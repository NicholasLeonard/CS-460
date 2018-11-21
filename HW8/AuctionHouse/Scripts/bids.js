$(document).ready(function () {
    window.setInterval(ajax_call, interval);
});

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

function displayBids(AllBids) {

    $("#bids").empty();
    var test = JSON.parse(AllBids);
 
    for (var x = 0; x < test.length; x++) {
        console.log(test[x]);
        $("#bids").append("<tr id='row'><td>" + test[x].Buyer + "</td > <td>" + test[x].Price + "</td></tr>");
    }
}

function displayError() {
    $("#bids").empty();
    $("#bids").append("ERROR IN THE AJAX!");
}