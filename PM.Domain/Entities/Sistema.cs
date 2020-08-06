using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOSistema")]
    public class Sistema : EntityTypeConfiguration<Sistema>
    {
        public Sistema() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_sistema { get; set; }

        [MaxLength(20)]
        public string nm_sistema { get; set; }

        [ForeignKey("Frota")]
        public int? id_frota_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        public Frota Frota { get; set; }
    }
}