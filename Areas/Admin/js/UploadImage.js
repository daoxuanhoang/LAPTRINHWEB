function UploadImage() {
    $(".fileImg").on("change", function () {
        let fileData = $(this).prop("files")[0];
        let math = ["image/png", "image/jpg", "image/jpeg"];

        if ($.inArray(fileData.type, math) === -1) {

            $(this).val(null);
            return false;
        }
        let fileReader = new FileReader();
        fileReader.readAsDataURL(fileData);
        let formData = new FormData();
        formData.append("fileImg", fileData);
        $.ajax({
            url: `/Admin/Product/UploadImage`,
            type: "POST",
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            success: function (data) {
                $("#Image").val(data.name);
            }
        })
    })
}

$(document).ready(function () {
    UploadImage();
})