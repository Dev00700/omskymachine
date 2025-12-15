function login() {
    let username = $("#txtusername").val();
    let password = $("#txtpassword").val();
    if (username == null || username == undefined || username == "") {
        alert("please enter username");
        return false;
    }

    if (password == null || password == undefined || password == "") {
        alert("please enter password");
        return false;
    }
    var model = {
        UserName: username,
        Password: password
    };
    $.ajax({
        url: '/Login/SaveLogin',
        type: 'POST',
        data: model,
        success: function (res) {
            if (res.success) {
                alert("Saved successfully");
                window.location.href = "/Dashboard";
            } else {
                alert(res.message);
            }
        },
        error: function () {
            alert("Something went wrong");
        }
    });
    

}