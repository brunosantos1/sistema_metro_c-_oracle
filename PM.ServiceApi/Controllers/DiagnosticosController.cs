using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Diagnosticos")]
    public class DiagnosticosController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Diagnostico))]
        public IHttpActionResult GetById(int id)
        {
            Diagnostico result = new DiagnosticoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Diagnostico>))]
        public IHttpActionResult GetAll()
        {
            var result = new DiagnosticoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(Diagnostico))]
        public IHttpActionResult Add(Diagnostico obj)
        {
            var result = new DiagnosticoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Diagnostico))]
        public IHttpActionResult Update(Diagnostico obj)
        {
            var result = new DiagnosticoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Diagnostico))]
        public IHttpActionResult Delete(Diagnostico catalogo)
        {
            var result = new DiagnosticoService().Delete(catalogo);
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

