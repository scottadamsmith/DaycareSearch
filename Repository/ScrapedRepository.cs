using DaycareSearch.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaycareSearch.Repository
{
    public class ScrapedRepository<T> : EfGenericRepository<T>, IScrapedRepository<T> where T : class 
    {
        public ScrapedRepository(IDbSet<T> dbSet) : base(dbSet) 
        {
            if (this.IsRefreshRequired()) 
            {
                this.RefreshData();
            }
        }
    
        public virtual bool IsRefreshRequired()
        {
            return true;
        }

        public virtual void RefreshData()
        {
 	    }
    }
}
