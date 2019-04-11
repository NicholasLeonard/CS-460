$(document).ready(function () {
    //Table here is created on Exercise/Index to generate all exercise entries
    $('#myTable').DataTable({
        paging: false
    });
});

/*This builds and renders the workout calendar on the main page.
 Note: To add functionality you need to render additional .css and .js files on the layout page
 then add plugins to this function.*/
$(document).ready(function () {
    var calendarEl = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        plugins: ['dayGrid'],
        defaultView: 'dayGridMonth',
        defaultDate: '2019-04-12',
        eventColor: 'green'
        
    });

    calendar.render();
    
});

$("#calendar").fullCalendar({
    events: [{
        id: 'a',
        title: 'testing',
        start: '2019-04-11'
    }]
});
