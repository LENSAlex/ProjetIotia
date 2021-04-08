var mqtt = require('mqtt');
var xtend = require('xtend');
//mqtt://51.75.125.121

options = {
    clientId: "test",
    username: "alexiotia",
    password: "iotia",
    clean: true
};
console.log("connected flag  " + client.connected);

var client = mqtt.connect("qtt://51.75.125.121", options)


client.on("connect", function() {
    console.log("connected");
})

client.end();