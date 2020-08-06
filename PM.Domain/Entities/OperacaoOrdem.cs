using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOOperacaoOrdem")]
    public class OperacaoOrdem : EntityTypeConfiguration<OperacaoOrdem>
    {
        public OperacaoOrdem() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_operacao { get; set; }

        [ForeignKey("Ordem")]
        public int? id_ordem_fk { get; set; }

        [StringLength(20)]
        public string ds_breve { get; set; }

        public int nr_pessoas { get; set; }

        public decimal dr_operacao { get; set; }

        [ForeignKey("NotaEA")]
        public int? id_nota_ea_fk { get; set; }

        [ForeignKey("CentroTrabalho")]
        public int? id_centro_trabalho_fk { get; set; }

        public DateTime dt_hora_operacao { get; set; }

        [ForeignKey("StatusOperacao")]
        public int? id_status_operacao_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public Ordem Ordem { get; set; }
        public Nota NotaEA { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
        public StatusOperacao StatusOperacao { get; set; }
    }
}