using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/ListasTarefass")]
    public class ListasTarefasController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(ListaTarefa))]
        public IHttpActionResult GetById(int id)
        {
            ListaTarefa result = new ListaTarefaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<ListaTarefa>))]
        public IHttpActionResult GetAll()
        {
            var result = new ListaTarefaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByEquipamentoid")]
        [ResponseType(typeof(List<ListaTarefa>))]
        public IHttpActionResult GetByEquipamentoid(int id_equipamento)
        {
            var result = new ListaTarefaService().GetByEquipamentoid(id_equipamento);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(ListaTarefa))]
        public IHttpActionResult Add(ListaTarefa obj)
        {
            var result = new ListaTarefaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(ListaTarefa))]
        public IHttpActionResult Update(ListaTarefa obj)
        {
            var result = new ListaTarefaService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(ListaTarefa))]
        public IHttpActionResult Delete(ListaTarefa ListaTarefa)
        {
            var result = new ListaTarefaService().Delete(ListaTarefa);
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

