#pragma checksum "/Users/kanan/Desktop/EduHome/BackEndProject/Views/Teacher/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "568793c56014808d60ec8c3885a3372a67028b91"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"568793c56014808d60ec8c3885a3372a67028b91", @"/Views/Teacher/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f6a7137cbfc21f64254730f2e3df1d47d27077f", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TeacherVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(18, 103, true);
            WriteLiteral("<!-- Banner Area Start -->\r\n<div class=\"banner-area-wrapper\">\r\n    <div class=\"banner-area text-center\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 121, "\"", 198, 5);
            WriteAttributeValue("", 129, "background-image:", 129, 17, true);
            WriteAttributeValue(" ", 146, "url(/img/banner/", 147, 17, true);
#line 4 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/Teacher/Index.cshtml"
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
#line 23 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/Teacher/Index.cshtml"
             foreach (Teacher teacher in Model.Teachers)
            {


#line default
#line hidden
            BeginContext(833, 236, true);
            WriteLiteral("                <div class=\"col-md-3 col-sm-4 col-xs-12\">\r\n                    <div class=\"single-teacher mb-45\">\r\n                        <div class=\"single-teacher-img\">\r\n                            <a href=\"teacher-details.html\"><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1069, "\"", 1101, 2);
            WriteAttributeValue("", 1075, "img/teacher/", 1075, 12, true);
#line 29 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/Teacher/Index.cshtml"
WriteAttributeValue("", 1087, teacher.Image, 1087, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1102, 190, true);
            WriteLiteral(" alt=\"teacher\"></a>\r\n                        </div>\r\n                        <div class=\"single-teacher-content text-center\">\r\n                            <h2><a href=\"teacher-details.html\">");
            EndContext();
            BeginContext(1293, 12, false);
#line 32 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/Teacher/Index.cshtml"
                                                          Write(teacher.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1305, 11, true);
            WriteLiteral("</a></h2>\r\n");
            EndContext();
#line 33 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/Teacher/Index.cshtml"
                             foreach (AboutTeacher about in Model.AboutTeachers)
                            {
                                if (teacher.AboutTeacherId == about.Id)
                                {

#line default
#line hidden
            BeginContext(1537, 40, true);
            WriteLiteral("                                    <h4>");
            EndContext();
            BeginContext(1578, 16, false);
#line 37 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/Teacher/Index.cshtml"
                                   Write(about.Speciality);

#line default
#line hidden
            EndContext();
            BeginContext(1594, 111, true);
            WriteLiteral("</h4>\r\n                                    <ul>\r\n                                        <li><a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1705, "\"", 1727, 1);
#line 39 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/Teacher/Index.cshtml"
WriteAttributeValue("", 1712, about.Facebook, 1712, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1728, 108, true);
            WriteLiteral("><i class=\"zmdi zmdi-facebook\"></i></a></li>\r\n                                        <li><a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1836, "\"", 1859, 1);
#line 40 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/Teacher/Index.cshtml"
WriteAttributeValue("", 1843, about.Pinterest, 1843, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1860, 109, true);
            WriteLiteral("><i class=\"zmdi zmdi-pinterest\"></i></a></li>\r\n                                        <li><a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1969, "\"", 1988, 1);
#line 41 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/Teacher/Index.cshtml"
WriteAttributeValue("", 1976, about.Vimeo, 1976, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1989, 105, true);
            WriteLiteral("><i class=\"zmdi zmdi-vimeo\"></i></a></li>\r\n                                        <li><a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2094, "\"", 2115, 1);
#line 42 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/Teacher/Index.cshtml"
WriteAttributeValue("", 2101, about.Twitter, 2101, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2116, 88, true);
            WriteLiteral("><i class=\"zmdi zmdi-twitter\"></i></a></li>\r\n                                    </ul>\r\n");
            EndContext();
#line 44 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/Teacher/Index.cshtml"
                                }
                            }

#line default
#line hidden
            BeginContext(2270, 86, true);
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 50 "/Users/kanan/Desktop/EduHome/BackEndProject/Views/Teacher/Index.cshtml"
            }

#line default
#line hidden
            BeginContext(2371, 56, true);
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