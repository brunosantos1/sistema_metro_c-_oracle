using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOGrupoCode")]
    public class GrupoCode : EntityTypeConfiguration<GrupoCode>
    {
        public GrupoCode() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_gp_code { get; set; }

        [StringLength(8)]
        public string cd_sap { get; set; }

        public virtual ICollection<Catalogo> Catalogos { get; set; }

        [StringLength(40)]
        public string ds_gp_code { get; set; }

        public bool st_gp_code { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
