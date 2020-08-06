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

namespace PM.Web.Controllers
{
    /// <summary>
    /// NotaOCOPOLs Controller responsavel pelas ações e trocas de dados de Front e Back.
    /// </summary>
    /// 
    [RoutePrefix("Oficina2")]
    public class NotaOCOPOLsController : BaseController
    {
        [Route("GetListaTarefas")]
        [HttpPost]
        public ActionResult GetListaTarefas(int id_equipamento)
        {
            NotaOCOPOLViewModel telaVM = new NotaOCOPOLViewModel();
            List<ListaTarefa> retorno = new ListaTarefaServices().GetByEquipamentoid(id_equipamento);
            List<ListaTarefaViewModel> grid = new List<ListaTarefaViewModel>();

            retorno.ForEach(i => grid.Add(new ListaTarefaViewModel
            {
                id_lt_tarefa = i.IdLtTarefa.Value,
                Selecionar = false,
                cd_gp_lt_tarefa = i.CdGpLtTarefa,
                cd_sap = i.CdSap,
                ds_lt_tarefa = i.DsLtTarefa

            }));

            telaVM.GridListaTarefas = grid;

            return PartialView("~/Views/oficina/_GetListaTarefas.cshtml", telaVM);
        }

        [Route("GetListaTarefaMaterial")]
        [HttpPost]
        public ActionResult GetListaTarefaMaterial(string listaTarefaSelecionar, string listaTarefaMaterialSelecionar)
        {
            NotaOCOPOLViewModel telaVM = new NotaOCOPOLViewModel();
            List<ListaTarefaOperacaoComponente> retorno;
            List<ListaTarefaMaterialViewModel> grid = new List<ListaTarefaMaterialViewModel>();

            //Varre lista da Lista de Tarefas buscando os selecionados
            foreach (var item in listaTarefaSelecionar.Split('|'))
            {
                var selecionados = item.Split('-');

                if (selecionados[0] != "" && selecionados[1].Substring(0, 4) == "true")
                {
                    retorno = new ListaTarefaOperacaoComponenteServices().GetByid_lt_tarefa(int.Parse(selecionados[0]));
                    grid = new List<ListaTarefaMaterialViewModel>();

                    retorno.ForEach(i => grid.Add(new ListaTarefaMaterialViewModel
                    {
                        //cd_sap = i.ListaTarefas.CdSap,
                        cd_operacao = "", //i.Operacao.CdOperacao,
                        cd_material_antigo = "", //i.Material.CdMaterialAntigo,
                        ds_material = "", //i.Material.DsMaterial,
                        nr_quantidade = i.NrQuantidade.Value,
                        ds_unidade_medida = "PC",
                        Selecionar = listaTarefaMaterialSelecionar.IndexOf(i.IdLtTarOpComp.ToString() + "-true") >= 0 ? true : false,
                        id_lt_tar_op_comp = i.IdLtTarOpComp.Value,
                        id_lt_tarefa_fk = 3, //i.ListaTarefas.IdLtTarefa.Value,
                        id_operacao_fk = 1,
                        id_material_fk = 1, //i.IdMaterialFk,
                        id_un_duracao_fk = 1
                    }));
                    telaVM.GridListaTarefaMateriais.AddRange(grid);
                }
            }

            return PartialView("~/Views/oficina/_GetListaTarefaMateriais.cshtml", telaVM);
        }

