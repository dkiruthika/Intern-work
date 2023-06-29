
    $(document).ready(function () {
        $("#product").DataTable({
            "ajax": {
                "url": "/Product/GetData",
                "type": "GET",
                "datatype": "json"
            },
            "columns": [
                { "data": "Id" },
                { "data": "ProductName" },
                { "data": "Active" }
            ]

        })
    })
