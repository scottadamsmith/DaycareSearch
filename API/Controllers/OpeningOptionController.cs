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
    public class OpeningOptionController : BaseController
    {
        public OpeningOptionController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [HttpGet]
        public IEnumerable<OpeningOption> GetAllOpeningOptions()
        {
            return UnitOfWork.OpeningOptionRepository.GetAll();
        }

        [HttpGet]
        public IHttpActionResult GetOpeningOption(int id)
        {
            var openingOption = UnitOfWork.OpeningOptionRepository.FirstOrDefault(o => o.ID == id);
            return Result<OpeningOption> (openingOption);
        }
    }
}
