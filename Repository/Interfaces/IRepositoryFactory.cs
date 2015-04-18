using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaycareSearch.Repository.Interfaces
{
    public interface IRepositoryFactory<T> where T : class
    {
        IGenericRepository<T> GetRepository(IDbSet<T> dbSet);
    }
}
