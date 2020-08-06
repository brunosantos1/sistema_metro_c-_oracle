using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOGrupoAutorizacao")]
    public class GrupoAutorizacao : EntityTypeConfiguration<GrupoAutorizacao>
    {
        public GrupoAutorizacao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_gp_autorizacao { get; set; }

        [StringLength(3)]
        //[Index("IX_GrupoAutorizacao", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(50)]
        public string ds_gp_autorizacao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
