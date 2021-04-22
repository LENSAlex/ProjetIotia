var express = require("express");
var mysql = require('mysql');
const fs = require('fs');
var app = express();


//Swagger
var swaggerTools  = require('swagger-tools');
var swaggerDoc = require('./Infrastructure.json')  

const port = 3000;

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
    Service qui traite de l'affichage d'informations sur les infrastructures de l'iut
*/

//Documentation Swagger
swaggerTools.initializeMiddleware(swaggerDoc, function (middleware) {
    // Serve the Swagger documents and Swagger UI
    app.use(middleware.swaggerUi());
  });

//GET---------------------

//Affichage nb etage et nb salle par campus
app.get("/Infrastructure/CountInfo/Campus", (req, res) => {
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
app.get("/Infrastructure/ListEquipement", (req, res) => {
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
app.get("/Infrastructure/ListSite", (req, res) => {
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
app.get("/Infrastructure/ListBatiment", (req, res) => {
    conn.query("select id_batiment ,id_site , nom as NomBatiment from Batiment", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


//lIST des etagesID
app.get("/Infrastructure/ListEtage", (req, res) => {
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
app.get("/Infrastructure/ListEtage/:IdBatiment", (req, res) => {
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
app.get("/Infrastructure/ListSalle/:IdEtage", (req, res) => {
    conn.query("select id_salle ,nom from Salle , Etage where Etage.id_etage = Salle.id_etage and Etage.id_etage = '" + req.params.IdEtage + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})






app.listen(port, () => {
    console.log('Server listen on port 3000')
})