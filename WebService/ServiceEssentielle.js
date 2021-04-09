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

/*
select B.id_box ,B.libelle , B.adr_ip , B.description ,Ba.nom , S.id_etage , S.nom  as NomSalle from Box B , Salle S , Etage E , Batiment Ba where B.id_salle = S.id_salle and S.id_etage = E.id_etage AND E.id_batiment = Ba.id_batiment;
*/


//------------------------------GET ----------------------------

app.get("/Personne/CasCovid", (req, res) => {
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

app.get("/Batiment/CountInfo/Campus", (req, res) => {
    //Affciahe nb etage et nb salle par campus
    conn.query("select * from (select a.id_salle , a.id_box ,a.libelle , a.adr_ip , a.description ,a.nom , a.id_etage , a.nom as NomSalle , PanneauSolaire from (select B.id_salle , B.id_box ,B.libelle , B.adr_ip , B.description ,Ba.nom , S.id_etage , S.nom as NomSalle from Box B , Salle S , Etage E , Batiment Ba where B.id_salle = S.id_salle and S.id_etage = E.id_etage AND E.id_batiment = Ba.id_batiment) a LEFT JOIN (select S.id_salle , count(*) as PanneauSolaire from DeviceType DT , Device D , Box B , Salle S where DT.id_devicetype = D.id_device AND D.id_box = B.id_box AND B.id_salle = S.id_salle AND DT.id_devicetype = 17 group by S.id_salle) b on a.id_salle = b.id_salle) c LEFT JOIN (select S.id_salle , count(*) as NbBouton from Device D , Box B , Salle S where D.id_box = B.id_box AND B.id_salle = S.id_salle AND D.id_devicetype = 11 group by S.id_salle) d on c.id_salle = d.id_salle", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    })
})

app.get("/Personne/ListPromo", (req, res) => {

    //Affichage formation avec departement et duree
    conn.query("select F.nom , P.annee ,F.duree from Promotion P , Formation F , Departement D where P.id_formation = F.id_formation and D.id_departement = F.id_departement", function(err, result) {
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

//Liste des devices sans arduino et rasp pour dorian
app.get("/Personne/ListDevice", (req, res) => {

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
app.get("/Personne/ListCapteur", (req, res) => {

    conn.query("select D.id_device ,DT.libelle_type , B.libelle from DeviceType DT , Device D , Box B where DT.id_devicetype = D.id_devicetype and D.id_box = B.id_box", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Info de chaque Box Ip , Etage , batiment ...
app.get("/Personne/Box/Info", (req, res) => {

    //List device sans rpi et arduino 
    conn.query("select B.id_box ,B.libelle , B.adr_ip , B.description ,Ba.nom , S.id_etage , S.nom as NomSalle from Box B , Salle S , Etage E , Batiment Ba where B.id_salle = S.id_salle and S.id_etage = E.id_etage AND E.id_batiment = Ba.id_batiment", function(err, result) {
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
app.get("/Capteur/Search/:IdSalle", (req, res) => {
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
app.get("/Covid/Count/:IdSalle/:IdBatiment/", (req, res) => {
    //Echelle Salle

    // select F.nom from CasCovid CC , Personne P , Contenir C , Formation F where CC.id_personne = P.id_personne and P.id_personne = C.id_eleve and C.id_formation = F.id_formation

    if (req.params.IdBatiment == 0) {
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
    else {
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
    conn.query("select id_batiment ,id_site , nom from Batiment", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List Promo
app.get("/Personne/ListPromo", (req, res) => {
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
app.get("/Personne/ListSalleEleve", (req, res) => {
    conn.query("select P.id_personne,S.id_salle from Personne P , Contenir C , Promotion Po , Cours Cou , Salle S where P.id_personne = C.id_eleve AND C.id_promotion = Po.id_promotion AND Po.id_promotion = Cou.id_promotion AND Cou.id_salle = S.id_salle", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//All Capteur d une salle
app.get("/Personne/ListSalleEleve/:Salle", (req, res) => {
    conn.query("select D.id_device , VT.libelle from ValueType VT , Device D , Box B , Salle S where D.id_valuetype = VT.id_valuetype AND D.id_box = B.id_box and B.id_salle = S.id_salle and S.nom = '" + req.params.Salle + "'", function(err, result) {
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


//-----------------------------------POST--------------------------------

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

//Envoie nouveau covid vers CasCovid
app.post("/Alerte/Covid/:IdPersonne", (req, res) => {

    conn.query("INSERT INTO `CasCovid`(`id_personne`, `date_declaration`) VALUES ('" + req.params.IdPersonne + "',NOW())", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json("Cas covid cree");
        }
    });
})

app.listen(port, () => {
    // console.log(`Example app listening at http://localhost:${port}`)
    console.log('Server listen on port 3001')
})