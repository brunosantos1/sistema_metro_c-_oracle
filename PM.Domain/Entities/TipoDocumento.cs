using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOTipoDocumento")]
    public class TipoDocumento : EntityTypeConfiguration<TipoDocumento>
    {
        public TipoDocumento() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tp_documento { get; set; }

        [StringLength(50)]
        public string ds_tp_documento { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
