using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PM.Web.ViewModel;
using PM.Web.ViewModel.Pericia;
using PM.WebServices.Service;
using PM.WebServices.Models;
using PM.Domain.Entities.Enum;
using PM.Web.ViewModel.Enum;
using System.Text;
using System.Web.UI.WebControls;

namespace PM.Web.Controllers
{
    /// <summary>
    /// NotaPericiaMRs Controller responsavel pelas ações e trocas de dados de Front e Back.
    /// </summary>
    /// 
    [RoutePrefix("CopesePericia")]
    public class NotaPericiaMRsController : BaseController
    {
        /// <summary>
        /// Chamada da criacao da nota
        /// </summary>
        /// 
        [Route("CriarNotaPericiaMR")]
        public ActionResult CriarNotaPericiaMR(string message)
        {
            NotaPericiaMRViewModel telaVM = new NotaPericiaMRViewModel();

            #region  Carrega DropDownlists

            telaVM.SelecionarStatusPericia = base.CarregaDropDownList(ServicoType.StatusPericia);
            telaVM.SelecionarFrota = base.CarregaDropDownList(ServicoType.Frota);
            telaVM.SelecionarTrem = base.CarregaDropDownList(ServicoType.Trem, 0, true);
            telaVM.SelecionarCarro = base.CarregaDropDownList(ServicoType.Carro, 0, true);
            telaVM.SelecionarEventoGerador = base.CarregaDropDownList(ServicoType.EventoGerador);
            telaVM.SelecionarLinha = base.CarregaDropDownList(ServicoType.Linha);

            #endregion

            //ViewBag.Action = "Criar";
            telaVM.id_nota = 0;
            telaVM.habilitaNotaReferencia = true;
            telaVM.Operacao = ViewModel.Enum.OperacaoType.Criar;
            ViewBag.Message = message;

            return View("~/Views/CopesePericia/CriarNotaPericiaMR.cshtml", telaVM);
        }

        /// <summary>
        /// Chamada da criacao da nota passando o codigo sap da nota de referencia
        /// </summary>
        /// 
        [Route("CriarNotaPericiaMRNotaRef")]
        public ActionResult CriarNotaPericiaMRNotaRef(string _cd_nota_sap_ref)
        {
            NotaPericiaMRViewModel telaVM = new NotaPericiaMRViewModel();

            #region  Carrega DropDownlists

            telaVM.SelecionarStatusPericia = base.CarregaDropDownList(ServicoType.StatusPericia);
            telaVM.SelecionarFrota = base.CarregaDropDownList(ServicoType.Frota);
            telaVM.SelecionarTrem = base.CarregaDropDownList(ServicoType.Trem, 0, true);
            telaVM.SelecionarCarro = base.CarregaDropDownList(ServicoType.Carro, 0, true);
            telaVM.SelecionarEventoGerador = base.CarregaDropDownList(ServicoType.EventoGerador);
            telaVM.SelecionarLinha = base.CarregaDropDownList(ServicoType.Linha);

            #endregion

            //ViewBag.Action = "Criar";
            telaVM.id_nota = 0;
            telaVM.cd_nota_sap_Ref = _cd_nota_sap_ref;
            telaVM.habilitaNotaReferencia = true;
            telaVM.Operacao = ViewModel.Enum.OperacaoType.CriarNotaRef;
            //ViewBag.Message = message;

            return View("~/Views/CopesePericia/CriarNotaPericiaMR.cshtml", telaVM);
        }

