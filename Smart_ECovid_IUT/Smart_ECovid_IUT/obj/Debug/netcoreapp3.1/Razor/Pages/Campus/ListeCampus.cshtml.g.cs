#pragma checksum "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Campus\ListeCampus.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5df5b87cfa2faefcc17ce2c3b62589250f31614"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Smart_ECovid_IUT.Pages.Campus.Pages_Campus_ListeCampus), @"mvc.1.0.razor-page", @"/Pages/Campus/ListeCampus.cshtml")]
namespace Smart_ECovid_IUT.Pages.Campus
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
#line 3 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Campus\ListeCampus.cshtml"
using ClasseE_Covid.Campus;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5df5b87cfa2faefcc17ce2c3b62589250f31614", @"/Pages/Campus/ListeCampus.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e99fb346a7d1c9e89043127974e0cace3f3918c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Campus_ListeCampus : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Utilisateur/CreeModifUtilisateur", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<div>
    <div class=""border-bottom mb-4"">
        <h1>Liste Campus</h1>
    </div>
    <div class=""row"">
        <div class=""col-md-12 mb-4"">
            <div class=""card"">
                <div class=""card-header border-bottom"">
                    <h3>Liste Campus</h3>
                </div>
                <div class="" table-responsive"">
                    <table class=""table table-striped"">
                        <thead>
                            <tr>
                                <th scope=""col"">Campus</th>
                                <th scope=""col"">Batiment</th>
                                <th scope=""col"">N°Etage</th>
                                <th scope=""col"">N°Salle</th>
                                <th scope=""col"">Action</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 29 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Campus\ListeCampus.cshtml"
                             foreach (Campus campus in Model.Branches)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n\r\n                                    <td>");
#nullable restore
#line 33 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Campus\ListeCampus.cshtml"
                                   Write(campus.NomCampus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 35 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Campus\ListeCampus.cshtml"
                                         foreach (Campus campus2 in Model.Branches2)
                                        {
                                            if (campus2.IdBatiment == campus.IdCampusBatiment)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <p>");
#nullable restore
#line 39 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Campus\ListeCampus.cshtml"
                                              Write(campus2.IdBatiment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 40 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Campus\ListeCampus.cshtml"
                                            }

                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>");
#nullable restore
#line 44 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Campus\ListeCampus.cshtml"
                                   Write(campus.NBEtageCampus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 45 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Campus\ListeCampus.cshtml"
                                   Write(campus.NBSalleCampus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5df5b87cfa2faefcc17ce2c3b62589250f316147248", async() => {
                WriteLiteral("<i class=\"far fa-edit\"></i>\"");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5df5b87cfa2faefcc17ce2c3b62589250f316148466", async() => {
                WriteLiteral("<i class=\"far fa-trash-alt\"></i>\"");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 51 "D:\TAFF\IOTIATravaille\CourAcctuelle\ProjetFinAnnee\Smart_ECovid_IUT\Smart_ECovid_IUT\Pages\Campus\ListeCampus.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Smart_ECovid_IUT.Pages.Campus.ListeCampusModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Smart_ECovid_IUT.Pages.Campus.ListeCampusModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Smart_ECovid_IUT.Pages.Campus.ListeCampusModel>)PageContext?.ViewData;
        public Smart_ECovid_IUT.Pages.Campus.ListeCampusModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
