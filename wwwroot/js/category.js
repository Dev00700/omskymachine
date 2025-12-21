function AddCategory() {
    let categoryname = $("#txtcatname").val();
    if (categoryname == null || categoryname == undefined || categoryname == "") {
        alert("please enter category name");
        return false;
    }

    let isActive = $("#chkisactive").is(":checked");

    let categoryguid = $("#txthiddenguid").val();

    var formData = new FormData();

    formData.append("CategoryName", categoryname);
    formData.append("CategoryGuid", categoryguid ?? null);
    formData.append("IsActive", isActive);

    var files = document.getElementById("txtfile").files;
    for (var i = 0; i < files.length; i++) {
        formData.append("images", files[i]); 
    }
  
    
    $.ajax({
        url: '/CreateCategory/SaveCategory',
        type: 'POST',
        data: formData,
        contentType: false,   
        processData: false,   
        success: function (res) {
            if (res.success) {
                alert("Saved successfully");
                window.location.href = "/Category";
            } else {
                alert(res.message);
            }
        },
        error: function () {
            alert("Something went wrong");
        }
    });

}