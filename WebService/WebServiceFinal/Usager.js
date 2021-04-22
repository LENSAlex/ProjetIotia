var express = require("express");
var mysql = require('mysql');
const fs = require('fs');
var app = express();

//Swagger
var swaggerTools  = require('swagger-tools');
var swaggerDoc = require('./Usager.json')  

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

/*
    Service qui traite de l'affichage d'informations sur les usagers de l'iut
*/


//Documentation Swagger
swaggerTools.initializeMiddleware(swaggerDoc, function (middleware) {
    // Serve the Swagger documents and Swagger UI
    app.use(middleware.swaggerUi());
  });

//GET------------------------
//list personne(nom , prenom)
app.get("/Usager/:Prenom/:Nom", (req, res) => {

    //Affichage formation avec departement et duree
    conn.query("select nom , prenom , email from Personne where nom LIKE '%" + req.params.Nom + "%' AND prenom LIKE '%" + req.params.Prenom + "%'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
        }
    })
})

app.get("/Usager/ListPromo", (req, res) => {

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

app.get("/Usager/ListPersonne", (req, res) => {

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
app.get("/Usager/ListTypePersonne", (req, res) => {
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
app.get("/Usager/ListPromo/Simple", (req, res) => {
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
app.get("/Usager/ListSalleEleve/:Id", (req, res) => {
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
app.get("/Usager/GetIdEleve/:Nom/:Prenom/:Email", (req, res) => {
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
app.get("/Usager/GetIdEleve/:Ine", (req, res) => {
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

//LIST des professeur
app.get("/Usager/ListProf", (req, res) => {
    var id;
    conn.query("select distinct Promotion.id_professeur , Personne.nom , Personne.prenom from Promotion , Personne where Promotion.id_professeur = Personne.id_personne", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
        }
    });
})

app.listen(port, () => {
    console.log('Server listen on port 3001')
})