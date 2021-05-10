var express = require("express");
var mysql = require('mysql');
const fs = require('fs');
var app = express();

//Swagger
var swaggerTools  = require('swagger-tools');
var swaggerDoc = require('./InfraProd.json')  

const port = 3005;

// BDD--------------------
console.log('Get connection ...');
var conn = mysql.createConnection({
    database: 'ProjetIotia',
    host: "51.75.125.121",
    user: "iotia",
    password: "iotia"
});

conn.connect(function(err) {
    if (err)
        res.status(404).json({ ErrorConnection: 'Error bdd' });
    console.log("Connected!");
})

/*
    Service qui traite de l affichage des valeurs des capteurs et actionneurs
*/

//Documentation Swagger
swaggerTools.initializeMiddleware(swaggerDoc, function (middleware) {
    // Serve the Swagger documents and Swagger UI
    app.use(middleware.swaggerUi());
  });



//GET -------------------------------------
//Capteur-----
//List des ValueType
app.get("/InfraProd/ListValueType", (req, res) => {
    conn.query("SELECT `id_valuetype`, `libelle`, `unite` FROM `ValueType`", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Liste des devices sans arduino et rasp pour dorian
app.get("/InfraProd/ListDevice", (req, res) => {
    //List device sans rpi et arduino 
    conn.query("select id_devicetype , libelle_type from DeviceType where id_devicetype <> 1 and id_devicetype <> 2", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})



app.get("/InfraProd/Device/:id", (req, res) => {
    //List device sans rpi et arduino 
    conn.query("select Device.libelle , DeviceType.description , DeviceType.id_devicetype , Box.date_installation , Box.description , Box.libelle , Salle.nom , Salle.id_salle , Box.adr_mac , Box.adr_ip , Device.seuil_min , Device.seuil_max from Device , DeviceType , Box , Salle where Device.id_devicetype = DeviceType.id_devicetype AND Device.id_box = Box.id_box AND Box.id_salle = Salle.id_salle AND Device.id_device = '" + req.params.id + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})




// Get Capteur de la salle via search (Cherche les capteurs d'une salle via le numéro de salle)
app.get("/InfraProd/Search/:NomSalle", (req, res) => {
    conn.query("select S.id_salle ,S.nom ,D.id_device ,B.libelle , B.adr_ip , B.description ,Ba.nom , S.id_etage from Box B , Salle S , Etage E , Batiment Ba , Device D where B.id_salle = S.id_salle and S.id_etage = E.id_etage AND E.id_batiment = Ba.id_batiment and B.id_box = D.id_box and S.nom = '" + req.params.NomSalle + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Info de chaque Box Ip , Etage , batiment ...
app.get("/InfraProd/Box/Info", (req, res) => {

    //List device sans rpi et arduino 
    conn.query("select c.id_salle , c.id_box ,c.libelle , c.adr_ip , c.description ,c.nom , c.id_etage , c.nom as NomSalle , COALESCE(PanneauSolaire,0) as PanneauSolaire , COALESCE(NbBouton,0) as NbBouton  from (select a.id_salle , a.id_box ,a.libelle , a.adr_ip , a.description ,a.nom , a.id_etage , a.nom as NomSalle , PanneauSolaire from (select B.id_salle , B.id_box ,B.libelle , B.adr_ip , B.description ,S.nom , S.id_etage , S.nom as NomSalle from Box B , Salle S , Etage E , Batiment Ba where B.id_salle = S.id_salle and S.id_etage = E.id_etage AND E.id_batiment = Ba.id_batiment)a LEFT JOIN (select S.id_salle , count(*) as PanneauSolaire from DeviceType DT , Device D , Box B , Salle S where DT.id_devicetype = D.id_device AND D.id_box = B.id_box AND B.id_salle = S.id_salle AND DT.id_devicetype = 17 group by S.id_salle) b on a.id_salle = b.id_salle) c LEFT JOIN (select S.id_salle , count(*) as NbBouton from Device D , Box B , Salle S where D.id_box = B.id_box AND B.id_salle = S.id_salle AND D.id_devicetype = 11 group by S.id_salle) d on c.id_salle = d.id_salle", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//All Capteur d une salle
app.get("/InfraProd/ListCapteur/:Salle", (req, res) => {
    conn.query("select D.id_device , VT.libelle from ValueType VT , Device D , Box B , Salle S where D.id_valuetype = VT.id_valuetype AND D.id_box = B.id_box and B.id_salle = S.id_salle and S.nom = '" + req.params.Salle + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Liste des devices sans arduino et rasp pour dorian
//Attend confirmation de dorian car la elle sert a rien
// app.get("/Capteur/ListDevice/All", (req, res) => {

//     //List device sans rpi et arduino 
//     conn.query("select Device.id_devicetype as TypeCapteur , Box.id_box as IDBoxCapteur, DeviceType.id_devicetype, libelle_type from DeviceType, Box , Device where Box.id_devicetype = DeviceType.id_devicetype AND Box.id_box = Device.id_box and DeviceType.id_devicetype <> 1 and DeviceType.id_devicetype <> 2", function(err, result) {
//         if (err)
//             res.status(400).json({ ErrorRequete: 'Requete invalid' });
//         else {
//             res.status(200).json(result);
//             console.log(result);
//         }
//     });
// })

//List des capteurs (device)
//Utilisés par loris
app.get("/InfraProd/ListCapteur", (req, res) => {

    conn.query("select D.id_device ,DT.libelle_type , B.libelle from DeviceType DT , Device D , Box B where DT.id_devicetype = D.id_devicetype and D.id_box = B.id_box", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List capteur dernieres de DORIAN
app.get("/InfraProd/ListComplete", (req, res) => {
    conn.query("select D.id_device ,VT.libelle as nom, B.id_box from ValueType VT , Device D , Box B where VT.id_valuetype = D.id_valuetype and D.id_box = B.id_box order by D.id_device", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            console.log(result);
            res.status(200).json(result);
        }
    });
})


//Affichage des salles comme ca pour avoir id_box
app.get("/InfraProd/ListSalle", (req, res) => {
    conn.query("select S.nom , B.id_box , B.id_salle from Box B , Salle S where B.id_salle = S.id_salle", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Chercher les valeurs d une salle
app.get("/InfraProd/Valeur/:IdSalle", (req, res) => {
    conn.query("select H.valeur , VT.libelle , S.nom from Historique H , ValueType VT , Box B , Salle S where H.id_valuetype = VT.id_valuetype and H.id_box = B.id_box and B.id_salle = S.id_salle AND S.id_salle = '" + req.params.IdSalle + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Chercher une valeur precise dans une salle garce a son type 
app.get("/InfraProd/Valeur/:IdSalle/:IdValueType", (req, res) => {
    conn.query("select H.valeur , VT.libelle , S.nom from Historique H , ValueType VT , Box B , Salle S where H.id_valuetype = VT.id_valuetype and H.id_box = B.id_box and B.id_salle = S.id_salle AND S.id_salle = '" + req.params.IdSalle + "' and H.id_valuetype = '" + req.params.IdValueType + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


//Recup valeur d un capteur specifique
app.get("/InfraProd/ValeurSpecifique/:IdDevice", (req, res) => {
    //les jointures ne fonctionait pas
    var id_box, id_valuetype;
    conn.query("select id_box , id_valuetype , DeviceType.libelle_type from Device , DeviceType where id_device = '" + req.params.IdDevice + "' and DeviceType.id_devicetype = Device.id_devicetype", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            result.forEach((result) => {
                id_box = result.id_box;
                id_valuetype = result.id_valuetype;
            });
            conn.query("select * from Historique where id_box = '" + id_box + "' and id_valuetype = '" + id_valuetype + "'", function(err, result) {
                if (err)
                    res.status(400).json({ ErrorRequete: 'Requete invalid' });
                else {
                    res.status(200).json(result);
                }
            });
        }
    });
})


app.get("/InfraProd/List/Historique", (req, res) => {
    conn.query("select ValueType.libelle , Device.id_device , Historique.valeur , ValueType.unite , DeviceType.libelle_type from Historique , Device , ValueType , DeviceType WHERE Historique.id_device = Device.id_device AND Device.id_valuetype = ValueType.id_valuetype and DeviceType.id_devicetype = Device.id_devicetype", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

app.get("/InfraProd/ValeurSpecifique/Last/:IdDevice", (req, res) => {
    conn.query("select Historique.valeur , ValueType.unite , ValueType.libelle , DeviceType.libelle_type from Historique , Device , ValueType , DeviceType WHERE Historique.id_device = Device.id_device AND Device.id_valuetype = ValueType.id_valuetype AND Historique.id_device = 1 and DeviceType.id_devicetype = Device.id_devicetype order by Historique.valeur desc LIMIT 1", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

app.get("/InfraProd/ValeurSpecifique/Moyenne/:IdDevice", (req, res) => {
    conn.query("select AVG(Historique.valeur) as Moyenne , ValueType.unite , ValueType.libelle , DeviceType.libelle_type from Historique , Device , ValueType , DeviceType WHERE Historique.id_device = Device.id_device AND Device.id_valuetype = ValueType.id_valuetype AND Historique.id_device = 1 and DeviceType.id_devicetype = Device.id_devicetype order by Historique.valeur desc LIMIT 1", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List des capteur temps dans l historique plus recent au plus vieux
app.get("/InfraProd/List/Historique/Temp", (req, res) => {
    conn.query("select DT.libelle_type , B.libelle , H.valeur from Historique H , Device D , DeviceType DT , Box B WHERE H.id_device = D.id_device and DT.id_devicetype = D.id_devicetype AND D.id_box = B.id_box and DT.id_devicetype = 4 order by H.date_historique DESC ", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List des capteur co2 dans l historique plus recent au plus vieux
app.get("/InfraProd/List/Historique/CO2", (req, res) => {
    conn.query("select Site.nom ,Bat.nom , S.nom , DT.libelle_type , B.libelle , H.valeur , S.nom as NomSalle , E.num as NomEtage, Bat.nom as NomBatiment, Site.nom as NomSite , H.date_historique , H.date_historique from Historique H , Device D , DeviceType DT, Box B , Salle S , Etage E , Batiment Bat , Site WHERE H.id_device = D.id_device and DT.id_devicetype = D.id_devicetype AND D.id_box = B.id_box and B.id_salle = S.id_salle and E.id_etage = S.id_etage AND Bat.id_batiment = E.id_batiment AND Bat.id_site = Site.id_site AND DT.id_devicetype = 3 order by H.date_historique DESC", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List des capteur energie dans l historique plus recent au plus vieux
//A voir avec dorian
app.get("/InfraProd/List/Historique/Energie", (req, res) => {
    conn.query("select VT.libelle , B.libelle , H.valeur from Historique H , Device D , ValueType VT, Box B WHERE H.id_device = D.id_device and VT.id_valuetype = D.id_valuetype AND D.id_box = B.id_box AND VT.id_valuetype = 9 order by H.date_historique DESC", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Tous les capteurs d une box
app.get("/InfraProd/Box/:IdBox", (req, res) => {
    conn.query("select Device.id_device , Device.libelle from Device , Box WHERE Device.id_box = Box.id_box AND Box.id_box = '" + req.params.IdBox + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Tous les actionneur d une box
app.get("/InfraProd/Box/Actionneur/:IdBox", (req, res) => {
    conn.query("select Device.id_device , Device.libelle from Device , Box , DeviceType WHERE Device.id_box = Box.id_box AND Box.id_box = '" + req.params.IdBox + "' AND Box.id_devicetype = DeviceType.id_devicetype AND DeviceType.id_devicetype = 11", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Tous les panneau solaire d une box
app.get("/InfraProd/Box/PanneauSolaire/:IdBox", (req, res) => {
    conn.query("select Device.id_device , Device.libelle from Device , Box , DeviceType WHERE Device.id_box = Box.id_box AND Box.id_box = '" + req.params.IdBox + "' AND Box.id_devicetype = DeviceType.id_devicetype AND DeviceType.id_devicetype = 17", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})



app.listen(port, () => {
    console.log('Server listen on port 3005')
})