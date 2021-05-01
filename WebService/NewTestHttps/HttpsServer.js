const fs = require('fs')
const https = require('https')

/*
Best tuto : https://mylittleneuron.com/2019/04/07/creer-un-serveur-https-avec-nodejs-et-powershell/
*/

//https://localhost:4040/login


var credentials = { 
    pfx: fs.readFileSync(__dirname + '/certif.pfx'),  //A voir pour autorisé le certif sur notre serveur
    passphrase: 'jessicalex' //mettre mdp certif
}


var server = https.createServer(credentials,function (req, res) {
    // res.writeHead(200,{'Content-Type': 'text/plain'})
    // res.end('Hello World\n')

    console.log(req);
    if(req.method == "POST")
    {
        if(req.url == "/Batiment/CountInfo/Campus") {
            conn.query("UPDATE `Personne` SET `num_ref` = '" + req.params.NumRef + "', `id_pers_type` = '" + req.params.IdPersType + "', `password` = '" + req.params.Password + "', `email` = '" + req.params.Email + "', `telephone` = '" + req.params.Tel + "', `sexe`= '" + req.params.Sexe + "', `nom` = '" + req.params.Nom + "', `prenom` = '" + req.params.Prenom + "', `date_anniversaire` = '" + req.params.Birth + "' where id_personne = '" + req.params.IdPersonne + "' ", function(err, result) {
                if (err)
                    res.status(400).json({ ErrorRequete: 'Requete invalid' });
                else {
                }
            });
        
            //La je vais chercher la requete que je viens d envoyer pour avoir l id de l utilisateur cree
            //Que si eleve
            if ( req.params.IdPersType == 1) {
                    //La je vais chercher la requete que je viens d envoyer pour avoir l id de l utilisateur cree
                conn.query("UPDATE `Contenir` set `id_promotion` = " + req.params.IdPromo + " where id_eleve= " + req.params.IdPersonne + "", function(err, result) {
                    if (err)
                    {
                        res.writeHead(400);
                        res.end("error")
                    }
                    else {
                        res.writeHead(200);
                        res.write(JSON.stringify("etudiant modifié"));
                        res.end();
                    }
                });
            } else {
                res.writeHead(200);
            }
        }
    }

    if (req.url == "/login") {
        console.log("dedans")
            //Prend les infos du corqs
        // console.log(data);
        res.writeHead(200);
        res.end("bonne route")

    } else {
        res.writeHead(404);
        res.end("Mauvaise route")
    }


  })
  
  server.listen(4040)