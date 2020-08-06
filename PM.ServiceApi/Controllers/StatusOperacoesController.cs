using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/StatusOperacoes")]
    public class StatusOperacoesController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(StatusOperacao))]
        public IHttpActionResult GetById(int id)
        {
            StatusOperacao result = new StatusOperacaoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<StatusOperacao>))]
        public IHttpActionResult GetAll()
        {
            var result = new StatusOperacaoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(StatusOperacao))]
        public IHttpActionResult Add(StatusOperacao obj)
        {
            var result = new StatusOperacaoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(StatusOperacao))]
        public IHttpActionResult Update(StatusOperacao obj)
        {
            var result = new StatusOperacaoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(StatusOperacao))]
        public IHttpActionResult Delete(StatusOperacao statusOperacao)
        {
            var result = new StatusOperacaoService().Delete(statusOperacao);
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

