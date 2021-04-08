var express = require("express");
var mysql = require('mysql');
var app = express();

const port = 3001;

// BDD--------------------
console.log('Get connection ...');
var conn = mysql.createConnection({
    database: 'ProjetIotia',
    host: "51.75.125.121",
    user: "iotia",
    password: "iotia"
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
app.get("/Capteur/GetIdSalle/Batiment/:IDBat/Etage/:IDEtage/Salle/:IDSalle", (req, res) => {
        // A voir peut etre donne , batiment etage 

        conn.connect(function(err) {
            if (err)
                res.status(404).json({ ErrorConnection: 'Error bdd' });
            console.log("Connected!");
            conn.query("select Bo.id_Salle from Batiment B , Etage E , Salle S , Box Bo where B.id_Batiment = E.id_Batiment and E.id_Etage = S.id_Etage and S.id_Salle = Bo.id_Salle and B.id_batiment = '" + req.params.IDBat + "' and E.id_Etage = '" + req.params.IDEtage + "' and S.id_Salle = '" + req.params.IDSalle + "'",
                function(err, result) {
                    if (err)
                        res.status(400).json({ ErrorRequete: 'Requete invalid' });
                    else {
                        res.status(200).json(result);
                        console.log(result);
                    }
                });
        });
    })
    //Voir pour get capteur , 
    //SELECT * FROM historique WHERE id_valutetype IN (SELECT id_valuetype FROM valueType WHERE unité LIKE 'degré'); 

//Get recption valeur capteur par bdd vu avec MAP.
//Pas bon car on veut une salle d un batiment et un etage precis
app.get("/Capteur/Salle/:idSalle/All", (req, res) => {
    //List de tous les releves dans une salle pour chq capteur / en supposant une salle a une box plus sur

    conn.connect(function(err) {
        if (err)
            res.status(404).json({ ErrorConnection: 'Error bdd' });
        console.log("Connected!");
        // conn.query("SELECT * FROM Historique , Box where Box.id_Salle = Historique.id_box and Box.id_Salle = '" + req.params.idSalle + "'",
        conn.query("SELECT * FROM Historique", function(err, result) {
            if (err)
                res.status(400).json({ ErrorRequete: 'Requete invalid' });
            else {
                res.status(200).json(result);
                console.log(result);
            }
        });
    });

    /*
      SELECT * FROM historique , box where box.id_Salle = Historique.id_box and box.id_Salle = '"+req.params.idSalle+"';
    */
    //Puis traitement ici
})

app.get("/Capteur/Salle/:idSalle/Last", (req, res) => {
    //List des derniers releve dans une salle pour chq capteur 

    conn.connect(function(err) {
        if (err)
            res.status(404).json({ ErrorConnection: 'Error bdd' });
        console.log("Connected!");
        // conn.query("SELECT * FROM Historique , Box where Box.id_Salle = Historique.id_box and Box.id_Salle = '" + req.params.idSalle + "'",
        conn.query("SELECT distinct * FROM Historique , Box where Box.id_Salle = Historique.id_box and Box.id_Salle = '" + req.params.idSalle + "' order by Historique.id_box DESC", function(err, result) {
            if (err)
                res.status(400).json({ ErrorRequete: 'Requete invalid' });
            else {
                res.status(200).json(result);
                console.log(result);
            }
        });
    });

    // SELECT distinct * FROM historique, box where box.id_Salle = Historique.id_box and box.id_Salle = '"+req.params.idSalle+"'
    // order by Historique.id_box DESC;
})

app.get("Capteur/Salle/:idSalle/:Obj/List/:Date1/:Date2", (req, res) => {
    //List capteur entre 2 dates Partir de Device
    /*
    SELECT * FROM historique , box where box.id_Salle = Historique.id_box and box.id_Salle = '"+req.params.idSalle+"' and Date BETWEEN '"+req.params.Date1+"' and '"+req.params.Date2+"'
    */
})


app.get("/Capteur/Salle/:idSalle/:Obj", (req, res) => {
    //Releve d un capteur specifique a voir avec le valuType peut etre partir du order desc et en prendre une valeur

    conn.connect(function(err) {
        if (err)
            res.status(404).json({ ErrorConnection: 'Error bdd' });
        console.log("Connected!");
        conn.query("select distinct Valeur from Historique , Box , DeviceType where Box.id_devicetype = DeviceType.id_devicetype and Box.id_box = Historique.id_box and Historique.id_box = '" + req.params.idSalle + "' and Historique.id_valuetype = '" + req.params.Obj + "'", function(err, result) {
            if (err)
                res.status(400).json({ ErrorRequete: 'Requete invalid' });
            else {
                res.status(200).json(result);
                console.log(result);
            }
        });
    });

    //select distinct Valeur from Historique , Box , DeviceType where Box.id_devicetype = DeviceType.id_devicetype and Box.id_box = Historique.id_box and Historique.id_box = 1 and Historique.id_valuetype = 11

})


app.get("Capteur/Salle/:idSalle/:Obj/List", (req, res) => {
    //List d un capteur specifique , Pareil que en haut mais tout

    conn.connect(function(err) {
        if (err)
            res.status(404).json({ ErrorConnection: 'Error bdd' });
        console.log("Connected!");
        conn.query("select Valeur from Historique , Box , DeviceType where Box.id_devicetype = DeviceType.id_devicetype and Box.id_box = Historique.id_box and Historique.id_box = '" + req.params.idSalle + "' and Historique.id_valuetype = '" + req.params.Obj + "'", function(err, result) {
            if (err)
                res.status(400).json({ ErrorRequete: 'Requete invalid' });
            else {
                res.status(200).json(result);
                console.log(result);
            }
        });
    });
})



//Get avec traitement ----------------------------------------------


app.get("Capteur/Salle/:idSalle/MoyenneCo2", (req, res) => {
    //Co2Moyen journee facile juste recup id co2 et faire traitement peut etre avec historique
    //Voir juste id capteur CO2

    /* select Valeur from Historique 
    where 
    id_TypeValue = (select id_DeviceType from Device where id_Device = 'IdCapteurCo2') 
    and 
    id_box = (select id_box from box where id_Salle = '"+req.params.idSalle+"') */

    //Apres reception donnes
    //var moyenne = 0;
    //             result.forEach( (result) => {
    //                 moyenne = moyenne + result.Valeur;
    //                 console.log(moyenne)
    //               });
    //               moyenne = moyenne / result.length;
    //               console.log(moyenne);
    //             res.status(200).json({MoyenneCapteurCo2 : moyenne});

})


app.get("Capteur/Salle/:idSalle/Co2/:Attribut", (req, res) => {
    //co2 min ou max journee Pareil que en haut sauf trouver min et max en focntion attributs
    if (req.params.Attribut == "min") {
        /* select MIN(Valeur) from Historique 
        where 
        id_TypeValue = (select id_DeviceType from Device where id_Device = 'IdCapteurCo2') 
        and 
        id_box = (select id_box from box where id_Salle = '"+req.params.idSalle+"')
        */
    } else if (req.params.Attribut == "max") {
        /* select MAX(Valeur) from Historique 
          where 
          id_TypeValue = (select id_DeviceType from Device where id_Device = 'IdCapteurCo2') 
          and 
          id_box = (select id_box from box where id_Salle = '"+req.params.idSalle+"')
          */
    } else {
        res.status(404).json({ StatutRequete: 'Mauvais attribut voir la doc' });
    }
})

app.get("Capteur/Salle/:idSalle/Temp", (req, res) => {
    //tempMoyenne journee voir historique avec id capteur

    //var Today = SELECT DATE( NOW() );

    /* select Valeur from Historique 
  where 
  id_TypeValue = (select id_DeviceType from Device where id_Device = 'IdTemps') 
  and 
  id_box = (select id_box from box where id_Salle = '"+req.params.idSalle+"')
  and
  Date = '"+Today+"'
  */

    //Apres reception donnes
    //var moyenne = 0;
    //             result.forEach( (result) => {
    //                 moyenne = moyenne + result.Valeur;
    //                 console.log(moyenne)
    //               });
    //               moyenne = moyenne / result.length;
    //               console.log(moyenne);
    //             res.status(200).json({MoyenneTemp : moyenne});
})

app.get("Capteur/Salle/:idSalle/Temp/:Attribut", (req, res) => {
    //temp min ou max  journee
    if (req.params.Attribut == "min") {
        /* select MIN(Valeur) from Historique 
            where 
            id_TypeValue = (select id_DeviceType from Device where id_Device = 'IdTemp') 
            and 
            id_box = (select id_box from box where id_Salle = '"+req.params.idSalle+"')
            */
    } else if (req.params.Attribut == "max") {
        /* select MAX(Valeur) from Historique 
            where 
            id_TypeValue = (select id_DeviceType from Device where id_Device = 'IdTemp') 
            and 
            id_box = (select id_box from box where id_Salle = '"+req.params.idSalle+"')
            */
    } else {
        res.status(404).json({ StatutRequete: 'Mauvais attribut voir la doc' });
    }
})

app.get("Capteur/Salle/:idSalle/OuvertureFenetre", (req, res) => {
    /* select Distinct Valeur from Historique 
          where 
          id_TypeValue = (select id_DeviceType from Device where id_Device = 'IdCapteurFenetre') 
          and 
          id_box = (select id_box from box where id_Salle = '"+req.params.idSalle+"')
          order by desc
      */
})

app.get("Capteur/Salle/:idSalle/NbEntree", (req, res) => {
    //nombre entre salle journee
    /* select COUNT(Valeur) from Historique 
          where 
          id_TypeValue = (select id_DeviceType from Device where id_Device = 'IDCapteurEntree') 
          and 
          id_box = (select id_box from box where id_Salle = '"+req.params.idSalle+"')
      */
})

app.get("Capteur/Salle/:idSalle/NbEntree/:Date1/:Date2", (req, res) => {
    //nombre entre salle entre deux dates

    /*
  SELECT Valeur FROM historique , box 
  id_TypeValue = (select id_DeviceType from Device where id_Device = 'IdCapteurEntree') 
  and 
  id_box = (select id_box from box where id_Salle = '"+req.params.idSalle+"')
  and
  Date BETWEEN '"+req.params.Date1+"' and '"+req.params.Date2+"'
  */
})

app.get("Capteur/Salle/:idSalle/NbSortie", (req, res) => {
    /* select COUNT(Valeur) from Historique 
          where 
          id_TypeValue = (select id_DeviceType from Device where id_Device = 'IDCapteurSortie') 
          and 
          id_box = (select id_box from box where id_Salle = '"+req.params.idSalle+"')
      */
})

app.get("Capteur/Salle/:idSalle/NbSortie/:Date1/:Date2", (req, res) => {
    //nombre sortie salle entre deux dates

    /*
    SELECT Valeur FROM historique , box 
    id_TypeValue = (select id_DeviceType from Device where id_Device = 'IdCapteurSortie') 
    and 
    id_box = (select id_box from box where id_Salle = '"+req.params.idSalle+"')
    and
    Date BETWEEN '"+req.params.Date1+"' and '"+req.params.Date2+"'
    */
})

//Fin GET -------------------------------------------------

//ID post ou put
app.put("Capteur/ChgtValeur/:IDCapteur"), (req, res) => {
    //Changé valeur d un capteur requete onem2m ou via python pas clair
}

app.put("Capteur/CapteurEntree/:Attribut"), (req, res) => {
    //Sortie ou entree qui incremente un compteur pour la journee ou rajoute une ligne je trie apres
}

//Put ou post Ajout valeur capteur sur onem2m et bdd.

app.listen(port, () => {
    console.log("Serveur disponible port " + port);
})