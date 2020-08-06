using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/ListaTarefaOperacaoComponentes")]
    public class ListaTarefaOperacaoComponentesController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(ListaTarefaOperacaoComponente))]
        public IHttpActionResult GetById(int id)
        {
            ListaTarefaOperacaoComponente result = new ListaTarefaOperacaoComponenteService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<ListaTarefaOperacaoComponente>))]
        public IHttpActionResult GetAll()
        {
            var result = new ListaTarefaOperacaoComponenteService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByidlttarefa")]
        [ResponseType(typeof(List<ListaTarefaOperacaoComponente>))]
        public IHttpActionResult GetByidlttarefa(int id_lt_tarefa)
        {
            var result = new ListaTarefaOperacaoComponenteService().GetByid_lt_tarefa(id_lt_tarefa);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(ListaTarefaOperacaoComponente))]
        public IHttpActionResult Add(ListaTarefaOperacaoComponente obj)
        {
            var result = new ListaTarefaOperacaoComponenteService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(ListaTarefaOperacaoComponente))]
        public IHttpActionResult Update(ListaTarefaOperacaoComponente obj)
        {
            var result = new ListaTarefaOperacaoComponenteService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(ListaTarefaOperacaoComponente))]
        public IHttpActionResult Delete(ListaTarefaOperacaoComponente ListaTarefaOperacaoComponente)
        {
            var result = new ListaTarefaOperacaoComponenteService().Delete(ListaTarefaOperacaoComponente);
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

