using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOManobra")]
    public class Manobra : EntityTypeConfiguration<Manobra>
    {
        public Manobra() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_manobra { get; set; }

        [ForeignKey("EntregaTrem")]
        public int? id_entrega_trem_fk { get; set; }

        [ForeignKey("LinhaOrigem")]
        public int? id_linha_origem { get; set; }

        [ForeignKey("LinhaDestino")]
        public int? id_linha_destino { get; set; }

        [ForeignKey("EmpregadoSolicitante")]
        public int? id_rg_solicitante_fk { get; set; }

        [ForeignKey("EmpregadoAutorizacao")]
        public int? id_rg_autorizacao_fk { get; set; }

        [ForeignKey("EmpregadoCancelamento")]
        public int? id_rg_cancelamento_fk { get; set; }

        public int id_st_manobra { get; set; }

        public DateTime dt_solicitacao { get; set; }

        public DateTime hr_solicitacao { get; set; }

        public DateTime dt_autorizacao { get; set; }

        public DateTime hr_autorizacao { get; set; }

        public DateTime dt_inicio { get; set; }

        public DateTime hr_inicio { get; set; }

        public DateTime dt_fim { get; set; }

        public DateTime hr_fim { get; set; }

        public DateTime dt_cancelamento { get; set; }

        public DateTime hr_cancelamento { get; set; }

        [StringLength(60)]
        public string ds_motivo_canc { get; set; }

        [StringLength(100)]
        public string ds_observacao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public EntregaTrem EntregaTrem { get; set; }
        public Linha LinhaOrigem { get; set; }
        public Linha LinhaDestino { get; set; }
        public Empregado EmpregadoSolicitante { get; set; }
        public Empregado EmpregadoAutorizacao { get; set; }
        public Empregado EmpregadoCancelamento { get; set; }
    }
}