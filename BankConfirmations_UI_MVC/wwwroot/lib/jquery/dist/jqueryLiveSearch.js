$(document).ready(function () {
    $("#search").keyup(function () {
        $("#result").html("");
        var search = $("#search").val();
        var expression = new RegExp(search, "i");
        $.get("https://localhost:7049/api/client", function (data) {
            $.each(data, function (key, value) {
                if (value.firstName.search(expression) != -1 || value.lastName.search(expression) != -1 || value.idNumber.search(expression) != -1)
                {
                    $("#result").append("<li>" + value.firstName + " " + value.lastName + " " + value.idNumber + "</li>");
                    if (search=="") {
                        $("#result").html("");
                    }
                }
            });
        });
    });
});