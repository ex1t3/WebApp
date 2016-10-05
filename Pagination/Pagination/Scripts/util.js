$(function () {

    $('#chatBody').hide();
    $('#loginBlock').show();
    $('#chatusers').hide();
    // proxi link of hub
    var chat = $.connection.newChatHub;
    // function is called by hub
    chat.client.addMessage = function (name, message, imgLink) {
        // adding messages to page
        $('#chatroom').append('<div class="chat_block"><table><tr><td><img src="' +
            htmlEncode(imgLink) + '"/></td><td><div class="chat_area"><b>' + htmlEncode(name)
            + '</b>: ' + '<i><br/>'+htmlEncode(message) + '</i></div></td></tr></table></div>');
    };

    // function is called while user is connecting
    chat.client.onConnected = function (id, userName, allUsers) {

        $('#loginBlock').hide();
        $('#chatBody').show();
        // hidden id and user name
        $('#hdId').val(id);
        $('#username').val(userName);
        $('#header').html('<h3>Welcome, ' + '<i>'+userName +'</i></h3>');

        // all users list
        for (i = 0; i < allUsers.length; i++) {

            AddUser(allUsers[i].ConnectionId, allUsers[i].Name);
        }

    
    }

    // adding user to chat
    chat.client.onNewUserConnected = function (id, name) {

        AddUser(id, name);

    }
    chat.client.onCheckUsers = function (allUsers) {

        if (allUsers.length <= 1) {
            $("#chatusers").append('You are the first one!');

        }
    }
    // deleting user
    chat.client.onUserDisconnected = function (id, userName) {

        $('#' + id).remove();
    }
   /* $(function () {

        var notificationhub = $.connection.notificationHub;

        notificationhub.client.displayMessage = function (message) {

            $('#notification').html(message);
        };

        $.connection.hub.start();

    });
    */
    // openning connection
    $.connection.hub.start().done(function () {

        $('#sendmessage').click(function () {
            // Викликаєм у хаба метод Send
            var mes = $("#message").val();
            if (mes.length > 0) {
                chat.server.send($('#username').val(), $('#message').val());
                $('#message').val('');
            } else {
                alert("Type message, please!")
            }
        });
        // login processing
        $("#btnLogin").click(function () {

            var name = $("#txtUserName").val();
            if (name.length > 0) {
                chat.server.connect(name);
            }
            else {
                alert("Type your name!");
            }
        });
    });
});
// tags codying
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}
//Adding new user
function AddUser(id, name) {

    var userId = $('#hdId').val();
    if (userId != id) {
        $("#chatusers").append('<p id="' + id + '"><b>' + name + '</b></p>');
    }
  
}
$("#showUsers").click(function () {
    $('#chatusers').show();
    if ($('#showUsers').val() == 'Show users') {
        $('#showUsers').val('Hide users');

    } else {
        $('#showUsers').val('Show users');
        $('#chatusers').hide();
    }
    
  
    
});