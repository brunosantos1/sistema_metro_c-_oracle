using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaLogLogin")]
    public class SistemaLogLoginController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaLogLogin))]
        public IHttpActionResult GetById(int id)
        {
            SistemaLogLogin result = new SistemaLogLoginService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaLogLogin>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaLogLoginService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaLogLogin))]
        public IHttpActionResult Add(SistemaLogLogin obj)
        {
            var result = new SistemaLogLoginService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaLogLogin obj)
        {
            var result = new SistemaLogLoginService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaLogLogin))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaLogLoginService().DeleteById(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}

