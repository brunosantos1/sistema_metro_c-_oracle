using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Prioridades")]
    public class PrioridadesController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Prioridade))]
        public IHttpActionResult GetById(int id)
        {
            Prioridade result = new PrioridadeService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Route("GetBySintoma")]
        [ResponseType(typeof(Prioridade))]
        public IHttpActionResult GetBySintoma(int idSintoma)
        {
            Prioridade result = new PrioridadeService().GetBySintoma(idSintoma);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Prioridade>))]
        public IHttpActionResult GetAll()
        {
            var result = new PrioridadeService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(Prioridade))]
        public IHttpActionResult Add(Prioridade obj)
        {
            var result = new PrioridadeService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Prioridade))]
        public IHttpActionResult Update(Prioridade obj)
        {
            var result = new PrioridadeService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Prioridade))]
        public IHttpActionResult Delete(Prioridade catalogo)
        {
            var result = new PrioridadeService().Delete(catalogo);
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

