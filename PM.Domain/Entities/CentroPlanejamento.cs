using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCentroPlanejamento")]
    public class CentroPlanejamento : EntityTypeConfiguration<CentroPlanejamento>
    {
        public CentroPlanejamento() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_ct_planejamento { get; set; }

        [StringLength(4)]
        //[Index("IX_CentroPlanejamento", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(50)]
        public string ds_ct_planejamento { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
