using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Data.Entity;
using PoorChild.Web.Models;

namespace PoorChild.Web
{
    using System.Data.Entity.Migrations;
     
    using PoorChild.Web.Context;
     
    /// <summary>
    /// The web api application.
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// The application_ start2.
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());

            using (var context = new DataContext())
            {
                context.Database.Initialize(force: true);
            }
        }
    }
}
