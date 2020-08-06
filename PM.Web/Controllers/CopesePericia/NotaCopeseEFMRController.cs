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
using PM.WebServices.Service;
using PM.WebServices.Models;
using PM.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using PM.Web.ViewModel.Copese;
using PM.Web.ViewModel.Enum;

namespace PM.Web.Controllers
{
    /// <summary>
    /// NotaOCOPOLs Controller responsavel pelas ações e trocas de dados de Front e Back.
    /// </summary>
    /// 
    [RoutePrefix("CopesePericia")]
    public class NotaCopeseEFMRController : BaseController
    {
        /// <summary>
        /// Chamada da criacao da nota
        /// </summary>
        /// 
        [Route("CriarNotaCopeseEFMR")]
        public ActionResult CriarNotaCopeseEFMR(string cd_sap)
        {
            NotaCopeseEFMRViewModel telaVM = new NotaCopeseEFMRViewModel();
            telaVM.SelecionarLinha = base.CarregaDropDownList(ServicoType.Linha);
            telaVM.SelecionarCimAcionado = base.CarregaDropDownList(ServicoType.CimAcionado);

            ViewBag.Action = "Criar";
            telaVM.Operacao = OperacaoType.Criar;

            if (!string.IsNullOrEmpty(cd_sap))
            {

                Nota nota = new NotaServices().GetNotasCodigoSapMRRef(cd_sap);

                if (nota != null)
                {
                    telaVM.cd_nota_sap_Ref = nota.CdNotaSap;
                    telaVM.id_nota_Ref = nota.IdNota.Value;
                    telaVM.ds_descricao_Ref = nota.DsDescricao;

                    if (nota.LocalInstalacao != null)
                    {
                        telaVM.cd_local_inst_sap_Ref = nota.LocalInstalacao.DsLcInstalacao;
                        telaVM.id_local_inst_Ref = nota.LocalInstalacao.IdLcInstalacao.Value;

                        if (nota.IdLinhaFk != null)
                        {
                            nota.Linha = new LinhaServices().GetById(nota.IdLinhaFk.Value);
                            if (nota.Linha != null)
                            {
                                telaVM.nm_linha = nota.Linha.NmLinha;
                                telaVM.id_linha = nota.Linha.IdLinha.Value;
                            }
                        }

                        if (nota.IdNotificadorFk != null)
                            nota.Empregado = new EmpregadoServices().GetById(nota.IdNotificadorFk.Value);

                        if (nota.Empregado != null)
                        {
                            telaVM.rg_notificador = nota.Empregado.RgEmpregado;
                            telaVM.id_notificador_fk = nota.Empregado.IdEmpregado.Value;
                        }
                        if (nota.CentroTrabalho != null)
                        {
                            telaVM.ds_ct_trabalho = nota.CentroTrabalho.DsCtTrabalho;
                            telaVM.id_ct_trabalho = nota.CentroTrabalho.IdCtTrabalho.Value;
                        }
                        if (nota.CodeSintoma != null)
                        {
                            telaVM.ds_breve_code_Ref = nota.CodeSintoma.DsCode;
                            telaVM.id_code_Ref = nota.CodeSintoma.IdCode.Value;
                        }
                    }
                }
            }

            return View("~/Views/CopesePericia/NotaCopeseEFMR.cshtml", telaVM);
        }

