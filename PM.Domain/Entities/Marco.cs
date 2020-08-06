using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOMarco")]
    public class Marco : EntityTypeConfiguration<Marco>
    {
        public Marco() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_marcador { get; set; }

        [ForeignKey("ModeloLinear")]
        public int? id_md_rf_linear_fk { get; set; }

        [StringLength(18)]
        //[Index("IX_Marco", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(40)]
        public string ds_marcador { get; set; }

        [ForeignKey("TipoMarcador")]
        public int? id_tp_marcador_fk { get; set; }

        [StringLength(18)]
        public string pt_rf_marcador { get; set; }

        public decimal nr_comprimento { get; set; }

        [ForeignKey("UnidadeMedida")]
        public int? id_un_comprimento_fk { get; set; }

        [ForeignKey("LocalInstalacao")]
        public int? cd_lc_instalacao_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public ModeloLinear ModeloLinear { get; set; }
        public TipoMarcador TipoMarcador { get; set; }
        public LocalInstalacao LocalInstalacao { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
