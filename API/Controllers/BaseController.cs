using DaycareSearch.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DaycareSearch.API.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        protected BaseController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        protected IHttpActionResult Result<T>(T entity){
            return entity == null
                ? (IHttpActionResult)NotFound()
                : (IHttpActionResult)Ok<T>(entity)
            ;
        }
    }
}
