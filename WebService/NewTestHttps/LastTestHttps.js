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


// var credentials = { 
//     pfx: fs.readFileSync(__dirname + '/certif.pfx'),  //A voir pour autorisé le certif sur notre serveur
//     passphrase: 'jessicalex' //mettre mdp certif
// }

// const options = {
//     key: fs.readFileSync(__dirname + 'key.pem'),
//     cert: fs.readFileSync(__dirname + 'cert.pem')
//   };

var server = https.createServer(function (req, res) {
    // res.writeHead(200,{'Content-Type': 'text/plain'})
    // res.end('Hello World\n')


    if (req.url == "/Batiment/CountInfo/Campus") {
        conn.query("select a.nom , nbetage , nbsalle from (select Site.nom, count(id_salle) as nbsalle from Site, Batiment, Etage, Salle where Site.id_site = Batiment.id_site and Batiment.id_batiment = Etage.id_batiment and Etage.id_etage = Salle.id_etage group by Site.nom) a, (select Site.nom, count(Etage.id_etage) as nbetage from Site, Batiment, Etage where Site.id_site = Batiment.id_site and Batiment.id_batiment = Etage.id_batiment group by Site.nom) b where a.nom = b.nom", function(err, result) {
            if (err)
            {
                res.writeHead(400);
                res.end("error")
            }
            else {
                res.writeHead(200);
                res.end(result)
            }
        })
    }
    else if(req.url == "/Batiment/ListEquipement")
    {
        conn.query("select id_equipement , libelle , description from Equipement", function(err, result) {
            if (err)
            {
                res.writeHead(400);
                res.end("error")
            }
            else {
                res.writeHead(200);
                res.write(JSON.stringify(result));
                res.end();
            }
        });
    }
    else
    {
        res.writeHead(200);
        res.write(JSON.stringify("alex"));
        res.end();
    }

  })
  
  server.listen(4040)