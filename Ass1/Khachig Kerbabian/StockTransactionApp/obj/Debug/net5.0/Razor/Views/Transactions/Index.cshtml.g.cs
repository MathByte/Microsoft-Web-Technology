#pragma checksum "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c288b8bdea07d8604bb3f23abe3fd77be199755"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transactions_Index), @"mvc.1.0.view", @"/Views/Transactions/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\_ViewImports.cshtml"
using StockTransactionApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\_ViewImports.cshtml"
using StockTransactionApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c288b8bdea07d8604bb3f23abe3fd77be199755", @"/Views/Transactions/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdd53ced591467d4087951371a8497169c45c816", @"/Views/_ViewImports.cshtml")]
    public class Views_Transactions_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Transaction>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Transaction", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
  
	ViewData["Title"] = "All Transactions";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>");
#nullable restore
#line 9 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c288b8bdea07d8604bb3f23abe3fd77be1997555164", async() => {
                WriteLiteral("Add new movie");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<table class=""table table-bordered table-striped"">
	<thead>
		<tr>
			<th>Ticker Symbol</th>
			<th>Transaction Type</th>
			<th>Company Name</th>
			<th>Quantity</th>
			<th>Share Price</th>
			<th>Commission Fee</th>
			<th>Gross Value</th>
			<th>Net Value</th>
			<th>Action</th>

		</tr>
	</thead>
	<tbody>
");
#nullable restore
#line 27 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
         foreach (var transaction in Model)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<tr>\r\n\t\t\t<td>");
#nullable restore
#line 30 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
           Write(transaction.TickerSymbol);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t<td>");
#nullable restore
#line 31 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
           Write(transaction.TransactionType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t<td>");
#nullable restore
#line 32 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
           Write(transaction.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t<td>");
#nullable restore
#line 33 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
           Write(transaction.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t<td>");
#nullable restore
#line 34 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
           Write(transaction.SharePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t<td>");
#nullable restore
#line 35 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
           Write(transaction.TransactionType.CommissionFee);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\t\t\t<!--TO DISPLAY  Dollar sign in HTML I used Unicode &#36; \r\n\t\t\t\talso I checked if the resaults are less than 0 so I can know when to add Dollar sign or not-->\r\n");
#nullable restore
#line 39 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
             if (@transaction.GrossValue > 0)
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<td>");
#nullable restore
#line 41 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
               Write(transaction.GrossValue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 42 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
			}
			else
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<td> &#36;( ");
#nullable restore
#line 45 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
                        Write(transaction.GrossValue * -1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" )</td>\r\n");
#nullable restore
#line 46 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 49 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
             if (@transaction.NetValue > 0)
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<td>");
#nullable restore
#line 51 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
               Write(transaction.NetValue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 52 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
			}
			else
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<td> &#36;( ");
#nullable restore
#line 55 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
                        Write(transaction.NetValue * -1);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</td>\r\n");
#nullable restore
#line 56 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\t\t\t<td>\r\n\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c288b8bdea07d8604bb3f23abe3fd77be19975512522", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
                                                                    WriteLiteral(transaction.TransactionId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t<span class=\"linkSpacer\">|</span>\r\n\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c288b8bdea07d8604bb3f23abe3fd77be19975515051", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
                                                                      WriteLiteral(transaction.TransactionId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t</td>\r\n\t\t</tr>\r\n");
#nullable restore
#line 66 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Sec1&2-Mic Web Tech\Ass1\Khachig Kerbabian\StockTransactionApp\Views\Transactions\Index.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Transaction>> Html { get; private set; }
    }
}
#pragma warning restore 1591
