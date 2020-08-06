using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOTipoMarcador")]
    public class TipoMarcador : EntityTypeConfiguration<TipoMarcador>
    {
        public TipoMarcador() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tp_marcador { get; set; }

        [MaxLength(2)]
        //[Index("IX_TipoMarcador", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [MaxLength(50)]
        public string ds_tp_marcador { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
