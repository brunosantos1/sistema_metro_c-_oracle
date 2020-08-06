using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCarro")]
    public class Carro : EntityTypeConfiguration<Carro>
    {
        public Carro() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_carro { get; set; }

        [MaxLength(20)]
        public string nm_carro { get; set; }

        [ForeignKey("Trem")]
        public int? id_trem_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public Trem Trem { get; set; }
    }
}