        /// <summary>
        /// Chamada da alteracao da nota
        /// </summary>
        /// 
        [Route("EditarNotaPericiaMR")]
        public ActionResult EditarNotaPericiaMR(int id, string message)
        {
            NotaPericiaMRViewModel telaVM = new NotaPericiaMRViewModel();

            NotaServices notaService = new NotaServices();
            Nota nota = new Nota();

            //ViewBag.Action = "Editar";
            nota = notaService.GetById(id);

            telaVM.cd_nota_sap = nota.CdNotaSap;
            telaVM.id_nota = id;
            telaVM.Operacao = ViewModel.Enum.OperacaoType.Editar;
            telaVM.id_st_pericia_fk = nota.IdStPericiaFk == null ? 0 : nota.IdStPericiaFk.Value;
            //if (telaVM.id_st_pericia_fk.Value > 0)
            //{
            //    var perricia = new StatusPericiaServices().GetById(telaVM.id_st_pericia_fk.Value);
            //    telaVM.ds_st_pericia = perricia.DsStPericia;
            //}

            telaVM.id_ev_gerador_fk = nota.IdEvGeradorFk == null ? 0 : nota.IdEvGeradorFk.Value;
            //if (telaVM.id_ev_gerador_fk.Value > 0)
            //{
            //    var eventoGerador = new EventoGeradorServices().GetById(telaVM.id_ev_gerador_fk.Value);
            //    telaVM.ds_evento_gerador = eventoGerador.DsEventoGerador;
            //}

            telaVM.id_nota_referencia_fk = nota.IdNotaReferenciaFk == null ? 0 : nota.IdNotaReferenciaFk.Value;
            telaVM.habilitaNotaReferencia = false;

            if (telaVM.id_nota_referencia_fk.Value > 0)
            {
                var notaRef = notaService.GetById(telaVM.id_nota_referencia_fk.Value);
                telaVM.cd_nota_sap_Ref = notaRef.CdNotaSap;
                telaVM.id_local_inst_Ref = notaRef.IdLocalInstFk == null ? 0 : notaRef.IdLocalInstFk.Value;
                telaVM.habilitaNotaReferencia = true;
            }

            telaVM.id_centro_trabalho_fk = nota.IdCentroTrabalhoFk;
            telaVM.id_local_inst = nota.IdLocalInstFk == null ? 0 : nota.IdLocalInstFk.Value;

            LocalInstalacao localInstalacao;
            if (telaVM.id_local_inst > 0)
            {
                localInstalacao = new LocalInstalacaoServices().GetById(telaVM.id_local_inst);
                telaVM.id_frota_fk = localInstalacao.IdFrotaFk;
                //if (telaVM.id_frota_fk.Value > 0)
                //{
                //    var frota = new FrotaServices().GetById(telaVM.id_frota_fk.Value);
                //    telaVM.nm_frota = frota.NmFrota;
                //}

                telaVM.id_trem_fk = localInstalacao.IdTremFk;
                //if (telaVM.id_trem_fk.Value > 0)
                //{
                //    var trem = new TremServices().GetById(telaVM.id_trem_fk.Value);
                //    telaVM.nm_trem = trem.NmTrem;
                //}

                telaVM.id_carro = localInstalacao.IdCarroFk == null ? 0 : localInstalacao.IdCarroFk.Value;
                //if (telaVM.id_carro > 0)
                //{
                //    var carro = new CarroServices().GetById(telaVM.id_carro);
                //    telaVM.nm_carro = carro.NmCarro;
                //}

                telaVM.id_linha = nota.IdLinhaFk == null ? 0 : nota.IdLinhaFk.Value;
                if (telaVM.id_linha > 0)
                {
                    var centroTrabalho = new CentroTrabalhoServices().GetById(telaVM.id_centro_trabalho_fk.Value);
                    telaVM.ds_ct_trabalho = centroTrabalho.DsCtTrabalho;
                }

                //if (telaVM.id_linha > 0)
                //{
                //    var linha = new LinhaServices().GetById(telaVM.id_linha);
                //    telaVM.nm_linha = linha.NmLinha;
                //}
            }

            #region  Carrega DropDownlists

            telaVM.SelecionarStatusPericia = base.CarregaDropDownList(ServicoType.StatusPericia, telaVM.id_st_pericia_fk.Value);
            telaVM.SelecionarFrota = base.CarregaDropDownList(ServicoType.Frota, telaVM.id_frota_fk.Value);
            telaVM.SelecionarTrem = base.CarregaDropDownList(ServicoType.Trem, telaVM.id_trem_fk.Value);
            telaVM.SelecionarCarro = base.CarregaDropDownList(ServicoType.Carro, telaVM.id_carro);
            telaVM.SelecionarEventoGerador = base.CarregaDropDownList(ServicoType.EventoGerador, telaVM.id_ev_gerador_fk.Value);
            telaVM.SelecionarLinha = base.CarregaDropDownList(ServicoType.Linha, telaVM.id_linha);

            #endregion

            telaVM.ds_descricao = nota.DsDescricao;

            try
            {
                telaVM.id_notificador_fk = nota.IdNotificadorFk == null ? 0 : nota.IdNotificadorFk.Value;
                telaVM.nm_notificador = new EmpregadoServices().GetById(nota.IdNotificadorFk.Value).NmFuncionario;
            } catch (Exception) { }

            telaVM.id_tp_nota_fk = nota.IdTpNotaFk;

            telaVM.cd_bo_metro = nota.CdBoMetro;
            telaVM.ds_bo_metro = nota.DsBoMetro;

            telaVM.cd_bo_ssp = nota.CdBoSsp;
            telaVM.ds_bo_ssp = nota.DsBoSsp;

            telaVM.ds_descricao = nota.DsDescricao;
            telaVM.ds_observacao = nota.DsObservacao;

            telaVM.ds_observacao = nota.DsObservacao;
            telaVM.dt_hora_nota = nota.DtHoraNota.ToString();

            ViewBag.Message = message;

            return View("~/Views/CopesePericia/CriarNotaPericiaMR.cshtml", telaVM);
        }

        /// <summary>
        /// Chamada da consulta da nota
        /// </summary>
        /// 
        [Route("ConsultarNotaPericiaMR")]
        public ActionResult ConsultarNotaPericiaMR(int id, int operacao, string message)
        {
            NotaPericiaMRViewModel telaVM = new NotaPericiaMRViewModel();

            NotaServices notaService = new NotaServices();
            Nota nota = new Nota();

            //ViewBag.Action = "Consultar";
            telaVM.Operacao = (OperacaoType)operacao;
            nota = notaService.GetById(id);
            ViewBag.Message = message;
            telaVM.cd_nota_sap = nota.CdNotaSap;
            telaVM.id_nota = id;

            telaVM.id_st_pericia_fk = nota.IdStPericiaFk == null ? 0 : nota.IdStPericiaFk.Value;
            if (telaVM.id_st_pericia_fk.Value > 0)
            {
                var perricia = new StatusPericiaServices().GetById(telaVM.id_st_pericia_fk.Value);
                telaVM.ds_st_pericia = perricia.DsStPericia;
            }

            telaVM.id_ev_gerador_fk = nota.IdEvGeradorFk == null ? 0 : nota.IdEvGeradorFk.Value;
            telaVM.id_nota_referencia_fk = nota.IdNotaReferenciaFk == null ? 0 : nota.IdNotaReferenciaFk.Value;

            if (telaVM.id_nota_referencia_fk.Value > 0)
            {
                var notaRef = notaService.GetById(telaVM.id_nota_referencia_fk.Value);
                telaVM.cd_nota_sap_Ref = notaRef.CdNotaSap;
            }

            if (telaVM.id_ev_gerador_fk.Value > 0)
            {
                var eventoGerador = new EventoGeradorServices().GetById(telaVM.id_ev_gerador_fk.Value);
                telaVM.ds_evento_gerador = eventoGerador.DsEventoGerador;
            }

            telaVM.id_centro_trabalho_fk = nota.IdCentroTrabalhoFk;
            telaVM.id_local_inst = nota.IdLocalInstFk == null ? 0 : nota.IdLocalInstFk.Value;

            LocalInstalacao localInstalacao;
            if (telaVM.id_local_inst > 0)
            {
                localInstalacao = new LocalInstalacaoServices().GetById(telaVM.id_local_inst);
                telaVM.id_frota_fk = localInstalacao.IdFrotaFk;
                if (telaVM.id_frota_fk.Value > 0)
                {
                    var frota = new FrotaServices().GetById(telaVM.id_frota_fk.Value);
                    telaVM.nm_frota = frota.NmFrota;
                }

                telaVM.id_trem_fk = localInstalacao.IdTremFk;
                if (telaVM.id_trem_fk.Value > 0)
                {
                    var trem = new TremServices().GetById(telaVM.id_trem_fk.Value);
                    telaVM.nm_trem = trem.NmTrem;
                }

                telaVM.id_carro = localInstalacao.IdCarroFk == null ? 0 : localInstalacao.IdCarroFk.Value;
                if (telaVM.id_carro > 0)
                {
                    var carro = new CarroServices().GetById(telaVM.id_carro);
                    telaVM.nm_carro = carro.NmCarro;
                }

                telaVM.id_linha = nota.IdLinhaFk == null ? 0 : nota.IdLinhaFk.Value;
                if (telaVM.id_linha > 0)
                {
                    var linha = new LinhaServices().GetById(telaVM.id_linha);
                    telaVM.nm_linha = linha.NmLinha;
                }
            }

            #region  Carrega DropDownlists
            #endregion

            telaVM.ds_descricao = nota.DsDescricao;
            //telaVM.rg_notificador = nota.RgNotificador;
            //telaVM.ds_ct_trabalho = nota.;

            telaVM.id_tp_nota_fk = nota.IdTpNotaFk;

            telaVM.cd_bo_metro = nota.CdBoMetro;
            telaVM.ds_bo_metro = nota.DsBoMetro;

            telaVM.cd_bo_ssp = nota.CdBoSsp;
            telaVM.ds_bo_ssp = nota.DsBoSsp;

            telaVM.ds_descricao = nota.DsDescricao;
            telaVM.ds_observacao = nota.DsObservacao;

            telaVM.ds_observacao = nota.DsObservacao;
            telaVM.dt_hora_nota = nota.DtHoraNota.ToString();

            return View("~/Views/CopesePericia/ConsultarNotaPericiaMR.cshtml", telaVM);
        }

