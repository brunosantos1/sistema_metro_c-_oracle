using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Notas")]
    public class NotasController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult GetById(int id)
        {
            Nota result = new NotaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("CountByFrotaTremCarro")]
        [ResponseType(typeof(object))]
        public IHttpActionResult GetByFrotaTremCarro(int idFrota, int idTrem, int idCarro)
        {
            int quant = new NotaService().CountByFrotaTremCarro(idFrota, idTrem, idCarro);
            if (quant == null)
            {
                return NotFound();
            }
            else
            {

                return Ok(new { total = quant });
            }
        }

        [Route("CarregarUltima")]
        [ResponseType(typeof(Nota))]
        [HttpGet]
        public IHttpActionResult CarregarUltima(string tpNota)
        {
            Nota result = new NotaService().CarregarUltima(tpNota);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        #region NotaMC
        [Route("CancelarMC")]
        [ResponseType(typeof(Nota))]
        [HttpGet]
        public IHttpActionResult CancelarMC(int id, string motivo)
        {
            Nota result = new NotaService().CancelarMC(id, motivo);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("CriarMC")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult CriarMC(Nota obj)
        {
            DatabaseContext newContext = new DatabaseContext();

            var result = new NotaService(newContext).CriarMC(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("EditarMC")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult EditarMC(Nota obj)
        {
            DatabaseContext newContext = new DatabaseContext();

            var result = new NotaService(newContext).EditarMC(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("PesquisarNotaMC")]
        [ResponseType(typeof(List<Nota>))]
        [HttpGet]
        public IHttpActionResult PesquisarNotaMC(int? idFrota = null, int? idTrem = null, int? idCarro = null, int? idSistema = null, int? idSintoma = null, string cdSap = null, string dataInicial = null, string dataFinal = null, int? idPrioridade = null, int? idNotificador = null, int? rg_notificador = null, int? idStatus = null)
        {
            DateTime? convertedDataInicial = null;
            DateTime? convertedDataFinal = null;
            if (dataInicial != null)
            {
                convertedDataInicial = DateTime.Parse(dataInicial);
            }
            if (dataFinal != null)
            {
                convertedDataFinal = DateTime.Parse(dataFinal);
            }

            var result = new NotaService().PesquisarNotaMC(idFrota, idTrem, idCarro, idSistema, idSintoma, cdSap, convertedDataInicial, convertedDataFinal, idPrioridade, idNotificador, rg_notificador, idStatus);//, idTrem, idCarro, idSistema, idSintoma, cdSap, dataInicial, dataFinal, idPrioridade, idNotificador, rg_notificador, idStatus);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("PesquisarNotaProgramacao")]
        [ResponseType(typeof(List<Nota>))]
        [HttpGet]
        public IHttpActionResult PesquisarNotaProgramacao(int? idFrota = null, int? idTrem = null, int? idCarro = null, int? idSistema = null, int? idSintoma = null, string cdSap = null, string dataInicial = null, string dataFinal = null, int? idPrioridade = null, int? idNotificador = null, int? rg_notificador = null, int? idStatus = null, int? idNotStatus = null, string cd_sap = "MC")
        {
            DateTime? convertedDataInicial = null;
            DateTime? convertedDataFinal = null;
            if (dataInicial != null)
            {
                convertedDataInicial = DateTime.Parse(dataInicial);
            }
            if (dataFinal != null)
            {
                convertedDataFinal = DateTime.Parse(dataFinal);
            }

            var result = new NotaService().PesquisarNotaProgramacao(idFrota, idTrem, idCarro, idSistema, idSintoma, cdSap, convertedDataInicial, convertedDataFinal, idPrioridade, idNotificador, rg_notificador, idStatus, idNotStatus, cd_sap);//, idTrem, idCarro, idSistema, idSintoma, cdSap, dataInicial, dataFinal, idPrioridade, idNotificador, rg_notificador, idStatus);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        #endregion

        #region NotaMS
        [Route("CriarMS")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult CriarMS(Nota obj)
        {
            DatabaseContext newContext = new DatabaseContext();

            var result = new NotaService(newContext).CriarMS(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("EditarMS")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult EditarMS(Nota obj)
        {
            DatabaseContext newContext = new DatabaseContext();

            var result = new NotaService(newContext).EditarMS(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        #endregion

        #region NotaMD
        [Route("CancelarMD")]
        [ResponseType(typeof(Nota))]
        [HttpGet]
        public IHttpActionResult CancelarMD(int id, string motivo)
        {
            Nota result = new NotaService().CancelarMD(id, motivo);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("CriarMD")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult CriarMD(Nota obj)
        {
            DatabaseContext newContext = new DatabaseContext();

            var result = new NotaService(newContext).CriarMD(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("EditarMD")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult EditarMD(Nota obj)
        {
            DatabaseContext newContext = new DatabaseContext();

            var result = new NotaService(newContext).EditarMD(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        #endregion

        [Route("GetNotasCodigoSap")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult GetNotasCodigoSap(string nr_nota_sap)
        {
            Nota result = new NotaService().GetNotasCodigoSap(nr_nota_sap);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetNotasCodigoSapMR")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult GetNotasCodigoSapMR(string nr_nota_sap)
        {
            Nota result = new NotaService().GetNotasCodigoSapMR(nr_nota_sap);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetNotasCodigoSapEF")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult GetNotasCodigoSapEF(string nr_nota_sap)
        {
            Nota result = new NotaService().GetNotasCodigoSapEF(nr_nota_sap);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAbertasPendentes")]
        [ResponseType(typeof(List<Nota>))]
        public IHttpActionResult GetAbertasPendentes(int idFrota, int idTrem, string tpNota)
        {
            var result = new NotaService().GetAbertasPendentes(idFrota, idTrem, tpNota);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetNavigationPropertiesById")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult GetNavigationPropertiesByID(int id)
        {
            Nota result = new NotaService().GetNavigationPropertiesByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetNotaVinculadaTrem")]
        [ResponseType(typeof(List<Nota>))]
        public IHttpActionResult GetNotaVinculadaTrem(int idTrem, string cd_sap)
        {
            List<Nota> result = new List<Nota>();
            try
            {
                result = new NotaService().GetNotaVinculadaTrem(idTrem, cd_sap);
                if (result == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                ex = ex;
            }

            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Nota>))]
        public IHttpActionResult GetAll()
        {
            var result = new NotaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetNotasVinculadas")]
        [ResponseType(typeof(List<Nota>))]
        public IHttpActionResult GetNotasVinculadas(int id)
        {
            var result = new NotaService().GetNotasVinculadas(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetNotasVinculadasEntregaTrem")]
        [ResponseType(typeof(List<Nota>))]
        public IHttpActionResult GetNotasVinculadasEntregaTrem(int idEntregaTrem, int idTipoNota)
        {
            var result = new NotaService().GetNotasVinculadasEntregaTrem(idEntregaTrem, idTipoNota);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetNotasVinculadasNavigationProperties")]
        [ResponseType(typeof(List<Nota>))]
        public IHttpActionResult GetNotasVinculadasNavigationProperties(int id)
        {
            var result = new NotaService().GetNotasVinculadasNavigationProperties(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("ConsultarNotaParametros")]
        [ResponseType(typeof(List<Nota>))]
        public IHttpActionResult ConsultarNotaParametros(Nota nota)
        {
            List<Nota> result = new NotaService().ConsultarNotaParametros(nota);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("ConsultarNotaCopeseEFMRParametros")]
        [ResponseType(typeof(List<Nota>))]
        public IHttpActionResult ConsultarNotaCopeseEFMRParametros(Nota nota, DateTime dtIni, DateTime dtFim)
        {
            List<Nota> result = new NotaService().ConsultarNotaCopeseEFMRParametros(nota, dtIni, dtFim);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("ConsultarNotaPericiaMRParametros")]
        [ResponseType(typeof(List<Nota>))]
        public IHttpActionResult ConsultarNotaPericiaMRParametros(Nota nota, string dtIni, string dtFim)
        {
            List<Nota> result = new NotaService().ConsultarNotaPericiaMRParametros(nota, dtIni, dtFim);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetNotasCodigoSapPericia")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult GetNotasCodigoSapPericia(string nr_nota_sap)
        {
            Nota result = new NotaService().GetNotasCodigoSapPericia(nr_nota_sap);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /*[Route("GetAllByLinhaZonaSistema")]
        [ResponseType(typeof(List<Nota>))]
        public IHttpActionResult GetAllByLinhaZonaSistema(int linha, int zona, int sistema)
        {
            var result = new NotaService().GetAllByLinhaZonaSistema(linha, zona, sistema);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }*/

        #region NotaMI
        [Route("CriarMI")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult CriarMI(Nota obj)
        {
            DatabaseContext newContext = new DatabaseContext();
            var result = new NotaService(newContext).CriarMI(obj);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("EditarMI")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult EditarMI(Nota obj)
        {
            DatabaseContext newContext = new DatabaseContext();
            var result = new NotaService(newContext).EditarMI(obj);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("CancelarMI")]
        [ResponseType(typeof(Nota))]
        [HttpGet]
        public IHttpActionResult CancelarMI(int id, string motivo)
        {
            Nota result = new NotaService().CancelarMI(id, motivo);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("PesquisarNotaMI")]
        [ResponseType(typeof(List<Nota>))]
        [HttpGet]
        public IHttpActionResult PesquisarNotaMI(int? idFrota = null, int? idTrem = null, int? idCarro = null, string cdSap = null, string dataInicial = null, string dataFinal = null, int? idNotificador = null, int? rg_notificador = null, int? idStatus = null)
        {
            DateTime? convertedDataInicial = null;
            DateTime? convertedDataFinal = null;

            if (dataInicial != null)
            {
                convertedDataInicial = DateTime.Parse(dataInicial);
            }

            if (dataFinal != null)
            {
                convertedDataFinal = DateTime.Parse(dataFinal);
            }

            var result = new NotaService().PesquisarNotaMI(idFrota, idTrem, idCarro, cdSap, convertedDataInicial, convertedDataFinal, idNotificador, rg_notificador, idStatus);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        #endregion

        #region Pericia 
        [Route("AddPericia")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult AddPericia(Nota obj)
        {
            var result = new NotaService().AddPericia(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("UpdatePericia")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult UpdatePericia(Nota obj)
        {
            var result = new NotaService().UpdatePericia(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("LiberarPericia")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult LiberarPericia(Nota obj)
        {
            var result = new NotaService().LiberarPericia(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("EncerrarPericia")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult EncerrarPericia(Nota obj)
        {
            var result = new NotaService().EncerrarPericia(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        #endregion

        [Route("AddCopese")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult AddCopese(Nota obj)
        {
            var result = new NotaService().AddCopese(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("UpdateCopese")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult UpdateCopese(Nota obj)
        {
            var result = new NotaService().UpdateCopese(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DescaracterizarCopese")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult DescaracterizarCopese(Nota obj)
        {
            var result = new NotaService().DescaracterizarCopese(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("EncerrarCopese")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult EncerrarCopese(Nota obj)
        {
            var result = new NotaService().EncerrarCopese(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Route("Add")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult Add(Nota obj)
        {
            var result = new NotaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult Update(Nota obj)
        {
            var result = new NotaService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new NotaService().DeleteById(id);
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
