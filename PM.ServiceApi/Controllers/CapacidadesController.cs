using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Capacidades")]
    public class CapacidadesController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Capacidade))]
        public IHttpActionResult GetById(int id)
        {
            Capacidade result = new CapacidadeService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Capacidade>))]
        public IHttpActionResult GetAll()
        {
            var result = new CapacidadeService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(Capacidade))]
        public IHttpActionResult Add(Capacidade obj)
        {
            var result = new CapacidadeService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Capacidade))]
        public IHttpActionResult Update(Capacidade obj)
        {
            var result = new CapacidadeService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Capacidade))]
        public IHttpActionResult Delete(Capacidade catalogo)
        {
            var result = new CapacidadeService().Delete(catalogo);
            if (result == null)
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

