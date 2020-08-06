using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/MedidasNota")]
    public class MedidasNotaController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(MedidaNota))]
        public IHttpActionResult GetById(int id)
        {
            MedidaNota result = new MedidaNotaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetNavigationPropertiesByNota")]
        [ResponseType(typeof(List<MedidaNota>))]
        public IHttpActionResult GetNavigationPropertiesByNota(int id)
        {
            List<MedidaNota> result = new MedidaNotaService().GetNavigationPropertiesByNota(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<MedidaNota>))]
        public IHttpActionResult GetAll()
        {
            var result = new MedidaNotaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByNota")]
        [ResponseType(typeof(List<MedidaNota>))]
        public IHttpActionResult GetByNota(int id)
        {
            var result = new MedidaNotaService().GetByNota(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(MedidaNota))]
        public IHttpActionResult Add(MedidaNota obj)
        {
            var result = new MedidaNotaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(MedidaNota))]
        public IHttpActionResult Update(MedidaNota obj)
        {
            var result = new MedidaNotaService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(MedidaNota))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new MedidaNotaService().DeleteById(id);
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

