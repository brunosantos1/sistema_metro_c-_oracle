using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OODiagnostico")]
    public class Diagnostico : EntityTypeConfiguration<Diagnostico>
    {
        public Diagnostico() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_diagnostico { get; set; }

        [StringLength(150)]
        public string ds_diagnostico { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
