using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOEstrategiaPacote")]
    public class EstrategiaPacote : EntityTypeConfiguration<EstrategiaPacote>
    {
        public EstrategiaPacote() { BaseModel = new BaseModel(); }

        [Key]
        [ForeignKey("Estrategia")]
        public int id_estrategia { get; set; }

        [StringLength(2)]
        public string cd_pacote { get; set; }

        [StringLength(22)]
        public string nr_ciclo_manutencao { get; set; }

        [ForeignKey("UnidadeMedida")]
        public int? id_un_ciclo_fk { get; set; }

        [StringLength(30)]
        public string ds_ciclo { get; set; }

        [StringLength(2)]
        public string ds_breve_ciclo { get; set; }

        public bool cr_hierarquia { get; set; }

        [StringLength(22)]
        public string nr_offset_ciclo { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public Estrategia Estrategia { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
