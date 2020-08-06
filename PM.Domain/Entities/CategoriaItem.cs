using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCategoriaItem")]
    public class CategoriaItem : EntityTypeConfiguration<CategoriaItem>
    {
        public CategoriaItem() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_categoria_item { get; set; }

        [StringLength(50)]
        public string ds_categoria_item { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
