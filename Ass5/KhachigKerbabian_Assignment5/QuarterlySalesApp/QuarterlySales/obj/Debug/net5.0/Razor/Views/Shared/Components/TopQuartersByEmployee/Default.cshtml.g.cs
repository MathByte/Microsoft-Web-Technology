#pragma checksum "Z:\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Ass5\KhachigKerbabian_Assignment5\QuarterlySalesApp\QuarterlySales\Views\Shared\Components\TopQuartersByEmployee\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5c7cd10c6094aaa77a11ed79ec9c832ab315965"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_TopQuartersByEmployee_Default), @"mvc.1.0.view", @"/Views/Shared/Components/TopQuartersByEmployee/Default.cshtml")]
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
#line 1 "Z:\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Ass5\KhachigKerbabian_Assignment5\QuarterlySalesApp\QuarterlySales\Views\_ViewImports.cshtml"
using QuarterlySales;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "Z:\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Ass5\KhachigKerbabian_Assignment5\QuarterlySalesApp\QuarterlySales\Views\_ViewImports.cshtml"
using QuarterlySales.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "Z:\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Ass5\KhachigKerbabian_Assignment5\QuarterlySalesApp\QuarterlySales\Views\_ViewImports.cshtml"
using QuarterlySales.Components;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5c7cd10c6094aaa77a11ed79ec9c832ab315965", @"/Views/Shared/Components/TopQuartersByEmployee/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17f2c016b455773af20e530e6344932783d1834c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_TopQuartersByEmployee_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TopQuartersByEmployeeModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h4>Top Quarters by Employee</h4>\r\n\r\n<ul>\r\n\t<!-- loop thru our top movies: -->\r\n");
#nullable restore
#line 7 "Z:\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Ass5\KhachigKerbabian_Assignment5\QuarterlySalesApp\QuarterlySales\Views\Shared\Components\TopQuartersByEmployee\Default.cshtml"
     for (int i = 0; i < Model.NumberOfQuartersToDisplay; i++)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<li>\r\n\t\t\t<div class=\"row\">\r\n\t\t\t\t<span class=\"col-sm-4 \" style=\"padding-right: 0px;  margin-right: 0px; margin-left: 0px; \">");
#nullable restore
#line 11 "Z:\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Ass5\KhachigKerbabian_Assignment5\QuarterlySalesApp\QuarterlySales\Views\Shared\Components\TopQuartersByEmployee\Default.cshtml"
                                                                                                       Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral(". ");
#nullable restore
#line 11 "Z:\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Ass5\KhachigKerbabian_Assignment5\QuarterlySalesApp\QuarterlySales\Views\Shared\Components\TopQuartersByEmployee\Default.cshtml"
                                                                                                                Write(Model.NumberOfQuartersIntermsOfSale[@i].Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Q ");
#nullable restore
#line 11 "Z:\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Ass5\KhachigKerbabian_Assignment5\QuarterlySalesApp\QuarterlySales\Views\Shared\Components\TopQuartersByEmployee\Default.cshtml"
                                                                                                                                                                Write(Model.NumberOfQuartersIntermsOfSale[@i].Quarter);

#line default
#line hidden
#nullable disable
            WriteLiteral(":</span>\r\n\t\t\t\t<div class=\"col-sm-2 font-weight-bold\" style=\"padding-right: 0px; padding-left: 0px;\">&#36;");
#nullable restore
#line 12 "Z:\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Ass5\KhachigKerbabian_Assignment5\QuarterlySalesApp\QuarterlySales\Views\Shared\Components\TopQuartersByEmployee\Default.cshtml"
                                                                                                      Write(Model.NumberOfQuartersIntermsOfSale[@i].Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\t\t\t</div>\r\n\r\n\t\t\t<div class=\"row col-sm-10\" style=\"margin-left: 5px; margin-bottom: 15px; \">\r\n\t\t\t\t<span class=\"rounded bg-primary\" style=\"padding-left: 10px; padding-right: 10px;\"  >");
#nullable restore
#line 16 "Z:\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Ass5\KhachigKerbabian_Assignment5\QuarterlySalesApp\QuarterlySales\Views\Shared\Components\TopQuartersByEmployee\Default.cshtml"
                                                                                               Write(Model.NumberOfQuartersIntermsOfSale[@i].Employee.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n\t\t\t</div>\r\n\r\n\r\n\r\n\t\t</li>\r\n");
#nullable restore
#line 22 "Z:\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Ass5\KhachigKerbabian_Assignment5\QuarterlySalesApp\QuarterlySales\Views\Shared\Components\TopQuartersByEmployee\Default.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TopQuartersByEmployeeModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
