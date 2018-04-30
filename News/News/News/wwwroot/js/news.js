$("#seedbutton").click(function () {
    $.ajax({
        url: '/api/news/seed',
        method: 'POST'
        //data: {
        //    number: numberFromInputBox
        //}
    })
    .done(function (result) {
        alert(`Success: ${result}`);
        console.log("Success", result);
    })
    .fail(function (xhr, status, error) {
        alert(`Error! ${xhr.responseText}`);
        console.log("xhr", xhr);
        console.log("status", status);
        console.log("error", error);
    });
});

$("#countbutton").click(function () {
    $.ajax({
        url: '/api/news/count',
        method: 'GET'
        //data: {
        //    number: numberFromInputBox
        //}
    })
    .done(function (result) {
        alert(`Success: ${result}`);
        console.log("Success", result);
    })
    .fail(function (xhr, status, error) {
        alert(`Error! ${xhr.responseText}`);
        console.log("xhr", xhr);
        console.log("status", status);
        console.log("error", error);
    });
});

//$("#showallbutton").click(function () {
//    $.ajax({
//        url: '/api/news/showall',
//        method: 'GET'
//    })
//    .done(function (result) {
//        $.getJSON(result);
//        console.log("Success", result);
//    })
//    .fail(function (xhr, status, error) {
//        alert(`Error! ${xhr.responseText}`);
//        console.log("xhr", xhr);
//        console.log("status", status);
//        console.log("error", error);
//    });
//});

$("#addbutton").click(function () {
    var title = $("#title").val();
    var header = $("#header").val();
    var body = $("#body").val();

    $.ajax({
        url: '/api/news/add',
        method: 'POST',
        data: {
            title: title,
            header: header,
            body: body
        }
    })
    .done(function (result) {
        alert(`Success: ${result}`);
        console.log("Success", result);
    })
    .fail(function (xhr, status, error) {
        alert(`Error! ${xhr.responseText}`);
        console.log("xhr", xhr);
        console.log("status", status);
        console.log("error", error);
    });
});

$("#removebutton").click(function () {
    var id = $("#remove").val();

    $.ajax({
            url: '/api/news/remove',
            method: 'POST',
            data: {
                id: id
            }
        })
        .done(function (result) {
            alert(`Success: ${result}`);
            console.log("Success", result);
        })
        .fail(function (xhr, status, error) {
            alert(`Error! ${xhr.responseText}`);
            console.log("xhr", xhr);
            console.log("status", status);
            console.log("error", error);
        });
});

$("#updatebutton").click(function () {
    var updateid = $("#updateid").val();
    var updatetitle = $("#updatetitle").val();
    var updateheader = $("#updateheader").val();
    var updatebody = $("#updatebody").val();

    $.ajax({
        url: '/api/news/update',
        method: 'POST',
        data: {
            id: updateid,
            title: updatetitle,
            header: updateheader,
            body: updatebody
        }
    })
    .done(function (result) {
        alert(`Success: ${result}`);
        console.log("Success", result);
    })
    .fail(function (xhr, status, error) {
        alert(`Error! ${xhr.responseText}`);
        console.log("xhr", xhr);
        console.log("status", status);
        console.log("error", error);
    });
});


