using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaTabela")]
    public class SistemaTabelaController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaTabela))]
        public IHttpActionResult GetById(int id)
        {
            SistemaTabela result = new SistemaTabelaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaTabela>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaTabelaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaTabela))]
        public IHttpActionResult Add(SistemaTabela obj)
        {
            var result = new SistemaTabelaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaTabela obj)
        {
            var result = new SistemaTabelaService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaTabela))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaTabelaService().DeleteById(id);
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