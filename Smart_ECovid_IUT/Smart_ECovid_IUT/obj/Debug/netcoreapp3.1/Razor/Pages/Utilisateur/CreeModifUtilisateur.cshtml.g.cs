#pragma checksum "C:\Users\ga304263\Source\Repos\ProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57b7d2de7dc6108637d91ff54de0982b94154601"
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
#line 1 "C:\Users\ga304263\Source\Repos\ProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\_ViewImports.cshtml"
using Smart_ECovid_IUT;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57b7d2de7dc6108637d91ff54de0982b94154601", @"/Pages/Utilisateur/CreeModifUtilisateur.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e99fb346a7d1c9e89043127974e0cace3f3918c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Utilisateur_CreeModifUtilisateur : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\ga304263\Source\Repos\ProjetIotia\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Utilisateur\CreeModifUtilisateur.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div>
    <div class=""border-bottom mb-4"">
        <h1> Création Utilisateur</h1>
    </div>
    <div class=""row"">
        <div class=""col-md-12 mb-4"">
            <div class=""card"">
                <div class=""card-header border-bottom"">
                    <h3>Création Utilisateur</h3>
                </div>
                <div class=""card-body border-bottom"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "57b7d2de7dc6108637d91ff54de0982b941546013883", async() => {
                WriteLiteral(@"
                        <div class=""form-row"">
                            <div class=""col-md-4 mb-3"">
                                <label for=""Nom"">Nom</label>
                                <input type=""text"" class=""form-control"" id=""Nom"" placeholder=""Nom"" required />
                            </div>
                            <div class=""col-md-4 mb-3"">
                                <label for=""Prenom"">Prénom</label>
                                <input type=""text"" class=""form-control"" id=""Prenom"" placeholder=""Prénom"" required />
                            </div>
                            <div class=""col-md-4 mb-3"">
                                <label for=""Promotion"">Promotion</label>
                                <input type=""text"" class=""form-control"" id=""Promotion"" placeholder=""Promotion""  required />
                            </div>
                        </div>
                        <div class=""form-row"">
                            <div class=""col-md-6 mb-3"">");
                WriteLiteral(@"
                                <label for=""validationDefault03"">City</label>
                                <input type=""text"" class=""form-control"" id=""validationDefault03"" placeholder=""City"" required>
                            </div>
                            <div class=""col-md-3 mb-3"">
                                <label for=""validationDefault04"">State</label>
                                <input type=""text"" class=""form-control"" id=""validationDefault04"" placeholder=""State"" required>
                            </div>
                            <div class=""col-md-3 mb-3"">
                                <label for=""validationDefault05"">Zip</label>
                                <input type=""text"" class=""form-control"" id=""validationDefault05"" placeholder=""Zip"" required>
                            </div>
                        </div>
                        <div class=""form-group"">
                            <div class=""form-check"">
                                <input class=""f");
                WriteLiteral("orm-check-input\" type=\"checkbox\"");
                BeginWriteAttribute("value", " value=\"", 2604, "\"", 2612, 0);
                EndWriteAttribute();
                WriteLiteral(@" id=""invalidCheck2"" required>
                                <label class=""form-check-label"" for=""invalidCheck2"">
                                    Agree to terms and conditions
                                </label>
                            </div>
                        </div>
                        <button class=""btn btn-primary"" type=""submit"">Submit form</button>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
