#pragma checksum "C:\Users\AlumnoMCSD\Documents\0-master\Azure.Net\mvcStorage\mvcStorage\Views\Departamentos\ApiClienteAjax.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "302a528d81729a24a0c48f75440edb36cf6fccff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Departamentos_ApiClienteAjax), @"mvc.1.0.view", @"/Views/Departamentos/ApiClienteAjax.cshtml")]
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
#nullable restore
#line 2 "C:\Users\AlumnoMCSD\Documents\0-master\Azure.Net\mvcStorage\mvcStorage\Views\_ViewImports.cshtml"
using mvcStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\AlumnoMCSD\Documents\0-master\Azure.Net\mvcStorage\mvcStorage\Views\_ViewImports.cshtml"
using NuGetDoctoresModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"302a528d81729a24a0c48f75440edb36cf6fccff", @"/Views/Departamentos/ApiClienteAjax.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"570447de26045f336a9557f4b7b7ca365800c274", @"/Views/_ViewImports.cshtml")]
    public class Views_Departamentos_ApiClienteAjax : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/serviceapidepartamentos.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Consumo Api Crud Departamentos</h1>\n\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "302a528d81729a24a0c48f75440edb36cf6fccff4311", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        var urlapi = ""https://apicruddepartamentoscorepgs.azurewebsites.net/"";
        $(document).ready(function () {
            cargarDepartamentos();

            $(""#botoneliminar"").click(function () {
                var id = $(""#cajanumero"").val();
                eliminarDepartamentoAsync(id, function () {
                    cargarDepartamentos();
                });
            });

            $(""#botoninsertar"").click(function () {
                var id = parseInt($(""#cajanumero"").val());
                var nombre = $(""#cajanombre"").val();
                var localidad = $(""#cajalocalidad"").val();
                var json = convertirDeptJson(id, nombre, localidad);
                insertarDepartamentoAsync(json, function () {
                    cargarDepartamentos();
                });
            });

            $(""#botonmodificar"").click(function () {
                var id = parseInt($(""#cajanumero"").val());
                var nombre = $(""#cajanombre"").val();
               ");
                WriteLiteral(@" var localidad = $(""#cajalocalidad"").val();
                var json = convertirDeptJson(id, nombre, localidad);
                modificarDepartamentoAsync(json, function () {
                    cargarDepartamentos();
                });
            });
        });

        function cargarDepartamentos() {
            getTablaDepartamentosAsync(function (data) {
                $(""#tabladepartamentos tbody"").html(data);
            });
        }
    </script>
");
            }
            );
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "302a528d81729a24a0c48f75440edb36cf6fccff7012", async() => {
                WriteLiteral(@"
    <label>Id Departamento: </label>
    <input type=""text"" id=""cajanumero"" placeholder=""Id departamento""
           class=""form-control"" /><br />
    <label>Nombre: </label>
    <input type=""text"" id=""cajanombre"" placeholder=""Nombre departamento""
           class=""form-control"" /><br />
    <label>Localidad: </label>
    <input type=""text"" id=""cajalocalidad"" placeholder=""Localidad""
           class=""form-control"" /><br />
    <div>
        <button type=""button"" id=""botoninsertar""
                class=""btn btn-success"">
            Insertar
        </button>
        <button type=""button"" id=""botonmodificar""
                class=""btn btn-info"">
            Modificar
        </button>
        <button type=""button"" id=""botoneliminar""
                class=""btn btn-danger"">
            Eliminar
        </button>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n<table class=\"table table-bordered table-warning\"\n       id=\"tabladepartamentos\">\n    <thead>\n        <tr>\n            <th>Id</th>\n            <th>Nombre</th>\n            <th>Localidad</th>\n        </tr>\n    </thead>\n    <tbody>\n    </tbody>\n</table> ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
