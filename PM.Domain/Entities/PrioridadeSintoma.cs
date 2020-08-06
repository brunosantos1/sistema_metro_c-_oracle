using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOPrioridadeSintoma")]
    public class PrioridadeSintoma : EntityTypeConfiguration<PrioridadeSintoma>
    {
        public PrioridadeSintoma() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_prioridade_sintoma { get; set; }

        [ForeignKey("Code")]
        public int? id_code_fk { get; set; }

        [StringLength(1)]
        public string cd_prioridade { get; set; }

        [ForeignKey("Prioridade")]
        public int? id_prioridade_fk { get; set; }

        [StringLength(1)]
        public string cd_entrega { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public Code Code { get; set; }
        public Prioridade Prioridade { get; set; }
    }
}
