using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaAplicacao")]
    public class SistemaAplicacaoController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaAplicacao))]
        public IHttpActionResult GetById(int id)
        {
            SistemaAplicacao result = new SistemaAplicacaoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaAplicacao>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaAplicacaoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaAplicacao))]
        public IHttpActionResult Add(SistemaAplicacao obj)
        {
            var result = new SistemaAplicacaoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaAplicacao obj)
        {
            var result = new SistemaAplicacaoService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaAplicacao))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaAplicacaoService().DeleteById(id);
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