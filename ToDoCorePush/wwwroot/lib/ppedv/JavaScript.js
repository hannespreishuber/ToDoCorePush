//Todo Parameterisieren ddata-ppedv-huburl="ToDoHub" data-ppedv-function="DoneToDoHub"
var connection = new signalR.HubConnectionBuilder().withUrl("/ToDoHub").build();

connection.on("DoneToDo", function (message) {
    var container = document.querySelector('[data-ppedv-placeholder]');
    container.innerHTML = message.result;
    container.querySelectorAll('[data-ppedv-action]').forEach(function (i) {
        i.onclick = Action;

    });

});
connection.onclose(function (e) {
    alert('connection closed');
});


connection.start().catch(function (err) {
    return console.error(err.toString());
});

//Library Preview

//Set it up
//foreach soll sehr langsam sein
document.querySelectorAll('[data-ppedv-action]').forEach(function (i) {
    i.onclick = Action;

});
//universeller CRUD Action Handler
function Action() {

    var action = this.getAttribute('data-ppedv-action');
    switch (action) {
        case "Check":

            connection.invoke('Action', this.value, action).catch(function (err) {
                return console.error(err.toString());
            });
            break;
        case "Add":
            var message = document.querySelector('[data-ppedv-parameter]').value;

            connection.invoke('Action', message, action).catch(function (err) {
                return console.error(err.toString());
            });
            break;

        default:
    }


    event.preventDefault();
}