        /// <summary>
        /// Gravacao da nota (criacao e edicao)
        /// </summary>
        /// 
        [Route("SalvarNotaPericiaMR")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarNotaPericiaMR(NotaPericiaMRViewModel telaVM)
        {
            NotaServices notaService = new NotaServices();
            Nota notaSalvaService = new Nota();

            if (ModelState.IsValid)
            {
                Nota nota;

                if (telaVM.id_nota > 0)
                {
                    nota = notaService.GetById(telaVM.id_nota);
                    telaVM.Operacao = ViewModel.Enum.OperacaoType.Editar;
                }
                else
                {
                    nota = new Nota();
                    telaVM.Operacao = ViewModel.Enum.OperacaoType.Criar;
                }

                //telaVM.id_centro_trabalho_fk = 2;

                TipoNota tipoNota = new TipoNotaServices().GetByCodigoSap(TipoNotaSelecionarType.PE.ToString());
                telaVM.id_tp_nota_fk = tipoNota.IdTpNota.Value;

                nota.DsDescricao = telaVM.ds_descricao;
                nota.IdNotificadorFk = telaVM.id_notificador_fk;

                nota.CdNotaSap = telaVM.cd_nota_sap;

                if (telaVM.id_nota_referencia_fk != null)
                    nota.IdNotaReferenciaFk = telaVM.id_nota_referencia_fk.Value;

                if (telaVM.id_st_pericia_fk != null)
                    nota.IdStPericiaFk = telaVM.id_st_pericia_fk.Value;

                if (telaVM.id_ev_gerador_fk != null)
                    nota.IdEvGeradorFk = telaVM.id_ev_gerador_fk.Value;

                if (telaVM.id_centro_trabalho_fk != null)
                    nota.IdCentroTrabalhoFk = telaVM.id_centro_trabalho_fk.Value;

                if (telaVM.id_linha > 0)
                    nota.IdLinhaFk = telaVM.id_linha;

                if (telaVM.id_local_inst_Ref != 0)
                {
                    telaVM.id_local_inst = telaVM.id_local_inst_Ref;
                    nota.IdLocalInstFk = telaVM.id_local_inst_Ref;

                    var localInstalacao = new LocalInstalacaoServices().GetById(telaVM.id_local_inst_Ref);

                    telaVM.id_frota_fk = localInstalacao.IdFrotaFk;
                    telaVM.id_trem_fk = localInstalacao.IdTremFk;
                    telaVM.id_carro = localInstalacao.IdCarroFk == null ? 0 : localInstalacao.IdCarroFk.Value;
                }
                else
                {
                    var localInstalacao = new LocalInstalacaoServices().Search(telaVM.id_frota_fk.Value, telaVM.id_trem_fk.Value, telaVM.id_carro);

                    if (localInstalacao.Count() > 0)
                    {
                        telaVM.id_local_inst = localInstalacao[0].IdLcInstalacao.Value;
                        nota.IdLocalInstFk = localInstalacao[0].IdLcInstalacao;
                    }
                }

                nota.IdTpNotaFk = telaVM.id_tp_nota_fk;

                nota.CdBoMetro = telaVM.cd_bo_metro;
                nota.DsBoMetro = telaVM.ds_bo_metro;

                nota.CdBoSsp = telaVM.cd_bo_ssp;
                nota.DsBoSsp = telaVM.ds_bo_ssp;

                nota.DsDescricao = telaVM.ds_descricao;
                nota.DsObservacao = telaVM.ds_observacao;
                nota.DtHoraNota = DateTime.Now;

                #region  Carrega DropDownlists

                telaVM.SelecionarStatusPericia = base.CarregaDropDownList(ServicoType.StatusPericia, telaVM.id_st_pericia_fk.Value);
                telaVM.SelecionarFrota = base.CarregaDropDownList(ServicoType.Frota, telaVM.id_frota_fk.Value);
                telaVM.SelecionarTrem = base.CarregaDropDownList(ServicoType.Trem, telaVM.id_trem_fk.Value);
                telaVM.SelecionarCarro = base.CarregaDropDownList(ServicoType.Carro, telaVM.id_carro);
                telaVM.SelecionarEventoGerador = base.CarregaDropDownList(ServicoType.EventoGerador, telaVM.id_ev_gerador_fk.Value);
                telaVM.SelecionarLinha = base.CarregaDropDownList(ServicoType.Linha, telaVM.id_linha);

                #endregion

                if (!ValidaCampos(telaVM))
                    return View("~/Views/CopesePericia/CriarNotaPericiaMR.cshtml", telaVM);

                if (telaVM.id_nota == 0)
                {
                    notaSalvaService = notaService.AddPericia(nota);
                    ViewBag.Message = notaSalvaService.BaseModel.MensagemUsuario;

                    if (notaSalvaService.BaseModel.Erro == true)
                        return View("~/Views/CopesePericia/CriarNotaPericiaMR.cshtml", telaVM);
                    else
                        return RedirectToAction("CriarNotaPericiaMR", new { message = notaSalvaService.BaseModel.MensagemUsuario });
                }
                else
                {
                    notaSalvaService = notaService.UpdatePericia(nota);
                    ViewBag.Message = notaSalvaService.BaseModel.MensagemUsuario;
                    if (notaSalvaService.BaseModel.Erro == true)
                        return View("~/Views/CopesePericia/CriarNotaPericiaMR.cshtml", telaVM);
                    else
                        return RedirectToAction("EditarNotaPericiaMR", new { id = telaVM.id_nota, message = notaSalvaService.BaseModel.MensagemUsuario });

                }
            }
            else
            {
                return View("~/Views/CopesePericia/CriarNotaPericiaMR.cshtml", telaVM);
            }
        }

        /// <summary>
        /// Liberar da nota (criacao e edicao)
        /// </summary>
        /// 
        [Route("LiberarPericiaMR")]
        public ActionResult LiberarPericiaMR(int id)
        {
            NotaServices notaService = new NotaServices();
            Nota notaSalvaService = new Nota();
            Nota nota = notaService.GetById(id);
            notaSalvaService = notaService.LiberarPericia(nota);
            string message = notaSalvaService.BaseModel.MensagemUsuario;
            message = "Rotina de Liberar Pericia sem regra de negocio definida";
            return RedirectToAction("ConsultarNotaPericiaMR", new { id = id, operacao = (int)OperacaoType.Liberar, message = message });
        }

        /// <summary>
        /// Encerrar da nota (criacao e edicao)
        /// </summary>
        /// 
        [Route("EncerrarPericiaMR")]
        public ActionResult EncerrarPericiaMR(int id)
        {
            NotaServices notaService = new NotaServices();
            Nota notaSalvaService = new Nota();
            Nota nota = notaService.GetById(id);
            notaSalvaService = notaService.EncerrarPericia(nota);
            string message = notaSalvaService.BaseModel.MensagemUsuario;
            message = "Rotina de Encerrar Pericia sem regra de negocio definida";
            return RedirectToAction("ConsultarNotaPericiaMR", new { id = id, operacao = (int)OperacaoType.Encerrar, message = message });
        }

        /// <summary>
        /// Cancelar metodo da Controller responsavel por cancelar a nota fiscal.
        /// </summary>
        /// 
        [Route("Cancelar")]
        public ActionResult Cancelar(NotaPSViewModel telaVM)
        {

            return View(telaVM);
        }

        public bool ValidaCampos(NotaPericiaMRViewModel telaVM)
        {
            bool validacoesCampos = true;

            if (telaVM.id_tp_nota_fk == 0)
            {
                ModelState.AddModelError(string.Empty, Mensagens.MSG501.Replace("[#1]", "Tipo da Nota"));
                validacoesCampos = false;
            }

            if (string.IsNullOrEmpty(telaVM.ds_descricao))
            {
                ModelState.AddModelError(string.Empty, Mensagens.MSG501.Replace("[#1]", "Descrição"));
                validacoesCampos = false;
            }

            if (telaVM.id_st_pericia_fk <= 0)
            {
                ModelState.AddModelError(string.Empty, Mensagens.MSG501.Replace("[#1]", "Status da Perícia"));
                validacoesCampos = false;
            }

            if (telaVM.id_frota_fk <= 0)
            {
                ModelState.AddModelError(string.Empty, Mensagens.MSG501.Replace("[#1]", "Frota"));
                validacoesCampos = false;
            }

            if (telaVM.id_trem_fk <= 0)
            {
                ModelState.AddModelError(string.Empty, Mensagens.MSG501.Replace("[#1]", "Trem"));
                validacoesCampos = false;
            }

            if (telaVM.id_carro <= 0)
            {
                ModelState.AddModelError(string.Empty, Mensagens.MSG501.Replace("[#1]", "Carro"));
                validacoesCampos = false;
            }

            if (telaVM.id_linha <= 0)
            {
                ModelState.AddModelError(string.Empty, Mensagens.MSG501.Replace("[#1]", "Linha"));
                validacoesCampos = false;
            }
            if (telaVM.id_centro_trabalho_fk == null)
            {
                ModelState.AddModelError(string.Empty, Mensagens.MSG501.Replace("[#1]", "Centro de Trabalho"));
                validacoesCampos = false;
            }

            if (telaVM.id_local_inst <= 0)
            {
                ModelState.AddModelError(string.Empty, Mensagens.MSG999);
                validacoesCampos = false;
            }

            if (telaVM.id_centro_trabalho_fk < 0 || telaVM.id_centro_trabalho_fk == null)
            {
                ModelState.AddModelError(string.Empty, Mensagens.MSG501.Replace("[#1]", "Centro de Trabalho"));
                validacoesCampos = false;
            }

            if (telaVM.id_ev_gerador_fk <= 0)
            {
                ModelState.AddModelError(string.Empty, Mensagens.MSG501.Replace("[#1]", "Evento Gerador"));
                validacoesCampos = false;
            }

            if (string.IsNullOrEmpty(telaVM.cd_bo_metro) != string.IsNullOrEmpty(telaVM.ds_bo_metro))
            {
                ModelState.AddModelError(string.Empty, Mensagens.MSG502.Replace("[#1]", "Número BO Metrô").Replace("[#2]", "Descr BO Metrô"));
                validacoesCampos = false;
            }

            if (string.IsNullOrEmpty(telaVM.cd_bo_ssp) != string.IsNullOrEmpty(telaVM.ds_bo_ssp))
            {
                ModelState.AddModelError(string.Empty, Mensagens.MSG502.Replace("[#1]", "Número BO SSP").Replace("[#2]", "Descr BO SSP"));
                validacoesCampos = false;
            }

            return validacoesCampos;
        }

        [Route("PericiaBuscarNotaRef")]
        public JsonResult PericiaBuscarNotaRef(string nr_nota_sap)
        {
            Nota nota = new Nota();
            LocalInstRef retorno = new LocalInstRef();

            if (!string.IsNullOrEmpty(nr_nota_sap))
            {
                Empregado empregado = new Empregado();
                Frota frota = new Frota { IdFrota = 0, NmFrota = "*** SELECIONE ***" };
                Trem trem = new Trem { IdTrem = 0, NmTrem = "*** SELECIONE ***" };
                Carro carro = new Carro { IdCarro = 0, NmCarro = "*** SELECIONE ***" };
                Linha linha = new Linha { IdLinha = 0, NmLinha = "*** SELECIONE ***" };
                CentroTrabalho centroTrabalho = new CentroTrabalho { IdCtTrabalho = 0, DsCtTrabalho = "" };

                nota = new NotaServices().GetNotasCodigoSapMR(nr_nota_sap);

                if (nota.IdNota != null)
                {
                    if (nota.LocalInstalacao?.IdFrotaFk != null)
                        frota = new FrotaServices().GetById(nota.LocalInstalacao.IdFrotaFk.Value);

                    if (nota.IdNotificadorFk != null)
                        empregado = new EmpregadoServices().GetById(nota.IdNotificadorFk.Value);

                    if (nota.LocalInstalacao?.IdTremFk != null)
                        trem = new TremServices().GetById(nota.LocalInstalacao.IdTremFk.Value);

                    if (nota.LocalInstalacao?.IdCarroFk != null)
                        carro = new CarroServices().GetById(nota.LocalInstalacao.IdCarroFk.Value);

                    if (nota.LocalInstalacao?.IdLinhaFk != null)
                    {
                        linha = new LinhaServices().GetById(nota.LocalInstalacao.IdLinhaFk.Value);
                        if (linha?.IdCentroTrabalhoFk != null)
                            centroTrabalho = new CentroTrabalhoServices().GetById(linha.IdCentroTrabalhoFk.Value);
                    }

                    retorno = new LocalInstRef
                    {
                        id_nota = nota.IdNota.Value,
                        ds_descricao = nota.DsDescricao,
                        id_local_inst = nota.IdLocalInstFk != null ? nota.IdLocalInstFk.Value : 0,
                        id_frota = frota.IdFrota.Value,
                        nm_frota = frota.NmFrota,
                        id_trem = trem.IdTrem.Value,
                        nm_trem = trem.NmTrem,
                        id_carro = carro.IdCarro.Value,
                        nm_carro = carro.NmCarro,
                        id_linha = linha.IdLinha.Value,
                        nm_linha = linha.NmLinha,
                        nm_notificador = empregado == null ? "" : empregado.NmFuncionario,
                        id_notificador_fk = nota.IdNotificadorFk != null ? nota.IdNotificadorFk.Value : 0,
                        id_ct_trabalho = centroTrabalho.IdCtTrabalho.Value,
                        ds_ct_trabalho = centroTrabalho.DsCtTrabalho,
                    };
                }
                else
                {
                    retorno = new LocalInstRef
                    {
                        id_nota = 0,
                        id_local_inst = 0,
                        id_frota = 0,
                        nm_frota = "",
                        id_trem = 0,
                        nm_trem = "*** SELECIONE ***",
                        id_carro = 0,
                        nm_carro = "*** SELECIONE ***",
                        id_linha = 0,
                        nm_linha = "*** SELECIONE ***",
                        id_ct_trabalho = 0,
                        ds_ct_trabalho = "",
                        ds_descricao = "",
                        nm_notificador = string.Empty,
                        id_notificador_fk = 0,
                        listaFrota = CarregaDropDownList(ServicoType.Frota).ToList()
                    };
                }
            }
            else
            {
                retorno = new LocalInstRef
                {
                    id_nota = 0,
                    id_local_inst = 0,
                    id_frota = 0,
                    nm_frota = "",
                    id_trem = 0,
                    nm_trem = "*** SELECIONE ***",
                    id_carro = 0,
                    nm_carro = "*** SELECIONE ***",
                    id_linha = 0,
                    nm_linha = "*** SELECIONE ***",
                    id_ct_trabalho = 0,
                    ds_ct_trabalho = "",
                    nm_notificador = string.Empty,
                    id_notificador_fk = 0,
                    ds_descricao = "",
                    listaFrota = CarregaDropDownList(ServicoType.Frota).ToList()
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [Route("PesquisarNotaPericiaMR")]
        public ActionResult PesquisarNotaPericiaMR()
        {
            try
            {
                PesquisaNotaPericiaMRViewModel telaVM = new PesquisaNotaPericiaMRViewModel();
                #region Carregar DropDownList
                telaVM.SelecionarFrota = base.CarregaDropDownList(ServicoType.Frota);
                telaVM.SelecionarTrem = base.CarregaDropDownList(ServicoType.Trem, 0, true);
                telaVM.SelecionarCarro = base.CarregaDropDownList(ServicoType.Carro, 0, true);
                telaVM.SelecionarSistema = base.CarregaDropDownList(ServicoType.Sistema, 0, true);
                telaVM.SelecionarEventoGerador = base.CarregaDropDownList(ServicoType.EventoGerador);
                telaVM.SelecionarStatusPericia = base.CarregaDropDownList(ServicoType.StatusPericia);
                #endregion

                ViewBag.Action = "Pesquisar";

                return View("~/Views/CopesePericia/PesquisarNotaPericiaMR.cshtml", telaVM);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
                return View("~/Views/CopesePericia/PesquisarNotaPericiaMR.cshtml", new PesquisaNotaPericiaMRViewModel());
            }
        }

        [HttpPost]
        [Route("FiltrarNotaPericiaMR")]
        public ActionResult FiltrarNotaPericiaMR(PesquisaNotaPericiaMRViewModel telaVM)
        {
            try
            {
                if (
                    telaVM.id_st_pericia_fk <= 0 &&
                    telaVM.id_frota_fk <= 0 &&
                    telaVM.id_trem_fk <= 0 &&
                    telaVM.id_carro <= 0 &&
                    telaVM.id_sistema <= 0 &&
                    telaVM.id_ev_gerador_fk <= 0 &&
                    String.IsNullOrEmpty(telaVM.cd_bo_metro) &&
                    String.IsNullOrEmpty(telaVM.cd_bo_ssp) &&
                    String.IsNullOrEmpty(telaVM.cd_nota_sap) &&
                    String.IsNullOrEmpty(telaVM.cd_nota_sap_Ref) &&
                    telaVM.dt_inicio == null &&
                    telaVM.dt_fim == null &&
                    telaVM.id_st_pericia_fk <= 0
                    )
                    ModelState.AddModelError("CampoRequerido", "Informe ao menos um filtro de pesquisa.");
                else if ((telaVM.dt_fim != null && telaVM.dt_fim != null) && Convert.ToDateTime(telaVM.dt_fim) < Convert.ToDateTime(telaVM.dt_inicio))
                    ModelState.AddModelError("CampoRequerido", "Data Final deve ser maior que a Data Inicial.");

                if (ModelState.IsValid)
                {
                    telaVM = CarregaTelaVM(telaVM);

                    if (telaVM.gridNotaCopese.Count <= 0)
                        ViewBag.NaoEncontrado = "Não há registro retornado na pesquisa.";
                }
                else
                {
                    var model = ModelState;
                    ViewBag.NaoEncontrado = ModelState["CampoRequerido"].Errors[0].ErrorMessage;
                }
                return View("~/Views/CopesePericia/PesquisarNotaPericiaMR.cshtml", telaVM);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
                return View("~/Views/CopesePericia/PesquisarNotaPericiaMR.cshtml", telaVM);
            }
        }

        [Route("LimparNotaPericiaMR")]
        public ActionResult LimparNotaPericiaMR(PesquisaNotaPericiaMRViewModel telaVM)
        {
            try
            {
                telaVM = new PesquisaNotaPericiaMRViewModel();

                #region Carregar DropDownList
                telaVM.SelecionarFrota = base.CarregaDropDownList(ServicoType.Frota);
                telaVM.SelecionarTrem = base.CarregaDropDownList(ServicoType.Trem, 0, true);
                telaVM.SelecionarCarro = base.CarregaDropDownList(ServicoType.Carro, 0, true);
                telaVM.SelecionarSistema = base.CarregaDropDownList(ServicoType.Sistema, 0, true);
                telaVM.SelecionarEventoGerador = base.CarregaDropDownList(ServicoType.EventoGerador);
                telaVM.SelecionarStatusPericia = base.CarregaDropDownList(ServicoType.StatusPericia);
                #endregion

                return View("~/Views/CopesePericia/PesquisarNotaPericiaMR.cshtml", telaVM);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
                return View("~/Views/CopesePericia/PesquisarNotaPericiaMR.cshtml", telaVM);
            }
        }

        //[HttpGet]
        [Route("ExportNotaPericiaToExcelMR")]
        public ActionResult ExportNotaPericiaToExcelMR(PesquisaNotaPericiaMRViewModel telaVM)
        {
            telaVM = CarregaTelaVM(telaVM);

            var gv = new GridView();

            gv.DataSource = telaVM.gridNotaCopese;

            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;

            Response.Clear();
            Response.ClearHeaders();
            Response.ContentType = "application/ms-excel";
            Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            Response.AddHeader("Content-Disposition", "attachment;filename=NotaPericiaMR.xls");

            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");

            StringBuilder sb = new StringBuilder();

            sb.Append("<font Style='font-size:13px; font-family:sans-serif;'>");
            sb.Append("<Table border='0px none'>");
            sb.Append("<TR>");
            //Aplica o estilo a coluna
            string sTH = "<Td Style=\"color:#FFFFFF; font-size:13px; font-family:sans-serif;\" bgColor='#6495ED' color='#DEE2E6' border='1px solid #DEE2E6' cellSpacing='0' cellPadding='0'>";
            //Criar as colunas
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Nota de Ref"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Nota Perícia"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Local de Instalação"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Descrição do Instalação"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Descrição da Nota"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Evento Gerador"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Data"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Hora"));
            //sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Notificador"));
            //sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Centro de Trabalho"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Status da Perícia"));

            sb.Append("</TR>");

            bool alternate = true;
            string sTD;
            foreach (GridViewRow row in gv.Rows)
            {

                sb.Append("<TR>");
                //Aplica o estilo alternativo para as linhas nas colunas
                if (alternate)
                    sTD = "<Td Style=\"font-size:13px; font-family:sans-serif; \" bgColor='#F2F2F2'>";
                else
                    sTD = "<Td Style=\"font-size:13px; font-family:sans-serif; \" bgColor='transparent'>";

                alternate = !alternate;

                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[0].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[1].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[2].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[3].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[4].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[5].Text.ToString());
                //sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[6].Text.ToString());
                //sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[7].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, Convert.ToDateTime(row.Cells[6].Text.ToString()).ToString("dd/MM/yyyy"));
                sb.AppendFormat("{0}{1}</Td>", sTD, Convert.ToDateTime(row.Cells[7].Text.ToString()).ToString("hh:mm"));
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[8].Text.ToString());

                sb.Append("</TR>");
            }
            sb.Append("</Table>");
            sb.Append("</font>");

            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();

            return View("~/Views/CopesePericia/PesquisarNotaPericiaMR.cshtml", telaVM);
        }

