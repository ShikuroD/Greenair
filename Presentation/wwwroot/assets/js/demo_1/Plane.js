(function ($) {
    $(function () {
        $(".DeletePlane").click(function () {
            var id = $(this).attr("id");
            if (confirm('Are you sure you want to delete this item has id: ' + id)) {
                $.ajax({
                    type: 'POST',
                    headers: {
                        "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
                    },
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    url: '/Admin/Maker?handler=DeletePlane',
                    data: JSON.stringify({
                        PlaneId: id
                    }),
                    success: function (respone) {
                        alert(respone);
                        location.reload();
                    }
                });
            }
        });

        $(".EditPlane").click(function () {
            var id = $(this).attr("id");
            $.ajax({
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                url: '/Admin/Maker?handler=EditPlane',
                data: {
                    id: id
                },
                success: function (result) {
                    $("#EditPlane-id").val(result.PlaneId);
                    $("#EditPlane-seatnum").val(result.SeatNum);
                    $("#EditPlane-default").text(result.MakerId);

                }
            });
        });
        $("#btsubmitEditPlane").click(function () {
            var id = $('#EditPlane-id').val();
            var seatnum = $("#EditPlane-seatnum").val();
            var makerid = $("#EditPlane-makerid").val();
            event.preventDefault();
            // event.preventDefault() là để ngăn thằng form nó load lại trang ..
            $.ajax({
                type: 'POST',
                headers: {
                    "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
                },
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                url: '/Admin/Maker?handler=EditPlane',
                data: JSON.stringify({
                    PlaneId: id,
                    SeatNum: seatnum,
                    MakerId: makerid
                }),
                success: function (respone) {
                    $('#EditPlane').modal('hide');
                    alert(respone);
                    // $("#tablePlane").empty();
                    location.reload();
                    // $('#tablePlane').load("/Admin/Plane" + "  #tablePlane");
                },
                failure: function (result) {
                    alert("fail");
                }

            });
        });

    });
})(jQuery);