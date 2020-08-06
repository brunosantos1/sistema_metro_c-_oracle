using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.WebServices.Service
{
    public class NotaServices
    {
        public IList<Nota> GetAll()
        {
            return NotasExtensions.GetAll(Links.appN.Notas);
        }
        public object GetByFrotaTremCarro(int idFrota, int idTrem, int idCarro)
        {
            object obj1 = NotasExtensions.GetByFrotaTremCarro(Links.appN.Notas, idFrota, idTrem, idCarro);
            return obj1;
        }
        public Nota CarregarUltima(string tpNota)
        {
            return NotasExtensions.CarregarUltima(Links.appN.Notas, tpNota);
        }

        public Nota GetById(int id)
        {
            return NotasExtensions.GetById(Links.appN.Notas, id);
        }

        #region NotaMC
        public Nota CriarMC(Nota _param)
        {
            try
            {
                return NotasExtensions.CriarMC(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Nota CancelarMC(int id, string motivo)
        {
            try
            {
                return NotasExtensions.CancelarMC(Links.appN.Notas, id, motivo);
            }
            catch (System.Exception e)
            {
                Nota _param = new Nota();
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Nota EditarMC(Nota _param)
        {
            try
            {
                return NotasExtensions.EditarMC(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }
        #endregion

        #region NotaMS
        public Nota CriarMS(Nota _param)
        {
            try
            {
                return NotasExtensions.CriarMS(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Nota EditarMS(Nota _param)
        {
            try
            {
                return NotasExtensions.EditarMS(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }
        #endregion

        #region NotaMD
        public Nota CriarMD(Nota _param)
        {
            try
            {
                return NotasExtensions.CriarMD(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Nota CancelarMD(int id, string motivo)
        {
            try
            {
                return NotasExtensions.CancelarMD(Links.appN.Notas, id, motivo);
            }
            catch (System.Exception e)
            {
                Nota _param = new Nota();
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Nota EditarMD(Nota _param)
        {
            try
            {
                return NotasExtensions.EditarMD(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }
        #endregion

        public Nota GetNotasCodigoSap(string nr_nota_sap)
        {
            try
            {
                return NotasExtensions.GetNotasCodigoSap(Links.appN.Notas, nr_nota_sap);
            }
            catch (System.Exception e)
            {
                return new Nota();
            }
        }

        public Nota GetNotasCodigoSapPericia(string nr_nota_sap)
        {
            try
            {
                return NotasExtensions.GetNotasCodigoSapPericia(Links.appN.Notas, nr_nota_sap);
            }
            catch (System.Exception e)
            {
                return new Nota();
            }
        }

        public Nota GetNotasCodigoSapPericiaRef(string nr_nota_sap)
        {
            try
            {
                Nota nota = NotasExtensions.GetNotasCodigoSap(Links.appN.Notas, nr_nota_sap);
                if ("MC-MI-MP-MS-EC-EI-ED-EP".IndexOf(nota.TipoNota.CdSap) < 0)
                    return new Nota();
                else
                    return nota;
            }
            catch (System.Exception e)
            {
                return new Nota();
            }
        }

        public Nota GetNotasCodigoSapMR(string nr_nota_sap)
        {
            try
            {
                Nota nota = NotasExtensions.GetNotasCodigoSapPericia(Links.appN.Notas, nr_nota_sap);
                if ("MC-MI-MP-MS".IndexOf(nota.TipoNota.CdSap) < 0)
                    return new Nota();
                else
                    return nota;
            }
            catch (System.Exception e)
            {
                return new Nota();
            }
        }

        public IList<Nota> GetAbertasPendentes(int idFrota, int idTrem, string tp)
        {
            return NotasExtensions.GetAbertasPendentes(Links.appN.Notas, idFrota, idTrem, tp);
        }

        public Nota GetNavigationPropertiesById(int id)
        {
            return NotasExtensions.GetNavigationPropertiesByID(Links.appN.Notas, id);
        }

        public IList<Nota> GetNotasVinculadas(int id)
        {
            return NotasExtensions.GetNotasVinculadas(Links.appN.Notas, id);
        }

        public IList<Nota> GetNotasVinculadasEntregaTrem(int idEntregaTrem, int idTipoNota)
        {
            return NotasExtensions.GetNotasVinculadasEntregaTrem(Links.appN.Notas, idEntregaTrem, idTipoNota);
        }

        public IList<Nota> GetNotasVinculadasNavigationProperties(int id)
        {
            return NotasExtensions.GetNotasVinculadasNavigationProperties(Links.appN.Notas, id);
        }

        public IList<Nota> GetNotaVinculadaTrem(int idTrem, string cd_sap)
        {
            //return NotasExtensions.GetNotaVinculadaTrem(Links.appN.Notas, idTrem, idTipoNota);

            List<Nota> ret = new List<Nota>();
            try
            {
                ret = (List<Nota>)NotasExtensions.GetNotaVinculadaTrem(Links.appN.Notas, idTrem, cd_sap);
            }
            catch (Exception ex)
            {
                ex = ex;
            }
            return ret;
        }

        public IList<Nota> ConsultarNotaParametros(Nota nota)
        {
            //IList<Nota> retorno = null;
            IList<Nota> retorno;

            try
            {
                retorno = NotasExtensions.ConsultarNotaParametros(Links.appN.Notas, nota);

                if (retorno == null)
                    return new List<Nota>();
                else
                    return retorno as List<Nota>;
            }
            catch (System.Exception e)
            {
                return new List<Nota>();
            }
        }
        public IList<Nota> ConsultarNotaCopeseEFMRParametros(Nota nota, DateTime dtIni, DateTime dtFim)
        {
            return NotasExtensions.ConsultarNotaCopeseEFMRParametros(Links.appN.Notas, nota, dtIni, dtFim);
        }
        public IList<Nota> ConsultarNotaPericiaMRParametros(Nota nota, string dtIni, string dtFim)
        {
            return NotasExtensions.ConsultarNotaPericiaMRParametros(Links.appN.Notas, nota, dtIni, dtFim);
        }

        #region NotaMI
        public Nota CriarMI(Nota _nota)
        {
            try
            {
                return NotasExtensions.CriarMI(Links.appN.Notas, _nota);
            }
            catch (Exception e)
            {
                _nota.BaseModel = new BaseModel();
                _nota.BaseModel.Erro = true;
                _nota.BaseModel.Retorno = (int)MessageType.Error;
                _nota.BaseModel.MensagemUsuario = "erro processar";
                _nota.BaseModel.MensagemException = e;

                return _nota;
            }
        }

        public Nota EditarMI(Nota _nota)
        {
            try
            {
                return NotasExtensions.EditarMI(Links.appN.Notas, _nota);
            }
            catch (Exception e)
            {
                _nota.BaseModel = new BaseModel();
                _nota.BaseModel.Erro = true;
                _nota.BaseModel.Retorno = (int)MessageType.Error;
                _nota.BaseModel.MensagemUsuario = "erro processar";
                _nota.BaseModel.MensagemException = e;

                return _nota;
            }
        }

        public Nota CancelarMI(int id, string motivo)
        {
            try
            {
                return NotasExtensions.CancelarMI(Links.appN.Notas, id, motivo);
            }
            catch (System.Exception e)
            {
                Nota _nota = new Nota();
                _nota.BaseModel = new BaseModel();
                _nota.BaseModel.Erro = true;
                _nota.BaseModel.Retorno = (int)MessageType.Error;
                _nota.BaseModel.MensagemUsuario = "erro processar";
                _nota.BaseModel.MensagemException = e;
                return _nota;
            }
        }

        public IList<Nota> PesquisarMI(int? idFrota = null, int? idTrem = null, int? idCarro = null, string cdSap = null, string dataInicial = null, string dataFinal = null, int? idNotificador = null, int? rgNotificador = null, int? idStatus = null)
        {
            return NotasExtensions.PesquisarNotaMI(Links.appN.Notas, idFrota, idTrem, idCarro, cdSap, dataInicial, dataFinal, idNotificador, rgNotificador, idStatus);
        }
        #endregion


        #region Pericia
        public Nota AddPericia(Nota _param)
        {
            try
            {
                return NotasExtensions.AddPericia(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Nota UpdatePericia(Nota _param)
        {
            try
            {
                //return NotasExtensions.UpdatePericia(Links.appN.Notas, _param);
                return NotasExtensions.UpdatePericia(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "Mensagens.Erro_Processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Nota LiberarPericia(Nota _param)
        {
            try
            {
                return NotasExtensions.LiberarPericia(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Nota EncerrarPericia(Nota _param)
        {
            try
            {
                return NotasExtensions.EncerrarPericia(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }
        #endregion

        #region Copese

        public Nota AddCopese(Nota _param)
        {
            try
            {
                return NotasExtensions.AddCopese(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Nota DescaracterizarCopese(Nota _param)
        {
            try
            {
                return NotasExtensions.DescaracterizarCopese(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Nota EncerrarCopese(Nota _param)
        {
            try
            {
                return NotasExtensions.EncerrarCopese(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        #endregion

        public Nota Add(Nota _param)
        {
            try
            {
                return NotasExtensions.Add(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "erro processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Nota Update(Nota _param)
        {
            try
            {
                return NotasExtensions.Update(Links.appN.Notas, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "Mensagens.Erro_Processar";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Nota GetNotasCodigoSapMRRef(string nr_nota_sap)
        {
            try
            {
                Nota nota = NotasExtensions.GetNotasCodigoSap(Links.appN.Notas, nr_nota_sap);
                if ("MC-MI-MP-MS".IndexOf(nota.TipoNota.CdSap) < 0)
                    return new Nota();
                else
                    return nota;
            }
            catch (System.Exception e)
            {
                return new Nota();
            }
        }

        public Nota GetNotasCodigoSapEFRef(string nr_nota_sap)
        {
            try
            {
                Nota nota = NotasExtensions.GetNotasCodigoSap(Links.appN.Notas, nr_nota_sap);
                if ("EC-EI-ED-EP".IndexOf(nota.TipoNota.CdSap) < 0)
                    return new Nota();
                else
                    return nota;
            }
            catch (System.Exception e)
            {
                return new Nota();
            }
        }

        public IList<Nota> PesquisarMC(int? idFrota = null, int? idTrem = null, int? idCarro = null, int? idSistema = null, int? idSintoma = null, string cdSap = null, string dataInicial = null, string dataFinal = null, int? idPrioridade = null, int? idNotificador = null, int? rgNotificador = null, int? idStatus = null)
        {
            return NotasExtensions.PesquisarNotaMC(Links.appN.Notas, idFrota, idTrem, idCarro, idSistema, idSintoma, cdSap, dataInicial, dataFinal, idPrioridade, idNotificador, rgNotificador, idStatus);
        }

        public IList<Nota> PesquisarNotaProgramacao(int? idFrota = null, int? idTrem = null, int? idCarro = null, int? idSistema = null, int? idSintoma = null, string cdSap = null, string dataInicial = null, string dataFinal = null, int? idPrioridade = null, int? idNotificador = null, int? rgNotificador = null, int? idStatus = null, int? idNotStatus = null, string cd_sap = "MC")
        {
            return NotasExtensions.PesquisarNotaProgramacao(Links.appN.Notas, idFrota, idTrem, idCarro, idSistema, idSintoma, cdSap, dataInicial, dataFinal, idPrioridade, idNotificador, rgNotificador, idStatus, idNotStatus, cd_sap);
        }


        //public NotaViewModel Delete(Nota nota)
        //{
        //    return NotasExtensions.Delete(Links.appN.Notas, nota);
        //}

        //public async Task<RegiaoViewModel> GetAllAsync()
        //{
        //    RegiaoViewModel uFVM = new RegiaoViewModel();
        //    uFVM.Regiaos = await RegioesExtensions.GetAllAsync(Links.appN.Regioes);
        //    return uFVM;
        //}

        //public async Task<RegiaoViewModel> GetByPaisAsync(long paisID)
        //{
        //    RegiaoViewModel uFVM = new RegiaoViewModel();
        //    uFVM.Regiaos = await RegioesExtensions.GetByPaisAsync(Links.appN.Regioes, paisID);
        //    return uFVM;
        //}

        //public async Task<RegiaoViewModel> GetByIDAsync(long id)
        //{
        //    RegiaoViewModel vm = new RegiaoViewModel();
        //    vm.Regiao = await RegioesExtensions.GetByIDAsync(Links.appN.Regioes, id); 
        //    return vm;
        //}

    }
}