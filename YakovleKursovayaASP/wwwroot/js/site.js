// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('document').ready(function ()  {
    GetCartLength();
})
function AddToCart(id) {
    $.ajax({
        url:'Cart/AddToCart',
        method: "POST",
        data: {id: id},
        success: function (result) {
            console.log(result);
            GetCartLength();
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
        }
    });
}

function GetCartLength() {
    $.ajax({
        url: 'Cart/GetCartLength',
        method: "Get",
        success: function (result) {
            console.log(result);
            $(".cart-icon > span").text(`${result}`);
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
        }
    });
}