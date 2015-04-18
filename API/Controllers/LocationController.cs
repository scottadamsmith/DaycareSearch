using DaycareSearch.Entities;
using DaycareSearch.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DaycareSearch.API.Controllers
{
    public class LocationController : BaseController
    {
        public LocationController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [HttpGet]
        public IEnumerable<Location> GetAllLocations()
        {
            return UnitOfWork.LocationRepository.GetAll();
        }

        [HttpGet]
        public IHttpActionResult GetLocation(int id)
        {
            var location = UnitOfWork.LocationRepository.FirstOrDefault(l => l.ID == id);
            return Result<Location>(location);
        }
    }
}
