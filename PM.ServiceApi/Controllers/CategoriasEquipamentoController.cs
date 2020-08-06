using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/CategoriasEquipamento")]
    public class CategoriasEquipamentoController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(CategoriaEquipamento))]
        public IHttpActionResult GetById(int id)
        {
            CategoriaEquipamento result = new CategoriaEquipamentoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<CategoriaEquipamento>))]
        public IHttpActionResult GetAll()
        {
            var result = new CategoriaEquipamentoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(CategoriaEquipamento))]
        public IHttpActionResult Add(CategoriaEquipamento obj)
        {
            var result = new CategoriaEquipamentoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(CategoriaEquipamento))]
        public IHttpActionResult Update(CategoriaEquipamento obj)
        {
            var result = new CategoriaEquipamentoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(CategoriaEquipamento))]
        public IHttpActionResult Delete(CategoriaEquipamento catalogo)
        {
            var result = new CategoriaEquipamentoService().Delete(catalogo);
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

