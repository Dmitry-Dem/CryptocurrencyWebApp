// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


/* Views/Home/Converter.cshtml */

$(document).ready(function () {
    $('#convertBtn').click(function () {
        var amount = $('#amount').val();
        var currencyId = $('#searchInputDataSource').val();
        var targetCurrencyId = $('#searchInputDataTarget').val();

        $.ajax({
            url: '/Home/ConvertCurrency',
            type: 'POST',
            data: { currencyId: currencyId, targetCurrencyId: targetCurrencyId, amount: amount },
            success: function (data) {
                $('#result').text(data.result);
            },
            error: function () {
                $('#result').text('Unknown');
            }
        });
    });
});

/* Views/Home/Currencydetails.cshtml -- Chart -- */

