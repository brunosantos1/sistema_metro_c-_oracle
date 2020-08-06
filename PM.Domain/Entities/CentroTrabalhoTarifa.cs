using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCentroTrabalhoTarifa")]
    public class CentroTrabalhoTarifa : EntityTypeConfiguration<CentroTrabalhoTarifa>
    {
        public CentroTrabalhoTarifa() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_ct_trabalho { get; set; }

        [StringLength(8)]
        //[Index("IX_CentroTrabalhoTarifa", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        public bool cr_tarifa { get; set; }

        [ForeignKey("Tarifa")]
        public int? id_tp_atividade_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public Tarifa Tarifa { get; set; }
    }
}
