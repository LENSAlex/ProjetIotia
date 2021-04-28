#pragma checksum "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c91b6bdc97c72e8e1236155fb017a89ffdf2786f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Smart_ECovid_IUT.Pages.Capteur.Pages_Capteur_AfficheCapteur), @"mvc.1.0.razor-page", @"/Pages/Capteur/AfficheCapteur.cshtml")]
namespace Smart_ECovid_IUT.Pages.Capteur
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
#line 3 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
using ClasseE_Covid.Capteur;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c91b6bdc97c72e8e1236155fb017a89ffdf2786f", @"/Pages/Capteur/AfficheCapteur.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e99fb346a7d1c9e89043127974e0cace3f3918c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Capteur_AfficheCapteur : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div>
    <div class=""border-bottom mb-4"">
        <h1>Liste log etat plateforme</h1>
    </div>
    <div class=""row"">
        <div class=""col-md-12 mb-4"">
            <div class=""card"">
                <div class=""card-header border-bottom"">
                    <h3>Liste Capteur Temp</h3>
                </div>
                <div class=""table-responsive"">
                    <table class=""table table-striped"">
                        <thead>
                            <tr>
                                <th scope=""col"">Nom</th>
                                <th scope=""col"">Box</th>
                                <th scope=""col"">°C</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 27 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                             foreach (Temperature temperature in Model.Temperature)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 30 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                                   Write(temperature.NomTemp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 31 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                                   Write(temperature.NomBox);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 32 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                                   Write(temperature.ValeurTemp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 34 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class=""col-md-6 mb-4"">
            <div class=""card"">
                <div class=""card-header border-bottom"">
                    <h3>Liste Capteur Co2</h3>
                </div>
                <div class=""table-responsive"">
                    <table class=""table table-striped"">
                        <thead>
                            <tr>
                                <th scope=""col"">Nom</th>
                                <th scope=""col"">Box</th>
                                <th scope=""col"">gaz m²</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 56 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                             foreach (Co2 co2 in Model.Co2)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 59 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                                   Write(co2.NomCo2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 60 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                                   Write(co2.NomBox);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 61 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                                   Write(co2.ValeurCo2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 63 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class=""col-md-6 mb-4"">
            <div class=""card"">
                <div class=""card-header border-bottom"">
                    <h3>Liste Box Energie</h3>
                </div>
                <div class=""table-responsive"">
                    <table class=""table table-striped"">
                        <thead>
                            <tr>
                                <th scope=""col"">Box</th>
                                <th scope=""col"">Watt</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 84 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                             foreach (Energie nrj in Model.Energie)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 87 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                                   Write(nrj.NomBox);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 88 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                                   Write(nrj.ValeurEnergie);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 90 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Capteur\AfficheCapteur.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tr>

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class=""col-md-6 mb-4"">
            <div class=""card"">
                <div class=""card-header border-bottom"">
                    <h3>Liste Capteur Taux occupation</h3>
                </div>
                <div class=""table-responsive"">
                    <table class=""table table-striped"">
                        <thead>
                            <tr>
                                <th scope=""col"">Nom</th>
                                <th scope=""col"">Box</th>
                                <th scope=""col"">°C</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th scope=""row"">CO2</th>
                                <td>Box - 1</td>
                                <td>95%</td>
                  ");
            WriteLiteral(@"          </tr>
                            <tr>
                                <th scope=""row"">Température</th>
                                <td>Box - 52</td>
                                <td>10%</td>
                            </tr>
                            <tr>
                                <th scope=""row"">RFIS</th>
                                <td>Box - 628</td>
                                <td>36%</td>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Smart_ECovid_IUT.Pages.Capteur.AfficheCapteurModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Smart_ECovid_IUT.Pages.Capteur.AfficheCapteurModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Smart_ECovid_IUT.Pages.Capteur.AfficheCapteurModel>)PageContext?.ViewData;
        public Smart_ECovid_IUT.Pages.Capteur.AfficheCapteurModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
