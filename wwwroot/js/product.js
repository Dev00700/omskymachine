function AddProduct() {
    let productname = $("#txtprdname").val();
    let shortdescription = $("#txtprdshortdesc").val();
    let categoryId = $("#ddlcategory").val();
    let productdesc = CKEDITOR.instances.txtprddesc.getData();

    if (categoryId == null || categoryId == undefined || categoryId == "" || categoryId == 0) {
        alert("please select Category");
        return false;
    }

    if (productname == null || productname == undefined || productname == "") {
        alert("please enter product name");
        return false;
    }
    if (productdesc == null || productdesc == undefined || productdesc == "") {
        alert("please enter Description");
        return false;
    }
    if (shortdescription == null || shortdescription == undefined || shortdescription == "") {
        alert("please enter short description");
        return false;
    }
   

    let isActive = $("#chkisactive").is(":checked");
    let isshowonweb = $("#chkIsShowOnWeb").is(":checked");

    let productguid = $("#txthiddenguid").val() ?? null;

    var formData = new FormData();

    formData.append("CategoryId", categoryId);
    formData.append("ProductName", productname);
    formData.append("ShortDescription", shortdescription.trim());
    formData.append("Description", productdesc.trim());
    formData.append("ProductGuid", productguid);
    formData.append("IsActive", isActive);
    formData.append("IsShowOnWeb", isshowonweb);
    

    var files = document.getElementById("txtfile").files;
    for (var i = 0; i < files.length; i++) {
        formData.append("images", files[i]);
    }


    $.ajax({
        url: '/CreateProduct/SaveProduct',
        type: 'POST',
        data: formData,
        contentType: false,
        processData: false,
        success: function (res) {
            if (res.success) {
                alert("Saved successfully");
                window.location.href = "/Product";
            } else {
                alert(res.message);
            }
        },
        error: function () {
            alert("Something went wrong");
        }
    });

}

function deleteimage(productImageGuid) {

    if (!confirm("Are you sure you want to delete this image?")) {
        return;
    }

    $.ajax({
        url: '/CreateProduct/DeleteImage',
        type: 'POST',
        data: { productImageGuid: productImageGuid },
        success: function (response) {
            if (response.success) {
                alert("Image deleted successfully");
                location.reload();
            } else {
                alert(response.message);
            }
        },
        error: function () {
            alert("Something went wrong while deleting image");
        }
    });
}
