const express = require('express')
const app = express()
const port = 3000
const jwt = require('jsonwebtoken');
const fs = require('fs');

//https://etienner.github.io/api-json-web-token-authentication-jwt-sur-express-js/


var TokenSession;


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



app.get('/', (req, res) => {
    console.log(req)
    res.send('Hello World!')
})

//route pour se login plus tard , authorisé le token ou pas
app.get('/jwt', (req, res) => {
    //Je procede au token si l utilsiateur avec mdp est bon A FAIRE
    let privateKey = fs.readFileSync('./private.pem', 'utf8');
    let token = jwt.sign({ "ID": "iotia" }, privateKey , { expiresIn: '1 hours' });
    res.send(token);
    TokenSession = token;
})

// let's first add a /secret api endpoint that we will be protecting
app.get('/secret', checkTokenMiddleware , (req, res) => {
    // Récupération du token
    const token = req.headers.authorization && extractBearerToken(req.headers.authorization)

    // Décodage du token
    // const decoded = jwt.decode(token, { complete: false })
    // return res.json({ content: decoded })
})

app.get('/GetTokenSession' , (req,res) =>
{

    //Ici je retransmet le dernier token creer
})

// and a /readme endpoint which will be open for the world to see 
app.get('/readme', (req, res) => {
    console.log(req.headers.authorization)
    res.json({ "message" : "This is open to the world!" })
})



app.listen(port, 
    () => console.log(`Simple Express app listening on port ${port}!`))



//README
/*
Du coup juste besoin de d'abord generer son token avec la route login ou on enverra nom , prenom et mdp par exemple
Si cela est bon ca generer le token
Et a chaque fois que l on rentre dans une route confidentielle on utilisera la fonction checkTokenMiddleware qui appelle aussi extractBearerToken a expliqué leur role
Mais en gros il verifie le token qui est passe pour voir si il correspond a celui generer avec la bonne cle

Il faut que dorian recup le token generer pour 1h et l utilise pour chaque route confidentielle , a voir comment garder en memoire un token differnet a chaque fois
Puis inserer ca dans chaque requete pour routes confidentielle
Authorization : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJRCI6ImlvdGlhIiwiaWF0IjoxNjE4NTk3MjI2LCJleHAiOjE2MTg2MDA4MjZ9.8-PV7QJtWAbK2wWKSGnPhAi6CxKW_z3jfzXvpDkjcoE

Voir Variable de session .net core ou l on stockera le token
*/