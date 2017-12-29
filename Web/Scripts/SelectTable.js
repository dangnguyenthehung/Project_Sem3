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
                getTableAvailable();
            }
        );
    });

    $("#EndTime").change(function () {
        getTableAvailable();
    });

    function getTableAvailable() {
        var url = APICall.GetTableAvailable;

        var begin = $("#BeginTime").val();
        var end = $("#EndTime").val();

        $.get(
            url,
            { beginTime: begin, endTime: end },
            function (data) {

                var listOption = "";
                var index = 1;
                $.each(data,
                    function (key, value) {
                        var countId = "count_group_" + index;
                        var containerId = "group_" + index;
                        var count = value.length;

                        $("#" + countId).html("Table available (" + count + ")");
                        $("#" + containerId).html("");

                        var content = "";

                        $.each(value,
                            function (subkey, subvalue) {
                                content += "<div class='checkbox'><input name= 'ListIdTable' type= 'checkbox' id= '" +
                                    subvalue.IdTable + "' value= '" + subvalue.IdTable + "' /><label for='" +
                                    subvalue.IdTable + "'>Table " + subvalue.TableNumber + "</label></div>";

                                
                            });

                        $("#" + containerId).html(content);
                        index++;
                    });
            }
        );
    };

});
