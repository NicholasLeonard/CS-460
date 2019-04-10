$(document).ready(function () {
    //Table here is created on Exercise/Index to generate all exercise entries
    $('#myTable').DataTable({
        paging: false
    });
});

document.addEventListener('DOMContentLoaded', function () {
    var calendarE1 = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarE1, {
        plugins: ['dayGrid']
    });

    calendar.render();
});