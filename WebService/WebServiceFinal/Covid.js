var express = require("express");
var mysql = require('mysql');
const fs = require('fs');
var app = express();

//Swagger
var swaggerTools  = require('swagger-tools');
var swaggerDoc = require('./Covid.json')  

const port = 3002;

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
    Service qui traite de l'affichage des cas covid suspecter a l'iut , par formation ...
*/

//Documentation Swagger
swaggerTools.initializeMiddleware(swaggerDoc, function (middleware) {
    // Serve the Swagger documents and Swagger UI
    app.use(middleware.swaggerUi());
  });

//GET ----------------------------------
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


app.listen(port, () => {
    console.log('Server listen on port 3002')
})