using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/EventosGerador")]
    public class EventosGeradorController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(EventoGerador))]
        public IHttpActionResult GetById(int id)
        {
            EventoGerador result = new EventoGeradorService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<EventoGerador>))]
        public IHttpActionResult GetAll()
        {
            var result = new EventoGeradorService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(EventoGerador))]
        public IHttpActionResult Add(EventoGerador obj)
        {
            var result = new EventoGeradorService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(EventoGerador))]
        public IHttpActionResult Update(EventoGerador obj)
        {
            var result = new EventoGeradorService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(EventoGerador))]
        public IHttpActionResult Delete(EventoGerador catalogo)
        {
            var result = new EventoGeradorService().Delete(catalogo);
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

