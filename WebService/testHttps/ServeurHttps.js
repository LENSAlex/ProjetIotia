const https = require('https');
const fs = require('fs');
var bodyParser = require("body-parser");
// var express = require('express');
// var app = express();

// app.get('/', (req, res) => {
//     res.json("test");
// })

// app.listen(8080, () => {
//     console.log("demarrage server sur 8080")
// })

const options = {
    key: fs.readFileSync('key.pem'),
    cert: fs.readFileSync('cert.pem')
};


// https.get('/', (res) => {
//     console.log('statusCode:', res.statusCode);
//     console.log('headers:', res.headers);

//     res.on('data', (d) => {
//         process.stdout.write(d);
//     });

// }).on('error', (e) => {
//     console.error(e);
// });

https.createServer(options, (req, res) => {
    // res.writeHead(200);
    // var url = req.url;
    // res.end(url)

    // res.on("data", function(chunk) {
    //     console.log("BODY: " + chunk);
    // });

    if (req.url == "/login") {
        console.log("dedans")
            //Prend les infos du corqs
        console.log(data);
        res.writeHead(200);
        res.end("bonne route")

    } else {
        console.log("non")
        res.writeHead(404);
        res.end("Mauvaise route")
    }
}).listen(8000);