using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOPontoMedicaoDocMedicao")]
    public class PontoMedicaoDocMedicao : EntityTypeConfiguration<PontoMedicaoDocMedicao>
    {
        public PontoMedicaoDocMedicao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_dc_medicao { get; set; }

        [StringLength(20)]
        //[Index("IX_PontoMedicaoDocMedicao", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [ForeignKey("PontoMedicao")]
        public int? id_pt_medicao_fk { get; set; }

        public DateTime dt_medicao { get; set; }

        public DateTime hr_medicao { get; set; }

        public float nr_ps_contador { get; set; }

        public float nr_valor_medicao { get; set; }

        [ForeignKey("UnidadeMedida")]
        public int? id_un_medida_fk { get; set; }

        [StringLength(40)]
        public string ds_dc_medicao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public PontoMedicao PontoMedicao { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
