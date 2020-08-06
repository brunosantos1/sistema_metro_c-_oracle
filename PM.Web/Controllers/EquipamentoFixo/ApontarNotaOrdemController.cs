using PM.WebServices.Models;
using PM.WebServices.Service;
using PM.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.Web.Controllers.EquipamentoFixo
{
    [RoutePrefix("EquipamentoFixo2")]
    public class ApontarNotaOrdemController : Controller
    {
        /// <summary>
        /// Conversão da Model Nota para NotaViewModel
        /// </summary>
        /// <param name="notaVM">ViewModel a ser atualizada</param>
        /// <param name="nota">Model</param>
        private void NotaModelToViewModel(ApontarNotaOrdemViewModel.NotaViewModel notaVM, Nota nota)
        {
            notaVM.id_nota = nota.IdNota.Value;
            notaVM.id_tp_nota = nota.IdTpNotaFk;
            notaVM.ds_tp_nota = nota.TipoNota.DsTpNota;
            notaVM.dt_nota = String.Format("{0:d/M/yyyy}", nota.DtHoraNota);
            notaVM.hr_nota = String.Format("{0:HH:mm:ss}", nota.DtHoraNota);
            notaVM.id_centro_trabalho = int.Parse(nota.IdCentroTrabalhoFk.ToString());
            notaVM.ds_centro_trabalho = nota.CentroTrabalho.DsCtTrabalho;
            notaVM.st_usuario_nota = nota.StatusUsuarios.Select(n => n.DsStUsuario).ToList();
            notaVM.id_local_inst = nota.IdLocalInstFk.Value;
            notaVM.ds_local_inst = nota.LocalInstalacao.DsLcInstalacao;
            notaVM.id_sintoma = nota.IdCodeSintomaFk.Value;
            notaVM.ds_sintoma = nota.CodeSintoma.DsCode;
            notaVM.nt_descricao = nota.DsDescricao;
            notaVM.rg_notificador = nota.Empregado.RgEmpregado;
            notaVM.id_diagnostico = nota.IdDiagnosticoFk.Value;
            notaVM.ds_diagnostico = nota.Diagnostico.DsDiagnostico;
            notaVM.id_local_inst_princip = nota.IdLocalInstPrincFk.Value;
            notaVM.ds_local_inst_princip = nota.LocalInstPrinc.DsLcInstalacao;
            //notaVM.id_causa_raiz = nota.IdCausaRaiz;
            notaVM.nt_observacao = nota.DsObservacao;
        }

        [HttpGet]
        [Route("ApontarNota/{notaId?}")]
        public ActionResult ApontarNota(int? notaId)
        {
            Nota nota;

            try
            {
                nota = new NotaServices().GetById(notaId.Value);

                if (nota != null)
                {
                    List<MedidaNota> medidasNota = new MedidaNotaServices().GetNavigationPropertiesByNota((int)nota.IdNota).ToList();
                    List<Nota> notasVinculadas = new NotaServices().GetNotasVinculadasNavigationProperties((int)nota.IdNota).ToList();
                    List<Documento> documentosVinculados = new DocumentoServices().GetNavigationPropertiesByNota((int)nota.IdNota).ToList();

                    if (medidasNota != null)
                    {
                        nota.MedidasNota = medidasNota;
                    }

                    if (notasVinculadas != null)
                    {
                        nota.NotasVinculadas = notasVinculadas;
                    }
                }
            }
            catch
            {
                nota = new Nota();
            }

            return View(nota);
        }

        [HttpGet]
        [Route("ApontarOrdem/{ordemId?}")]
        public ActionResult ApontarOrdem(int? ordemId)
        {
            Ordem ordem;
            ApontarNotaOrdemViewModel apontarOrdemVM;

            try
            {
                //Carregamento da Ordem
                ordem = new OrdemServices().GetById(ordemId.Value);

                if (ordem != null)
                {
                    apontarOrdemVM = new ApontarNotaOrdemViewModel();

                    //Carregamento da Nota
                    //Nota nota = new NotaServices().GetById(ordem.IdNotaFk.Value);
                    Nota nota = new NotaServices().GetNavigationPropertiesById(ordem.IdNotaFk.Value);

                    if (nota != null)
                    {
                        //Conversão de Model para ViewModel (Nota)
                        NotaModelToViewModel(apontarOrdemVM.Nota, nota);

                        //Carregamento das Medidas da Nota
                        List<MedidaNota> medidasNota = new MedidaNotaServices().GetNavigationPropertiesByNota(nota.IdNota.Value).ToList();

                        foreach (MedidaNota medidaNota in medidasNota)
                        {
                            //Conversão de Model para ViewModel (Medidas da Nota)
                            apontarOrdemVM.Nota.MedidasNota.Add(
                                new ApontarNotaOrdemViewModel.MedidaNotaViewModel()
                                {
                                    id_medida_nota = medidaNota.IdMedidaNota.Value,
                                    id_nota = nota.IdNota.Value,
                                    dt_medida_nota = String.Format("{0:d/M/yyyy}", medidaNota.DtHoraMedidaNota),
                                    hr_medida_nota = String.Format("{0:HH:mm:ss}", medidaNota.DtHoraMedidaNota),
                                    id_empregado = medidaNota.IdEmpregadoFk.Value,
                                    ds_empregado = medidaNota.Empregado.NmFuncionario,
                                    tx_medida_nota = medidaNota.DsMotivo,
                                    id_empregado_responsavel = medidaNota.IdEmpregadoFk.Value,
                                    ds_empregado_responsavel = medidaNota.EmpregadoResponsavel.NmFuncionario,
                                    id_cent_trab_responsavel = medidaNota.IdCentTrabResponsavelFk.Value,
                                    ds_cent_trab_responsavel = medidaNota.CentroTrabalho != null ? medidaNota.CentroTrabalho.DsCtTrabalho : String.Empty,
                                    id_st_medida = medidaNota.IdStMedidaFk.Value,
                                    ds_st_medida = medidaNota.StatusMedida.DsStMedida
                                });
                        }

                        //Carregamento das Notas Vinculadas
                        List<Nota> notasVinculadas = new NotaServices().GetNotasVinculadasNavigationProperties(nota.IdNota.Value).ToList();

                        foreach (Nota notaVinculada in notasVinculadas)
                        {
                            ApontarNotaOrdemViewModel.NotaViewModel notaVinculadaVM = new ApontarNotaOrdemViewModel.NotaViewModel();

                            //Conversão de Model para ViewModel (Nota)
                            NotaModelToViewModel(notaVinculadaVM, notaVinculada);
                            apontarOrdemVM.Nota.NotasVinculadas.Add(notaVinculadaVM);
                        }
                    }

                    //Conversão de Model para ViewModel (Ordem)
                    apontarOrdemVM.Ordem.id_ordem = ordem.IdOrdem.Value;
                    apontarOrdemVM.Ordem.id_nota = ordem.IdNotaFk.Value;
                    apontarOrdemVM.Ordem.dt_hora_ordem = ordem.DtHoraOrdem.Value;
                    //apontarOrdemVM.Ordem.id_status = ordem.StatusUsuarios.ToString();
                }
                else
                {
                    ordem = new Ordem();
                    apontarOrdemVM = new ApontarNotaOrdemViewModel();
                }
            }
            catch (Exception ex)
            {
                ordem = new Ordem();
                apontarOrdemVM = new ApontarNotaOrdemViewModel();
            }

            return View("~/Views/EquipamentoFixo/ApontarNotaOrdem/ApontarNotaOrdem.cshtml", apontarOrdemVM);
        }

        [HttpGet]
        [Route("ApontarNotaOrdem/GetDocumentosVinculados/{notaId?}")]
        public JsonResult GetDocumentosVinculados(int? notaId)
        {
            JsonResult result;

            try
            {
                List<ApontarNotaOrdemViewModel.DocumentoVinculadoModel> documentosVinculadosVM = new List<ApontarNotaOrdemViewModel.DocumentoVinculadoModel>();

                //Carregamento dos Documentos Vinculados
                List<Documento> documentosVinculados = new DocumentoServices().GetNavigationPropertiesByNota(notaId.Value).ToList();

                if (documentosVinculados != null)
                {
                    foreach (Documento documentoVinculado in documentosVinculados)
                    {
                        //Conversão de Model para ViewModel (Documento Vinculado)
                        documentosVinculadosVM.Add(
                            new ApontarNotaOrdemViewModel.DocumentoVinculadoModel()
                            {
                                id_documento = documentoVinculado.IdDocumento.Value,
                                id_tipo_documento = documentoVinculado.IdTpDocumentoFk.Value,
                                ds_tipo_documento = documentoVinculado.TipoDocumento.DsTpDocumento,
                                ds_documento = documentoVinculado.DsDocumento,
                                id_nota = notaId.Value
                            });
                    }

                    if (documentosVinculados.Count > 0)
                    {
                        //Conversão de ViewModel para Json compatível com o plugin dataTable
                        List<String[]> values = documentosVinculadosVM.Select(x => new String[] {
                            x.id_documento.ToString(),
                            x.ds_tipo_documento,
                            x.ds_documento,
                            x.id_nota.ToString()
                        }).ToList();

                        var _values = new { data = values };
                        result = Json(_values, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        result = null;
                    }
                }
                else
                {
                    result = null;
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        [HttpGet]
        [Route("ApontarNotaOrdem/GetOperacoesOrdem/{ordemId?}")]
        public JsonResult GetOperacoesOrdem(int? ordemId)
        {
            JsonResult result;

            try
            {
                List<ApontarNotaOrdemViewModel.OperacaoOrdemViewModel> operacoesOrdemVM = new List<ApontarNotaOrdemViewModel.OperacaoOrdemViewModel>();

                //Carregamento das Operações da Ordem
                List<OperacaoOrdem> operacoesOrdem = new OperacaoOrdemServices().GetNavigationPropertiesByOrdem(ordemId.Value).ToList();

                foreach (OperacaoOrdem operacaoOrdem in operacoesOrdem)
                {
                    //Conversão de Model para ViewModel (Operações da Ordem)
                    operacoesOrdemVM.Add(
                        new ApontarNotaOrdemViewModel.OperacaoOrdemViewModel()
                        {
                            id_operacao = operacaoOrdem.IdOperacao.Value,
                            id_ordem = operacaoOrdem.IdOperacao.Value,
                            tx_breve = operacaoOrdem.DsBreve,
                            nr_pessoas = operacaoOrdem.NrPessoas.Value,
                            dr_operacao = (float)operacaoOrdem.DrOperacao.Value,
                            ds_nota_ea = operacaoOrdem.NotaEA.DsDescricao,
                            id_centro_trabalho = operacaoOrdem.IdCentroTrabalhoFk.Value,
                            ds_centro_trabalho = operacaoOrdem.CentroTrabalho.DsCtTrabalho,
                            dt_operacao = String.Format("{0:d/M/yyyy}", operacaoOrdem.DtHoraOperacao),
                            hr_operacao = String.Format("{0:HH:mm:ss}", operacaoOrdem.DtHoraOperacao),
                            id_status_operacao = operacaoOrdem.IdStatusOperacaoFk.Value,
                            ds_status_operacao = operacaoOrdem.StatusOperacao.DsStOperacao,
                        });
                }

                if (operacoesOrdemVM.Count > 0)
                {
                    //Conversão de ViewModel para Json compatível com o plugin dataTable
                    List<String[]> values = operacoesOrdemVM.Select(x => new String[] {
                        x.id_ordem.ToString(),
                        x.id_operacao.ToString(),
                        x.tx_breve .ToString(),
                        x.nr_pessoas .ToString(),
                        x.dr_operacao .ToString(),
                        x.ds_nota_ea.ToString(),
                        x.ds_centro_trabalho.ToString(),
                        x.dt_operacao.ToString(),
                        x.hr_operacao.ToString(),
                        x.ds_status_operacao.ToString(),
                    }).ToList();

                    var _values = new { data = values };
                    result = Json(_values, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    result = null;
                }
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }

        [HttpGet]
        public JsonResult GetMaosDeObra(int operacaoOrdemId)
        {
            JsonResult result;

            try
            {
                List<MaoDeObra> maosDeObra = new MaoDeObraServices().GetByOperacaoOrdem(operacaoOrdemId).ToList();

                if (maosDeObra != null)
                {
                    result = Json(maosDeObra, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    result = null;
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        [HttpGet]
        public JsonResult GetMateriaisOperacao(int operacaoOrdemId)
        {
            JsonResult result;

            try
            {
                List<MaterialOperacao> materiaisOperacao = new MaterialOperacaoServices().GetByOperacaoOrdem(operacaoOrdemId).ToList();

                if (materiaisOperacao != null)
                {
                    result = Json(materiaisOperacao, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    result = null;
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        [HttpGet]
        public JsonResult GetMAPs(int operacaoOrdemId)
        {
            JsonResult result;

            try
            {
                List<MAP> maps = new MAPServices().GetByOperacaoOrdem(operacaoOrdemId).ToList();

                if (maps != null)
                {
                    result = Json(maps, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    result = null;
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        [HttpGet]
        public JsonResult GetIntervencoesOperacao(int operacaoOrdemId)
        {
            JsonResult result;

            try
            {
                List<IntervencaoOperacao> intervencoesOperacao = new IntervencaoOperacaoServices().GetByOperacaoOrdem(operacaoOrdemId).ToList();

                if (intervencoesOperacao != null)
                {
                    result = Json(intervencoesOperacao, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    result = null;
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }
    }
}