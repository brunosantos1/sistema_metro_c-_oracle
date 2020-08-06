using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOGrupoPlanejamento")]
    public class GrupoPlanejamento : EntityTypeConfiguration<GrupoPlanejamento>
    {
        public GrupoPlanejamento() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_gp_planejamento { get; set; }

        [StringLength(3)]
        //[Index("IX_GrupoPlanejamento", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(50)]
        public string ds_gp_planejamento { get; set; }

        [ForeignKey("CentroLocalizacao")]
        public int? id_ct_localizacao_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public CentroLocalizacao CentroLocalizacao { get; set; }
    }
}
