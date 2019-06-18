$(document).ready(function () {
    //Table here is created on Exercise/Index to generate all exercise entries
    $('#myTable').DataTable({
        paging: false
    });

    //Table in the UserWorkout/History page, default order by date descending
    $('#myHistoryTable').DataTable({
        paging: false,
        "order": [[1]]
    });

});

//used to update the calendar workout event based on the events url state so that it only adjusts
//it in the db if there is not a currently active workout.
function EventClick(event) {
        if (event.url != "") {
            console.log(event.description);
            $.ajax("/UserWorkouts/UpdateEvents/" + event.id);
        }
        else {
            console.log("Clicked");
        }
}