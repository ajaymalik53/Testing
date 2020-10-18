$(function () {

    bindYears();
    $("#ddlYears").val(new Date().getFullYear());
});

$("#ddlSectorID").change(function () {
    
    $("#hdnsecname").val('');
    $("#hdnsecname").val($("#ddlSectorID  option:selected").text());
    $("button").removeClass("clickclass");
    $("#hdntab").val('');
    tabID = $("#hdntab").val();
    $("#hdntab").val('');
    $("button").removeClass("clickclass");
    from = $("#dtidfrom").val();
    to = $("#dtidto").val();
    getdate('', tabID, from, to, "onlysector");
    $("#ddlYears").val(new Date().getFullYear());

});

$("#ddlYears").change(function () {
    getmapdata("","","","","");

});

function YearlyFilter(control) {

    $("#hdnYearly").val("onlychart");
    to = "";
    var today = new Date();
    //var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    var from = today.getFullYear() + '-01-01';
    if (control.id == "btn1y")
        to = today.getFullYear() +3;
    else if (control.id == "btn3y")
        to = today.getFullYear() + 5;
    else
        to = today.getFullYear() + 10;

    tonew = to + '-01-01';
    //2020-01-01
    tabID = $("#hdntab").val();
    from = from;
    to = tonew;
    SecID = $("#ddlSectorID").val();
    if (SecID != "" && SecID != undefined)
        getdate(SecID, tabID, from, to, "onlysector");
    else
        getdate(SecID, tabID, from, to, "ChartData");
}


$("#btnAllID").click(function () {
    $('#ddlSectorID').prop('selectedIndex', 0);

    getAllData();
    $("#hdntab").val('1111');
});
$(function () {
    $("#divdataID").hide();
    $("#divgraphID").hide();

});



function getimgURL() {
    var svgString = new XMLSerializer().serializeToString(document.querySelector('svg'));

    var canvas = document.getElementById("canvas");
    var ctx = canvas.getContext("2d");
    var DOMURL = self.URL || self.webkitURL || self;
    var img = new Image();
    var svg = new Blob([svgString], { type: "image/svg+xml;charset=utf-8" });
    var url = DOMURL.createObjectURL(svg);
    //img.onload = function () {
    //    ctx.drawImage(img, 0, 0);
    //    var png = canvas.toDataURL("image/png");
    //    document.querySelector('#pngcontainer').innerHTML = '<img src="' + png + '"/>';
    //    DOMURL.revokeObjectURL(png);
    //};
    img.src = url;
    return url;
}
function exportHTML(intable, htmlval, filename, sectorname) {

    var header = "<html xmlns:o='urn:schemas-microsoft-com:office:office' " +
        "xmlns:w='urn:schemas-microsoft-com:office:word' " +
        "xmlns='http://www.w3.org/TR/REC-html40'>" +
        "<head><meta charset='utf-8'><title>Export HTML to Word Document with JavaScript</title></head><body>";
    var footer = "</body></html>";
    document.querySelector('#pngcontainer').innerHTML = '';
    document.querySelector('#pngcontainer').innerHTML = '<div><img src="' + imgdata + '" /></div><div style="margin-top:2pt"><span style="font-size:25pt" >' + $("#hdnsecname").val() + '</span></div><br/><br/><div style="margin-top:200pt" ><br><br/><br><br/> <img style="margin-top:100pt" src="' + intable + '"></img></div><div style="margin-top:60%" id="divtblID"></div>';
    document.querySelector('#divtblID').innerHTML = htmlval;
    var sourceHTML = header + document.getElementById("pngcontainer").innerHTML + footer;

    var source = 'data:application/vnd.ms-word;charset=utf-8,' + encodeURIComponent(sourceHTML);
    var fileDownload = document.createElement("a");
    document.body.appendChild(fileDownload);
    fileDownload.href = source;
    fileDownload.download = 'document.doc';
    fileDownload.click();
    document.body.removeChild(fileDownload);
}

