// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    let sort;
    let filter;
    if (getCookie("city") == undefined) {
        $('#staticBackdrop').modal('show');
    }
    else {
        $('#citiesMenu').val(getCookie("city"))
    }

    $('.btn-sort').click(function () {
        sort = $(this).val()
        $.ajax({
            type: "GET",
            url: "Home/Sort", // "{Controller}/{ActionMethod}"
            data: {
                'sort': sort,
                'filter': filter
            },
            success: function (response) {
                $('#products').html(response)
            }
        });
    })

    $('.btn-filter').click(function () {
        filter = $(this).val()
        $.ajax({
            type: "GET",
            url: "Home/Sort", 
            data: {
                'sort': sort,
                'filter': filter
            },
            success: function (response) {
                $('#products').html(response)
            }
        });
    })

    $('.btn-city').click(function () {
        let city = $(this).val().trim()
        $('#citiesMenu').val(city)
        document.cookie = "city="+city
    })

    $('.btn-basket').click(function () {
        let elem = $(this);
        $.ajax({
            type: "POST",
            url: "Home/AddToBasket",
            data: {
                'id': $(this).attr('data-id')
            },
            success: function (response) {
                $('#basketCount').text(response);
                elem.addClass('d-none');
                elem.next().removeClass('d-none');

            }
        });
    })
    $('.btn-plus').click(function () {
        let conuter = $(this).parent().children('p');
        let price = $(this).parent().parent().parent().children('div').children('p.price');
        let elem = $(this);
        $.ajax({
            type: "POST",
            url: "ChangeCntr",
            dataType: "JSON",
            data: {
                'id': elem.attr('data-id'),
                'change': 'plus'
            },
            success: function (response) {
                conuter.text(response['count']);
                price.text(response['price'] + ' P');
                $('#totalPrice').text(response['totalPrice']);
            }
        });
    })
    $('.btn-minus').click(function () {
        let conuter = $(this).parent().children('p');
        let price = $(this).parent().parent().parent().children('div').children('p.price');
        let elem = $(this);
        $.ajax({
            type: "POST",
            url: "ChangeCntr",
            dataType: "JSON",
            data: {
                'id': elem.attr('data-id'),
                'change': 'minus'
            },
            success: function (response) {
                conuter.text(response['count']);
                price.text(response['price'] + ' P');
                $('#totalPrice').text(response['totalPrice']);
            }
        });
    })
    $('#finishOrdersButton').click(function () {
        $.ajax({
            type: "POST",
            url: "FinishOrder",
            success: function (response) {
            }
        });

    })
});

function getCookie(name) {
    let matches = document.cookie.match(new RegExp(
        "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
}

