using PM.Web.ViewModel.Copese;
using PM.WebServices.Models;
using PM.WebServices.Service;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PM.Web.Controllers
{
    [RoutePrefix("CopesePericia")]
    public class PesquisarNotaCopeseEFController : BaseController
    {
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("PesquisarNotaCopeseEF")]
        public ActionResult PesquisarNotaCopeseEF()
        {
            try
            {
                PesquisaNotaCopeseEFMRViewModel telaVM = new PesquisaNotaCopeseEFMRViewModel();
                #region Carregar DropDownList
                telaVM.SelecionarLinha = base.CarregaDropDownList(ServicoType.Linha);
                telaVM.SelecionarZona = base.CarregaDropDownList(ServicoType.Zona);
                telaVM.SelecionarSistema = base.CarregaDropDownList(ServicoType.Sistema);
                telaVM.SelecionarComplemento = base.CarregaDropDownList(ServicoType.Complemento);
                telaVM.SelecionarSintoma = base.CarregaDropDownList(ServicoType.Sintoma);
                telaVM.SelecionarStatusPericia = base.CarregaDropDownList(ServicoType.StatusPericia);
                telaVM.SelecionarStatusCopese = base.CarregaDropDownList(ServicoType.StatusCopese);
                #endregion

                ViewBag.Action = "Pesquisar";
                return View("~/Views/CopesePericia/PesquisarNotaCopeseEF.cshtml", telaVM);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
                return View("~/Views/CopesePericia/PesquisarNotaCopeseEF.cshtml", new PesquisaNotaCopeseEFMRViewModel());
            }
        }


        [Route("FiltrarNotaCopeseEF")]
        public ActionResult FiltrarNotaCopeseEF(PesquisaNotaCopeseEFMRViewModel telaVM)
        {
            try
            {
                #region Carregar DropDownList
                telaVM.SelecionarLinha = base.CarregaDropDownList(ServicoType.Linha);
                telaVM.SelecionarZona = base.CarregaDropDownList(ServicoType.Zona);
                telaVM.SelecionarSistema = base.CarregaDropDownList(ServicoType.Sistema);
                telaVM.SelecionarComplemento = base.CarregaDropDownList(ServicoType.Complemento);
                telaVM.SelecionarSintoma = base.CarregaDropDownList(ServicoType.Sintoma);
                telaVM.SelecionarStatusPericia = base.CarregaDropDownList(ServicoType.StatusPericia);
                telaVM.SelecionarStatusCopese = base.CarregaDropDownList(ServicoType.StatusCopese);
                #endregion

                if (telaVM.id_local_inst <= 0 && telaVM.id_zona <= 0 && telaVM.id_sistema <= 0 && telaVM.id_complemento <= 0
                    && String.IsNullOrEmpty(telaVM.nr_copese) && String.IsNullOrEmpty(telaVM.nr_nota_ref)
                    && telaVM.dt_inicio == null && telaVM.dt_fim == null && telaVM.id_st_copese_fk <= 0)
                    ModelState.AddModelError("CampoRequerido", "Informe ao menos um filtro de pesquisa.");
                else if ((telaVM.dt_fim != null && telaVM.dt_fim != null) && Convert.ToDateTime(telaVM.dt_fim) < Convert.ToDateTime(telaVM.dt_inicio))
                    ModelState.AddModelError("CampoRequerido", "Data Final deve ser maior que a Data Inicial.");

                if (ModelState.IsValid)
                {
                    NotaServices notaService = new NotaServices();
                    LocalInstalacaoServices localInstalacaoServices = new LocalInstalacaoServices();

                    Nota nota = new Nota();
                    LocalInstalacao localInstalacao = new LocalInstalacao();

                    IList<Nota> listNota = new List<Nota>();
                    Nota nota_ref = new Nota();
                    IList<LocalInstalacao> listLocalInstalacao = new List<LocalInstalacao>();

                    localInstalacao.IdSistemaFk = telaVM.id_sistema;
                    localInstalacao.IdComplementoFk = telaVM.id_complemento;
                    localInstalacao.IdLinhaFk = telaVM.id_linha;
                    localInstalacao.IdZonaFk = telaVM.id_zona;

                    listLocalInstalacao = localInstalacaoServices.ConsultarLCParametros(localInstalacao);

                    int IdNotaRef = 0;
                    if (!string.IsNullOrEmpty(telaVM.nr_nota_ref))
                    {
                        var notaRef = notaService.GetNotasCodigoSap(telaVM.nr_nota_ref);
                        IdNotaRef = notaRef.IdNota.Value;
                    }

                    if (listLocalInstalacao.Count > 0)
                    {
                        foreach (var itemLC in listLocalInstalacao)
                        {
                            TipoNota tipoNota = new TipoNotaServices().GetByCodigoSap(TipoNotaSelecionarType.PC.ToString());
                            nota.IdTpNotaFk = tipoNota.IdTpNota.Value;
                            nota.IdCodeSintomaFk = telaVM.id_sintoma;
                            nota.CdNotaSap = telaVM.nr_copese;

                            //nota.IdStCopeseFk = telaVM.id_st_copese_fk;
                            nota.IdLocalInstFk = itemLC.IdLcInstalacao;
                            nota.IdNotaReferenciaFk = IdNotaRef;

                            DateTime dtIni = (telaVM.dt_inicio != null) ? DateTime.Parse(telaVM.dt_inicio) : new DateTime();
                            DateTime dtFim = (telaVM.dt_fim != null) ? DateTime.Parse(telaVM.dt_fim) : new DateTime();

                            var retorno = notaService.ConsultarNotaCopeseEFMRParametros(nota, dtIni, dtFim);
                            foreach (var item in retorno)
                            {
                                listNota.Add(item);
                            }
                        }
                    }
                    else
                    {
                        TipoNota tipoNota = new TipoNotaServices().GetByCodigoSap(TipoNotaSelecionarType.PC.ToString());
                        nota.IdTpNotaFk = tipoNota.IdTpNota.Value;
                        nota.IdCodeSintomaFk = telaVM.id_sintoma;
                        nota.CdNotaSap = telaVM.nr_copese;

                        //nota.IdStCopeseFk = telaVM.id_st_copese_fk;
                        nota.IdNotaReferenciaFk = IdNotaRef;

                        DateTime dtIni = (telaVM.dt_inicio != null) ? DateTime.Parse(telaVM.dt_inicio) : new DateTime();
                        DateTime dtFim = (telaVM.dt_fim != null) ? DateTime.Parse(telaVM.dt_fim) : new DateTime();

                        listNota = notaService.ConsultarNotaCopeseEFMRParametros(nota, dtIni, dtFim);
                    }

                    GridNotaCopeseViewModel gridNotaCopeseViewModels = new GridNotaCopeseViewModel();
                    foreach (var item in listNota)
                    {
                        gridNotaCopeseViewModels = new GridNotaCopeseViewModel();
                        gridNotaCopeseViewModels.nr_copese = item.CdNotaSap;
                        gridNotaCopeseViewModels.dt_abertura_nota_copese = item.DtHoraNota.Value;
                        gridNotaCopeseViewModels.id_copese = item.IdNota.Value.ToString();

                        //if (item.IdStCopeseFk > 0)
                        //{
                        //    StatusCopese statusCopese = new StatusCopeseServices().GetAll().ToList().Find(s => s.IdStCopese == item.IdStCopeseFk);
                        //    gridNotaCopeseViewModels.st_copese_ret = statusCopese.DsStCopese;
                        //}

                        if (item.IdNotaReferenciaFk != null)
                        {
                            nota_ref = notaService.GetById(item.IdNotaReferenciaFk.Value);
                            if (nota_ref != null)
                            {

                                gridNotaCopeseViewModels.nr_nota_ref = nota_ref.CdNotaSap;

                                if (nota_ref.IdLocalInstFk != null)
                                    nota_ref.LocalInstalacao = localInstalacaoServices.GetById(nota_ref.IdLocalInstFk.Value);
                                if (nota_ref.LocalInstalacao != null)
                                {
                                    gridNotaCopeseViewModels.ds_lc_inst = nota_ref.LocalInstalacao.DsLcInstalacao;

                                    var ds_frota = new FrotaServices().GetById(telaVM.id_frota_fk.Value);
                                    var ds_trem = new TremServices().GetById(telaVM.id_trem_fk.Value);
                                    var ds_carro = new CarroServices().GetById(telaVM.id_carro);
                                    gridNotaCopeseViewModels.nr_lc_inst = String.Format("{0} - {1} - {2}", ds_frota.NmFrota, ds_trem.NmTrem, ds_carro.NmCarro);
                                }

                                if (nota_ref.IdCentroTrabalhoFk > 0)
                                    nota_ref.CentroTrabalho = new CentroTrabalhoServices().GetAll().Find(c => c.IdCentroFk == nota_ref.IdCentroTrabalhoFk);
                                if (nota_ref.CentroTrabalho != null)
                                    gridNotaCopeseViewModels.ds_ct_trabalho = nota_ref.CentroTrabalho.DsCtTrabalho;

                                gridNotaCopeseViewModels.dt_abertura_nota_ref = nota_ref.DtHoraNota.Value;
                            }
                        }

                        telaVM.gridNotaCopese.Add(gridNotaCopeseViewModels);
                    }

                    if (telaVM.gridNotaCopese.Count <= 0)
                        ViewBag.NaoEncontrado = "Não há registro retornado na pesquisa.";

                }
                else
                {
                    var model = ModelState;
                    ViewBag.NaoEncontrado = ModelState["CampoRequerido"].Errors[0].ErrorMessage;
                }
                return View("~/Views/CopesePericia/PesquisarNotaCopeseEF.cshtml", telaVM);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
                return View("~/Views/CopesePericia/PesquisarNotaCopeseEF.cshtml", new PesquisaNotaCopeseEFMRViewModel());
            }
        }

        [Route("LimparNotaCopeseEF")]
        public ActionResult LimparNotaCopeseEF(PesquisaNotaCopeseEFMRViewModel telaVM)
        {
            try
            {
                #region Carregar DropDownList
                telaVM.SelecionarLinha = base.CarregaDropDownList(ServicoType.Linha);
                telaVM.SelecionarZona = base.CarregaDropDownList(ServicoType.Zona);
                telaVM.SelecionarSistema = base.CarregaDropDownList(ServicoType.Sistema);
                telaVM.SelecionarComplemento = base.CarregaDropDownList(ServicoType.Complemento);
                telaVM.SelecionarSintoma = base.CarregaDropDownList(ServicoType.Sintoma);
                telaVM.SelecionarStatusPericia = base.CarregaDropDownList(ServicoType.StatusPericia);
                telaVM.SelecionarStatusCopese = base.CarregaDropDownList(ServicoType.StatusCopese);
                #endregion

                return View("~/Views/CopesePericia/PesquisarNotaCopeseEF.cshtml", telaVM);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
                return View("~/Views/CopesePericia/PesquisarNotaCopeseEF.cshtml", new PesquisaNotaCopeseEFMRViewModel());
            }
        }
    }
}