#pragma checksum "D:\job\4.biolabs_rAb\Taskdocument\4-code\ImageUploader\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c42ccda1baf16644b2e33a0993dbd9bab6f7dde"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ImageUploader.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace ImageUploader.Pages
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
#line 1 "D:\job\4.biolabs_rAb\Taskdocument\4-code\ImageUploader\Pages\_ViewImports.cshtml"
using ImageUploader;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c42ccda1baf16644b2e33a0993dbd9bab6f7dde", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1f145084c4f180bf3099afd7b34cbdbeaf46c54", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("fileupload"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\job\4.biolabs_rAb\Taskdocument\4-code\ImageUploader\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Force latest IE rendering engine or ChromeFrame if installed -->
<!--[if IE]>
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"" />
<![endif]-->
<meta charset=""utf-8"" />
<title>jQuery File Upload Demo</title>
<meta name=""description""
      content=""File Upload widget with multiple file selection, drag&amp;drop support, progress bars, validation and preview images, audio and video for jQuery. Supports cross-domain, chunked and resumable file uploads and client-side image resizing. Works with any server-side platform (PHP, Python, Ruby on Rails, Java, Node.js, Go etc.) that supports standard HTML form file uploads."" />
<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
<!-- Bootstrap styles -->
<link rel=""stylesheet""
      href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css""
      integrity=""sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u""
      crossorigin=""anonymous"" />
<!-- Doka Image Editor styles -->
<l");
            WriteLiteral(@"ink rel=""stylesheet"" href=""css/vendor/doka.min.css"" />
<!-- Generic page styles -->
<style>
    #navigation {
        margin: 10px 0;
    }
    #carbonads {
        box-sizing: border-box;
        max-width: 300px;
        min-height: 130px;
        padding: 15px 15px 15px 160px;
        margin: 0;
        border-radius: 4px;
        font-size: 13px;
        line-height: 1.4;
        background-color: rgba(0, 0, 0, 0.05);
    }
    #carbonads .carbon-img {
        float: left;
        margin-left: -145px;
    }
    #carbonads .carbon-poweredby {
        display: block;
        color: #777 !important;
    }
