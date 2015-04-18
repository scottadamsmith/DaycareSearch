using DaycareSearch.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaycareSearch.Repository
{
    public class OpeningOptionRepository : ScrapedRepository<OpeningOption> 
    {
        public OpeningOptionRepository(IDbSet<OpeningOption> dbSet) : base(dbSet) { }

        public override bool IsRefreshRequired()
        {
            throw new NotImplementedException();
        }

        public override void RefreshData()
        {
            throw new NotImplementedException();
        }
    }
}
