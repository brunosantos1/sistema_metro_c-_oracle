using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOEstrategia")]
    public class Estrategia : EntityTypeConfiguration<Estrategia>
    {
        public Estrategia() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_estrategia { get; set; }

        [StringLength(6)]
        //[Index("IX_Estrategia", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(30)]
        public string ds_estrategia { get; set; }

        [StringLength(2)]
        public string cd_programacao { get; set; }

        [StringLength(3)]
        public string un_estrategia { get; set; }
        
        [ForeignKey("Calendario")]
        public int? id_calendario_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public CalendarioFabrica Calendario { get; set; }
    }
}
