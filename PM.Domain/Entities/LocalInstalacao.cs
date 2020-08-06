using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOLocalInstalacao")]
    public class LocalInstalacao : EntityTypeConfiguration<LocalInstalacao>
    {
        public LocalInstalacao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_lc_instalacao { get; set; }

        [StringLength(22)]
        //[Index("IX_LocalInstalacao", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(40)]
        public string ds_lc_instalacao { get; set; }

        [StringLength(1)]
        public string cg_lc_instalacao { get; set; }

        [StringLength(5)]
        public string cd_estrutura { get; set; }

        [StringLength(10)]
        public string cd_tp_lc_instalacao { get; set; }

        [ForeignKey("CentroLocalizacao")]
        public int? id_ct_localizacao_fk { get; set; }

        [StringLength(40)]
        public string st_sistema { get; set; }

        [StringLength(40)]
        public string st_usuario { get; set; }

        [StringLength(60)]
        public string ds_rua { get; set; }

        [StringLength(10)]
        public string nr_endereco { get; set; }

        [StringLength(10)]
        public string cd_postal { get; set; }

        [StringLength(30)]
        public string nr_telefone { get; set; }

        [StringLength(10)]
        public string nr_ramal { get; set; }

        [ForeignKey("LocalInstalacaoSuperior")]
        public int? id_lc_inst_superior_fk { get; set; }

        public bool cr_mg_permitida { get; set; }

        public bool cr_mg_individual { get; set; }

        [StringLength(30)]
        public string cp_ordenacao { get; set; }

        [StringLength(3)]
        public string sg_pais_produtor { get; set; }

        [StringLength(30)]
        public string ds_fabricante { get; set; }

        [StringLength(20)]
        public string ds_tp_fabricante { get; set; }

        [StringLength(30)]
        public string rf_fabricante { get; set; }

        [StringLength(30)]
        public string nr_serie_fabricante { get; set; }

        public int nr_ano_construcao { get; set; }

        public int nr_mes_construcao { get; set; }

        public DateTime dt_aquisicao { get; set; }

        public DateTime dt_entrada_servico { get; set; }

        public DateTime dt_inicio_garantia { get; set; }

        public DateTime dt_fim_garantia { get; set; }

        [StringLength(18)]
        public string nr_dimensao { get; set; }

        public decimal pe_bruto { get; set; }

        [ForeignKey("UnidadeMedidaPeso")]
        public int? id_un_peso_fk { get; set; }

        [ForeignKey("ModeloLinear")]
        public int? id_md_rf_linear_fk { get; set; }

        [StringLength(18)]
        public string pt_partida { get; set; }

        [StringLength(18)]
        public string pt_final { get; set; }

        public decimal nr_comprimento { get; set; }

        [StringLength(3)]
        public string un_medida { get; set; }

        [ForeignKey("MarcoPartida")]
        public int? id_mr_partida_fk { get; set; }

        [ForeignKey("MarcoFinal")]
        public int? id_mr_final_fk { get; set; }

        [StringLength(18)]
        public string nr_di_mr_partida { get; set; }

        [StringLength(18)]
        public string nr_di_mr_final { get; set; }

        [ForeignKey("UnidadeMedidaMarcador")]
        public int? id_un_di_marcador_fk { get; set; }

        [StringLength(2)]
        public string tp_deslocamento1 { get; set; }

        public float nr_deslocamento1 { get; set; }

        [ForeignKey("UnidadeMedidaDes1")]
        public int? id_un_deslocamento1_fk { get; set; }

        [StringLength(2)]
        public string tp_deslocamento2 { get; set; }

        public float nr_deslocamento2 { get; set; }

        [ForeignKey("UnidadeMedidaDes2")]
        public int? id_un_deslocamento2_fk { get; set; }

        [ForeignKey("Conjunto")]
        public int? id_conjunto_fk { get; set; }

        [ForeignKey("Centro")]
        public int? id_centro_fk { get; set; }

        [ForeignKey("CentroTrabalho")]
        public int? id_ct_trabalho_fk { get; set; }

        [ForeignKey("Localizacao")]
        public int? id_ct_planejamento_fk { get; set; }

        [ForeignKey("GpPlanejamento")]
        public int? id_gp_planejamento_fk { get; set; }

        [ForeignKey("CentroCusto")]
        public int? id_ct_custo_fk { get; set; }

        [StringLength(4)]
        public string ar_contabil { get; set; }

        [ForeignKey("CodigoAbc")]
        public int? id_cd_abc_fk { get; set; }

        [ForeignKey("PerfilCatalogo")]
        public int? id_perfil_fk { get; set; }

        [ForeignKey("Frota")]
        public int? id_frota_fk { get; set; }

        [ForeignKey("Trem")]
        public int? id_trem_fk { get; set; }

        [ForeignKey("Carro")]
        public int? id_carro_fk { get; set; }

        [ForeignKey("Sistema")]
        public int? id_sistema_fk { get; set; }

        [ForeignKey("Complemento")]
        public int? id_complemento_fk { get; set; }

        [ForeignKey("Posicao")]
        public int? id_posicao_fk { get; set; }

        [ForeignKey("Zona")]
        public int? id_zona_fk { get; set; }

        [ForeignKey("Linha")]
        public int? id_linha_fk { get; set; }

        [ForeignKey("GrCodeSistema")]
        public int? id_grcode_sistema_fk { get; set; }

        [StringLength(22)]
        public string cd_obj { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public CentroLocalizacao Centro { get; set; }
        public CentroCusto CentroCusto { get; set; }
        public CentroLocalizacao CentroLocalizacao { get; set; }
        public CodigoABC CodigoAbc { get; set; }
        public GrupoPlanejamento GpPlanejamento { get; set; }
        public CentroLocalizacao Localizacao { get; set; }
        public virtual Marco MarcoPartida { get; set; }
        public virtual Marco MarcoFinal { get; set; }
        public ModeloLinear ModeloLinear { get; set; }
        public Perfil PerfilCatalogo { get; set; }
        public Material Conjunto { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
        public UnidadeMedida UnidadeMedidaPeso { get; set; }
        public UnidadeMedida UnidadeMedidaMarcador { get; set; }
        public UnidadeMedida UnidadeMedidaDes1 { get; set; }
        public UnidadeMedida UnidadeMedidaDes2 { get; set; }
        public LocalInstalacao LocalInstalacaoSuperior { get; set; }
        public Linha Linha { get; set; }
        public Frota Frota { get; set; }
        public Trem Trem { get; set; }
        public Carro Carro { get; set; }
        public Sistema Sistema { get; set; }
        public Complemento Complemento { get; set; }
        public Posicao Posicao { get; set; }
        public Zona Zona { get; set; }
        public GrupoCode GrCodeSistema { get; set; }
    }
}