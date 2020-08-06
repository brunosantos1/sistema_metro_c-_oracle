using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOModeloLinear")]
    public class ModeloLinear : EntityTypeConfiguration<ModeloLinear>
    {
        public ModeloLinear() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_md_rf_linear { get; set; }

        [StringLength(30)]
        //[Index("IX_ModeloLinear", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(40)]
        public string ds_modelo { get; set; }

        [StringLength(4)]
        public string tp_modelo { get; set; }

        public bool cd_di_marcador { get; set; }

        [ForeignKey("UnidadeMedida")]
        public int? id_un_di_marcador_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
