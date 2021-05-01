var express = require("express");
var mysql = require('mysql');
const fs = require('fs');
var app = express();
const https = require('https')


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


// Certificate
const privateKey = fs.readFileSync('/etc/letsencrypt/live/webservice.lensalex.fr/privkey.pem', 'utf8');
const certificate = fs.readFileSync('/etc/letsencrypt/live/webservice.lensalex.fr/cert.pem', 'utf8');
const ca = fs.readFileSync('/etc/letsencrypt/live/webservice.lensalex.fr/chain.pem', 'utf8');

const credentials = {
	key: privateKey,
	cert: certificate,
	ca: ca
};


var server = https.createServer(credentials , function (req, res) {

    //Service https

    //Ici on met tous les post
    if(req.method == "POST")
    {
        // if(req.url == "/InfraAdmin/Usager/Add/Rapide/:Nom/:Prenom")
    }
    

    // if(req.url == "/Batiment/CountInfo/Campus") {
    //     conn.query("UPDATE `Personne` SET `num_ref` = '" + req.params.NumRef + "', `id_pers_type` = '" + req.params.IdPersType + "', `password` = '" + req.params.Password + "', `email` = '" + req.params.Email + "', `telephone` = '" + req.params.Tel + "', `sexe`= '" + req.params.Sexe + "', `nom` = '" + req.params.Nom + "', `prenom` = '" + req.params.Prenom + "', `date_anniversaire` = '" + req.params.Birth + "' where id_personne = '" + req.params.IdPersonne + "' ", function(err, result) {
    //         if (err)
    //             res.status(400).json({ ErrorRequete: 'Requete invalid' });
    //         else {
    //         }
    //     });
    
    //     //La je vais chercher la requete que je viens d envoyer pour avoir l id de l utilisateur cree
    //     //Que si eleve
    //     if ( req.params.IdPersType == 1) {
    //             //La je vais chercher la requete que je viens d envoyer pour avoir l id de l utilisateur cree
    //         conn.query("UPDATE `Contenir` set `id_promotion` = " + req.params.IdPromo + " where id_eleve= " + req.params.IdPersonne + "", function(err, result) {
    //             if (err)
    //             {
    //                 res.writeHead(400);
    //                 res.end("error")
    //             }
    //             else {
    //                 res.writeHead(200);
    //                 res.write(JSON.stringify("etudiant modifié"));
    //                 res.end();
    //             }
    //         });
    //     } else {
    //         res.writeHead(200);
    //     }
    // }
    // else if()


    // else if(req.url == "/Batiment/ListEquipement")
    // {
    //     conn.query("select id_equipement , libelle , description from Equipement", function(err, result) {
    //         if (err)
    //         {
    //             res.writeHead(400);
    //             res.end("error")
    //         }
    //         else {
    //             res.writeHead(200);
    //             res.write(JSON.stringify(result));
    //             res.end();
    //         }
    //     });
    // }
    else
    {
        res.writeHead(200);
        res.write(JSON.stringify("Service introuvable veuillez consulter la documentation"));
        res.end();
    }


})
  
server.listen(9999)