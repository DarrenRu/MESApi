
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for(var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function postWebApi(actions, dataField){
    $.ajax({
        type: "post",
        url: parent.webApiUrl + actions,
        data: dataField,
        contentType: "application/json",
        error: function(e){
            return JSON.stringify({
                "result": false,
                "data": e
            });
        },
        success: function(e) {
            return JSON.stringify({
                "result": true,
                "data": e
            });
        }
    });
}