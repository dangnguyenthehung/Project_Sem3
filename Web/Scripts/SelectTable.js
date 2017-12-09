﻿var arr = [];
$(document).ready(function () {
    $(".numberOfTable").on("change", function () {
        console.log('changed');
        var type = $(this).data("type");
        var num = $(this).val();

        var obj = { TableType: type, NumberOfTable: num }
        if (arr.length === 0) {
            arr.push(obj);
        } else {

            var i = -1;

            for (var j = 0; j < arr.length; j++) {

                if (arr[j].TableType === type) {
                    i = j;
                    break;
                } 
            }

            if ( i !== -1) {
                arr[i] = obj;
            } else {
                arr.push(obj);
            }
        }
        
    });

    $("#submitSelectTable").click(function() {
        var url = APICall.SelectTable;
        var beginTime = $("#beginTime").val();
        var endTime = $("#endTime").val();
        var orderDate = $("#OrderDate").val();
        var numberOfPeople = $("#numberOfPeople").val();

        $.post(
            url,
            { OrderDate: orderDate, BeginTime: beginTime, EndTime: endTime, NumberOfCustomers: numberOfPeople, ListNumberOfTable: arr },
            function (data) {
            console.log(data);
        });

    });
});
