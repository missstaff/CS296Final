#pragma checksum "F:\School\CS296\CS296Final\StephenKingFanSite\Views\Trivia\Scores.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65ad7b2c998d3b6c3938ef22009972790d965374"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Trivia_Scores), @"mvc.1.0.view", @"/Views/Trivia/Scores.cshtml")]
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
#line 1 "F:\School\CS296\CS296Final\StephenKingFanSite\Views\_ViewImports.cshtml"
using StephenKingFanSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\School\CS296\CS296Final\StephenKingFanSite\Views\_ViewImports.cshtml"
using StephenKingFanSite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65ad7b2c998d3b6c3938ef22009972790d965374", @"/Views/Trivia/Scores.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4e3ff34658e5f9f4c422d3ce30dad5ba81993ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Trivia_Scores : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Scores>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\School\CS296\CS296Final\StephenKingFanSite\Views\Trivia\Scores.cshtml"
  
    ViewData["Title"] = "Scores Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""text-center"">
    <h1 class=""display-4 font-weight-bold"">King of Horror</h1>
</div>

<h2 class=""text-center"">Scores</h2>
<br />

<table class=""table table-striped"">
    <thead>
        <tr>
            <th>
               Username
            </th>
            <th>
               Score
            </th>
            <th>
               Ranking
            </th>
            <th>
                Date
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 30 "F:\School\CS296\CS296Final\StephenKingFanSite\Views\Trivia\Scores.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 34 "F:\School\CS296\CS296Final\StephenKingFanSite\Views\Trivia\Scores.cshtml"
               Write(item.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 37 "F:\School\CS296\CS296Final\StephenKingFanSite\Views\Trivia\Scores.cshtml"
               Write(item.Score);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 40 "F:\School\CS296\CS296Final\StephenKingFanSite\Views\Trivia\Scores.cshtml"
               Write(item.Ranking);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 43 "F:\School\CS296\CS296Final\StephenKingFanSite\Views\Trivia\Scores.cshtml"
               Write(item.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tr>\r\n");
#nullable restore
#line 45 "F:\School\CS296\CS296Final\StephenKingFanSite\Views\Trivia\Scores.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Scores>> Html { get; private set; }
    }
}
#pragma warning restore 1591
