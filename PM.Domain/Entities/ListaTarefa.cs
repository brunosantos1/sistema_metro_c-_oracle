using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOListaTarefa")]
    public class ListaTarefa : EntityTypeConfiguration<ListaTarefa>
    {
        public ListaTarefa() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_lt_tarefa { get; set; }

        [StringLength(8)]
        public string cd_gp_lt_tarefa { get; set; }

        [StringLength(2)]
        //[Index("IX_ListaTarefa", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [ForeignKey("StatusListaTarefa")]
        public int? id_st_lista_tarefa_fk { get; set; }

        [StringLength(40)]
        public string ds_lt_tarefa { get; set; }

        [ForeignKey("LocalInstalacao")]
        public int? id_lc_instalacao_fk { get; set; }

        [ForeignKey("Equipamento")]
        public int? cd_equipamento_fk { get; set; }

        [ForeignKey("Estrategia")]
        public int? id_estrategia_fk { get; set; }

        [ForeignKey("Centro")]
        public int? id_centro_fk { get; set; }

        [ForeignKey("CentroTrabalho")]
        public int? id_ct_trabalho_fk { get; set; }

        [ForeignKey("CentroPlanejamento")]
        public int? id_ct_planejamento_fk { get; set; }

        [ForeignKey("GpPlanejamento")]
        public int? id_gp_planejamento_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public CentroLocalizacao Centro { get; set; }
        public Estrategia Estrategia { get; set; }
        public GrupoPlanejamento GpPlanejamento { get; set; }
        public CentroPlanejamento CentroPlanejamento { get; set; }
        public LocalInstalacao LocalInstalacao { get; set; }
        public Equipamento Equipamento { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
        public StatusListaTarefa StatusListaTarefa { get; set; }
    }
}
