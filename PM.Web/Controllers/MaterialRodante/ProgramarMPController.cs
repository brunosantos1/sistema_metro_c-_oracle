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
    public class ProgramarMPController : BaseController
    {
        
        public JsonResult GravaDadosEmBanco(int IdProgramacao = 0, int idTipoProgramacao=0, int idLinha = 0, int idPatio = 0, int idTrens = 0, int idCentroTrabalho = 0, int idTipo_manutencao = 0, string data_entrega = "", string hora_entrega = "", string data_liberacao = "", string hora_liberacao = "", string observacao = "")
        {
            List<String[]> values = new List<string[]>();
            List<Nota> lstNotasFull = new List<Nota>();
            string NomeOrigemDataTemp = "";
            string NomeDestinoDataTemp = "";
            JsonResult result = new JsonResult();
            try
            {
                #region --|Capturando as Notas Armazenadas em Memoria|--                
                if(idTipoProgramacao == 1) // MP
                {
                    NomeOrigemDataTemp = string.Format("TempData_Origem_NotaTipo_{0}", "MP".ToUpper()).ToUpper();
                    NomeDestinoDataTemp = string.Format("TempData_Destino_NotaTipo_{0}", "MP".ToUpper()).ToUpper();
                    lstNotasFull = TempData[NomeDestinoDataTemp] as List<Nota>;
                    TempData.Keep(NomeDestinoDataTemp);
                }
                else if (idTipoProgramacao == 2) // MDMS
                {
                    NomeOrigemDataTemp  = string.Format("TempData_Origem_NotaTipo_{0}", "MDMS".ToUpper()).ToUpper();
                    NomeDestinoDataTemp = string.Format("TempData_Destino_NotaTipo_{0}", "MDMS".ToUpper()).ToUpper();
                    lstNotasFull        = TempData[NomeDestinoDataTemp] as List<Nota>;
                    TempData.Keep(NomeDestinoDataTemp);
                }
                #endregion

                Programacao oProgramacao        = new Programacao();
                oProgramacao.IdProgramacao      = IdProgramacao;
                oProgramacao.CdTpProgramacao    = "1";
                oProgramacao.IdTremFk           = idTrens;
                oProgramacao.IdTipoManutencaoFk = 1;
                oProgramacao.IdEntregaTremFk    = 0;
                oProgramacao.DtEntrega          = DateTime.Parse(string.Format("{0:dd/MM/yyyy} {1:hh:mm:00}", data_entrega, hora_entrega));
                oProgramacao.HrEntrega          = DateTime.Parse(string.Format("{0:dd/MM/yyyy} {1:hh:mm:00}", data_entrega, hora_entrega));                
                if (!data_liberacao.Trim().Length.Equals(0) && !hora_liberacao.Trim().Length.Equals(0))
                {
                    oProgramacao.DtLiberacao = DateTime.Parse(string.Format("{0:dd/MM/yyyy} {1:hh:mm:00}", data_liberacao, hora_liberacao));
                    oProgramacao.HrLiberacao = DateTime.Parse(string.Format("{0:dd/MM/yyyy} {1:hh:mm:00}", data_liberacao, hora_liberacao));
                }
                oProgramacao.IdRgProgramacao    = 1;
                oProgramacao.DsObservacao       = observacao.ToUpper();
                oProgramacao.IdCtTrab           = idCentroTrabalho;
                oProgramacao.Notas              = lstNotasFull.OrderBy(c => c.IdNota).ToList();
                Programacao retorno             = new Programacao();
                if (int.Parse(IdProgramacao.ToString()).Equals(0))
                {
                    retorno = (new PM.WebServices.Service.ProgramacaoServices()).Add(oProgramacao);
                }
                else
                {
                    retorno = (new PM.WebServices.Service.ProgramacaoServices()).Update(oProgramacao);
                }
                //PM.Web.Library.LogApplication.RegistraLogOperacoes(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), 12, oEntregaTrem);

                String[] texto = { retorno.BaseModel.MensagemUsuario };
                values.Add(texto);
                TempData[NomeDestinoDataTemp] = null;
                TempData[NomeOrigemDataTemp] = null;                
            }
            catch (Exception ex)
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

        public JsonResult BuscarNotas(int idProgramacao, int idTipoProgramacao, int idLinha, int idPatio, int idTrens, string ftDataDe, string ftDataAte, int ftCentroDeTrabalho =0, string ftTipoManutencao = "", int ftLocalInstalacao = 0)
        {
            JsonResult result = new JsonResult();
            int idTipo = 21;
            try
            {
                int idFrota = 0;
                int idTrem = idTrens;
                int idCarro = 0;
                int idSistema = 0;
                int idSintoma = 0;
                string cdSap = "";
                string dataInicial = ftDataDe;
                string dataFinal = ftDataAte;
                int idPrioridade = 0;
                int idNotificador = 0;
                int rgNotificador = 0;
                int idStatus = 3;
                int idNotStatus = 21;
                string cd_sap = "";
                List <Nota> lst = new List<Nota>();
                if (idTipoProgramacao == 1)
                {
                    cd_sap = "MP";
                    lst = (new WebServices.Service.NotaServices()).PesquisarNotaProgramacao(idFrota, idTrens, idCarro, idSistema, idSintoma, cdSap, ftDataDe, ftDataAte, idPrioridade, idNotificador, rgNotificador, idStatus, idNotStatus, cd_sap).ToList();
                }
                else
                {
                    cd_sap = "MD";
                    //lst = (new WebServices.Service.NotaServices()).PesquisarMC(0, idTrens, 0, 0, 0, "", ftDataDe, ftDataAte, null, null, null, 0, cd_sap).ToList();
                    lst = (new WebServices.Service.NotaServices()).PesquisarNotaProgramacao(idFrota, idTrens, idCarro, idSistema, idSintoma, cdSap, ftDataDe, ftDataAte, idPrioridade, idNotificador, rgNotificador, idStatus, idNotStatus, cd_sap).ToList();
                    cd_sap = "MS";
                    //lst.AddRange( (new WebServices.Service.NotaServices()).PesquisarMC(0, idTrens, 0, 0, 0, "", ftDataDe, ftDataAte, null, null, null, 0, cd_sap).ToList());
                    lst.AddRange((new WebServices.Service.NotaServices()).PesquisarNotaProgramacao(idFrota, idTrens, idCarro, idSistema, idSintoma, cdSap, ftDataDe, ftDataAte, idPrioridade, idNotificador, rgNotificador, idStatus, idNotStatus, cd_sap).ToList());
                    cd_sap = "MDMS";
                }
                if (lst.Count > 0)                
                {
                    string NomeGrid = idTipo.Equals(21) ? "Ocorrencia" : idTipo.Equals(23) ? "Inspecao" : "Programacao";
                    //string NomeDataTemp = string.Format("TempData_Origem_{0}_NotaTipo_{1}", NomeGrid, idTipo.ToString());
                    //string NomeDestinoDataTemp = string.Format("TempData_Destino_{0}_NotaTipo_{1}", NomeGrid, idTipo.ToString());
                    //TempData[NomeDestinoDataTemp] = null;
                    //TempData[NomeDataTemp] = lst;
                    string NomeOrigemDataTemp = string.Format("TempData_Origem_NotaTipo_{0}"  , cd_sap.ToUpper()).ToUpper();
                    string NomeDestinoDataTemp = string.Format("TempData_Destino_NotaTipo_{0}", cd_sap.ToUpper()).ToUpper();
                    TempData[NomeDestinoDataTemp] = null;
                    TempData[NomeOrigemDataTemp]  = lst;

                    if (idTipoProgramacao == 1)
                    {
                        string sCor = "#000";
                        List<String[]> values = lst.Select(x => new String[] {
                                                                              string.Format("<input id=\"chk_{3}_{0:000000}\" type=\"checkbox\" onclick=\"fnAtualizaDataTemp(this,{0}, '{1}');\"> <span>{0:000000}</span>", x.IdNota, x.TipoNota.CdSap.ToUpper(), NomeGrid, NomeGrid.ToLower())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Fase 02").ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.LocalInstalacao.CdSap.ToUpper())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.LocalInstalacao.DsLcInstalacao.ToUpper())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.DsDescricao.ToUpper())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "6 - Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "70.000")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "85.000")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "9 - Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "10 - Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0:dd/MM/yyyy HH:mm:ss}'><strong>{1}</strong></span>"  , sCor, DateTime.Now)
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "ABERTA")
                                                                        }).ToList();
                        var _values = new { data = values };
                        result = Json(_values, JsonRequestBehavior.AllowGet);
                        
                    }
                    else if(idTipoProgramacao == 2)
                    {
                        string sCor = "#000";
                        List<String[]> values = lst.Select(x => new String[] {
                                                                              string.Format("<input id=\"chk_{3}_{0:000000}\" type=\"checkbox\" onclick=\"fnAtualizaDataTemp(this,{0}, '{1}');\"> <span>{0:000000}</span>", x.IdNota, x.TipoNota.CdSap.ToUpper(), NomeGrid, NomeGrid.ToLower())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.TipoNota.CdSap).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Fase 02").ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.LocalInstalacao.CdSap).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.LocalInstalacao.DsLcInstalacao).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.DsDescricao).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Tipo Serviço (BRUNO)").ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.CentroTrabalho.DsCtTrabalho).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.DtHoraNota).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.StatusUsuarios.LastOrDefault().DsStUsuario).ToUpper()
                                                                        }).ToList();
                        var _values = new { data = values };
                        result = Json(_values, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    List<String[]> values = new List<string[]>();
                    var _values = new { data = values };
                    result = Json(_values, JsonRequestBehavior.AllowGet);
                }
            }
            catch (OutOfMemoryException ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return result;
        }

        public JsonResult AtualizaDadosGravacao(int idTipoProgramacao,  string cd_sap, int idNota, int idProgramacao = 0)
        {
            JsonResult result = new JsonResult();
            try
            {
                TipoNota tipoNota = (new TipoNotaServices()).GetByCodigoSap(cd_sap);
                     int idTipo   = int.Parse(tipoNota.IdTpNota.ToString());

                
                string NomeOrigemDataTemp   = string.Format("TempData_Origem_NotaTipo_{0}" , tipoNota.CdSap.ToUpper()).ToUpper();
                string NomeDestinoDataTemp  = string.Format("TempData_Destino_NotaTipo_{0}",tipoNota.CdSap.ToUpper()).ToUpper();
                if (idTipoProgramacao == 2)
                {
                    NomeOrigemDataTemp = string.Format("TempData_Origem_NotaTipo_{0}", "MDMS".ToUpper()).ToUpper();
                    NomeDestinoDataTemp = string.Format("TempData_Destino_NotaTipo_{0}", "MDMS".ToUpper()).ToUpper();
                }
                List<Nota> lstOrigem        = new List<Nota>();
                List<Nota> lstDestino       = new List<Nota>();

                lstOrigem = TempData[NomeOrigemDataTemp] as List<Nota>;
                TempData.Keep(NomeOrigemDataTemp);

                if (idProgramacao.Equals(0))
                {
                    if (TempData[NomeDestinoDataTemp] == null)
                    {
                        lstDestino = lstOrigem.Where(c => c.IdNota.Equals(idNota) && c.IdTpNotaFk.Equals(idTipo)).ToList();
                        TempData[NomeDestinoDataTemp] = lstDestino;
                        TempData.Keep(NomeDestinoDataTemp);
                    }
                    else
                    {
                        if (!lstOrigem.Where(c => c.IdNota.Equals(idNota) && c.IdTpNotaFk.Equals(idTipo)).ToList().Count.Equals(0))
                        {
                            lstDestino = TempData[NomeDestinoDataTemp] as List<Nota>;
                            TempData.Keep(NomeDestinoDataTemp);

                            if (lstDestino.Where(c => c.IdNota.Equals(idNota) && c.IdTpNotaFk.Equals(idTipo)).ToList().Count.Equals(0))
                            {
                                // Adciona
                                lstDestino.Add((lstOrigem.Where(c => c.IdNota.Equals(idNota) && c.IdTpNotaFk.Equals(idTipo)).ToList())[0]);
                            }
                            else
                            {
                                // Remove
                                lstDestino.Remove((lstOrigem.Where(c => c.IdNota.Equals(idNota) && c.IdTpNotaFk.Equals(idTipo)).ToList())[0]);
                                if (!lstDestino.Where(c => c.IdNota.Equals(idNota)).ToList().Count.Equals(0))
                                {
                                    lstDestino = lstDestino.Where(c => c.IdNota != idNota && c.IdTpNotaFk.Equals(idTipo)).ToList();
                                }
                            }
                            TempData[NomeDestinoDataTemp] = lstDestino;
                            TempData.Keep(NomeDestinoDataTemp);
                        }
                    }
                }
                else
                {
                    //lstDestino = (new NotaServices()).GetNotasVinculadasEntregaTrem(idProgramacao, idTipo).ToList();
                    //TempData[NomeDestinoDataTemp] = lstDestino;
                    //TempData.Keep(NomeDestinoDataTemp);
                }
                if (lstDestino.Count > 0)
                {                    
                    if (idTipoProgramacao == 1)
                    {
                        string sCor = "#000";
                        List<String[]> values = lstDestino.Select(x => new String[] {
                                                                              string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.IdNota).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Fase 02").ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.LocalInstalacao.CdSap.ToUpper())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.LocalInstalacao.DsLcInstalacao.ToUpper())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.DsDescricao.ToUpper())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "6 - Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "70.000")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "85.000")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "9 - Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "10 - Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0:dd/MM/yyyy HH:mm:ss}'><strong>{1}</strong></span>"  , sCor, DateTime.Now)
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "ABERTA")
                                                                        }).ToList();
                        var _values = new { data = values };
                        result = Json(_values, JsonRequestBehavior.AllowGet);
                    }
                    else if (idTipoProgramacao == 2)
                    {
                        string sCor = "#000";
                        List<String[]> values = lstDestino.Select(x => new String[] {
                                                                              string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.IdNota).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.TipoNota.CdSap).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Fase 02").ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.LocalInstalacao.CdSap).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.LocalInstalacao.DsLcInstalacao).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.DsDescricao).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Tipo Serviço (BRUNO)").ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.CentroTrabalho.DsCtTrabalho).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.DtHoraNota).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.StatusUsuarios.LastOrDefault().DsStUsuario).ToUpper()
                                                                        }).ToList();
                        var _values = new { data = values };
                        result = Json(_values, JsonRequestBehavior.AllowGet);
                    }
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

        public JsonResult BuscarProgramacao(int idProgramacao = 0, int idTipoProgramacao = 0, int idLinha = 0, int idPatio = 0, int idTrens = 0, int idMotivo = 0, string data_entrega_inicio = "", string data_entrega_final = "")
        {
            JsonResult result = new JsonResult();
            int idTipo = 21;
            try
            {
                int idFrota = 0;
                int idTrem = idTrens;
                int idCarro = 0;
                int idSistema = 0;
                int idSintoma = 0;
                string cdSap = "";
                string dataInicial = data_entrega_inicio;
                string dataFinal = data_entrega_final;
                int idPrioridade = 0;
                int idNotificador = 0;
                int rgNotificador = 0;
                int idStatus = 3;
                int idNotStatus = 21;
                string cd_sap = "";
                List<Nota> lst = new List<Nota>();
                if (idTipoProgramacao == 1)
                {
                    cd_sap = "MP";
                    lst = (new WebServices.Service.NotaServices()).PesquisarNotaProgramacao(idFrota, idTrens, idCarro, idSistema, idSintoma, cdSap, dataInicial, dataFinal, idPrioridade, idNotificador, rgNotificador, idStatus, idNotStatus, cd_sap).ToList();
                }
                else
                {
                    cd_sap = "MD";
                    //lst = (new WebServices.Service.NotaServices()).PesquisarMC(0, idTrens, 0, 0, 0, "", ftDataDe, ftDataAte, null, null, null, 0, cd_sap).ToList();
                    lst = (new WebServices.Service.NotaServices()).PesquisarNotaProgramacao(idFrota, idTrens, idCarro, idSistema, idSintoma, cdSap, dataInicial, dataFinal, idPrioridade, idNotificador, rgNotificador, idStatus, idNotStatus, cd_sap).ToList();
                    cd_sap = "MS";
                    //lst.AddRange( (new WebServices.Service.NotaServices()).PesquisarMC(0, idTrens, 0, 0, 0, "", ftDataDe, ftDataAte, null, null, null, 0, cd_sap).ToList());
                    lst.AddRange((new WebServices.Service.NotaServices()).PesquisarNotaProgramacao(idFrota, idTrens, idCarro, idSistema, idSintoma, cdSap, dataInicial, dataFinal, idPrioridade, idNotificador, rgNotificador, idStatus, idNotStatus, cd_sap).ToList());
                    cd_sap = "MDMS";
                }
                if (lst.Count > 0)
                {
                    string NomeGrid = idTipo.Equals(21) ? "Ocorrencia" : idTipo.Equals(23) ? "Inspecao" : "Programacao";
                    //string NomeDataTemp = string.Format("TempData_Origem_{0}_NotaTipo_{1}", NomeGrid, idTipo.ToString());
                    //string NomeDestinoDataTemp = string.Format("TempData_Destino_{0}_NotaTipo_{1}", NomeGrid, idTipo.ToString());
                    //TempData[NomeDestinoDataTemp] = null;
                    //TempData[NomeDataTemp] = lst;
                    string NomeOrigemDataTemp = string.Format("TempData_Origem_NotaTipo_{0}", cd_sap.ToUpper()).ToUpper();
                    string NomeDestinoDataTemp = string.Format("TempData_Destino_NotaTipo_{0}", cd_sap.ToUpper()).ToUpper();
                    TempData[NomeDestinoDataTemp] = null;
                    TempData[NomeOrigemDataTemp] = lst;

                    if (idTipoProgramacao == 1)
                    {
                        string sCor = "#000";
                        List<String[]> values = lst.Select(x => new String[] {
                                                                              string.Format("<input id=\"chk_{3}_{0:000000}\" type=\"checkbox\" onclick=\"fnAtualizaDataTemp(this,{0}, '{1}');\"> <span>{0:000000}</span>", x.IdNota, x.TipoNota.CdSap.ToUpper(), NomeGrid, NomeGrid.ToLower())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Fase 02").ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.LocalInstalacao.CdSap.ToUpper())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.LocalInstalacao.DsLcInstalacao.ToUpper())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.DsDescricao.ToUpper())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "6 - Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "70.000")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "85.000")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "9 - Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "10 - Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0:dd/MM/yyyy HH:mm:ss}'><strong>{1}</strong></span>"  , sCor, DateTime.Now)
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "ABERTA")
                                                                        }).ToList();
                        var _values = new { data = values };
                        result = Json(_values, JsonRequestBehavior.AllowGet);

                    }
                    else if (idTipoProgramacao == 2)
                    {
                        string sCor = "#000";
                        List<String[]> values = lst.Select(x => new String[] {
                                                                              string.Format("<input id=\"chk_{3}_{0:000000}\" type=\"checkbox\" onclick=\"fnAtualizaDataTemp(this,{0}, '{1}');\"> <span>{0:000000}</span>", x.IdNota, x.TipoNota.CdSap.ToUpper(), NomeGrid, NomeGrid.ToLower())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.TipoNota.CdSap).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Fase 02").ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.LocalInstalacao.CdSap).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.LocalInstalacao.DsLcInstalacao).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.DsDescricao).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Tipo Serviço (BRUNO)").ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.CentroTrabalho.DsCtTrabalho).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.DtHoraNota).ToUpper()
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, x.StatusUsuarios.LastOrDefault().DsStUsuario).ToUpper()
                                                                        }).ToList();
                        var _values = new { data = values };
                        result = Json(_values, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    List<String[]> values = new List<string[]>();
                    var _values = new { data = values };
                    result = Json(_values, JsonRequestBehavior.AllowGet);
                }
            }
            catch (OutOfMemoryException ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return result;
        }
    }
}