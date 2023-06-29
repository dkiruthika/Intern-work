$(document).ready(function () {
    var table = $('#purchase').DataTable();

    $('#purchase tbody').on('click', 'tr', function () {

        $("#view").removeAttr('disabled');
    });
});