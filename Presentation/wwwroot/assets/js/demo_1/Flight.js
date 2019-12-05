(function ($) {
    $(function () { //đâu cái chỗ nào ajax
        $(".DeleteFlight").click(function () {
            var id = $(this).attr("id");
            if (confirm('Are you sure you want to delete this flight has id: ' + id)) {
                $.ajax({
                    type: 'POST',
                    headers: {
                        "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
                    },
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    url: '/Admin/Flight?handler=DeleteFlight',
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
        $(".DetailFlight").click(function () {
            var id = $(this).attr("id");
            // alert("Id1 " + id);
            $.ajax({
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                url: '/Admin/Flight?handler=DetailFlight',
                data: {
                    id: id
                },
                success: function (result) {
                    // alert("Id2 " + result.FlightId);
                    $("#DetailFlight-planeid").text(result.flight.planeId);
                    $("#DetailFlight-flightid").text(result.flight.flightId);
                    $("#DetailFlight-status").text(result.flight.status);
                    // alert(result.listFlight[0].flightId); //còn lại của m
                    var s = "<hr>";
                    for (item of result.listFlight) {
                        s += `<div class"row">`;

                        s += `<div class="form-group row">`;
                        s += ` <label class="col-sm-2 col-form-label">Detail ID:</label><div class="col-sm-2">`;
                        s += `<span>` + item.flightDetailId + `</span></div>`;
                        s += ` <label class="col-sm-2 col-form-label">Departure Date:</label><div class="col-sm-2">`;
                        s += `<span>` + item.depDate + `</span></div>`;
                        s += ` <label class="col-sm-2 col-form-label">Arrive Date:</label><div class="col-sm-2">`;
                        s += `<span>` + item.arrDate + `</span></div>`;
                        s += `</div>`;

                        s += `<div class="form-group row">`;
                        s += ` <label class="col-sm-2 col-form-label">Route ID:</label><div class="col-sm-2">`;
                        s += `<span>` + item.routeId + `</span></div>`;
                        s += ` <label class="col-sm-2 col-form-label">Origin:</label><div class="col-sm-2">`;
                        s += `<span>` + item.originAirport + ` (` + item.originCountry + `)` + `</span></div>`;
                        s += ` <label class="col-sm-2 col-form-label">Destination:</label><div class="col-sm-2">`;
                        s += `<span>` + item.desAirport + ` (` + item.desCountry + `)` + `</span></div>`;
                        s += `</div>`;

                        s += `</div><hr>`;
                    }
                    $("#DetailFlight-context").html(s);
                }
            });
        });
        // $(".EditFlight").click(function () {
        //     var id = $(this).attr("id");
        //     $.ajax({
        //         type: 'GET',
        //         dataType: 'json',
        //         contentType: 'application/json; charset=utf-8',
        //         url: '/Admin/Flight?handler=EditFlight',
        //         data: {
        //             id: id
        //         },
        //         success: function (result) {
        //             // alert("Id2 " + result.Id);
        //             $("#EditFlightLock-id").val(result.Id);
        //             $("#EditFlightUnlock-id").val(result.Id);
        //         }
        //     });
        // });
        // $("#btsubmitEditFlightLock").click(function () {
        //     var id = $('#EditFlight-id').val();
        //     event.preventDefault();
        //     // event.preventDefault() là để ngăn thằng form nó load lại trang ..
        //     $.ajax({
        //         type: 'POST',
        //         headers: {
        //             "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        //         },
        //         dataType: 'json',
        //         contentType: 'application/json; charset=utf-8',
        //         url: '/Admin/Flight?handler=EditFlightLock',
        //         data: JSON.stringify({
        //             Id: id
        //         }),
        //         success: function (respone) {
        //             alert("Disabled success");
        //             location.reload();
        //         },
        //         failure: function (result) {
        //             alert("fail");
        //         }

        //     });
        // });
        // $("#btsubmitEditFlightUnlock").click(function () {
        //     var id = $('#EditFlight-id').val();
        //     event.preventDefault();
        //     // event.preventDefault() là để ngăn thằng form nó load lại trang ..
        //     $.ajax({
        //         type: 'POST',
        //         headers: {
        //             "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        //         },
        //         dataType: 'json',
        //         contentType: 'application/json; charset=utf-8',
        //         url: '/Admin/Flight?handler=EditFlightUnlock',
        //         data: JSON.stringify({
        //             Id: id
        //         }),
        //         success: function (respone) {
        //             alert("Active success");
        //             location.reload();
        //         },
        //         failure: function (result) {
        //             alert("fail");
        //         }

        //     });
        // });
        // $("#btsubmitSearchFlight").click(function () {
        //     var search = $('#SearchFlight').val();
        //     event.preventDefault();
        //     // event.preventDefault() là để ngăn thằng form nó load lại trang ..
        //     $.ajax({
        //         type: 'POST',
        //         headers: {
        //             "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        //         },
        //         dataType: 'json',
        //         contentType: 'application/json; charset=utf-8',
        //         url: '/Admin/Flight?handler=EditFlight',
        //         data: {
        //             searchString: search
        //         },
        //         success: function (respone) {
        //             location.reload();
        //         },
        //         failure: function (result) {
        //             alert("fail");
        //         }

        //     });
        // });

    });
})(jQuery);