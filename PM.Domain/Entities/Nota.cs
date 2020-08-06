using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OONota")]
    public class Nota : EntityTypeConfiguration<Nota>
    {
        public Nota() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_nota { get; set; }

        [StringLength(12)]
        public string cd_nota_sap { get; set; }

        [ForeignKey("TipoNota")]
        [Required]
        public int id_tp_nota_fk { get; set; }

        [ForeignKey("LocalInstalacao")]
        public int? id_local_inst_fk { get; set; }

        [ForeignKey("LocalInstPrinc")]
        public int? id_local_inst_princ_fk { get; set; }

        [ForeignKey("NotaReferencia")]
        public int? id_nota_referencia_fk { get; set; }

        [ForeignKey("StatusSistema")]
        public int? id_st_sistema_fk { get; set; }

        [ForeignKey("CodeSintoma")]
        public int? id_code_sintoma_fk { get; set; }

        

        [ForeignKey("Prioridade")]
        public int? id_prioridade_fk { get; set; }

        [ForeignKey("CentroTrabalho")]
        [Required]
        public int id_centro_trabalho_fk { get; set; }

        [ForeignKey("ElementoPEP")]
        public int? id_elemento_pep_fk { get; set; }

        [ForeignKey("Equipamento")]
        public int? id_equipamento_fk { get; set; }

        [ForeignKey("Material")]
        public int? id_material_fk { get; set; }

        [ForeignKey("UnidadeMedidaTempoPrevisto")]
        public int? id_un_medid_tempo_prev_fk { get; set; }

        [ForeignKey("StatusPericia")]
        public int? id_st_pericia_fk { get; set; }

        [ForeignKey("StatusCopese")]
        public int? id_st_copese_fk { get; set; }

        [ForeignKey("EventoGerador")]
        public int? id_ev_gerador_fk { get; set; }

        [StringLength(1000)]
        public string ds_observacao { get; set; }

        [ForeignKey("EmpregadoPNAcionado")]
        public int? id_pn_acionado_fk { get; set; }

        [ForeignKey("CentroTrabCiACionado")]
        public int? id_ci_acionado_fk { get; set; }

        [ForeignKey("EmpregadoReprAcionado")]
        public int? id_pl_repres_acionado_fk { get; set; }

        [ForeignKey("EmpregadoReprAcionado2")]
        public int? id_pl_repres_acionado2_fk { get; set; }

        [ForeignKey("EmpregadoReprAcionado3")]
        public int? id_pl_repres_acionado3_fk { get; set; }

        [ForeignKey("EmpregadoReprAcionado4")]

        public int? id_pl_repres_acionado4_fk { get; set; }

        [StringLength(40)]
        public string ds_descricao { get; set; }

        [ForeignKey("Empregado")]
        public int? id_notificador_fk { get; set; }

        [StringLength(1)]
        public string sg_local { get; set; }

        [ForeignKey("Diagnostico")]
        public int? id_diagnostico_fk { get; set; }

        [StringLength(20)]
        public string mc_inicial { get; set; }

        public decimal? di_marco_inicial { get; set; }

        public decimal? co_comprimento { get; set; }

        public bool? st_if_oper_maior_cinco_min { get; set; }

        public bool? st_in_notavel { get; set; }

        public bool? st_fumaca { get; set; }

        public bool? st_reboque { get; set; }

        public decimal? qt_lote { get; set; }

        public float? tm_previsto { get; set; }

        [StringLength(40)]
        public string nm_cliente { get; set; }

        public string nr_contrato { get; set; }

        [StringLength(12)]
        public string cd_bo_metro { get; set; }

        [StringLength(50)]
        public string ds_bo_metro { get; set; }

        [StringLength(12)]
        public string cd_bo_ssp { get; set; }

        [StringLength(50)]
        public string ds_bo_ssp { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? dt_hora_nota { get; set; }

        public int? id_nota_vinculo_fk { get; set; }

        [ForeignKey("Linha")]
        public int? id_linha_fk { get; set; }

        [ForeignKey("EntregaTrem")]
        public int? id_entrega_trem_fk { get; set; }

        [ForeignKey("Programacao")]
        public int? id_programacao_fk { get; set; }

        public DateTime? dt_hora_programada { get; set; }

        [ForeignKey("CodeTpServico")]
        public int? id_code_tp_servico_fk { get; set; }

        [ForeignKey("Solicitante")]
        public int? id_solicitante_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public TipoNota TipoNota { get; set; }
        public LocalInstalacao LocalInstalacao { get; set; }
        public LocalInstalacao LocalInstPrinc { get; set; }
        public Nota NotaReferencia { get; set; }
        public StatusSistema StatusSistema { get; set; }
        public virtual ICollection<StatusUsuario> StatusUsuarios { get; set; }
        public Code CodeSintoma { get; set; }
        public Prioridade Prioridade { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
        public ElementoPEP ElementoPEP { get; set; }
        public Equipamento Equipamento { get; set; }
        public Material Material { get; set; }
        public Diagnostico Diagnostico { get; set; }
        public ICollection<Nota> NotasVinculadas { get; set; }
        public ICollection<MedidaNota> MedidasNota { get; set; }
        public UnidadeMedida UnidadeMedidaTempoPrevisto { get; set; }
        public StatusPericia StatusPericia { get; set; }
        public StatusCopese StatusCopese { get; set; }
        public EventoGerador EventoGerador { get; set; }
        public Empregado Empregado { get; set; }
        public Linha Linha { get; set; }
        public Empregado EmpregadoPNAcionado { get; set; }
        public CentroTrabalho CentroTrabCiACionado { get; set; }
        public Empregado EmpregadoReprAcionado { get; set; }
        public Empregado EmpregadoReprAcionado2 { get; set; }
        public Empregado EmpregadoReprAcionado3 { get; set; }
        public Empregado EmpregadoReprAcionado4 { get; set; }
        public EntregaTrem EntregaTrem { get; set; }

        public Programacao Programacao { get; set; }

        public Code CodeTpServico { get; set; }
        public Empregado Solicitante { get; set; }
    }
}