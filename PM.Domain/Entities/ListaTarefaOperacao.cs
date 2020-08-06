using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOListaTarefaOperacao")]
    public class ListaTarefaOperacao : EntityTypeConfiguration<ListaTarefaOperacao>
    {
        public ListaTarefaOperacao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cd_lt_tarefa_operacao { get; set; }

        [ForeignKey("ListaTarefa")]
        public int id_lt_tarefa_fk { get; set; }

        [StringLength(8)]
        public string cd_gp_lt_tarefa { get; set; }

        [StringLength(4)]
        public string cd_operacao { get; set; }

        [StringLength(4)]
        public string cd_sub_operacao { get; set; }

        [StringLength(40)]
        public string ds_operacao { get; set; }

        public int nr_capacidade { get; set; }

        public decimal nr_duracao { get; set; }

        [ForeignKey("UnidadeMedidaDuracao")]
        public int? id_un_duracao_fk { get; set; }

        public int nr_trabalho { get; set; }

        [ForeignKey("UnidadeMedidaTrabalho")]
        public int? id_un_trabalho_fk { get; set; }

        [ForeignKey("Conjunto")]
        public int? id_conjunto_fk { get; set; }

        [ForeignKey("Tarifa")]
        public int? id_tp_atividade_fk { get; set; }

        [ForeignKey("CentroLocalizacao")]
        public int? id_centro_fk { get; set; }

        [ForeignKey("CentroTrabalho")]
        public int? id_ct_trabalho_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public CentroLocalizacao CentroLocalizacao { get; set; }
        public Tarifa Tarifa { get; set; }
        public ListaTarefa ListaTarefa { get; set; }
        public Material Conjunto { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
        public UnidadeMedida UnidadeMedidaDuracao { get; set; }
        public UnidadeMedida UnidadeMedidaTrabalho { get; set; }
    }
}