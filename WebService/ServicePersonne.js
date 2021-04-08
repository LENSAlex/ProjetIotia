var express = require("express");
var mysql = require('mysql');
var app = express();

const port = 3000;

// BDD--------------------
console.log('Get connection ...');
var conn = mysql.createConnection({
    database: 'ProjetIotia', //Voir database
    host: "51.75.125.121", //134.59.143.55:8081
    user: "iotia", //ioita
    password: "iotia" //Sm@rt$2021
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
app.get("/Personne", (req, res) => {
    //Voir la table 
    //Requete possible: Select nom , prenom , Formation_nom from Personne inner join Contenir

    //liste de tous les eleves des promos
    conn.connect(function(err) {
        if (err)
            res.status(404).json({ ErrorConnection: 'Error bdd' });
        console.log("Connected!");
        conn.query("SELECT * from Authentification", function(err, result) {
            if (err)
                res.status(400).json({ ErrorRequete: 'Requete invalid' });
            else {
                res.status(200).json(result);
                console.log(result);
            }
        });
    });
})


app.get("/Personne/Formation", (req, res) => {
    //Requete possible: Select Formation_nom from Formation;
    /*select * from 
	Departement, Formation, Promotion, Contenir, Personne
    where 
    Departement.id_departement = Formation.id_departement
    and Formation.id_formation = Promotion.id_formation
    and Promotion.id_promotion = Contenir.id_promotion
    and Contenir.id_eleve = Personne.id_personne */
    //liste des promos

})


app.get("/Personne/Departement/:ID", (req, res) => {
    //Requete possible:

    //liste des personnes pour un departement
    //Voir avec pierre car bcp inner join peut etre pas bon
})

app.get("/Personne/Promotion/:ID", (req, res) => {
    //Requete possible:select P.nom , P.prenom from Promotion P inner join Contenir C C.id_formation=P.id_Formation 
    //inner join Personne P on P.id_Personne=C.id_Eleve 

    //liste des personnes dans une promo
})

app.get("/Personne/Promotion/:IDPromo/personne/cours", (req, res) => {
    //Requete possible:select heure_debut , heure_fin ,Commentaire from Cours where id_promotion = '"+req.params.IDPromo+"'

    //Liste des cours d un eleve
})

app.get("/Personne/Promotion/:IDPromo/personne/cours/presentielle", (req, res) => {
    //Requete possible:select heure_debut , heure_fin ,Commentaire from Cours where id_promotion = '"+req.params.IDPromo+"' and presentiel = true

    //Liste des cours en presentielle d un eleve
})


app.get("/Personne/Promotion/:IDPromo/personne/cours/distancielle", (req, res) => {
    //Requete possible:select heure_debut , heure_fin ,Commentaire from Cours where id_promotion = '"+req.params.IDPromo+"' and presentiel = false

    //Liste des cours en distancielle d un eleve
})


app.get("/Personne/:IDPersonne/abs", (req, res) => {
    //Requete possible:select C.Commentaire , A.motif from Cours C inner join Absence A on A.id_cours = C.id_cours where A.id_PersonneEtudiant = '"+req.params.IDPersonne+"'

    //Absecence d un eleve
})



//Route annexes qui doivent etre utiliser avant de passer des parametre route (idUser , IdPromo , ...)
//Id personne voir https
app.get("/Personne/GetIDPerson/:login/:mdp", (req, res) => {
    //
})

//IDPromo a savoir car je n ai pas de nom pour identifier

//POST / PUT --------------------------------------
//HTTPS
app.post("/Personne/Add/:IdPersType/:Num_ref/:password/:mail/:Tel/:Nom/:Prenom/:Sexe/:anniv/:RFID") {
    //Requete possible faire un insert avec toutes ces valeurs
}

app.listen(port, () => {
    console.log("Serveur disponible port " + port);
})