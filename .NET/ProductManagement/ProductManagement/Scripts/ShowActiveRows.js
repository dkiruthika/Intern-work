$(document).ready(function () {
    $("#checkbox").change(function () {
        if (this.checked) {
            $("#product tbody tr").each(function () {
                var activeStatus = $(this).find("td:nth-child(3)").text().trim();
                if (activeStatus !== "Yes") {
                    $(this).hide();
                } else {
                    $(this).show();
                }
            });
        } else {
            $("#product tbody tr").show();
        }
    });
});