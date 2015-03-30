using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EfUnitOfWork : DaycareSearchEntities, IUnitOfWork
    {
        private readonly EfGenericRepository<Entities.OpeningOption> _openingOptionRepo;
        private readonly EfGenericRepository<Entities.Location> _locationRepo;

        public DbSet<Entities.OpeningOption> OpeningOptions { get; set; }
        public DbSet<Entities.Location> Locations { get; set; }
        
        public EfUnitOfWork()
        {
            _openingOptionRepo = new EfGenericRepository<Entities.OpeningOption>(OpeningOptions);
            _locationRepo = new EfGenericRepository<Entities.Location>(Locations);
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
