using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOZona")]
    public class Zona : EntityTypeConfiguration<Zona>
    {
        public Zona() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_zona { get; set; }

        [MaxLength(20)]
        public string nm_zona { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
