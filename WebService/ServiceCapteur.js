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

//Mais GETTeur pour recup ID 
app.get("Capteur/GetIdSalle/Batiment/:IDBat/Etage/:IDEtage/Salle/:IDSalle", (req, res) => {
  // A voir peut etre donne , batiment etage 
  //Requete possible:
  /*
    select B.id_Salle from Batiment B , Etage E , Salle S , box B
    where 
    B.id_Batiment = E.id_Batiment
    and 
    E.id_Etage = S.id_Etage
    and 
    S.id_Salle = B.id_Salle
    and 
    B.id_batiment = '"+req.params.IDBat+"' and E.id_Etage = '"+req.params.IDEtage+"' and S.id_Salle = '"+req.params.IDSalle+"'

  */
})

//Voir pour get capteur , 
//SELECT * FROM historique WHERE id_valutetype IN (SELECT id_valuetype FROM valueType WHERE unité LIKE 'degré'); 

//Get recption valeur capteur par bdd vu avec MAP.
app.get("/Capteur/Salle/:idSalle/All", (req, res) => {
  //List de tous les releves dans une salle pour chq capteur / en supposant une salle a une box plus sur
  // A voir quoi correspond la valeur je ne vois pas
  /*
    SELECT * FROM historique;
  */
 //Puis traitement ici
})

app.get("/Capteur/Salle/:idSalle/Last", (req, res) => {
  //List des derniers releve dans une salle pour chq capteur 
  //pareil que en haut
  /*
  SELECT distinct * FROM historique order by DESC; //Avoir les derneires valeur une fois
  */

})

app.get("Capteur/Salle/:idSalle/:Obj/List/Date1/Date2", (req, res) => {
  //List capteur entre 2 dates Partir de Device
})


app.get("Capteur/Salle/:idSalle/:Obj", (req, res) => {
//Releve d un capteur specifique
})


app.get("Capteur/Salle/:idSalle/:Obj/List", (req, res) => {
//List d un capteur specifique
})



//Get avec traitement ----------------------------------------------


app.get("Capteur/Salle/:idSalle/MoyenneCo2", (req, res) => {
  //Co2Moyen journee facile juste recup id co2 et faire traitement peut etre avec historique
})


app.get("Capteur/Salle/:idSalle/Co2/:Attribut", (req, res) => {
  //co2 min ou max journee Pareil que en haut sauf trouver min et max en focntion attributs
  if(req.params.Attribut == "min")
  {

  }
  else if(req.params.Attribut == "max")
  {

  }
  else
  {
    res.status(404).json({ StatutRequete: 'Mauvais attribut voir la doc' });
  }
})

app.get("Capteur/Salle/:idSalle/Temp", (req, res) => {
  //tempMoyenne journee voir historique avec id capteur
})

app.get("Capteur/Salle/:idSalle/Temp/:Attribut", (req, res) => {
  //temp min ou max  journee
  if(req.params.Attribut == "min")
  {

  }
  else if(req.params.Attribut == "max")
  {

  }
  else
  {
    res.status(404).json({ StatutRequete: 'Mauvais attribut voir la doc' });
  }
})

app.get("Capteur/Salle/:idSalle/OuvertureFenetre", (req, res) => {
  //ouverture fenetre journee nb ou dernieres valeur releve a voir
})

app.get("Capteur/Salle/:idSalle/Co2/:Attribut", (req, res) => {
  //nombre entre salle journee
  //Faire une route qui incremente le compteur sur bdd post
})

app.get("Capteur/Salle/:idSalle/NbEntree", (req, res) => {
  //nombre entre salle journee
})

app.get("Capteur/Salle/:idSalle/NbEntree/Date1/Date2", (req, res) => {
  //nombre entre salle entre deux dates
})

app.get("Capteur/Salle/:idSalle/NbSortie", (req, res) => {
  //nombre sortie salle journee
})

app.get("Capteur/Salle/:idSalle/NbSortie/Date1/Date2", (req, res) => {
  //nombre sortie salle entre deux dates
})

//Fin GET -------------------------------------------------

//ID post ou put
app.put("Capteur/ChgtValeur/:IDCapteur")
{
  //Changé valeur d un capteur requete onem2m ou via python pas clair
}

app.put("Capteur/CapteurEntree/:Attribut")
{
  //Sortie ou entree qui incremente un compteur pour la journee ou rajoute une ligne je trie apres
}

//Put ou post Ajout valeur capteur sur onem2m et bdd.

app.listen(port , () =>
{
    console.log("Serveur disponible port " + port);
})