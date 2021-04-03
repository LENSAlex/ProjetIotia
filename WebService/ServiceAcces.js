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


app.get("/Acces/Batiment", (req, res) => {
    //Jauge de tous les batiments
    /*
    Requete possible
    select id_Batiment , Seuil_presence from AccesBatiment

    */
})


app.get("/Acces/Batiment/:id", (req, res) => {
    //Jauge d un batiment par id
    /*
    select Seuil_presence from AccesBatiment where id_Batiment = '"+req.params.id+"'
    */
})



app.get("/Acces/Batiment/:id/Etage ", (req, res) => {
    //Jauge des etages d un batiment
    /*
    select AE.id_Etage ,AE.Seuil_presence from Batiment B , Etage E, AccesEtage AE
    where 
    B.id_Batiment = E.id_Batiment
    and 
    E.id_Etage = AE.id_Etage
    and 
    B.id_Batiment = '"+req.params.id+"' 
    
    */
})


app.get("/Acces/Batiment/Salle/:id", (req, res) => {
    //Jauge d une salle
    /*
    select Seuil_presence from AccesSalle where id_Salle = '"+req.params.id+"' 
    
    */
})

app.get("/Acces/Batiment/id/Salle", (req, res) => {

    //On veut les jauges de toutes les salles d un bat
    /*
    select AE.id_Etage ,AS.Seuil_presence from Batiment B , Etage E, AccesEtage AE , Salle S , AccesSalle AS
    where 
    B.id_Batiment = E.id_Batiment
    and 
    E.id_Etage = AE.id_Etage
    and
    E.id_Etage = S.id_Etage
    and 
    S.id_Salle = AS.id_Salle
    and 
    B.id_Batiment = '"+req.params.id+"' 
    
    */
})


app.get("/Acces/Promo", (req, res) => {
    //(nb acces de toutes les promos)

})


app.get("/Acces/Promo/id", (req, res) => {

})

