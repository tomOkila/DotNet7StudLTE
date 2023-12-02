// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ShowMessage(msg) {
    toastr.success(msg);
}

function ShowMessageError(msg) {
    toastr.error(msg);
}

//Initialize Select2 Elements
$('.select2').select2({
    dropdownAutoWidth: 'true',
    width: '100%'
})

//Date picker
$('.datepicker').datepicker({
    autoclose: true
})