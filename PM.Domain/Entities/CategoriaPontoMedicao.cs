using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCategoriaPontoMedicao")]
    public class CategoriaPontoMedicao : EntityTypeConfiguration<CategoriaPontoMedicao>
    {
        public CategoriaPontoMedicao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_cg_ponto_medicao { get; set; }

        [StringLength(5)]
        //[Index("IX_CategoriaPontoMedicao", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(50)]
        public string ds_cg_ponto_medicao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}