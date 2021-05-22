"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("Posalji").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});


connection.start().then(function () {
    document.getElementById("Posalji").disabled = false;
    var user = document.getElementById("userName").innerHTML;
    connection.invoke("Connect", user);
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("Posalji").addEventListener("click", function (event) {
    var user = document.getElementById("userName").innerHTML;
    var message = document.getElementById("messageInput").value;
    var receiver = document.getElementById("userNameToWho").innerHTML;
    connection.invoke("SendMessage", user, message, receiver).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
