#pragma checksum "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "713add0e52f3f47d6eac65de7e6476e0af78c636"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Presentation.Pages.Admin.Pages_Admin_Plane), @"mvc.1.0.razor-page", @"/Pages/Admin/Plane.cshtml")]
namespace Presentation.Pages.Admin
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\_ViewImports.cshtml"
using Presentation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"713add0e52f3f47d6eac65de7e6476e0af78c636", @"/Pages/Admin/Plane.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d76d778d4c858045a827ae28cbb9bc28e1d5c23", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Plane : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control form-control-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("cursor:pointer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Admin/Plane", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("pagination_link active"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("pagination_link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("forms-sample"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("EditPlane-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
  
  Layout = "_LayoutAdmin";
	ViewData["Title"] = "Admin Page";

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
  
  if(HttpContext.Session.GetString("username") == null)
  {
    Response.Redirect("Index");
  }
  string job = HttpContext.Session.GetString("job");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""main-panel"">
  <div class=""content-wrapper"">
    <!-- row button create -->
    <div class=""row"">
      <div class=""col-lg-12 stretch-card"">
        <a href=""#CreatePlaneForm"" data-toggle=""modal"" id=""btCreatePlane"" type=""button"" class=""btn  btn-primary btn-lg btn-inverse-*"">
          <i class=""mdi mdi-upload""></i>Create Plane
        </a>
      </div>
    </div>
    <!-- row table -->
    <div class=""row"">
    <div class=""col-lg-12 stretch-card"">
      <div class=""card"">
        <div class=""card-body"">
          <div class=""form-group row"">
            <div class=""col-sm-7""></div>
            <div class=""col-sm-5"">
              <div class=""input-group"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713add0e52f3f47d6eac65de7e6476e0af78c6367669", async() => {
                WriteLiteral("\r\n                  <div class=\"input-group\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713add0e52f3f47d6eac65de7e6476e0af78c6367996", async() => {
                    WriteLiteral("\r\n                      ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713add0e52f3f47d6eac65de7e6476e0af78c6368286", async() => {
                        WriteLiteral("All");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 36 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.SearchMaker);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 36 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.ListMakerName;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    <button type=\"submit\" id=\"btsubmitSearchMaker\" class=\"btn btn-icons btn-rounded btn-outline-primary\"><i class=\"fa fa-search\"></i></button>\r\n                  </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
              </div>
            </div> 
          </div>
          <h3 align=""center"">List of Planes </h3>
          <table class=""table table-bordered table-striped table-hover"" id=""TablePlane"">
           <thead>
            <tr>
              <th>Phane ID</th>
              <th>Seat Num</th>
              <th>Maker ID</th>
              <th></th>
            </tr>
           </thead>
           <tbody>
");
#nullable restore
#line 56 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
             foreach (var item in Model.ListPlanePage.Planes){

#line default
#line hidden
#nullable disable
            WriteLiteral("              <tr>\r\n                <td>");
#nullable restore
#line 58 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
               Write(item.PlaneId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 59 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
               Write(item.SeatNum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 60 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
               Write(item.MakerId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td> \r\n                  <button");
            BeginWriteAttribute("id", "  id=\"", 2173, "\"", 2192, 1);
#nullable restore
#line 62 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
WriteAttributeValue("", 2179, item.PlaneId, 2179, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"modal\" data-target=\"#EditPlaneForm\"  type=\"button\" class=\"btn btn-dark btn-sm  btn-rounded EditPlane\"><i class=\"fa fa-cog\"></i></button>\r\n                  <button");
            BeginWriteAttribute("id", "  id=\"", 2370, "\"", 2389, 1);
#nullable restore
#line 63 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
WriteAttributeValue("", 2376, item.PlaneId, 2376, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"button\" class=\"btn btn-danger btn-sm  btn-rounded DeletePlane\"><i class=\"fa fa-times\" ></i></button>\r\n                </td>\r\n              </tr>\r\n");
#nullable restore
#line 66 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n          </table>\r\n          <br />\r\n");
#nullable restore
#line 70 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
            
              var preDisabled = !Model.ListPlanePage.Planes.HasPrevious ? "disabled" : "";
              var nextDisabled = !Model.ListPlanePage.Planes.HasNext ? "disabled" : "";
              var pageNow =Model.ListPlanePage.Planes.PageIndex;
            

#line default
#line hidden
#nullable disable
            WriteLiteral("              <!-- pagination -->\r\n              <div class=\"pagination\" >\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713add0e52f3f47d6eac65de7e6476e0af78c63616037", async() => {
                WriteLiteral("Previous");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageIndex", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 78 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                          WriteLiteral(Model.ListPlanePage.Planes.PageIndex - 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageIndex", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3145, "pagination_link", 3145, 15, true);
#nullable restore
#line 79 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
AddHtmlAttributeValue(" ", 3160, preDisabled, 3161, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 80 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                 for (int i=1;i<=Model.ListPlanePage.Planes.TotalPages;++i)
                {
                    if(i==pageNow)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                      ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713add0e52f3f47d6eac65de7e6476e0af78c63619224", async() => {
#nullable restore
#line 84 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                                                                                                                            Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageIndex", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 84 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                                                                                 WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageIndex", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 85 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                    }
                    else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                      ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713add0e52f3f47d6eac65de7e6476e0af78c63622115", async() => {
#nullable restore
#line 87 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                                                                                                                    Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageIndex", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 87 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                                                                                 WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageIndex", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 88 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713add0e52f3f47d6eac65de7e6476e0af78c63624984", async() => {
                WriteLiteral("Next");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageIndex", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 91 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                          WriteLiteral(Model.ListPlanePage.Planes.PageIndex + 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageIndex", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3879, "pagination_link", 3879, 15, true);
#nullable restore
#line 92 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
AddHtmlAttributeValue(" ", 3894, nextDisabled, 3895, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
              </div>
        </div>
      </div>
    </div>
    </div>

  </div>
  <!-- end content-wrapper -->
</div>

<!--create plane form  -->
<div class=""modal fade"" id=""CreatePlaneForm"" role=""dialog"">
  <div class=""modal-dialog modal-dialog-centered modal-sm"">
    <div class=""modal-content"" >
      <div class=""modal-header"" style=""text-align:center !important; background-color:aliceblue;"">
        <h4 class=""modal-title"" style="" color:#000; font-weight: bold;font-size:34"">Create Plane</h4>
      </div>
		  <div class=""model-body"" style=""margin: 15px"">
				");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713add0e52f3f47d6eac65de7e6476e0af78c63628408", async() => {
                WriteLiteral(@"
          <div class=""form-group row"">
            <label class=""col-sm-3 col-form-label"">SeatNum</label>
            <div class=""col-sm-9"">
              <input id=""CreatePlane-seatnum"" type=""number"" class=""form-control""  placeholder=""Enter seat number"">
            </div>    
          </div>
          <div class=""form-group row"">
            <label class=""col-sm-3 col-form-label"">Maker ID</label>
            <div class=""col-sm-9"">
              <select class=""form-control form-control-lg"" id=""CreatePlane-makerid"">
");
#nullable restore
#line 122 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                 foreach (var item in Model.ListMakers){

#line default
#line hidden
#nullable disable
                WriteLiteral("                  ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713add0e52f3f47d6eac65de7e6476e0af78c63629494", async() => {
#nullable restore
#line 123 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                     Write(item.MakerId);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" - \r\n                    ");
#nullable restore
#line 124 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
               Write(item.MakerName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 125 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"              </select>
            </div>
          </div>
          <button id=""btsubmitCreatePlane"" type=""submit"" class=""btn btn-success mr-2"" ><b>Create</b></button>
          <button class=""btn btn-light"" data-dismiss=""modal""><b>Cancel</b></button>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
		  </div>
    </div> 
  </div>
</div>

 <!-- edit Plane form -->
<div class=""modal fade"" id=""EditPlaneForm"" role=""dialog"">
  <div class=""modal-dialog modal-dialog-centered modal-sm"">
    <div class=""modal-content"" >
      <div class=""modal-header"" style=""text-align:center !important; background-color:aliceblue;"">
        <h4 class=""modal-title"" style="" color:#000; font-weight: bold;font-size:34"">Edit Plane</h4>
      </div>
      <div class=""model-body"" style=""margin: 15px"" id=""bodyEditPlane"">
				");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713add0e52f3f47d6eac65de7e6476e0af78c63633020", async() => {
                WriteLiteral(@"
          <input id=""EditPlane-id"" type=""hidden"" class=""form-control""   >
          <div class=""form-group row"">
            <label class=""col-sm-3 col-form-label"">SeatNum</label>
            <div class=""col-sm-9"">
              <input id=""EditPlane-seatnum"" type=""number"" class=""form-control""  placeholder=""Enter seat number"">
            </div>    
          </div>
          <div class=""form-group row"">
            <label class=""col-sm-3 col-form-label"">Maker ID</label>
            <div class=""col-sm-9"">
              <select class=""form-control form-control-lg"" id=""EditPlane-makerid"">
                  ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713add0e52f3f47d6eac65de7e6476e0af78c63633930", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 158 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                 foreach (var item in Model.ListMakers){

#line default
#line hidden
#nullable disable
                WriteLiteral("                  ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713add0e52f3f47d6eac65de7e6476e0af78c63635579", async() => {
#nullable restore
#line 159 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                     Write(item.MakerId);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" - \r\n                    ");
#nullable restore
#line 160 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
               Write(item.MakerName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 161 "C:\Users\Administrator\Desktop\Greenair\presentation\Pages\Admin\Plane.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"              </select>
            </div>
          </div>
          <button id=""btsubmitEditPlane"" type=""submit"" class=""btn btn-success mr-2"" ><b>Update</b></button>
          <button class=""btn btn-light"" data-dismiss=""modal""><b>Cancel</b></button>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n      </div>\r\n    </div>    \r\n  </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Presentation.Pages.Admin.PlaneModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Presentation.Pages.Admin.PlaneModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Presentation.Pages.Admin.PlaneModel>)PageContext?.ViewData;
        public Presentation.Pages.Admin.PlaneModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
