function AddBlog() {
    let title = $("#txttitle").val();
    let desc = $("#txtdesc").val();
    let link = $("#txtlink").val();
    if (title == null || title == undefined || title == "") {
        alert("please enter title");
        return false;
    }

    if (desc == null || desc == undefined || desc == "") {
        alert("please enter desc");
        return false;
    }

    if (link == null || link == undefined || link == "") {
        alert("please enter link");
        return false;
    }
    let isActive = $("#chkisactive").is(":checked");

    let blogguid = $("#txthiddenguid").val();

    var formData = new FormData();

    formData.append("Title", title);
    formData.append("Description", desc);
    formData.append("Link", link);
    formData.append("BlogGuid", blogguid ?? null);
    formData.append("IsActive", isActive);

    var files = document.getElementById("txtfile").files;
    for (var i = 0; i < files.length; i++) {
        formData.append("images", files[i]);
    }


    $.ajax({
        url: '/CreateBlog/SaveBlog',
        type: 'POST',
        data: formData,
        contentType: false,
        processData: false,
        success: function (res) {
            if (res.success) {
                alert("Saved successfully");
                window.location.href = "/Blog";
            } else {
                alert(res.message);
            }
        },
        error: function () {
            alert("Something went wrong");
        }
    });

}