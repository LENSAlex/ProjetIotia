/* http://127.0.0.1:8080/webpage/ apres avoir demarrer in-cse avec le start.bat*/


var express = require("express");
var fs  = require('fs');
var cors = require('cors');
const fetch = require('node-fetch');
exp = express();
const swagger = require("swagger-tools");
var JefNode = require('json-easy-filter').JefNode;
var passport = require('passport');
exp.use(passport.initialize());
exp.use(passport.session());
exp.use(cors());

//Initialisation du mot de passe avec passport
// passport.use(new LocalStrategy(
//     function(alex, jess, done) {
//       // Find the user from your DB (MongoDB, CouchDB, other...)
//       User.findOne({ username: username, password: password }, function (err, user) {
//         done(err, user);
//       });
//     }
//   ));


  exp.get('/login', 
  passport.authenticate('local'),
  function(req, res) {
    // If this function gets called, authentication was successful.
    // `req.user` contains the authenticated user.
    res.redirect('/users/' + req.user.username);
  });

//Requete d acceuil sur l api 
exp.get("/" , (req, res,next) =>{
    //Peut etre en html
    res.end("Bonjour vous etes sur la page d acceuil de notre web service <br> Vous pouvez obtenir plus d info en tapant l url /docs");
    console.log(new Date().toJSON());
})



//Debut de la visualisation des capteurs


exp.get("/Last/Batiment/:idBat/Salle/:idSalle/" , (req, res) =>{
    // res.write(JSON.stringify(data));

    var obj1 = JSON.parse(fs.readFileSync("new.json" , "utf8"));
    var test = obj1.ValeurCapteur
    var obj = {
		test
    };
//console.log(obj);
var numbers = new JefNode(obj).filter(function(node) {
    //https://github.com/gliviu/json-easy-filter
        if(node.value.Batiment ==  1 && node.value.Salle == 3)
        {

            return node.value.Nom + ' ' + node.value.Valeur;
        }
	});
// req.params.idBat req.params.idSalle
console.log(numbers);
res.send(numbers);
});
//apres voir des tries plus specifique mais comme ca ca marche





exp.put("/Batiment/:idBat/Salle/:idSalle/:Obj/:Value" , (req, res) =>{
    //Verification de ce qu on a
    console.log("vous etes bien au batiment "+ req.params.idBat +" et à la salle "+req.params.idSalle+" obj:"+req.params.Obj);
    //traitement dernieres valeurs

    var FileNew = JSON.parse(fs.readFileSync("new.json" , "utf8"));
    //Parcour du json pour changer valeur de ce que l on veut
    var taille = FileNew.ValeurCapteur.length;
    let compteur=-1;
    //console.log(taille);
    for(var i=0 ; i < taille ; i++)
    {
        console.log(FileNew.ValeurCapteur[i].Nom);
        if(FileNew.ValeurCapteur[i].Nom == req.params.Obj)
        {
            compteur = i;
        }
    }
    console.log(compteur);

    if(compteur != -1)
    {
        FileNew.ValeurCapteur[compteur].Valeur = req.params.Value
        FileNew.ValeurCapteur[compteur].Date = new Date().toJSON();
        FileNew.ValeurCapteur[compteur].Batiment = req.params.idBat;
        FileNew.ValeurCapteur[compteur].Salle = req.params.idSalle;
        fs.writeFileSync('new.json', JSON.stringify(FileNew) , function (err) {
            if (err) return console.log(err);
            console.log('data envoyé avec succés');
            });

        //Envoie sur onem2m


        //traitement all values
        var FileAll = JSON.parse(fs.readFileSync("all.json" , "utf8"));
        var NewValueCapteur = {
            "Nom":req.params.Obj,
            "Valeur":req.params.Value,
            "Date":new Date().toJSON(),
            "Batiment":req.params.idBat,
            "Salle":req.params.idSalle
        };
        FileAll.ValeurCapteur.push(NewValueCapteur);
        fs.writeFileSync('all.json', JSON.stringify(FileAll) , function (err) {
            if (err) return console.log(err);
            console.log('data envoyé avec succés');
            });
    }
    else
    {
        res.status(404).json({
            message: 'Ressource introuvable !'
        });
    }
});





exp.listen(9999, () => {
    console.log("Le programme a été lancé sur le port 9999");
  })


//----------------------------Brouillon ----------------------------------------
//Debut de la visualisation des capteurs 
// exp.get("/Batiment/:idBat/Salle/:idSalle/:Obj" , (req, res) =>{
//     //Verification de ce qu on a
//     console.log("vous etes bien au batiment "+ req.params.idBat +" et à la salle "+req.params.idSalle+" obj:"+req.params.Obj);
//     //traitement dernieres valeurs

//     var FileNew = JSON.parse(fs.readFileSync("new.json" , "utf8"));
//     //Parcour du json pour changer valeur de ce que l on veut
//     let ValeurCapteur = FileNew.ValeurCapteur.filter((elem)=>
//     {
//         //console.log(elem);
//         if(elem.Nom == req.params.Obj)
//         {
//             console.log(elem.Valeur);
//         }
//     })

//     //traitement all values

// })