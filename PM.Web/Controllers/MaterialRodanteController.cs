using PM.Web.ViewModel;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.WebServices.Service;
using PM.WebServices.Models;

namespace PM.Web.Controllers
{
    public class MaterialRodanteController : BaseController
    {
        // GET: MaterialRodanteController
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult NotaMc(int? id)
        {
            if (id == null)
            {
                ViewBag.Action = "new";
            }
            else
            {
                ViewBag.Action = "edit";
            }
            return View();
        }
        [HttpGet]
        public ActionResult NotaMd(int? id)
        {
            if(id==null)
            {
                ViewBag.Action = "new";
            }
            else
            {
                ViewBag.Action = "edit";
            }
            return View();
        }
        [HttpGet]
        public ActionResult NotaMi(int? id)
        {
            if(id==null)
            {
                ViewBag.Action = "new";
            }
            else
            {
                ViewBag.Action = "edit";
            }
            return View();
        }
        [HttpGet]
        public ActionResult NotaMs(int? id)
        {
            if (id == null)
            {
                ViewBag.Action = "new";
            }
            else
            {
                ViewBag.Action = "edit";
            }
            return View();
        }

        public ActionResult ConsultarMc()
        {
            return View();
        }

        public ActionResult ConsultarMd()
        {
            return View();
        }

        public ActionResult ConsultarMi()
        {
            return View();
        }

        public ActionResult ConsultarMs()
        {
            return View();
        }        

