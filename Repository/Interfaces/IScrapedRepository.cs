using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaycareSearch.Repository.Interfaces
{
    public interface IScrapedRepository<T> : IGenericRepository<T> where T : class
    {
        bool IsRefreshRequired();
        void RefreshData();
    }
}
