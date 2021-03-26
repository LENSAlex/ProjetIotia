/* http://127.0.0.1:8080/webpage/ apres avoir demarrer in-cse avec le start.bat*/


var express = require("express");
var fs  = require('fs');
var cors = require('cors');
const fetch = require('node-fetch');
exp = express();
const swagger = require("swagger-tools");
var JefNode = require('json-easy-filter').JefNode;


//Module mysql
// var mysql = require('mysql');

// //Session
// var session = require('express-session')
// const timeSession = 1000 * 60 * 10 //10min de session

// //BDD--------------------
// // console.log('Get connection ...');
// // var conn = mysql.createConnection({
// //   database: 'test',
// //   host: "51.75.125.121",
// //   user: "alex",
// //   password: "Jessicalex2510*"
// // });
 
// // conn.connect(function(err) {
// //   if (err) throw err;
// //   console.log("Connected!");
// //   conn.query("SELECT * from Authentification where User='alex'", function (err, result) {
// //     if (err) throw err;
// //     console.log(result);
// //   });
// // });

// //Session---------------------
// exp.set('trust proxy', 1) // trust first proxy
// exp.use(session({
//   maxAge : timeSession, 
//   secret: 'keyboard cat',
//   resave: false,
//   saveUninitialized: true,
//   cookie: { secure: true }
// }))



// exp.use(cors());

// //Essaie variable de session , donc connection a cette variable via
// //une route specifique puis on peut acceder a des routes differentes



// //Requete d acceuil sur l api 
// exp.get("/" , (req, res,next) =>{
//     //Peut etre en html
//     res.end("Bonjour vous etes sur la page d acceuil de notre web service <br> Vous pouvez obtenir plus d info en tapant l url /docs");
//     console.log(new Date().toJSON());
// })

// exp.get("/testlolo" , (req, res,next) =>{
//   //Peut etre en html
//   res.end(new Date().toJSON());
//   //console.log(new Date().toJSON());
// })


// exp.listen(9999, () => {
//     console.log("Le programme a été lancé sur le port 9999");
//   })


  const https = require('https');
  // const fs = require('fs');
  
  const options = {
    key: fs.readFileSync('privateKey.key'),
    cert: fs.readFileSync('certificate.crt')
  };
  
  https.createServer(options, function (req, res) {
    res.writeHead(200);
    res.end("hello world\n");
  }).listen(8000)
