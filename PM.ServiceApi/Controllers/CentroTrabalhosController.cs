using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/CentroTrabalhos")]
    public class CentroTrabalhosController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(CentroTrabalho))]
        public IHttpActionResult GetById(int id)
        {
            CentroTrabalho result = new CentroTrabalhoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByLinha")]
        [ResponseType(typeof(CentroTrabalho))]
        public IHttpActionResult GetByLinha(int idLinha)
        {
            CentroTrabalho result = new CentroTrabalhoService().GetByLinha(idLinha);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<CentroTrabalho>))]
        public IHttpActionResult GetAll()
        {
            var result = new CentroTrabalhoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(CentroTrabalho))]
        public IHttpActionResult Add(CentroTrabalho obj)
        {
            var result = new CentroTrabalhoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(CentroTrabalho))]
        public IHttpActionResult Update(CentroTrabalho obj)
        {
            var result = new CentroTrabalhoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(CentroTrabalho))]
        public IHttpActionResult Delete(CentroTrabalho catalogo)
        {
            var result = new CentroTrabalhoService().Delete(catalogo);
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

