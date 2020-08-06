using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Documentos")]
    public class DocumentosController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Documento))]
        public IHttpActionResult GetById(int id)
        {
            Documento result = new DocumentoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByNota")]
        [ResponseType(typeof(List<Documento>))]
        public IHttpActionResult GetByNota(int id)
        {
            var result = new DocumentoService().GetByNota(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetNavigationPropertiesByNota")]
        [ResponseType(typeof(List<Documento>))]
        public IHttpActionResult GetNavigationPropertiesByNota(int id)
        {
            List<Documento> result = new DocumentoService().GetNavigationPropertiesByNota(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Documento>))]
        public IHttpActionResult GetAll()
        {
            var result = new DocumentoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(Documento))]
        public IHttpActionResult Add(Documento obj)
        {
            var result = new DocumentoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Documento))]
        public IHttpActionResult Update(Documento obj)
        {
            var result = new DocumentoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(Documento))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new DocumentoService().DeleteById(id);
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

