using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCentroLocalizacaoArOP")]
    public class CentroLocalizacaoArOP : EntityTypeConfiguration<CentroLocalizacaoArOP>
    {
        public CentroLocalizacaoArOP() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_ct_localizacao { get; set; }

        [StringLength(40)]
        //[Index("IX_CentroLocalizacaoArOP", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [ForeignKey("AreaOperacional")]
        public int? id_ar_operacional_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public AreaOperacional AreaOperacional { get; set; }
    }
}