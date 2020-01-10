var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/Product/ChangeStatus",
                data: JSON.stringify({ id: id}),
                dataType: 'json',
                type: 'POST',
                contentType: "application/json;charset=urf-8",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text('Còn hàng');
                    }
                    else {
                        btn.text('Hết hàng');
                    }
                }
            })
        });
    }
}
user.init();