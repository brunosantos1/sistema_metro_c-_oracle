using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCapacidade")]
    public class Capacidade : EntityTypeConfiguration<Capacidade>
    {
        public Capacidade() { BaseModel = new BaseModel(); }

        [Key]     
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_capacidade { get; set; }

        [ForeignKey("CentroLocalizacao")]
        public int? id_centro_fk { get; set; }

        [ForeignKey("CentroTrabalho")]
        public int? id_ct_trabalho_fk { get; set; }

        [StringLength(3)]
        //[Index("IX_TipoCapacidade", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [ForeignKey("TipoCapacidade")]
        public int? id_tp_capacidade_fk { get; set; }

        public bool cr_excluida_planejamento { get; set; }

        public bool cr_programacao { get; set; }

        [StringLength(3)]
        public string cr_sobrecarga { get; set; }

        public bool cr_capacidade_operacao { get; set; }

        [ForeignKey("Calendario")]
        public int? id_calendario_fk { get; set; }

        public decimal nr_capacidade { get; set; }

        [ForeignKey("UnidadeMedidaCap")]
        public int? id_un_capacidade_fk { get; set; }

        [ForeignKey("UnidadeMedidaBaseCap")]
        public int? id_un_base_capacidade_fk { get; set; }

        public int gr_utilizacao { get; set; }

        [ForeignKey("GpPlanejamento")]
        public int? id_gp_planejamento_fk { get; set; }

        public DateTime hr_fim_capacidade { get; set; }

        public DateTime hr_inicio_capacidade { get; set; }

        public DateTime hr_intervalo { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public CentroTrabalho CentroTrabalho { get; set; }
        public CentroLocalizacao CentroLocalizacao { get; set; }
        public TipoCapacidade TipoCapacidade { get; set; }
        public CalendarioFabrica Calendario { get; set; }
        public GrupoPlanejamento GpPlanejamento { get; set; }
        public UnidadeMedida UnidadeMedidaCap { get; set; }
        public UnidadeMedida UnidadeMedidaBaseCap { get; set; }
    }
}