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

app.get("/Usager/Load/User/:id", (req, res) => {
    console.log("test");
    //Affichage formation avec departement et duree
    console.log(req.params.id);
    conn.query("select * from Personne where id_personne = '" + req.params.id + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    })
})

app.get("/Usager/ListPromo", (req, res) => {

    //Affichage formation avec departement et duree
    conn.query("select P.id_professeur ,Pers.nom as nomProf ,Pers.prenom, P.id_promotion , F.nom , P.annee ,F.duree from Promotion P , Formation F , Departement D , Personne Pers where P.id_formation = F.id_formation and D.id_departement = F.id_departement and P.id_professeur = Pers.id_personne", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    })
})

app.get("/Usager/ListPromo/:id", (req, res) => {

    //Affichage formation avec departement et duree
    conn.query("select P.id_professeur ,Pers.nom ,Pers.prenom, P.id_promotion , F.nom as NomPromo , P.annee ,F.duree , D.name as NomDepartement , D.id_departement from Promotion P , Formation F , Departement D , Personne Pers where P.id_formation = F.id_formation and D.id_departement = F.id_departement and P.id_professeur = Pers.id_personne and F.id_formation = '" + req.params.id + "'", function(err, result) {
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

//AFAIRE
app.get("/Usager/ListPersonne/:Id", (req, res) => {

    //Prof faisable aussi voir demain

    //Affichage formation avec departement et duree
    conn.query("select * from Personne where Personne.id_personne = '" + req.params.Id + "'", function(err, result) {
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

//Taux occupation BATIMENT
app.get("/Usager/List/TauxOccupation/Batiment", (req, res) => {
    conn.query("SELECT b.id_batiment, b.nom, ROUND(IFNULL((COUNT(DISTINCT p.id_personne) / SUM(s.capacite_max)) * 100, 0), 2) AS taux_occupation, SUM(IFNULL(s.capacite_max, 0)) AS capacite_max_batiment,  TIMESTAMPDIFF(MONTH, CONCAT(YEAR(CURRENT_DATE), '-01-01'),  CURRENT_DATE) AS nbMois,  TIMESTAMPDIFF(DAY, CONCAT(YEAR(CURRENT_DATE), '-01-01'),  CURRENT_DATE) AS nbJours FROM Batiment AS b  LEFT JOIN Salle AS s ON s.id_etage IN (SELECT id_etage FROM Etage AS e WHERE e.id_batiment = b.id_batiment) LEFT JOIN Cours AS c ON c.id_salle = s.id_salle LEFT JOIN Presentiel AS p ON p.id_cours = c.id_cours AND p.presence = 1 WHERE c.heure_debut IS NULL OR (DATE_FORMAT(c.heure_debut, '%Y') = YEAR(CURRENT_DATE)) GROUP BY b.id_batiment, b.nom", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Taux occupation Site
app.get("/Usager/List/TauxOccupation/Site", (req, res) => {
    conn.query("SELECT si.id_site, si.nom,    ROUND(IFNULL((COUNT(DISTINCT p.id_personne) / SUM(s.capacite_max)) * 100, 0), 2) AS taux_occupation,    SUM(IFNULL(s.capacite_max, 0)) AS capacite_max_site,  TIMESTAMPDIFF(MONTH, CONCAT(YEAR(CURRENT_DATE), '-01-01'),  CURRENT_DATE) AS nbMois, TIMESTAMPDIFF(DAY, CONCAT(YEAR(CURRENT_DATE), '-01-01'),  CURRENT_DATE) AS nbJours FROM Site AS si LEFT JOIN Batiment AS b ON b.id_site = si.id_site LEFT JOIN Salle AS s ON s.id_etage IN (SELECT id_etage FROM Etage AS e WHERE e.id_batiment = b.id_batiment) LEFT JOIN Cours AS c ON c.id_salle = s.id_salle LEFT JOIN Presentiel AS p ON p.id_cours = c.id_cours AND p.presence = 1 WHERE c.heure_debut IS NULL OR (DATE_FORMAT(c.heure_debut, '%Y') = YEAR(CURRENT_DATE)) GROUP BY si.id_site, si.nom", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

app.listen(port, () => {
    console.log('Server listen on port 3001')
})