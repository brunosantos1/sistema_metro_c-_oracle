using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOTipoCapacidade")]
    public class TipoCapacidade : EntityTypeConfiguration<TipoCapacidade>
    {
        public TipoCapacidade() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tp_capacidade { get; set; }

        [MaxLength(10)]
        //[Index("IX_TipoCapacidade", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [MaxLength(50)]
        public string ds_tp_capacidade { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
