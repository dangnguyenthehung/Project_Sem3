var arr = [];
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

    $("#datepicker").change(function() {
        getTableAvailableAdmin();
    });

    $("#BeginTime").change(function () {
        var url = APICall.GetEndTime;
        var begin = $("#BeginTime").val();

        $.get(
            url,
            { beginTime: begin },
            function (data) {

                $("#EndTime").html();
                var listOption = "";

                $.each(data,
                    function (key, value) {
                        listOption += "<option value=" + value + ">" + value + "</option>";
                    });

                $("#EndTime").html(listOption);
                getTableAvailableAdmin();
            }
        );
    });

    $("#EndTime").change(function () {
        getTableAvailableAdmin();
    });
    
    function getTableAvailableAdmin() {
        var url = APICall.GetTableAvailableAdmin;
        
        var idBranch = $("#idBranch").val();
        var date = $("#datepicker").val();
        var begin = $("#BeginTime").val();
        var end = $("#EndTime").val();

        $.get(
            url,
            { idBranch: idBranch, date: date,  beginTime: begin, endTime: end },
            function (data) {

                var listOption = "";
                var index = 1;
                $.each(data,
                    function (key, value) {
                        var countId = "count_group_" + index;
                        var containerId = "group_" + index;
                        var count = value.length;

                        $("#" + countId).html("Available (" + count + ")");
                        $("#" + containerId).html("");

                        var content = "";

                        $.each(value,
                            function (subkey, subvalue) {
                                content += "<div><label>Table " + subvalue.TableNumber + "</label></div>";


                            });

                        $("#" + containerId).html(content);
                        index++;
                    });
            }
        );
    };

});
