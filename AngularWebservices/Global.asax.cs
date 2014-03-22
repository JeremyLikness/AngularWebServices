// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Jeremy Likness">
//   Copyright (c) 2014 Jeremy Likness.
// </copyright>
// <summary>
//   The MVC application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AngularWebservices
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// The MVC application.
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// The application start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleDependencyResolver();
        }
    }
}