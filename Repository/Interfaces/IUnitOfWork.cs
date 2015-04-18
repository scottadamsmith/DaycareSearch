using DaycareSearch.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaycareSearch.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<OpeningOption> OpeningOptionRepository { get; }
        IGenericRepository<Location> LocationRepository { get; }

        void Commit();
    }
}
