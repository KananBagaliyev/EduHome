#pragma checksum "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58574ee774547277ee4fbdc5a6fd9bb24b94b868"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_About_Index), @"mvc.1.0.view", @"/Views/About/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/About/Index.cshtml", typeof(AspNetCore.Views_About_Index))]
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
#line 1 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/_ViewImports.cshtml"
using BackEndProject.ViewModels;

#line default
#line hidden
#line 2 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/_ViewImports.cshtml"
using BackEndProject.Models;

#line default
#line hidden
#line 3 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58574ee774547277ee4fbdc5a6fd9bb24b94b868", @"/Views/About/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f6a7137cbfc21f64254730f2e3df1d47d27077f", @"/Views/_ViewImports.cshtml")]
    public class Views_About_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AboutVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("about"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(15, 102, true);
            WriteLiteral("\n<!-- Banner Area Start -->\n<div class=\"banner-area-wrapper\">\n    <div class=\"banner-area text-center\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 117, "\"", 194, 5);
            WriteAttributeValue("", 125, "background-image:", 125, 17, true);
            WriteAttributeValue(" ", 142, "url(/img/banner/", 143, 17, true);
#line 5 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
WriteAttributeValue("", 159, Model.Background.Image, 159, 23, false);

#line default
#line hidden
            WriteAttributeValue("", 182, ")", 182, 1, true);
            WriteAttributeValue(" ", 183, "!important", 184, 11, true);
            EndWriteAttribute();
            BeginContext(195, 644, true);
            WriteLiteral(@">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-xs-12"">
                    <div class=""banner-content-wrapper"">
                        <div class=""banner-content"">
                            <h2>about us</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Banner Area End -->
<!-- About Start -->
<div class=""about-area pt-145 pb-155"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-6 col-sm-6"">
                <div class=""about-content"">
                    <h2>");
            EndContext();
            BeginContext(840, 20, false);
#line 26 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                   Write(Model.AboutUs.Header);

#line default
#line hidden
            EndContext();
            BeginContext(860, 29, true);
            WriteLiteral("</h2>\n                    <p>");
            EndContext();
            BeginContext(890, 21, false);
#line 27 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                  Write(Model.AboutUs.Content);

#line default
#line hidden
            EndContext();
            BeginContext(911, 46, true);
            WriteLiteral("</p>\n                    <p class=\"hidden-sm\">");
            EndContext();
            BeginContext(958, 26, false);
#line 28 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                                    Write(Model.AboutUs.ShortContent);

#line default
#line hidden
            EndContext();
            BeginContext(984, 220, true);
            WriteLiteral("</p>\n                    <a class=\"default-btn\" href=\"#\">view courses</a>\n                </div>\n            </div>\n            <div class=\"col-md-6 col-sm-6\">\n                <div class=\"about-img\">\n                    ");
            EndContext();
            BeginContext(1204, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fd2e0592e8214226b6cc77a779699aab", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1214, "~/img/about/", 1214, 12, true);
#line 34 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
AddHtmlAttributeValue("", 1226, Model.AboutUs.Image, 1226, 20, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1260, 493, true);
            WriteLiteral(@"
                </div>
            </div>
        </div>
    </div>
</div>
<!-- About End -->
<!-- Teacher Start -->
<div class=""teacher-area pb-150"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-xs-12"">
                <div class=""section-title text-center"">
                    <img src=""img/icon/section.png"" alt=""title"">
                    <h2>meet our teachers</h2>
                </div>
            </div>
        </div>
        <div class=""row"">
");
            EndContext();
#line 53 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
             foreach (Teacher teacher in Model.Teachers)
            {


#line default
#line hidden
            BeginContext(1825, 227, true);
            WriteLiteral("                <div class=\"col-md-3 col-sm-4 col-xs-12\">\n                    <div class=\"single-teacher\">\n                        <div class=\"single-teacher-img\">\n                            <a href=\"teacher-details.html\"><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2052, "\"", 2084, 2);
            WriteAttributeValue("", 2058, "img/teacher/", 2058, 12, true);
#line 59 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
WriteAttributeValue("", 2070, teacher.Image, 2070, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2085, 187, true);
            WriteLiteral(" alt=\"teacher\"></a>\n                        </div>\n                        <div class=\"single-teacher-content text-center\">\n                            <h2><a href=\"teacher-details.html\">");
            EndContext();
            BeginContext(2273, 12, false);
#line 62 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                                                          Write(teacher.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2285, 100, true);
            WriteLiteral("</a></h2>\n                            <h4>Associate Professor</h4>\n                            <ul>\n");
            EndContext();
#line 65 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                                 foreach (AboutTeacher about in Model.AboutTeachers)
                                {
                                    if (teacher.AboutTeacherId == about.Id)
                                    {

#line default
#line hidden
            BeginContext(2618, 62, true);
            WriteLiteral("                                        <li><a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2680, "\"", 2702, 1);
#line 69 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
WriteAttributeValue("", 2687, about.Facebook, 2687, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2703, 107, true);
            WriteLiteral("><i class=\"zmdi zmdi-facebook\"></i></a></li>\n                                        <li><a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2810, "\"", 2833, 1);
#line 70 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
WriteAttributeValue("", 2817, about.Pinterest, 2817, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2834, 108, true);
            WriteLiteral("><i class=\"zmdi zmdi-pinterest\"></i></a></li>\n                                        <li><a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2942, "\"", 2961, 1);
#line 71 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
WriteAttributeValue("", 2949, about.Vimeo, 2949, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2962, 104, true);
            WriteLiteral("><i class=\"zmdi zmdi-vimeo\"></i></a></li>\n                                        <li><a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3066, "\"", 3087, 1);
#line 72 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
WriteAttributeValue("", 3073, about.Twitter, 3073, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3088, 44, true);
            WriteLiteral("><i class=\"zmdi zmdi-twitter\"></i></a></li>\n");
            EndContext();
#line 73 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                                    }
                                }

#line default
#line hidden
            BeginContext(3204, 116, true);
            WriteLiteral("\n                            </ul>\n                        </div>\n                    </div>\n                </div>\n");
            EndContext();
#line 80 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
            }

#line default
#line hidden
            BeginContext(3334, 262, true);
            WriteLiteral(@"        </div>
    </div>
</div>
<!-- Teacher End -->
<!-- Testimonial Area Start -->
<div class=""testimonial-area pt-110 pb-105 text-center"">
    <div class=""container"">
        <div class=""row"">
            <div class=""testimonial-owl owl-theme owl-carousel"">
");
            EndContext();
#line 90 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                 foreach (Testimonial testimonial in Model.Testimonials)
                {


#line default
#line hidden
            BeginContext(3688, 287, true);
            WriteLiteral(@"                    <div class=""col-md-8 col-md-offset-2 col-sm-12"">
                        <div class=""single-testimonial"">
                            <div class=""testimonial-info"">
                                <div class=""testimonial-img"">
                                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 3975, "\"", 4015, 2);
            WriteAttributeValue("", 3981, "img/testimonial/", 3981, 16, true);
#line 97 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
WriteAttributeValue("", 3997, testimonial.Image, 3997, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4016, 164, true);
            WriteLiteral(" alt=\"testimonial\">\n                                </div>\n                                <div class=\"testimonial-content\">\n                                    <p>");
            EndContext();
            BeginContext(4181, 23, false);
#line 100 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                                  Write(testimonial.Description);

#line default
#line hidden
            EndContext();
            BeginContext(4204, 45, true);
            WriteLiteral("</p>\n                                    <h4>");
            EndContext();
            BeginContext(4250, 16, false);
#line 101 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                                   Write(testimonial.Name);

#line default
#line hidden
            EndContext();
            BeginContext(4266, 46, true);
            WriteLiteral("</h4>\n                                    <h5>");
            EndContext();
            BeginContext(4313, 22, false);
#line 102 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                                   Write(testimonial.Speciality);

#line default
#line hidden
            EndContext();
            BeginContext(4335, 138, true);
            WriteLiteral("</h5>\n                                </div>\n                            </div>\n                        </div>\n                    </div>\n");
            EndContext();
#line 107 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                }

#line default
#line hidden
            BeginContext(4491, 415, true);
            WriteLiteral(@"            </div>
        </div>
    </div>
</div>
<!-- Testimonial Area End -->
<!-- Notice Start -->
<section class=""notice-area two pt-140 pb-100"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-6 col-sm-6 col-xs-12"">
                <div class=""notice-right-wrapper mb-25 pb-25"">
                    <h3>TAKE A VIDEO TOUR</h3>
                    <div class=""notice-video""");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 4906, "\"", 4981, 3);
            WriteAttributeValue("", 4914, "background-image:url(img/notice/", 4914, 32, true);
#line 120 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
WriteAttributeValue("", 4946, Model.NoticeVideo.Image, 4946, 24, false);

#line default
#line hidden
            WriteAttributeValue("", 4970, ")!important", 4970, 11, true);
            EndWriteAttribute();
            BeginContext(4982, 113, true);
            WriteLiteral(">\n                        <div class=\"video-icon video-hover\">\n                            <a class=\"video-popup\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 5095, "\"", 5125, 1);
#line 122 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
WriteAttributeValue("", 5102, Model.NoticeVideo.Link, 5102, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5126, 390, true);
            WriteLiteral(@">
                                <i class=""zmdi zmdi-play""></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-6 col-sm-6 col-xs-12"">
                <div class=""notice-left-wrapper"">
                    <h3>notice board</h3>
                    <div class=""notice-left"">
");
            EndContext();
#line 133 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                         foreach (NoticeBoard board in Model.NoticeBoards)
                        {


#line default
#line hidden
            BeginContext(5618, 109, true);
            WriteLiteral("                            <div class=\"single-notice-left mb-23 pb-20\">\n                                <h4>");
            EndContext();
            BeginContext(5728, 65, false);
#line 137 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                               Write(board.Date.ToString("dd, MMM yyyy", CultureInfo.InvariantCulture));

#line default
#line hidden
            EndContext();
            BeginContext(5793, 41, true);
            WriteLiteral("</h4>\n                                <p>");
            EndContext();
            BeginContext(5835, 13, false);
#line 138 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                              Write(board.Content);

#line default
#line hidden
            EndContext();
            BeginContext(5848, 40, true);
            WriteLiteral("</p>\n                            </div>\n");
            EndContext();
#line 140 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/About/Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(5914, 126, true);
            WriteLiteral("                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</section>\n<!-- Notice End -->\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AboutVM> Html { get; private set; }
    }
}
#pragma warning restore 1591