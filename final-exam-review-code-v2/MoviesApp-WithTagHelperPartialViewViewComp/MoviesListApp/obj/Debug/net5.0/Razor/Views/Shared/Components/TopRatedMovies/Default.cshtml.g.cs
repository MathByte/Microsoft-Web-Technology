#pragma checksum "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Final exam review Code\final-exam-review-code-v2\MoviesApp-WithTagHelperPartialViewViewComp\MoviesListApp\Views\Shared\Components\TopRatedMovies\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3375b8c24f3e9d67ddebb48f6601a8f21a8f4d51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_TopRatedMovies_Default), @"mvc.1.0.view", @"/Views/Shared/Components/TopRatedMovies/Default.cshtml")]
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
#line 1 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Final exam review Code\final-exam-review-code-v2\MoviesApp-WithTagHelperPartialViewViewComp\MoviesListApp\Views\_ViewImports.cshtml"
using MoviesListApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Final exam review Code\final-exam-review-code-v2\MoviesApp-WithTagHelperPartialViewViewComp\MoviesListApp\Views\_ViewImports.cshtml"
using MoviesListApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Final exam review Code\final-exam-review-code-v2\MoviesApp-WithTagHelperPartialViewViewComp\MoviesListApp\Views\_ViewImports.cshtml"
using MoviesListApp.Components;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3375b8c24f3e9d67ddebb48f6601a8f21a8f4d51", @"/Views/Shared/Components/TopRatedMovies/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2ee97b4aec4871b66a67fccc774157c363e0eb5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_TopRatedMovies_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TopRatedMoviesViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h3>To Rated Movies</h3>\r\n<h6>With a rating of at least ");
#nullable restore
#line 4 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Final exam review Code\final-exam-review-code-v2\MoviesApp-WithTagHelperPartialViewViewComp\MoviesListApp\Views\Shared\Components\TopRatedMovies\Default.cshtml"
                         Write(Model.LowestRating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n<ul>\r\n    <!-- loop thru our top movies: -->\r\n");
#nullable restore
#line 7 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Final exam review Code\final-exam-review-code-v2\MoviesApp-WithTagHelperPartialViewViewComp\MoviesListApp\Views\Shared\Components\TopRatedMovies\Default.cshtml"
     for (int i = 0; i < Model.NumberOfMoviesToDisplay; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>");
#nullable restore
#line 9 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Final exam review Code\final-exam-review-code-v2\MoviesApp-WithTagHelperPartialViewViewComp\MoviesListApp\Views\Shared\Components\TopRatedMovies\Default.cshtml"
       Write(Model.Movies[@i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 9 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Final exam review Code\final-exam-review-code-v2\MoviesApp-WithTagHelperPartialViewViewComp\MoviesListApp\Views\Shared\Components\TopRatedMovies\Default.cshtml"
                               Write(Model.Movies[@i].Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 9 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Final exam review Code\final-exam-review-code-v2\MoviesApp-WithTagHelperPartialViewViewComp\MoviesListApp\Views\Shared\Components\TopRatedMovies\Default.cshtml"
                                                      Write(Model.Movies[@i].Genre.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</li>\r\n");
#nullable restore
#line 10 "C:\Users\khach\Documents\Conestoga\2021-2022\PROG2230-21F-Mic Web Tech\Final exam review Code\final-exam-review-code-v2\MoviesApp-WithTagHelperPartialViewViewComp\MoviesListApp\Views\Shared\Components\TopRatedMovies\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TopRatedMoviesViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
