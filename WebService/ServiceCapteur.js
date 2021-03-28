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


//https://openclassrooms.com/fr/courses/5079046-mettez-en-place-une-architecture-pour-objets-connectes-avec-le-standard-onem2m/5263981-exercice-dentrainement-deployez-une-architecture-om2m-sur-votre-machine

/*
Resume: La majorité des routes vont chercher sur onem2m les dernieres valeurs des capteurs .
Certaine infos comme la moyenne , valeur min ou max demande un traitement spécifique ont ce servira donc de la bdd.

*/


/*
Requete vers onem2m:
http://127.0.0.1:8080/~/in-cse/in-name/MYSENSOR100 (la je cible un container MYSENSOR100)
Il faudra un cree pour chaque categorie
[{"key":"Accept","value":" application/xml","description":""},{"key":"X-M2M-Origin","value":"admin:admin","description":""}] header a mettre

//Ensuite il faut envoyes des info dans le container suivre le tuto d openclassroom
*/



app.listen(port , () =>
{
    console.log("Serveur disponible port " + port);
})