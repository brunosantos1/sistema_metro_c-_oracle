using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Linhas")]
    public class LinhasController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Linha))]
        public IHttpActionResult GetById(int id)
        {
            Linha result = new LinhaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByTrem")]
        [ResponseType(typeof(Linha))]
        public IHttpActionResult GetByTrem(int idTrem)
        {
            Linha result = new LinhaService().GetByTrem(idTrem);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Linha>))]
        public IHttpActionResult GetAll()
        {
            var result = new LinhaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(Linha))]
        public IHttpActionResult Add(Linha obj)
        {
            var result = new LinhaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Linha))]
        public IHttpActionResult Update(Linha obj)
        {
            var result = new LinhaService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Linha))]
        public IHttpActionResult Delete(Linha catalogo)
        {
            var result = new LinhaService().Delete(catalogo);
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

