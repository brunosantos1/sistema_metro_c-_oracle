using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOStatusMedida")]
    public class StatusMedida : EntityTypeConfiguration<StatusMedida>
    {
        public StatusMedida() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_st_medida { get; set; }

        [StringLength(4)]
        public string cd_sap { get; set; }

        [StringLength(150)]
        public string ds_st_medida { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}