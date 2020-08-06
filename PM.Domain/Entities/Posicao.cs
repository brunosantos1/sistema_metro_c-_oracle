using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOPosicao")]
    public class Posicao : EntityTypeConfiguration<Posicao>
    {
        public Posicao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_posicao { get; set; }

        [MaxLength(40)]
        public string ds_posicao { get; set; }

        [ForeignKey("Complemento")]
        public int? id_complemento_fk { get; set; }

        public Complemento Complemento { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}