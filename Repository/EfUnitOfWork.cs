using DaycareSearch.Data;
using DaycareSearch.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaycareSearch.Repository
{
    public class EfUnitOfWork : DbContext, IUnitOfWork
    {
        private readonly OpeningOptionRepository _openingOptionRepo;
        private readonly LocationRepository _locationRepo;

        public DbSet<Entities.OpeningOption> OpeningOptions { get; set; }
        public DbSet<Entities.Location> Locations { get; set; }
        
        public EfUnitOfWork()
        {
            _openingOptionRepo = new OpeningOptionRepository(OpeningOptions);
            _locationRepo = new LocationRepository(Locations);
        }
        
        public IGenericRepository<Entities.OpeningOption> OpeningOptionRepository
        {
            get { return _openingOptionRepo; }
        }

        public IGenericRepository<Entities.Location> LocationRepository
        {
            get { return _locationRepo; }
        }

        public void Commit()
        {
            this.SaveChanges();
        }
    }
}
