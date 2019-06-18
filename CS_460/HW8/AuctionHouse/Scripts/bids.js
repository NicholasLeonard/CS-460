$(document).ready(function () {
    window.setInterval(ajax_call, interval);
});

//ajax function for calling to the server
var ajax_call = function () {
    var pageURL = window.location.href;
    var id = pageURL.substr(pageURL.lastIndexOf('/') + 1);
    var source = "/Home/Update/" + id;
    
    $.ajax({
        method: "GET",
        dataType: "json",
        url: source,
        success: displayBids,
        error: displayError
    });
};

var interval = 1000 * 5;

//used to display all of the bids on the page
function displayBids(AllBids) {

    $("#bids").empty();
    var test = JSON.parse(AllBids);
 
    for (var x = 0; x < test.length; x++) {
        console.log(test[x]);
        $("#bids").append("<tr id='row'><td>" + test[x].Buyer + "</td > <td>" + test[x].Price + "</td></tr>");
    }
}

//used for displaying an error message if JSON returns an error
function displayError() {
    $("#bids").empty();
    $("#bids").append("ERROR IN THE AJAX!");
}