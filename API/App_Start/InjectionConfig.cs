using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Extensions;
using SimpleInjector;
using System.Web.Http;
using DaycareSearch.Repository;

namespace DaycareSearch.API
{
    public class InjectionConfig
    {
        public static void SetupInjections()
        {
            var container = new SimpleInjector.Container();
            RepositorySetup.ConfigureInjections(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);            
        }

    }
}