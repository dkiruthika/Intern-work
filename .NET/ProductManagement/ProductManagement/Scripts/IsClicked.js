$(document).ready(function () {
    var table = $('#product').DataTable();

    $('#product tbody').on('click', 'tr', function () {

        $("#view").removeAttr('disabled');
    });
});