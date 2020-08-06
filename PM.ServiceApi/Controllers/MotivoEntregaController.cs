using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/MotivoEntrega")]
    public class MotivoEntregaController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(MotivoEntrega))]
        public IHttpActionResult GetById(int id)
        {
            MotivoEntrega result = new MotivoEntregaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("GetAll")]
        [ResponseType(typeof(List<MotivoEntrega>))]
        public IHttpActionResult GetAll()
        {
            var result = new MotivoEntregaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(MotivoEntrega))]
        public IHttpActionResult Add(MotivoEntrega obj)
        {
            var result = new MotivoEntregaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //[Route("Update")]
        //[ResponseType(typeof(MotivoEntrega))]
        //public IHttpActionResult Update(MotivoEntrega obj)
        //{
        //    var result = new MotivoEntregaService().Update(obj);
        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(result);
        //}

        //[Route("Delete")]
        //[ResponseType(typeof(MotivoEntrega))]
        //public IHttpActionResult Delete(MotivoEntrega MotivoEntrega)
        //{
        //    var result = new MotivoEntregaService().Delete(MotivoEntrega);
        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(result);
        //}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}