        private PesquisaNotaPericiaMRViewModel CarregaTelaVM(PesquisaNotaPericiaMRViewModel telaVM)
        {
            #region Carregar DropDownList
            telaVM.SelecionarTrem = base.CarregaDropDownList(ServicoType.Frota, telaVM.id_frota, false);
            telaVM.SelecionarTrem = base.CarregaDropDownList(ServicoType.Trem, (telaVM.id_trem_fk != null) ? telaVM.id_trem_fk.Value : 0, false);
            telaVM.SelecionarCarro = base.CarregaDropDownList(ServicoType.Carro, telaVM.id_carro, false);
            telaVM.SelecionarSistema = base.CarregaDropDownList(ServicoType.Sistema, telaVM.id_sistema, true);
            telaVM.SelecionarEventoGerador = base.CarregaDropDownList(ServicoType.EventoGerador, telaVM.id_ev_gerador_fk);
            telaVM.SelecionarStatusPericia = base.CarregaDropDownList(ServicoType.StatusPericia, (telaVM.id_st_pericia_fk != null) ? telaVM.id_st_pericia_fk.Value : 0);
            #endregion

            #region  CarregarGrid

            NotaServices notaService = new NotaServices();
            LocalInstalacaoServices localInstalacaoServices = new LocalInstalacaoServices();

            Nota nota = new Nota();
            LocalInstalacao localInstalacao = new LocalInstalacao();

            IList<Nota> listNota = new List<Nota>();
            Nota nota_ref = new Nota();
            IList<LocalInstalacao> listLocalInstalacao = new List<LocalInstalacao>();

            localInstalacao.IdFrotaFk = telaVM.id_frota_fk;
            localInstalacao.IdTremFk = telaVM.id_trem_fk;
            localInstalacao.IdCarroFk = telaVM.id_carro;

            listLocalInstalacao = localInstalacaoServices.ConsultarLCParametros(localInstalacao);

            int IdNotaRef = 0;
            if (!string.IsNullOrEmpty(telaVM.cd_nota_sap_Ref))
            {
                var notaRef = notaService.GetNotasCodigoSap(telaVM.cd_nota_sap_Ref);
                IdNotaRef = notaRef.IdNota.Value;
            }

            if (listLocalInstalacao.Count > 0)
            {
                foreach (var itemLC in listLocalInstalacao)
                {
                    TipoNota tipoNota = new TipoNotaServices().GetByCodigoSap(TipoNotaSelecionarType.PE.ToString());
                    nota.IdTpNotaFk = tipoNota.IdTpNota.Value;

                    nota.IdLocalInstFk = itemLC.IdLcInstalacao;
                    nota.IdEvGeradorFk = telaVM.id_ev_gerador_fk;
                    nota.CdBoMetro = telaVM.cd_bo_metro;
                    nota.CdBoSsp = telaVM.cd_bo_ssp;
                    nota.CdNotaSap = telaVM.cd_nota_sap;

                    string dtIni = (telaVM.dt_inicio != null) ? telaVM.dt_inicio : new DateTime().ToShortDateString();
                    string dtFim = (telaVM.dt_fim != null) ? telaVM.dt_fim : new DateTime().ToShortDateString();

                    nota.IdNotaReferenciaFk = IdNotaRef;
                    nota.IdStPericiaFk = telaVM.id_st_pericia_fk;

                    var retorno = notaService.ConsultarNotaPericiaMRParametros(nota, dtIni, dtFim);
                    foreach (var item in retorno)
                    {
                        listNota.Add(item);
                    }
                }
            }
            else
            {
                TipoNota tipoNota = new TipoNotaServices().GetByCodigoSap(TipoNotaSelecionarType.PE.ToString());
                nota.IdTpNotaFk = tipoNota.IdTpNota.Value;

                nota.IdEvGeradorFk = telaVM.id_ev_gerador_fk;
                nota.CdBoMetro = telaVM.cd_bo_metro;
                nota.CdBoSsp = telaVM.cd_bo_ssp;
                nota.CdNotaSap = telaVM.cd_nota_sap;

                string dtIni = (telaVM.dt_inicio != null) ? telaVM.dt_inicio : new DateTime().ToShortDateString();
                string dtFim = (telaVM.dt_fim != null) ? telaVM.dt_fim : new DateTime().ToShortDateString();

                nota.IdNotaReferenciaFk = IdNotaRef;
                nota.IdStPericiaFk = telaVM.id_st_pericia_fk;

                listNota = notaService.ConsultarNotaPericiaMRParametros(nota, dtIni, dtFim);
            }

            GridNotaPericiaViewModel gridNotaCopeseViewModels = new GridNotaPericiaViewModel();
            foreach (var item in listNota)
            {
                gridNotaCopeseViewModels = new GridNotaPericiaViewModel();
                gridNotaCopeseViewModels.cd_nota_sap = item.CdNotaSap;
                gridNotaCopeseViewModels.dt_nota = item.DtHoraNota.Value.ToShortDateString();
                gridNotaCopeseViewModels.hr_nota = item.DtHoraNota.Value.ToShortTimeString();

                gridNotaCopeseViewModels.id_nota = item.IdNota.Value.ToString();
                gridNotaCopeseViewModels.ds_nota = item.DsDescricao;

                if (item.IdEvGeradorFk != null)
                {
                    EventoGerador code = new EventoGeradorServices().GetAll().ToList().Find(c => c.IdEventoGerador == item.IdEvGeradorFk.Value);
                    gridNotaCopeseViewModels.ds_evento_gerador = code.DsEventoGerador;
                }

                if (item.IdStPericiaFk > 0)
                {
                    StatusPericia statusCopese = new StatusPericiaServices().GetAll().ToList().Find(s => s.IdStPericia == item.IdStPericiaFk);
                    gridNotaCopeseViewModels.ds_st_pericia = statusCopese.DsStPericia;
                }

                if (item.IdNotaReferenciaFk != null)
                {
                    nota_ref = notaService.GetById(item.IdNotaReferenciaFk.Value);
                    if (nota_ref != null)
                    {
                        gridNotaCopeseViewModels.cd_nota_sap_Ref = nota_ref.CdNotaSap;

                        if (nota_ref.IdLocalInstFk != null)
                            nota_ref.LocalInstalacao = localInstalacaoServices.GetById(nota_ref.IdLocalInstFk.Value);
                        if (nota_ref.LocalInstalacao != null)
                        {
                            gridNotaCopeseViewModels.ds_lc_inst = nota_ref.LocalInstalacao.DsLcInstalacao;

                            string NmFrota = string.Empty;
                            string NmTrem = string.Empty;
                            string NmCarro = string.Empty;

                            try
                            {
                                NmFrota = new FrotaServices().GetById(nota_ref.LocalInstalacao.IdFrotaFk.Value).NmFrota;
                                NmTrem = new TremServices().GetById(nota_ref.LocalInstalacao.IdTremFk.Value).NmTrem;
                                NmCarro = new CarroServices().GetById(nota_ref.LocalInstalacao.IdCarroFk.Value).NmCarro;
                            }
                            catch (Exception) { }

                            gridNotaCopeseViewModels.nr_lc_inst = String.Format("{0} - {1} - {2}", NmFrota, NmTrem, NmCarro);
                        }

                        if (nota_ref.IdCentroTrabalhoFk > 0)
                            nota_ref.CentroTrabalho = new CentroTrabalhoServices().GetAll().Find(c => c.IdCtTrabalho == nota_ref.IdCentroTrabalhoFk);
                    }
                }

                telaVM.gridNotaCopese.Add(gridNotaCopeseViewModels);
            }
            #endregion
            return telaVM;
        }

