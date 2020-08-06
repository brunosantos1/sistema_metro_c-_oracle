using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOOperacaoProgramacaoEF")]
    public class OperacaoProgramacaoEF : EntityTypeConfiguration<OperacaoProgramacaoEF>
    {
        public OperacaoProgramacaoEF() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id_operacaoprogramacaoef { get; set; }

        [ForeignKey("ProgramacaoEquipamentoFixo")]
        public int? id_programacao { get; set; }

        [ForeignKey("Ordem")]
        public int? id_ordem { get; set; }

        [ForeignKey("ListaTarefa")]
        public int? id_gp_lt_tarefa { get; set; }

        public int? id_operacao { get; set; }

        public int? id_sub_operacao { get; set; }

        public DateTime dt_programacao { get; set; }

        public DateTime dt_reprogramacao { get; set; }

        [ForeignKey("MotivoEntrega")]
        public int? id_motivo { get; set; }

        public DateTime dt_realizacao { get; set; }

        public string ds_comentario { get; set; }

        public string ds_obs { get; set; }

        public bool ic_ocultar_historico { get; set; }

        public bool ic_reprogramacao { get; set; }

        public int? id_operacao_origem {get;set;}

        public string st_operacao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public ProgramacaoEF ProgramacaoEquipamentoFixo { get; set; }
        public Ordem Ordem { get; set; }

        public ListaTarefa ListaTarefa { get; set; }

        public MotivoEntrega MotivoEntrega { get; set; }

    }
}