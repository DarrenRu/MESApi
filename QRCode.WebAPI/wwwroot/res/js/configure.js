var webApiUrl = "http://localhost:49705";

function setCookie(cookieName, cookieValue) {
    document.cookie = cookieName + "=" + cookieValue + ";path=/";
}

function getCookie(cookieName) {
    var name = cookieName + "=";
    var cookieDecode = decodeURIComponent(document.cookie);
    var cookieItem = cookieDecode.split(';');
    for (var i = 0; i < cookieItem.length; i++) {
        var item = cookieItem[i];
        while (item.charAt(0) === ' ') {
            item = item.substring(1);
        }
        if (item.indexOf(name) === 0) {
            return item.substring(name.length, item.length);
        }
    }
    return "";
}