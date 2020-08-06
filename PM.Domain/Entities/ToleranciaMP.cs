using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOToleranciaMP")]
    public class ToleranciaMP : EntityTypeConfiguration<ToleranciaMP>
    {
        public ToleranciaMP() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id_tolerancia { get; set; }

        [ForeignKey("Estrategia")]
        public int? id_estrategia_fk { get; set; }

        public int? id_pacote { get; set; }

        [StringLength(4)]
        public string nr_limite_superior { get; set; }

        [StringLength(4)]
        public string nr_limite_inferior { get; set; }

        [ForeignKey("UnidadeMedida")]
        public int? id_un_limite { get; set; }


        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public Estrategia Estrategia { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}