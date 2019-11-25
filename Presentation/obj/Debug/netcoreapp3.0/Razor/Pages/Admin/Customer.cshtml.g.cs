#pragma checksum "D:\Code\C#\Greenair\Presentation\Pages\Admin\Customer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "196e12e11ff948515dd6a61ec3ed0dc35b4c183c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Presentation.Pages.Admin.Pages_Admin_Customer), @"mvc.1.0.razor-page", @"/Pages/Admin/Customer.cshtml")]
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
#line 1 "D:\Code\C#\Greenair\Presentation\Pages\_ViewImports.cshtml"
using Presentation;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"196e12e11ff948515dd6a61ec3ed0dc35b4c183c", @"/Pages/Admin/Customer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d76d778d4c858045a827ae28cbb9bc28e1d5c23", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Customer : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Code\C#\Greenair\Presentation\Pages\Admin\Customer.cshtml"
  
  Layout = "_LayoutAdmin";
	ViewData["Title"] = "Admin Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""main-panel"">
  <div class=""content-wrapper"">
     <!-- row search -->
    <div class=""row"">
    </div>
    <!-- row table -->
    <div class=""row"">
    <div class=""col-lg-12 stretch-card"">
      <div class=""card"">
        <div class=""card-body"">
          <h3 align=""center"">List of Customers </h3>
          <table class=""table table-bordered table-striped table-hover"" id=""TableCustomer"">
           <thead>
            <tr>
              <th>ID</th>
              <th>First name</th>
              <th>Last name</th>
              <th>Email</th>
              <th>Status</th>
              <th></th>
            </tr>
           </thead>
           <tbody>
             <!-- change to code later -->
");
#nullable restore
#line 31 "D:\Code\C#\Greenair\Presentation\Pages\Admin\Customer.cshtml"
             foreach (var item in Model.ListCustomer){

#line default
#line hidden
#nullable disable
            WriteLiteral(@"              <tr>
                <td>item.Id</td>
                <td>item.FirstName</td>
                <td>item.LastName</td>
                <td>item.Email</td>
                <td><label class=""badge badge-warning"">item.Status</label></td>
                <td> 
                  <button");
            BeginWriteAttribute("id", "  id=\"", 1221, "\"", 1235, 1);
#nullable restore
#line 39 "D:\Code\C#\Greenair\Presentation\Pages\Admin\Customer.cshtml"
WriteAttributeValue("", 1227, item.Id, 1227, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"modal\" data-target=\"#EditCustomerForm\"  type=\"button\" class=\"btn btn-dark btn-sm  btn-rounded EditCustomer\"><i class=\"fa fa-cog\"></i></button>\r\n                  <button");
            BeginWriteAttribute("id", "  id=\"", 1419, "\"", 1433, 1);
#nullable restore
#line 40 "D:\Code\C#\Greenair\Presentation\Pages\Admin\Customer.cshtml"
WriteAttributeValue("", 1425, item.Id, 1425, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"button\" class=\"btn btn-danger btn-sm  btn-rounded DeleteCustomer\"><i class=\"fa fa-times\" ></i></button>\r\n                </td>\r\n              </tr>\r\n");
#nullable restore
#line 43 "D:\Code\C#\Greenair\Presentation\Pages\Admin\Customer.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n          </table>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    </div> \r\n  </div> \r\n  <!-- end content_warper -->\r\n</div>\r\n<!-- end main body -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Presentation.Pages.Admin.CustomerModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Presentation.Pages.Admin.CustomerModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Presentation.Pages.Admin.CustomerModel>)PageContext?.ViewData;
        public Presentation.Pages.Admin.CustomerModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