</style>
<!-- blueimp Gallery styles -->
<link rel=""stylesheet"" href=""css/blueimp-gallery.min.css"" />
<!-- CSS to style the file input field as button and adjust the Bootstrap progress bars -->
<link rel=""stylesheet"" href=""css/jquery.fileupload.css"" />
<link rel=""stylesheet"" href=""css/jquery.fileupload-ui.css"" />
<!-- CSS adjustments for browsers with JavaScript disabled -->
");
            WriteLiteral(@"<noscript>
    <link rel=""stylesheet"" href=""css/jquery.fileupload-noscript.css"" />
</noscript>
<noscript>
    <link rel=""stylesheet"" href=""css/jquery.fileupload-ui-noscript.css"" />
</noscript>

<div class=""container"">
    <!-- The file upload form used as target for the file upload widget -->
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7c42ccda1baf16644b2e33a0993dbd9bab6f7dde7024", async() => {
                WriteLiteral(@"
        <!-- The fileupload-buttonbar contains buttons to add/delete files and start/cancel the upload -->
        <div class=""row fileupload-buttonbar"">
            <div class=""col-lg-7"">
                <!-- The fileinput-button span is used to style the file input field as button -->
                <span class=""btn btn-success fileinput-button"">
                    <i class=""glyphicon glyphicon-plus""></i>
                    <span>Add files...</span>
                    <input type=""file"" name=""files[]"" accept=""image/*"" />
                </span>
                <button type=""submit"" class=""btn btn-primary start"">
                    <i class=""glyphicon glyphicon-upload""></i>
                    <span>Start upload</span>
                </button>
                <button type=""reset"" class=""btn btn-warning cancel"">
                    <i class=""glyphicon glyphicon-ban-circle""></i>
                    <span>Cancel upload</span>
                </button>
                <button type=""butto");
                WriteLiteral(@"n"" class=""btn btn-danger delete"">
                    <i class=""glyphicon glyphicon-trash""></i>
                    <span>Delete selected</span>
                </button>
                <input type=""checkbox"" class=""toggle"" />
                <!-- The global file processing state -->
                <span class=""fileupload-process""></span>
            </div>
            <!-- The global progress state -->
            <div class=""col-lg-5 fileupload-progress fade"">
                <!-- The global progress bar -->
                <div class=""progress progress-striped active""
                     role=""progressbar""
                     aria-valuemin=""0""
                     aria-valuemax=""100"">
                    <div class=""progress-bar progress-bar-success""
                         style=""width:0%;""></div>
                </div>
                <!-- The extended global progress state -->
                <div class=""progress-extended"">&nbsp;</div>
            </div>
        </div>
       ");
                WriteLiteral(" <!-- The table listing the files available for upload/download -->\r\n        <table role=\"presentation\" class=\"table table-striped\">\r\n            <tbody class=\"files\"></tbody>\r\n        </table>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<!-- The blueimp Gallery widget -->
<div id=""blueimp-gallery""
     class=""blueimp-gallery blueimp-gallery-controls""
     data-filter="":even"">
    <div class=""slides""></div>
    <h3 class=""title""></h3>
    <a class=""prev"">‹</a>
    <a class=""next"">›</a>
    <a class=""close"">×</a>
    <a class=""play-pause""></a>
    <ol class=""indicator""></ol>
</div>
<!-- The template to display files available for upload -->
<script id=""template-upload"" type=""text/x-tmpl"">
    {% for (var i=0, file; file=o.files[i]; i++) { %}
    <tr class=""template-upload fade"">
        <td>
            <span class=""preview""></span>
        </td>
        <td>
            {% if (window.innerWidth > 480 || !o.options.loadImageFileTypes.test(file.type)) { %}
            <p class=""name"">{%=file.name%}</p>
            {% } %}
            <strong class=""error text-danger""></strong>
        </td>
        <td>
            <p class=""size"">Processing...</p>
            <div class=""progress progress-striped active"" ro");
            WriteLiteral(@"le=""progressbar"" aria-valuemin=""0"" aria-valuemax=""100"" aria-valuenow=""0""><div class=""progress-bar progress-bar-success"" style=""width:0%;""></div></div>
        </td>
        <td>
            {% if (!o.options.autoUpload && o.options.edit && o.options.loadImageFileTypes.test(file.type)) { %}
            <button class=""btn btn-success edit"" data-index=""{%=i%}"" disabled>
                <i class=""glyphicon glyphicon-edit""></i>
                <span>Edit</span>
            </button>
            {% } %}
            {% if (!i && !o.options.autoUpload) { %}
            <button class=""btn btn-primary start"" disabled>
                <i class=""glyphicon glyphicon-upload""></i>
                <span>Start</span>
            </button>
            {% } %}
            {% if (!i) { %}
            <button class=""btn btn-warning cancel"">
                <i class=""glyphicon glyphicon-ban-circle""></i>
                <span>Cancel</span>
            </button>
            {% } %}
        </td>
    </tr>
    ");
            WriteLiteral(@"{% } %}
</script>
<!-- The template to display files available for download -->
<script id=""template-download"" type=""text/x-tmpl"">
    {% for (var i=0, file; file=o.files[i]; i++) { %}
    <tr class=""template-download fade"">
        <td>
            <span class=""preview"">
                {% if (file.thumbnailUrl) { %}
                <a href=""{%=file.url%}"" title=""{%=file.name%}"" download=""{%=file.name%}"" data-gallery><img src=""{%=file.thumbnailUrl%}""></a>
                {% } %}
            </span>
        </td>
        <td>
            {% if (window.innerWidth > 480 || !file.thumbnailUrl) { %}
            <p class=""name"">
                {% if (file.url) { %}
                <a href=""{%=file.url%}"" title=""{%=file.name%}"" download=""{%=file.name%}"" {%=file.thumbnailUrl?'data-gallery':''%}>{%=file.name%}</a>
                {% } else { %}
                <span>{%=file.name%}</span>
                {% } %}
            </p>
            {% } %}
            {% if (file.error) { %}
         ");
            WriteLiteral(@"   <div><span class=""label label-danger"">Error</span> {%=file.error%}</div>
            {% } %}
        </td>
        <td>
            <span class=""size"">{%=o.formatFileSize(file.size)%}</span>
        </td>
        <td>
            {% if (file.deleteUrl) { %}
            <button class=""btn btn-danger delete"" data-type=""{%=file.deleteType%}"" data-url=""{%=file.deleteUrl%}"" {% if (file.deleteWithCredentials) { %} data-xhr-fields='{""withCredentials"":true}' {% } %}>
                <i class=""glyphicon glyphicon-trash""></i>
                <span>Delete</span>
            </button>
            <input type=""checkbox"" name=""delete"" value=""1"" class=""toggle"">
            {% } else { %}
            <button class=""btn btn-warning cancel"">
                <i class=""glyphicon glyphicon-ban-circle""></i>
                <span>Cancel</span>
            </button>
            {% } %}
        </td>
    </tr>
    {% } %}
</script>
<!-- The jQuery UI widget factory, can be omitted if jQuery UI is already inc");
            WriteLiteral(@"luded -->
<script src=""js/vendor/jquery.ui.widget.js""></script>
<!-- The Templates plugin is included to render the upload/download listings -->
<script src=""js/tmpl.min.js""></script>
<!-- The Load Image plugin is included for the preview images and image resizing functionality -->
<script src=""js/load-image.all.min.js""></script>
<!-- The Canvas to Blob plugin is included for image resizing functionality -->
<script src=""js/canvas-to-blob.min.js""></script>
<!-- Doka Image Editor polyfills -->
<script>
    [
        {
            supported: 'Promise' in window,
            fill:
                'https://cdn.jsdelivr.net/npm/promise-polyfill@8/dist/polyfill.min.js'
        },
        {
            supported: 'fetch' in window,
            fill: 'https://cdn.jsdelivr.net/npm/fetch-polyfill@0.8.2/fetch.min.js'
        },
        {
            supported:
                'CustomEvent' in window &&
                'log10' in Math &&
                'sign' in Math &&
                'assign' ");
            WriteLiteral(@"in Object &&
                'from' in Array &&
                ['find', 'findIndex', 'includes'].reduce(function (previous, prop) {
                    return prop in Array.prototype ? previous : false;
                }, true),
            fill: 'js/vendor/doka.polyfill.min.js'
        }
    ].forEach(function (p) {
        if (p.supported) return;
        document.write('<script src=""' + p.fill + '""><\/script>');
    });
</script>
<!-- Doka Image Editor library -->
<script src=""js/vendor/doka.min.js""></script>
<!-- blueimp Gallery script -->
<script src=""js/jquery.blueimp-gallery.min.js""></script>
<!-- The Iframe Transport is required for browsers without support for XHR file uploads -->
<script src=""js/jquery.iframe-transport.js""></script>
<!-- The basic File Upload plugin -->
<script src=""js/jquery.fileupload.js""></script>
<!-- The File Upload processing plugin -->
<script src=""js/jquery.fileupload-process.js""></script>
<!-- The File Upload image preview & resize plugin -->
<script");
            WriteLiteral(@" src=""js/jquery.fileupload-image.js""></script>
<!-- The File Upload audio preview plugin -->
<script src=""js/jquery.fileupload-audio.js""></script>
<!-- The File Upload video preview plugin -->
<script src=""js/jquery.fileupload-video.js""></script>
<!-- The File Upload validation plugin -->
<script src=""js/jquery.fileupload-validate.js""></script>
<!-- The File Upload user interface plugin -->
<script src=""js/jquery.fileupload-ui.js""></script>
<!-- The main application script -->
<script src=""js/demo.js""></script>
<!-- The XDomainRequest Transport is included for cross-domain file deletion for IE 8 and IE 9 -->
<!--[if (gte IE 8)&(lt IE 10)]>
  <script src=""js/cors/jquery.xdr-transport.js""></script>
<![endif]-->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