        /// <summary>
        /// Chamada da criacao da nota
        /// </summary>
        /// 
        [Route("CriarNotaOCOPOL")]
        public ActionResult CriarNotaOCOPOL()
        {
            NotaOCOPOLViewModel telaVM = new NotaOCOPOLViewModel();

            #region  Carrega DropDownlists

            telaVM.SelecionarTipoNota = base.CarregaDropDownList(ServicoType.TipoNota);
            telaVM.SelecionarPrioridade = base.CarregaDropDownList(ServicoType.Prioridade);
            telaVM.SelecionarElementoPEP = base.CarregaDropDownList(ServicoType.ElementoPEP);
            telaVM.SelecionarEquipamento = base.CarregaDropDownList(ServicoType.Equipamento);
            //telaVM.SelecionarCentroTrabalho = base.CarregaDropDownList(ServicoType.CentroTrabalho);
            telaVM.SelecionarMaterial = base.CarregaDropDownList(ServicoType.Material);

            #endregion

            ViewBag.Action = "Criar";
            telaVM.GridListaTarefas = new List<ListaTarefaViewModel>();

            //var listaTarefas = new ListaTarefaServices().GetAll().ToList();
            //listaTarefas.ForEach(n =>
            //{
            //telaVM.GridListaTarefas.Add(new ListaTarefaViewModel
            //{
            //    Selecionar = false,
            //    id_lt_tarefa = n.IdLtTarefa.Value,
            //        cd_gp_lt_tarefa = n.CdGpLtTarefa,
            //        cd_sap = n.CdSap,
            //        ds_lt_tarefa = n.DsLtTarefa,
            //        cd_equipamento_fk = n.CdEquipamentoFk
            //    });
            //});



            //var materiais = new MaterialServices().GetAll();
            //telaVM.GridMateriais = materiais.ToList();

            //ViewBag.Message = "";

            //if (!string.IsNullOrEmpty(message))
            //{
            //    ViewBag.Message = message;
            //}

            return View("~/Views/oficina/NotaOCOPOL.cshtml", telaVM);
        }

        /// <summary>
        /// Chamada da criacao da nota
        /// </summary>
        /// 
        [Route("EquipamentoListaMateriais")]
        public ActionResult EquipamentoListaMateriais(NotaOCOPOLViewModel telaVM)
        {
            telaVM.SelecionarTipoNota = base.CarregaDropDownList(ServicoType.TipoNota);
            telaVM.SelecionarPrioridade = base.CarregaDropDownList(ServicoType.Prioridade);
            telaVM.SelecionarElementoPEP = base.CarregaDropDownList(ServicoType.ElementoPEP);
            telaVM.SelecionarEquipamento = base.CarregaDropDownList(ServicoType.Equipamento);
            telaVM.SelecionarMaterial = base.CarregaDropDownList(ServicoType.Material);

            //ViewBag.Action = "Criar";
            telaVM.GridListaTarefas = new List<ListaTarefaViewModel>();

            var listaTarefas = new ListaTarefaServices().GetAll().ToList();
            listaTarefas.ForEach(n =>
            {
                telaVM.GridListaTarefas.Add(new ListaTarefaViewModel
                {
                    Selecionar = false,
                    id_lt_tarefa = n.IdLtTarefa.Value,
                    cd_gp_lt_tarefa = n.CdGpLtTarefa,
                    cd_sap = n.CdSap,
                    ds_lt_tarefa = n.DsLtTarefa,
                    cd_equipamento_fk = n.CdEquipamentoFk
                });
            });


            //var materiais = new MaterialServices().GetAll();
            //telaVM.GridMateriais = materiais.ToList();

            //ViewBag.Message = "";

            //if (!string.IsNullOrEmpty(message))
            //{
            //    ViewBag.Message = message;
            //}

            return View("~/Views/oficina/NotaOCOPOL.cshtml", telaVM);
        }


