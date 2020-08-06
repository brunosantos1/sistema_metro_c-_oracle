using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOStatusSistema")]
    public class StatusSistema : EntityTypeConfiguration<StatusSistema>
    {
        public StatusSistema() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_st_sistema { get; set; }

        [StringLength(150)]
        public string ds_st_sistema { get; set; }

        [StringLength(5)]
        //[Index("IX_StatusSistema", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}