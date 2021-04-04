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


//Count cas covid
app.get("/Alerte/Covid/Count")
{
  /*
    select count(id_Personne) from CasCovid
  */
}

app.get("/Alerte/Covid/Count/:Date1/:Date2")
{
  /*
    select count(id_Personne) from CasCovid where Date_declaration BETWEEN '"+req.params.Date1+"' and '"+req.params.Date2+"'
  */
}

//Count cas covid batiment
app.get("/Alerte/Covid/Count/Departement/:IdDep")
{
  /*
    select count(CasCovid.id_Personne) from Departement , Formation , Promotion , Contenir , Personne , CasCovid 
    where 
    Departement.id_Departement = Formation.id_Departement 
    and 
    Formation.id_Formation = Promotion.id_Formation
    and
    Promotion.id_promotion = Contenir.id_promotion
    and
    Contenir.id_Eleve = Personne.id_Personne
    and
    Personne.id_Personne = CasCovid.id_Personne
    and
     Departement.id_Departement = '"+req.params.IdDep+"'
  */
}

//Count cas covid Promo
app.get("/Alerte/Covid/Count/Promo/:IdPromo")
{
  /*
    select count(CasCovid.id_Personne) from Promotion , Contenir , Personne , CasCovid 
    where 
    Promotion.id_promotion = Contenir.id_promotion
    and
    Contenir.id_Eleve = Personne.id_Personne
    and
    Personne.id_Personne = CasCovid.id_Personne
    and
     Promotion.id_promotion = '"+req.params.IdPromo+"'
  */
}

//Declare cas covid---------------------
app.post("/Alerte/Covid/Personne/:id/:Date", (req, res) => {
   /*
    insert into CasCovid (id_personne , Date_declaration) values('"+req.params.id+"' , '"+req.params.Date+"')
   */
})