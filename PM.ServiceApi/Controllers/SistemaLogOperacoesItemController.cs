using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaLogOperacoesItem")]
    public class SistemaLogOperacoesItemController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaLogOperacoesItem))]
        public IHttpActionResult GetById(int id)
        {
            SistemaLogOperacoesItem result = new SistemaLogOperacoesItemService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaLogOperacoesItem>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaLogOperacoesItemService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaLogOperacoesItem))]
        public IHttpActionResult Add(SistemaLogOperacoesItem obj)
        {
            var result = new SistemaLogOperacoesItemService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaLogOperacoesItem obj)
        {
            var result = new SistemaLogOperacoesItemService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaLogOperacoesItem))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaLogOperacoesItemService().DeleteById(id);
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