function downloadPDF() {

    $("#tblData table").tableHTMLExport({
        // csv, txt, json, pdf
        type: 'pdf',
        orientation: 'p',

        // file name
        filename: 'sample.pdf'

    });


}




function getAllData() {

    //$("button").removeClass("clickclass");
    tabID = $("#hdntab").val();
    //$("button").removeClass("clickclass");
    from = '';
    to = $("#dtidto").val();
    getdate('', '', from, to, "GetAllGDP");
}

$(".Cbox").click(function () {
    if (this.id == 'chkdataID') {
        if ($(this).is(":checked")) {
            commonfunction();

        } else {
            $("#divdataID").hide();
        }
    }
    else {
        if ($(this).is(":checked")) {
            commonfunction();
        } else {
            $("#divgraphID").hide();
        }
    }
});

function tabClick(control) {

    $("#hdnsecname").val('');
    $("#hdnsecname").val(control.textContent);
    $('#ddlSectorID').prop('selectedIndex', 0);
    tabID = control.id;
    $("#hdntab").val(tabID);
    $("button").removeClass("clickclass");
    $(control).addClass('clickclass');
    from = $("#dtidfrom").val();
    to = $("#dtidto").val();
    getdate('', tabID, from, to, "ChartData");
}
function commonfunction() {
    tabID = $("#hdntab").val();
    SecID = $("#ddlSectorID").val() == undefined ? '' : $("#ddlSectorID").val();
    if (tabID == "" && SecID == "") {
        $(".Cbox").prop("checked", false);
        return false;
    }
    //$("button").removeClass("clickclass");
    from = $("#dtidfrom").val();
    to = $("#dtidto").val();
    if (SecID == "") {
        if (tabID == "1111")
            getAllData();
        else
            getdate(SecID, tabID, from, to, "ChartData");
    }
    else {
        getdate(SecID, tabID, from, to, "onlysector");
    }

}
function submitclick() {
    

    tabID = $("#hdntab").val();
    from = $("#dtidfrom").val();
    to = $("#dtidto").val();
    SecID = $("#ddlSectorID").val();
    if (SecID != "" && SecID != undefined)
        getdate(SecID, tabID, from, to, "onlysector");
    else
        getdate(SecID, tabID, from, to, "ChartData");
}

$("ul.nav-tabs a").click(function (e) {
    e.preventDefault();
    $(this).tab('show');
});

