"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("Posalji").disabled = true;

connection.on("ReceiveMessage", function (user, message, userWhom) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("Posalji").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("Posalji").addEventListener("click", function (event) {
    var user = document.getElementById("userName").innerHTML;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

//proba
/*document.getElementById("sendPrivateButton").disabled = true;

connection.on("broadcasttouser", function (user, message, userWhom) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg + userWhom;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendPrivateButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendPrivateButton").addEventListener("click", function (event) {
    var user = document.getElementById("userName").innerHTML;
    var message = document.getElementById("messageInput").value;
    var userWhom = document.getElementById("userNameToWho").innerHTML;
    connection.invoke("BroadcastToUser", user, message, userWhom).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});    */

//nesto
/*
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub", {
        accessTokenFactory: () => "testing"
    })
    .build();

connection.on("PrimljenaPoruka", function (user, message, connectionId) {

    //code for generating new message
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg + connectionId;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);

});


connection.start().then(function () {
    connection.invoke('GetConnectionId')
        .then(function (connectionId) {
            //alert(connectionId);
            return connectionId;
        });
}*/