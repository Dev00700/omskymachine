function SendEnquiry() {
    debugger;
    let name = $("#txtname").val();
    let email = $("#txtemail").val();
    let subject = $("#txtsubject").val();
    let message = $("#txtmessage").val();

    if (name == null || name == undefined || name == "") {
        alert("please enter name");
        return false;
    }

    if (email == null || email == undefined || email == "") {
        alert("please enter email");
        return false;
    }

    if (subject == null || subject == undefined || subject == "") {
        alert("please enter subject");
        return false;
    }

    if (message == null || message == undefined || message == "") {
        alert("please enter message");
        return false;
    }
    var formData = new FormData();

    formData.append("Name", name);
    formData.append("Email",email);
    formData.append("Subject", subject);
    formData.append("Message", message);

    $.ajax({
        url: '/Home/SendEnquiry',
        type: 'POST',
        data: formData,
        contentType: false,
        processData: false,
        success: function (res) {
            if (res.success) {
                alert("enquiry send successfully");
                location.reload();
            } else {
                alert(res.message);
            }
        },
        error: function () {
            alert("Something went wrong");
        }
    });
}