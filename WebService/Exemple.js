var express = require("express");
var mysql = require('mysql');
const fs = require('fs');
var app = express();

//Swagger
var swaggerTools  = require('swagger-tools');
var swaggerDoc = require('./InfraAdmin.json');  

//JWT
const jwt = require('jsonwebtoken');

//PORT
const port = 3004;



//Traitement Requetes



//Ecoute du port
app.listen(port, () => {
    console.log('Server listen on port 3004')
})




// BDD initialisation
console.log('Get connection ...');
var conn = mysql.createConnection({
    database: 'ProjetIotia',
    host: "51.75.125.121",
    user: "iotia",
    password: "iotia"
});

//Connexion BDD
conn.connect(function(err) {
    if (err)
        res.status(404).json({ ErrorConnection: 'Error bdd' });
    console.log("Connected!");
})


//Documentation Swagger
swaggerTools.initializeMiddleware(swaggerDoc, function (middleware) {
    // Serve the Swagger documents and Swagger UI
    app.use(middleware.swaggerUi());
  });
  
  
  
  
  
 //Token -------------------
//Fonction du token
/* Récupération du header bearer */
const extractBearerToken = headerValue => {
    if (typeof headerValue !== 'string') {
        return false
    }

    const matches = headerValue.match(/(bearer)\s+(\S+)/i)
    return matches && matches[2]
}


/* Vérification du token , qui doit etre envoyés*/
const checkTokenMiddleware = (req, res, next) => {
    // Récupération du token
    const token = req.headers.authorization && extractBearerToken(req.headers.authorization)

    // Présence d'un token
    if (!token) {
        return res.status(401).json({ message: 'Error. Need a token' })
    }

    // Véracité du token
    let privateKey = fs.readFileSync('./private.pem', 'utf8');
    jwt.verify(token, privateKey, (err, decodedToken) => {
        if (err) {
            res.status(401).json({ message: 'Error. Bad token' })
        } else {
            return next()
        }
    })
}



//Example Utilisation du token
//Modif Capteur
app.put("/InfraAdmin/Capteur/Modifs/Capteur/:Nom/:IdBox/:TypeActionneur/:IdCapteur",checkTokenMiddleware, (req, res) => {
    conn.query("UPDATE `Device` SET `id_box`='" + req.params.Box + "',`id_devicetype`='" + req.params.TypeActionneur + "',`libelle`='" + req.params.Nom + "' WHERE id_device = '" + req.params.IdCapteur + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json("Capteur modifié");
        }
    })
})