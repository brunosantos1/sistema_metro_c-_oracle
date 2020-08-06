using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOPlano")]
    public class Plano : EntityTypeConfiguration<Plano>
    {
        public Plano() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_plano { get; set; }

        [StringLength(12)]
        //[Index("IX_Plano", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(40)]
        public string ds_plano { get; set; }

        [StringLength(1)]
        public string cd_plano_gp_ciclo { get; set; }

        [ForeignKey("Estrategia")]
        public int? id_estrategia_fk { get; set; }

        [StringLength(22)]
        public string nr_ciclo_unico_manut { get; set; }

        [ForeignKey("UnidadeMedidaCiclo")]
        public int? id_un_ciclo_manut_fk { get; set; }

        [StringLength(2)]
        public string cd_cg_plano { get; set; }

        [ForeignKey("PontoMedicao")]
        public int? id_pt_medicao_fk { get; set; }

        public decimal nr_intervalo_solic { get; set; }

        [ForeignKey("UnidadeMedidaIntervalo")]
        public int? id_un_intervalo_solic_fk { get; set; }

        [StringLength(20)]
        public string ds_selecao_plano { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public PontoMedicao PontoMedicao { get; set; }
        public Estrategia Estrategia { get; set; }
        public UnidadeMedida UnidadeMedidaCiclo { get; set; }
        public UnidadeMedida UnidadeMedidaIntervalo { get; set; }
    }
}