        /// <summary>
        /// Chamada da alteracao da nota
        /// </summary>
        /// 
        [Route("EditarNotaOCOPOL")]
        public ActionResult EditarNotaOCOPOL(int id)
        {
            NotaOCOPOLViewModel telaVM = new NotaOCOPOLViewModel();

            NotaServices notaService = new NotaServices();
            Nota nota = new Nota();

            ViewBag.Action = "Editar";

            nota = notaService.GetById(id);

            telaVM.id_st_sistema_fk = 1;                        //inicia com aberta (verificando qual vai ser o valor)
            telaVM.id_un_medid_tempo_prev_fk = 1;
            telaVM.id_st_pericia_fk = 1;
            telaVM.id_ev_gerador_fk = 1;
            telaVM.id_diagnostico_fk = 1;
            telaVM.di_marco_inicial = 1;
            telaVM.co_comprimento = 1;
            telaVM.if_oper_maior_cinco_min = false;
            telaVM.in_notavel = false;
            telaVM.in_fumaca = false;
            telaVM.tm_previsto = 1;
            telaVM.nr_contrato = 1;
            telaVM.fk_nota_vinculo = 1;

            telaVM.cd_tp_nota_sap = nota.CdNotaSap;
            telaVM.id_nota_Ref = !nota.IdNotaReferenciaFk.HasValue ? 0 : nota.IdNotaReferenciaFk.Value;

            telaVM.id_nota = nota.IdNota;
            telaVM.id_tp_nota = nota.IdTpNotaFk;
            telaVM.ds_descricao = nota.DsDescricao;

            //telaVM.id_local_inst_Ref = nota.IdLocalInstPrincFk;                         //nao obrigatorio
            //telaVM.id_st_sistema_fk = nota.IdStSistemaFk.Value;                         //inicia aberta
            //telaVM.id_un_medid_tempo_prev_fk = nota.IdUnMedidTempoPrevFk.Value;         //nao obrigatorio
            //telaVM.id_st_pericia_fk = nota.IdStPericiaFk.Value;                         //nao obrigatorio
            //telaVM.id_ev_gerador_fk = nota.IdEvGeradorFk.Value;                         //nao obrigatorio
            //telaVM.id_diagnostico_fk = nota.IdDiagnosticoFk.Value;                      //nao obrigatorio
            //telaVM.di_marco_inicial = nota.DiMarcoInicial.Value;                      //nao obrigatorio
            //telaVM.co_comprimento = nota.CoComprimento.Value;                           //nao obrigatorio
            //telaVM.if_oper_maior_cinco_min = !nota.IfOperMaiorCincoMin.HasValue ? false : nota.IfOperMaiorCincoMin.Value;                 //nao obrigatorio
            //telaVM.in_notavel = !nota.InNotavel.HasValue ? false : nota.InNotavel.Value;                                         //nao obrigatorio
            //telaVM.in_fumaca = !nota.InFumaca.HasValue ? false : nota.InFumaca.Value;                                           //nao obrigatorio
            //telaVM.tm_previsto = nota.TmPrevisto.Value;                                       //nao obrigatorio
            //telaVM.nr_contrato = nota.NrContrato.Value;                                       //nao obrigatorio
            //telaVM.fk_nota_vinculo = !nota.FkNotaVinculo.HasValue ? 0 : nota.FkNotaVinculo.Value;                                //nao obrigatorio

            //telaVM.dt = nota.DtHoraNota = DateTime.Now;

            //telaVM.id_code_Ref = !nota.IdCodeSintomaFk.HasValue ? 0 : nota.IdCodeSintomaFk.Value;
            telaVM.id_prioridade = !nota.IdPrioridadeFk.HasValue ? 0 : nota.IdPrioridadeFk.Value;
            //telaVM.eq_etiqueta = nota.EqEtiqueta;
            telaVM.ds_observacao = nota.DsObservacao;
            telaVM.id_elemento_pep = !nota.IdElementoPepFk.HasValue ? 0 : nota.IdElementoPepFk.Value;
            telaVM.id_equipamento = !nota.IdEquipamentoFk.HasValue ? 0 : nota.IdEquipamentoFk.Value;
            telaVM.id_material = !nota.IdMaterialFk.HasValue ? 0 : nota.IdMaterialFk.Value;
            //telaVM.Qt_Lote = nota.QtLote;
            telaVM.id_ct_trabalho = int.Parse( nota.IdCentroTrabalhoFk.ToString());

            #region Carregar Dados da Nota de Referencia 

            var notaRef = new NotaServices().GetById(telaVM.id_nota_Ref);
            telaVM.id_nota_Ref = notaRef.IdNota.Value;
            //telaVM.cd_tp_nota_sap_Ref = notaRef.TipoNota.ArTpNota;
            telaVM.cd_tp_nota_sap_Ref = notaRef.TipoNota.CdSap;
            telaVM.ds_descricao_Ref = notaRef.DsDescricao;
            telaVM.id_local_inst_Ref = notaRef.LocalInstalacao.IdLcInstalacao.Value;
            //telaVM.id_local_inst_Ref = notaRef.LocalInstalacao.IdLocalInst.Value;
            telaVM.cd_local_inst_sap_Ref = notaRef.LocalInstalacao.CdSap;
            //telaVM.cd_local_inst_sap_Ref = notaRef.LocalInstalacao.CdLocalInstSap;
            telaVM.ds_observacao_Ref = notaRef.DsObservacao;
            //telaVM.ds_local_inst_Ref = notaRef.LocalInstalacao.DsLcInst;
            //telaVM.ds_breve_code_Ref = notaRef.CodeSintoma.DsBreveCode;
            telaVM.ds_local_inst_Ref = notaRef.LocalInstalacao.DsLcInstalacao;
            telaVM.ds_breve_code_Ref = notaRef.CodeSintoma.DsCode;
            telaVM.id_code_Ref = notaRef.CodeSintoma.IdCode.Value;
            //telaVM.dt_hora_nota_Ref = notaRef.dt_hora_nota_Ref;
            //telaVM.DataEncerramentoRef = notaRef.DataEncerramentoRef;
            telaVM.ds_breve_CentroTrabalho_Ref = notaRef.CentroTrabalho.DsCtTrabalho;
            //telaVM.ds_breve_CentroTrabalho_Ref = notaRef.CentroTrabalho.DsBreve;

            #endregion

            #region Carregar Dados do Elemento PEP

            var elementoPEP = new ElementoPEPServices().GetById(telaVM.id_elemento_pep);
            telaVM.ds_elemento_pep = elementoPEP.DsElementoPep;

            #endregion

            #region Carregar Dados do Equipamento

            var equipamento = new EquipamentoServices().GetById(telaVM.id_equipamento);

            telaVM.nr_serie_fabricante = equipamento.NrSerieFabricante;
            //telaVM.ds_objeto_tecnico = equipamento.DsObjetoTecnico;
            //telaVM.nr_identificacao_tecnica = equipamento.NrIdentificacaoTecnica;
            telaVM.ds_objeto_tecnico = equipamento.DsEquipamento;
            telaVM.nr_identificacao_tecnica = equipamento.NrIdentifTecnica;
            //telaVM.nr_inventario = equipamento.NrInventario;


            #endregion

            #region Carregar Dados do Material

            var material = new MaterialServices().GetById(telaVM.id_material);
            //telaVM.ds_objeto_tecnico = equipamento.DsEquipamento;
            //telaVM.ds_objeto_tecnico = equipamento.DsObjetoTecnico;

            telaVM.ds_material = material.DsMaterial;

            #endregion

            #region  Carrega DropDownlists

            telaVM.SelecionarTipoNota = base.CarregaDropDownList(ServicoType.TipoNota, telaVM.id_tp_nota);
            telaVM.SelecionarPrioridade = base.CarregaDropDownList(ServicoType.Prioridade, telaVM.id_prioridade);
            telaVM.SelecionarElementoPEP = base.CarregaDropDownList(ServicoType.ElementoPEP, telaVM.id_elemento_pep);
            telaVM.SelecionarEquipamento = base.CarregaDropDownList(ServicoType.Equipamento, telaVM.id_equipamento);
            telaVM.SelecionarCentroTrabalho = base.CarregaDropDownList(ServicoType.CentroTrabalho, telaVM.id_ct_trabalho);

            #endregion

            //var tarefas = new TarefaServices().GetAll();
            //telaVM.GridTarefas = tarefas.ToList();

            //var materiais = new MaterialServices().GetAll();
            //telaVM.GridMateriais = materiais.ToList();

            //ViewBag.Message = "";

            //if (!string.IsNullOrEmpty(message))
            //{
            //    ViewBag.Message = message;
            //}

            return View("~/Views/oficina/NotaOCOPOL.cshtml", telaVM);
        }

