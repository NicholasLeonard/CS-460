function errorOnAjax() {
    console.log("ERROR: Couldn't connect to the GetWorkoutReward API.")
}


//function to get current user's EXP and LEVEL, no need to pass in parameters, since it's hard-coded in the API controller
function ajax_getWorkoutRewards() {
    $.ajax({
        type: 'GET',
        dataType: 'Json',
        url: "/API/GetWorkoutRewards/" + $('#currentWorkoutID').text(),
        success: function (rewardData) { //pass the result into userData
            $('#Exp_Amount').text(rewardData[0])
        },
        error: errorOnAjax
    });
}

//call this function when page fully loaded
$(document).ready(function () {
    
    ajax_getWorkoutRewards();
});