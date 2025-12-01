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
            $('.pb-3').html(result);
            console.log(result);
            GetCartLength();
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
        }
    });
}

function AddToCartInShop(id) {
    $.ajax({
        url: 'Cart/AddToCart',
        method: "POST",
        data: { id: id },
        success: function (result) {
            console.log(result);
            GetCartLength();
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
        }
    });
}

function reduceItem(id) {
    $.ajax({
        url: 'Cart/ReduceItem',
        method: "POST",
        data: { id: id },
        success: function (result) {
            $('.pb-3').html(result);
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
function removeFromCart(id) {
    $.ajax({
        url: 'Cart/RemoveItem',
        method: "Post",
        data: {id: id},
        success: function (result) {
            $('.pb-3').html(result);
            GetCartLength();
        },
    });
}

function ChangeValue(id) {
    var value = $(`#qty2-${id}`).val();
    $.ajax({
        url: 'Cart/ChangeValue',
        method: "Post",
        data: { id: id, value: value },
        success: function (result) {
            $('.pb-3').html(result);
            GetCartLength();
        },
    });
}