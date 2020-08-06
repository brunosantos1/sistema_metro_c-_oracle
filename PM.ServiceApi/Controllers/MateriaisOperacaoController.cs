using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/MateriaisOperacao")]
    public class MateriaisOperacaoController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(MaterialOperacao))]
        public IHttpActionResult GetById(int id)
        {
            MaterialOperacao result = new MaterialOperacaoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<MaterialOperacao>))]
        public IHttpActionResult GetAll()
        {
            var result = new MaterialOperacaoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByOperacaoOrdem")]
        [ResponseType(typeof(List<MaterialOperacao>))]
        public IHttpActionResult GetByOperacaoOrdem(int id)
        {
            var result = new MaterialOperacaoService().GetByOperacaoOrdem(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(MaterialOperacao))]
        public IHttpActionResult Add(MaterialOperacao obj)
        {
            var result = new MaterialOperacaoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(MaterialOperacao))]
        public IHttpActionResult Update(MaterialOperacao obj)
        {
            var result = new MaterialOperacaoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(MaterialOperacao))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new MaterialOperacaoService().DeleteById(id);
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

