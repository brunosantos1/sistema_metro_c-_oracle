using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOEquipamento")]
    public class Equipamento : EntityTypeConfiguration<Equipamento>
    {
        public Equipamento() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_equipamento { get; set; }

        [StringLength(22)]
        //[Index("IX_Equipamento", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(18)]
        public string cd_equipamento { get; set; }

        [ForeignKey("CgEquipamento")]
        public int? id_cg_equipamento_fk { get; set; }

        [StringLength(40)]
        public string ds_equipamento { get; set; }

        [StringLength(10)]
        public string tp_equipamento { get; set; }

        [StringLength(40)]
        public string st_sistema { get; set; }

        [StringLength(40)]
        public string st_equipamento { get; set; }

        [ForeignKey("CtLocalizacao")]
        public int? id_ct_localizacao_fk { get; set; }

        [StringLength(30)]
        public string cp_ordenacao { get; set; }

        [ForeignKey("LocalInstalacao")]
        public int? id_lc_instalacao_fk { get; set; }

        public int id_eq_superior_fk { get; set; }

        public bool cr_mg_individual { get; set; }

        [StringLength(3)]
        public string sg_pais_produtor { get; set; }

        [StringLength(30)]
        public string ds_fabricante { get; set; }

        [StringLength(30)]
        public string rf_fabricante { get; set; }

        [StringLength(30)]
        public string nr_serie_fabricante { get; set; }

        public int nr_ano_construcao { get; set; }

        public int nr_mes_construcao { get; set; }

        public DateTime dt_aquisicao { get; set; }

        public DateTime dt_ini_func { get; set; }

        public DateTime dt_inicio_garantia { get; set; }

        public DateTime dt_fim_garantia { get; set; }

        public bool cd_herdar_garantia { get; set; }

        [StringLength(25)]
        public string nr_identif_tecnica { get; set; }

        [StringLength(18)]
        public string nr_dimensao { get; set; }

        public decimal pe_bruto { get; set; }

        [ForeignKey("UnidadeMedida")]
        public int? id_un_peso_fk { get; set; }

        [ForeignKey("Material")]
        public int? id_material_fk { get; set; }

        [ForeignKey("Conjunto")]
        public int? id_conjunto_fk { get; set; }

        [StringLength(10)]
        public string tp_veiculo { get; set; }

        [StringLength(18)]
        public string nr_identif_veiculo { get; set; }

        [StringLength(15)]
        public string ds_placa_veiculo { get; set; }

        [StringLength(30)]
        public string nr_serie_motor { get; set; }

        [StringLength(12)]
        public string cd_tp_combustivel_primario { get; set; }

        [StringLength(12)]
        public string cd_tp_combustivel_secundario { get; set; }

        [StringLength(12)]
        public string cd_tp_oleo { get; set; }

        [ForeignKey("CentroLocalizacao")]
        public int? id_centro_fk { get; set; }

        [ForeignKey("CentroTrabalho")]
        public int? id_ct_trabalho_fk { get; set; }

        [ForeignKey("CentroPlanejamento")]
        public int? id_ct_planejamento_fk { get; set; }

        [ForeignKey("GpPlanejamento")]
        public int? id_gp_planejamento_fk { get; set; }

        [ForeignKey("CentroCusto")]
        public int? id_ct_custo_fk { get; set; }

        [StringLength(4)]
        public string ar_contabil { get; set; }

        [StringLength(12)]
        public string nr_imobilizado { get; set; }

        [StringLength(4)]
        public string nr_sub_imobilizado { get; set; }

        [StringLength(25)]
        public string nr_patrimonio { get; set; }

        [ForeignKey("CodigoABC")]
        public int? id_cd_abc_fk { get; set; }

        [ForeignKey("PerfilCatalogo")]
        public int? id_perfil_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public Perfil PerfilCatalogo { get; set; }
        public CentroLocalizacao CtLocalizacao { get; set; }
        public CentroLocalizacao CentroLocalizacao { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
        public GrupoPlanejamento GpPlanejamento { get; set; }
        public CentroCusto CentroCusto { get; set; }
        public CodigoABC CodigoABC { get; set; }
        public CategoriaEquipamento CgEquipamento { get; set; }
        public Material Material { get; set; }
        public Material Conjunto { get; set; }
        public LocalInstalacao LocalInstalacao { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public CentroPlanejamento CentroPlanejamento { get; set; }
        public virtual ICollection<PontoMedicao> PontosMedicao { get; set; }
    }
}
