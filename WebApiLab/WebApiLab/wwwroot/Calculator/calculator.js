$(document).ready(function () {
    $("#calculatorbutton").click(function () {

    var number = "number=" + $("number").val();

        $.ajax({
                url: "/api/Calculator/Square",
                data: number,
                method: "GET"
        })
        .done(function(result) {
            var doneMessage = result.statusText;
            alert(doneMessage);
        })
        .fail(function(xhr, status, error) {


        });
    });

});
