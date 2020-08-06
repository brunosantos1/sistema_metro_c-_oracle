using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOPlanoItem")]
    public class PlanoItem : EntityTypeConfiguration<PlanoItem>
    {
        public PlanoItem() { BaseModel = new BaseModel(); }

        [Key, Column(Order = 0)]
        [ForeignKey("Plano")]
        public int id_plano_fk { get; set; }

        [Key, Column(Order = 1)]
        [StringLength(12)]
        public string cd_item { get; set; }

        [StringLength(40)]
        public string ds_item { get; set; }

        [ForeignKey("LocalInstalacao")]
        public int? id_lc_instalacao_fk { get; set; }

        [ForeignKey("Equipamento")]
        public int? cd_equipamento_fk { get; set; }

        [ForeignKey("Material")]
        public int? id_material_fk { get; set; }

        [StringLength(12)]
        public string cd_gp_lt_tarefa { get; set; }

        [ForeignKey("ListaTarefas")]
        public int? id_lt_tarefa_fk { get; set; }
        
        [ForeignKey("Centro")]
        public int? id_centro_fk { get; set; }

        [ForeignKey("CentroTrabalho")]
        public int? ct_trabalho_fk { get; set; }

        [ForeignKey("CentroPlanejamento")]
        public int? id_ct_planejamento_fk { get; set; }

        [ForeignKey("GpPlanejamento")]
        public int? id_gp_planejamento_fk { get; set; }

        [ForeignKey("TpOrdem")]
        public int? id_tp_ordem_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public ListaTarefa ListaTarefas { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
        public CentroLocalizacao Centro { get; set; }
        public GrupoPlanejamento GpPlanejamento { get; set; }
        public TipoOrdem TpOrdem { get; set; }
        public CentroPlanejamento CentroPlanejamento { get; set; }
        public Plano Plano { get; set; }
        public Material Material { get; set; }
        public LocalInstalacao LocalInstalacao { get; set; }
        public Equipamento Equipamento { get; set; }
    }
}
