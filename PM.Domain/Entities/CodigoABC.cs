using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCodigoABC")]
    public class CodigoABC : EntityTypeConfiguration<CodigoABC>
    {
        public CodigoABC() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_abc { get; set; }

        [StringLength(1)]
        //[Index("IX_CodigoABC", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(50)]
        public string ds_abc { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}