using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/EntregaTrem")]
    public class EntregaTremController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(EntregaTrem))]
        public IHttpActionResult GetById(int id)
        {
            EntregaTrem result = new EntregaTremService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetNavigationPropertiesByID")]
        [ResponseType(typeof(EntregaTrem))]
        public IHttpActionResult GetNavigationPropertiesByID(int id)
        {
            EntregaTrem result = new EntregaTremService().GetNavigationPropertiesByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByEntrega")]
        [ResponseType(typeof(List<EntregaTrem>))]
        public IHttpActionResult GetByEntrega(int idLinha, int idPatio, int idTrem, int idMotivo, DateTime dtInicio, DateTime dtFinal)
        {
            var result = new EntregaTremService().GetByEntrega(idLinha, idPatio, idTrem, idMotivo, dtInicio, dtFinal);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<EntregaTrem>))]
        public IHttpActionResult GetAll()
        {
            var result = new EntregaTremService().GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(EntregaTrem))]
        public IHttpActionResult Add(EntregaTrem obj)
        {
            var result = new EntregaTremService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(EntregaTrem))]
        public IHttpActionResult Update(EntregaTrem obj)
        {
            var result = new EntregaTremService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(EntregaTrem))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new EntregaTremService().DeleteById(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("LiberarEntregaTrem")]
        [ResponseType(typeof(EntregaTrem))]
        public IHttpActionResult LiberarEntregaTrem(EntregaTrem obj)
        {
            var result = new EntregaTremService().LiberarEntregaTrem(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("CancelaEntregaTrem")]
        [ResponseType(typeof(EntregaTrem))]
        public IHttpActionResult CancelaEntregaTrem(EntregaTrem obj)
        {
            var result = new EntregaTremService().CancelaEntregaTrem(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("MudarLocalEntregaTrem")]
        [ResponseType(typeof(EntregaTrem))]
        public IHttpActionResult MudarLocalEntregaTrem(EntregaTrem obj)
        {
            var result = new EntregaTremService().MudarLocalEntregaTrem(obj);
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
