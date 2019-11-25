(function ($) {
    $(function () {
        $(".DeleteCustomer").click(function () {
            var id = $(this).attr("id");
            if (confirm('Are you sure you want to delete this person has id: ' + id)) {
                $.ajax({
                    type: 'POST',
                    headers: {
                        "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
                    },
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    url: '/Admin/Customer?handler=DeleteCustomer',
                    data: JSON.stringify({
                        Id: id
                    }),
                    success: function (respone) {
                        alert(respone);
                        location.reload();
                    }
                });
            }
        });

        $(".EditCustomer").click(function () {
            var id = $(this).attr("id");
            $.ajax({
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                url: '/Admin/Customer?handler=EditCustomer',
                data: {
                    id: id
                },
                success: function (result) {
                    $("#EditCustomer-name").val(result.CustomerName);
                    $("#EditCustomer-address").val(result.Address);
                    $("#EditCustomer-id").val(result.CustomerId);

                }
            });
        });
        $("#btsubmitEditCustomer").click(function () {
            var id = $('#EditCustomer-id').val();
            var name = $("#EditCustomer-name").val();
            var address = $("#EditCustomer-address").val();
            event.preventDefault();
            // event.preventDefault() là để ngăn thằng form nó load lại trang ..
            $.ajax({
                type: 'POST',
                headers: {
                    "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
                },
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                url: '/Admin/Customer?handler=EditCustomer',
                data: JSON.stringify({
                    Id: id,
                    CustomerName: name,
                    Address: address
                }),
                success: function (respone) {
                    $('#EditCustomerForm').modal('hide');
                    alert(respone);
                    location.reload();
                },
                failure: function (result) {
                    alert("fail");
                }

            });
        });

    });
})(jQuery);