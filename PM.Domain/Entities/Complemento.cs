using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOComplemento")]
    public class Complemento : EntityTypeConfiguration<Complemento>
    {
        public Complemento() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_complemento { get; set; }

        [MaxLength(20)]
        public string ds_complemento { get; set; }

        [ForeignKey("GrCodeSistema")]
        public int? id_grcode_sistema_fk { get; set; }

        public GrupoCode GrCodeSistema { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
