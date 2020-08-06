using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/TiposMarcador")]
    public class TiposMarcadorController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(TipoMarcador))]
        public IHttpActionResult GetById(int id)
        {
            TipoMarcador result = new TipoMarcadorService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<TipoMarcador>))]
        public IHttpActionResult GetAll()
        {
            var result = new TipoMarcadorService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(TipoMarcador))]
        public IHttpActionResult Add(TipoMarcador obj)
        {
            var result = new TipoMarcadorService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(TipoMarcador))]
        public IHttpActionResult Update(TipoMarcador obj)
        {
            var result = new TipoMarcadorService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(TipoMarcador))]
        public IHttpActionResult Delete(TipoMarcador tipoMarcador)
        {
            var result = new TipoMarcadorService().Delete(tipoMarcador);
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

