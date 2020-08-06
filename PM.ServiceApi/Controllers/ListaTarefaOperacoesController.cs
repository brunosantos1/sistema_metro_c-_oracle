using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/ListaTarefaOperacoes")]
    public class ListaTarefaOperacoesController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(ListaTarefaOperacao))]
        public IHttpActionResult GetById(int id)
        {
            ListaTarefaOperacao result = new ListaTarefaOperacaoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<ListaTarefaOperacao>))]
        public IHttpActionResult GetAll()
        {
            var result = new ListaTarefaOperacaoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByidlttarefa")]
        [ResponseType(typeof(List<ListaTarefaOperacao>))]
        public IHttpActionResult GetByidlttarefa(int id_lt_tarefa)
        {
            var result = new ListaTarefaOperacaoService().GetByid_lt_tarefa(id_lt_tarefa);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(ListaTarefaOperacao))]
        public IHttpActionResult Add(ListaTarefaOperacao obj)
        {
            var result = new ListaTarefaOperacaoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(ListaTarefaOperacao))]
        public IHttpActionResult Update(ListaTarefaOperacao obj)
        {
            var result = new ListaTarefaOperacaoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(ListaTarefaOperacao))]
        public IHttpActionResult Delete(ListaTarefaOperacao ListaTarefaOperacao)
        {
            var result = new ListaTarefaOperacaoService().Delete(ListaTarefaOperacao);
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

