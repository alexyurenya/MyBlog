#pragma checksum "C:\Users\Пользователь\Desktop\Прога\for fun\MyBlog\MyBlog\Views\Home\EditArticle.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2838a49d14afa9043b9362241a774691c76a2ec8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EditArticle), @"mvc.1.0.view", @"/Views/Home/EditArticle.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/EditArticle.cshtml", typeof(AspNetCore.Views_Home_EditArticle))]
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
#line 1 "C:\Users\Пользователь\Desktop\Прога\for fun\MyBlog\MyBlog\Views\_ViewImports.cshtml"
using MyBlog;

#line default
#line hidden
#line 2 "C:\Users\Пользователь\Desktop\Прога\for fun\MyBlog\MyBlog\Views\_ViewImports.cshtml"
using MyBlog.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2838a49d14afa9043b9362241a774691c76a2ec8", @"/Views/Home/EditArticle.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b889b3f4308041dc292b61010b9c4781c7386c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EditArticle : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MyBlog.Models.Article>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Пользователь\Desktop\Прога\for fun\MyBlog\MyBlog\Views\Home\EditArticle.cshtml"
  
    ViewBag.Title = "Edit";
   

#line default
#line hidden
            BeginContext(71, 19, true);
            WriteLiteral("\r\n<h2>Edit</h2>\r\n\r\n");
            EndContext();
#line 9 "C:\Users\Пользователь\Desktop\Прога\for fun\MyBlog\MyBlog\Views\Home\EditArticle.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(120, 45, true);
            WriteLiteral("<fieldset>\r\n    <legend>Name</legend>\r\n\r\n    ");
            EndContext();
            BeginContext(166, 33, false);
#line 14 "C:\Users\Пользователь\Desktop\Прога\for fun\MyBlog\MyBlog\Views\Home\EditArticle.cshtml"
Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(199, 42, true);
            WriteLiteral("\r\n\r\n    <p>\r\n        Name <br />\r\n        ");
            EndContext();
            BeginContext(242, 35, false);
#line 18 "C:\Users\Пользователь\Desktop\Прога\for fun\MyBlog\MyBlog\Views\Home\EditArticle.cshtml"
   Write(Html.EditorFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(277, 65, true);
            WriteLiteral("\r\n    </p>\r\n\r\n    <p>\r\n        Short description <br />\r\n        ");
            EndContext();
            BeginContext(343, 47, false);
#line 23 "C:\Users\Пользователь\Desktop\Прога\for fun\MyBlog\MyBlog\Views\Home\EditArticle.cshtml"
   Write(Html.EditorFor(model => model.ShortDescription));

#line default
#line hidden
            EndContext();
            BeginContext(390, 60, true);
            WriteLiteral("\r\n    </p>\r\n\r\n    <p>\r\n        Description  <br />\r\n        ");
            EndContext();
            BeginContext(451, 42, false);
#line 28 "C:\Users\Пользователь\Desktop\Прога\for fun\MyBlog\MyBlog\Views\Home\EditArticle.cshtml"
   Write(Html.EditorFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(493, 51, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        Date  <br />\r\n        ");
            EndContext();
            BeginContext(545, 35, false);
#line 32 "C:\Users\Пользователь\Desktop\Прога\for fun\MyBlog\MyBlog\Views\Home\EditArticle.cshtml"
   Write(Html.EditorFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(580, 54, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        Category <br />\r\n        ");
            EndContext();
            BeginContext(635, 81, false);
#line 36 "C:\Users\Пользователь\Desktop\Прога\for fun\MyBlog\MyBlog\Views\Home\EditArticle.cshtml"
   Write(Html.DropDownListFor(model => model.CategoryId, ViewBag.Categories as SelectList));

#line default
#line hidden
            EndContext();
            BeginContext(716, 12, true);
            WriteLiteral("\r\n    </p>\r\n");
            EndContext();
            BeginContext(917, 78, true);
            WriteLiteral("    <p>\r\n        <input type=\"submit\" value=\"Save\" />\r\n    </p>\r\n</fieldset>\r\n");
            EndContext();
#line 46 "C:\Users\Пользователь\Desktop\Прога\for fun\MyBlog\MyBlog\Views\Home\EditArticle.cshtml"
}

#line default
#line hidden
            BeginContext(998, 11, true);
            WriteLiteral("<div>\r\n    ");
            EndContext();
            BeginContext(1010, 36, false);
#line 48 "C:\Users\Пользователь\Desktop\Прога\for fun\MyBlog\MyBlog\Views\Home\EditArticle.cshtml"
Write(Html.ActionLink("Back", "AdminView"));

#line default
#line hidden
            EndContext();
            BeginContext(1046, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyBlog.Models.Article> Html { get; private set; }
    }
}
#pragma warning restore 1591
