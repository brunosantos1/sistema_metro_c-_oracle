using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOPatioLinha")]
    public class PatioLinha : EntityTypeConfiguration<PatioLinha>
    {
        public PatioLinha() { BaseModel = new BaseModel(); }

        [Key, Column(Order = 0)]
        [ForeignKey("Patio")]
        public int? id_patio_fk { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Linha")]
        public int? id_linha_fk { get; set; }

        [StringLength(1)]
        public string cd_uso_linha { get; set; }

        public int qt_trem { get; set; }

        [StringLength(15)]
        public string cd_status { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public Linha Linha { get; set; }
        public Patio Patio { get; set; }
    }
}