        /// <summary>
        /// Chamada da alteracao da nota
        /// </summary>
        /// 
        [Route("EditarNotaCopeseEFMR")]
        public ActionResult EditarNotaCopeseEFMR(int id)
        {
            NotaCopeseEFMRViewModel telaVM = new NotaCopeseEFMRViewModel();
            telaVM.Operacao = OperacaoType.Editar;

            telaVM.SelecionarCimAcionado = base.CarregaDropDownList(ServicoType.CimAcionado);

            NotaServices notaService = new NotaServices();
            Nota nota = new Nota();

            ViewBag.Action = "Editar";
            nota = notaService.GetById(id);
            if (nota.IdNotaReferenciaFk != null)
                nota.NotaReferencia = notaService.GetById(nota.IdNotaReferenciaFk.Value);

            telaVM.id_nota = nota.IdNota;

            if (nota.NotaReferencia != null)
            {
                telaVM.cd_nota_sap_Ref = nota.NotaReferencia.CdNotaSap;
                telaVM.ds_descricao_Ref = nota.NotaReferencia.DsDescricao;
            }

            if (nota.IdLocalInstFk != null)
            {
                nota.LocalInstalacao = new LocalInstalacaoServices().GetById(nota.IdLocalInstFk.Value);

                if (nota.LocalInstalacao != null)
                {
                    telaVM.cd_local_inst_sap_Ref = nota.LocalInstalacao.DsLcInstalacao;
                    telaVM.id_local_inst_Ref = nota.LocalInstalacao.IdLcInstalacao.Value;

                    nota.LocalInstalacao.Linha = (nota.LocalInstalacao.IdLinhaFk != null) ? new LinhaServices().GetById(nota.LocalInstalacao.IdLinhaFk.Value): null;
                    if (nota.LocalInstalacao.Linha != null)
                    {
                        telaVM.nm_linha = nota.LocalInstalacao.Linha.NmLinha;
                        telaVM.id_linha = nota.LocalInstalacao.Linha.IdLinha.Value;
                    }
                }
            }

            Empregado empregado = new EmpregadoServices().GetById(nota.IdNotificadorFk.Value);
            if (empregado != null)
            {
                telaVM.id_notificador_fk = empregado.IdEmpregado.Value;
                telaVM.rg_notificador = empregado.RgEmpregado;
            }

            CentroTrabalho centroTrabalho = new CentroTrabalhoServices().GetById(nota.IdCentroTrabalhoFk);

            if (centroTrabalho != null)
            {
                telaVM.ds_ct_trabalho = centroTrabalho.DsCtTrabalho;
                telaVM.id_ct_trabalho = centroTrabalho.IdCtTrabalho.Value;
            }

            if (nota.IdCodeSintomaFk != null)
            {
                nota.CodeSintoma = new SintomaServices().GetAll().Where(s => s.IdCode == nota.IdCodeSintomaFk.Value).First();
                if (nota.CodeSintoma != null)
                {
                    telaVM.ds_breve_code_Ref = nota.CodeSintoma.DsCode;
                    telaVM.id_code_Ref = nota.CodeSintoma.IdCode.Value;
                }
            }
            telaVM.ds_local_inst_Ref = nota.DsDescricao;
            telaVM.id_nota_Ref = nota.IdNotaReferenciaFk.Value;
            telaVM.ds_observacao = nota.DsObservacao;

            Empregado pnAcionado = (nota.IdPnAcionadoFk != null) ? new EmpregadoServices().GetById(nota.IdPnAcionadoFk.Value) : null;
            if (pnAcionado != null)
            {

                telaVM.id_plantonista_acionado = pnAcionado.IdEmpregado.Value;
                telaVM.nm_plantonista_acionado = pnAcionado.RgEmpregado;
            }

            CentroTrabalho ciAcionado = (nota.IdCiAcionadoFk != null) ? new CentroTrabalhoServices().GetById(nota.IdCiAcionadoFk.Value) : null;

            if (ciAcionado != null)
            {
                telaVM.id_cim_acionado = ciAcionado.IdCtTrabalho.Value;
                telaVM.nm_cim_acionado = ciAcionado.DsCtTrabalho;
            }

            Empregado plAcionado1 = (nota.IdPlRepresAcionadoFk != null) ? new EmpregadoServices().GetById(nota.IdPlRepresAcionadoFk.Value) : null;
            if (plAcionado1 != null)
            {
                telaVM.id_pl_represent_acionado1 = plAcionado1.IdEmpregado.Value;
                telaVM.nm_pl_represent_acionado1 = plAcionado1.RgEmpregado;
            }
            Empregado plAcionado2 = (nota.IdPlRepresAcionado2Fk != null) ? new EmpregadoServices().GetById(nota.IdPlRepresAcionado2Fk.Value) : null;
            if (plAcionado2 != null)
            {
                telaVM.id_pl_represent_acionado2 = plAcionado2.IdEmpregado.Value;
                telaVM.nm_pl_represent_acionado2 = plAcionado2.RgEmpregado;
            }
            Empregado plAcionado3 = (nota.IdPlRepresAcionado3Fk != null) ? new EmpregadoServices().GetById(nota.IdPlRepresAcionado3Fk.Value) : null;
            if (plAcionado3 != null)
            {
                telaVM.id_pl_represent_acionado3 = plAcionado3.IdEmpregado.Value;
                telaVM.nm_pl_represent_acionado3 = plAcionado3.RgEmpregado;
            }
            Empregado plAcionado4 = (nota.IdPlRepresAcionado4Fk != null) ? new EmpregadoServices().GetById(nota.IdPlRepresAcionado4Fk.Value) : null;
            if (plAcionado4 != null)
            {
                telaVM.id_pl_represent_acionado4 = plAcionado4.IdEmpregado.Value;
                telaVM.nm_pl_represent_acionado4 = plAcionado4.RgEmpregado;
            }

            return View("~/Views/CopesePericia/NotaCopeseEFMR.cshtml", telaVM);
        }

