function ajaxCall(url, type, data, successCallBack) {
    if (type.toLowerCase() == "post") {
        $.ajax({
            url: url,
            dataType: "json",
            type: type,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            success: function (result) {
                successCallBack(result);
            },
            error: function (jqXHR, textstatus, errorThrown) {
                showAlert('text status ' + textstatus + ', err ' + errorThrown);
            }
        });
    }
    else {
        $.ajax({
            url: url,
            dataType: "json",
            cache: false,
            type: type,
            contentType: "application/json; charset=utf-8",
            //data: JSON.stringify(data),
            success: function (result) {
                successCallBack(result);
            },
            error: function (jqXHR, textstatus, errorThrown) {
                showAlert('text status ' + textstatus + ', err ' + errorThrown);
            }
        });
    }
}

function showAlert(strMsg) {
    $("#divAlert .modal-body").html(strMsg);
    $("#divAlert").modal('show')
}