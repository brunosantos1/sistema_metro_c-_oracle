using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOListaTarefaOperacaoPacote")]
    public class ListaTarefaOperacaoPacote : EntityTypeConfiguration<ListaTarefaOperacaoPacote>
    {
        public ListaTarefaOperacaoPacote() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_lt_tar_op_pac { get; set; }

        [ForeignKey("GrupoListaTarefas")]
        public int? id_gp_lt_tarefa_fk { get; set; }

        [ForeignKey("ListaTarefa")]
        public int? id_lt_tarefa_fk { get; set; }

        [ForeignKey("Operacao")]
        public int? id_operacao_fk { get; set; }

        [ForeignKey("SubOperacao")]
        public int? id_sub_operacao_fk { get; set; }

        [ForeignKey("Estrategia")]
        public int? id_estrategia_fk { get; set; }

        [ForeignKey("Pacote")]
        public int? id_pacote_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public ListaTarefaOperacao Operacao { get; set; }
        public ListaTarefaOperacao SubOperacao { get; set; }
        public EstrategiaPacote Pacote { get; set; }
        public EstrategiaPacote Estrategia { get; set; }
        public ListaTarefa GrupoListaTarefas { get; set; }
        public ListaTarefa ListaTarefa { get; set; }
    }
}
