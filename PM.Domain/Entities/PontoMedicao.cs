using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOPontoMedicao")]
    public class PontoMedicao : EntityTypeConfiguration<PontoMedicao>
    {
        public PontoMedicao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_pt_medicao { get; set; }

        [StringLength(12)]
        //[Index("IX_PontoMedicao", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(3)]
        public string ic_equip_li { get; set; }

        [StringLength(40)]
        public string lc_instalacao { get; set; }

        [ForeignKey("CategoriaPontoMedicao")]
        public int? id_cg_pt_medicao_fk { get; set; }

        [StringLength(40)]
        public string ds_pt_medicao { get; set; }

        [StringLength(20)]
        public string ds_item_medicao { get; set; }

        [StringLength(30)]
        public string cd_caracteristica { get; set; }

        public int nr_casa_decimal { get; set; }

        [ForeignKey("UnidadeMedida")]
        public int? id_un_medida_fk { get; set; }

        public bool ic_contador { get; set; }

        public bool ic_cont_decrescente { get; set; }

        public float at_anual_contador { get; set; }

        public bool cr_transferencia { get; set; }

        public float nr_total_contador { get; set; }

        public float nr_valor_teorico { get; set; }

        public float nr_limite_inferior { get; set; }

        public float nr_limite_superior { get; set; }

        [ForeignKey("UnidadeMedidaIntervalo")]
        public int? id_un_intervalo_fk { get; set; }

        [StringLength(40)]
        public string ds_adicional { get; set; }

        public DateTime dt_valido_desde { get; set; }

        public DateTime dt_valido_ate { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public CategoriaPontoMedicao CategoriaPontoMedicao { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public UnidadeMedida UnidadeMedidaIntervalo { get; set; }
        public virtual ICollection<Equipamento> Equipamentos { get; set; }
    }
}
