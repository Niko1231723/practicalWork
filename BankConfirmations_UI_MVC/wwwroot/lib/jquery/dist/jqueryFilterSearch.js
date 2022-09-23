$(document).ready(function () {
    $("#search").keyup(function () {

        var searchText = $("#search").delay(5000).val().toLowerCase();

        /*$("#search").delay(5000).fadeOut();*/

        //$("#search").fadeOut();

        $.get('https://localhost:7049/api/client/search/' + searchText, function (data) {
            var row = "";
            for (var i = 0; i < data.length; i++) {
                row = row
                    + "<tr>"
                    + "<td>" + data[i].id + "</td>"
                    + "<td>" + data[i].firstName + "</td>"
                    + "<td>" + data[i].lastName + "</td>"
                    + "<td>" + data[i].idNumber + "</td>"
                    + "<td>" + `<a href="https://localhost:7185/Accounts/Select/${data[i].id}" class="btn btn-success">Select</a>` + "</td>"
                    + "</tr>";
            };
            $("#tbody").append(row),
            function () {
                    alert("aa");
            };
        });

        $.get('Accounts/Partial', function (data) {
            $("#tbody").html(data);
        });

        $.ajax({
            URL: 'https://localhost:7049/api/client/search/' + searchText,
            method: 'get',
            dataType: 'json',
            Error: function () {
                alert();
            },
            success: function (data) {
                $(data).each(function (i, client) {
                    $("#tbody").append($("<tr>")
                    .append($("<td>").append(client.firstName)));
                });
            }
        });

        //$.getJSON('https://localhost:7049/api/client/search/' + searchText, function (data) {
        //    $(data).each(function (i, client) {
        //        $('#tbody').append($("<tr>")
        //            .append($("<td>").append(client.id))
        //            .append($("<td>").append(client.firstName))
        //            .append($("<td>").append(client.lastName))
        //            .append($("<td>").append(client.idNumber))
        //            .append($('<a href="https://localhost:7185/Accounts/Select/${data[i].id}" class="btn btn-success">Select</a>'))
        //        );
        //    });
        //})


        .done(function () {
            alert("Completed");
        })
        .fail(function (e) {
            console.log('error:');
            console.error(e);
        })
        .always(function () {
            alert("always runs");
        });
        if (searchText == "") {
            $("#tbody").html("");
        }
    });
});

