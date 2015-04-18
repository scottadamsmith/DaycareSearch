using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using System.Data.Entity;
using DaycareSearch.Data;
using DaycareSearch.Repository.Interfaces;

namespace DaycareSearch.Repository
{
    public class RepositorySetup
    {
        public static void ConfigureInjections(Container container) 
        {
            container.Register<IDbContext, DaycareSearchEntities>(Lifestyle.Transient);
            container.Register<IUnitOfWork, EfUnitOfWork>(Lifestyle.Transient);
        }
    }
}
