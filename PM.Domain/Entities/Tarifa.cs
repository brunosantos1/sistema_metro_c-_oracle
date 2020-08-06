using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOTarifa")]
    public class Tarifa : EntityTypeConfiguration<Tarifa>
    {
        public Tarifa() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tarifa { get; set; }

        [StringLength(12)]
        //[Index("IX_Tarifa", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(40)]
        public string ds_tp_atividade { get; set; }

        [ForeignKey("UnidadeMedida")]
        public int? id_un_atividade_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
