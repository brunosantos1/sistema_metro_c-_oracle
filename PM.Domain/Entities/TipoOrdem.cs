using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOTipoOrdem")]
    public class TipoOrdem : EntityTypeConfiguration<TipoOrdem>
    {
        public TipoOrdem() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tp_ordem { get; set; }

        [StringLength(3)]
        //[Index("IX_TipoOrdem", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(50)]
        public string ds_tp_ordem { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
