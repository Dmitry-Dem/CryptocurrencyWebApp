// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


/* Views/Home/Index.cshtml */
$(document).ready(function () {
    var currentPage = 1;
    var currencyList = document.getElementById("CurrencyList");

    $('#NextCurrenciesPage').on('click', function () {
        $.ajax({
            url: '/Home/GetCurrenciesByPageNum',
            type: 'GET',
            data: { pageNum: ++currentPage },
            dataType: 'json',
            success: function (data) {
                for (var i = 0; i < data.length; i++) {
                    var currency = data[i];

                    var row = `
                        <tr>
                            <td>${currency.rank}</td>
                            <td><img src="${currency.imageUrl}" class="table-image"></td>
                            <td><a class="table_link" href="/Home/CurrencyDetails/${currency.id}">${currency.name}</a></td>
                            <td>${currency.symbol}</td>
                            <td>${currency.price}</td>
                            <td><a class="btn btn-primary" href="/Home/CurrencyDetails/${currency.id}">Open</a></td>
                        </tr>
                    `;

                    currencyList.innerHTML += row;
                }
            },
            error: function (error) {
                alert('Error fetching data:', error);
            }
        });
    });
});

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