        public ActionResult PesquisarMc()
        {
            return View();
        }
        public ActionResult PesquisarMi()
        {
            return View();
        }
        // efmr2
        public ActionResult PesquisarNotas()
        {
            return View();
        }
        public ActionResult PesquisarOrdens()
        {
            return View();
        }
        //efmr3
        public ActionResult DocumentoMedicao()
        {
            return View();
        }
        public ActionResult PesquisarEntregaTrem(int idLinha = 0, int idPatio = 0, int idTrem = 0)
        {
            PesquisarEntregaTrensViewModel telaVM = new PesquisarEntregaTrensViewModel();
            try
            {
                telaVM.linha = idLinha;
                telaVM.patio = idPatio;
                telaVM.trens = idTrem;
                telaVM.motivo = 0;
                // Liberacao
                telaVM.trem_status_liberacao = 0;
                telaVM.id_resp_liberacao    = 0;
                // Cancelamento
                telaVM.motivo_cancelamento  = "";
                telaVM.id_resp_cancelamento = 0;
                // Mudanca Patio
                telaVM.linha_novo = 0;
                telaVM.patio_novo = 0;

                telaVM.SelecionarLinha                  = idLinha.Equals(0) ? base.CarregaDropDownList(ServicoType.Linha, 0, false) : base.CarregaDropDownList(ServicoType.Linha, idLinha, false);
                telaVM.SelecionarPatioLinha             = idPatio.Equals(0) ? base.CarregaDropDownList(ServicoType.PatioLinha, 0, true) : base.CarregaDropDownList(ServicoType.PatioLinha, idPatio);
                telaVM.SelecionarTrens                  = idTrem.Equals(0) ? base.CarregaDropDownList(ServicoType.Trem, 0, true) : base.CarregaDropDownList(ServicoType.Trem, idTrem);
                telaVM.SelecionarMotivo                 = base.CarregaDropDownList(ServicoType.MotivoEntrega, idTrem);
                telaVM.SelecionarStatusLiberacaoTrens   = base.CarregaDropDownList(ServicoType.StatusLiberacaoTrem, 0, false);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return View(telaVM);
        }
        public ActionResult PesquisarManobra()
        {
            return View();
        }
        public ActionResult PesquisarTrens()
        {
            PesquisarTrensViewModel telaVM  = new PesquisarTrensViewModel();
            try
            {
                telaVM.SelecionarLinha      = base.CarregaDropDownList(ServicoType.Linha);
                telaVM.SelecionarStatus     = base.CarregaDropDownList(ServicoType.Status);
                telaVM.SelecionarPatioLinha = base.CarregaDropDownList(ServicoType.PatioLinha, 0, true);
            }
            catch(Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return View(telaVM);
        }
        [HttpGet]
        public ActionResult SolicitarEntregaTrem(int idLinha = 0, int idPatio = 0, int idTrem = 0, int idEntrega = 0)
        {
            EntregaTrensViewModel telaVM = new EntregaTrensViewModel();
            try
            {
                if(!int.Parse(idEntrega.ToString()).Equals(0))
                {
                    TipoNota tipoNota;
                    List<Nota> lstOrigem = new List<Nota>();
                    int idTipo = 0;
                  //string NomeGrid = "";
                    string NomeOrigemDataTemp = "";
                    string NomeDestinoDataTemp = "";
                    WebServices.Models.EntregaTrem entregaTrem = (new EntregaTremServices()).GetNavigationPropertiesByID(int.Parse(idEntrega.ToString()));
                    idLinha             = entregaTrem.IdLinEntrega.Value;
                    idPatio             = entregaTrem.IdPatioFk.Value;
                    idTrem              = entregaTrem.IdTremFk.Value;

                    tipoNota            = (new TipoNotaServices()).GetByCodigoSap("MC");
                    idTipo              = int.Parse(tipoNota.IdTpNota.ToString());
                  //NomeGrid            = tipoNota.CdSap.ToUpper().Equals("MC") ? "Ocorrencia" : tipoNota.CdSap.ToUpper().Equals("MI") ? "Inspecao" : "Programacao";
                    lstOrigem           = (new WebServices.Service.NotaServices()).GetNotaVinculadaTrem(idTrem, tipoNota.CdSap).ToList();
                    telaVM.NotasMC      = (new NotaServices()).GetNotasVinculadasEntregaTrem(entregaTrem.IdEntrega.Value, idTipo).ToList();
                    NomeOrigemDataTemp  = "TEMPDATA_ORIGEM_OCORRENCIA_NOTATIPO_MC".ToUpper();
                    NomeDestinoDataTemp = "TEMPDATA_DESTINO_OCORRENCIA_NOTATIPO_MC".ToUpper();                        
                    TempData[NomeOrigemDataTemp] = lstOrigem;
                    TempData.Keep(NomeOrigemDataTemp);

                    TempData[NomeDestinoDataTemp] = telaVM.NotasMC.ToList();
                    TempData.Keep(NomeDestinoDataTemp);

                    tipoNota            = (new TipoNotaServices()).GetByCodigoSap("MI");
                    idTipo              = int.Parse(tipoNota.IdTpNota.ToString());
                  //NomeGrid            = tipoNota.CdSap.ToUpper().Equals("MC") ? "Ocorrencia" : tipoNota.CdSap.ToUpper().Equals("MI") ? "Inspecao" : "Programacao";
                    lstOrigem           = (new WebServices.Service.NotaServices()).GetNotaVinculadaTrem(idTrem, tipoNota.CdSap).ToList();
                    telaVM.NotasMI      = (new NotaServices()).GetNotasVinculadasEntregaTrem(entregaTrem.IdEntrega.Value, idTipo).ToList();
                    
                    NomeOrigemDataTemp  = "TEMPDATA_ORIGEM_INSPECAO_NOTATIPO_MI".ToUpper();
                    NomeDestinoDataTemp = "TEMPDATA_DESTINO_INSPECAO_NOTATIPO_MI".ToUpper();
                    TempData[NomeOrigemDataTemp] = lstOrigem;
                    TempData.Keep(NomeOrigemDataTemp);

                    TempData[NomeDestinoDataTemp] = telaVM.NotasMI.ToList();
                    TempData.Keep(NomeDestinoDataTemp);
                }                
                telaVM.linha = idLinha;
                telaVM.patio = idPatio;
                telaVM.trens = idTrem;
                telaVM.SelecionarLinha      = idLinha.Equals(0) ? base.CarregaDropDownList(ServicoType.Linha     , 0, false) : base.CarregaDropDownList(ServicoType.Linha     , idLinha, false);
                telaVM.SelecionarPatioLinha = idPatio.Equals(0) ? base.CarregaDropDownList(ServicoType.PatioLinha, 0, true)  : base.CarregaDropDownList(ServicoType.PatioLinha, idPatio, false);
                telaVM.SelecionarTrens      = idTrem.Equals(0)  ? base.CarregaDropDownList(ServicoType.Trem      , 0, true)  : base.CarregaDropDownList(ServicoType.Trem      , idTrem , false);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return View(telaVM);
        }

        public ActionResult SolicitarManobra()
        {
            return View();
        }

        // efmr 4
        public ActionResult ConsultarProgramacao()
        {
            return View();
        }

        public ActionResult ConsultarProgramacaoEspecifico()
        {
            return View();
        }

        public ActionResult ConsultarProgramacaoMd()
        {
            return View();
        }

        public ActionResult EditarProgramacao()
        {
            return View();
        }

        public ActionResult EditarProgramacaoMd()
        {
            return View();
        }

        public ActionResult PesquisarCarteiraNotaMdMs()
        {
            return View();
        }

        public ActionResult PesquisarCarteiraNotaMp()
        {
            return View();
        }

        public ActionResult PesquisarProgramacaoNotasMdMs()
        {
            PesquisarProgramacaoNotasMdMsViewModel telaVM = new PesquisarProgramacaoNotasMdMsViewModel();
            try
            {
                telaVM.idPatio                  = 0;
                telaVM.idTrem                   = 0;
                telaVM.idLinha                  = 0;
                telaVM.idTipo_manutencao        = 0;
                telaVM.idCentroTrabalho         = 0;
                telaVM.idStatus                 = 0;
                telaVM.data_inicial             = "";
                telaVM.data_final               = "";
                telaVM.SelecionarLinha          = base.CarregaDropDownList(ServicoType.Linha            , 0, false);                
                telaVM.SelecionarPatio          = base.CarregaDropDownList(ServicoType.PatioLinha       , 0, false);
                telaVM.SelecionarTrem           = base.CarregaDropDownList(ServicoType.Trem             , 0, false);
                telaVM.SelecionarCentroTrabalho = base.CarregaDropDownList(ServicoType.CentroTrabalho   , 0, false);
                telaVM.SelecionarTipoManutencao = base.CarregaDropDownList(ServicoType.TipoManutencao   , 0, false);
                telaVM.SelecionarStatus         = base.CarregaDropDownList(ServicoType.Status           , 0, false);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return View(telaVM);
        }

        public ActionResult PesquisarProgramacaoNotasMp()
        {
            PesquisarProgramacaoNotasMPViewModel telaVM = new PesquisarProgramacaoNotasMPViewModel();
            try
            {
                telaVM.idPatio                  = 0;
                telaVM.idTrem                   = 0;
                telaVM.idLinha                  = 0;
                telaVM.idTipo_manutencao        = 0;
                telaVM.idCentroTrabalho         = 0;
                telaVM.data_inicial             = "";
                telaVM.data_final               = "";
                telaVM.SelecionarTrem           = base.CarregaDropDownList(ServicoType.Trem             , 0, false);
                telaVM.SelecionarPatio          = base.CarregaDropDownList(ServicoType.PatioLinha       , 0, false);
                telaVM.SelecionarLinha          = base.CarregaDropDownList(ServicoType.Linha            , 0, false);
                telaVM.SelecionarCentroTrabalho = base.CarregaDropDownList(ServicoType.CentroTrabalho   , 0, false);
                telaVM.SelecionarTipoManutencao = base.CarregaDropDownList(ServicoType.TipoManutencao   , 0, false);
                telaVM.SelecionarStatus         = base.CarregaDropDownList(ServicoType.Status           , 0, false);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return View(telaVM);
        }

        public ActionResult PesquisarProgramacaoTrens()
        {
            PesquisarProgramacaoTrensViewModel telaVM = new PesquisarProgramacaoTrensViewModel();
            try
            {
                telaVM.idTipoProgramacao    = 0;
                telaVM.idLinha              = 0;
                telaVM.idPatio              = 0;
                telaVM.idTrens              = 0;
                telaVM.idTipo_manutencao    = 0;
                telaVM.idCentroTrabalho     = 0;
                telaVM.idStatus             = 0;
                telaVM.data_entrega_inicio  = "";
                telaVM.data_entrega_final   = "";

                telaVM.SelecionarLinha          = base.CarregaDropDownList(ServicoType.Linha                , 0, false);
                telaVM.SelecionarPatio          = base.CarregaDropDownList(ServicoType.PatioLinha           , 0, false);
                telaVM.SelecionarTrens          = base.CarregaDropDownList(ServicoType.Trem                 , 0, false);
                telaVM.SelecionarTipoManutencao = base.CarregaDropDownList(ServicoType.TipoManutencao       , 0, false);
                telaVM.SelecionarCentroTrabalho = base.CarregaDropDownList(ServicoType.CentroTrabalho       , 0, false);
                telaVM.SelecionarStatus         = base.CarregaDropDownList(ServicoType.StatusProgramacaoTrem, 0, false);
                telaVM.SelecionarMotivo         = base.CarregaDropDownList(ServicoType.StatusProgramacaoTrem, 0, true);
                telaVM.SelecionarTipoProgramacao = base.CarregaDropDownList(ServicoType.TipoProgramacao      , 0, false);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return View(telaVM);
        }

        public ActionResult ProgramarMdMs()
        {
            return View();
        }

        public ActionResult ProgramarMp(int ProgramarTrem = 0)
        {
            ProgramarMPViewModel telaVM = new ProgramarMPViewModel();
            try
            {
                telaVM.idTipoProgramacao        = 0;
                telaVM.idLinha                  = 0;
                telaVM.idPatio                  = 0;
                telaVM.idTrens                  = 0;
                
                telaVM.idTipo_manutencao        = 0;
                telaVM.idCentroTrabalho         = 0;
                telaVM.data_entrega             = "";
                telaVM.hora_entrega             = "";
                telaVM.data_liberacao           = "";
                telaVM.hora_liberacao           = "";
                telaVM.observacao               = "";
                telaVM.ftCentroDeTrabalho       = 0;
                telaVM.ftLocalInstalacao        = 0;
                telaVM.ftTipoManutencao         = "";
                telaVM.ftDataDe                 = string.Format("{0:dd/MM/yyyy}", System.DateTime.Now.AddDays(int.Parse(System.Configuration.ConfigurationManager.AppSettings["CamposDatasIntervaloDeDiasAteDataAtual"].ToString())));
                telaVM.ftDataAte                = string.Format("{0:dd/MM/yyyy}",  DateTime.Now.AddDays(1));

                telaVM.SelecionarTipoProgramacao    = base.CarregaDropDownList(ServicoType.TipoProgramacao  , telaVM.idTipoProgramacao  , false);
                telaVM.SelecionarLinha              = base.CarregaDropDownList(ServicoType.Linha            , telaVM.idLinha            , false);
                telaVM.SelecionarPatioLinha         = base.CarregaDropDownList(ServicoType.PatioLinha       , telaVM.idPatio            , true);
                telaVM.SelecionarTrens              = base.CarregaDropDownList(ServicoType.Trem             , telaVM.idTrens            , true);
                telaVM.SelecionarCentroTrabalho     = base.CarregaDropDownList(ServicoType.CentroTrabalho   , telaVM.idCentroTrabalho   , false);
                telaVM.SelecionarTipoManutencao     = base.CarregaDropDownList(ServicoType.TipoManutencao   , telaVM.idTipo_manutencao  , false);
                telaVM.SelecionarftCentroDeTrabalho = base.CarregaDropDownList(ServicoType.CentroTrabalho   , telaVM.ftCentroDeTrabalho , false);
                telaVM.SelecionarftLocalInstalacao  = base.CarregaDropDownList(ServicoType.LocalInstalacao  , telaVM.ftLocalInstalacao  , true);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return View(telaVM);
        }

        //efmr5

        public ActionResult ApontarIntervencao()
        {
            return View();
        }

        public ActionResult ApontarNotasDocumentosVinculados()
        {
            return View();
        }

        public ActionResult ApontarOrdem()
        {
            return View();
        }

        public ActionResult ApontarTudo()
        {
            return View();
        }
        public void SelectFolder()
        {
            //Teste tst = new Teste();
            //List<Teste> ITeste = tst.GeraDados().ToList();
            //string saida = PM.Web.Library.Helper.ExportCSV(ITeste);
        }
    }


    

}