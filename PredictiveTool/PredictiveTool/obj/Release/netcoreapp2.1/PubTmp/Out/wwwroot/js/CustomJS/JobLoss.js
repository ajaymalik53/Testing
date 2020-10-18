$("#ddlSectorID").change(function () {
    $("button").removeClass("clickclass");
    $("#hdntab").val('');
    tabID = $("#hdntab").val();
    $("#hdntab").val('');
    $("button").removeClass("clickclass");
    from = $("#dtidfrom").val();
    to = $("#dtidto").val();
    getdate('', tabID, from, to);

});

$(".Cbox").click(function () {
    if (this.id == 'chkdataID') {
        if ($(this).is(":checked")) {
            $("#tblData").show();
        } else {
            $("#tblData").hide();
        }
    }
    else {
        if ($(this).is(":checked")) {
            $("#divchartID").show();
        } else {
            $("#divchartID").hide();
        }
    }
});

function tabClick(control) {

    $('#ddlSectorID').prop('selectedIndex', 0);
    tabID = control.id;
    $("#hdntab").val(tabID);
    $("button").removeClass("clickclass");
    $(control).addClass('clickclass');
    from = $("#dtidfrom").val();
    to = $("#dtidto").val();
    getdate('', tabID, from, to);
}
function submitclick() {
    tabID = $("#hdntab").val();
    from = $("#dtidfrom").val();
    to = $("#dtidto").val();
    SecID = $("#ddlSectorID").val();
    getdate(SecID, tabID, from, to);
}

$("ul.nav-tabs a").click(function (e) {
    e.preventDefault();
    $(this).tab('show');
});
// string from = "", string To = ""
function getdate(SecID, tabID, from, to) {
    SecID = $('#ddlSectorID').val();
    var URL = 'DashBoardPredective/getChartandTableData/';  ///'@Url.Action("getChartandTableData","DashBoardPredective")';
    $.ajax({
        type: "GET",
        url: URL,
        data: { 'SecID': SecID, 'tabID': tabID, 'type': 1, 'from': from, 'to': to },
        contentType: "application/json",
        dataType: "json",
        success: function (result) {

            $('#tblData').empty();
            $('#container').empty();
            if ($("#chkdataID").is(":checked"))
                draw_a_table_from_json(result.table, Object.keys(result.table[0]), Object.keys(result.table[0]), '#tblData');
            //var keys = Object.keys(result);
            if ($("#chkgpID").is(":checked")) {
                var cat = new Array();
                var catData = new Array();
                var col1 = [];
                var col2 = [];
                var col3 = [];
                var col4 = [];
                //var totalspent = 0.0;
                for (var i = 0; i < result.table1.length; i++) {
                    col1.push([result.table1[i].year, result.table1[i][Object.keys(result.table1[i])[1]]]);
                    col2.push([result.table1[i].year, result.table1[i][Object.keys(result.table1[i])[2]]]);
                    col3.push([result.table1[i].year, result.table1[i][Object.keys(result.table1[i])[3]]]);
                    //col4.push([result[i].year, result[i].mqf]);
                    //arrLN.push(result[i].mq);
                    //totalspent += result[keys[i]];
                    //cat.push(arrL);
                    //catData.push(arrLN);
                    //catData.push(arrL, arrLN)
                }
                custlbl = [];
                debugger;
                Object.keys(col1).forEach(function (key) {
                    var value = col1[key];
                    custlbl.push(value[0]);
                    // ...
                });
                var asasa = catData;
                debugger;
                if (tabID != "")
                    createCharts(custlbl,col1, col2, col3, col4, Object.keys(result.table1[0])[1], Object.keys(result.table1[0])[2], Object.keys(result.table1[0])[3], result.table2[0].title, Object.keys(result.table[0])[0], Object.keys(result.table[0])[Object.keys(result.table[0]).length - 2]);
                else
                    createChartssingle(custlbl,col1, col2, col3, col4, Object.keys(result.table1[0])[1], Object.keys(result.table1[0])[2], Object.keys(result.table1[0])[3], result.table2[0].title, Object.keys(result.table[0])[0], Object.keys(result.table[0])[Object.keys(result.table[0]).length - 2]);
            }
        }
    });
}

function BinDDN() {
    $.ajax({
        type: "GET",
        url: "/DashBoardPredective/BindDropDown",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {

        }
    });
}


