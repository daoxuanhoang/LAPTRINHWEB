function UploadTempImage() {
    var formData = new FormData();
    formData.append('file', $('#flImage')[0].files[0]);
    $.ajax({
        type: 'post',
        url: '/TestImage/SaveToTemp',
        data: formData,
        success: function (response) {
            if (response != null) {
                var my_path = "/temp/" + response;
                var image = '<img src="' + my_path + '" alt="image" style="width:150px">';
                $("#imgPreview").append(image);
            }
        },
        processData: false,
        contentType: false,
        error: function () {
            alert("Whoops something went wrong!");
        }
    });
}

function Upload() {

    $.ajax({
        type: 'get',
        url: '/TestImage/SaveToMainFolder',
        success: function (response) {
            if (response != null) {
                alert(response);
            }
        },

    });
}