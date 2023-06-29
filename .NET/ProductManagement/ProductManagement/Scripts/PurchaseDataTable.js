$(document).ready(function () {
    $("#purchase").DataTable({
        "ajax": {
            "url": "/Purchase/GetPurchaseData",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Id" },
            { "data": "ProductId" },
            { "data": "PurchaseDate" },
            { "data": "Quantity" }
        ]

    })
})