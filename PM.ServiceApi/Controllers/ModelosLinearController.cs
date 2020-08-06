using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/ModelosLinear")]
    public class ModelosLinearController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(ModeloLinear))]
        public IHttpActionResult GetById(int id)
        {
            ModeloLinear result = new ModeloLinearService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<ModeloLinear>))]
        public IHttpActionResult GetAll()
        {
            var result = new ModeloLinearService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(ModeloLinear))]
        public IHttpActionResult Add(ModeloLinear obj)
        {
            var result = new ModeloLinearService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(ModeloLinear))]
        public IHttpActionResult Update(ModeloLinear obj)
        {
            var result = new ModeloLinearService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(ModeloLinear))]
        public IHttpActionResult Delete(ModeloLinear modeloLinear)
        {
            var result = new ModeloLinearService().Delete(modeloLinear);
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

