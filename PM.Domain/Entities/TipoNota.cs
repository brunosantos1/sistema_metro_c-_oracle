using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOTipoNota")]
    public class TipoNota : EntityTypeConfiguration<TipoNota>
    {
        public TipoNota() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tp_nota { get; set; }

        [StringLength(3)]
        //[Index("IX_TipoNota", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(50)]
        public string ds_tp_nota { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
