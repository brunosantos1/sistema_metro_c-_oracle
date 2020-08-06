using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/CalendariosFabrica")]
    public class CalendariosFabricaController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(CalendarioFabrica))]
        public IHttpActionResult GetById(int id)
        {
            CalendarioFabrica result = new CalendarioFabricaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<CalendarioFabrica>))]
        public IHttpActionResult GetAll()
        {
            var result = new CalendarioFabricaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(CalendarioFabrica))]
        public IHttpActionResult Add(CalendarioFabrica obj)
        {
            var result = new CalendarioFabricaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(CalendarioFabrica))]
        public IHttpActionResult Update(CalendarioFabrica obj)
        {
            var result = new CalendarioFabricaService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(CalendarioFabrica))]
        public IHttpActionResult Delete(CalendarioFabrica catalogo)
        {
            var result = new CalendarioFabricaService().Delete(catalogo);
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

