$('#productId').blur(function () {
    $.ajax({
        url: "https://localhost:44350/api/Product/{productId}",
        type: "GET",
        data: { "productId": $("#productId").val() },
        success: function (response) {
            // Display the old product name in the input field
            $("#oldProductName").val(response.ProductName);
            $("#oldStatus").val(response.Active);
        },
        error: function (error) {
            console.log(error);
        }
    });
});