function createCharts(custlbl,col1, col2, col3, col4, col1N, col2N, col3N, Title, firstD, lastD) {
    Highcharts.chart('container', {
        credits: {
            enabled: false
        },

        title: {
            text: Title + ',' + firstD + '-' + lastD
        },

        subtitle: {
            text: ''
        },
        xAxis: {
            categories: custlbl,
            labels: {
                align: 'left',
                reserveSpace: true
            }
        },
        yAxis: [{
            title: {
                text: 'Primary Axis'
            }
        }, {
            title: {
                text: 'Secondary Axis'
            },
            gridLineWidth: 0,
            opposite: true
        }],

        //yAxis: {
        //    title: {
        //        text: ''
        //    }
        //},
        legend: {
            align: 'center',
            verticalAlign: 'bottom'

        },

        //plotOptions: {
        //    series: {
        //        label: {
        //            connectorAllowed: false
        //        },
        //        pointStart: 2010
        //    }
        //},

        series: [{
            name: col1N,
            data: col1,
            color: '#359862',
            yAxis: 1
        },
        {
            name: col2N,
            data: col2,
            color: '#fa7c28'
        },
        {
            name: col3N,
            data: col3,
            //dashStyle: 'longdash',
            color: '#8db5de'

        }

        ]
    });
}


function createChartssingle(custlbl,col1, col2, col3, col4, col1N, col2N, col3N, Title, firstD, lastD) {
    Highcharts.chart('container', {
        credits: {
            enabled: false
        },

        title: {
            text: Title + ',' + firstD + '-' + lastD
        },

        subtitle: {
            text: ''
        },
        xAxis: {
            categories: custlbl,
            labels: {
                align: 'left',
                reserveSpace: true
            }
        },


        yAxis: [{
            title: {
                text: 'Primary Axis'
            }
        }, {
            title: {
                text: 'Secondary Axis'
            },
            gridLineWidth: 0,
            opposite: true
        }],

        //yAxis: {
        //    title: {
        //        text: ''
        //    }
        //},
        legend: {
            align: 'center',
            verticalAlign: 'bottom'

        },

        //plotOptions: {
        //    series: {
        //        label: {
        //            connectorAllowed: false
        //        },
        //        pointStart: 2010
        //    }
        //},

        series: [{
            name: col1N,
            data: col1,
            color: '#359862',
            yAxis: 1
        }
        ]
    });
}
document.addEventListener('DOMContentLoaded', function () {
    getdate();
    //var myChart = Highcharts.chart('container', {
    //    chart: {
    //        type: 'bar'
    //    },
    //    title: {
    //        text: 'Fruit Consumption'
    //    },
    //    xAxis: {
    //        categories: ['Apples', 'Bananas', 'Oranges']
    //    },
    //    yAxis: {
    //        title: {
    //            text: 'Fruit eaten'
    //        }
    //    },
    //    series: [{
    //        name: 'Jane',
    //        data: [1, 0, 4]
    //    }, {
    //        name: 'John',
    //        data: [5, 7, 3]
    //    }]
    //});
});
function draw_a_table_from_json(json_data_array, head_array, item_array, destinaion_element) {

    var table = '<table class="table table-bordered">';
    //TH Loop
    table += '<tr>';
    $.each(head_array, function (head_array_key, head_array_value) {
        table += '<th>' + head_array_value + '</th>';
    });
    table += '</tr>';
    //TR loop
    $.each(json_data_array, function (key, value) {

        table += '<tr>';
        //TD loop
        $.each(item_array, function (item_key, item_value) {
            table += '<td>' + value[item_value] + '</td>';
        });
        table += '</tr>';
    });
    table += '</table>';

    $(destinaion_element).append(table);
}
function FilterData() {

    $('#tblbodyID').html("");
    var datapaging = $.parseJSON($("#hdnData").val());
    if ($("#hdnData").val().indexOf("INVOICENO") >= 0) {
        for (var i = 0; i < datapaging.length; i++) {
            $("#tblbodyID").append('<tr><td>' + datapaging[i].INVOICENO +
                '</td><td>' + datapaging[i].DATE_OF_SHIPMENT_VESSEL_SAILING_DATE +
                '</td><td>' + datapaging[i].COUNTRY_OF_FINAL_DESTINATION +
                '</td><td>' + datapaging[i].NAME_AND_ADDRESS_OF_THE_BUYER +
                '</td><td>' + datapaging[i].COMMODITY +
                '</td><td>' + datapaging[i].TERMS_OF_PAYMENT +
                '</td><td>' + datapaging[i].Total +
                '</td><td>' + datapaging[i].PREMIUM_RATE +
                '</td><td>' + datapaging[i].AMOUNT_IN_RUPEES +

                '</td></tr>'
            );
        }
    }
    $("#tblID").DataTable();

    // $('#tblbodyID').html("");ID, BU, CustomerIDH,Buyer,Qty,cast(MaterialAvailabilityDate as Date) as MaterialAvailabilityDate ,SalesOrderNo,PONo , SysOrderNumber
}
//$(document).ready(function () {
//$("ul").on("click", "li", function () {
//    $('ul li').removeAttr('clickclass');
//    $(this).addClass('clickclass');
//});
//});

//$(document).ready(function () {
//    $('.menu li a').click(function () {
//        debugger;
//        $(this).parent().addClass('menuclickclass').siblings().removeClass('menuclickclass');
//    });

//});

