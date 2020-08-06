using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Classificacoes")]
    public class ClassificacoesController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Classificacao))]
        public IHttpActionResult GetById(int id)
        {
            Classificacao result = new ClassificacaoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Classificacao>))]
        public IHttpActionResult GetAll()
        {
            var result = new ClassificacaoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(Classificacao))]
        public IHttpActionResult Add(Classificacao obj)
        {
            var result = new ClassificacaoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Classificacao))]
        public IHttpActionResult Update(Classificacao obj)
        {
            var result = new ClassificacaoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Classificacao))]
        public IHttpActionResult Delete(Classificacao catalogo)
        {
            var result = new ClassificacaoService().Delete(catalogo);
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

