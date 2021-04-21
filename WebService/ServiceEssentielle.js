var express = require("express");
var mysql = require('mysql');
const fs = require('fs');
var app = express();

// npm i swagger-ui-express
//https://editor.swagger.io/
// const swaggerUi = require('swagger-ui-express');
// const swaggerJsDoc = require('swagger-jsdoc');

const port = 3001;

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

//Test doc swagger----------------------
// const swaggers 
// app.get("/Docs" , (req,res) =>
// {   
//     fs.readFile('swagger/Swagger_Editor.html', function(err, data) {
//         res.writeHead(200, {'Content-Type': 'text/html'});
//         res.write(data);
//         return res.end();
//     })
// })


//------------------------------GET ----------------------------

// app.get("/test/:id?", (req, res) => {
//     console.log("test")
//     res.end("ca marche");
// })

//Batiment-----
app.get("/Batiment/CountInfo/Campus", (req, res) => {
    //Affciahe nb etage et nb salle par campus
    conn.query("select a.nom , nbetage , nbsalle from (select Site.nom, count(id_salle) as nbsalle from Site, Batiment, Etage, Salle where Site.id_site = Batiment.id_site and Batiment.id_batiment = Etage.id_batiment and Etage.id_etage = Salle.id_etage group by Site.nom) a, (select Site.nom, count(Etage.id_etage) as nbetage from Site, Batiment, Etage where Site.id_site = Batiment.id_site and Batiment.id_batiment = Etage.id_batiment group by Site.nom) b where a.nom = b.nom", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    })
})

