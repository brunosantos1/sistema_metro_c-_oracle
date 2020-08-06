using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/CentrosLocalizacao")]
    public class CentrosLocalizacaoController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(CentroLocalizacao))]
        public IHttpActionResult GetById(int id)
        {
            CentroLocalizacao result = new CentroLocalizacaoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<CentroLocalizacao>))]
        public IHttpActionResult GetAll()
        {
            var result = new CentroLocalizacaoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(CentroLocalizacao))]
        public IHttpActionResult Add(CentroLocalizacao obj)
        {
            var result = new CentroLocalizacaoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(CentroLocalizacao))]
        public IHttpActionResult Update(CentroLocalizacao obj)
        {
            var result = new CentroLocalizacaoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(CentroLocalizacao))]
        public IHttpActionResult Delete(CentroLocalizacao catalogo)
        {
            var result = new CentroLocalizacaoService().Delete(catalogo);
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