        /// <summary>
        /// Chamada da consulta da nota
        /// </summary>
        /// 
        [Route("ConsultarNotaOCOPOL")]
        public ActionResult ConsultarNotaOCOPOL(int id)
        {
            NotaOCOPOLViewModel telaVM = new NotaOCOPOLViewModel();

            NotaServices notaService = new NotaServices();
            Nota nota = new Nota();

            ViewBag.Action = "Consultar";
            nota = notaService.GetById(id);

            telaVM.id_st_sistema_fk = 1;                        //inicia com aberta (verificando qual vai ser o valor)
            telaVM.id_un_medid_tempo_prev_fk = 1;
            telaVM.id_st_pericia_fk = 1;
            telaVM.id_ev_gerador_fk = 1;
            telaVM.id_diagnostico_fk = 1;
            telaVM.di_marco_inicial = 1;
            telaVM.co_comprimento = 1;
            telaVM.if_oper_maior_cinco_min = false;
            telaVM.in_notavel = false;
            telaVM.in_fumaca = false;
            telaVM.tm_previsto = 1;
            telaVM.nr_contrato = 1;
            telaVM.fk_nota_vinculo = 1;

            telaVM.cd_tp_nota_sap = nota.CdNotaSap;
            telaVM.id_nota_Ref = !nota.IdNotaReferenciaFk.HasValue ? 0 : nota.IdNotaReferenciaFk.Value;

            telaVM.id_nota = nota.IdNota;
            telaVM.id_tp_nota = nota.IdTpNotaFk;
            telaVM.ds_descricao = nota.DsDescricao;

            //telaVM.id_local_inst_Ref = nota.IdLocalInstPrincFk;                         //nao obrigatorio
            //telaVM.id_st_sistema_fk = nota.IdStSistemaFk.Value;                         //inicia aberta
            //telaVM.id_un_medid_tempo_prev_fk = nota.IdUnMedidTempoPrevFk.Value;         //nao obrigatorio
            //telaVM.id_st_pericia_fk = nota.IdStPericiaFk.Value;                         //nao obrigatorio
            //telaVM.id_ev_gerador_fk = nota.IdEvGeradorFk.Value;                         //nao obrigatorio
            //telaVM.id_diagnostico_fk = nota.IdDiagnosticoFk.Value;                      //nao obrigatorio
            //telaVM.di_marco_inicial = nota.DiMarcoInicial.Value;                      //nao obrigatorio
            //telaVM.co_comprimento = nota.CoComprimento.Value;                           //nao obrigatorio
            //telaVM.if_oper_maior_cinco_min = !nota.IfOperMaiorCincoMin.HasValue ? false : nota.IfOperMaiorCincoMin.Value;                 //nao obrigatorio
            //telaVM.in_notavel = !nota.InNotavel.HasValue ? false : nota.InNotavel.Value;                                         //nao obrigatorio
            //telaVM.in_fumaca = !nota.InFumaca.HasValue ? false : nota.InFumaca.Value;                                           //nao obrigatorio
            //telaVM.tm_previsto = nota.TmPrevisto.Value;                                       //nao obrigatorio
            //telaVM.nr_contrato = nota.NrContrato.Value;                                       //nao obrigatorio
            //telaVM.fk_nota_vinculo = !nota.FkNotaVinculo.HasValue ? 0 : nota.FkNotaVinculo.Value;                                //nao obrigatorio

            //telaVM.dt = nota.DtHoraNota = DateTime.Now;

            //telaVM.id_code_Ref = !nota.IdCodeSintomaFk.HasValue ? 0 : nota.IdCodeSintomaFk.Value;
            telaVM.id_prioridade = !nota.IdPrioridadeFk.HasValue ? 0 : nota.IdPrioridadeFk.Value;
            //telaVM.eq_etiqueta = nota.EqEtiqueta;
            telaVM.ds_observacao = nota.DsObservacao;
            telaVM.id_elemento_pep = !nota.IdElementoPepFk.HasValue ? 0 : nota.IdElementoPepFk.Value;
            telaVM.id_equipamento = !nota.IdEquipamentoFk.HasValue ? 0 : nota.IdEquipamentoFk.Value;
            telaVM.id_material = !nota.IdMaterialFk.HasValue ? 0 : nota.IdMaterialFk.Value;
            //telaVM.Qt_Lote = nota.QtLote;
            telaVM.id_ct_trabalho = int.Parse(nota.IdCentroTrabalhoFk.ToString());

            #region Carregar Dados da Nota de Referencia 

            var notaRef = new NotaServices().GetById(telaVM.id_nota_Ref);
            telaVM.id_nota_Ref = notaRef.IdNota.Value;
            telaVM.cd_tp_nota_sap_Ref = notaRef.TipoNota.DsTpNota;
            //telaVM.cd_tp_nota_sap_Ref = notaRef.TipoNota.ArTpNota;
            telaVM.ds_descricao_Ref = notaRef.DsDescricao;
            //telaVM.id_local_inst_Ref = notaRef.LocalInstalacao.IdLocalInst.Value;
            //telaVM.cd_local_inst_sap_Ref = notaRef.LocalInstalacao.CdLocalInstSap;
            telaVM.id_local_inst_Ref = notaRef.LocalInstalacao.IdLcInstalacao.Value;
            telaVM.cd_local_inst_sap_Ref = notaRef.LocalInstalacao.CdSap;
            telaVM.ds_observacao_Ref = notaRef.DsObservacao;
            //telaVM.ds_local_inst_Ref = notaRef.LocalInstalacao.DsLcInst;
            //telaVM.ds_breve_code_Ref = notaRef.CodeSintoma.DsBreveCode;
            telaVM.ds_local_inst_Ref = notaRef.LocalInstalacao.DsLcInstalacao;
            telaVM.ds_breve_code_Ref = notaRef.CodeSintoma.DsCode;
            telaVM.id_code_Ref = notaRef.CodeSintoma.IdCode.Value;
            //telaVM.dt_hora_nota_Ref = notaRef.dt_hora_nota_Ref;
            //telaVM.DataEncerramentoRef = notaRef.DataEncerramentoRef;
            telaVM.ds_breve_CentroTrabalho_Ref = notaRef.CentroTrabalho.DsCtTrabalho;
            //telaVM.ds_breve_CentroTrabalho_Ref = notaRef.CentroTrabalho.DsBreve;

            #endregion

            #region Carregar Dados do Elemento PEP

            var elementoPEP = new ElementoPEPServices().GetById(telaVM.id_elemento_pep);
            telaVM.ds_elemento_pep = elementoPEP.DsElementoPep;

            #endregion

            #region Carregar Dados do Equipamento

            var equipamento = new EquipamentoServices().GetById(telaVM.id_equipamento);

            telaVM.nr_serie_fabricante = equipamento.NrSerieFabricante;
            //telaVM.ds_objeto_tecnico = equipamento.DsObjetoTecnico;
            //telaVM.nr_identificacao_tecnica = equipamento.NrIdentificacaoTecnica;
            //telaVM.nr_inventario = equipamento.NrInventario;
            telaVM.ds_objeto_tecnico = equipamento.DsEquipamento;
            telaVM.nr_identificacao_tecnica = equipamento.NrIdentifTecnica;


            #endregion

            #region Carregar Dados do Material

            var material = new MaterialServices().GetById(telaVM.id_material);
            //telaVM.ds_objeto_tecnico = equipamento.DsObjetoTecnico;
            telaVM.ds_objeto_tecnico = equipamento.DsEquipamento;

            telaVM.ds_material = material.DsMaterial;

            #endregion

            #region  Carrega DropDownlists

            telaVM.SelecionarTipoNota = base.CarregaDropDownList(ServicoType.TipoNota, telaVM.id_tp_nota);
            telaVM.SelecionarPrioridade = base.CarregaDropDownList(ServicoType.Prioridade, telaVM.id_prioridade);
            telaVM.SelecionarElementoPEP = base.CarregaDropDownList(ServicoType.ElementoPEP, telaVM.id_elemento_pep);
            telaVM.SelecionarEquipamento = base.CarregaDropDownList(ServicoType.Equipamento, telaVM.id_equipamento);
            telaVM.SelecionarCentroTrabalho = base.CarregaDropDownList(ServicoType.CentroTrabalho, telaVM.id_ct_trabalho);

            #endregion

            //var tarefas = new TarefaServices().GetAll();
            //telaVM.GridTarefas = tarefas.ToList();

            //var materiais = new MaterialServices().GetAll();
            //telaVM.GridMateriais = materiais.ToList();

            //ViewBag.Message = "";

            //if (!string.IsNullOrEmpty(message))
            //{
            //    ViewBag.Message = message;
            //}

            return View("~/Views/oficina/NotaOCOPOL.cshtml", telaVM);
        }

