using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Trems")]
    public class TremsController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Trem))]
        public IHttpActionResult GetById(int id)
        {
            Trem result = new TremService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Trem>))]
        public IHttpActionResult GetAll()
        {
            var result = new TremService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByFrota")]
        [ResponseType(typeof(List<Trem>))]
        public IHttpActionResult GetByFrota(int id)
        {
            var result = new TremService().GetByFrota(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByPatioLinhaStatus")]
        [ResponseType(typeof(List<Trem>))]
        public IHttpActionResult GetByPatioLinhaStatus(int idLinha, int idPatio, int idStatus, int Manobra)
        {
            var result = new TremService().GetByPatioLinhaStatus(idLinha, idPatio, idStatus, Manobra);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [Route("GetByLinhaPatioTrem")]
        [ResponseType(typeof(List<Trem>))]
        public IHttpActionResult GetByLinhaPatioTrem(int idLinha, int idPatio, int idTrem)
        {
            var result = new TremService().GetByLinhaPatioTrem(idLinha, idPatio, idTrem);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [Route("Add")]
        [ResponseType(typeof(Trem))]
        public IHttpActionResult Add(Trem obj)
        {
            var result = new TremService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Trem))]
        public IHttpActionResult Update(Trem obj)
        {
            var result = new TremService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Trem))]
        public IHttpActionResult Delete(Trem obj)
        {
            var result = new TremService().Delete(obj);
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

