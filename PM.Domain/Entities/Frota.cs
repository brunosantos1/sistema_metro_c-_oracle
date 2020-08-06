using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOFrota")]
    public class Frota : EntityTypeConfiguration<Frota>
    {
        public Frota() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_frota { get; set; }

        [MaxLength(20)]
        public string nm_frota { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
