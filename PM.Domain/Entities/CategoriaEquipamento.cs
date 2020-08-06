using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCategoriaEquipamento")]
    public class CategoriaEquipamento : EntityTypeConfiguration<CategoriaEquipamento>
    {
        public CategoriaEquipamento() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_cg_equipamento { get; set; }

        [StringLength(1)]
        //[Index("IX_CategoriaEquipamento", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(40)]
        public string ds_cg_equipamento { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
