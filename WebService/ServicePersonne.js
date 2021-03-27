var express = require("express");
var mysql = require('mysql');
var app = express();

const port = 3000;

// BDD--------------------
console.log('Get connection ...');
var conn = mysql.createConnection({
  database: 'test',
  host: "51.75.125.121",
  user: "alex",
  password: "Jessicalex2510*"
});

//https://www.sitepoint.com/using-node-mysql-javascript-client/

//Requete simple
//Example
// conn.connect(function(err) {
//     if (err)
//         res.status(404).json({ ErrorConnection: 'Error bdd' });
//     console.log("Connected!");
//         conn.query("SELECT * from Authentification", function (err, result) {
//         if (err)
//             res.status(400).json({ ErrorRequete: 'Requete invalid' });
//         else
//         {
//             res.status(200).json(result);
//             console.log(result);
//         }

//         });
//     });

//Test avec insertion de param
// conn.connect(function(err) {
//     if (err)
//         res.status(404).json({ ErrorConnection: 'Error bdd' });
//     console.log("Connected!");
//         conn.query("SELECT * from Authentification where User = '"+req.params.ID+"'", function (err, result) {
//         if (err)
//             res.status(400).json({ ErrorRequete: 'Requete invalid' });
//         else
//         {
//             res.status(200).json(result);
//             console.log(result);
//         }

//         });
//     });


// Test pour traitement valeur Moyenne
// conn.connect(function(err) {
//     if (err)
//         res.status(404).json({ ErrorConnection: 'Error bdd' });
//     console.log("Connected!");
//         conn.query("SELECT * from TestAdd", function (err, result) {
//         if (err)
//             res.status(400).json({ ErrorRequete: 'Requete invalid' });
//         else
//         {
//             var moyenne = 0;
//             result.forEach( (result) => {
//                 moyenne = moyenne + result.Valeur;
//                 console.log(moyenne)
//               });
//               moyenne = moyenne / result.length;
//               console.log(moyenne);
//             res.status(200).json({MoyenneCapteur : moyenne});
//         }

//         });
//     });





//res.status(200).json({ Msg: 'test' });
app.get("/Personne" , (req,res) =>
{
    //Voir la table 
    //Requete possible: Select nom , prenom , Formation_nom from Personne inner join Contenir

    //liste de tous les eleves des promos
    conn.connect(function(err) {
    if (err)
        res.status(404).json({ ErrorConnection: 'Error bdd' });
    console.log("Connected!");
        conn.query("SELECT * from Authentification", function (err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else
        {
            res.status(200).json(result);
            console.log(result);
        }
        });
    });
})


app.get("/Personne/Formation" , (req,res) =>
{
    //Requete possible: Select Formation_nom from Formation;

    //liste des promos


})

app.get("/Personne/Formation/:ID" , (req,res) =>
{
    //Requete possible: select P.nom , P.prenom from Promotion P inner join Contenir C C.id_formation=P.id_Formation 
    //inner join Personne P on P.id_Personne=C.id_Eleve 

    //liste des personnes pour une formation

})

app.get("/Personne/Departement/:ID" , (req,res) =>
{
    //Requete possible:

    //liste des personnes pour un departement
    //Voir avec pierre car bcp inner join peut etre pas bon
})

app.get("/Personne/Promotion/:ID" , (req,res) =>
{
    //Requete possible:

    //liste des personnes dans une promo
})

app.listen(port , () =>
{
    console.log("Serveur disponible port " + port);
})