function accountLogin(form) {
    $.ajax({
        type: "POST",
        url: parent.webApiUrl + "/account/login",
        contentType: "application/json;charset=utf-8",
        async: false,
        data: JSON.stringify({
            "username": form.inputEmail.value,
            "password": form.inputPassword.value
        }),
        success: function (result) {
            alert(result.token);
            parent.setCookie("login", result.login);
            parent.setCookie("id", result.id);
            parent.setCookie("name", result.name);
            parent.setCookie("type", result.type);
            parent.setCookie("token", result.token);
            form.reset();
            top.location.reload();
        }
    });
}