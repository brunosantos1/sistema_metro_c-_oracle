using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOProgramacao")]
    public class Programacao : EntityTypeConfiguration<Programacao>
    {
        public Programacao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_programacao { get; set; }

        [StringLength(3)]
        public string cd_tp_programacao { get; set; }

        [ForeignKey("Trem")]
        public int? id_trem_fk { get; set; }

        public DateTime dt_planej_entrega { get; set; }

        public DateTime hr_planej_entrega { get; set; }

        [ForeignKey("Linha")]
        public int? id_lin_planej_entrega_fk { get; set; }

        public DateTime dt_prev_liberacao { get; set; }

        public DateTime hr_prev_liberacao { get; set; }

        [ForeignKey("EmpregadoProgramacao")]
        public int? id_rg_programacao { get; set; }

        [StringLength(2000)]
        public string ds_observacao { get; set; }

        public DateTime dt_autorizacao { get; set; }

        public DateTime hr_autorizacao { get; set; }

        [ForeignKey("EmpregadoAutorizacao")]
        public int? id_rg_autorizacao { get; set; }

        public DateTime dt_cancelamento { get; set; }

        public DateTime hr_cancelamento { get; set; }

        [ForeignKey("EmpregadoCancelamento")]
        public int? id_rg_cancelamento { get; set; }

        public DateTime dt_entrega { get; set; }

        public DateTime hr_entrega { get; set; }

        public DateTime dt_liberacao { get; set; }

        public DateTime hr_liberacao { get; set; }

        [ForeignKey("CentroTrabalho")]
        public int? id_ct_trab { get; set; }

        public int st_programacao { get; set; }

        [ForeignKey("EntregaTrem")]
        public int? id_entrega_trem_fk { get; set; }

        //[ForeignKey("EntregaTrem")]
        public int? id_tipo_manutencao_fk { get; set; }

        [ForeignKey("EmpregadoLiberacao")]
        public int? id_rg_liberacao { get; set; }

        [StringLength(2000)]
        public string ds_motivo_cancelamento { get; set; }

        [NotMapped]
        public List<Nota> Notas { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
        
        //Propriedade de navegação
        public Trem Trem { get; set; }
        public Linha Linha { get; set; }
        public Empregado EmpregadoProgramacao { get; set; }
        public Empregado EmpregadoLiberacao { get; set; }
        public Empregado EmpregadoAutorizacao { get; set; }
        public Empregado EmpregadoCancelamento { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
        public EntregaTrem EntregaTrem { get; set; }
        
    }
}