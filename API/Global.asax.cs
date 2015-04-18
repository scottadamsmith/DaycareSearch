using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace DaycareSearch.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InjectionConfig.SetupInjections();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
