var express = require('express');
var app = express();
var swaggerTools  = require('swagger-tools');

var swaggerDoc = require('./swagger.json')  

app.get('/', function(req, res) {
  res.send('Hello World!');
});

//La ca marche avec swagger mais que avec la version 2.0
swaggerTools.initializeMiddleware(swaggerDoc, function (middleware) {
  // Serve the Swagger documents and Swagger UI
  app.use(middleware.swaggerUi());
});

app.listen(5000, function() {
  console.log('Example app listening on port 5000!');
});