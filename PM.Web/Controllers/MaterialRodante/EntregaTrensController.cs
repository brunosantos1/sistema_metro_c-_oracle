using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.Web.ViewModel;

namespace PM.Web.Controllers.MaterialRodante
{
    public class EntregaTrensController : BaseController
    {
        

        public JsonResult AtualizaDadosGravacao(string cd_sap, int idRegistro, int idEntrega = 0)
        {
            JsonResult result = new JsonResult();
            try
            {
                TipoNota tipoNota = (new TipoNotaServices()).GetByCodigoSap(cd_sap);
                int idTipo = int.Parse(tipoNota.IdTpNota.ToString());

                string NomeGrid             = cd_sap.ToUpper().Equals("MC") ? "Ocorrencia" : cd_sap.ToUpper().Equals("MI") ? "Inspecao" : "Programacao";
                string NomeOrigemDataTemp   = string.Format("TempData_Origem_{0}_NotaTipo_{1}"  , NomeGrid, tipoNota.CdSap.ToUpper()).ToUpper();
                string NomeDestinoDataTemp  = string.Format("TempData_Destino_{0}_NotaTipo_{1}" , NomeGrid, tipoNota.CdSap.ToUpper()).ToUpper();
                List<Nota> lstOrigem        = new List<Nota>();
                List<Nota> lstDestino       = new List<Nota>();
                lstOrigem                   = TempData[NomeOrigemDataTemp] as List<Nota>;
                TempData.Keep(NomeOrigemDataTemp);

                if (idEntrega.Equals(0))
                {
                    if (TempData[NomeDestinoDataTemp] == null)
                    {
                        lstDestino = lstOrigem.Where(c => c.IdNota.Equals(idRegistro) && c.IdTpNotaFk.Equals(idTipo)).ToList();
                        TempData[NomeDestinoDataTemp] = lstDestino;
                        TempData.Keep(NomeDestinoDataTemp);
                    }
                    else
                    {
                        if (!lstOrigem.Where(c => c.IdNota.Equals(idRegistro) && c.IdTpNotaFk.Equals(idTipo)).ToList().Count.Equals(0))
                        {
                            lstDestino = TempData[NomeDestinoDataTemp] as List<Nota>;
                            TempData.Keep(NomeDestinoDataTemp);

                            if (lstDestino.Where(c => c.IdNota.Equals(idRegistro) && c.IdTpNotaFk.Equals(idTipo)).ToList().Count.Equals(0))
                            {
                                // Adciona
                                lstDestino.Add((lstOrigem.Where(c => c.IdNota.Equals(idRegistro) && c.IdTpNotaFk.Equals(idTipo)).ToList())[0]);
                            }
                            else
                            {
                                // Remove
                                lstDestino.Remove((lstOrigem.Where(c => c.IdNota.Equals(idRegistro) && c.IdTpNotaFk.Equals(idTipo)).ToList())[0]);
                                if (!lstDestino.Where(c => c.IdNota.Equals(idRegistro)).ToList().Count.Equals(0))
                                {
                                    lstDestino = lstDestino.Where(c => c.IdNota != idRegistro && c.IdTpNotaFk.Equals(idTipo)).ToList();
                                }
                            }
                            TempData[NomeDestinoDataTemp] = lstDestino;
                            TempData.Keep(NomeDestinoDataTemp);
                        }
                    }
                }
                else
                {
                    lstDestino = (new NotaServices()).GetNotasVinculadasEntregaTrem(idEntrega, idTipo).ToList();
                    TempData[NomeDestinoDataTemp] = lstDestino;
                    TempData.Keep(NomeDestinoDataTemp);
                }
                if (lstDestino.Count > 0)
                {
                    string sCor = "#F00";
                    List<String[]> values = lstDestino.Select(x => new String[] {
                                                          string.Format("{0:000000}", x.IdNota)
                                                        , (x.LocalInstalacao == null)                   ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) :  x.LocalInstalacao.DsLcInstalacao.ToUpper()
                                                        , string.IsNullOrEmpty(x.DsDescricao)           ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.DsDescricao.ToUpper()
                                                        , (x.CodeSintoma == null)                       ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.CodeSintoma.DsCode.ToUpper()
                                                        , (x.Prioridade == null)                        ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.Prioridade.DsPrioridade.ToUpper()
                                                        , (lstDestino[0].DtHoraNota == null)            ? ""                                                                                        : string.Format("{0:dd/MM/yyyy HH:mm:ss}",DateTime.Parse(x.DtHoraNota.ToString()))
                                                        , string.IsNullOrEmpty(x.Empregado.RgEmpregado) ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.Empregado.RgEmpregado.ToUpper()
                                                        , (x.CentroTrabalho == null)                    ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.CentroTrabalho.DsCtTrabalho
                                                        , (x.StatusSistema  == null)                    ? string.Format("<span style='color:{0}'><strong>ABERTA</strong></span>"            , sCor) : x.StatusSistema.DsStSistema
                                                    }).ToList();
                    var _values = new { data = values };
                    result = Json(_values, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    List<String[]> values = new List<string[]>();
                    var _values = new { data = values };
                    result = Json(_values, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return result;
        }

        public JsonResult GravaDadosEmBanco(int idLinha, int idPatio, int idTrem, int idEntrega = 0)
        {
            List<String[]> values = new List<string[]>();
            JsonResult result = new JsonResult();
            try
            {
                EntregaTrem oEntregaTrem = new EntregaTrem();
                oEntregaTrem.Notas = new List<Nota>();
                List<Nota> lstNotaOcorrencia = new List<Nota>();
                List<Nota> lstNotaInspecao = new List<Nota>();
                string NomeOrigemDataTemp = "";

                #region --|Capturando todas as notas de Ocorrencias|--
                TipoNota tipoNota = (new TipoNotaServices()).GetByCodigoSap("MC");
                int idTipo = int.Parse(tipoNota.IdTpNota.ToString());
                string NomeGrid = tipoNota.CdSap.ToUpper().Equals("MC") ? "Ocorrencia" : tipoNota.CdSap.ToUpper().Equals("MI") ? "Inspecao" : "Programacao";
                NomeOrigemDataTemp = string.Format("TempData_Destino_{0}_NotaTipo_{1}", NomeGrid, tipoNota.CdSap.ToUpper());
                if (TempData[NomeOrigemDataTemp] != null)
                {
                    lstNotaOcorrencia.AddRange(TempData[NomeOrigemDataTemp] as List<Nota>);
                    TempData.Keep(NomeOrigemDataTemp);
                    foreach (Nota item in lstNotaOcorrencia.ToList())
                    {
                        oEntregaTrem.Notas.Add(item);
                    }
                }
                #endregion

                #region --|Capturando todas as notas de Inspecao|--
                tipoNota = (new TipoNotaServices()).GetByCodigoSap("MI");
                idTipo = int.Parse(tipoNota.IdTpNota.ToString());
                NomeGrid = tipoNota.CdSap.ToUpper().Equals("MC") ? "Ocorrencia" : tipoNota.CdSap.ToUpper().Equals("MI") ? "Inspecao" : "Programacao";
                NomeOrigemDataTemp = string.Format("TempData_Destino_{0}_NotaTipo_{1}", NomeGrid, tipoNota.CdSap.ToUpper());
                if (TempData[NomeOrigemDataTemp] != null)
                {
                    lstNotaInspecao.AddRange(TempData[NomeOrigemDataTemp] as List<Nota>);
                    TempData.Keep(NomeOrigemDataTemp);
                    foreach (Nota item in lstNotaInspecao.ToList())
                    {
                        oEntregaTrem.Notas.Add(item);
                    }
                }
                #endregion
                #region --|Cabecalho da Entrega|--
                
                oEntregaTrem.IdEntrega                  = int.Parse(idEntrega.ToString());
                oEntregaTrem.DtEntrega                  = DateTime.Now;
                oEntregaTrem.HrEntrega                  = DateTime.Now;
                oEntregaTrem.IdPatioFk                  = idPatio;
                oEntregaTrem.IdTremFk                   = idTrem;
                oEntregaTrem.IdLinEntrega               = idLinha;
                oEntregaTrem.IdCtTrab                   = (new LinhaServices()).GetById(idLinha).IdCentroTrabalhoFk;
                oEntregaTrem.IdRespEntrega              = 1;
                oEntregaTrem.IdMotivoEntregaInspecaoFk  = lstNotaInspecao.Count.Equals(0) ? 0 : int.Parse(System.Configuration.ConfigurationManager.AppSettings["MotivoEntrega_Inspecao"].ToString());
                oEntregaTrem.IdMotivoEntregaOcorFk      = lstNotaOcorrencia.Count.Equals(0) ? 0 : int.Parse(System.Configuration.ConfigurationManager.AppSettings["MotivoEntrega_Ocorrencia"].ToString());
                oEntregaTrem.IdMotivoEntregaProgFk      = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MotivoEntrega_Programacao"].ToString());

                #endregion

                EntregaTrem retorno = new EntregaTrem();
                if (int.Parse(idEntrega.ToString()).Equals(0))
                {
                    retorno = (new PM.WebServices.Service.EntregaTremServices()).Add(oEntregaTrem);
                }
                else
                {
                    retorno = (new PM.WebServices.Service.EntregaTremServices()).Update(oEntregaTrem);
                }
                
                //PM.Web.Library.LogApplication.RegistraLogOperacoes(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), 12, oEntregaTrem);

                String[] texto = { retorno.BaseModel.MensagemUsuario };
                values.Add(texto);
                
            }
            catch(Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
                String[] texto = { ex.Message.ToString() };
                values.Add(texto);
            }
            finally
            {
                var _values = new { data = values };
                result = Json(_values, JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        public JsonResult LiberarEntregaTrem(int idEntrega, int idMotivoEntrega)
        {
            JsonResult result = new JsonResult();
            try
            {
                EntregaTrem oEntregaTrem = new EntregaTrem();                
                oEntregaTrem = (new EntregaTremServices()) .GetNavigationPropertiesByID(idEntrega);
                oEntregaTrem.DtLiberacao = DateTime.Now;
                oEntregaTrem.IdRespLiberacao = 1;
                oEntregaTrem.Trem.StTrem = idMotivoEntrega;
                int IdStatusEntregaTrem = 0;
                switch (oEntregaTrem.Trem.StTrem)
                {
                    case 1:
                        {
                            IdStatusEntregaTrem = 3; // LIBERADO
                            break;
                        }
                    case 2:
                        {
                            IdStatusEntregaTrem = 4; // LIBERADO COM PENDÊNCIA
                            break;
                        }
                }
                oEntregaTrem.StEntregaTrem = IdStatusEntregaTrem;
                //oEntregaTrem.Trem.StatusTrem = (new StatusTremServices()).GetById(1);
                (new EntregaTremServices()).LiberarEntregaTrem(oEntregaTrem);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return result;
        }

        public JsonResult CancelaEntregaTrem(int idEntrega, string MotivoCancelamento)
        {
            JsonResult result = new JsonResult();
            try
            {
                EntregaTrem oEntregaTrem = new EntregaTrem();
                oEntregaTrem = (new EntregaTremServices()).GetNavigationPropertiesByID(idEntrega);
                oEntregaTrem.DtCancelamento= DateTime.Now;
                oEntregaTrem.IdRespCancelamento = 1;
                (new EntregaTremServices()).CancelaEntregaTrem(oEntregaTrem);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return result;
        }

        public JsonResult MudarLocalEntregaTrem(int idEntrega, int idLinha, int idPatio)
        {
            JsonResult result = new JsonResult();
            try
            {
                EntregaTrem oEntregaTrem    = new EntregaTrem();
                oEntregaTrem                = (new EntregaTremServices()).GetNavigationPropertiesByID(idEntrega);
                oEntregaTrem.IdPatioFk      = idPatio;
                oEntregaTrem.IdLinEntrega   = idLinha;
                (new EntregaTremServices()).MudarLocalEntregaTrem(oEntregaTrem);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return result;
        }
    }
}