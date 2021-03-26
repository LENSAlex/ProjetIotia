// const https = require('https');
// // const fs = require('fs');

// // const options = {
// //   key: fs.readFileSync('key.pem'),
// //   cert: fs.readFileSync('cert.pem')
// // };

// // https.createServer(options, function (req, res) {
// //   res.writeHead(200);
// //   res.end("hello world\n");
// // }).listen(8000);

// //https://blog.ineat-group.com/2019/11/creer-une-api-node-js-et-la-securiser-avec-keycloak/


// var options = {
//     host: 'test.example.com',
//     port: 443,
//     path: '/api/service/Auth',
//     // authentication headers
//     headers: {
//        'Authorization': 'Basic ' + new Buffer('alex' + ':' + 'lens').toString('base64')
//     }   
//  };

//  //this is the call
//  request = https.get(options, function(res){
//     var body = "";
//     res.on('data', function(data) {
//        body += data;
//     });
//     res.on('end', function() {
//      //here we have the full response, html or json object
//        console.log(body);
//     })
//     res.on('error', function(e) {
//        onsole.log("Got error: " + e.message);
//     });
// });


/*Keycloack start standalone.sh
http://localhost:8080/auth/admin to connect tel

*/

var express = require('express');
var bodyParser = require("body-parser");

var session = require("express-session");
var Keycloak = require("keycloak-connect");

var app = express();

// // parse application/x-www-form-urlencoded
// app.use(bodyParser.urlencoded({ extended: false }))
// // parse application/json
// app.use(bodyParser.json())


//middlewares
const memoryStore = new session.MemoryStore();
app.use(
    session({
        secret: 'secretKey',
        resave: false,
        saveUninitialized: true,
        store: memoryStore
    })
);

//keycloak.json for keycloak-connect error
const keycloak = new Keycloak({
    store: memoryStore
});
app.use(
    keycloak.middleware({
        logout: '/logout',
        admin: '/'
    })
);

app.get('/api/unsecured', function(req, res) {
    res.json({ message: 'This is an unsecured endpoint payload' });
});


//keycloak.protect() for the rigth of route
app.get('/api/user', keycloak.protect('realm:user'), function(req, res) {
    res.json({ message: 'This is an USER endpoint payload' });
});

app.listen(3000, err => {
    if (err) {
        console.error(err);
    } {
        console.log(`APP Listen to port : 3000`);
    }
});