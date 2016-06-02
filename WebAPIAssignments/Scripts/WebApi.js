function GetAllProducts() {
    debugger;
    jQuery.support.cors = true;
    $.ajax({
        url: 'http://localhost:50275/api/ProductDetails',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
function AddProducts() {
    jQuery.support.cors = true;
    var Product = {
        ID: $('#txtaddProid').val(),
        Name: $('#txtaddProName').val(),
        Category: $('#txtaddProCat').val(),
        Price: $('#txtaddEmpPri').val()
    };

    $.ajax({
        url: 'http://localhost:50275/api/ProductDetails',
        type: 'POST',
        data: JSON.stringify(Product),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
function DeleteEmployee() {
    debugger;
    jQuery.support.cors = true;
    var id = $('#txtdelProId').val()

    $.ajax({
        url: 'http://localhost:50275/api/ProductDetails/' + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function WriteResponse(Products) {
    var strResult = "<table><th>ID</th><th>Name</th><th>Category</th><th>Price</th>";
    $.each(Products, function (index, Product) {
        strResult += "<tr><td>" + Product.id + "</td><td> " + Product.Name + "</td><td>" + Product.Category + "</td><td>" + Product.Price + "</td></tr>";
    });
    strResult += "</table>";
    $("#divResult").html(strResult);
}

function ShowProducts(Product) {
    if (Product != null) {
        var strResult = "<table><th>EmpID</th><th>Emp Name</th><th>Emp Department</th><th>Mobile No</th>";
        strResult += "<tr><td>" + Product.id + "</td><td> " + Product.Name + "</td><td>" + Product.Category + "</td><td>" + Product.Price + "</td></tr>";
        strResult += "</table>";
        $("#divResult").html(strResult);
    }
    else {
        $("#divResult").html("No Results To Display");
    }
}

function GetProducts() {
    jQuery.support.cors = true;
    var id = $('#txtProid').val();
    $.ajax({
        url: 'http://localhost:50275/api/ProductDetails/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            ShowProducts(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}