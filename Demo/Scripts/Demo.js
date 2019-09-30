var Confirmation = function (id) {
    $('#userid').val(id);
    $('#MyModal').modal('show');
}
var confirmationDepartment = function (id) {
    debugger;
    $('#deptid').val(id);
    $('#DepartmentModal').modal('show');
}
var DeleteUser = function () {
    var userId = $('#userid').val()
    $.ajax({
        type: 'GET',
        url: '/User/DeleteUser',
        data: { 'id': userId },
        success: function (response) {
            if (response == "1") {
                $('#MyModal').modal('hide');
                $('#row_' + userId).remove();
            }
        },
        error: function (error) { alert('something happen wrong') },
    })
}
var DeleteDepartment = function () {
    var deptId = $('#deptid').val()
    $.ajax({
        type: 'GET',
        url: '/Department/DeleteDepartment',
        data: { 'id': deptId },
        success: function (response) {
            if (response == "1") {
                $('#DepartmentModal').modal('hide');
                $('#row_' + deptId).remove();
            }
            if (response == "Assigned") {
                $('#DepartmentModal').modal('hide');
                alert('You can not delete department because it is assigned to user')
            }
        },
        error: function (error) { alert('something happen wrong') },
    })
}

$(function () {
    function Validate() {
        if ($('#txtFName').val() == "") {
            $('#txtFName').css('border-color', 'red');
            $('#txtFName').focus();
            return false;
        }
        else {
            $('#txtFName').css('border-color', 'green');
        }
        if ($('#txtLName').val() == "") {
            $('#txtLName').css('border-color', 'red');
            $('#txtLName').focus();
            return false;
        }
        else {
            $('#txtLName').css('border-color', 'green');
        }
        if ($('#txtCountry').val() == "") {
            $('#txtCountry').css('border-color', 'red');
            $('#txtCountry').focus();
            return false;
        }
        else {
            $('#txtCountry').css('border-color', 'green');
        }
        if ($('#txtDescription').val() == "") {
            $('#txtDescription').css('border-color', 'red');
            $('#txtDescription').focus();
            return false;
        }
        else {
            $('#txtDescription').css('border-color', 'green');
        }
        if ($('#txtAddress').val() == "") {
            $('#txtAddress').css('border-color', 'red');
            $('#txtAddress').focus();
            return false;
        }
        else {
            $('#txtAddress').css('border-color', 'green');
        }
        if ($('#DepartmentId').val() == null) {
            $('#DepartmentId').css('border-color', 'red');
            $('#DepartmentId').focus();
            return false;
        }
        else {
            $('#DepartmentId').css('border-color', 'green');
        }

        return true;
    }
    function ValidateDepartment() {
        if ($('#Description').val() == "") {
            $('#Description').css('border-color', 'red');
            $('#Description').focus();
            return false;
        }
        else {
            $('#Description').css('border-color', 'green');
        }
        if (($('#Address').val() == "")) {
            $('#Address').css('border-color', 'red');
            $('#Address').focus();
            return false;
        }
        else {
            $('#Address').css('border-color', 'green');
        }
        return true;
    }
    function clearFields() {
        $('input[type="text"]').each(function () {
            $(this).val('');
        });
    }

    $('#btnSave').click(function () {

        if (Validate()) {
            var data = $('#user').serialize();
            $.ajax({
                type: 'POST',
                url: '/User/SaveUser',
                data: data,
                success: function (response) {
                    clearFields();
                    window.location.href = response;
                },
                error: function () { },
            });
        }
    });
    $('#btnEditUser').click(function () {
        debugger;
        if (Validate()) {
            var data = $('#useredit').serialize();
            $.ajax({
                type: 'POST',
                url: '/User/EditUser',
                data: data,
                success: function (response) {
                    clearFields();
                    window.location.href = response;
                },
                error: function () { },
            });
        }
    });
    $('#deptAdd').click(function () {
        debugger;
        if (ValidateDepartment()) {
            var data = $('#departmentForm').serialize();
            $.ajax({
                type: 'POST',
                url: '/Department/AddDepartment',
                data: data,
                success: function (response) {
                    clearFields();
                    window.location.href = response;
                   
                },
                error: function () { },
            });
        }
    });
    $('#btnEditDepartment').click(function () {
        debugger;
        if (ValidateDepartment()) {
            var data = $('#depteditform').serialize();
            $.ajax({
                type: 'POST',
                url: '/Department/EditDepartment',
                data: data,
                success: function (response) {
                    clearFields();
                    window.location.href = response;
                },
                error: function () { },
            });
        }
    });

});