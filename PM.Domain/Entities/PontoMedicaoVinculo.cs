using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOPontoMedicaoVinculo")]
    public class PontoMedicaoVinculo : EntityTypeConfiguration<PontoMedicaoVinculo>
    {
        public PontoMedicaoVinculo() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_pt_medicao_vinc { get; set; }

        [ForeignKey("PontoMedicao")]
        public int? id_pt_medicao_fk { get; set; }

        [ForeignKey("PontoMedicaoTransf")]
        public int id_pt_medicao_transf_valor { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public PontoMedicao PontoMedicao { get; set; }
        public PontoMedicao PontoMedicaoTransf { get; set; }
    }
}
