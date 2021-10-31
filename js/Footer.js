$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});
//------------------------------------------ Alert close ----------------------------------------
$(".close-alert-box").click(function () {
    $(".alert-box").fadeOut();
});

//------------------------------------------- Loader -------------------------------------------------
$(".click-on").click(function () {
    $(".after-click").fadeIn();
});
var loader = document.getElementById("loader");
window.addEventListener("load", function () {
    $("#loader").fadeOut();
});
$(".stop-loading").click(function () {
    $(".after-click").fadeOut();
    $("#loader").fadeOut();
});