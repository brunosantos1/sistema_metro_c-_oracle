using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOStatusPericia")]
    public class StatusPericia : EntityTypeConfiguration<StatusPericia>
    {
        public StatusPericia() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_st_pericia { get; set; }

        [StringLength(150)]
        public string ds_st_pericia { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}