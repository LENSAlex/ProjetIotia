#pragma checksum "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\LogAlerte\AfficheLogAlerte.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e5315cce6f56834120bacfcf839a0354be124a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Smart_ECovid_IUT.Pages.LogAlerte.Pages_LogAlerte_AfficheLogAlerte), @"mvc.1.0.razor-page", @"/Pages/LogAlerte/AfficheLogAlerte.cshtml")]
namespace Smart_ECovid_IUT.Pages.LogAlerte
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
#line 1 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\_ViewImports.cshtml"
using Smart_ECovid_IUT;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\LogAlerte\AfficheLogAlerte.cshtml"
using ClasseE_Covid.LogAlerte;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e5315cce6f56834120bacfcf839a0354be124a4", @"/Pages/LogAlerte/AfficheLogAlerte.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e99fb346a7d1c9e89043127974e0cace3f3918c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_LogAlerte_AfficheLogAlerte : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div>
    <div class=""border-bottom mb-4"">
        <h1>Liste Log d'alerte</h1>
    </div>
    <div class=""row"">
        <div class=""col-md-6 mb-4"">
            <div class=""card"">
                <div class=""card-header border-bottom"">
                    <h3>Liste cas Covid-19</h3>
                </div>
                <div class="" table-responsive"">
                    <table class=""table table-striped"">
                        <thead>
                            <tr>
                                <th scope=""col"">Nom</th>
                                <th scope=""col"">prenom</th>
                                <th scope=""col"">Date</th>
                            </tr>
                        </thead>
");
#nullable restore
#line 26 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\LogAlerte\AfficheLogAlerte.cshtml"
                         foreach (LogAlerte logAlerte in Model.Branches)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 29 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\LogAlerte\AfficheLogAlerte.cshtml"
                               Write(logAlerte.nomCasCovid);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 30 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\LogAlerte\AfficheLogAlerte.cshtml"
                               Write(logAlerte.prenomCasCovid);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 31 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\LogAlerte\AfficheLogAlerte.cshtml"
                               Write(logAlerte.DateCasCovid);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 33 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\LogAlerte\AfficheLogAlerte.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </table>
                </div>
            </div>
        </div>
        <div class=""col-md-6 mb-4"">
            <div class=""card"">
                <div class=""card-header border-bottom"">
                    <h3>Liste dépassement de Co2</h3>
                </div>
                <div class="" table-responsive"">
                    <table class=""table table-striped"">
                        <thead>
                            <tr>
                                <th scope=""col"">Campus</th>
                                <th scope=""col"">Batiment</th>
                                <th scope=""col"">etage</th>
                                <th scope=""col"">Salle</th>
                                <th scope=""col"">Horaire</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th scope=""row"">Carlone</th>
                                <td><p>Phycologie</p");
            WriteLiteral(@"></td>
                                <td>3</td>
                                <td>305</td>
                                <td>12/02/2021 14:25:23</td>
                            </tr>
                            <tr>
                                <th scope=""row"">Shophia</th>
                                <td><p>Informatique</p></td>
                                <td>1</td>
                                <td>206</td>
                                <td>28/11/2020 9:23:59</td>
                            </tr>
                            <tr>
                                <th scope=""row"">Fabron</th>
                                <td><p>Reseau</p></td>
                                <td>2</td>
                                <td>305</td>
                                <td>07/03/2021 17:56:43</td>
                            </tr>

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Smart_ECovid_IUT.Pages.LogAlerte.AfficheLogAlerteModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Smart_ECovid_IUT.Pages.LogAlerte.AfficheLogAlerteModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Smart_ECovid_IUT.Pages.LogAlerte.AfficheLogAlerteModel>)PageContext?.ViewData;
        public Smart_ECovid_IUT.Pages.LogAlerte.AfficheLogAlerteModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
