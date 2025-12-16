// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('document').ready(function () {
    GetCartLength();
    GetBrands();
    GetGenre();
    GetGameType();
    GetSubject();
    GetStudingType();
    GetProductTypes();
});

function AddToCart(id) {
    $.ajax({
        url: 'Cart/AddToCart',
        method: "POST",
        data: { id: id },
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
        data: { id: id },
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
function startOrder() {
    $('.remove-icon').hide();
    $('.qtyminus').hide();
    $('.qtyplus').hide();
    $('.qty').attr('disabled', 'disabled');
    $('#qty2-2').attr('disabled', 'disabled');
    
    $.ajax({
        url: 'Cart/OrderForm',
        method: "Get",
        success: function (result) {
            $('#orderForm').html(result);
            $('#startOrdedBtn').hide();
        },
    });
}

function cancelOrder() {
    $('.remove-icon').show();
    $('.qtyminus').show();
    $('.qtyplus').show();
    $('.qty').attr('disabled', 'false');
    $('#orderForm').html('');
    $('#startOrdedBtn').show();
}

function GetByFilters() {
    var values = getFormValuesFromDiv($('.Filters')[0]);
    $.ajax({
        url: 'Home/GetByFilters',
        method: "Get",
        data: values,
        success: function (result) {
            console.log(result);
            $.ajax({
                url: 'Home/GetFilteredProducts',
                method: "POST",
                data: { filteredProductsString: JSON.stringify(result.filteredProducts) },
                success: function (result) {
                    $('#products').html(result);
                }
            });
            console.log(result.fieldsWithNonNullValues.length);
            if (result.fieldsWithNonNullValues.length > 0) {
                $('#filterHolder').find('div[data-filter]').css('display', 'none');
                // Перебираем массив и скрываем каждый элемент
                $.each(result.fieldsWithNonNullValues, function (index, filterValue) {
                    $(`[data-filter="${filterValue}"]`).css('display', 'block');
                });
            }
        }
    });
}

function GetBrands() {
    $.ajax({
        url: 'Home/GetBrands',
        method: "Get",
        success: function (result) {
            $('#Brand').html(result);
            $('#Brand').css('display', 'inline');
            $('#Brand').next('div').remove();
        },
    });
}

function GetGenre() {
    $.ajax({
        url: 'Home/GetGenre',
        method: "Get",
        success: function (result) {
            $('#Genre').html(result);
            $('#Genre').css('display', 'inline');
            $('#BindingType').css('display', 'inline');
            $('#BindingType').next('div').remove();
            $('#Genre').next('div').remove();
            $('#Sort').css('display', 'inline');
            $('#Sort').next('div').remove();
            $('#SortWay').css('display', 'inline');
            $('#SortWay').next('div').remove();
        },
    });
}

function GetGameType() {
    $.ajax({
        url: 'Home/GetGameType',
        method: "Get",
        success: function (result) {
            $('#GameType').html(result);
            $('#GameType').css('display', 'inline');
            $('#GameType').next('div').remove();

        },
    });
}

function GetSubject() {
    $.ajax({
        url: 'Home/GetSubject',
        method: "Get",
        success: function (result) {
            $('#Subject').html(result);
            $('#Subject').css('display', 'inline');
            $('#Subject').next('div').remove();

        },
    });
}

function GetStudingType() {
    $.ajax({
        url: 'Home/GetStudingType',
        method: "Get",
        success: function (result) {
            $('#StudingType').html(result);
            $('#StudingType').css('display', 'inline');
            $('#StudingType').next('div').remove();

        },
    });
}

function GetProductTypes() {
    $.ajax({
        url: 'Home/GetProductTypes',
        method: "Get",
        success: function (result) {
            $('#ProductTypes').html(result);
            $('#ProductTypes').css('display', 'inline');
            $('#ProductTypes').next('div').remove();

        },
    });
}

function getFormValuesFromDiv(divSelector) {
    const values = {};

    $(divSelector).find('input, select, textarea').each(function () {
        const $element = $(this);
        const name = $element.attr('name');

        if (!name) return;

        if ($element.is(':checkbox')) {
            if (!$element.is(':checked')) return;
            if (!values[name]) values[name] = [];
            values[name].push($element.val());
        } else if ($element.is(':radio')) {
            if ($element.is(':checked')) {
                values[name] = $element.val();
            }
        } else if ($element.is('select[multiple]')) {
            values[name] = $element.val() || [];
        } else {
            values[name] = $element.val();
        }
    });

    return values;
}

function freezOrder() {
    if ($('#FormOrder')[0].reportValidity()) {
        $('.orderForm').find('input, textarea').each(function () {
            const $element = $(this);
            $element.attr('disabled', 'disabled');
        });
        $('.orderForm').find('button').each(function () {
            const $element = $(this);
            $element.css('display', 'none');
        });
    }
}

$("#Name").off("input").on("input", GetByFilters);
$("#Thematics").off("input").on("input", GetByFilters);
$("#Series").off("input").on("input", GetByFilters);
$("#WeightFrom").off("input").on("input", GetByFilters);
$("#WeightTo").off("input").on("input", GetByFilters);
$("#PagesFrom").off("input").on("input", GetByFilters);
$("#PagesTo").off("input").on("input", GetByFilters);
$("#PriceTo").off("input").on("input", GetByFilters);
$("#PriceFrom").off("input").on("input", GetByFilters);
$("#Brand").off("change").on("change", GetByFilters);
$("#Genre").off("change").on("change", GetByFilters);
$("#BindingType").off("change").on("change", GetByFilters);
$("#ProductTypes").off("change").on("change", GetByFilters); 
$("#GameType").off("change").on("change", GetByFilters);
$("#Subject").off("change").on("change", GetByFilters);
$("#Sort").off("change").on("change", GetByFilters);
$("#SortWay").off("change").on("change", GetByFilters);
$("#StudingType").off("change").on("change", GetByFilters);
$("#PlayersFrom").off("input").on("input", GetByFilters);
$("#PlayersTo").off("input").on("input", GetByFilters);
$("#ClassFrom").off("input").on("input", GetByFilters);
$("#ClassTo").off("input").on("input", GetByFilters);

$('#WeightFrom, #WeightTo, #PagesFrom, #PagesTo, #PlayersTo, #PlayersFrom, #ClassFrom, #ClassTo').on('keydown', function (e) {
    if (e.key === '.' || e.key === ',' || e.key.toLowerCase() === 'e') {
        e.preventDefault();
    }
});
