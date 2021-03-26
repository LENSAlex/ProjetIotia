/* http://127.0.0.1:8080/webpage/ apres avoir demarrer in-cse avec le start.bat*/


var express = require("express");
var fs  = require('fs');
var cors = require('cors');
const fetch = require('node-fetch');
exp = express();
const swagger = require("swagger-tools");
var JefNode = require('json-easy-filter').JefNode;
var passport = require('passport')
  , LocalStrategy = require('passport-local').Strategy;
exp.use(passport.initialize());
exp.use(passport.session());


exp.use(cors());

//Essaie variable de session , donc connection a cette variable via
//une route specifique puis on peut acceder a des routes differentes



//Requete d acceuil sur l api 
exp.get("/" , (req, res,next) =>{
    //Peut etre en html
    res.end("Bonjour vous etes sur la page d acceuil de notre web service <br> Vous pouvez obtenir plus d info en tapant l url /docs");
    console.log(new Date().toJSON());
})


exp.listen(9999, () => {
    console.log("Le programme a été lancé sur le port 9999");
  })