        [Route("FiltrarNotaPericiaMRjson")]
        public JsonResult FiltrarNotaPericiaMRjson(PesquisaNotaPericiaMRViewModel telaVM)
        {
            JsonResult result;
            try
            {
                if (
                    telaVM.id_st_pericia_fk <= 0 &&
                    (telaVM.id_frota_fk == null || telaVM.id_frota_fk <= 0) &&
                    telaVM.id_trem_fk <= 0 &&
                    telaVM.id_carro <= 0 &&
                    String.IsNullOrEmpty(telaVM.cd_bo_metro) &&
                    String.IsNullOrEmpty(telaVM.cd_bo_ssp) &&
                    String.IsNullOrEmpty(telaVM.cd_nota_sap) &&
                    String.IsNullOrEmpty(telaVM.cd_nota_sap_Ref) &&
                    telaVM.dt_inicio == null &&
                    telaVM.dt_fim == null)
                    ModelState.AddModelError("CampoRequerido", "Informe ao menos um filtro de pesquisa.");
                else if ((telaVM.dt_inicio != null && telaVM.dt_fim != null) && Convert.ToDateTime(Convert.ToDateTime(telaVM.dt_fim).ToString("dd/MM/yyyy")) < Convert.ToDateTime(Convert.ToDateTime(telaVM.dt_inicio).ToString("dd/MM/yyyy")))
                    ModelState.AddModelError("CampoRequerido", "Data Final deve ser maior que a Data Inicial.");

                if (ModelState.IsValid)
                {
                    PesquisaNotaPericiaMRViewModel telaVMReturn = new PesquisaNotaPericiaMRViewModel();

                    //Carregamento dos Documentos Vinculados
                    telaVMReturn = CarregaTelaVM(telaVM);

                    if (telaVMReturn != null)
                    {
                        if (telaVMReturn.gridNotaCopese.Count > 0)
                        {
                            //Conversão de ViewModel para Json compatível com o plugin dataTable
                            List<String[]> values = telaVMReturn.gridNotaCopese.Select(x => new String[] {
                            (x.cd_nota_sap_Ref != null) ? x.cd_nota_sap_Ref.ToString():string.Empty,
                            (x.cd_nota_sap != null) ? x.cd_nota_sap:string.Empty,
                            (x.nr_lc_inst != null) ? x.nr_lc_inst:string.Empty,
                            (x.ds_lc_inst != null) ? x.ds_lc_inst.ToString():string.Empty,
                            (x.ds_nota != null) ? x.ds_nota.ToString():string.Empty,
                            (x.ds_evento_gerador != null) ? x.ds_evento_gerador.ToString():string.Empty,
                            (x.dt_nota != null) ? x.dt_nota.ToString():string.Empty,
                            (x.hr_nota != null) ? x.hr_nota.ToString():string.Empty,
                                (x.ds_st_pericia != null) ? x.ds_st_pericia.ToString():string.Empty,
                                string.Format(@"<a href='#' data-id='{0}' class='btn_details'><i class='material-icons'>search</i></a>" +
                                //"<a href='#' data-id='{0}' class='btn_add'><i class='material-icons'>add</i></a>" +
                                "<a href='#' data-id='{0}' class='btn_edit'><i class='material-icons'>edit</i></a>"+
                                "<a href='#' data-id='{0}' class='btn_libera'><i class='material-icons'>done</i></a>"+
                                "<a href='#' data-id='{0}' class='btn_encerra'><i class='material-icons'>clear</i></a>"
                                //"<a href='#' data-id='{0}' class='btn_cancel'><i class='material-icons' style='color:#FF0000'>close</i></a>"
                                ,(x.id_nota != null) ? x.id_nota.ToString():string.Empty)
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
                    else
                    {
                        List<String[]> values = new List<string[]>();
                        var _values = new { data = values };
                        result = Json(_values, JsonRequestBehavior.AllowGet);
                    }

                    if (telaVM.gridNotaCopese.Count <= 0)
                        ViewBag.NaoEncontrado = "Não há registro retornado na pesquisa.";
                }
                else
                {
                    var model = ModelState;
                    ViewBag.NaoEncontrado = ModelState["CampoRequerido"].Errors[0].ErrorMessage;
                    List<String[]> values = new List<string[]>();
                    var _values = new { data = values };
                    result = Json(_values, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                List<String[]> values = new List<string[]>();
                var _values = new { data = values };
                result = Json(_values, JsonRequestBehavior.AllowGet);
            }

            return result;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);

        }
    }

    public struct LocalInstRef
    {
        public int id_nota { get; set; }
        public int id_local_inst { get; set; }

        public int id_frota { get; set; }
        public string nm_frota { get; set; }

        public int id_trem { get; set; }
        public string nm_trem { get; set; }

        public int id_carro { get; set; }
        public string nm_carro { get; set; }

        public int id_linha { get; set; }
        public string nm_linha { get; set; }

        public int id_ct_trabalho { get; set; }
        public string ds_ct_trabalho { get; set; }
        public string nm_notificador { get; set; }
        public int id_notificador_fk { get; set; }
        public string ds_descricao { get; set; }

        public List<SelectListItem> listaFrota { get; set; }
    }
}
