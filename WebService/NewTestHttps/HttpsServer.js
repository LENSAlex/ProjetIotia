const fs = require('fs')
const https = require('https')

/*
Best tuto : https://mylittleneuron.com/2019/04/07/creer-un-serveur-https-avec-nodejs-et-powershell/
*/

//https://localhost:4040/login


var credentials = { 
    pfx: fs.readFileSync(__dirname + '/certif.pfx'),  //A voir pour autorisé le certif sur notre serveur
    passphrase: '*' //mettre mdp certif
}


var server = https.createServer(credentials,function (req, res) {
    // res.writeHead(200,{'Content-Type': 'text/plain'})
    // res.end('Hello World\n')


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