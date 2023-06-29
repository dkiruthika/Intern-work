$("#editProduct").click(function () {
    var productName = $("#newProductName").val();
    var productId = $("#productId").val();
    var productStatus = $("#newStatus").val();

    // Create the new row object
    var newRow = {
        ProductName: productName,
        Id: productId,
        Active: productStatus
    };

    // Send AJAX request to save the new row
    $.ajax({
        url: "https://localhost:44350/api/Product/Edit",
        type: "POST",
        data: JSON.stringify(newRow),
        contentType: "application/json",
        success: function (response) {
            // Refresh the DataTable to display the new row
            $("#product").DataTable().ajax.reload();

            $("#editProductForm")[0].reset();

            // Close the modal
            $("#exampleModal").modal("hide");
        },
        error: function (error) {
            console.log(error);
        }
    });
});
