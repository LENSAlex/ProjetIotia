var express = require("express");
var mysql = require('mysql');
var app = express();

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



//------------------------------GET ----------------------------

app.get("/Personne/CasCovid" , (req,res) =>{
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

app.get("/Batiment/CountInfo/Campus" , (req,res) =>{
    //Affichage de toutes les personne qui ont le covid
    //Pb pas remplie la table
    //demander a Pierre pour la requete la j arrive pas
    // conn.connect(function(err) {
    //     if (err)
    //         res.status(404).json({ ErrorConnection: 'Error bdd' });
    //     console.log("Connected!");
    //     conn.query("select P.nom , P.prenom , CC.date_declaration from Personne P , CasCovid CC where P.id_personne = CC.id_personne", function(err, result) {
    //         if (err)
    //             res.status(400).json({ ErrorRequete: 'Requete invalid' });
    //         else {
    //             res.status(200).json(result);
    //             console.log(result);
    //         }
    //     });
    // });
})

app.get("/Personne/ListPromo" , (req, res) =>
{

//Affichage formation avec departement et duree
    conn.query("select D.name , F.nom , F.duree from Formation F , Departement D where D.id_departement = F.id_departement", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    })
})

app.get("/Personne/ListEleve" , (req, res) =>
{

    //Prof faisable aussi voir demain

    //Affichage formation avec departement et duree
        conn.query("select P.nom , P.prenom , P.email , F.nom , PT.libelle from Personne P , PersonneType PT , Contenir C , Formation F where P.id_pers_type = PT.id_pers_type AND P.id_personne = C.id_eleve AND C.id_formation = F.id_formation", function(err, result) {
            if (err)
                res.status(400).json({ ErrorRequete: 'Requete invalid' });
            else {
                res.status(200).json(result);
                console.log(result);
            }
        });
})  

//Liste des devices sans arduino et rasp pour dorian
app.get("/Personne/ListDevice" , (req, res) =>
{

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

//List des capteurs (device)
app.get("/Personne/ListCapteur" , (req, res) =>
{

        conn.query("select DT.libelle_type , B.libelle from DeviceType DT , Device D , Box B where DT.id_devicetype = D.id_devicetype and D.id_box = B.id_box", function(err, result) {
            if (err)
                res.status(400).json({ ErrorRequete: 'Requete invalid' });
            else {
                res.status(200).json(result);
                console.log(result);
            }
        });
    }) 

//Info de chaque Box Ip , Etage , batiment ...
app.get("/Personne/Box/Info" , (req, res) =>
{

    //List device sans rpi et arduino 
        conn.query("select B.libelle , B.adr_ip , B.description ,Ba.nom , S.id_etage from Box B , Salle S , Etage E , Batiment Ba where B.id_salle = S.id_salle and S.id_etage = E.id_etage AND E.id_batiment = Ba.id_batiment", function(err, result) {
            if (err)
                res.status(400).json({ ErrorRequete: 'Requete invalid' });
            else {
                res.status(200).json(result);
                console.log(result);
            }
        });
})


// Get Capteur de la salle via search (Cherche les capteurs d'une salle via le numéro de salle)
//A voir avec Loris
app.get("/Capteur/Search/:IdSalle" , (req, res) =>
{
        conn.query("select B.libelle , B.adr_ip , B.description ,Ba.nom , S.id_etage from Box B , Salle S , Etage E , Batiment Ba where B.id_salle = S.id_salle and S.id_etage = E.id_etage AND E.id_batiment = Ba.id_batiment", function(err, result) {
            if (err)
                res.status(400).json({ ErrorRequete: 'Requete invalid' });
            else {
                res.status(200).json(result);
                console.log(result);
            }
        });
})



// Get Count des malades d'un salle, bâtiment et iut (Récupère le nombre de malade en fonction de ce qu'on a choisit)
//Voir avec Pierre
app.get("/Covid/Count/:IdSalle/:IdBatiment/" , (req, res) =>
{
    //Echelle Salle

    // select F.nom from CasCovid CC , Personne P , Contenir C , Formation F where CC.id_personne = P.id_personne and P.id_personne = C.id_eleve and C.id_formation = F.id_formation

    if(req.params.IdBatiment == 0)
    {
            conn.query("select B.libelle , B.adr_ip , B.description ,Ba.nom , S.id_etage from Box B , Salle S , Etage E , Batiment Ba where B.id_salle = S.id_salle and S.id_etage = E.id_etage AND E.id_batiment = Ba.id_batiment", function(err, result) {
                if (err)
                    res.status(400).json({ ErrorRequete: 'Requete invalid' });
                else {
                    res.status(200).json(result);
                    console.log(result);
                }
            });
    }
    //Echelle Batiment
    else
    {
            conn.query("select B.libelle , B.adr_ip , B.description ,Ba.nom , S.id_etage from Box B , Salle S , Etage E , Batiment Ba where B.id_salle = S.id_salle and S.id_etage = E.id_etage AND E.id_batiment = Ba.id_batiment", function(err, result) {
                if (err)
                    res.status(400).json({ ErrorRequete: 'Requete invalid' });
                else {
                    res.status(200).json(result);
                    console.log(result);
                }
            });
    }
    
})



// Get list des équipements pour le stock (Liste les équipements disponible dans l'établissement)
//Voir avec Loris




//-----------------------------------PUT-----------------------------
app.put("/Alerte/IsPenurie/:IdEquipement/:IdSalle" , (req, res) =>
{
        conn.query("UPDATE `Penurie` SET `is_penurie`=true,`date_maj`=NOW() WHERE id_equipement = '"+req.params.IdEquipement+"' and id_salle='"+req.params.IdSalle+"'", function(err, result) {
            if (err)
                res.status(400).json({ ErrorRequete: 'Requete invalid' });
            else {
                res.status(200).json(result);
                console.log(result);
            }
        });
})

app.put("/Alerte/NotPenurie/:IdEquipement/:IdSalle" , (req, res) =>
{
        conn.query("UPDATE `Penurie` SET `is_penurie`=false,`date_maj`=NOW() WHERE id_equipement = '"+req.params.IdEquipement+"' and id_salle='"+req.params.IdSalle+"'", function(err, result) {
            if (err)
                res.status(400).json({ ErrorRequete: 'Requete invalid' });
            else {
                res.status(200).json(result);
                console.log(result);
            }
        });
})

//-----------------------------------POST--------------------------------

//Envoie nouveau covid vers CasCovid
app.post("/Alerte/Covid/:IdPersonne" , (req, res) =>
{

        conn.query("INSERT INTO `CasCovid`(`id_personne`, `date_declaration`) VALUES ('"+req.params.IdPersonne+"',NOW())", function(err, result) {
            if (err)
                res.status(400).json({ ErrorRequete: 'Requete invalid' });
            else {
                res.status(200).json(result);
                console.log(result);
            }
        });
})


app.listen(port, () => {
    // console.log(`Example app listening at http://localhost:${port}`)
    console.log('Server listen on port 3001')
})