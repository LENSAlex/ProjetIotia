#pragma checksum "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3102f345e9dec347673cbbaf2ae590f377a967e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Smart_ECovid_IUT.Pages.Utilisateur.Pages_Utilisateur_CreeModifUtilisateur), @"mvc.1.0.razor-page", @"/Pages/Utilisateur/CreeModifUtilisateur.cshtml")]
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
#line 3 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
using ClasseE_Covid.Utilisateur;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
using ClasseE_Covid.Promotion;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id:int?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3102f345e9dec347673cbbaf2ae590f377a967e2", @"/Pages/Utilisateur/CreeModifUtilisateur.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e99fb346a7d1c9e89043127974e0cace3f3918c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Utilisateur_CreeModifUtilisateur : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "F", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "H", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "EnvoieDonne", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"border-bottom mb-4\">\r\n        <h1 class=\"letest\"> ");
#nullable restore
#line 10 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                        Write(Model.ModifUser != null ? "Modifer une Utilisateur" : "Création une Utilisateur");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
    </div>
    <div class=""row"">
        <div class=""col-md-12 mb-4"">
            <div class=""card"">
                <div class=""card-header border-bottom"">
                    <h3>Création Utilisateur</h3>
                </div>
                <div class=""card-body border-bottom"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3102f345e9dec347673cbbaf2ae590f377a967e27583", async() => {
                WriteLiteral(@"
                        <div class=""form-row"">
                            <div class=""col-md-4 mb-3"">
                                <label for=""Nom"">Nom</label>
                                <input type=""text"" class=""form-control"" id=""nom"" name=""nom""");
                BeginWriteAttribute("value", " value=\"", 974, "\"", 1040, 1);
#nullable restore
#line 23 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
WriteAttributeValue("", 982, Model.ModifUser != null ? Model.utilisateur?.Nom : null, 982, 58, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"  placeholder=""Nom"" required />
                            </div>
                            <div class=""col-md-4 mb-3"">
                                <label for=""Prenom"">Prénom</label>
                                <input type=""text"" class=""form-control"" id=""prenom""");
                BeginWriteAttribute("value", " value=\"", 1318, "\"", 1386, 1);
#nullable restore
#line 27 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
WriteAttributeValue("", 1326, Model.ModifUser != null ? Model.utilisateur?.Prenom :null, 1326, 60, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" name=""prenom"" placeholder=""Prénom"" required />
                            </div>
                            <div class=""col-md-4 mb-3"">
                                <label for=""validationDefault03"">Email</label>
                                <input type=""text"" class=""form-control"" id=""email""");
                BeginWriteAttribute("value", " value=\"", 1691, "\"", 1759, 1);
#nullable restore
#line 31 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
WriteAttributeValue("", 1699, Model.ModifUser != null ? Model.utilisateur?.Email : null, 1699, 60, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" name=""email"" placeholder=""coco@iut-nice.fr"" required>
                            </div>
                        </div>
                        <div class=""form-row"">
                            <div class=""col-md-6 mb-3"">
                                <label for=""validationDefault04"">Mot de passe</label>
                                <input type=""password"" class=""form-control verif"" id=""pwd"" name=""pwd"" placeholder=""Mf65$"" required>
                            </div>
                            <div class=""col-md-6 mb-3"">
                                <label for=""validationDefault04"">Vérification mot de passe</label>
                                <input type=""password"" class=""form-control verif2"" id=""pwd2"" name=""pwd2"" placeholder=""Mf65$"" required>
                            </div>
                        </div>
                        <div class=""form-row"">
                            <div class=""col-md-4 mb-3"">
                                <label for=""validationDefault03"">Formatio");
                WriteLiteral("n</label>\r\n                                <select class=\"form-control select\" aria-hidden=\"true\" id=\"formation\" name=\"formation\">\r\n");
                WriteLiteral("                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3102f345e9dec347673cbbaf2ae590f377a967e211460", async() => {
#nullable restore
#line 49 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                                                                                                                     Write(Model.ModifUser != null ? Model.utilisateur?.Promotion : 0);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 49 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                                            WriteLiteral(Model.ModifUser != null ? Model.utilisateur?.Promotion : null);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 50 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                                        if (Model.DDPromotion != null)
                                        {
                                            foreach (PromotionClass promo in Model.DDPromotion)
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3102f345e9dec347673cbbaf2ae590f377a967e214176", async() => {
#nullable restore
#line 54 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                                                                     Write(promo.Nom);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 54 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                                                   WriteLiteral(promo.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 55 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                                            }
                                        }
                                    

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </select>
                            </div>
                            <div class=""col-md-4 mb-3"">
                                <label for=""validationDefault04"">Niveau</label>
                                <select class=""form-control select"" aria-hidden=""true"" id=""niveau"" name=""niveau"">
");
                WriteLiteral("                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3102f345e9dec347673cbbaf2ae590f377a967e216990", async() => {
                    WriteLiteral(" ");
#nullable restore
#line 64 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                                                                                                                   Write(Model.ModifUser != null ? Model.utilisateur?.Niveau : "--Selectionner Niveau--");

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 64 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                                            WriteLiteral(Model.ModifUser != null ? Model.utilisateur?.Niveau : null);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 65 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"

                                        if (Model.DDNiveau != null)
                                        {
                                            foreach (Niveau niveau in Model.DDNiveau)
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3102f345e9dec347673cbbaf2ae590f377a967e219751", async() => {
#nullable restore
#line 70 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                                                                            Write(niveau.LeNiveau);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 70 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                                                   WriteLiteral(niveau.IdNiveau);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 71 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                                            }
                                        }
                                    

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </select>
                            </div>
                            <div class=""col-md-4 mb-3"">
                                <label for=""validationDefault04"">Numéro référencielle </label>
                                <input type=""text"" class=""form-control""");
                BeginWriteAttribute("value", " value=\"", 5004, "\"", 5073, 1);
#nullable restore
#line 78 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
WriteAttributeValue("", 5012, Model.ModifUser != null ? Model.utilisateur?.Niveau : null, 5012, 61, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" id=""num_ref"" name=""num_ref"" placeholder=""Num_ref"" required>
                            </div>
                        </div>
                        <div class=""form-row"">
                            <div class=""col-md-4 mb-3"">
                                <label for=""validationDefault03"">Tel </label>
                                <input type=""text"" class=""form-control"" id=""tel"" name=""tel""");
                BeginWriteAttribute("value", " value=\"", 5479, "\"", 5551, 1);
#nullable restore
#line 84 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
WriteAttributeValue("", 5487, Model.ModifUser != null ? Model.utilisateur?.Telephone : null, 5487, 64, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""0625639874"" required>
                            </div>
                            <div class=""col-md-4 mb-3"">
                                <label for=""validationDefault04"">Sexe</label>
                                <select class=""form-control select"" aria-hidden=""true"" id=""sexe"" name=""sexe"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3102f345e9dec347673cbbaf2ae590f377a967e224229", async() => {
                    WriteLiteral("\"");
#nullable restore
#line 89 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                                                                                                             Write(Model.ModifUser != null ? Model.utilisateur?.Sexe : "--Selectionner Sexe--");

#line default
#line hidden
#nullable disable
                    WriteLiteral("\"");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 89 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
                                        WriteLiteral(Model.ModifUser != null ? Model.utilisateur?.Sexe : null);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3102f345e9dec347673cbbaf2ae590f377a967e226508", async() => {
                    WriteLiteral("Femme");
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
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3102f345e9dec347673cbbaf2ae590f377a967e227767", async() => {
                    WriteLiteral("Homme");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                </select>
                            </div>
                            <div class=""col-md-4 mb-3"">
                                <label for=""validationDefault04"">Anniversaire</label>
                                <input type=""text""");
                BeginWriteAttribute("value", "  value=\"", 6488, "\"", 6557, 1);
#nullable restore
#line 96 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
WriteAttributeValue("", 6497, Model.ModifUser != null ? Model.utilisateur?.Anniv : null, 6497, 60, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control dateAnniv\" id=\"anniv\" name=\"anniv\" placeholder=\"1968-08-11\" required>\r\n                            </div>\r\n                        </div>\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3102f345e9dec347673cbbaf2ae590f377a967e229942", async() => {
                    WriteLiteral("Envoier");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3102f345e9dec347673cbbaf2ae590f377a967e232650", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script type=""text/javascript"">

    $("".verif2"").keyup(function (e) {
        var verif = $(this).val();
        var pass1 = $('.verif').val();

        if ($(this).val().length == $('.verif').val().length && verif != null) {
            if (verif != pass1)
                alert(""ATTENTION LES 2 MOT DE PASSE NE SONT PAS IDENTIQUE"")
        }
    })

    $("".dateAnniv"").keyup(function (e) {
        var rech = $(this).val();

        var max = 10;

        if ($(this).val().length >= max) {
            $(this).val(rech.substr(0, max));
        }

        $(this).val($(this).val().replace(/[a-zA-Z]/, """"));

        var max = parseInt($(this).attr('max'));
        var min = ""01"";

        if ($(this).val().length == 11) {
            $(this).val($(this).val().replace(/./, """"));
        }

        if (($(this).val().length == 4 && $(this).val()[1] != ""-"" && event.which != 11) || ($(this).val().length == 7 && $(this).val()[1] != ""-"" && event.which != 11)) {
            if ($(this).");
            WriteLiteral("val() > max) {\r\n                $(this).val(max);\r\n            }\r\n            else if ($(this).val() < min) {\r\n                $(this).val(min);\r\n            }\r\n            $(this).val($(this).val() + \"-\");\r\n        }\r\n    })\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Smart_ECovid_IUT.Pages.Utilisateur.CreeModifUtilisateurModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Smart_ECovid_IUT.Pages.Utilisateur.CreeModifUtilisateurModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Smart_ECovid_IUT.Pages.Utilisateur.CreeModifUtilisateurModel>)PageContext?.ViewData;
        public Smart_ECovid_IUT.Pages.Utilisateur.CreeModifUtilisateurModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
