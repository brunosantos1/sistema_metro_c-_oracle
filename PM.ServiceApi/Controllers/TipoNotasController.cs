using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/TipoNotas")]
    public class TipoNotasController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(TipoNota))]
        public IHttpActionResult GetById(int id)
        {
            TipoNota result = new TipoNotaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByCodigoSap")]
        [ResponseType(typeof(TipoNota))]
        public IHttpActionResult GetByCodigoSap(string cd_sap)
        {
            TipoNota result = new TipoNotaService().GetByCodigoSap(cd_sap);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<TipoNota>))]
        public IHttpActionResult GetAll()
        {
            var result = new TipoNotaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(TipoNota))]
        public IHttpActionResult Add(TipoNota obj)
        {
            var result = new TipoNotaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(TipoNota))]
        public IHttpActionResult Update(TipoNota obj)
        {
            var result = new TipoNotaService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(TipoNota))]
        public IHttpActionResult Delete(TipoNota catalogo)
        {
            var result = new TipoNotaService().Delete(catalogo);
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

