var express = require("express");
var mysql = require('mysql');
const fs = require('fs');
var app = express();

//Swagger
var swaggerTools  = require('swagger-tools');
var swaggerDoc = require('./Alerte.json')  

const port = 3006;

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
    Service qui traite des alertes (covid , materielles)
*/

//Documentation Swagger
swaggerTools.initializeMiddleware(swaggerDoc, function (middleware) {
    // Serve the Swagger documents and Swagger UI
    app.use(middleware.swaggerUi());
  });

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

//POST
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



app.listen(port, () => {
    console.log('Server listen on port 3006')
})