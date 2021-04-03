var express = require("express");
var mysql = require('mysql');
var app = express();

const port = 3001;

// BDD--------------------
console.log('Get connection ...');
var conn = mysql.createConnection({
  database: 'test',
  host: "51.75.125.121",
  user: "alex",
  password: "*"
});



app.get("/Alerte/Covid/Personne/id", (req, res) => {
    //alerte cas covid , alerté membre classe , etage , bat ....
    //Voir avec les autres ce qu il veule car un peu flou
})
