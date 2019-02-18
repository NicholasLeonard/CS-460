$(function () {
    $('#BirthDate').datetimepicker({
        format: "MM/DD/YYYY"
    }).on('dp.change', function (e) {
        $(this).data('DateTimePicker').hide();
    });
});