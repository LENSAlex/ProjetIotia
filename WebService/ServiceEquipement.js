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


app.get("/Equipement/Alerte", (req, res) => {
  //Renvoie de tous les stocks verifier si penurie
  //Requete possible
  /*
  select E.libelle , P.Is_penurie from Equipement E , Penurie P
  where
  E.id_equipement = P.id_equipement
  */

  //Ou alors requete si penurie renvoie sinon on renvoie autre chose si requete null
  /*
  select E.libelle , P.Is_penurie from Equipement E , Penurie P
  where
  E.id_equipement = P.id_equipement
  and P.Is_penurie = true
  */
})