function getmapdata(SecID, tabID, from,to, typ) {
    To = $('#ddlYears').val();
    var URL = 'DashBoardPredective/getChartandTableData/';  ///'@Url.Action("getChartandTableData","DashBoardPredective")';
    $.ajax({
        type: "GET",
        url: URL,
        data: { 'SecID': SecID, 'tabID': tabID, 'type': "MAPData", 'from': from, 'to': To },
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            
            if (result["table"] != undefined)
                initMap(result.table);
        }
    });

}
// string from = "", string To = ""
function getdate(SecID, tabID, from, to, type) {
    SecID = $('#ddlSectorID').val();
    var URL = 'DashBoardPredective/getChartandTableData/';  ///'@Url.Action("getChartandTableData","DashBoardPredective")';
    $.ajax({
        type: "GET",
        url: URL,
        data: { 'SecID': SecID, 'tabID': tabID, 'type': type, 'from': from, 'to': to },
        contentType: "application/json",
        dataType: "json",
        success: function (result) {

            // $("#hdncmsdataorg").val(result.table7);
            
            if ($("#hdnsecname").val() != "CMS") { $(".divmainmap").hide(); } else { initMap(result.table7); $(".divmainmap").show() }
                                      
            $('#container').empty();
            if ($("#chkdataID").is(":checked")) {
                
                if ($("#hdnYearly").val() == "") { $('#tblData').empty(); draw_a_table_from_json(result.table, result.table3, Object.keys(result.table3[0]), Object.keys(result.table[0]), '#tblData', result['table5']==undefined?"":result.table5[0].per); $("#divdataID").show(); }
            }
            //var keys = Object.keys(result);
            if ($("#chkgpID").is(":checked")) {
                var cat = new Array();
                var catData = new Array();
                cser = [];

                if (result.table.length > 1) { Pretype = 'ShortDash'; type = 'spline'; colorcode = ['#359862', '#fa7c28', '#8db5de', '#4A235A', '#154360', '#0E6655', '#7B7D7D', '#707B7C', '#283747']; Precolorcode = ['#359862', '#fa7c28', '#8db5de', '#4A235A', '#154360', '#0E6655', '#7B7D7D', '#707B7C', '#283747']; }

                else { Pretype = ''; type = 'column'; colorcode = ['#008080', '#fa7c28', '#8db5de']; if (result.table.length == 0) Precolorcode = ['#008080', '#fa7c28', '#8db5de']; else Precolorcode = ['#fa7c28', '#fa7c28', '#8db5de']; }
                // Precolorcode = ['#fa7c28', '#fa7c28', '#fa7c28'];
                Yexiscode = [0, 1, 1];
                var col1 = [];
                var col2 = [];
                var col3 = [];
                var col4 = [];
                
                for (var a = 0; a <= result.table.length - 1; a++) {
                    col1 = [];
                    for (var i = 0; i < result.table1.length; i++) {
                        col1.push([result.table1[i].year, result.table1[i][Object.keys(result.table1[i])[a + 1]]]);
                    }
                    incser = {
                        name: Object.keys(result.table1[0])[a + 1],
                        data: col1,
                        type: type,
                        lineWidth: 4,
                        color: colorcode[a],

                        yAxis: Yexiscode[a]
                    };
                    cser.push(incser);

                }
                //trend Data
                for (var a1 = 0; a1 <= result.table3.length - 1; a1++) {
                    col1 = [];
                    for (var i1 = 0; i1 < result.table4.length; i1++) {
                        col1.push([result.table4[i1].year, result.table4[i1][Object.keys(result.table4[i1])[a1 + 1]]]);
                    }
                    incser = {
                        name: result['table5'] == undefined ?"":Object.keys(result.table4[0])[a1 + 1],
                        data: col1,
                        //type: Pretype,
                        dashStyle: Pretype,
                        color: Precolorcode[a1],
                        yAxis: Yexiscode[a1]
                    };
                    cser.push(incser);

                }
                custlbl = [];
                seriesOptions = [];
                Object.keys(col1).forEach(function (key) {
                    var value = col1[key];
                    custlbl.push(value[0]);

                });


                //col1 = [];


                colors = ['green', 'blue', '#c76f6f','#4A235A','#154360','#0E6655','#7B7D7D','#707B7C','#283747'];
                classname = ['accuracydiv', 'accuracytop', 'accuracytop','accuracytop'];
                if(result['table5'] != undefined)
                if (result.table.length > 0 && result.table6.length > 0 ) {
                    $("#rowaccuracyID").empty();
                    for (i7 = 0; i7 <= result.table6.length - 1; i7++) {

                        spin1 = '<div class="box"><div class="progress-bar position" data-percent=' + result.table6[i7].y +
                            ' data-duration="1000" data-color="#ccc,' + colors[i7] + 
                            '"></div><span style="color: white;">' + result.table6[i7].name +
                            '</span></div>';
                        //spin1 = `<div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ` + classname[i7] + `">
                        //   <div class="progress-bar position" data-percent=`+ result.table6[i7].y + ` data-duration="1000" data-color="#ccc,` + colors[i7] + `"></div>
                        //           <span style="color: white; display:inline-block">`+ result.table6[i7].name + `</span>
                        //                            </div>`;

                        $("#rowaccuracyID").append(spin1);

                    }
                    $(".progress-bar").loading();
                    $('input').on('click', function () {
                        $(".progress-bar").loading();
                    });
                }

                //    cser.push(incser);
                //}



                //accurecy



                var asasa = catData;
                if (tabID != "")
                    createCharts(cser, custlbl,result.table2[0].title, Object.keys(result.table3[0])[1], Object.keys(result.table3[0])[Object.keys(result.table3[0]).length - 1]);
                else
                    createChartssingle(cser, custlbl,result.table2[0].title, Object.keys(result.table3[0])[1], Object.keys(result.table3[0])[Object.keys(result.table3[0]).length - 1]);
                $("#divgraphID").show();
                $("#hdnYearly").val('');

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


function createCharts(cser, custlbl,Title, firstD, lastD) {
    
    var buttons = Highcharts.getOptions().exporting.buttons.contextButton.menuItems.slice();
    buttons[5] = "label";
    buttons[6] = "label2";
    //buttons.push('label');
    //buttons.push('label2');
    Highcharts.chart('container', {
        credits: {
            enabled: false
        },
        chart: { backgroundColor: "rgba(0,0,0,0)" },
        title: {
            text: CapitaliseFirstLetter(Title) + ',' + firstD + '-' + lastD,
            style: {
                color: 'white'
            }
        },

        exporting: {
            menuItemDefinitions: {
                // Custom definition
                label: {
                    onclick: function () {

                        var Url = getimgURL();
                        demoFromHTML(Url, this.getTable(), this.getFilename(), Title);


                    },
                    text: 'Download PDF'
                },
                label2: {
                    onclick: function () {
                        var Url = getimgURL();
                        Export2Doc(Url, this.getTable(), this.getFilename(), Title, custlbl, cser, firstD, lastD);
                        //Export2Doc(Url, this.getTable(), this.getFilename(), Title, cser, firstD, lastD);
                    },
                    text: 'Download Word'
                }
            },

            buttons: {
                contextButton: {
                    menuItems: buttons
                }
            }
        },

        subtitle: {
            text: ''
        },
        xAxis: {
            categories: custlbl,
            labels: {
                rotation:20,
                align: 'left',
                reserveSpace: true,
                style: {
                    paddingTop: '10px',
                    color: 'white'
                }

            }
        },
        yAxis: [{
            title: {
                text: 'Primary Axis'
            },
            labels: {
                style: {
                    color: "white"
                }
            }
        }, {
            title: {
                text: 'Secondary Axis'
            },
            labels: {
                style: {
                    color: "white"
                }
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
            verticalAlign: 'bottom',
            itemStyle: {
                color: 'white'
            }

        },

        //plotOptions: {
        //    series: {
        //        label: {
        //            connectorAllowed: false
        //        },
        //        pointStart: 2010
        //    }
        //},

        series: cser //[{
        //    name: col1N,
        //    data: col1,
        //    color: '#359862',
        //    yAxis: 1
        //},
        //{
        //    name: col2N,
        //    data: col2,
        //    color: '#fa7c28'
        //},
        //{
        //    name: col3N,
        //    data: col3,
        //    //dashStyle: 'longdash',
        //    color: '#8db5de'

        //}

        //]
    });
}


function createChartssingle(cser, custlbl, Title, firstD, lastD) {
  var buttons = Highcharts.getOptions().exporting.buttons.contextButton.menuItems.slice();
    buttons[5] = "label";
    buttons[6] = "label2";
    //buttons.push('label');
    //buttons.push('label2');

    Highcharts.chart('container', {

        credits: {
            enabled: false
        },
        chart: { backgroundColor: "rgba(0,0,0,0)" },
        title: {
            text: CapitaliseFirstLetter(Title) + ',' + firstD + '-' + lastD,
            style: {
                color: 'white'
            }
        },
        scrollbar: {
            enabled: true
        },
        navigator: {
            enabled: true
        },
        rangeSelector: {
            enabled: true
        },

        exporting: {
            menuItemDefinitions: {
                // Custom definition
                label: {
                    onclick: function () {

                        var Url = getimgURL();
                        demoFromHTML(Url, this.getTable(), this.getFilename(), Title);

                    },
                    text: 'Download PDF'
                },
                label2: {
                    onclick: function () {
                        var Url = getimgURL();
                        Export2Doc(Url, this.getTable(), this.getFilename(), Title, custlbl, cser, firstD, lastD);

                    },
                    text: 'Download Word'
                }
            },

            buttons: {
                contextButton: {
                    menuItems: buttons
                }
            }
        },

        subtitle: {
            text: ''
        },
        xAxis: {
            categories: custlbl,
            labels: {
                rotation: 20,
                align: 'left',
                reserveSpace: true,
                style: {
                    paddingTop: '10px',
                    color: 'white'
                }

            }
        },

        yAxis: [{
            title: {
                text: 'Primary Axis'
            },
            labels: {
                style: {
                    color: "white"
                }
            }
        }
            , {
            title: {
                text: 'Secondary Axis'
            },
            labels: {
                style: {
                    color: "white"
                }
            },
            gridLineWidth: 0,
            opposite: true
        }
        ],
        legend: {
            align: 'center',
            verticalAlign: 'bottom',
            itemStyle: {
                color: 'white'
            }

        },

        plotOptions: {
            column: {
                pointPadding: 0.2,
                borderWidth: 0
            }
        },

        series: cser //[{
        //    name: col1N,
        //    data: col1,
        //    color: '#359862',
        //    yAxis: 1
        //}
        //]

    });
}
document.addEventListener('DOMContentLoaded', function () {
    getdate();
   
});
function draw_a_table_from_json(json_data_array, json_data_array2, head_array, item_array, destinaion_element, per) {

    var table = '<table class="table table-bordered">';
    //TH Loop
    table += '<tr>';
    $.each(head_array, function (head_array_key, head_array_value) {
        table += '<th>' + head_array_value.charAt(0).toUpperCase() + head_array_value.slice(1) + ' ' + per + '</th>';
    });
    table += '</tr>';
    //TR loop
    $.each(json_data_array, function (key, value) {

        table += '<tr>';

        $.each(head_array, function (item_key, item_value) {
            table += '<td>' + (value[item_value] == null ? '' : value[item_value]) + '</td>';
        });
        table += '</tr>';
    });
    $.each(json_data_array2, function (key, value) {

        table += '<tr>';
        //TD loop
        $.each(head_array, function (item_key, item_value) {
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

function CapitaliseFirstLetter(elemId) {
    var txt = elemId.toLowerCase();
    txtNew = (txt.replace(/^(.)|\s(.)/g, function ($1) {
        return $1.toUpperCase();
    }));
    return txtNew;
}


function waitAndCall(func) {
    setTimeout(func, parseInt(Math.random() * 10000));
}

function toDataURL(src, callback, outputFormat) {
    var img = new Image();
    img.crossOrigin = 'Anonymous';
    img.onload = function () {
        var canvas = document.createElement('CANVAS');
        var ctx = canvas.getContext('2d');
        var dataURL;
        canvas.height = this.naturalHeight;
        canvas.width = this.naturalWidth;
        ctx.drawImage(this, 0, 0);
        dataURL = canvas.toDataURL(outputFormat);
        callback(dataURL);
    };
    img.src = src;
    if (img.complete || img.complete === undefined) {
        img.src = "data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///ywAAAAAAQABAAACAUwAOw==";
        img.src = src;
    }

}

 function Export2Doc(intable, htmlval, filename, sectorname, cat, chdata, first, last) {
    var html, link, blob, url, css;

    if (!window.Blob) {
        alert('Your legacy browser does not support this action.');
        return;
    }

    imagedata = "";
    imagedata1 = "";


    toDataURL(
        'images/LogoNew.jpeg',
        function (dataUrl) {
            imagedata = dataUrl;
        }
    );

  setTimeout(getchartimgURL(cat, chdata, sectorname, first, last), 500);
    setTimeout(
        function () {

            if (!window.Blob) {
                alert('Your legacy browser does not support this action.');
                return;
            }

            var html, link, blob, url, css;

            var preHtml = '<html xmlns:o="urn:schemas-microsoft-com:office:office"'+
'xmlns:w="urn:schemas-microsoft-com:office:word"' +
'xmlns="http://www.w3.org/TR/REC-html40">'+
'<head><title>Microsoft Office HTML Example</title>'+
'<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"><style>'+

'#divtblID table, th, td {border: 1px solid black;.tablecl {   height: 17px;   margin-top:5px}'+

'.tablecl th, td {   height: 17px;   margin-top:5px   border: 0px solid white !important;}'
'@page'+
'{    mso-page-orientation: landscape; size:26.7cm 36.4cm; margin:1cm 1cm 1cm 1cm;}'+
'@page Section1 { }'+
'div.Section1 { page:Section1; }</style><xml><w:WordDocument>'+
'<w:View>Print</w:View>'+
'<w:Zoom>50</w:Zoom>'+
'<w:DoNotOptimizeForBrowser/>'+
'</w:WordDocument></xml></head><body>';

            // var preHtml = "<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word' xmlns='http://www.w3.org/TR/REC-html40'><head><meta charset='utf-8'><meta http-equiv='content-type' content='text/ html'; charset=UTF-8><meta name='robots' content='noindex,nofollow'><title>Export HTML To Doc</title></head><body>";
            var postHtml = "</body></html>";
            document.querySelector('#pngcontainer').innerHTML = '';
            //document.querySelector('#pngcontainer').innerHTML = '<div class="Section1"><div><img src="' + imagedata + '" /></div><div style="margin-top:2pt;text-align:center"><span style="font-size:20pt" >Sector  - ' + $("#hdnsecname").val() + '</span></div><div style="margin-top:2pt;text-align:center"> <table><tr><td><img  src="' + imagedata1 + '" ></img></td></tr></table></div><div id="divtblID"></div></div>';
            document.querySelector('#pngcontainer').innerHTML = '<div class="Section1"><div ><img src="' + imagedata + '" /></div><table  class="tablecl"><tr><td style="border="0"></td></tr></table><div style="margin-top:2pt"><span style="font-size:17pt" >Sector  - ' + $("#hdnsecname").val() + '</span></div><table><tr><td style="border="0"></td></tr></table><div style="margin-top:2pt;"> <img  src="' + $("#hdnimageurl").val() + '" ></img></div><table><tr><td></td></tr></table><div id="divtblID"></div></div>';
            document.querySelector('#divtblID').innerHTML = htmlval;

            html = preHtml + document.getElementById('pngcontainer').innerHTML + postHtml;

            // EU A4 use: size: 841.95pt 595.35pt;
            // US Letter use: size:11.0in 8.5in;


            blob = new Blob(['\ufeff', html], {
                type: 'application/msword'
            });
            url = URL.createObjectURL(blob);
            link = document.createElement('A');
            link.href = url;
            // Set default file name. 
            // Word will append file extension - do not add an extension here.
            link.download = $("#hdnsecname").val();
            document.body.appendChild(link);
            if (navigator.msSaveOrOpenBlob) navigator.msSaveOrOpenBlob(blob, $("#hdnsecname").val() + '.doc'); // IE10-11
            else link.click();  // other browsers
            document.body.removeChild(link);
        }, 1500);
   
}
function demoFromHTML(intable, htmlval, filename, sectorname) {

    var pdf = new jsPDF('p', 'pt', 'a1');
    // var pdf = new jsPDF('p', 'pt', 'letter');

    var width = pdf.internal.pageSize.getWidth();
    var height = pdf.internal.pageSize.getHeight();
    // var pdf = new jsPDF('p', 'pt', 'letter');

    document.querySelector('#pngcontainer').innerHTML = '';
    document.querySelector('#pngcontainer').innerHTML = '<div><img src="images/LogoNew.jpeg"></img></div><table><tr><td></td></tr></table><div><span style="font-size:25pt" > Sector - ' + $("#hdnsecname").val() + '</span></div><table><tr><td></td></tr></table><div><img  src="' + intable + '"></img></div><table><tr><td></td></tr></table><div class="highcharts-data-table" id="divtblID"></div>';
    //document.querySelector('#pngcontainer').innerHTML = '<div><img  src="images/LogoNew.jpeg" /></div><table><tr><td align="right">Sector - </td><td>' + $("#hdnsecname").val() + '</td></tr></Table><div><img  src="' + intable + '"></div><div id="divtblID"></div>';
    document.querySelector('#divtblID').innerHTML = htmlval;
    //Export();

    source = document.querySelector('#pngcontainer').innerHTML;
    specialElementHandlers = {
        // element with id of "bypass" - jQuery style selector
        '#bypassme': function (element, renderer) {
            // true = "handled elsewhere, bypass text extraction"
            return true;
        }
    };
    margins = {
        top: 10,
        bottom: 0,
        left: 60,

        width: width,
        height: height
    };

    pdf.fromHTML(
        source, // HTML string or DOM elem ref.
        margins.left, // x coord
        margins.top, { // y coord
            'width': margins.width, // max width of content on PDF
            'elementHandlers': specialElementHandlers
        },

        function (dispose) {
            pdf.save($("#hdnsecname").val());
        }, margins);
}

function createPDF() {
    var sTable = document.getElementById('pngcontainer').innerHTML;

    var style = "<style>";
    style = style + "table {width: 100%;font: 17px Calibri;}";
    style = style + "table, th, td {border: solid 1px #DDD; border-collapse: collapse;";
    style = style + "padding: 2px 3px;text-align: center;}";
    style = style + "</style>";

    // CREATE A WINDOW OBJECT.
    var win = window.open('', '', 'height=700,width=700');

    win.document.write('<html><head>');
    win.document.write('<title>Profile</title>');   // <title> FOR PDF HEADER.
    win.document.write(style);          // ADD STYLE INSIDE THE HEAD TAG.
    win.document.write('</head>');
    win.document.write('<body>');
    win.document.write(sTable);         // THE TABLE CONTENTS INSIDE THE BODY TAG.
    win.document.write('</body></html>');

    win.document.close(); 	// CLOSE THE CURRENT WINDOW.

    win.print();    // PRINT THE CONTENTS.
}

function Export() {
    html2canvas(document.getElementById('pngcontainer'), {
        onrendered: function (canvas) {
            var data = canvas.toDataURL();
            var docDefinition = {
                content: [{
                    image: data,
                    width: 500
                }]
            };
            pdfMake.createPdf(docDefinition).download("Table.pdf");
        }
    });
}
function getchartimgURL(cat, indata, sectorname, firstD, lastD) {
    var options = {
        chart: {},
        credits: {
            enabled: false
        },
        title: {
            text: CapitaliseFirstLetter(sectorname) + ',' + firstD + '-' + lastD
        },
        yAxis: [{
            title: {
                text: 'Primary Axis'
            },
            tickInterval: 20
        }
            , {
            title: {
                text: 'Secondary Axis'
            },
            tickInterval: 20
            ,
            gridLineWidth: 0,
            opposite: true
        }
        ],
        xAxis: {
            categories: cat
        },
        series: indata
    };
    var data = {
        options: JSON.stringify(options),
        filename: 'test.png',
        type: 'image/png',
        async: true
    };
    imageurlNew = "";
    var exportUrl = 'https://export.highcharts.com/';
    $.post(exportUrl, data, function (data) {
        var imageUrl = exportUrl + data;
        var urlCreator = window.URL || window.webkitURL;
        $("#hdnimageurl").val('');
        $("#hdnimageurl").val(imageUrl);
        //return imageUrl;
        //document.querySelector("#image").src = imageUrl;
        //fetch(imageUrl).then(response => response.blob()).then(data => { console.log(data) });
    });


}
function setProgress(elem, percent) {
    var
        degrees = percent * 3.6,
        transform = /MSIE 9/.test(navigator.userAgent) ? 'msTransform' : 'transform';
    elem.querySelector('.counter').setAttribute('data-percent', Math.round(percent));
    elem.querySelector('.progressEnd').style[transform] = 'rotate(' + degrees + 'deg)';
    elem.querySelector('.progress').style[transform] = 'rotate(' + degrees + 'deg)';
    if (percent >= 50 && !/(^|\s)fiftyPlus(\s|$)/.test(elem.className))
        elem.className += ' fiftyPlus';
}

function initMap(beaches) {
     const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 7,
        center: {
            lat: -26.270760,
            lng: 28.112268
        }
    });
    setMarkers(map, beaches);
} 

function setMarkers(map, beaches) {
    

       // Adds markers to the map.
    // Marker sizes are expressed as a Size of X,Y where the origin of the image
    // (0,0) is located in the top left of the image.
    // Origins, anchor positions and coordinates of the marker increase in the X
    // direction to the right and in the Y direction down.
    const image = {
        //url:
        //    "images/south-africa-flag-xs.jpg",
        // This marker is 20 pixels wide by 32 pixels high.
        size: new google.maps.Size(100,50),
        // The origin for this image is (0, 0).
        origin: new google.maps.Point(0, 0),
        // The anchor for this image is the base of the flagpole at (0, 32).
        anchor: new google.maps.Point(20,100)
    }; // Shapes define the clickable region of the icon. The type defines an HTML
    // <area> element 'poly' which traces out a polygon as a series of X,Y points.
    // The final coordinate closes the poly by connecting to the first coordinate.
    var markerIcon = {
        url: 'https://maps.google.com/mapfiles/ms/icons/red-dot.png',
        scaledSize: new google.maps.Size(50, 50),
        origin: new google.maps.Point(0, 0),
        anchor: new google.maps.Point(32, 65),
        labelOrigin: new google.maps.Point(30, 70)
    };
    
    
    for (let i = 0; i < beaches.length; i++) {
        const beach = beaches[i];
        const lbl = beach.sectorName + " <br/> " + "(Orig)" + beach.dataval + " <br/>  " + "(Pred)" + beach.trend;
         new google.maps.Marker({
            position: {
                lat: beach.lat,
                lng: beach.long
             },
             icon: markerIcon,
             map: map,
             animation: google.maps.Animation.DROP,
             labelOrigin: new google.maps.Point(-7, 0),
             label: {
                 color: 'black',
                 fontWeight: 'bold'
                //text: beach.sectorName + "\n(Orig)  " + beach.dataval + "    " + "\n(Pred.)  " + beach.trend,
             },
            title: "(Orig)  " + beach.dataval + "    " + "\n(Pred.)  " + beach.trend
        })
    }
  
}

//function filtermapData(fyear) {
//    $("hdncmsdataFilter").val();
//      const  org= $("#hdncmsdataorg").val();
//      const pred = $("#hdncmsdatapred").val();

//       const Filteredallcitydata = totallcitydata.map(item => {
//        const container = {};

//        container[item.name] = item.likes;
//        container.age = item.name.length * 10;

//        return container;
//    })
//}


function  bindYears () {
    //Reference the DropDownList.
    var ddlYears = document.getElementById("ddlYears");

    //Determine the Current Year.
    var currentYear = (new Date()).getFullYear()+30;

    //Loop and add the Year values to DropDownList.
    for (var i = 2001; i <= currentYear; i++) {
        var option = document.createElement("OPTION");
        option.innerHTML = i;
        option.value = i;
        ddlYears.appendChild(option);
    }
};



