#pragma checksum "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be3fe6d96047360dbbfd71ae9cf12e87a3ba5348"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Smart_ECovid_IUT.Pages.Utilisateur.Pages_Utilisateur_ListeUtilisateur), @"mvc.1.0.razor-page", @"/Pages/Utilisateur/ListeUtilisateur.cshtml")]
namespace Smart_ECovid_IUT.Pages.Utilisateur
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
#line 3 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
using ClasseE_Covid.Utilisateur;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be3fe6d96047360dbbfd71ae9cf12e87a3ba5348", @"/Pages/Utilisateur/ListeUtilisateur.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e99fb346a7d1c9e89043127974e0cace3f3918c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Utilisateur_ListeUtilisateur : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "/Utilisateur/ListeUtilisateur", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("supp"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div>
    <div class=""border-bottom mb-4"">
        <h1>Liste Utilisateur</h1>
    </div>
    <div class=""row"">
        <div class=""col-md-12 mb-4"">
            <div class=""card"">
                <div class=""card-header border-bottom"">
                    <h3>Liste Utilisateur</h3>
                </div>
                <div class=""table-responsive"">
                    <table class=""table table-striped"">
                        <thead>
                            <tr>
                                <th scope=""col"">Nom</th>
                                <th scope=""col"">Prénom</th>
                                <th scope=""col"">Sexe</th>
                                <th scope=""col"">Anniversere</th>
                                <th scope=""col"">EMail</th>
                                <th scope=""col"">Formation</th>
                                <th scope=""col"">Niveau</th>
                                <th scope=""col"">Téléphone</th>
                                <th scope=""c");
            WriteLiteral("ol\">INE / NUMEN</th>\r\n                                <th scope=\"col\">Action</th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 34 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                             if (Model.Branches != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                 foreach (Utilisateur user in Model.Branches)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n\r\n                                        <td>");
#nullable restore
#line 40 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                       Write(user.Nom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 41 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                       Write(user.Prenom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 42 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                       Write(user.Sexe);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 43 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                       Write(user.Anniv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 44 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                       Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 45 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                       Write(user.NomFormation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 46 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                       Write(user.Niveau);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 47 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                       Write(user.Telephone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 48 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                       Write(user.NumRef);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be3fe6d96047360dbbfd71ae9cf12e87a3ba534810053", async() => {
                WriteLiteral("<i class=\"far fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
            WriteLiteral("/Utilisateur/ListeUtilisateur/");
#nullable restore
#line 50 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                                                             WriteLiteral(user.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be3fe6d96047360dbbfd71ae9cf12e87a3ba534811894", async() => {
                WriteLiteral("<i class=\"far fa-trash-alt\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 51 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                                                                              Write(user.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 54 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\ListeUtilisateur.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be3fe6d96047360dbbfd71ae9cf12e87a3ba534814600", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script type=""text/javascript"">
    $("".supp"").click(function (e) {

        var id = $(this).data('id');
        var res = confirm(""Êtes-vous sûr de vouloir supprimer?"");
        if (res) {
            $.ajax({
                type: ""GET"",
                url: ""?handler=DeleteUser"",
                data: {
                    id: id,
                }
            }).done(function (result) {
                window.location.href(""/Utilisateur/ListeUtilisateur"");
            })
        }
        else {
            alert(""vous n'aver rien supprimer"")
        }
    })
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Smart_ECovid_IUT.Pages.Utilisateur.ListeUtilisateurModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Smart_ECovid_IUT.Pages.Utilisateur.ListeUtilisateurModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Smart_ECovid_IUT.Pages.Utilisateur.ListeUtilisateurModel>)PageContext?.ViewData;
        public Smart_ECovid_IUT.Pages.Utilisateur.ListeUtilisateurModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
