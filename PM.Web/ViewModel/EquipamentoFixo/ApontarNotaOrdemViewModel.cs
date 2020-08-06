using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Web.ViewModel
{
    public class ApontarNotaOrdemViewModel : BaseViewModel
    {
        public ApontarNotaOrdemViewModel()
        {
            this.Ordem = new OrdemViewModel();
            this.Ordem.Operacoes = new List<OperacaoOrdemViewModel>();

            this.Nota = new NotaViewModel();
            this.Nota.MedidasNota = new List<MedidaNotaViewModel>();
            this.Nota.NotasVinculadas = new List<NotaViewModel>();
            this.Nota.DocumentosVinculados = new List<DocumentoVinculadoModel>();
        }

        public NotaViewModel Nota { get; set; }

        public OrdemViewModel Ordem { get; set; }

        public class NotaViewModel : BaseViewModel
        {
            public int id_nota { get; set; }

            public int id_tp_nota { get; set; }

            public string ds_tp_nota { get; set; }

            public string dt_nota { get; set; }

            public string hr_nota { get; set; }

            public int id_centro_trabalho { get; set; }

            public string ds_centro_trabalho { get; set; }

            public List<string> st_usuario_nota { get; set; }

            public int id_local_inst { get; set; }

            public string ds_local_inst { get; set; }

            public int id_sintoma { get; set; }

            public string ds_sintoma { get; set; }

            public string nt_descricao { get; set; }

            public string rg_notificador { get; set; }

            public int id_diagnostico { get; set; }

            public string ds_diagnostico { get; set; }

            public int id_local_inst_princip { get; set; }

            public string ds_local_inst_princip { get; set; }

            //public int id_causa_raiz { get; set; }

            public string nt_observacao { get; set; }

            public OrdemViewModel Ordem { get; set; }

            public List<MedidaNotaViewModel> MedidasNota { get; set; }

            public List<NotaViewModel> NotasVinculadas { get; set; }

            public List<DocumentoVinculadoModel> DocumentosVinculados { get; set; }
        }

        public class OrdemViewModel : BaseViewModel
        {
            public int id_ordem { get; set; }

            public int id_nota { get; set; }

            public DateTime dt_hora_ordem { get; set; }

            public int id_status { get; set; }

            public List<OperacaoOrdemViewModel> Operacoes { get; set; }
        }

        public class MedidaNotaViewModel : BaseViewModel
        {
            public int id_medida_nota { get; set; }

            public int id_nota { get; set; }

            public string dt_medida_nota { get; set; }

            public string hr_medida_nota { get; set; }

            public int id_empregado { get; set; }

            public String ds_empregado { get; set; }

            public string tx_medida_nota { get; set; }

            public int id_empregado_responsavel { get; set; }

            public string ds_empregado_responsavel { get; set; }

            public int id_cent_trab_responsavel { get; set; }

            public string ds_cent_trab_responsavel { get; set; }

            public int id_st_medida { get; set; }

            public string ds_st_medida { get; set; }
        }

        public class DocumentoVinculadoModel : BaseViewModel
        {
            public int id_documento { get; set; }

            public int id_nota { get; set; }

            public int id_tipo_documento { get; set; }

            public string ds_tipo_documento { get; set; }

            public string ds_documento { get; set; }
        }

        public class OperacaoOrdemViewModel : BaseViewModel
        {
            public int id_operacao { get; set; }

            public int id_ordem { get; set; }

            public string tx_breve { get; set; }

            public int nr_pessoas { get; set; }

            public float dr_operacao { get; set; }

            public int id_nota_ea { get; set; }

            public string ds_nota_ea { get; set; }

            public int id_centro_trabalho { get; set; }

            public string ds_centro_trabalho { get; set; }

            public string dt_operacao { get; set; }

            public string hr_operacao { get; set; }

            public int id_status_operacao { get; set; }

            public string ds_status_operacao { get; set; }

            public List<MaoDeObraViewModel> MaosDeObra { get; set; }

            public List<MaterialOperacaoViewModel> Material { get; set; }

            public List<MAPViewModel> MAP { get; set; }

            public List<IntervencaoViewModel> Intervencao { get; set; }
        }

        public class MaoDeObraViewModel : BaseViewModel
        {
            public int id_maodeobra { get; set; }

            public int id_operacao { get; set; }

            public string id_centro_trabalho { get; set; }

            public int id_tarifa { get; set; }

            public int ds_tarifa { get; set; }

            public string id_chavecontrole { get; set; }

            public string ds_chavecontrole { get; set; }

            public DateTime dt_hora_maodeobra { get; set; }

            public string id_empregado { get; set; }

            public float tm_preparo { get; set; }

            public float tm_deslocamento { get; set; }

            public float tm_acesso { get; set; }

            public float tm_execucao { get; set; }

            public string id_unidade { get; set; }

            public string ds_unidade { get; set; }
        }

        public class MaterialOperacaoViewModel : BaseViewModel
        {
            public int id_material { get; set; }

            public int id_operacao { get; set; }

            public int id_componente { get; set; }

            public string dn_material { get; set; }

            public int qt_material { get; set; }

            public string id_unidade { get; set; }

            public string ds_unidade { get; set; }

            public string id_categoria_item { get; set; }

            public string ds_categoria_item { get; set; }

            public int id_deposito { get; set; }

            public int ds_deposito { get; set; }

            public int id_centro_logistico { get; set; }

            public int ds_centro_logistico { get; set; }

            public string rl_reserva { get; set; }

            public int id_local_entrega { get; set; }

            public int ds_local_entrega { get; set; }

            public int id_recebedor { get; set; }
        }

        public class MAPViewModel : BaseViewModel
        {
            public int id_map { get; set; }

            public int id_operacao { get; set; }

            public string dn_map { get; set; }
        }

        public class IntervencaoViewModel : BaseViewModel
        {
            public int id_intervencao { get; set; }

            public int id_operacao { get; set; }

            public int id_nota_ea { get; set; }

            public string id_local_instalacao { get; set; }

            public string ds_local_instalacao { get; set; }

            public int id_parte_objeto { get; set; }

            public int ds_parte_objeto { get; set; }

            public int id_defeito { get; set; }

            public int ds_defeito { get; set; }

            public int id_reparo { get; set; }

            public int ds_reparo { get; set; }

            public int qt_intervencao { get; set; }

            public string mo_invervencao { get; set; }

            public float di_intervencao { get; set; }

            public float co_intervencao { get; set; }

            public int id_equipamento_desinstalado { get; set; }

            public int ds_equipamento_desinstalado { get; set; }

            public int id_equipamento_instalado { get; set; }

            public int ds_equipamento_instalado { get; set; }
        }
    }
}