#pragma checksum "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dcba79da65b5645ea0e512b3594a874362c7d8ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Course_Delete), @"mvc.1.0.view", @"/Areas/Admin/Views/Course/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Course/Delete.cshtml", typeof(AspNetCore.Areas_Admin_Views_Course_Delete))]
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
#line 1 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\_ViewImports.cshtml"
using BackEndProject.ViewModels;

#line default
#line hidden
#line 2 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\_ViewImports.cshtml"
using BackEndProject.Models;

#line default
#line hidden
#line 3 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcba79da65b5645ea0e512b3594a874362c7d8ab", @"/Areas/Admin/Views/Course/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bdf109ff8c5382f253bf09a9f160d3f310288e6", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Course_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CourseDetailVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("courses-details"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(23, 843, true);
            WriteLiteral(@"<!-- Banner Area Start -->
<div class=""banner-area-wrapper"">
    <div class=""banner-area text-center"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-xs-12"">
                    <div class=""banner-content-wrapper"">
                        <div class=""banner-content"">
                            <h2>courses details</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Banner Area End -->
<!-- Blog Start -->
<div class=""courses-details-area blog-area pt-150 pb-140"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""courses-details"">
                    <div class=""courses-details-img"">
                        ");
            EndContext();
            BeginContext(866, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "688fa3cb911c43868a6e9dfad58d246d", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 876, "~/img/course/", 876, 13, true);
#line 26 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
AddHtmlAttributeValue("", 889, Model.Course.Image, 889, 19, false);

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
            BeginContext(932, 116, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"course-details-content\">\r\n                        <h2>");
            EndContext();
            BeginContext(1049, 17, false);
#line 29 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                       Write(Model.Course.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1066, 104, true);
            WriteLiteral("</h2>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-6\">\r\n\r\n");
            EndContext();
#line 33 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                 foreach (CourseDetail detail in Model.CourseDetails)
                                {
                                    if (detail.Id == Model.Course.CourseDetailId)
                                    {

#line default
#line hidden
            BeginContext(1414, 43, true);
            WriteLiteral("                                        <p>");
            EndContext();
            BeginContext(1458, 14, false);
#line 37 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                      Write(detail.Content);

#line default
#line hidden
            EndContext();
            BeginContext(1472, 7, true);
            WriteLiteral(" </p>\r\n");
            EndContext();
            BeginContext(1481, 275, true);
            WriteLiteral(@"                                        <div class=""course-details-left"">
                                            <div class=""single-course-left"">
                                                <h3>about course</h3>
                                                <p>");
            EndContext();
            BeginContext(1757, 18, false);
#line 42 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                              Write(detail.AboutCourse);

#line default
#line hidden
            EndContext();
            BeginContext(1775, 258, true);
            WriteLiteral(@"</p>
                                            </div>
                                            <div class=""single-course-left"">
                                                <h3>how to apply</h3>
                                                <p>");
            EndContext();
            BeginContext(2034, 17, false);
#line 46 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                              Write(detail.HowToApply);

#line default
#line hidden
            EndContext();
            BeginContext(2051, 274, true);
            WriteLiteral(@"</p>
                                            </div>
                                            <div class=""single-course-left"">
                                                <h3>certification</h3>
                                                <p class=""margin"">");
            EndContext();
            BeginContext(2326, 20, false);
#line 50 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                                             Write(detail.Certification);

#line default
#line hidden
            EndContext();
            BeginContext(2346, 108, true);
            WriteLiteral("</p>\r\n\r\n                                            </div>\r\n                                        </div>\r\n");
            EndContext();
#line 54 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                    }
                                }

#line default
#line hidden
            BeginContext(2528, 90, true);
            WriteLiteral("                            </div>\r\n                            <div class=\"col-md-6\">\r\n\r\n");
            EndContext();
#line 59 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                 foreach (CourseFeature feature in Model.CourseFeatures)
                                {
                                    if (feature.Id == Model.Course.CourseFeatureId)
                                    {


#line default
#line hidden
            BeginContext(2869, 397, true);
            WriteLiteral(@"                                        <div class=""course-details-right"">
                                            <h3>COURSE FEATURES</h3>
                                            <table style=""width:100%"">
                                                <tr>
                                                    <th>Starts</th>
                                                    <td>");
            EndContext();
            BeginContext(3267, 75, false);
#line 69 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                                   Write(feature.StartingDate.ToString("dd MMM, yyyy", CultureInfo.InvariantCulture));

#line default
#line hidden
            EndContext();
            BeginContext(3342, 243, true);
            WriteLiteral("</td>\r\n                                                </tr>\r\n                                                <tr>\r\n                                                    <th>Duration</th>\r\n                                                    <td>");
            EndContext();
            BeginContext(3586, 16, false);
#line 73 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                                   Write(feature.Duration);

#line default
#line hidden
            EndContext();
            BeginContext(3602, 255, true);
            WriteLiteral(" Month</td>\r\n                                                </tr>\r\n                                                <tr>\r\n                                                    <th>Class Duration</th>\r\n                                                    <td>");
            EndContext();
            BeginContext(3858, 21, false);
#line 77 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                                   Write(feature.ClassDuration);

#line default
#line hidden
            EndContext();
            BeginContext(3879, 252, true);
            WriteLiteral(" Hours</td>\r\n                                                </tr>\r\n                                                <tr>\r\n                                                    <th>Skill Level</th>\r\n                                                    <td>");
            EndContext();
            BeginContext(4132, 18, false);
#line 81 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                                   Write(feature.SkillLevel);

#line default
#line hidden
            EndContext();
            BeginContext(4150, 243, true);
            WriteLiteral("</td>\r\n                                                </tr>\r\n                                                <tr>\r\n                                                    <th>Language</th>\r\n                                                    <td>");
            EndContext();
            BeginContext(4394, 16, false);
#line 85 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                                   Write(feature.Language);

#line default
#line hidden
            EndContext();
            BeginContext(4410, 243, true);
            WriteLiteral("</td>\r\n                                                </tr>\r\n                                                <tr>\r\n                                                    <th>Students</th>\r\n                                                    <td>");
            EndContext();
            BeginContext(4654, 16, false);
#line 89 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                                   Write(feature.Students);

#line default
#line hidden
            EndContext();
            BeginContext(4670, 245, true);
            WriteLiteral("</td>\r\n                                                </tr>\r\n                                                <tr>\r\n                                                    <th>Assesments</th>\r\n                                                    <td>");
            EndContext();
            BeginContext(4916, 18, false);
#line 93 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                                   Write(feature.Assesments);

#line default
#line hidden
            EndContext();
            BeginContext(4934, 196, true);
            WriteLiteral("</td>\r\n                                                </tr>\r\n                                            </table>\r\n                                            <h3 class=\"text-danger\">course fee $");
            EndContext();
            BeginContext(5131, 11, false);
#line 96 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                                                           Write(feature.Fee);

#line default
#line hidden
            EndContext();
            BeginContext(5142, 55, true);
            WriteLiteral("</h3>\r\n                                        </div>\r\n");
            EndContext();
#line 98 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Areas\Admin\Views\Course\Delete.cshtml"
                                    }
                                }

#line default
#line hidden
            BeginContext(5271, 164, true);
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        ");
            EndContext();
            BeginContext(5435, 189, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2f617fd036a646c5bb8235b41dd77c79", async() => {
                BeginContext(5455, 94, true);
                WriteLiteral("\r\n            <button type=\"submit\" class=\"btn btn-primary mr-2\">Submit</button>\r\n            ");
                EndContext();
                BeginContext(5549, 58, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b068503c01c4c38ab47c5e7f67eaed4", async() => {
                    BeginContext(5592, 11, true);
                    WriteLiteral("Go to Index");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5607, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5624, 41, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<!-- Blog End -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CourseDetailVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
