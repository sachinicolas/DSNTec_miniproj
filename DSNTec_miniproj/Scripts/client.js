$(document).ready(function () {
    loadData();
    loadControls();
});

function loadData() {
    $.ajax({
        url: "/Client/ListAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ClientID + '</td>';
                html += '<td>' + item.Name + '</td>';
                //html += '<td>' + item.ProvinceID + '</td>';
                html += '<td>' + item.Province.Description + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.ClientID + ')">Edit</a> | <a href="#" onclick="Delete(' + item.ClientID + ')">Delete</a></td>';
                html += '</tr>';
            });

            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function loadControls() {
    $.ajax({
        url: "/Province/ListAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, item) {
                var provDesc = new Option(item.Description);

                $(provDesc).html(item.Description);

                $("#ProvinceDescription").append(provDesc);
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Add() {
    if (validate() == false) {
        return false;
    }

    var provObj = {
        ProvinceID: $('#ProvinceDescription').prop('selectedIndex'),
        Description: $('#ProvinceDescription').val(),
    };

    var cliObj = {
        ClientID: $('#ClientID').val(),
        Name: $('#Name').val(),
        //ProvinceID: $('#ProvinceDescription').prop('selectedIndex'),
        Province: provObj,
    };

    $.ajax({
        url: "/Client/Add",
        data: JSON.stringify(cliObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();

            alert("Client added correctly.");

            $('#ClientID').val("");
            $('#Name').val("");
            //$('#ProvinceID').val("");
            $('#ProvinceDescription').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function getbyID(id) {
    $('#Name').css('border-color', 'lightgrey');
    //$('#ProvinceID').css('border-color', 'lightgrey');
    $('#ProvinceDescription').css('border-color', 'lightgrey');

    $.ajax({
        url: "/Client/GetByID/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ClientID').val(result.ClientID);
            $('#Name').val(result.Name);
            //$('#ProvinceID').val(result.ProvinceID);
            $('#ProvinceDescription').prop('selectedIndex', result.Province.ProvinceID);

            $('#myModal').modal('show');

            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function Update() {
    if (validate() == false) {
        return false;
    }

    var provObj = {
        ProvinceID: $('#ProvinceDescription').prop('selectedIndex'),
        Description: $('#ProvinceDescription').val(),
    };

    var cliObj = {
        ClientID: $('#ClientID').val(),
        Name: $('#Name').val(),
        //ProvinceID: $('#ProvinceDescription').prop('selectedIndex'),
        Province: provObj,
    };

    $.ajax({
        url: "/Client/Update",
        data: JSON.stringify(cliObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();

            $('#myModal').modal('hide');

            $('#ClientID').val("");
            $('#Name').val("");
            //$('#ProvinceID').val
            $('#ProvinceDescription').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Delete(id) {
    var ans = confirm("Are you sure you want to delete this record?");

    if (ans) {
        $.ajax({
            url: "/Client/Delete/" + id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function clearTextBoxes() {
    $('#ClientID').val("");
    $('#Name').val("");
    //$('#ProvinceID').val("");
    $('#ProvinceDescription').val("");

    $('#Name').css('border-color', 'lightgrey');
    //$('#ProvinceID').css('border-color', 'lightgrey'); 
    $('#ProvinceDescription').css('border-color', 'lightgrey'); 

    $('#btnUpdate').hide();
    $('#btnAdd').show();
}

function validate() {
    var isValid = true;

    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');

        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }

    /*
    if ($('#ProvinceID').val().trim() == "") {
        $('#ProvinceID').css('border-color', 'Red');

        isValid = false;
    }
    else {
        $('#ProvinceID').css('border-color', 'lightgrey');
    }
    */

    if ($('#ProvinceDescription').prop('selectedIndex') == 0) {
        $('#ProvinceDescription').css('border-color', 'Red');

        isValid = false;
    }
    else {
        $('#ProvinceDescription').css('border-color', 'lightgrey');
    }

    return isValid;
}