using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Zonas")]
    public class ZonasController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Zona))]
        public IHttpActionResult GetById(int id)
        {
            Zona result = new ZonaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Zona>))]
        public IHttpActionResult GetAll()
        {
            var result = new ZonaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(Zona))]
        public IHttpActionResult Add(Zona obj)
        {
            var result = new ZonaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Zona))]
        public IHttpActionResult Delete(Zona obj)
        {
            var result = new ZonaService().Delete(obj);
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

