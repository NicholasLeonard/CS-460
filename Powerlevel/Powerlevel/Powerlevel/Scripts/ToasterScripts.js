$(document).ready(function () {
    //Table here is created on Exercise/Index to generate all exercise entries
    $('#myTable').DataTable({
        paging: false
    });

    //Table in the UserWorkout/History page, default order by date descending
    $('#myHistoryTable').DataTable({
        paging: false,
        "order": [[1, "desc"]]
    });

});