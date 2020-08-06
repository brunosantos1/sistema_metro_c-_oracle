using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Ordens")]
    public class OrdensController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Ordem))]
        public IHttpActionResult GetById(int id)
        {
            Ordem result = new OrdemService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Ordem>))]
        public IHttpActionResult GetAll()
        {
            var result = new OrdemService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(Ordem))]
        public IHttpActionResult Add(Ordem obj)
        {
            var result = new OrdemService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Ordem))]
        public IHttpActionResult Update(Ordem obj)
        {
            var result = new OrdemService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(Ordem))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new OrdemService().DeleteById(id);
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

