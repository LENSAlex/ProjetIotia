<<<<<<< HEAD
#pragma checksum "C:\Users\pd012752\Desktop\WEBProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Promotion\ListePromotion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c3f9e8996ae874d91073a201fc9e75cd6b1481e"
=======
#pragma checksum "C:\Users\ga304263\Source\Repos\ProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Promotion\ListePromotion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "08dd0d727d35fd9233e4ca47642381f78eb4b419"
>>>>>>> 113e30624732c6a407f49d483a3d959ca2e24bb1
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Smart_ECovid_IUT.Pages.Promotion.Pages_Promotion_ListePromotion), @"mvc.1.0.razor-page", @"/Pages/Promotion/ListePromotion.cshtml")]
namespace Smart_ECovid_IUT.Pages.Promotion
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
#line 1 "C:\Users\pd012752\Desktop\WEBProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\_ViewImports.cshtml"
using Smart_ECovid_IUT;

#line default
#line hidden
#nullable disable
#nullable restore
<<<<<<< HEAD
#line 3 "C:\Users\pd012752\Desktop\WEBProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Promotion\ListePromotion.cshtml"
using ClasseE_Covid.Promotion;
=======
#line 3 "C:\Users\ga304263\Source\Repos\ProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Promotion\ListePromotion.cshtml"
using ClasseE_Covid;
>>>>>>> 113e30624732c6a407f49d483a3d959ca2e24bb1

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c3f9e8996ae874d91073a201fc9e75cd6b1481e", @"/Pages/Promotion/ListePromotion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e99fb346a7d1c9e89043127974e0cace3f3918c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Promotion_ListePromotion : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div>
    <div class=""border-bottom mb-4"">
        <h1>Liste Promotion</h1>
    </div>
    <div class=""row"">
        <div class=""col-md-12 mb-4"">
            <div class=""card"">
                <div class=""card-header border-bottom"">
                    <h3>Liste Promotion</h3>
                </div>
                <div class="" table-responsive"">
                    <table class=""table table-striped"">
                        <thead>
                            <tr>
                                <th scope=""col"">Nom</th>
                                <th scope=""col"">Année</th>
                                <th scope=""col"">Durée</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
<<<<<<< HEAD
#line 27 "C:\Users\pd012752\Desktop\WEBProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Promotion\ListePromotion.cshtml"
                             foreach (PromotionClass promotion in Model.Branches)
=======
#line 27 "C:\Users\ga304263\Source\Repos\ProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Promotion\ListePromotion.cshtml"
                             foreach (GitHubBranch gitHubBranch in Model.Branches)
>>>>>>> 113e30624732c6a407f49d483a3d959ca2e24bb1
                            {



#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
<<<<<<< HEAD
#line 32 "C:\Users\pd012752\Desktop\WEBProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Promotion\ListePromotion.cshtml"
                                   Write(promotion.Nom);
=======
#line 32 "C:\Users\ga304263\Source\Repos\ProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Promotion\ListePromotion.cshtml"
                                   Write(gitHubBranch.Name);
>>>>>>> 113e30624732c6a407f49d483a3d959ca2e24bb1

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
<<<<<<< HEAD
#line 33 "C:\Users\pd012752\Desktop\WEBProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Promotion\ListePromotion.cshtml"
                                   Write(promotion.Annee);
=======
#line 33 "C:\Users\ga304263\Source\Repos\ProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Promotion\ListePromotion.cshtml"
                                   Write(gitHubBranch.Id);
>>>>>>> 113e30624732c6a407f49d483a3d959ca2e24bb1

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
<<<<<<< HEAD
#line 34 "C:\Users\pd012752\Desktop\WEBProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Promotion\ListePromotion.cshtml"
                                   Write(promotion.Duree);
=======
#line 34 "C:\Users\ga304263\Source\Repos\ProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Promotion\ListePromotion.cshtml"
                                   Write(gitHubBranch.Disponible);
>>>>>>> 113e30624732c6a407f49d483a3d959ca2e24bb1

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 36 "C:\Users\ga304263\Source\Repos\ProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Promotion\ListePromotion.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Smart_ECovid_IUT.Pages.Promotion.ListePromotionModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Smart_ECovid_IUT.Pages.Promotion.ListePromotionModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Smart_ECovid_IUT.Pages.Promotion.ListePromotionModel>)PageContext?.ViewData;
        public Smart_ECovid_IUT.Pages.Promotion.ListePromotionModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
