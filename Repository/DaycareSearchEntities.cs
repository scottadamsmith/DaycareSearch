using DaycareSearch.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaycareSearch.Repository
{
    public partial class DaycareSearchEntities : DbContext, IDbContext
    {
    }
}
