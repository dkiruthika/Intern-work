$("#addNewPurchase").click(function () {
    var productId = $("#productName").val();

    var quantity = $("#quantity").val();
    var selectedDate = $('#dateInput').val();
    var newPurchase = {
        ProductId: productId,
        PurchaseDate: selectedDate,
        Quantity: quantity
    };

    // Send AJAX request to save the new row
    $.ajax({
        url: "/Purchase/AddPurchase",
        type: "POST",
        data: JSON.stringify(newPurchase),
        contentType: "application/json",
        success: function (response) {
            // Refresh the DataTable to display the new row
            $("#purchase").DataTable().ajax.reload();

            // Clear the form inputs
            $("#productName").val("");
            $("#quantity").val("");
            $("#dateInput").val("");

            // Close the modal
            $("#exampleModal").modal("hide");
        },
        error: function (error) {
            console.log(error);
        }
    });
});