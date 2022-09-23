$(document).ready(function () {
    getClient();

    $("#search").keyup(function () {
        var searchtext = $("#search").val().toLowerCase();

        var row = document.getElementById("tbody").children;

        $(row).each(function () {
            if (!Contains($(this).text().toLowerCase(), searchtext)) {
                $(this).hide();
            }
            else {
                $(this).show();
            }
        });

        //$("#tbody").each(function () {
        //    if (!Contains($(this).text().toLowerCase(), searchtext)) {
        //        $(this).hide();
        //    }
        //    else {
        //        $(this).show();
        //    }
        //});
    });

});

function Contains(text_one, text_two) {
    if (text_one.indexOf(text_two) != -1)
        return true;
}

function getClient() {
    $.get("https://localhost:7049/api/client", function (data) {
        //if (data) {
            var row = "";
            //var anchor = document.createElement("a");
            for (var i = 0; i < data.length; i++) {
                row = row
                    + "<tr>"
                    + "<td>" + data[i].id + "</td>"
                    + "<td>" + data[i].firstName + "</td>"
                    + "<td>" + data[i].lastName + "</td>"
                    + "<td>" + data[i].idNumber + "</td>"
                    //+ "<td>" + anchor + "</td>"
                    + "<td>" + `<a href="https://localhost:7185/Accounts/Select/${data[i].id}" class="btn btn-success">Select</a>` + "</td>"
                    + "</tr>";
                //anchor.setAttribute("class", "btn btn-success");
                //anchor.setAttribute("asp-action", "select");
                //anchor.setAttribute("asp-route-id", data[i].id);
                //anchor.innerText = "Select";
            };
            $("#tbody").append(row);
        //}
    });
}