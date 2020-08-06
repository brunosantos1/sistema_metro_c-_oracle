using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOEntregaTrem")]
    public class EntregaTrem : EntityTypeConfiguration<EntregaTrem>
    {
        public EntregaTrem() {
            BaseModel = new BaseModel();           
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_entrega { get; set; }
                
        [ForeignKey("MotivoEntregaOcorrencia")]
        public int? id_motivo_entrega_ocor_fk { get; set; }

        [ForeignKey("MotivoEntregaProgramacao")]
        public int? id_motivo_entrega_prog_fk { get; set; }

        [ForeignKey("MotivoEntregaInspecao")]
        public int? id_motivo_entrega_inspecao_fk { get; set; }

        [ForeignKey("Trem")]
        public int? id_trem_fk { get; set; }

        public DateTime dt_entrega { get; set; }

        public DateTime hr_entrega { get; set; }

        [ForeignKey("Patio")]
        public int? id_patio_fk { get; set; }

        [ForeignKey("Linha")]
        public int? id_lin_entrega { get; set; }

        [ForeignKey("CentroTrabalho")]
        public int? id_ct_trab { get; set; }

        [ForeignKey("RespEntrega")]
        public int? id_resp_entrega { get; set; }

        public DateTime dt_cancelamento { get; set; }

        public DateTime hr_cancelamento { get; set; }

        [ForeignKey("RespCancelamento")]
        public int? id_resp_cancelamento { get; set; }

        public DateTime dt_liberacao { get; set; }

        public DateTime hr_liberacao { get; set; }

        [ForeignKey("RespLiberacao")]
        public int? id_resp_liberacao { get; set; }

        [ForeignKey("StatusEntregaTrem")]
        public int? st_entrega_trem { get; set; }

        [NotMapped]
        public List<Nota> Notas { get; set; }

        [NotMapped]
        public List<Programacao> Programacao { get; set; }

        [MaxLength(2000)]
        public string ds_motivo_cancelamento { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public MotivoEntrega MotivoEntregaOcorrencia { get; set; }
        public MotivoEntrega MotivoEntregaProgramacao { get; set; }
        public MotivoEntrega MotivoEntregaInspecao { get; set; }        
        public Trem Trem { get; set; }
        public Patio Patio { get; set; }
        public Linha Linha { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
        public Empregado RespEntrega { get; set; }
        public Empregado RespCancelamento { get; set; }
        public Empregado RespLiberacao { get; set; }
        public StatusEntregaTrem StatusEntregaTrem { get; set; }
    }
}
