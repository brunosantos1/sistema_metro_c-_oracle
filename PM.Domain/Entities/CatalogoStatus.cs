using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCatalogosStatus")]
    public class CatalogoStatus : EntityTypeConfiguration<CatalogoStatus>
    {
        public CatalogoStatus() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_cat_status { get; set; }

        [StringLength(10)]
        public string cd_status { get; set; }

        [StringLength(40)]
        public string ds_cat_status { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
