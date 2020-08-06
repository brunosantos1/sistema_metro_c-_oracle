using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Carros")]
    public class CarrosController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Carro))]
        public IHttpActionResult GetById(int id)
        {
            Carro result = new CarroService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Carro>))]
        public IHttpActionResult GetAll()
        {
            var result = new CarroService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByTrem")]
        [ResponseType(typeof(List<Carro>))]
        public IHttpActionResult GetByTrem(int id)
        {
            var result = new CarroService().GetByTrem(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(Carro))]
        public IHttpActionResult Add(Carro obj)
        {
            var result = new CarroService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Carro))]
        public IHttpActionResult Update(Carro obj)
        {
            var result = new CarroService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Carro))]
        public IHttpActionResult Delete(Carro catalogo)
        {
            var result = new CarroService().Delete(catalogo);
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

