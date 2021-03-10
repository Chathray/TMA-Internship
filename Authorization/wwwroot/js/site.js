// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function InternLeave(iid, btn) {

    $.ajax({
        method: "POST",
        url: "Home/InternLeave",
        data: { id: iid }
    }).done(function (msg) {
        alert("Gone: " + msg);

        var row = btn.parentNode.parentNode;
        row.parentNode.remove();
    });
}