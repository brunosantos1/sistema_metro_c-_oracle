using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Equipamentos")]
    public class EquipamentosController : ApiController
    {
        [Route("ConsultarEFParametros")]
        [ResponseType(typeof(List<Equipamento>))]
        public IHttpActionResult ConsultarEFParametros(Equipamento equipamento)
        {
            List<Equipamento> result = new EquipamentoService().ConsultarEFParametros(equipamento);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetById")]
        [ResponseType(typeof(Equipamento))]
        public IHttpActionResult GetById(int id)
        {
            Equipamento result = new EquipamentoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Equipamento>))]
        public IHttpActionResult GetAll()
        {
            var result = new EquipamentoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(Equipamento))]
        public IHttpActionResult Add(Equipamento obj)
        {
            var result = new EquipamentoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Equipamento))]
        public IHttpActionResult Update(Equipamento obj)
        {
            var result = new EquipamentoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Equipamento))]
        public IHttpActionResult Delete(Equipamento catalogo)
        {
            var result = new EquipamentoService().Delete(catalogo);
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