        /// <summary>
        /// Chamada da consulta da nota
        /// </summary>
        /// 
        [Route("ConsultarNotaCopeseMR")]
        public ActionResult ConsultarNotaCopeseMR(int id)
        {
            NotaCopeseEFMRViewModel telaVM = new NotaCopeseEFMRViewModel();
            telaVM = BuscarDadosCopese(id);
            telaVM.Operacao = OperacaoType.Consultar;

            return View("~/Views/CopesePericia/ConsultarNotaCopeseMR.cshtml", telaVM);
        }

        /// <summary>
        /// Chamada da consulta da nota
        /// </summary>
        /// 
        [Route("ConsultarNotaCopeseEF")]
        public ActionResult ConsultarNotaCopeseEF(int id)
        {
            NotaCopeseEFMRViewModel telaVM = new NotaCopeseEFMRViewModel();
            telaVM = BuscarDadosCopese(id);
            telaVM.Operacao = OperacaoType.Consultar;
            return View("~/Views/CopesePericia/ConsultarNotaCopeseEF.cshtml", telaVM);
        }

        /// <summary>
        /// Gravacao da nota (criacao e edicao)
        /// </summary>
        /// 
        [Route("SalvarNotaCopeseEFMR")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarNotaCopeseEFMR(NotaCopeseEFMRViewModel telaVM)
        {
            telaVM.SelecionarCimAcionado = base.CarregaDropDownList(ServicoType.CimAcionado);

            NotaServices notaService = new NotaServices();
            Nota notaSalvaService = new Nota();



            if (ModelState.IsValid)
            {
                Nota notaRef = new NotaServices().GetById(telaVM.id_nota_Ref);
                Nota nota = new Nota();
                nota.IdNotaReferenciaFk = (telaVM.id_nota_Ref != 0) ? telaVM.id_nota_Ref : new int?();
                nota.IdLocalInstFk = telaVM.id_local_inst_Ref;
                nota.IdCodeSintomaFk = telaVM.id_code_Ref;
                nota.DsDescricao = (notaRef != null) ? notaRef.DsDescricao : "";

                nota.DsObservacao = telaVM.ds_observacao;
                nota.IdPnAcionadoFk = telaVM.id_plantonista_acionado.Value;
                nota.IdCiAcionadoFk = telaVM.id_cim_acionado;
                nota.IdPlRepresAcionadoFk = telaVM.id_pl_represent_acionado1 ?? null;
                nota.IdPlRepresAcionado2Fk = telaVM.id_pl_represent_acionado2 ?? null;
                nota.IdPlRepresAcionado3Fk = telaVM.id_pl_represent_acionado3 ?? null;
                nota.IdPlRepresAcionado4Fk = telaVM.id_pl_represent_acionado4 ?? null;
                nota.IdCentroTrabalhoFk = telaVM.id_ct_trabalho;

                nota.IdNotificadorFk = telaVM.id_notificador_fk;
                nota.DtHoraNota = DateTime.Now;
                nota.IdStCopeseFk = 1;

                TipoNota tipoNota = new TipoNotaServices().GetByCodigoSap(TipoNotaSelecionarType.PC.ToString());
                nota.IdTpNotaFk = tipoNota.IdTpNota.Value;


                if (telaVM.id_nota != null && telaVM.id_nota > 0)
                {
                    nota.IdNota = telaVM.id_nota;

                    notaSalvaService = notaService.Update(nota);
                    ViewBag.SuccessMessage = "Alteração realizada com sucesso.";
                }
                else
                {
                    string cdNtSap = SalvarNotaSap(nota);
                    nota.CdNotaSap = (String.IsNullOrEmpty(cdNtSap) ? DateTime.Now.ToString("ddMMyymmhhss") : cdNtSap);
                    notaSalvaService = notaService.AddCopese(nota);
                    ViewBag.SuccessMessage = String.Format("Inclusão realiza com sucesso. Número da Nota {0}.", notaSalvaService.IdNota);
                }
                if (notaSalvaService != null)
                    telaVM.id_nota = notaSalvaService.IdNota;
            }
            else
            {
                string Message = "Campo(s) obrigatório(s) não preenchido(s). Verifique.";
                ViewBag.ErrorMessage = Message;
            }


            return View("~/Views/CopesePericia/NotaCopeseEFMR.cshtml", telaVM);
        }

        /// <summary>
        /// Cancelar metodo da Controller responsavel por cancelar a nota fiscal.
        /// </summary>
        /// 
        [Route("Cancelar")]
        public ActionResult Cancelar(NotaCopeseEFMRViewModel telaVM)
        {
            BuscarDadosCopese(telaVM);
            telaVM.Operacao = OperacaoType.Cancelar;
            return View("~/Views/CopesePericia/ConsultarNotaCopeseMR.cshtml", telaVM);
        }

        /// <summary>
        /// Cancelar metodo da Controller responsavel por cancelar a nota fiscal.
        /// </summary>
        /// 
        [Route("SalvarCancelar")]
        public ActionResult SalvarCancelar(int id)
        {
            NotaServices notaService = new NotaServices();
            Nota notaSalvaService = new Nota();
            Nota nota = notaService.GetById(id);
            notaSalvaService = notaService.EncerrarCopese(nota);
            string message = notaSalvaService.BaseModel.MensagemUsuario;
            message = "COPESE cancelada e encerrada com sucesso";
            return Json(new { id = id, operacao = (int)OperacaoType.Cancelar, message = message }, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Encerrar da nota (criacao e edicao)
        /// </summary>
        /// 
        [Route("EncerrarCopeseMR")]
        public ActionResult EncerrarCopeseMR(int id)
        {
            NotaCopeseEFMRViewModel telaVM = BuscarDadosCopese(id);
            telaVM.Operacao = OperacaoType.Encerrar;
            return View("~/Views/CopesePericia/NotaCopeseEFMR.cshtml", telaVM);
        }
        /// <summary>
        /// Encerrar da nota (criacao e edicao)
        /// </summary>
        /// 
        [Route("SalvarEncerrarCopeseMR")]
        public JsonResult SalvarEncerrarCopeseMR(int id)
        {
            NotaServices notaService = new NotaServices();
            Nota notaSalvaService = new Nota();
            Nota nota = notaService.GetById(id);
            notaSalvaService = notaService.EncerrarCopese(nota);
            string message = notaSalvaService.BaseModel.MensagemUsuario;
            message = "Rotina de Encerrar Copese sem regra de negocio definida";
            //return RedirectToAction("NotaCopeseEFMR", new { id = id, operacao = (int)OperacaoType.Encerrar, message = message });
            //return View("~/Views/CopesePericia/NotaCopeseEFMR.cshtml", new { id = id, operacao = (int)OperacaoType.Encerrar, message = message });
            return Json(new { id = id, operacao = (int)OperacaoType.Encerrar, message = message }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Encerrar da nota (criacao e edicao)
        /// </summary>
        /// 
        [Route("Descaracterizar")]
        public ActionResult Descaracterizar(int id)
        {
            NotaCopeseEFMRViewModel telaVM = BuscarDadosCopese(id);
            telaVM.Operacao = OperacaoType.Descaracterizar;
            return View("~/Views/CopesePericia/NotaCopeseEFMR.cshtml", telaVM);
        }

        /// <summary>
        /// Encerrar da nota (criacao e edicao)
        /// </summary>
        /// 
        [Route("SalvarDescaracterizar")]
        public ActionResult SalvarDescaracterizar(int id)
        {
            NotaServices notaService = new NotaServices();
            Nota notaSalvaService = new Nota();
            Nota nota = notaService.GetById(id);
            notaSalvaService = notaService.EncerrarCopese(nota);
            string message = notaSalvaService.BaseModel.MensagemUsuario;
            message = "COPESE descaracterizada e encerrada com sucesso";
            return Json(new { id = id, operacao = (int)OperacaoType.Descaracterizar, message = message }, JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// Busca Nota de Referencia para sugerir digitacao
        /// </summary>
        /// 
        [Route("BuscarNotaRefLcInst")]
        public JsonResult BuscarNotaRefLcInst(string nr_nota_sap)
        {
            Nota nota = new Nota();

            if (!string.IsNullOrEmpty(nr_nota_sap))
            {

                nota = new NotaServices().GetNotasCodigoSapMRRef(nr_nota_sap);

                if (nota.LocalInstalacao != null)
                {

                    if (nota.LocalInstalacao.IdLinhaFk != null)
                        nota.LocalInstalacao.Linha = new LinhaServices().GetById(nota.LocalInstalacao.IdLinhaFk.Value);

                    if (nota.IdNotificadorFk != null)
                        nota.Empregado = new EmpregadoServices().GetById(nota.IdNotificadorFk.Value);
                }
            }

            return Json(nota, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);

        }
        private void BuscarDadosCopese(NotaCopeseEFMRViewModel telaVM)
        {
            BuscarDadosCopese(telaVM.id_nota.Value);
        }
        private NotaCopeseEFMRViewModel BuscarDadosCopese(int id)
        {
            NotaCopeseEFMRViewModel telaVM = new NotaCopeseEFMRViewModel();

            telaVM.Operacao = OperacaoType.Consultar;

            telaVM.SelecionarCimAcionado = base.CarregaDropDownList(ServicoType.CimAcionado);

            NotaServices notaService = new NotaServices();
            Nota nota = new Nota();


            nota = notaService.GetById(id);
            telaVM.id_nota = nota.IdNota.Value;

            if (nota.IdNotaReferenciaFk != null)
                nota.NotaReferencia = notaService.GetById(nota.IdNotaReferenciaFk.Value);

            telaVM.cd_nota_sap = nota.CdNotaSap;
            if (nota.DtHoraNota != null)
                telaVM.dt_hora_nota = nota.DtHoraNota.Value;

            if (nota.NotaReferencia != null)
            {
                telaVM.cd_nota_sap_Ref = nota.NotaReferencia.CdNotaSap;
                if (nota.NotaReferencia.DtHoraNota != null)
                    telaVM.dt_hora_nota_Ref = nota.NotaReferencia.DtHoraNota.Value;
            }

            telaVM.nm_st_copese = new StatusCopeseServices().GetAll().ToList().Find(s => s.IdStCopese == nota.IdStCopeseFk).DsStCopese;

            if (nota.IdLocalInstFk != null)
            {
                nota.LocalInstalacao = new LocalInstalacaoServices().GetById(nota.IdLocalInstFk.Value);
                telaVM.ds_local_inst_Ref = nota.LocalInstalacao.DsLcInstalacao;
                telaVM.cd_local_inst_sap_Ref = nota.LocalInstalacao.DsLcInstalacao;
                telaVM.id_local_inst_Ref = nota.LocalInstalacao.IdLcInstalacao.Value;

                if (nota.LocalInstalacao.IdFrotaFk > 0)
                {
                    Frota frota = new FrotaServices().GetById(nota.LocalInstalacao.IdFrotaFk.Value);
                    telaVM.nm_frota = frota.NmFrota;
                }

                if (nota.LocalInstalacao.IdTremFk > 0)
                {
                    Trem trem = new TremServices().GetById(nota.LocalInstalacao.IdTremFk.Value);
                    telaVM.nm_trem = trem.NmTrem;
                }

                if (nota.LocalInstalacao.IdCarroFk > 0)
                {
                    Carro carro = new CarroServices().GetById(nota.LocalInstalacao.IdCarroFk.Value);
                    telaVM.nm_carro = carro.NmCarro;
                }

                if (nota.LocalInstalacao.IdSistemaFk > 0)
                {
                    Sistema sistema = new SistemaServices().GetById(nota.LocalInstalacao.IdSistemaFk.Value);
                    telaVM.nm_sistema = sistema.NmSistema;
                }

                if (nota.LocalInstalacao.IdLinhaFk > 0)
                {
                    Linha linha = new LinhaServices().GetById(nota.LocalInstalacao.IdLinhaFk.Value);
                    telaVM.nm_linha = linha.NmLinha;
                }

            }

            if (nota.IdCentroTrabalhoFk > 0)
            {
                CentroTrabalho centroTrabalho = new CentroTrabalhoServices().GetById(nota.IdCentroTrabalhoFk);
                telaVM.ds_ct_trabalho = centroTrabalho.DsCtTrabalho;
            }

            telaVM.ds_descricao_Ref = nota.DsDescricao;

            if (nota.IdCodeSintomaFk != null)
            {
                nota.CodeSintoma = new SintomaServices().GetAll().Where(s => s.IdCode == nota.IdCodeSintomaFk.Value).First();
                if (nota.CodeSintoma != null)
                {
                    telaVM.nm_sintoma = nota.CodeSintoma.DsCode;
                    telaVM.ds_breve_code_Ref = nota.CodeSintoma.DsCode;
                    telaVM.id_code_Ref = nota.CodeSintoma.IdCode.Value;
                }
            }

            telaVM.ds_observacao = nota.DsObservacao;

            Empregado empregado = (nota.IdNotificadorFk != null) ? new EmpregadoServices().GetById(nota.IdNotificadorFk.Value) : null;
            if (empregado != null)
            {
                telaVM.id_notificador_fk = empregado.IdEmpregado.Value;
                telaVM.rg_notificador = empregado.RgEmpregado;
            }

            Empregado pnAcionado = (nota.IdPnAcionadoFk != null) ? new EmpregadoServices().GetById(nota.IdPnAcionadoFk.Value) : null;
            if (pnAcionado != null)
            {

                telaVM.id_plantonista_acionado = pnAcionado.IdEmpregado.Value;
                telaVM.nm_plantonista_acionado = pnAcionado.RgEmpregado;
            }

            CentroTrabalho ciAcionado = (nota.IdCiAcionadoFk != null) ? new CentroTrabalhoServices().GetById(nota.IdCiAcionadoFk.Value) : null;

            if (ciAcionado != null)
            {
                telaVM.id_cim_acionado = ciAcionado.IdCtTrabalho.Value;
                telaVM.nm_cim_acionado = ciAcionado.DsCtTrabalho;
            }

            Empregado plAcionado1 = (nota.IdPlRepresAcionadoFk != null) ? new EmpregadoServices().GetById(nota.IdPlRepresAcionadoFk.Value) : null;
            if (plAcionado1 != null)
            {
                telaVM.id_pl_represent_acionado1 = plAcionado1.IdEmpregado.Value;
                telaVM.nm_pl_represent_acionado1 = plAcionado1.RgEmpregado;
            }
            Empregado plAcionado2 = (nota.IdPlRepresAcionado2Fk != null) ? new EmpregadoServices().GetById(nota.IdPlRepresAcionado2Fk.Value) : null;
            if (plAcionado2 != null)
            {
                telaVM.id_pl_represent_acionado2 = plAcionado2.IdEmpregado.Value;
                telaVM.nm_pl_represent_acionado2 = plAcionado2.RgEmpregado;
            }
            Empregado plAcionado3 = (nota.IdPlRepresAcionado3Fk != null) ? new EmpregadoServices().GetById(nota.IdPlRepresAcionado3Fk.Value) : null;
            if (plAcionado3 != null)
            {
                telaVM.id_pl_represent_acionado3 = plAcionado3.IdEmpregado.Value;
                telaVM.nm_pl_represent_acionado3 = plAcionado3.RgEmpregado;
            }
            Empregado plAcionado4 = (nota.IdPlRepresAcionado4Fk != null) ? new EmpregadoServices().GetById(nota.IdPlRepresAcionado4Fk.Value) : null;
            if (plAcionado4 != null)
            {
                telaVM.id_pl_represent_acionado4 = plAcionado4.IdEmpregado.Value;
                telaVM.nm_pl_represent_acionado4 = plAcionado4.RgEmpregado;
            }

            return telaVM;
        }

        private string SalvarNotaSap(Nota nota)
        {
            string retorno = string.Empty;

            try
            {
                //PM.IntegradorSAP.Model.ModelPericiaCopese modelPericiaCopese = new IntegradorSAP.Model.ModelPericiaCopese();
                //PM.IntegradorSAP.Model.ModelPericiaCopeseAtividade modelPericiaCopeseAtividade = new IntegradorSAP.Model.ModelPericiaCopeseAtividade();
                //PM.IntegradorSAP.Model.ModelPericiaCopeseCausa modelPericiaCopeseCausa = new IntegradorSAP.Model.ModelPericiaCopeseCausa();
                //PM.IntegradorSAP.Model.ModelPericiaCopeseMedida modelPericiaCopeseMedida = new IntegradorSAP.Model.ModelPericiaCopeseMedida();
                //PM.IntegradorSAP.PericiaCopese oPericiaCopese = new IntegradorSAP.PericiaCopese();
                //List<PM.IntegradorSAP.Helper.Resposta> respostaPericiaCopese;



                //modelPericiaCopeseMedida.CodMedidas = "1";
                //modelPericiaCopeseMedida.DataMedida = "1";
                //modelPericiaCopeseMedida.DataProgramanda = "1";
                //modelPericiaCopeseMedida.FuncResposavel = "1";
                //modelPericiaCopeseMedida.GrpCodMedidas = "1";
                //modelPericiaCopeseMedida.HoraMedida = "1";
                //modelPericiaCopeseMedida.HoraProgramada = "1";
                //modelPericiaCopeseMedida.ItemMedia = "1";
                //modelPericiaCopeseMedida.Responsavel = "1";
                //modelPericiaCopeseMedida.RGLogado = "1";
                //modelPericiaCopeseMedida.StatusMedida = "1";

                //modelPericiaCopese.Medida = new List<IntegradorSAP.Model.ModelPericiaCopeseMedida>();
                //modelPericiaCopese.Medida.Add(modelPericiaCopeseMedida);

                //modelPericiaCopeseAtividade.CodAtividades = "";
                //modelPericiaCopese.Atividade = new List<IntegradorSAP.Model.ModelPericiaCopeseAtividade>();
                //modelPericiaCopese.Atividade.Add(modelPericiaCopeseAtividade);

                //modelPericiaCopese.Causa = new List<IntegradorSAP.Model.ModelPericiaCopeseCausa>();
                //modelPericiaCopese.Causa.Add(modelPericiaCopeseCausa);

                //modelPericiaCopese.Code = nota.IdCodeSintomaFk.Value.ToString();
                //modelPericiaCopese.Descricao = nota.DsDescricao;
                //modelPericiaCopese.GrpCode = "1";
                //modelPericiaCopese.LocInstalacao = nota.IdLocalInstFk.Value.ToString();


                //modelPericiaCopese.NotaReferencia = nota.IdNotaReferenciaFk.Value.ToString();
                //modelPericiaCopese.Notificador = nota.IdNotificadorFk.Value.ToString();
                //modelPericiaCopese.Observacao = nota.DsObservacao;
                //modelPericiaCopese.StatusNota = (nota.IdStCopeseFk != null) ? nota.IdStCopeseFk.Value.ToString() : "1";
                //modelPericiaCopese.StatusUsuario = (nota.IdStSistemaFk != null) ? nota.IdStSistemaFk.Value.ToString() : "1";
                //modelPericiaCopese.TipoNota = "PC";


                //respostaPericiaCopese = oPericiaCopese.CriacaoNota("DESENVOLVIMENTO", modelPericiaCopese);
                //foreach (PM.IntegradorSAP.Helper.Resposta item in respostaPericiaCopese)
                //{
                //    if (item._status == true)
                //    {
                //        retorno = item._codMensagem;
                //    }
                //}
            }
            catch
            {
                return retorno;
            }
            return retorno;

        }

    }
}
