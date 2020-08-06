using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/TiposCapacidade")]
    public class TiposCapacidadeController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(TipoCapacidade))]
        public IHttpActionResult GetById(int id)
        {
            TipoCapacidade result = new TipoCapacidadeService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<TipoCapacidade>))]
        public IHttpActionResult GetAll()
        {
            var result = new TipoCapacidadeService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(TipoCapacidade))]
        public IHttpActionResult Add(TipoCapacidade obj)
        {
            var result = new TipoCapacidadeService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(TipoCapacidade))]
        public IHttpActionResult Update(TipoCapacidade obj)
        {
            var result = new TipoCapacidadeService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(TipoCapacidade))]
        public IHttpActionResult Delete(TipoCapacidade tipoCapacidade)
        {
            var result = new TipoCapacidadeService().Delete(tipoCapacidade);
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

