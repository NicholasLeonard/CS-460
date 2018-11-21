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
        
    });
};

var interval = 1000 * 5;

function displayBids(AllBids) {
    console.log(AllBids);
    console.log("AllBids above");
    var test = JSON.parse(AllBids);
    console.log("test above");
    console.log(test);
}