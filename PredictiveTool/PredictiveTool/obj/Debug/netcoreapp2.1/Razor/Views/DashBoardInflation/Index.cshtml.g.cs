#pragma checksum "D:\Test\RndDsample\PredictiveTool (2)\PredictiveTool\PredictiveTool\Views\DashBoardInflation\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f0e0a4e17361df1a18af01456071768b74ead91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DashBoardInflation_Index), @"mvc.1.0.view", @"/Views/DashBoardInflation/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DashBoardInflation/Index.cshtml", typeof(AspNetCore.Views_DashBoardInflation_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Test\RndDsample\PredictiveTool (2)\PredictiveTool\PredictiveTool\Views\_ViewImports.cshtml"
using PredictiveTool;

#line default
#line hidden
#line 2 "D:\Test\RndDsample\PredictiveTool (2)\PredictiveTool\PredictiveTool\Views\_ViewImports.cshtml"
using PredictiveTool.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f0e0a4e17361df1a18af01456071768b74ead91", @"/Views/DashBoardInflation/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e4150f2e4959385b99c056e2c396627efcfaa37", @"/Views/_ViewImports.cshtml")]
    public class Views_DashBoardInflation_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PredictiveTool.Models.PredAnalysisModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Test\RndDsample\PredictiveTool (2)\PredictiveTool\PredictiveTool\Views\DashBoardInflation\Index.cshtml"
  
    var test = ViewContext.RouteData.Values["Action"].ToString();
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutMain.cshtml";

#line default
#line hidden
            BeginContext(209, 355, true);
            WriteLiteral(@"<div class=""innerdiv"">
    <div>
        <div role=""form"" class='form-horizontal'>


            <div class=""form-group"">
                <div class=""col-xs-2 text-left datamargin"">
                    <label class=""label Data"" for=""cpTitle"">Sectors </label>
                </div>
                <div class=""col-xs-3 mar"">
                    ");
            EndContext();
            BeginContext(565, 153, false);
#line 18 "D:\Test\RndDsample\PredictiveTool (2)\PredictiveTool\PredictiveTool\Views\DashBoardInflation\Index.cshtml"
               Write(Html.DropDownListFor(x => x.SectorID, ViewBag.UserName as IEnumerable<SelectListItem>, "Select", new { @class = "form-control DDN", id = "ddlSectorID" }));

#line default
#line hidden
            EndContext();
            BeginContext(718, 4118, true);
            WriteLiteral(@"
                </div>
                <div class=""col-xs-1 chkmar"">
                    <div class=""checkbox"">
                        <label>
                            <input id=""hdntab"" style=""display:none"" />
                            <input id=""chkdataID"" class=""Cbox"" type=""checkbox""> Data
                        </label>
                    </div>
                </div>
                <div class=""col-xs-3 chkmar"">
                    <div class=""checkbox"">
                        <label>
                            <input id=""chkgpID"" class=""Cbox"" type=""checkbox""> Graph
                        </label>
                    </div>
                </div>

            </div>
            
            <div class=""col-xs-12 col-sm-12 divblock"">
                <span>Date Range</span>
            </div>
            <br />
            <br />
            <br />
            <div class=""row"" style=""margin-top:25px"">
                <div class=""col-md-6"">
                    <div cl");
            WriteLiteral(@"ass=""col-md-6"">
                        <div class=""form-group"">
                            <label class=""col-md-4 control-label"">Year From</label>
                            <div class=""col-md-8"">
                                <div class='input-group date' id='datetimepicker1'>
                                    <input id=""dtidfrom"" type='date' class=""form-control input-lg"" />
                                    <span class=""input-group-addon"">
                                        <span style=""color:black!important"" class=""glyphicon glyphicon-calendar""></span>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label class=""col-md-2 control-label"">To</label>
                            <div class=""col-md-8"">
                                <di");
            WriteLiteral(@"v class='input-group date' id='datetimepicker1'>
                                    <input id=""dtidfrom"" type='date' class=""form-control input-lg"" />
                                    <span class=""input-group-addon"">
                                        <span style=""color:black!important"" class=""glyphicon glyphicon-calendar""></span>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-md-2"">
                    <button type=""submit"" onclick=""return submitclick();"" class=""btn btn-sm  subbtn""> Submit</button>
                </div>
            </div>
            <div id=""divdataID"" style=""display:none"">
                <div class=""col-xs-12 col-sm-12 divblock"">
                    <span>Data</span>
                </div>
                <div class=""tab-pane fade active in"" id=""sub11"">
                    <div cl");
            WriteLiteral(@"ass=""tbldicscrol"" id=""tblData""></div>
                </div>
            </div>
            <div id=""divgraphID"" style=""display:none"">
                <div class=""col-xs-12 col-sm-12 divblock"">
                    <span>Graph</span>
                    <div class=""intbtn"">
                    <button id=""btn5y"" onclick=""return YearlyFilter(this);"">10y</button>
                    <button id=""btn3y"" onclick=""return YearlyFilter(this);"">5y</button>
                    <button id=""btn1y"" onclick=""return YearlyFilter(this);"">3y</button>
                     </div>
                </div>
                <div id=""divchartID"" class=""tab-pane fade active in Outchartdivclass"" id=""sub11"">
                    <div id=""container"" style=""width:100%; height:400px;""></div>
                </div>
                <div class=""col-xs-12 col-sm-12 divblock""><span>Variance</span></div>
                <div id=""rowaccuracyID"" class=""wrapper"">

                </div>
            </div>

        </div>


    ");
            WriteLiteral("</div>\r\n\r\n\r\n\r\n</div>\r\n");
            EndContext();
            BeginContext(4949, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PredictiveTool.Models.PredAnalysisModel> Html { get; private set; }
    }
}
#pragma warning restore 1591