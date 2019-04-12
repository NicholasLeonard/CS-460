function errorOnAjax() {
    console.log("ERROR: Couldn't connect to the user API.")
}


//function to get current user's EXP and LEVEL, no need to pass in parameters, since it's hard-coded in the API controller
function ajax_getUserInfos() {
    $.ajax({
        type: 'GET',
        dataType: 'Json',
        url: "/API/GetUser",
        success: function (userData) { //pass the result into userData
            $('#userInfos_navbar').text("LEVEL: " + userData[0].Level + " | " + "EXP: " + userData[0].Experience);
        },
        error: errorOnAjax
    });
}

//call this function when page fully loaded
$(document).ready(function () {

    var interval = 1000 * 1; // call this refresh function every 1 seconds.
    window.setInterval(ajax_getUserInfos, interval);
});