//using System;
//using System.Configuration;
//using System.Data.Entity.Spatial;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Controllers;
//using System.Web.Http.ExceptionHandling;
//using System.Web.Http.Validation;
//using Autofac;
//using Autofac.Builder;
//using Autofac.Integration.WebApi;
//using Microsoft.Azure.Mobile.Server;
//using Microsoft.Azure.Mobile.Server.Authentication;
//using Microsoft.Azure.Mobile.Server.Config;
//using Microsoft.Azure.Mobile.Server.Tables;
//using Microsoft.Owin.Security.DataProtection;
//using Owin;

//namespace XDogService
//{
//    public class JsonDotNetConfigProvider : TableControllerConfigProvider
//    {
//        public override void Configure(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
//        {
//            base.Configure(controllerSettings, controllerDescriptor);
//            //if (!controllerSettings.Formatters.OfType<JsonDotNetFormatter>().Any())
//            //{
//            //    controllerSettings.Formatters.Insert(0, new JsonDotNetFormatter());
//            //}
//        }
//    }

//    //public class CustomBodyModelValidator : DefaultBodyModelValidator
//    //{
//    //    public override bool ShouldValidateType(Type type)
//    //    {
//    //        return type != typeof(DbGeography) && base.ShouldValidateType(type);
//    //    }
//    //}

//    public partial class Startup
//    {
//        //private static void ConfigureMobileApp(IAppBuilder app, ContainerBuilder builder)
//        //{
//        //    GlobalConfiguration.Configure(c => Configure(app, builder, c));
//        //    GlobalConfiguration.Configuration.Services.Replace(typeof(IBodyModelValidator), new CustomBodyModelValidator());
//        //}

//        //class OopsExceptionHandler : ExceptionHandler
//        //{
//        //    public override void Handle(ExceptionHandlerContext context)
//        //    {
//        //        context.Result = new TextPlainErrorResult
//        //        {
//        //            Request = context.ExceptionContext.Request,
//        //            Content = "Oops! Sorry! Something went wrong." +
//        //                      "Please contact support so we can try to fix it."
//        //        };
//        //    }

//        //    private class TextPlainErrorResult : IHttpActionResult
//        //    {
//        //        public HttpRequestMessage Request { get; set; }

//        //        public string Content { get; set; }

//        //        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
//        //        {
//        //            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
//        //            response.Content = new StringContent(Content);
//        //            response.RequestMessage = Request;
//        //            return Task.FromResult(response);
//        //        }
//        //    }
//        //}

//        private static void Configure(IAppBuilder app, ContainerBuilder builder, HttpConfiguration config)
//        {
//            //builder.RegisterModule(new WebApiModule(config));
//            //var container = builder.Build();
//            //RegisterIdentity(app.GetDataProtectionProvider(), container);
//            //config.Services.Replace(typeof(IExceptionHandler), new OopsExceptionHandler());
//            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
//            //config.EnableSystemDiagnosticsTracing();

//            config.Routes.MapHttpRoute("DefaultApi", "api/{culture}/{controller}/{id}", new { id = RouteParameter.Optional });
//            new MobileAppConfiguration()
//                .AddTablesWithEntityFramework()
//                .WithTableControllerConfigProvider(new JsonDotNetConfigProvider())
//                .ApplyTo(config);

//            //MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();
//            //if (string.IsNullOrEmpty(settings.HostName))
//            //{
//            //    // This middleware is intended to be used locally for debugging. By default, HostName will
//            //    // only have a value when running in an App Service application.
//            //    app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
//            //    {
//            //        SigningKey = ConfigurationManager.AppSettings["SigningKey"],
//            //        ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
//            //        ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
//            //        TokenHandler = config.GetAppServiceTokenHandler()
//            //    });
//            //}

//            //app.UseAutofacWebApi(config);
//            //app.UseAutofacMiddleware(container);
//        }

//        //private static void RegisterIdentity(IDataProtectionProvider dataProtectionProvider, IContainer container)
//        //{
//        //    container.ComponentRegistry.Register(RegistrationBuilder.ForDelegate((c, p) => dataProtectionProvider).CreateRegistration());
//        //}
//    }
//}

