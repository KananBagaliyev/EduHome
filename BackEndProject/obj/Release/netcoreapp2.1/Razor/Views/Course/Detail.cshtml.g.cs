#pragma checksum "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b105330caddaeacb2ac921b093ac3904f246c1a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_Detail), @"mvc.1.0.view", @"/Views/Course/Detail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Course/Detail.cshtml", typeof(AspNetCore.Views_Course_Detail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b105330caddaeacb2ac921b093ac3904f246c1a6", @"/Views/Course/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3901e7c2bbfb5a082ff900225b5567e29d38e7f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CourseDetailVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("courses-details"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("contact-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("http://demo.devitems.com/eduhome/mail.php"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(23, 103, true);
            WriteLiteral("<!-- Banner Area Start -->\r\n<div class=\"banner-area-wrapper\">\r\n    <div class=\"banner-area text-center\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 126, "\"", 203, 5);
            WriteAttributeValue("", 134, "background-image:", 134, 17, true);
            WriteAttributeValue(" ", 151, "url(/img/banner/", 152, 17, true);
#line 4 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
WriteAttributeValue("", 168, Model.Background.Image, 168, 23, false);

#line default
#line hidden
            WriteAttributeValue("", 191, ")", 191, 1, true);
            WriteAttributeValue(" ", 192, "!important", 193, 11, true);
            EndWriteAttribute();
            BeginContext(204, 739, true);
            WriteLiteral(@">
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
            <div class=""col-md-8"">
                <div class=""courses-details"">
                    <div class=""courses-details-img"">
                        ");
            EndContext();
            BeginContext(943, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "33d67dafeb974f209701e5d3b4afd77b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 953, "~/img/course/", 953, 13, true);
#line 26 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
AddHtmlAttributeValue("", 966, Model.Course.Image, 966, 19, false);

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
            BeginContext(1009, 116, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"course-details-content\">\r\n                        <h2>");
            EndContext();
            BeginContext(1126, 17, false);
#line 29 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                       Write(Model.Course.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1143, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 30 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                         foreach (CourseDetail detail in Model.CourseDetails)
                        {
                            if (detail.Id == Model.Course.CourseDetailId)
                            {

#line default
#line hidden
            BeginContext(1362, 35, true);
            WriteLiteral("                                <p>");
            EndContext();
            BeginContext(1398, 14, false);
#line 34 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                              Write(detail.Content);

#line default
#line hidden
            EndContext();
            BeginContext(1412, 7, true);
            WriteLiteral(" </p>\r\n");
            EndContext();
            BeginContext(1421, 243, true);
            WriteLiteral("                                <div class=\"course-details-left\">\r\n                                    <div class=\"single-course-left\">\r\n                                        <h3>about course</h3>\r\n                                        <p>");
            EndContext();
            BeginContext(1665, 18, false);
#line 39 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                                      Write(detail.AboutCourse);

#line default
#line hidden
            EndContext();
            BeginContext(1683, 226, true);
            WriteLiteral("</p>\r\n                                    </div>\r\n                                    <div class=\"single-course-left\">\r\n                                        <h3>how to apply</h3>\r\n                                        <p>");
            EndContext();
            BeginContext(1910, 17, false);
#line 43 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                                      Write(detail.HowToApply);

#line default
#line hidden
            EndContext();
            BeginContext(1927, 242, true);
            WriteLiteral("</p>\r\n                                    </div>\r\n                                    <div class=\"single-course-left\">\r\n                                        <h3>certification</h3>\r\n                                        <p class=\"margin\">");
            EndContext();
            BeginContext(2170, 20, false);
#line 47 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                                                     Write(detail.Certification);

#line default
#line hidden
            EndContext();
            BeginContext(2190, 92, true);
            WriteLiteral("</p>\r\n\r\n                                    </div>\r\n                                </div>\r\n");
            EndContext();
#line 51 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                            }
                        }

#line default
#line hidden
            BeginContext(2340, 24, true);
            WriteLiteral("                        ");
            EndContext();
#line 53 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                         foreach (CourseFeature feature in Model.CourseFeatures)
                        {
                            if (feature.Id == Model.Course.CourseFeatureId)
                            {


#line default
#line hidden
            BeginContext(2559, 229, true);
            WriteLiteral("                                <div class=\"course-details-right\">\r\n                                    <h3>COURSE FEATURES</h3>\r\n                                    <ul>\r\n                                        <li>starts <span>");
            EndContext();
            BeginContext(2789, 74, false);
#line 61 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                                                    Write(feature.StartingDate.ToString("dd MMM, yyyy",CultureInfo.InvariantCulture));

#line default
#line hidden
            EndContext();
            BeginContext(2863, 73, true);
            WriteLiteral("</span></li>\r\n                                        <li>duration <span>");
            EndContext();
            BeginContext(2937, 16, false);
#line 62 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                                                      Write(feature.Duration);

#line default
#line hidden
            EndContext();
            BeginContext(2953, 85, true);
            WriteLiteral(" Month</span></li>\r\n                                        <li>class duration <span>");
            EndContext();
            BeginContext(3039, 21, false);
#line 63 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                                                            Write(feature.ClassDuration);

#line default
#line hidden
            EndContext();
            BeginContext(3060, 82, true);
            WriteLiteral(" hours</span></li>\r\n                                        <li>skill level <span>");
            EndContext();
            BeginContext(3143, 18, false);
#line 64 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                                                         Write(feature.SkillLevel);

#line default
#line hidden
            EndContext();
            BeginContext(3161, 73, true);
            WriteLiteral("</span></li>\r\n                                        <li>language <span>");
            EndContext();
            BeginContext(3235, 16, false);
#line 65 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                                                      Write(feature.Language);

#line default
#line hidden
            EndContext();
            BeginContext(3251, 73, true);
            WriteLiteral("</span></li>\r\n                                        <li>students <span>");
            EndContext();
            BeginContext(3325, 16, false);
#line 66 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                                                      Write(feature.Students);

#line default
#line hidden
            EndContext();
            BeginContext(3341, 75, true);
            WriteLiteral("</span></li>\r\n                                        <li>assesments <span>");
            EndContext();
            BeginContext(3417, 18, false);
#line 67 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                                                        Write(feature.Assesments);

#line default
#line hidden
            EndContext();
            BeginContext(3435, 121, true);
            WriteLiteral("</span></li>\r\n                                    </ul>\r\n                                    <h3 class=\"red\">course fee $");
            EndContext();
            BeginContext(3557, 11, false);
#line 69 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                                                           Write(feature.Fee);

#line default
#line hidden
            EndContext();
            BeginContext(3568, 47, true);
            WriteLiteral("</h3>\r\n                                </div>\r\n");
            EndContext();
#line 71 "C:\Users\Kanan\Desktop\EduHome\BackEndProject\Views\Course\Detail.cshtml"
                            }
                        }

#line default
#line hidden
            BeginContext(3673, 345, true);
            WriteLiteral(@"                    </div>
                    <div class=""reply-area"">
                        <h3>LEAVE A REPLY</h3>
                        <p>I must explain to you how all this a mistaken idea of ncing great explorer of the rut<br> the is lder of human happinescias unde omnis iste natus error sit volptatem </p>
                        ");
            EndContext();
            BeginContext(4018, 1215, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8ae3967d01149adb6339e954f78af21", async() => {
                BeginContext(4107, 1119, true);
                WriteLiteral(@"
                            <div class=""row"">
                                <div class=""col-md-12"">
                                    <p>Name</p>
                                    <input type=""text"" name=""name"" id=""name"">
                                </div>
                                <div class=""col-md-12"">
                                    <p>Email</p>
                                    <input type=""text"" name=""email"" id=""email"">
                                </div>
                                <div class=""col-md-12"">
                                    <p>Subject</p>
                                    <input type=""text"" name=""subject"" id=""subject"">
                                    <p>Massage</p>
                                    <textarea name=""message"" id=""message"" cols=""15"" rows=""10""></textarea>
                                </div>
                            </div>
                            <a class=""reply-btn"" href=""#"" data-text=""send""><span>send message");
                WriteLiteral("</span></a>\r\n                            <p class=\"form-messege\"></p>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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
            BeginContext(5233, 340, true);
            WriteLiteral(@"
                    </div>
                </div>
            </div>
            <div class=""col-md-4"">
                <div class=""blog-sidebar right"">
                    <div class=""single-blog-widget mb-50"">
                        <h3>search</h3>
                        <div class=""blog-search"">
                            ");
            EndContext();
            BeginContext(5573, 339, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eff29d359bfa45098eed51cef287336f", async() => {
                BeginContext(5602, 303, true);
                WriteLiteral(@"
                                <input type=""search"" placeholder=""Search..."" name=""search"" />
                                <button type=""submit"">
                                    <span><i class=""fa fa-search""></i></span>
                                </button>
                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5912, 4403, true);
            WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""single-blog-widget mb-50"">
                        <h3>categories</h3>
                        <ul>
                            <li><a href=""#"">CSS Engineering (10)</a></li>
                            <li><a href=""#"">Political Science (12)</a></li>
                            <li><a href=""#"">Micro Biology (08)</a></li>
                            <li><a href=""#"">HTML5 &amp; CSS3 (15)</a></li>
                            <li><a href=""#"">Web Design (20)</a></li>
                            <li><a href=""#"">PHP (23)</a></li>
                        </ul>
                    </div>
                    <div class=""single-blog-widget mb-50"">
                        <div class=""single-blog-banner"">
                            <a href=""blog-details.html"" id=""blog""><img src=""img/blog/blog-img.jpg"" alt=""blog""></a>
                            <h2>best<br> eductaion<br> theme</h2>
                        </div>
 ");
            WriteLiteral(@"                   </div>
                    <div class=""single-blog-widget mb-50"">
                        <h3>latest post</h3>
                        <div class=""single-post mb-30"">
                            <div class=""single-post-img"">
                                <a href=""blog-details.html"">
                                    <img src=""img/post/post1.jpg"" alt=""post"">
                                    <div class=""blog-hover"">
                                        <i class=""fa fa-link""></i>
                                    </div>
                                </a>
                            </div>
                            <div class=""single-post-content"">
                                <h4><a href=""blog-details.html"">English Language Course for you</a></h4>
                                <p>By Alex  /  June 20, 2017</p>
                            </div>
                        </div>
                        <div class=""single-post mb-30"">
                          ");
            WriteLiteral(@"  <div class=""single-post-img"">
                                <a href=""blog-details.html"">
                                    <img src=""img/post/post2.jpg"" alt=""post"">
                                    <div class=""blog-hover"">
                                        <i class=""fa fa-link""></i>
                                    </div>
                                </a>
                            </div>
                            <div class=""single-post-content"">
                                <h4><a href=""blog-details.html"">Advance Web Design and Develop</a></h4>
                                <p>By Alex  /  June 20, 2017</p>
                            </div>
                        </div>
                        <div class=""single-post"">
                            <div class=""single-post-img"">
                                <a href=""blog-details.html"">
                                    <img src=""img/post/post3.jpg"" alt=""post"">
                                    <div class=""b");
            WriteLiteral(@"log-hover"">
                                        <i class=""fa fa-link""></i>
                                    </div>
                                </a>
                            </div>
                            <div class=""single-post-content"">
                                <h4><a href=""blog-details.html"">English Language Course for you</a></h4>
                                <p>By Alex  /  June 20, 2017</p>
                            </div>
                        </div>
                    </div>
                    <div class=""single-blog-widget"">
                        <h3>tags</h3>
                        <div class=""single-tag"">
                            <a href=""blog-details.html"" class=""mr-10 mb-10"">course</a>
                            <a href=""blog-details.html"" class=""mr-10 mb-10"">education</a>
                            <a href=""blog-details.html"" class=""mb-10"">teachers</a>
                            <a href=""blog-details.html"" class=""mr-10"">learning</a>
    ");
            WriteLiteral(@"                        <a href=""blog-details.html"" class=""mr-10"">university</a>
                            <a href=""blog-details.html"">events</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Blog End -->");
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