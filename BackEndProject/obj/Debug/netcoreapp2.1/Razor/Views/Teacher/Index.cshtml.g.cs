#pragma checksum "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a41cd556748ccbc6b8e7145d55a1530fc9658fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_Index), @"mvc.1.0.view", @"/Views/Teacher/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Teacher/Index.cshtml", typeof(AspNetCore.Views_Teacher_Index))]
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
#line 1 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\_ViewImports.cshtml"
using BackEndProject.ViewModels;

#line default
#line hidden
#line 2 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\_ViewImports.cshtml"
using BackEndProject.Models;

#line default
#line hidden
#line 3 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a41cd556748ccbc6b8e7145d55a1530fc9658fe", @"/Views/Teacher/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3901e7c2bbfb5a082ff900225b5567e29d38e7f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TeacherVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Teacher", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(18, 103, true);
            WriteLiteral("<!-- Banner Area Start -->\r\n<div class=\"banner-area-wrapper\">\r\n    <div class=\"banner-area text-center\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 121, "\"", 198, 5);
            WriteAttributeValue("", 129, "background-image:", 129, 17, true);
            WriteAttributeValue(" ", 146, "url(/img/banner/", 147, 17, true);
#line 4 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 163, Model.Background.Image, 163, 23, false);

#line default
#line hidden
            WriteAttributeValue("", 186, ")", 186, 1, true);
            WriteAttributeValue(" ", 187, "!important", 188, 11, true);
            EndWriteAttribute();
            BeginContext(199, 559, true);
            WriteLiteral(@">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-xs-12"">
                    <div class=""banner-content-wrapper"">
                        <div class=""banner-content"">
                            <h2>our teachers</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Banner Area End -->
<!-- Teacher Start -->
<div class=""teacher-area pt-150 pb-105"">
    <div class=""container"">
        <div class=""row"">
");
            EndContext();
#line 23 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
             foreach (Teacher teacher in Model.Teachers)
            {


#line default
#line hidden
            BeginContext(833, 201, true);
            WriteLiteral("                <div class=\"col-md-3 col-sm-4 col-xs-12\">\r\n                    <div class=\"single-teacher mb-45\">\r\n                        <div class=\"single-teacher-img\">\r\n                            ");
            EndContext();
            BeginContext(1034, 131, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ffca1af16e9468bae28dcd1bd83f063", async() => {
                BeginContext(1109, 4, true);
                WriteLiteral("<img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 1113, "\"", 1145, 2);
                WriteAttributeValue("", 1119, "img/teacher/", 1119, 12, true);
#line 29 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 1131, teacher.Image, 1131, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1146, 15, true);
                WriteLiteral(" alt=\"teacher\">");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 29 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
                                                                              WriteLiteral(teacher.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1165, 140, true);
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"single-teacher-content text-center\">\r\n                            <h2>");
            EndContext();
            BeginContext(1305, 92, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "885993d75eb544ffa9603f89def53330", async() => {
                BeginContext(1381, 12, false);
#line 32 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
                                                                                                      Write(teacher.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 32 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
                                                                                  WriteLiteral(teacher.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1397, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 33 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
                             foreach (AboutTeacher about in Model.AboutTeachers)
                            {
                                if (teacher.AboutTeacherId == about.Id)
                                {

#line default
#line hidden
            BeginContext(1625, 40, true);
            WriteLiteral("                                    <h4>");
            EndContext();
            BeginContext(1666, 16, false);
#line 37 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
                                   Write(about.Speciality);

#line default
#line hidden
            EndContext();
            BeginContext(1682, 111, true);
            WriteLiteral("</h4>\r\n                                    <ul>\r\n                                        <li><a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1793, "\"", 1815, 1);
#line 39 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 1800, about.Facebook, 1800, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1816, 108, true);
            WriteLiteral("><i class=\"zmdi zmdi-facebook\"></i></a></li>\r\n                                        <li><a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1924, "\"", 1947, 1);
#line 40 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 1931, about.Pinterest, 1931, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1948, 109, true);
            WriteLiteral("><i class=\"zmdi zmdi-pinterest\"></i></a></li>\r\n                                        <li><a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2057, "\"", 2076, 1);
#line 41 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 2064, about.Vimeo, 2064, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2077, 105, true);
            WriteLiteral("><i class=\"zmdi zmdi-vimeo\"></i></a></li>\r\n                                        <li><a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2182, "\"", 2203, 1);
#line 42 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 2189, about.Twitter, 2189, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2204, 88, true);
            WriteLiteral("><i class=\"zmdi zmdi-twitter\"></i></a></li>\r\n                                    </ul>\r\n");
            EndContext();
#line 44 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
                                }
                            }

#line default
#line hidden
            BeginContext(2358, 86, true);
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 50 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Teacher\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(2459, 56, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n<!-- Teacher End -->");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TeacherVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
