$(document).ready(function () {
    $('#container').hide();
});

function startDiscussion() {

    // Declare a proxy to reference the hub.  
    var chat = $.connection.chatHub;
    // Create a function that the hub can call to broadcast messages.  
    chat.client.broadcastMessage = function (name, message) {

        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();

        $('#discussion').append('<li><h4>' + encodedName
            + '</h4>:  ' + encodedMsg + '</li>');
    };
    $('#message').focus();
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            chat.server.send($('#displayname').val(), $('#message').val());
            $('#message').val('').focus();
        });
    });
}

function AddUser() {
    if ($('#username').val() == "") {
        alert('enter username');
        return;
    }
    $('#displayname').val($('#username').val());
    $('#container').show();
    $('#setUser').hide();
    startDiscussion();
    $('#welcome').append(" : " + $('#username').val());
}  

// for getallproduct view remaining time