        /// <summary>
        /// Gravacao da nota (criacao e edicao)
        /// </summary>
        /// 
        [Route("SalvarNotaOCOPOL")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarNotaOCOPOL(NotaOCOPOLViewModel telaVM)
        {
            //public ActionResult SalvarNotaOCOPOL([Bind(Include = "GridListaTarefas")] NotaOCOPOLViewModel telaVM)
            NotaServices notaService = new NotaServices();
            Nota notaSalvaService = new Nota();

            if (ModelState.IsValid)
            {
                Nota nota = new Nota();

                #region NotaREF
                nota.IdNotaReferenciaFk = (telaVM.id_nota_Ref != 0) ? telaVM.id_nota_Ref : new int?();
                #endregion

                nota.IdTpNotaFk = telaVM.id_tp_nota;
                nota.DsDescricao = telaVM.ds_descricao;
                nota.DsObservacao = telaVM.ds_observacao;
                nota.IdPrioridadeFk = telaVM.id_prioridade;
                //nota.EqEtiqueta = telaVM.eq_etiqueta;
                nota.IdElementoPepFk = telaVM.id_elemento_pep;
                nota.IdEquipamentoFk = telaVM.id_equipamento;
                nota.IdMaterialFk = telaVM.id_material;
                nota.QtLote = telaVM.Qt_Lote;
                nota.IdCentroTrabalhoFk = telaVM.id_ct_trabalho;
                nota.DtHoraNota = DateTime.Now;

                if (telaVM.id_nota != null && telaVM.id_nota > 0)
                {
                    notaSalvaService = notaService.Update(nota);
                }
                else
                {
                    notaSalvaService = notaService.Add(nota);
                }

                if (!notaSalvaService.BaseModel.Erro.Value)
                {
                    //Danger("Ocorreu um erro na gravação da Empresa. Tente novamente mais tarde, se o erro persistir, contate o responável", true);
                }
                else
                {
                    //Success("EmpresaXUsuario incluido com sucesso.", true);
                }
            }

            return View("~/Views/oficina/NotaOCOPOL.cshtml", telaVM);
            //return RedirectToAction("CriarNotaOCOPOL", new { message = notaSalvaService.BaseModel.MensagemUsuario });
        }

        /// <summary>
        /// Busca a Equipamento pelo ID
        /// </summary>
        /// 
        [Route("BuscarListaTarefas")]
        public JsonResult BuscarListaTarefas(int id_equipamento)
        {
            List<ListaTarefa> retorno = new ListaTarefaServices().GetByEquipamentoid(id_equipamento);
            List<ListaTarefaViewModel> result = new List<ListaTarefaViewModel>();

            retorno.ForEach(i => result.Add(new ListaTarefaViewModel
            {
                id_lt_tarefa = i.IdLtTarefa.Value,
                Selecionar = false,
                cd_gp_lt_tarefa = i.CdGpLtTarefa,
                cd_sap = i.CdSap,
                ds_lt_tarefa = i.DsLtTarefa

            }));

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Busca a Equipamento pelo ID
        /// </summary>
        /// 
        [Route("BuscarListaTarefas1")]
        public JsonResult BuscarListaTarefas1(int id_equipamento)
        {
            List<ListaTarefa> retorno = new ListaTarefaServices().GetByEquipamentoid(id_equipamento);
            List<ListaTarefaViewModel> result = new List<ListaTarefaViewModel>();

            retorno.ForEach(i => result.Add(new ListaTarefaViewModel
            {
                id_lt_tarefa = i.IdLtTarefa.Value,
                Selecionar = false,
                cd_gp_lt_tarefa = i.CdGpLtTarefa,
                cd_sap = i.CdSap,
                ds_lt_tarefa = i.DsLtTarefa

            }));

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PartialViewExample()
        {
            return PartialView();
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);

        }
    }
}
