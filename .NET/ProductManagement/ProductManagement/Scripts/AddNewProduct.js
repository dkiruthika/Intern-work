
$("#addNewProduct").click(function () {
    var productName = $("#productName").val();
    var activeStatus = $("#toggleSwitch").prop("checked") ? "Yes" : "No";

    // Create the new row object
    var newRow = {
        Id: 0,
        ProductName: productName,
        Active: activeStatus
    };

    // Send AJAX request to save the new row
    $.ajax({
        url: "https://localhost:44350/api/Product/AddProduct",

        type: "POST",
        data: JSON.stringify(newRow),
        contentType: "application/json",
        success: function (response) {
            // Refresh the DataTable to display the new row
            $("#product").DataTable().ajax.reload();

            // Clear the form inputs
            $("#productName").val("");
            $("#toggleSwitch").prop("checked", false);

            // Close the modal
            $("#exampleModal").modal("hide");
        },
        error: function (error) {
            
                console.log(error);
            
        }
    });
});