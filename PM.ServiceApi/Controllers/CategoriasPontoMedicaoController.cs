using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/CategoriasPontoMedicao")]
    public class CategoriasPontoMedicaoController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(CategoriaPontoMedicao))]
        public IHttpActionResult GetById(int id)
        {
            CategoriaPontoMedicao result = new CategoriaPontoMedicaoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<CategoriaPontoMedicao>))]
        public IHttpActionResult GetAll()
        {
            var result = new CategoriaPontoMedicaoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(CategoriaPontoMedicao))]
        public IHttpActionResult Add(CategoriaPontoMedicao obj)
        {
            var result = new CategoriaPontoMedicaoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(CategoriaPontoMedicao))]
        public IHttpActionResult Update(CategoriaPontoMedicao obj)
        {
            var result = new CategoriaPontoMedicaoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(CategoriaPontoMedicao))]
        public IHttpActionResult Delete(CategoriaPontoMedicao catalogo)
        {
            var result = new CategoriaPontoMedicaoService().Delete(catalogo);
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

