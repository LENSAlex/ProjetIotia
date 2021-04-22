var express = require("express");
var mysql = require('mysql');
const fs = require('fs');
var app = express();

//Swagger
var swaggerTools  = require('swagger-tools');
var swaggerDoc = require('./InfraAdmin.json')  

const port = 3004;

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
    Service qui traite des modfications des valeurs des actionneurs , capteurs , ajout de valeur , usagers ...
*/

//Documentation Swagger
swaggerTools.initializeMiddleware(swaggerDoc, function (middleware) {
    // Serve the Swagger documents and Swagger UI
    app.use(middleware.swaggerUi());
  });

//PUT--------------------------------------------------
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



//POST-----------------------------------------------
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


app.listen(port, () => {
    console.log('Server listen on port 3004')
})