//List des equipement
app.get("/Batiment/ListEquipement", (req, res) => {
    conn.query("select id_equipement , libelle , description from Equipement", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List des sites
app.get("/Batiment/ListSite", (req, res) => {
    conn.query("select id_site , nom from Site", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List des Batiment
app.get("/Batiment/ListBatiment", (req, res) => {
    conn.query("select id_batiment ,id_site , nom as NomBatiment from Batiment", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


//DORIAN
//lIST des etagesID
app.get("/Batiment/ListEtage", (req, res) => {
    conn.query("select Etage.id_etage , Batiment.nom , Etage.num from Etage , Batiment WHERE Batiment.id_batiment = Etage.id_batiment", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


//List des etages d un batiment
app.get("/Batiment/ListEtage/:IdBatiment", (req, res) => {
    conn.query("select id_etage , num from Etage , Batiment where Etage.id_batiment = Batiment.id_batiment AND Batiment.id_batiment = '" + req.params.IdBatiment + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List des Salle d un etage
app.get("/Batiment/ListSalle/:IdEtage", (req, res) => {
    conn.query("select id_salle ,nom from Salle , Etage where Etage.id_etage = Salle.id_etage and Etage.id_etage = '" + req.params.IdEtage + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})




//Personne------

//list personne(nom , prenom)
app.get("/Personne/:Prenom/:Nom", (req, res) => {

    //Affichage formation avec departement et duree
    conn.query("select nom , prenom , email from Personne where nom LIKE '%" + req.params.Nom + "%' AND prenom LIKE '%" + req.params.Prenom + "%'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
        }
    })
})

app.get("/Personne/ListPromo", (req, res) => {

    //Affichage formation avec departement et duree
    conn.query("select P.id_promotion , F.nom , P.annee ,F.duree from Promotion P , Formation F , Departement D where P.id_formation = F.id_formation and D.id_departement = F.id_departement ", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    })
})

app.get("/Personne/ListPersonne", (req, res) => {

    //Prof faisable aussi voir demain

    //Affichage formation avec departement et duree
    conn.query("select * from (select Personne.id_personne, num_ref, Personne.id_pers_type, password, email, telephone, sexe, nom, prenom, date_anniversaire, rfid, libelle, description from Personne, PersonneType where Personne.id_pers_type = PersonneType.id_pers_type) pers LEFT JOIN (select nom as NomFormation, Contenir.id_promotion, id_eleve from (select id_promotion, nom from Promotion, Formation where Promotion.id_formation = Formation.id_formation and (annee + duree) >= (SELECT YEAR(NOW()))) a, Contenir where a.id_promotion = Contenir.id_promotion) b on pers.id_personne = b.id_eleve", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


//List des types de personne
app.get("/Personne/ListTypePersonne", (req, res) => {
    conn.query("select id_pers_type , libelle from PersonneType", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List Promo
app.get("/Personne/ListPromo/Simple", (req, res) => {
    conn.query("select id_promotion , Formation.nom from Promotion , Formation where Promotion.id_formation = Formation.id_formation", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List Salle pour eleve
app.get("/Personne/ListSalleEleve/:Id", (req, res) => {
    conn.query("select distinct P.id_personne,S.id_salle from Personne P , Contenir C , Promotion Po , Cours Cou , Salle S where P.id_personne = C.id_eleve AND C.id_promotion = Po.id_promotion AND Po.id_promotion = Cou.id_promotion AND Cou.id_salle = S.id_salle and P.id_personne = '" + req.params.Id + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Selection Personne via nom , prenom , email
app.get("/Personne/GetIdEleve/:Nom/:Prenom/:Email", (req, res) => {
    var id;
    conn.query("select id_personne from Personne where nom = '" + req.params.Nom + "' and prenom = '" + req.params.Prenom + "' and email = '" + req.params.Email + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            result.forEach((result) => {
                id = result.id_personne;
            });
            conn.query("INSERT INTO `CasCovid`(`id_personne`, `date_declaration`) VALUES ('" + id + "',NOW())", function(err, result) {
                if (err)
                    res.status(400).json({ ErrorRequete: 'Requete invalid' });
                else {
                    res.status(200).json("Cas covid cree");
                }
            });
        }
    });
})


//Selection Personne via INE (unique normalement)
app.get("/Personne/GetIdEleve/:Ine", (req, res) => {
    var id;
    conn.query("select id_personne from Personne where num_ref = '" + req.params.Ine + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            result.forEach((result) => {
                id = result.id_personne;
            });
            conn.query("INSERT INTO `CasCovid`(`id_personne`, `date_declaration`) VALUES ('" + id + "',NOW())", function(err, result) {
                if (err)
                    res.status(400).json({ ErrorRequete: 'Requete invalid' });
                else {
                    res.status(200).json(result);
                }
            });
        }
    });
})

//DORIAN
//LIST des professeur
app.get("/Personne/ListProf", (req, res) => {
    var id;
    conn.query("select distinct Promotion.id_professeur , Personne.nom , Personne.prenom from Promotion , Personne where Promotion.id_professeur = Personne.id_personne", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
        }
    });
})



//Covid---------

app.get("/Covid/CasCovid", (req, res) => {
    //Affichage de toutes les personne qui ont le covid
    //Pb pas remplie la table
    conn.query("select P.nom , P.prenom , CC.date_declaration from Personne P , CasCovid CC where P.id_personne = CC.id_personne", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

app.get("/Covid/Count/CasCovid/Formation", (req, res) => {
    conn.query("select F.nom , count(*) as NbCasCovid from CasCovid CC , Personne P , Contenir C , Promotion Po , Formation F    where     CC.id_personne = P.id_personne    and     P.id_personne = C.id_eleve    AND    Po.id_promotion = C.id_promotion    and     Po.id_formation = F.id_formation    group by F.nom", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


app.get("/Covid/Count/CasCovid/Departement", (req, res) => {
    conn.query("select D.name , count(*) as NbCasCovid from CasCovid CC , Personne P , Contenir C , Promotion Po , Formation F , Departement D    where     CC.id_personne = P.id_personne    and     P.id_personne = C.id_eleve    AND    Po.id_promotion = C.id_promotion    and     Po.id_formation = F.id_formation AND F.id_departement = D.id_departement group by D.name", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

app.get("/Covid/Count/CasCovid/Formation/:IdFormation", (req, res) => {
    conn.query("select F.nom , count(*) as NbCasCovid from CasCovid CC , Personne P , Contenir C , Promotion Po , Formation F    where     CC.id_personne = P.id_personne    and     P.id_personne = C.id_eleve    AND    Po.id_promotion = C.id_promotion    and     Po.id_formation = F.id_formation  and F.id_formation='" + req.params.IdFormation + "'  group by F.nom", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


app.get("/Covid/Count/CasCovid/Departement/:IdDepartement", (req, res) => {
    conn.query("select D.name , count(*) as NbCasCovid from CasCovid CC , Personne P , Contenir C , Promotion Po , Formation F , Departement D   where     CC.id_personne = P.id_personne    and     P.id_personne = C.id_eleve    AND    Po.id_promotion = C.id_promotion    and     Po.id_formation = F.id_formation AND F.id_departement = D.id_departement and D.id_departement= '" + req.params.IdDepartement + "' group by D.name", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


//Capteur-----
//List des ValueType
app.get("/Capteur/ListValueType", (req, res) => {
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
app.get("/Capteur/ListDevice", (req, res) => {
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

// Get Capteur de la salle via search (Cherche les capteurs d'une salle via le numéro de salle)
app.get("/Capteur/Search/:NomSalle", (req, res) => {
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
app.get("/Capteur/Box/Info", (req, res) => {

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
app.get("/Capteur/ListCapteur/:Salle", (req, res) => {
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
app.get("/Capteur/ListCapteur", (req, res) => {

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
app.get("/Capteur/ListComplete", (req, res) => {
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
app.get("/Capteur/ListSalle", (req, res) => {
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
app.get("/Capteur/Valeur/:IdSalle", (req, res) => {
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
app.get("/Capteur/Valeur/:IdSalle/:IdValueType", (req, res) => {
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
app.get("/Capteur/ValeurSpecifique/:IdDevice", (req, res) => {
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


app.get("/Capteur/List/Historique", (req, res) => {
    conn.query("select ValueType.libelle , Device.id_device , Historique.valeur , ValueType.unite , DeviceType.libelle_type from Historique , Device , ValueType , DeviceType WHERE Historique.id_device = Device.id_device AND Device.id_valuetype = ValueType.id_valuetype and DeviceType.id_devicetype = Device.id_devicetype", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

app.get("/Capteur/ValeurSpecifique/Last/:IdDevice", (req, res) => {
    conn.query("select Historique.valeur , ValueType.unite , ValueType.libelle , DeviceType.libelle_type from Historique , Device , ValueType , DeviceType WHERE Historique.id_device = Device.id_device AND Device.id_valuetype = ValueType.id_valuetype AND Historique.id_device = 1 and DeviceType.id_devicetype = Device.id_devicetype order by Historique.valeur desc LIMIT 1", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

app.get("/Capteur/ValeurSpecifique/Moyenne/:IdDevice", (req, res) => {
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
app.get("/Capteur/List/Historique/Temp", (req, res) => {
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
app.get("/Capteur/List/Historique/CO2", (req, res) => {
    conn.query("select DT.libelle_type , B.libelle , H.valeur , S.nom as NomSalle , E.num as NomEtage, Bat.nom as NomBatiment, Site.nom as NomSite , H.date_historique from Historique H , Device D , DeviceType DT, Box B , Salle S , Etage E , Batiment Bat , Site WHERE H.id_device = D.id_device and DT.id_devicetype = D.id_devicetype AND D.id_box = B.id_box and B.id_salle = S.id_salle and E.id_etage = S.id_etage AND Bat.id_batiment = E.id_batiment AND Bat.id_site = Site.id_site AND DT.id_devicetype = 3 order by H.date_historique DESC", function(err, result) {
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
app.get("/Capteur/List/Historique/Energie", (req, res) => {
    conn.query("select VT.libelle , B.libelle , H.valeur from Historique H , Device D , ValueType VT, Box B WHERE H.id_device = D.id_device and VT.id_valuetype = D.id_valuetype AND D.id_box = B.id_box AND VT.id_valuetype = 9 order by H.date_historique DESC", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List du taux occupation par salle
//select distinct id_personne , statut  from Badgeuse where statut = 1  
//Commencé mais trop dure faudra que tu demande a pierre
app.get("/Capteur/List/TauxOccupation", (req, res) => {
    conn.query("", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//-----------------------------------PUT-----------------------------
app.put("/Alerte/IsPenurie/:IdEquipement/:IdSalle", (req, res) => {
    conn.query("UPDATE `Penurie` SET `is_penurie`=true,`date_maj`=NOW() WHERE id_equipement = '" + req.params.IdEquipement + "' and id_salle='" + req.params.IdSalle + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

app.put("/Alerte/NotPenurie/:IdEquipement/:IdSalle", (req, res) => {
    conn.query("UPDATE `Penurie` SET `is_penurie`=false,`date_maj`=NOW() WHERE id_equipement = '" + req.params.IdEquipement + "' and id_salle='" + req.params.IdSalle + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Modifs eleve
app.put("/Personne/Modifs/:NumRef/:IdPersType/:Password/:Email/:Tel/:Sexe/:Nom/:Prenom/:Birth/:IdPromo/:IdPersonne", (req, res) => {

    //localhost:3001/Personne/Add/125/1/test/alex.@gmail.com/0607070705/F/LENS/AL/1908-08-11 01:00:00/1
    conn.query("UPDATE `Personne` SET `num_ref` = '" + req.params.NumRef + "', `id_pers_type` = '" + req.params.IdPersType + "', `password` = '" + req.params.Password + "', `email` = '" + req.params.Email + "', `telephone` = '" + req.params.Tel + "', `sexe`= '" + req.params.Sexe + "', `nom` = '" + req.params.Nom + "', `prenom` = '" + req.params.Prenom + "', `date_anniversaire` = '" + req.params.Birth + "' where id_personne = '" + req.params.IdPersonne + "' ", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            // res.status(200).json("Personne Creer");
        }
    });

    //La je vais chercher la requete que je viens d envoyer pour avoir l id de l utilisateur cree
    //Que si eleve
    if ( req.params.IdPersType == 1) {
            //La je vais chercher la requete que je viens d envoyer pour avoir l id de l utilisateur cree
        conn.query("UPDATE `Contenir` set `id_promotion` = " + req.params.IdPromo + " where id_eleve= " + req.params.IdPersonne + "", function(err, result) {
            if (err)
                res.status(400).json({ ErrorRequete: 'Requete invalid' });
            else {
                res.status(200).json("Etudiant modifier");
            }
        });
    } else {
        res.status(200);
    }

})

//Modif Formation
app.put("/Personne/Modifs/Formation/:IdDepartement/:NomFormation/:DureeFormation/IdFormation", (req, res) => {

    //liée la table formation et promotion 
    //Creation d'une formation:
    conn.query("update `Formation` set `id_departement`='" + req.params.IdDepartement + "' ,  `nom` = '" + req.params.NomFormation + "', `duree` = '" + req.params.DureeFormation + "' where id_formation = '" + req.params.IdFormation + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: err });
        else {
            res.status(200).json("Formation modifié");
        }
    })

})

//Modifs Promo
app.put("/Personne/Modifs/Promo/:AnneePromotion/:IdProfesseurPromotion/:IdPromo", (req, res) => {
    conn.query("update `Promotion` set `id_professeur` = '" + req.params.IdProfesseurPromotion + "', `annee` = '" + req.params.AnneePromotion + "' where id_promotion = '" + req.params.IdPromo + "' ", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json("Promotion modifié");
        }
    })
})


//-----------------------------------POST--------------------------------

//Personne --------------------
//Ajout personne
app.post("/Personne/Add/:NumRef/:IdPersType/:Password/:Email/:Tel/:Sexe/:Nom/:Prenom/:Birth/:IdPromo", (req, res) => {

    var idUser;
    var TypePers;

    //localhost:3001/Personne/Add/125/1/test/alex.@gmail.com/0607070705/F/LENS/AL/1908-08-11 01:00:00/1
    conn.query("INSERT INTO `Personne`(`num_ref`, `id_pers_type`, `password`, `email`, `telephone`, `sexe`, `nom`, `prenom`, `date_anniversaire`) VALUES ('" + req.params.NumRef + "','" + req.params.IdPersType + "', '" + req.params.Password + "' , '" + req.params.Email + "', '" + req.params.Tel + "' , '" + req.params.Sexe + "' , '" + req.params.Nom + "' , '" + req.params.Prenom + "' , '" + req.params.Birth + "')", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            // res.status(200).json("Personne Creer");
        }
    });

    //La je vais chercher la requete que je viens d envoyer pour avoir l id de l utilisateur cree
    conn.query("SELECT id_personne , id_pers_type from Personne order by id_personne DESC LIMIT 1", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            // res.status(200);
            result.forEach((result) => {
                idUser = result.id_personne;
                TypePers = result.id_pers_type
                console.log(idUser + "" + TypePers)
            });

            console.log("avant boucle" + idUser + "" + TypePers)

            //Que si eleve
            if (TypePers == 1) {
                console.log("dedans")
                    //La je vais chercher la requete que je viens d envoyer pour avoir l id de l utilisateur cree
                conn.query("INSERT INTO `Contenir`(`id_promotion`, `id_eleve`) VALUES ('" + req.params.IdPromo + "','" + idUser + "')", function(err, result) {
                    if (err)
                        res.status(400).json({ ErrorRequete: 'Requete invalid' });
                    else {
                        res.status(200).json("Etudiant integrer dans la table Contenir");
                    }
                });
            } else {
                res.status(200);
            }

        }
    });

})

//Ajout d'un utilisateur rapide
app.post("/Personne/Add/Test/:Nom/:Prenom", (req, res) => {

    conn.query("INSERT INTO `Personne`(`nom`, `prenom` , `num_ref` , `id_pers_type` , `password` ) VALUES ('" + req.params.Nom + "' , '" + req.params.Prenom + "' , '25416' , '1' , 'password')", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json("Cas covid cree");
        }
    });
})

//Add promo
app.post("/Personne/Add/Promo/:IdDepartement/:NomFormation/:DureeFormation/:AnneePromotion/:IdProfesseurPromotion", (req, res) => {

    //liée la table formation et promotion 
    //Creation d'une formation:
    conn.query("INSERT INTO `Formation` (`id_departement`, `nom`, `duree`) VALUES('" + req.params.IdDepartement + "', '" + req.params.NomFormation + "', '" + req.params.DureeFormation + "')", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: err });
        else {
            //liaison de la formation avec la promotion:
            var IDFormation = result.insertId;
            conn.query("INSERT INTO `Promotion`(`id_formation`, `id_professeur`, `annee`) VALUES ('" + IDFormation + "','" + req.params.IdProfesseurPromotion + "','" + req.params.AnneePromotion + "')", function(err, result) {
                if (err)
                    res.status(400).json({ ErrorRequete: 'Requete invalid' });
                else {
                    res.status(200).json("Promotion cree");
                }
            })
        }
    })

})

//Covid-------------------
//Envoie nouveau covid vers CasCovid
app.post("/Alerte/Covid/:IdPersonne", (req, res) => {

    conn.query("INSERT INTO `CasCovid`(`id_personne`, `date_declaration`) VALUES ('" + req.params.IdPersonne + "',NOW())", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json("Utilisateur test cree");
        }
    });
})


//Capteur -------------- 

//DORIAN
//Il faut liée les capteurs avec la box
//Faire la meme chose avec batiment , puis etage et salle pour mettre la box donc Choisir son batiment , puis son etage , puis sa salle
//Donc quand on a la salle on peut remplir la box et device
//Dropdown id_devicetype , batiment , etage , salle , id_valuetype
app.post("/Capteur/Add/BoxDevice/:IdSalle/:IdDeviceType/:AddrMac/:AddrIp/:LibelleBox/:DescriptionBox/:DateInstallation/:IdValueType/:LibelleDevice/:SeuilMin?/:SeuilMax?", (req, res) => {

    //D'abord requete Box
    conn.query("INSERT INTO `Box`(`id_salle`, `id_devicetype`, `adr_mac`, `adr_ip`, `libelle`, `description`, `date_installation`) VALUES ('" + req.params.IdSalle + "','" + req.params.IdDeviceType + "','" + req.params.AddrMac + "','" + req.params.AddrIp + "','" + req.params.Libelle + "','" + req.params.Description + "','" + req.params.DateInstallation + "')", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            //Puis device
            var IdBox = result.insertId;
            conn.query("INSERT INTO `Device`(`id_box`, `id_devicetype`, `id_valuetype`, `libelle`, `seuil_min`, `seuil_max`) VALUES ('" + IdBox + "','" + req.params.IdDeviceType + "','" + req.params.IdValueType + "','" + req.params.LibelleDevice + "','" + req.params.SeuilMin + "','" + req.params.SeuilMax + "')", function(err, result) {
                if (err)
                    res.status(400).json({ ErrorRequete: 'Requete invalid' });
                else {
                    res.status(200).json("Box et capteur cree");
                }
            })

        }
    });
})


//DORIAN
//creation actionneur peut etre capteur bouton dans Devicetype = 11 Voir dropdown ValueType je ne sais pas celui d un actionneur
app.post("/Capteur/Add/Actionneur/:IdBox/:IdValueType/:Libelle", (req, res) => {

    conn.query("INSERT INTO `Device`(`id_box`, `id_devicetype`, `id_valuetype`, `libelle`) VALUES ('" + req.params.IdBox + "', 11 ,'" + req.params.IdValueType + "','" + req.params.libelle + "')", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json("Actionneur cree");
        }
    });
})

//DORIAN
//creation panneau solaire peut etre capteur bouton dans Devicetype = 17 , 7 en ValueType (Lumens)
app.post("/Capteur/Add/PanneauSolaire/:IdBox/:Libelle", (req, res) => {

    conn.query("INSERT INTO `Device`(`id_box`, `id_devicetype`, `id_valuetype`, `libelle`) VALUES ('" + req.params.IdBox + "', 17 ,7,'" + req.params.libelle + "')", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: err });
        else {
            res.status(200).json("Panneau solaire cree");
        }
    });
})


//Batiment --------------

//DORIAN
//Creation d'un batiment et des etages correspondant : DropDown IdCampus , envoie du nombre de batiment et superficie etage
app.post("/Batiment/Add/Batiment/:Nom/:Superficie/:IdCampus/:EtageSuperficie", (req, res) => {
    // console.log(req.params.EtageSuperficie.SuperficieEtage)

    conn.query("INSERT INTO `Batiment`(`id_site`, `nom`, `surface`) VALUES ('" + req.params.IdCampus + "','" + req.params.Nom + "','" + req.params.Superficie + "')", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            var IdBatiment = result.insertId; //Id du batiment
            var json = JSON.parse(req.params.EtageSuperficie) //json 
            var numEtage = ['RDC', '1er', '2eme', '3eme', '4eme', '5eme']; //nom etage
            var compteur = 0;
            json.SuperficieEtage.forEach((result) => {
                // console.log(result);
                // console.log("Etage = " + result.Etage);
                // console.log("Superficie = " + result.Superficie);
                conn.query("INSERT INTO `Etage`(`id_batiment`, `num`, `surface`) VALUES ('" + IdBatiment + "','" + numEtage[compteur] + "','" + result.Superficie + "')", function(err, result) {
                    if (err)
                        res.status(400).json({ ErrorRequete: 'Requete invalid' });
                    else {
                        compteur++;
                    }
                });
            });
            res.status(200).json("Batiment et etage creer");
        }
    })
})


//DORIAN
//Creation d'une salle a partir : DropDown Etage , dropdown Batiment
//Du coup on choisit son batiment et en fonction de ca on a les Etage du batiment
//Utilisés cette route pour avoir les etages /Batiment/ListEtage/:IdBatiment
//DOnc apres choisir son etage et inserer ca salle
app.post("/Batiment/Add/Salle/:IdEtage/:Nom/:CapaciteMax/:Surface/:Volume", (req, res) => {

    conn.query("INSERT INTO `Salle`(`id_etage`, `nom`, `capacite_max`, `surface`, `volume`) VALUES ('" + req.params.IdEtage + "','" + req.params.Nom + "','" + req.params.CapaciteMax + "','" + req.params.Surface + "','" + req.params.Volume + "')", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json("Salle cree");
        }
    });
})


//Delete --------------------------------------------------

//Supp user 
app.delete("/Personne/Delete/:IdUser", (req, res) => {

    conn.query("DELETE FROM `Contenir` WHERE id_eleve = " + req.params.IdUser + "", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: err });
        else {
            conn.query("DELETE FROM `CasCovid` WHERE id_personne = " + req.params.IdUser + "", function(err, result) {
                if (err)
                    res.status(400).json({ ErrorRequete: err });
                else {
                    conn.query("DELETE FROM `Absence` WHERE id_personne = " + req.params.IdUser + "", function(err, result) {
                        if (err)
                            res.status(400).json({ ErrorRequete: err });
                        else {
                            conn.query("DELETE FROM `Presentiel` WHERE id_personne = " + req.params.IdUser + "", function(err, result) {
                                if (err)
                                    res.status(400).json({ ErrorRequete: err });
                                else {
                                    conn.query("DELETE FROM `Personne` WHERE id_personne = " + req.params.IdUser + "", function(err, result) {
                                        if (err)
                                            res.status(400).json({ ErrorRequete: err });
                                        else {
                                            res.status(200).json("Utilisateur avec id = " + req.params.IdUser + " a ete supprimer");
                                        }
                                    });
                                }
                            });
                        }
                    });
                    
                }
            });
        }
    });
})

//Supp promotion 
app.delete("/Personne/Delete/:IdPromo", (req, res) => {

    conn.query("DELETE FROM `Contenir` WHERE id_eleve = " + req.params.IdUser + "", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: err });
        else {
         
        }
    });
})

//Supp Campus 
app.delete("/Batiment/Delete/:IdCampus", (req, res) => {

    conn.query("DELETE FROM `AccesSite` WHERE id_site = " + req.params.IdCampus + "", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: err });
        else {
            conn.query("DELETE FROM `Batiment` WHERE id_site = " + req.params.IdCampus + "", function(err, result) {
                if (err)
                    res.status(400).json({ ErrorRequete: err });
                else {
                    conn.query("DELETE FROM `Site` WHERE id_site = " + req.params.IdCampus + "", function(err, result) {
                        if (err)
                            res.status(400).json({ ErrorRequete: err });
                        else {
                            res.status(200).json("Campus avec id = " + req.params.IdCampus + " a ete supprimer");
                        }
                    });
                }
            });
        }
    });
})


//Supp Device 
app.delete("/Capteur/Delete/:IdDevice", (req, res) => {

    conn.query("DELETE FROM `Contenir` WHERE id_eleve = " + req.params.IdUser + "", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: err });
        else {
         
        }
    });
})




app.listen(port, () => {
    // console.log(`Example app listening at http://localhost:${port}`)
    console.log('Server listen on port 3001')
})