namespace PM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "OO0009.OOAreaOperacional",
                c => new
                    {
                        id_ar_operacional = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 3),
                        ds_ar_operacional = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.id_ar_operacional);
            
            CreateTable(
                "OO0009.OOCalendarioFabrica",
                c => new
                    {
                        id_calendario_fabrica = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        dt_valido_desde_ano = c.DateTime(nullable: false),
                        dt_valido_ate_ano = c.DateTime(nullable: false),
                        tb_segunda = c.Decimal(nullable: false, precision: 1, scale: 0),
                        tb_terca = c.Decimal(nullable: false, precision: 1, scale: 0),
                        tb_quarta = c.Decimal(nullable: false, precision: 1, scale: 0),
                        tb_quinta = c.Decimal(nullable: false, precision: 1, scale: 0),
                        tb_sexta = c.Decimal(nullable: false, precision: 1, scale: 0),
                        tb_sabado = c.Decimal(nullable: false, precision: 1, scale: 0),
                        tb_domingo = c.Decimal(nullable: false, precision: 1, scale: 0),
                        tb_feriado = c.Decimal(nullable: false, precision: 1, scale: 0),
                        dt_ativo_desde_ano = c.DateTime(nullable: false),
                        dt_ativo_ate_ano = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_calendario_fabrica);
            
            CreateTable(
                "OO0009.OOCapacidadePessoal",
                c => new
                    {
                        id_capacidade_pessoal = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_capacidade_fk = c.Decimal(precision: 10, scale: 0),
                        id_empregado_fk = c.Decimal(precision: 10, scale: 0),
                        dt_inicio = c.DateTime(nullable: false),
                        dt_fim = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_capacidade_pessoal)
                .ForeignKey("OO0009.OOCapacidade", t => t.id_capacidade_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_empregado_fk)
                .Index(t => t.id_capacidade_fk)
                .Index(t => t.id_empregado_fk);
            
            CreateTable(
                "OO0009.OOCapacidade",
                c => new
                    {
                        id_capacidade = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_centro_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_trabalho_fk = c.Decimal(precision: 10, scale: 0),
                        cd_sap = c.String(maxLength: 3),
                        id_tp_capacidade_fk = c.Decimal(precision: 10, scale: 0),
                        cr_excluida_planejamento = c.Decimal(nullable: false, precision: 1, scale: 0),
                        cr_programacao = c.Decimal(nullable: false, precision: 1, scale: 0),
                        cr_sobrecarga = c.String(maxLength: 3),
                        cr_capacidade_operacao = c.Decimal(nullable: false, precision: 1, scale: 0),
                        id_calendario_fk = c.Decimal(precision: 10, scale: 0),
                        nr_capacidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id_un_capacidade_fk = c.Decimal(precision: 10, scale: 0),
                        id_un_base_capacidade_fk = c.Decimal(precision: 10, scale: 0),
                        gr_utilizacao = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_gp_planejamento_fk = c.Decimal(precision: 10, scale: 0),
                        hr_fim_capacidade = c.DateTime(nullable: false),
                        hr_inicio_capacidade = c.DateTime(nullable: false),
                        hr_intervalo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_capacidade)
                .ForeignKey("OO0009.OOCalendarioFabrica", t => t.id_calendario_fk)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_centro_fk)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ct_trabalho_fk)
                .ForeignKey("OO0009.OOGrupoPlanejamento", t => t.id_gp_planejamento_fk)
                .ForeignKey("OO0009.OOTipoCapacidade", t => t.id_tp_capacidade_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_base_capacidade_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_capacidade_fk)
                .Index(t => t.id_centro_fk)
                .Index(t => t.id_ct_trabalho_fk)
                .Index(t => t.id_tp_capacidade_fk)
                .Index(t => t.id_calendario_fk)
                .Index(t => t.id_un_capacidade_fk)
                .Index(t => t.id_un_base_capacidade_fk)
                .Index(t => t.id_gp_planejamento_fk);
            
            CreateTable(
                "OO0009.OOCentroLocalizacao",
                c => new
                    {
                        id_ct_localizacao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 4),
                        ds_ct_localizacao = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id_ct_localizacao);
            
            CreateTable(
                "OO0009.OOCentroTrabalho",
                c => new
                    {
                        id_ct_trabalho = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 8),
                        ct_trabalho = c.String(maxLength: 8),
                        id_centro_fk = c.Decimal(precision: 10, scale: 0),
                        id_tp_ct_trabalho_fk = c.Decimal(precision: 10, scale: 0),
                        ds_ct_trabalho = c.String(maxLength: 40),
                        id_localizacao_fk = c.Decimal(precision: 10, scale: 0),
                        cd_rs_ct_trabalho = c.String(maxLength: 3),
                        cd_ch_utilizacao_lista = c.String(maxLength: 3),
                        ch_controle = c.String(maxLength: 4),
                        cr_ch_controle = c.Decimal(nullable: false, precision: 1, scale: 0),
                        dt_inicio = c.DateTime(nullable: false),
                        dt_fim = c.DateTime(nullable: false),
                        id_ct_custo_fk = c.Decimal(precision: 10, scale: 0),
                        ar_contabil = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.id_ct_trabalho)
                .ForeignKey("OO0009.OOCentroCusto", t => t.id_ct_custo_fk)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_centro_fk)
                .ForeignKey("OO0009.OOLocalizacao", t => t.id_localizacao_fk)
                .ForeignKey("OO0009.OOTipoCentroTrabalho", t => t.id_tp_ct_trabalho_fk)
                .Index(t => t.id_centro_fk)
                .Index(t => t.id_tp_ct_trabalho_fk)
                .Index(t => t.id_localizacao_fk)
                .Index(t => t.id_ct_custo_fk);
            
            CreateTable(
                "OO0009.OOCentroCusto",
                c => new
                    {
                        id_centro_custo = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 10),
                        ds_centro_custo = c.String(maxLength: 30),
                        ds_completa_centro_custo = c.String(maxLength: 255),
                        nm_usuario_alteracao = c.String(maxLength: 12),
                        dt_alteracao_registro = c.DateTime(nullable: false),
                        nr_fator = c.Decimal(nullable: false, precision: 18, scale: 2),
                        sg_centro_custo = c.String(maxLength: 15),
                        st_ativo = c.Decimal(nullable: false, precision: 1, scale: 0),
                        ar_centro_custo = c.String(maxLength: 15),
                        dt_carga = c.DateTime(nullable: false),
                        ct_custo_anterior = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.id_centro_custo);
            
            CreateTable(
                "OO0009.OOLocalizacao",
                c => new
                    {
                        id_localizacao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_ct_localizacao_fk = c.Decimal(precision: 10, scale: 0),
                        cd_sap = c.String(maxLength: 4),
                        ds_localizacao = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.id_localizacao)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_ct_localizacao_fk)
                .Index(t => t.id_ct_localizacao_fk);
            
            CreateTable(
                "OO0009.OOTipoCentroTrabalho",
                c => new
                    {
                        id_tp_centro_trabalho = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 10),
                        ds_tp_centro_trabalho = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id_tp_centro_trabalho);
            
            CreateTable(
                "OO0009.OOGrupoPlanejamento",
                c => new
                    {
                        id_gp_planejamento = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 3),
                        ds_gp_planejamento = c.String(maxLength: 50),
                        id_ct_localizacao_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_gp_planejamento)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_ct_localizacao_fk)
                .Index(t => t.id_ct_localizacao_fk);
            
            CreateTable(
                "OO0009.OOTipoCapacidade",
                c => new
                    {
                        id_tp_capacidade = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 10),
                        ds_tp_capacidade = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id_tp_capacidade);
            
            CreateTable(
                "OO0009.OOUnidadeMedida",
                c => new
                    {
                        id_unidade_medida = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_unidade_medida = c.String(maxLength: 3),
                        tx_relativo_dimensao = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.id_unidade_medida);
            
            CreateTable(
                "OO0009.OOEmpregado",
                c => new
                    {
                        id_empregado = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        rg_empregado = c.String(maxLength: 12),
                        nm_funcionario = c.String(nullable: false, maxLength: 30),
                        sb_funcionario = c.String(nullable: false, maxLength: 50),
                        em_usuario = c.String(nullable: false, maxLength: 70),
                        id_ct_custo_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        st_ativo = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.id_empregado)
                .ForeignKey("OO0009.OOCentroCusto", t => t.id_ct_custo_fk, cascadeDelete: true)
                .Index(t => t.id_ct_custo_fk);
            
            CreateTable(
                "OO0009.OOCarro",
                c => new
                    {
                        id_carro = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        nm_carro = c.String(maxLength: 20),
                        id_trem_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_carro)
                .ForeignKey("OO0009.OOTrem", t => t.id_trem_fk)
                .Index(t => t.id_trem_fk);
            
            CreateTable(
                "OO0009.OOTrem",
                c => new
                    {
                        id_trem = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 3),
                        id_doc_medicao_fk = c.Decimal(precision: 10, scale: 0),
                        nm_trem = c.String(maxLength: 20),
                        id_frota_fk = c.Decimal(precision: 10, scale: 0),
                        id_linha_origem_fk = c.Decimal(precision: 10, scale: 0),
                        id_patio_fk = c.Decimal(precision: 10, scale: 0),
                        id_linha_atual_fk = c.Decimal(precision: 10, scale: 0),
                        st_manobra = c.Decimal(nullable: false, precision: 1, scale: 0),
                        st_trem = c.Decimal(precision: 10, scale: 0),
                        st_disponivel = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.id_trem)
                .ForeignKey("OO0009.OODocumento", t => t.id_doc_medicao_fk)
                .ForeignKey("OO0009.OOFrota", t => t.id_frota_fk)
                .ForeignKey("OO0009.OOLinha", t => t.id_linha_atual_fk)
                .ForeignKey("OO0009.OOLinha", t => t.id_linha_origem_fk)
                .ForeignKey("OO0009.OOPatio", t => t.id_patio_fk)
                .ForeignKey("OO0009.OOStatusTrem", t => t.st_trem)
                .Index(t => t.id_doc_medicao_fk)
                .Index(t => t.id_frota_fk)
                .Index(t => t.id_linha_origem_fk)
                .Index(t => t.id_patio_fk)
                .Index(t => t.id_linha_atual_fk)
                .Index(t => t.st_trem);
            
            CreateTable(
                "OO0009.OODocumento",
                c => new
                    {
                        id_documento = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_tp_documento_fk = c.Decimal(precision: 10, scale: 0),
                        ds_documento = c.String(maxLength: 20),
                        id_nota_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_documento)
                .ForeignKey("OO0009.OONota", t => t.id_nota_fk)
                .ForeignKey("OO0009.OOTipoDocumento", t => t.id_tp_documento_fk)
                .Index(t => t.id_tp_documento_fk)
                .Index(t => t.id_nota_fk);
            
            CreateTable(
                "OO0009.OONota",
                c => new
                    {
                        id_nota = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_nota_sap = c.String(maxLength: 12),
                        id_tp_nota_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_local_inst_fk = c.Decimal(precision: 10, scale: 0),
                        id_local_inst_princ_fk = c.Decimal(precision: 10, scale: 0),
                        id_nota_referencia_fk = c.Decimal(precision: 10, scale: 0),
                        id_st_sistema_fk = c.Decimal(precision: 10, scale: 0),
                        id_code_sintoma_fk = c.Decimal(precision: 10, scale: 0),
                        id_prioridade_fk = c.Decimal(precision: 10, scale: 0),
                        id_centro_trabalho_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_elemento_pep_fk = c.Decimal(precision: 10, scale: 0),
                        id_equipamento_fk = c.Decimal(precision: 10, scale: 0),
                        id_material_fk = c.Decimal(precision: 10, scale: 0),
                        id_un_medid_tempo_prev_fk = c.Decimal(precision: 10, scale: 0),
                        id_st_pericia_fk = c.Decimal(precision: 10, scale: 0),
                        id_st_copese_fk = c.Decimal(precision: 10, scale: 0),
                        id_ev_gerador_fk = c.Decimal(precision: 10, scale: 0),
                        ds_observacao = c.String(maxLength: 1000),
                        id_pn_acionado_fk = c.Decimal(precision: 10, scale: 0),
                        id_ci_acionado_fk = c.Decimal(precision: 10, scale: 0),
                        id_pl_repres_acionado_fk = c.Decimal(precision: 10, scale: 0),
                        id_pl_repres_acionado2_fk = c.Decimal(precision: 10, scale: 0),
                        id_pl_repres_acionado3_fk = c.Decimal(precision: 10, scale: 0),
                        id_pl_repres_acionado4_fk = c.Decimal(precision: 10, scale: 0),
                        ds_descricao = c.String(maxLength: 40),
                        id_notificador_fk = c.Decimal(precision: 10, scale: 0),
                        sg_local = c.String(maxLength: 1),
                        id_diagnostico_fk = c.Decimal(precision: 10, scale: 0),
                        mc_inicial = c.String(maxLength: 20),
                        di_marco_inicial = c.Decimal(precision: 18, scale: 2),
                        co_comprimento = c.Decimal(precision: 18, scale: 2),
                        st_if_oper_maior_cinco_min = c.Decimal(precision: 1, scale: 0),
                        st_in_notavel = c.Decimal(precision: 1, scale: 0),
                        st_fumaca = c.Decimal(precision: 1, scale: 0),
                        st_reboque = c.Decimal(precision: 1, scale: 0),
                        qt_lote = c.Decimal(precision: 18, scale: 2),
                        tm_previsto = c.Single(),
                        nm_cliente = c.String(maxLength: 40),
                        nr_contrato = c.String(),
                        cd_bo_metro = c.String(maxLength: 12),
                        ds_bo_metro = c.String(maxLength: 50),
                        cd_bo_ssp = c.String(maxLength: 12),
                        ds_bo_ssp = c.String(maxLength: 50),
                        dt_hora_nota = c.DateTime(),
                        id_nota_vinculo_fk = c.Decimal(precision: 10, scale: 0),
                        id_linha_fk = c.Decimal(precision: 10, scale: 0),
                        id_entrega_trem_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_nota)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_centro_trabalho_fk, cascadeDelete: true)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ci_acionado_fk)
                .ForeignKey("OO0009.OOCode", t => t.id_code_sintoma_fk)
                .ForeignKey("OO0009.OODiagnostico", t => t.id_diagnostico_fk)
                .ForeignKey("OO0009.OOElementoPEP", t => t.id_elemento_pep_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_notificador_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_pn_acionado_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_pl_repres_acionado_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_pl_repres_acionado2_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_pl_repres_acionado3_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_pl_repres_acionado4_fk)
                .ForeignKey("OO0009.OOEntregaTrem", t => t.id_entrega_trem_fk)
                .ForeignKey("OO0009.OOEquipamento", t => t.id_equipamento_fk)
                .ForeignKey("OO0009.OOEventoGerador", t => t.id_ev_gerador_fk)
                .ForeignKey("OO0009.OOLinha", t => t.id_linha_fk)
                .ForeignKey("OO0009.OOLocalInstalacao", t => t.id_local_inst_fk)
                .ForeignKey("OO0009.OOLocalInstalacao", t => t.id_local_inst_princ_fk)
                .ForeignKey("OO0009.OOMaterial", t => t.id_material_fk)
                .ForeignKey("OO0009.OONota", t => t.id_nota_referencia_fk)
                .ForeignKey("OO0009.OOPrioridade", t => t.id_prioridade_fk)
                .ForeignKey("OO0009.OOStatusCopese", t => t.id_st_copese_fk)
                .ForeignKey("OO0009.OOStatusPericia", t => t.id_st_pericia_fk)
                .ForeignKey("OO0009.OOStatusSistema", t => t.id_st_sistema_fk)
                .ForeignKey("OO0009.OOTipoNota", t => t.id_tp_nota_fk, cascadeDelete: true)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_medid_tempo_prev_fk)
                .Index(t => t.id_tp_nota_fk)
                .Index(t => t.id_local_inst_fk)
                .Index(t => t.id_local_inst_princ_fk)
                .Index(t => t.id_nota_referencia_fk)
                .Index(t => t.id_st_sistema_fk)
                .Index(t => t.id_code_sintoma_fk)
                .Index(t => t.id_prioridade_fk)
                .Index(t => t.id_centro_trabalho_fk)
                .Index(t => t.id_elemento_pep_fk)
                .Index(t => t.id_equipamento_fk)
                .Index(t => t.id_material_fk)
                .Index(t => t.id_un_medid_tempo_prev_fk)
                .Index(t => t.id_st_pericia_fk)
                .Index(t => t.id_st_copese_fk)
                .Index(t => t.id_ev_gerador_fk)
                .Index(t => t.id_pn_acionado_fk)
                .Index(t => t.id_ci_acionado_fk)
                .Index(t => t.id_pl_repres_acionado_fk)
                .Index(t => t.id_pl_repres_acionado2_fk)
                .Index(t => t.id_pl_repres_acionado3_fk)
                .Index(t => t.id_pl_repres_acionado4_fk)
                .Index(t => t.id_notificador_fk)
                .Index(t => t.id_diagnostico_fk)
                .Index(t => t.id_linha_fk)
                .Index(t => t.id_entrega_trem_fk);
            
            CreateTable(
                "OO0009.OOCode",
                c => new
                    {
                        id_code = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 4),
                        ds_code = c.String(maxLength: 40),
                        id_gr_code_fk = c.Decimal(precision: 10, scale: 0),
                        id_prioridade_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_code)
                .ForeignKey("OO0009.OOGrupoCode", t => t.id_gr_code_fk)
                .ForeignKey("OO0009.OOPrioridade", t => t.id_prioridade_fk)
                .Index(t => t.id_gr_code_fk)
                .Index(t => t.id_prioridade_fk);
            
            CreateTable(
                "OO0009.OOGrupoCode",
                c => new
                    {
                        id_gp_code = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 8),
                        ds_gp_code = c.String(maxLength: 40),
                        st_gp_code = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.id_gp_code);
            
            CreateTable(
                "OO0009.OOCatalogo",
                c => new
                    {
                        id_catalogo = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 9),
                    })
                .PrimaryKey(t => t.id_catalogo);
            
            CreateTable(
                "OO0009.OOPerfil",
                c => new
                    {
                        id_perfil = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 9),
                        ds_perfil = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.id_perfil);
            
            CreateTable(
                "OO0009.OOPrioridade",
                c => new
                    {
                        id_prioridade = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_prioridade = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id_prioridade);
            
            CreateTable(
                "OO0009.OODiagnostico",
                c => new
                    {
                        id_diagnostico = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_diagnostico = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id_diagnostico);
            
            CreateTable(
                "OO0009.OOElementoPEP",
                c => new
                    {
                        id_elemento_pep = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_elemento_pep = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id_elemento_pep);
            
            CreateTable(
                "OO0009.OOEntregaTrem",
                c => new
                    {
                        id_entrega = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_motivo_entrega_ocor_fk = c.Decimal(precision: 10, scale: 0),
                        id_motivo_entrega_prog_fk = c.Decimal(precision: 10, scale: 0),
                        id_motivo_entrega_inspecao_fk = c.Decimal(precision: 10, scale: 0),
                        id_trem_fk = c.Decimal(precision: 10, scale: 0),
                        dt_entrega = c.DateTime(nullable: false),
                        hr_entrega = c.DateTime(nullable: false),
                        id_patio_fk = c.Decimal(precision: 10, scale: 0),
                        id_lin_entrega = c.Decimal(precision: 10, scale: 0),
                        id_ct_trab = c.Decimal(precision: 10, scale: 0),
                        id_resp_entrega = c.Decimal(precision: 10, scale: 0),
                        dt_cancelamento = c.DateTime(nullable: false),
                        hr_cancelamento = c.DateTime(nullable: false),
                        id_resp_cancelamento = c.Decimal(precision: 10, scale: 0),
                        dt_liberacao = c.DateTime(nullable: false),
                        hr_liberacao = c.DateTime(nullable: false),
                        id_resp_liberacao = c.Decimal(precision: 10, scale: 0),
                        id_entrega_nota_fk = c.Decimal(precision: 10, scale: 0),
                        id_entrega_prog_fk = c.Decimal(precision: 10, scale: 0),
                        ds_motivo_cancelamento = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.id_entrega)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ct_trab)
                .ForeignKey("OO0009.OOLinha", t => t.id_lin_entrega)
                .ForeignKey("OO0009.OOMotivoEntrega", t => t.id_motivo_entrega_inspecao_fk)
                .ForeignKey("OO0009.OOMotivoEntrega", t => t.id_motivo_entrega_ocor_fk)
                .ForeignKey("OO0009.OOMotivoEntrega", t => t.id_motivo_entrega_prog_fk)
                .ForeignKey("OO0009.OOPatio", t => t.id_patio_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_resp_cancelamento)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_resp_entrega)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_resp_liberacao)
                .ForeignKey("OO0009.OOTrem", t => t.id_trem_fk)
                .Index(t => t.id_motivo_entrega_ocor_fk)
                .Index(t => t.id_motivo_entrega_prog_fk)
                .Index(t => t.id_motivo_entrega_inspecao_fk)
                .Index(t => t.id_trem_fk)
                .Index(t => t.id_patio_fk)
                .Index(t => t.id_lin_entrega)
                .Index(t => t.id_ct_trab)
                .Index(t => t.id_resp_entrega)
                .Index(t => t.id_resp_cancelamento)
                .Index(t => t.id_resp_liberacao);
            
            CreateTable(
                "OO0009.OOEntregaTremNota",
                c => new
                    {
                        id_entrega_nota = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_entrega_fk = c.Decimal(precision: 10, scale: 0),
                        id_nota_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_entrega_nota)
                .ForeignKey("OO0009.OONota", t => t.id_nota_fk)
                .ForeignKey("OO0009.OOEntregaTrem", t => t.id_entrega_fk)
                .Index(t => t.id_entrega_fk)
                .Index(t => t.id_nota_fk);
            
            CreateTable(
                "OO0009.OOEntregaTremProg",
                c => new
                    {
                        id_entrega_prog = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_entrega_fk = c.Decimal(precision: 10, scale: 0),
                        id_programacao_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_entrega_prog)
                .ForeignKey("OO0009.OOProgramacao", t => t.id_programacao_fk)
                .ForeignKey("OO0009.OOEntregaTrem", t => t.id_entrega_fk)
                .Index(t => t.id_entrega_fk)
                .Index(t => t.id_programacao_fk);
            
            CreateTable(
                "OO0009.OOProgramacao",
                c => new
                    {
                        id_programacao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_tp_programacao = c.String(maxLength: 3),
                        id_trem_fk = c.Decimal(precision: 10, scale: 0),
                        dt_planej_entrega = c.DateTime(nullable: false),
                        hr_planej_entrega = c.DateTime(nullable: false),
                        id_lin_planej_entrega_fk = c.Decimal(precision: 10, scale: 0),
                        dt_prev_liberacao = c.DateTime(nullable: false),
                        hr_prev_liberacao = c.DateTime(nullable: false),
                        id_rg_programacao = c.Decimal(precision: 10, scale: 0),
                        ds_observacao = c.String(maxLength: 100),
                        dt_autorizacao = c.DateTime(nullable: false),
                        hr_autorizacao = c.DateTime(nullable: false),
                        id_rg_autorizacao = c.Decimal(precision: 10, scale: 0),
                        dt_cancelamento = c.DateTime(nullable: false),
                        hr_cancelamento = c.DateTime(nullable: false),
                        id_rg_cancelamento = c.Decimal(precision: 10, scale: 0),
                        dt_entrega = c.DateTime(nullable: false),
                        hr_entrega = c.DateTime(nullable: false),
                        dt_liberacao = c.DateTime(nullable: false),
                        hr_liberacao = c.DateTime(nullable: false),
                        id_ct_trab = c.Decimal(precision: 10, scale: 0),
                        st_programacao = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.id_programacao)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ct_trab)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_rg_autorizacao)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_rg_cancelamento)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_rg_programacao)
                .ForeignKey("OO0009.OOLinha", t => t.id_lin_planej_entrega_fk)
                .ForeignKey("OO0009.OOTrem", t => t.id_trem_fk)
                .Index(t => t.id_trem_fk)
                .Index(t => t.id_lin_planej_entrega_fk)
                .Index(t => t.id_rg_programacao)
                .Index(t => t.id_rg_autorizacao)
                .Index(t => t.id_rg_cancelamento)
                .Index(t => t.id_ct_trab);
            
            CreateTable(
                "OO0009.OOLinha",
                c => new
                    {
                        id_linha = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        nm_linha = c.String(maxLength: 20),
                        id_centro_trabalho_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_linha)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_centro_trabalho_fk)
                .Index(t => t.id_centro_trabalho_fk);
            
            CreateTable(
                "OO0009.OOMotivoEntrega",
                c => new
                    {
                        id_motivo_entrega = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_motivo_entrega = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.id_motivo_entrega);
            
            CreateTable(
                "OO0009.OOPatio",
                c => new
                    {
                        id_patio = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 12),
                        ds_patio = c.String(maxLength: 6),
                        ds_rua = c.String(maxLength: 60),
                        nr_endereco = c.String(maxLength: 10),
                        nr_cep = c.String(maxLength: 10),
                        nr_telefone = c.String(maxLength: 30),
                        nr_ramal = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.id_patio);
            
            CreateTable(
                "OO0009.OOEquipamento",
                c => new
                    {
                        id_equipamento = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 22),
                        cd_equipamento = c.String(maxLength: 18),
                        id_cg_equipamento_fk = c.Decimal(precision: 10, scale: 0),
                        ds_equipamento = c.String(maxLength: 40),
                        tp_equipamento = c.String(maxLength: 10),
                        st_sistema = c.String(maxLength: 40),
                        st_equipamento = c.String(maxLength: 40),
                        id_ct_localizacao_fk = c.Decimal(precision: 10, scale: 0),
                        cp_ordenacao = c.String(maxLength: 30),
                        id_lc_instalacao_fk = c.Decimal(precision: 10, scale: 0),
                        id_eq_superior_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        cr_mg_individual = c.Decimal(nullable: false, precision: 1, scale: 0),
                        sg_pais_produtor = c.String(maxLength: 3),
                        ds_fabricante = c.String(maxLength: 30),
                        rf_fabricante = c.String(maxLength: 30),
                        nr_serie_fabricante = c.String(maxLength: 30),
                        nr_ano_construcao = c.Decimal(nullable: false, precision: 10, scale: 0),
                        nr_mes_construcao = c.Decimal(nullable: false, precision: 10, scale: 0),
                        dt_aquisicao = c.DateTime(nullable: false),
                        dt_ini_func = c.DateTime(nullable: false),
                        dt_inicio_garantia = c.DateTime(nullable: false),
                        dt_fim_garantia = c.DateTime(nullable: false),
                        cd_herdar_garantia = c.Decimal(nullable: false, precision: 1, scale: 0),
                        nr_identif_tecnica = c.String(maxLength: 25),
                        nr_dimensao = c.String(maxLength: 18),
                        pe_bruto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id_un_peso_fk = c.Decimal(precision: 10, scale: 0),
                        id_material_fk = c.Decimal(precision: 10, scale: 0),
                        id_conjunto_fk = c.Decimal(precision: 10, scale: 0),
                        tp_veiculo = c.String(maxLength: 10),
                        nr_identif_veiculo = c.String(maxLength: 18),
                        ds_placa_veiculo = c.String(maxLength: 15),
                        nr_serie_motor = c.String(maxLength: 30),
                        cd_tp_combustivel_primario = c.String(maxLength: 12),
                        cd_tp_combustivel_secundario = c.String(maxLength: 12),
                        cd_tp_oleo = c.String(maxLength: 12),
                        id_centro_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_trabalho_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_planejamento_fk = c.Decimal(precision: 10, scale: 0),
                        id_gp_planejamento_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_custo_fk = c.Decimal(precision: 10, scale: 0),
                        ar_contabil = c.String(maxLength: 4),
                        nr_imobilizado = c.String(maxLength: 12),
                        nr_sub_imobilizado = c.String(maxLength: 4),
                        nr_patrimonio = c.String(maxLength: 25),
                        id_cd_abc_fk = c.Decimal(precision: 10, scale: 0),
                        id_perfil_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_equipamento)
                .ForeignKey("OO0009.OOCentroCusto", t => t.id_ct_custo_fk)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_centro_fk)
                .ForeignKey("OO0009.OOCentroPlanejamento", t => t.id_ct_planejamento_fk)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ct_trabalho_fk)
                .ForeignKey("OO0009.OOCategoriaEquipamento", t => t.id_cg_equipamento_fk)
                .ForeignKey("OO0009.OOCodigoABC", t => t.id_cd_abc_fk)
                .ForeignKey("OO0009.OOMaterial", t => t.id_conjunto_fk)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_ct_localizacao_fk)
                .ForeignKey("OO0009.OOGrupoPlanejamento", t => t.id_gp_planejamento_fk)
                .ForeignKey("OO0009.OOLocalInstalacao", t => t.id_lc_instalacao_fk)
                .ForeignKey("OO0009.OOMaterial", t => t.id_material_fk)
                .ForeignKey("OO0009.OOPerfil", t => t.id_perfil_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_peso_fk)
                .Index(t => t.id_cg_equipamento_fk)
                .Index(t => t.id_ct_localizacao_fk)
                .Index(t => t.id_lc_instalacao_fk)
                .Index(t => t.id_un_peso_fk)
                .Index(t => t.id_material_fk)
                .Index(t => t.id_conjunto_fk)
                .Index(t => t.id_centro_fk)
                .Index(t => t.id_ct_trabalho_fk)
                .Index(t => t.id_ct_planejamento_fk)
                .Index(t => t.id_gp_planejamento_fk)
                .Index(t => t.id_ct_custo_fk)
                .Index(t => t.id_cd_abc_fk)
                .Index(t => t.id_perfil_fk);
            
            CreateTable(
                "OO0009.OOCentroPlanejamento",
                c => new
                    {
                        id_ct_planejamento = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 4),
                        ds_ct_planejamento = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id_ct_planejamento);
            
            CreateTable(
                "OO0009.OOCategoriaEquipamento",
                c => new
                    {
                        id_cg_equipamento = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 1),
                        ds_cg_equipamento = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.id_cg_equipamento);
            
            CreateTable(
                "OO0009.OOCodigoABC",
                c => new
                    {
                        id_abc = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 1),
                        ds_abc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id_abc);
            
            CreateTable(
                "OO0009.OOMaterial",
                c => new
                    {
                        id_material = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_material = c.String(maxLength: 50),
                        tp_material = c.String(maxLength: 4),
                        cd_unidade_medida = c.String(maxLength: 3),
                        ds_unidade_medida = c.String(maxLength: 30),
                        cd_classe_avaliacao = c.String(maxLength: 4),
                        dt_criacao = c.DateTime(nullable: false),
                        cd_material_antigo = c.String(maxLength: 60),
                        rg_empregado = c.String(maxLength: 10),
                        dt_ultima_alteracao = c.DateTime(nullable: false),
                        ds_tipo_material = c.String(maxLength: 30),
                        ds_detalhada = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.id_material);
            
            CreateTable(
                "OO0009.OOLocalInstalacao",
                c => new
                    {
                        id_lc_instalacao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 22),
                        ds_lc_instalacao = c.String(maxLength: 40),
                        cg_lc_instalacao = c.String(maxLength: 1),
                        cd_estrutura = c.String(maxLength: 5),
                        cd_tp_lc_instalacao = c.String(maxLength: 10),
                        id_ct_localizacao_fk = c.Decimal(precision: 10, scale: 0),
                        st_sistema = c.String(maxLength: 40),
                        st_usuario = c.String(maxLength: 40),
                        ds_rua = c.String(maxLength: 60),
                        nr_endereco = c.String(maxLength: 10),
                        cd_postal = c.String(maxLength: 10),
                        nr_telefone = c.String(maxLength: 30),
                        nr_ramal = c.String(maxLength: 10),
                        id_lc_inst_superior_fk = c.Decimal(precision: 10, scale: 0),
                        cr_mg_permitida = c.Decimal(nullable: false, precision: 1, scale: 0),
                        cr_mg_individual = c.Decimal(nullable: false, precision: 1, scale: 0),
                        cp_ordenacao = c.String(maxLength: 30),
                        sg_pais_produtor = c.String(maxLength: 3),
                        ds_fabricante = c.String(maxLength: 30),
                        ds_tp_fabricante = c.String(maxLength: 20),
                        rf_fabricante = c.String(maxLength: 30),
                        nr_serie_fabricante = c.String(maxLength: 30),
                        nr_ano_construcao = c.Decimal(nullable: false, precision: 10, scale: 0),
                        nr_mes_construcao = c.Decimal(nullable: false, precision: 10, scale: 0),
                        dt_aquisicao = c.DateTime(nullable: false),
                        dt_entrada_servico = c.DateTime(nullable: false),
                        dt_inicio_garantia = c.DateTime(nullable: false),
                        dt_fim_garantia = c.DateTime(nullable: false),
                        nr_dimensao = c.String(maxLength: 18),
                        pe_bruto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id_un_peso_fk = c.Decimal(precision: 10, scale: 0),
                        id_md_rf_linear_fk = c.Decimal(precision: 10, scale: 0),
                        pt_partida = c.String(maxLength: 18),
                        pt_final = c.String(maxLength: 18),
                        nr_comprimento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        un_medida = c.String(maxLength: 3),
                        id_mr_partida_fk = c.Decimal(precision: 10, scale: 0),
                        id_mr_final_fk = c.Decimal(precision: 10, scale: 0),
                        nr_di_mr_partida = c.String(maxLength: 18),
                        nr_di_mr_final = c.String(maxLength: 18),
                        id_un_di_marcador_fk = c.Decimal(precision: 10, scale: 0),
                        tp_deslocamento1 = c.String(maxLength: 2),
                        nr_deslocamento1 = c.Single(nullable: false),
                        id_un_deslocamento1_fk = c.Decimal(precision: 10, scale: 0),
                        tp_deslocamento2 = c.String(maxLength: 2),
                        nr_deslocamento2 = c.Single(nullable: false),
                        id_un_deslocamento2_fk = c.Decimal(precision: 10, scale: 0),
                        id_conjunto_fk = c.Decimal(precision: 10, scale: 0),
                        id_centro_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_trabalho_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_planejamento_fk = c.Decimal(precision: 10, scale: 0),
                        id_gp_planejamento_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_custo_fk = c.Decimal(precision: 10, scale: 0),
                        ar_contabil = c.String(maxLength: 4),
                        id_cd_abc_fk = c.Decimal(precision: 10, scale: 0),
                        id_perfil_fk = c.Decimal(precision: 10, scale: 0),
                        id_frota_fk = c.Decimal(precision: 10, scale: 0),
                        id_trem_fk = c.Decimal(precision: 10, scale: 0),
                        id_carro_fk = c.Decimal(precision: 10, scale: 0),
                        id_sistema_fk = c.Decimal(precision: 10, scale: 0),
                        id_complemento_fk = c.Decimal(precision: 10, scale: 0),
                        id_posicao_fk = c.Decimal(precision: 10, scale: 0),
                        id_zona_fk = c.Decimal(precision: 10, scale: 0),
                        id_linha_fk = c.Decimal(precision: 10, scale: 0),
                        id_grcode_sistema_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_lc_instalacao)
                .ForeignKey("OO0009.OOCarro", t => t.id_carro_fk)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_centro_fk)
                .ForeignKey("OO0009.OOCentroCusto", t => t.id_ct_custo_fk)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_ct_localizacao_fk)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ct_trabalho_fk)
                .ForeignKey("OO0009.OOCodigoABC", t => t.id_cd_abc_fk)
                .ForeignKey("OO0009.OOComplemento", t => t.id_complemento_fk)
                .ForeignKey("OO0009.OOMaterial", t => t.id_conjunto_fk)
                .ForeignKey("OO0009.OOFrota", t => t.id_frota_fk)
                .ForeignKey("OO0009.OOGrupoPlanejamento", t => t.id_gp_planejamento_fk)
                .ForeignKey("OO0009.OOGrupoCode", t => t.id_grcode_sistema_fk)
                .ForeignKey("OO0009.OOLinha", t => t.id_linha_fk)
                .ForeignKey("OO0009.OOLocalInstalacao", t => t.id_lc_inst_superior_fk)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_ct_planejamento_fk)
                .ForeignKey("OO0009.OOMarco", t => t.id_mr_final_fk)
                .ForeignKey("OO0009.OOMarco", t => t.id_mr_partida_fk)
                .ForeignKey("OO0009.OOModeloLinear", t => t.id_md_rf_linear_fk)
                .ForeignKey("OO0009.OOPerfil", t => t.id_perfil_fk)
                .ForeignKey("OO0009.OOPosicao", t => t.id_posicao_fk)
                .ForeignKey("OO0009.OOSistema", t => t.id_sistema_fk)
                .ForeignKey("OO0009.OOTrem", t => t.id_trem_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_deslocamento1_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_deslocamento2_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_di_marcador_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_peso_fk)
                .ForeignKey("OO0009.OOZona", t => t.id_zona_fk)
                .Index(t => t.id_ct_localizacao_fk)
                .Index(t => t.id_lc_inst_superior_fk)
                .Index(t => t.id_un_peso_fk)
                .Index(t => t.id_md_rf_linear_fk)
                .Index(t => t.id_mr_partida_fk)
                .Index(t => t.id_mr_final_fk)
                .Index(t => t.id_un_di_marcador_fk)
                .Index(t => t.id_un_deslocamento1_fk)
                .Index(t => t.id_un_deslocamento2_fk)
                .Index(t => t.id_conjunto_fk)
                .Index(t => t.id_centro_fk)
                .Index(t => t.id_ct_trabalho_fk)
                .Index(t => t.id_ct_planejamento_fk)
                .Index(t => t.id_gp_planejamento_fk)
                .Index(t => t.id_ct_custo_fk)
                .Index(t => t.id_cd_abc_fk)
                .Index(t => t.id_perfil_fk)
                .Index(t => t.id_frota_fk)
                .Index(t => t.id_trem_fk)
                .Index(t => t.id_carro_fk)
                .Index(t => t.id_sistema_fk)
                .Index(t => t.id_complemento_fk)
                .Index(t => t.id_posicao_fk)
                .Index(t => t.id_zona_fk)
                .Index(t => t.id_linha_fk)
                .Index(t => t.id_grcode_sistema_fk);
            
            CreateTable(
                "OO0009.OOComplemento",
                c => new
                    {
                        id_complemento = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_complemento = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.id_complemento);
            
            CreateTable(
                "OO0009.OOFrota",
                c => new
                    {
                        id_frota = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        nm_frota = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.id_frota);
            
            CreateTable(
                "OO0009.OOMarco",
                c => new
                    {
                        id_marcador = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_md_rf_linear_fk = c.Decimal(precision: 10, scale: 0),
                        cd_sap = c.String(maxLength: 18),
                        ds_marcador = c.String(maxLength: 40),
                        id_tp_marcador_fk = c.Decimal(precision: 10, scale: 0),
                        pt_rf_marcador = c.String(maxLength: 18),
                        nr_comprimento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id_un_comprimento_fk = c.Decimal(precision: 10, scale: 0),
                        cd_lc_instalacao_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_marcador)
                .ForeignKey("OO0009.OOLocalInstalacao", t => t.cd_lc_instalacao_fk)
                .ForeignKey("OO0009.OOModeloLinear", t => t.id_md_rf_linear_fk)
                .ForeignKey("OO0009.OOTipoMarcador", t => t.id_tp_marcador_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_comprimento_fk)
                .Index(t => t.id_md_rf_linear_fk)
                .Index(t => t.id_tp_marcador_fk)
                .Index(t => t.id_un_comprimento_fk)
                .Index(t => t.cd_lc_instalacao_fk);
            
            CreateTable(
                "OO0009.OOModeloLinear",
                c => new
                    {
                        id_md_rf_linear = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 30),
                        ds_modelo = c.String(maxLength: 40),
                        tp_modelo = c.String(maxLength: 4),
                        cd_di_marcador = c.Decimal(nullable: false, precision: 1, scale: 0),
                        id_un_di_marcador_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_md_rf_linear)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_di_marcador_fk)
                .Index(t => t.id_un_di_marcador_fk);
            
            CreateTable(
                "OO0009.OOTipoMarcador",
                c => new
                    {
                        id_tp_marcador = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 2),
                        ds_tp_marcador = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id_tp_marcador);
            
            CreateTable(
                "OO0009.OOPosicao",
                c => new
                    {
                        id_posicao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_posicao = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.id_posicao);
            
            CreateTable(
                "OO0009.OOSistema",
                c => new
                    {
                        id_sistema = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        nm_sistema = c.String(maxLength: 20),
                        id_frota_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_sistema)
                .ForeignKey("OO0009.OOFrota", t => t.id_frota_fk)
                .Index(t => t.id_frota_fk);
            
            CreateTable(
                "OO0009.OOZona",
                c => new
                    {
                        id_zona = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        nm_zona = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.id_zona);
            
            CreateTable(
                "OO0009.OOPontoMedicao",
                c => new
                    {
                        id_pt_medicao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 12),
                        ic_equip_li = c.String(maxLength: 3),
                        lc_instalacao = c.String(maxLength: 40),
                        id_cg_pt_medicao_fk = c.Decimal(precision: 10, scale: 0),
                        ds_pt_medicao = c.String(maxLength: 40),
                        ds_item_medicao = c.String(maxLength: 20),
                        cd_caracteristica = c.String(maxLength: 30),
                        nr_casa_decimal = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_un_medida_fk = c.Decimal(precision: 10, scale: 0),
                        ic_contador = c.Decimal(nullable: false, precision: 1, scale: 0),
                        ic_cont_decrescente = c.Decimal(nullable: false, precision: 1, scale: 0),
                        at_anual_contador = c.Single(nullable: false),
                        cr_transferencia = c.Decimal(nullable: false, precision: 1, scale: 0),
                        nr_total_contador = c.Single(nullable: false),
                        nr_valor_teorico = c.Single(nullable: false),
                        nr_limite_inferior = c.Single(nullable: false),
                        nr_limite_superior = c.Single(nullable: false),
                        id_un_intervalo_fk = c.Decimal(precision: 10, scale: 0),
                        ds_adicional = c.String(maxLength: 40),
                        dt_valido_desde = c.DateTime(nullable: false),
                        dt_valido_ate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_pt_medicao)
                .ForeignKey("OO0009.OOCategoriaPontoMedicao", t => t.id_cg_pt_medicao_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_medida_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_intervalo_fk)
                .Index(t => t.id_cg_pt_medicao_fk)
                .Index(t => t.id_un_medida_fk)
                .Index(t => t.id_un_intervalo_fk);
            
            CreateTable(
                "OO0009.OOCategoriaPontoMedicao",
                c => new
                    {
                        id_cg_ponto_medicao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 5),
                        ds_cg_ponto_medicao = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id_cg_ponto_medicao);
            
            CreateTable(
                "OO0009.OOEventoGerador",
                c => new
                    {
                        id_evento_gerador = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_evento_gerador = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id_evento_gerador);
            
            CreateTable(
                "OO0009.OOMedidaNota",
                c => new
                    {
                        id_medida_nota = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_nota_fk = c.Decimal(precision: 10, scale: 0),
                        sq_medida_nota = c.Decimal(nullable: false, precision: 10, scale: 0),
                        dt_hora_medida_nota = c.DateTime(nullable: false),
                        id_st_medida_fk = c.Decimal(precision: 10, scale: 0),
                        id_empregado_fk = c.Decimal(precision: 10, scale: 0),
                        id_code_tx_fk = c.Decimal(precision: 10, scale: 0),
                        id_st_usuario_fk = c.Decimal(precision: 10, scale: 0),
                        id_empregado_responsavel_fk = c.Decimal(precision: 10, scale: 0),
                        id_cent_trab_responsavel_fk = c.Decimal(precision: 10, scale: 0),
                        fn_responsavel = c.String(maxLength: 2),
                        dt_programada = c.DateTime(nullable: false),
                        ds_motivo = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id_medida_nota)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_cent_trab_responsavel_fk)
                .ForeignKey("OO0009.OOCode", t => t.id_code_tx_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_empregado_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_empregado_responsavel_fk)
                .ForeignKey("OO0009.OONota", t => t.id_nota_fk)
                .ForeignKey("OO0009.OOStatusMedida", t => t.id_st_medida_fk)
                .ForeignKey("OO0009.OOStatusUsuario", t => t.id_st_usuario_fk)
                .Index(t => new { t.id_nota_fk, t.sq_medida_nota }, unique: true, name: "ix_seq_medida_nota")
                .Index(t => t.id_st_medida_fk)
                .Index(t => t.id_empregado_fk)
                .Index(t => t.id_code_tx_fk)
                .Index(t => t.id_st_usuario_fk)
                .Index(t => t.id_empregado_responsavel_fk)
                .Index(t => t.id_cent_trab_responsavel_fk);
            
            CreateTable(
                "OO0009.OOStatusMedida",
                c => new
                    {
                        id_st_medida = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 4),
                        ds_st_medida = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id_st_medida);
            
            CreateTable(
                "OO0009.OOStatusUsuario",
                c => new
                    {
                        id_st_usuario = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 4),
                        ds_st_usuario = c.String(maxLength: 150),
                        st_usuario = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.id_st_usuario);
            
            CreateTable(
                "OO0009.OOOrdem",
                c => new
                    {
                        id_ordem = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_nota_fk = c.Decimal(precision: 10, scale: 0),
                        dt_hora_ordem = c.DateTime(nullable: false),
                        id_st_sistema_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_ordem)
                .ForeignKey("OO0009.OONota", t => t.id_nota_fk)
                .ForeignKey("OO0009.OOStatusSistema", t => t.id_st_sistema_fk)
                .Index(t => t.id_nota_fk)
                .Index(t => t.id_st_sistema_fk);
            
            CreateTable(
                "OO0009.OOOperacaoOrdem",
                c => new
                    {
                        id_operacao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_ordem_fk = c.Decimal(precision: 10, scale: 0),
                        ds_breve = c.String(maxLength: 20),
                        nr_pessoas = c.Decimal(nullable: false, precision: 10, scale: 0),
                        dr_operacao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id_nota_ea_fk = c.Decimal(precision: 10, scale: 0),
                        id_centro_trabalho_fk = c.Decimal(precision: 10, scale: 0),
                        dt_hora_operacao = c.DateTime(nullable: false),
                        id_status_operacao_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_operacao)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_centro_trabalho_fk)
                .ForeignKey("OO0009.OONota", t => t.id_nota_ea_fk)
                .ForeignKey("OO0009.OOOrdem", t => t.id_ordem_fk)
                .ForeignKey("OO0009.OOStatusOperacao", t => t.id_status_operacao_fk)
                .Index(t => t.id_ordem_fk)
                .Index(t => t.id_nota_ea_fk)
                .Index(t => t.id_centro_trabalho_fk)
                .Index(t => t.id_status_operacao_fk);
            
            CreateTable(
                "OO0009.OOStatusOperacao",
                c => new
                    {
                        id_st_operacao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_st_operacao = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id_st_operacao);
            
            CreateTable(
                "OO0009.OOStatusSistema",
                c => new
                    {
                        id_st_sistema = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_st_sistema = c.String(maxLength: 150),
                        cd_sap = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.id_st_sistema);
            
            CreateTable(
                "OO0009.OOStatusCopese",
                c => new
                    {
                        id_st_copese = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_st_copese = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id_st_copese);
            
            CreateTable(
                "OO0009.OOStatusPericia",
                c => new
                    {
                        id_st_pericia = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_st_pericia = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id_st_pericia);
            
            CreateTable(
                "OO0009.OOTipoNota",
                c => new
                    {
                        id_tp_nota = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 3),
                        ds_tp_nota = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id_tp_nota);
            
            CreateTable(
                "OO0009.OOTipoDocumento",
                c => new
                    {
                        id_tp_documento = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_tp_documento = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id_tp_documento);
            
            CreateTable(
                "OO0009.OOStatusTrem",
                c => new
                    {
                        id_st_trem = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_st_trem = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id_st_trem);
            
            CreateTable(
                "OO0009.OOCategoriaItem",
                c => new
                    {
                        id_categoria_item = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_categoria_item = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id_categoria_item);
            
            CreateTable(
                "OO0009.OOCentroTrabalhoTarifa",
                c => new
                    {
                        id_ct_trabalho = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 8),
                        cr_tarifa = c.Decimal(nullable: false, precision: 1, scale: 0),
                        id_tp_atividade_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_ct_trabalho)
                .ForeignKey("OO0009.OOTarifa", t => t.id_tp_atividade_fk)
                .Index(t => t.id_tp_atividade_fk);
            
            CreateTable(
                "OO0009.OOTarifa",
                c => new
                    {
                        id_tarifa = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 12),
                        ds_tp_atividade = c.String(maxLength: 40),
                        id_un_atividade_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_tarifa)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_atividade_fk)
                .Index(t => t.id_un_atividade_fk);
            
            CreateTable(
                "OO0009.OOChaveControle",
                c => new
                    {
                        id_ch_controle = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_chave_controle = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id_ch_controle);
            
            CreateTable(
                "OO0009.OOClassificacao",
                c => new
                    {
                        id_centro_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_trabalho_fk = c.Decimal(precision: 10, scale: 0),
                        id_classificacao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_lc_instalacao_fk = c.Decimal(precision: 10, scale: 0),
                        id_equipamento_fk = c.Decimal(precision: 10, scale: 0),
                        cd_classe = c.String(maxLength: 18),
                        cd_caracteristica = c.String(maxLength: 30),
                        cd_valor_caracteristica = c.String(maxLength: 30),
                        st_classificacao = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.id_classificacao)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_centro_fk)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ct_trabalho_fk)
                .ForeignKey("OO0009.OOEquipamento", t => t.id_equipamento_fk)
                .ForeignKey("OO0009.OOLocalInstalacao", t => t.id_lc_instalacao_fk)
                .Index(t => t.id_centro_fk)
                .Index(t => t.id_ct_trabalho_fk)
                .Index(t => t.id_lc_instalacao_fk)
                .Index(t => t.id_equipamento_fk);
            
            CreateTable(
                "OO0009.OODeposito",
                c => new
                    {
                        id_deposito = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                    })
                .PrimaryKey(t => t.id_deposito);
            
            CreateTable(
                "OO0009.OOEquipamentoRastreavel",
                c => new
                    {
                        id_eq_rastreavel = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_nota_fk = c.Decimal(precision: 10, scale: 0),
                        dt_subs_equip = c.DateTime(nullable: false),
                        hr_subs_equip = c.DateTime(nullable: false),
                        id_local_inst_fk = c.Decimal(precision: 10, scale: 0),
                        id_equip_removido_fk = c.Decimal(precision: 10, scale: 0),
                        id_equip_instalado_fk = c.Decimal(precision: 10, scale: 0),
                        id_doc_medicao_fk = c.Decimal(precision: 10, scale: 0),
                        id_empregado_fk = c.Decimal(precision: 10, scale: 0),
                        ds_st_pericia = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id_eq_rastreavel)
                .ForeignKey("OO0009.OODocumento", t => t.id_doc_medicao_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_empregado_fk)
                .ForeignKey("OO0009.OOEquipamento", t => t.id_equip_instalado_fk)
                .ForeignKey("OO0009.OOEquipamento", t => t.id_equip_removido_fk)
                .ForeignKey("OO0009.OOLocalInstalacao", t => t.id_local_inst_fk)
                .ForeignKey("OO0009.OONota", t => t.id_nota_fk)
                .Index(t => t.id_nota_fk)
                .Index(t => t.id_local_inst_fk)
                .Index(t => t.id_equip_removido_fk)
                .Index(t => t.id_equip_instalado_fk)
                .Index(t => t.id_doc_medicao_fk)
                .Index(t => t.id_empregado_fk);
            
            CreateTable(
                "OO0009.OOEstrategiaPacote",
                c => new
                    {
                        id_estrategia = c.Decimal(nullable: false, precision: 10, scale: 0),
                        cd_pacote = c.String(maxLength: 2),
                        nr_ciclo_manutencao = c.String(maxLength: 22),
                        id_un_ciclo_fk = c.Decimal(precision: 10, scale: 0),
                        ds_ciclo = c.String(maxLength: 30),
                        ds_breve_ciclo = c.String(maxLength: 2),
                        cr_hierarquia = c.Decimal(nullable: false, precision: 1, scale: 0),
                        nr_offset_ciclo = c.String(maxLength: 22),
                    })
                .PrimaryKey(t => t.id_estrategia)
                .ForeignKey("OO0009.OOEstrategia", t => t.id_estrategia)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_ciclo_fk)
                .Index(t => t.id_estrategia)
                .Index(t => t.id_un_ciclo_fk);
            
            CreateTable(
                "OO0009.OOEstrategia",
                c => new
                    {
                        id_estrategia = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 6),
                        ds_estrategia = c.String(maxLength: 30),
                        cd_programacao = c.String(maxLength: 2),
                        un_estrategia = c.String(maxLength: 3),
                        id_calendario_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_estrategia)
                .ForeignKey("OO0009.OOCalendarioFabrica", t => t.id_calendario_fk)
                .Index(t => t.id_calendario_fk);
            
            CreateTable(
                "OO0009.OOEstruturaCentroTrabalho",
                c => new
                    {
                        id_est_ct_trabalho = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_ct_superior = c.Decimal(precision: 10, scale: 0),
                        id_ct_subordinado = c.Decimal(precision: 10, scale: 0),
                        ic_imediato = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.id_est_ct_trabalho)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ct_superior)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ct_subordinado)
                .Index(t => t.id_ct_superior)
                .Index(t => t.id_ct_subordinado);
            
            CreateTable(
                "OO0009.OOGrupoAutorizacao",
                c => new
                    {
                        id_gp_autorizacao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 3),
                        ds_gp_autorizacao = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id_gp_autorizacao);
            
            CreateTable(
                "OO0009.OOIntervencaoOperacao",
                c => new
                    {
                        id_intervencao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_operacao_fk = c.Decimal(precision: 10, scale: 0),
                        id_local_instalacao_fk = c.Decimal(precision: 10, scale: 0),
                        id_code_parte_objeto_fk = c.Decimal(precision: 10, scale: 0),
                        id_code_defeito_fk = c.Decimal(precision: 10, scale: 0),
                        id_code_reparo_fk = c.Decimal(precision: 10, scale: 0),
                        qt_intervencao = c.Decimal(nullable: false, precision: 10, scale: 0),
                        mc_invervencao = c.Decimal(precision: 10, scale: 0),
                        di_intervencao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        co_intervencao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id_equipamento_desinstalado_fk = c.Decimal(precision: 10, scale: 0),
                        id_equipamento_instalado_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_intervencao)
                .ForeignKey("OO0009.OOCode", t => t.id_code_defeito_fk)
                .ForeignKey("OO0009.OOCode", t => t.id_code_parte_objeto_fk)
                .ForeignKey("OO0009.OOCode", t => t.id_code_reparo_fk)
                .ForeignKey("OO0009.OOEquipamento", t => t.id_equipamento_desinstalado_fk)
                .ForeignKey("OO0009.OOEquipamento", t => t.id_equipamento_instalado_fk)
                .ForeignKey("OO0009.OOLocalInstalacao", t => t.id_local_instalacao_fk)
                .ForeignKey("OO0009.OOMarco", t => t.mc_invervencao)
                .ForeignKey("OO0009.OOOperacaoOrdem", t => t.id_operacao_fk)
                .Index(t => t.id_operacao_fk)
                .Index(t => t.id_local_instalacao_fk)
                .Index(t => t.id_code_parte_objeto_fk)
                .Index(t => t.id_code_defeito_fk)
                .Index(t => t.id_code_reparo_fk)
                .Index(t => t.mc_invervencao)
                .Index(t => t.id_equipamento_desinstalado_fk)
                .Index(t => t.id_equipamento_instalado_fk);
            
            CreateTable(
                "OO0009.OOLinhaCentroTrabalho",
                c => new
                    {
                        id_linha_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_ct_trabalho_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.id_linha_fk, t.id_ct_trabalho_fk })
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ct_trabalho_fk, cascadeDelete: true)
                .ForeignKey("OO0009.OOLinha", t => t.id_linha_fk, cascadeDelete: true)
                .Index(t => t.id_linha_fk)
                .Index(t => t.id_ct_trabalho_fk);
            
            CreateTable(
                "OO0009.OOListaTarefaOperacaoComp",
                c => new
                    {
                        id_lt_tar_op_comp = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_operacao_fk = c.Decimal(precision: 10, scale: 0),
                        id_sub_operacao_fk = c.Decimal(precision: 10, scale: 0),
                        id_material_fk = c.Decimal(precision: 10, scale: 0),
                        nr_quantidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id_cg_item_fk = c.Decimal(precision: 10, scale: 0),
                        id_deposito_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_lt_tar_op_comp)
                .ForeignKey("OO0009.OOCategoriaItem", t => t.id_cg_item_fk)
                .ForeignKey("OO0009.OODeposito", t => t.id_deposito_fk)
                .ForeignKey("OO0009.OOMaterial", t => t.id_material_fk)
                .ForeignKey("OO0009.OOListaTarefaOperacao", t => t.id_operacao_fk)
                .ForeignKey("OO0009.OOListaTarefaOperacao", t => t.id_sub_operacao_fk)
                .Index(t => t.id_operacao_fk)
                .Index(t => t.id_sub_operacao_fk)
                .Index(t => t.id_material_fk)
                .Index(t => t.id_cg_item_fk)
                .Index(t => t.id_deposito_fk);
            
            CreateTable(
                "OO0009.OOListaTarefaOperacao",
                c => new
                    {
                        cd_lt_tarefa_operacao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_lt_tarefa_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        cd_gp_lt_tarefa = c.String(maxLength: 8),
                        cd_operacao = c.String(maxLength: 4),
                        cd_sub_operacao = c.String(maxLength: 4),
                        ds_operacao = c.String(maxLength: 40),
                        nr_capacidade = c.Decimal(nullable: false, precision: 10, scale: 0),
                        nr_duracao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id_un_duracao_fk = c.Decimal(precision: 10, scale: 0),
                        nr_trabalho = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_un_trabalho_fk = c.Decimal(precision: 10, scale: 0),
                        id_conjunto_fk = c.Decimal(precision: 10, scale: 0),
                        id_tp_atividade_fk = c.Decimal(precision: 10, scale: 0),
                        id_centro_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_trabalho_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.cd_lt_tarefa_operacao)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_centro_fk)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ct_trabalho_fk)
                .ForeignKey("OO0009.OOMaterial", t => t.id_conjunto_fk)
                .ForeignKey("OO0009.OOListaTarefa", t => t.id_lt_tarefa_fk, cascadeDelete: true)
                .ForeignKey("OO0009.OOTarifa", t => t.id_tp_atividade_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_duracao_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_trabalho_fk)
                .Index(t => t.id_lt_tarefa_fk)
                .Index(t => t.id_un_duracao_fk)
                .Index(t => t.id_un_trabalho_fk)
                .Index(t => t.id_conjunto_fk)
                .Index(t => t.id_tp_atividade_fk)
                .Index(t => t.id_centro_fk)
                .Index(t => t.id_ct_trabalho_fk);
            
            CreateTable(
                "OO0009.OOListaTarefa",
                c => new
                    {
                        id_lt_tarefa = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_gp_lt_tarefa = c.String(maxLength: 8),
                        cd_sap = c.String(maxLength: 2),
                        id_st_lista_tarefa_fk = c.Decimal(precision: 10, scale: 0),
                        ds_lt_tarefa = c.String(maxLength: 40),
                        id_lc_instalacao_fk = c.Decimal(precision: 10, scale: 0),
                        cd_equipamento_fk = c.Decimal(precision: 10, scale: 0),
                        id_estrategia_fk = c.Decimal(precision: 10, scale: 0),
                        id_centro_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_trabalho_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_planejamento_fk = c.Decimal(precision: 10, scale: 0),
                        id_gp_planejamento_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_lt_tarefa)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_centro_fk)
                .ForeignKey("OO0009.OOCentroPlanejamento", t => t.id_ct_planejamento_fk)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ct_trabalho_fk)
                .ForeignKey("OO0009.OOEquipamento", t => t.cd_equipamento_fk)
                .ForeignKey("OO0009.OOEstrategia", t => t.id_estrategia_fk)
                .ForeignKey("OO0009.OOGrupoPlanejamento", t => t.id_gp_planejamento_fk)
                .ForeignKey("OO0009.OOLocalInstalacao", t => t.id_lc_instalacao_fk)
                .ForeignKey("OO0009.OOStatusListaTarefa", t => t.id_st_lista_tarefa_fk)
                .Index(t => t.id_st_lista_tarefa_fk)
                .Index(t => t.id_lc_instalacao_fk)
                .Index(t => t.cd_equipamento_fk)
                .Index(t => t.id_estrategia_fk)
                .Index(t => t.id_centro_fk)
                .Index(t => t.id_ct_trabalho_fk)
                .Index(t => t.id_ct_planejamento_fk)
                .Index(t => t.id_gp_planejamento_fk);
            
            CreateTable(
                "OO0009.OOStatusListaTarefa",
                c => new
                    {
                        id_st_lt_tarefa = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 2),
                        ds_st_lt_operacao = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id_st_lt_tarefa);
            
            CreateTable(
                "OO0009.OOListaTarefaOperacaoPacote",
                c => new
                    {
                        id_lt_tar_op_pac = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_gp_lt_tarefa_fk = c.Decimal(precision: 10, scale: 0),
                        id_lt_tarefa_fk = c.Decimal(precision: 10, scale: 0),
                        id_operacao_fk = c.Decimal(precision: 10, scale: 0),
                        id_sub_operacao_fk = c.Decimal(precision: 10, scale: 0),
                        id_estrategia_fk = c.Decimal(precision: 10, scale: 0),
                        id_pacote_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_lt_tar_op_pac)
                .ForeignKey("OO0009.OOEstrategiaPacote", t => t.id_estrategia_fk)
                .ForeignKey("OO0009.OOListaTarefa", t => t.id_gp_lt_tarefa_fk)
                .ForeignKey("OO0009.OOListaTarefa", t => t.id_lt_tarefa_fk)
                .ForeignKey("OO0009.OOListaTarefaOperacao", t => t.id_operacao_fk)
                .ForeignKey("OO0009.OOEstrategiaPacote", t => t.id_pacote_fk)
                .ForeignKey("OO0009.OOListaTarefaOperacao", t => t.id_sub_operacao_fk)
                .Index(t => t.id_gp_lt_tarefa_fk)
                .Index(t => t.id_lt_tarefa_fk)
                .Index(t => t.id_operacao_fk)
                .Index(t => t.id_sub_operacao_fk)
                .Index(t => t.id_estrategia_fk)
                .Index(t => t.id_pacote_fk);
            
            CreateTable(
                "OO0009.OOListaTecnicaMaterialItem",
                c => new
                    {
                        id_lista_tecnica_item = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_centro_fk = c.Decimal(precision: 10, scale: 0),
                        id_material_fk = c.Decimal(precision: 10, scale: 0),
                        nr_item = c.String(maxLength: 4),
                        id_cd_item_fk = c.Decimal(precision: 10, scale: 0),
                        ds_material_Linha1 = c.String(maxLength: 40),
                        ds_material_Linha2 = c.String(maxLength: 40),
                        nr_quantidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id_un_material_fk = c.Decimal(precision: 10, scale: 0),
                        id_documento_fk = c.Decimal(precision: 10, scale: 0),
                        ds_parte_documento = c.String(maxLength: 3),
                        vs_documento = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.id_lista_tecnica_item)
                .ForeignKey("OO0009.OOCategoriaItem", t => t.id_cd_item_fk)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_centro_fk)
                .ForeignKey("OO0009.OODocumento", t => t.id_documento_fk)
                .ForeignKey("OO0009.OOMaterial", t => t.id_material_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_material_fk)
                .Index(t => t.id_centro_fk)
                .Index(t => t.id_material_fk)
                .Index(t => t.id_cd_item_fk)
                .Index(t => t.id_un_material_fk)
                .Index(t => t.id_documento_fk);
            
            CreateTable(
                "OO0009.OOListaTecnicaMaterial",
                c => new
                    {
                        id_lista_tecnica = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_centro_fk = c.Decimal(precision: 10, scale: 0),
                        id_material_fk = c.Decimal(precision: 10, scale: 0),
                        cr_utilizacao = c.String(maxLength: 1),
                        st_lt_tecnica = c.Decimal(nullable: false, precision: 1, scale: 0),
                        dt_valido_desde = c.DateTime(nullable: false),
                        dt_valido_ate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_lista_tecnica)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_centro_fk)
                .ForeignKey("OO0009.OOMaterial", t => t.id_material_fk)
                .Index(t => t.id_centro_fk)
                .Index(t => t.id_material_fk);
            
            CreateTable(
                "OO0009.OOMaoDeObra",
                c => new
                    {
                        id_maodeobra = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_operacao_fk = c.Decimal(precision: 10, scale: 0),
                        id_centro_trabalho_fk = c.Decimal(precision: 10, scale: 0),
                        id_tarifa_fk = c.Decimal(precision: 10, scale: 0),
                        id_chavecontrole_fk = c.Decimal(precision: 10, scale: 0),
                        dt_hora_maodeobra = c.DateTime(nullable: false),
                        dt_execucao = c.DateTime(nullable: false),
                        id_empregado_fk = c.Decimal(precision: 10, scale: 0),
                        tm_preparo = c.Single(nullable: false),
                        tm_deslocamento = c.Single(nullable: false),
                        tm_acesso = c.Single(nullable: false),
                        tm_execucao = c.Single(nullable: false),
                        dr_duracao = c.Single(nullable: false),
                        id_unidade_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_maodeobra)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_centro_trabalho_fk)
                .ForeignKey("OO0009.OOChaveControle", t => t.id_chavecontrole_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_empregado_fk)
                .ForeignKey("OO0009.OOOperacaoOrdem", t => t.id_operacao_fk)
                .ForeignKey("OO0009.OOTarifa", t => t.id_tarifa_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_unidade_fk)
                .Index(t => t.id_operacao_fk)
                .Index(t => t.id_centro_trabalho_fk)
                .Index(t => t.id_tarifa_fk)
                .Index(t => t.id_chavecontrole_fk)
                .Index(t => t.id_empregado_fk)
                .Index(t => t.id_unidade_fk);
            
            CreateTable(
                "OO0009.OOMAP",
                c => new
                    {
                        id_map = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_operacao_fk = c.Decimal(precision: 10, scale: 0),
                        dn_map = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.id_map)
                .ForeignKey("OO0009.OOOperacaoOrdem", t => t.id_operacao_fk)
                .Index(t => t.id_operacao_fk);
            
            CreateTable(
                "OO0009.OOMaterialOperacao",
                c => new
                    {
                        id_materialop = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_operacao_fk = c.Decimal(precision: 10, scale: 0),
                        dn_material = c.String(maxLength: 40),
                        qt_material = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id_unidade_fk = c.Decimal(precision: 10, scale: 0),
                        id_categoria_item_fk = c.Decimal(precision: 10, scale: 0),
                        id_deposito_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_localizacao_fk = c.Decimal(precision: 10, scale: 0),
                        rl_reserva = c.Decimal(nullable: false, precision: 1, scale: 0),
                        ds_local_entrega = c.String(),
                        nm_recebedor = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id_materialop)
                .ForeignKey("OO0009.OOCategoriaItem", t => t.id_categoria_item_fk)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_ct_localizacao_fk)
                .ForeignKey("OO0009.OODeposito", t => t.id_deposito_fk)
                .ForeignKey("OO0009.OOOperacaoOrdem", t => t.id_operacao_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_unidade_fk)
                .Index(t => t.id_operacao_fk)
                .Index(t => t.id_unidade_fk)
                .Index(t => t.id_categoria_item_fk)
                .Index(t => t.id_deposito_fk)
                .Index(t => t.id_ct_localizacao_fk);
            
            CreateTable(
                "OO0009.OOMotivoNaoExecucao",
                c => new
                    {
                        id_motivo = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 22),
                        ds_motivo = c.String(maxLength: 50),
                        id_ativo = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.id_motivo);
            
            CreateTable(
                "OO0009.OONivelAlerta",
                c => new
                    {
                        id_nivel_alerta = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_material_fk = c.Decimal(precision: 10, scale: 0),
                        qt_alerta = c.Decimal(nullable: false, precision: 10, scale: 0),
                        qt_critica = c.Decimal(nullable: false, precision: 10, scale: 0),
                        st_ativo = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.id_nivel_alerta)
                .ForeignKey("OO0009.OOMaterial", t => t.id_material_fk)
                .Index(t => t.id_material_fk);
            
            CreateTable(
                "OO0009.OONotaProgramacao",
                c => new
                    {
                        id_nota_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_programacao_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_entrega_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.id_nota_fk, t.id_programacao_fk })
                .ForeignKey("OO0009.OOEntregaTrem", t => t.id_entrega_fk)
                .ForeignKey("OO0009.OONota", t => t.id_nota_fk, cascadeDelete: true)
                .ForeignKey("OO0009.OOProgramacao", t => t.id_programacao_fk, cascadeDelete: true)
                .Index(t => t.id_nota_fk)
                .Index(t => t.id_programacao_fk)
                .Index(t => t.id_entrega_fk);
            
            CreateTable(
                "OO0009.OOManobra",
                c => new
                    {
                        id_manobra = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_entrega_trem_fk = c.Decimal(precision: 10, scale: 0),
                        id_linha_origem = c.Decimal(precision: 10, scale: 0),
                        id_linha_destino = c.Decimal(precision: 10, scale: 0),
                        id_rg_solicitante_fk = c.Decimal(precision: 10, scale: 0),
                        id_rg_autorizacao_fk = c.Decimal(precision: 10, scale: 0),
                        id_rg_cancelamento_fk = c.Decimal(precision: 10, scale: 0),
                        id_st_manobra = c.Decimal(nullable: false, precision: 10, scale: 0),
                        dt_solicitacao = c.DateTime(nullable: false),
                        hr_solicitacao = c.DateTime(nullable: false),
                        dt_autorizacao = c.DateTime(nullable: false),
                        hr_autorizacao = c.DateTime(nullable: false),
                        dt_inicio = c.DateTime(nullable: false),
                        hr_inicio = c.DateTime(nullable: false),
                        dt_fim = c.DateTime(nullable: false),
                        hr_fim = c.DateTime(nullable: false),
                        dt_cancelamento = c.DateTime(nullable: false),
                        hr_cancelamento = c.DateTime(nullable: false),
                        ds_motivo_canc = c.String(maxLength: 60),
                        ds_observacao = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id_manobra)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_rg_autorizacao_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_rg_cancelamento_fk)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_rg_solicitante_fk)
                .ForeignKey("OO0009.OOEntregaTrem", t => t.id_entrega_trem_fk)
                .ForeignKey("OO0009.OOLinha", t => t.id_linha_destino)
                .ForeignKey("OO0009.OOLinha", t => t.id_linha_origem)
                .Index(t => t.id_entrega_trem_fk)
                .Index(t => t.id_linha_origem)
                .Index(t => t.id_linha_destino)
                .Index(t => t.id_rg_solicitante_fk)
                .Index(t => t.id_rg_autorizacao_fk)
                .Index(t => t.id_rg_cancelamento_fk);
            
            CreateTable(
                "OO0009.OOOperacaoProgramacaoEF",
                c => new
                    {
                        id_operacaoprogramacaoef = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_programacao = c.Decimal(precision: 10, scale: 0),
                        id_ordem = c.Decimal(precision: 10, scale: 0),
                        id_gp_lt_tarefa = c.Decimal(precision: 10, scale: 0),
                        id_operacao = c.Decimal(precision: 10, scale: 0),
                        id_sub_operacao = c.Decimal(precision: 10, scale: 0),
                        dt_programacao = c.DateTime(nullable: false),
                        dt_reprogramacao = c.DateTime(nullable: false),
                        id_motivo = c.Decimal(precision: 10, scale: 0),
                        dt_realizacao = c.DateTime(nullable: false),
                        ds_comentario = c.String(),
                        ds_obs = c.String(),
                        ic_ocultar_historico = c.Decimal(nullable: false, precision: 1, scale: 0),
                        ic_reprogramacao = c.Decimal(nullable: false, precision: 1, scale: 0),
                        id_operacao_origem = c.Decimal(precision: 10, scale: 0),
                        st_operacao = c.String(),
                    })
                .PrimaryKey(t => t.id_operacaoprogramacaoef)
                .ForeignKey("OO0009.OOListaTarefa", t => t.id_gp_lt_tarefa)
                .ForeignKey("OO0009.OOMotivoEntrega", t => t.id_motivo)
                .ForeignKey("OO0009.OOOrdem", t => t.id_ordem)
                .ForeignKey("OO0009.OOProgramacaoEF", t => t.id_programacao)
                .Index(t => t.id_programacao)
                .Index(t => t.id_ordem)
                .Index(t => t.id_gp_lt_tarefa)
                .Index(t => t.id_motivo);
            
            CreateTable(
                "OO0009.OOProgramacaoEF",
                c => new
                    {
                        id_programacao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        nr_programacao = c.Decimal(precision: 10, scale: 0),
                        nr_ano = c.Decimal(precision: 10, scale: 0),
                        nr_semana = c.Decimal(precision: 10, scale: 0),
                        id_centro = c.Decimal(precision: 10, scale: 0),
                        id_centro_trabalho = c.Decimal(precision: 10, scale: 0),
                        id_empregado = c.Decimal(precision: 10, scale: 0),
                        dt_realizacao = c.DateTime(nullable: false),
                        id_status = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_programacao)
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_centro)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_centro_trabalho)
                .ForeignKey("OO0009.OOEmpregado", t => t.id_empregado)
                .Index(t => t.id_centro)
                .Index(t => t.id_centro_trabalho)
                .Index(t => t.id_empregado);
            
            CreateTable(
                "OO0009.OOOrdemProgramacaoEF",
                c => new
                    {
                        id_programacao = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_ordem = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ds_sistema = c.String(),
                        id_nota_fk = c.Decimal(precision: 10, scale: 0),
                        dt_planejada = c.DateTime(nullable: false),
                        dt_email = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.id_programacao, t.id_ordem })
                .ForeignKey("OO0009.OONota", t => t.id_nota_fk)
                .ForeignKey("OO0009.OOOrdem", t => t.id_ordem, cascadeDelete: true)
                .ForeignKey("OO0009.OOProgramacaoEF", t => t.id_programacao, cascadeDelete: true)
                .Index(t => t.id_programacao)
                .Index(t => t.id_ordem)
                .Index(t => t.id_nota_fk);
            
            CreateTable(
                "OO0009.OOPatioLinha",
                c => new
                    {
                        id_patio_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_linha_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        cd_uso_linha = c.String(maxLength: 1),
                        qt_trem = c.Decimal(nullable: false, precision: 10, scale: 0),
                        cd_status = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => new { t.id_patio_fk, t.id_linha_fk })
                .ForeignKey("OO0009.OOLinha", t => t.id_linha_fk, cascadeDelete: true)
                .ForeignKey("OO0009.OOPatio", t => t.id_patio_fk, cascadeDelete: true)
                .Index(t => t.id_patio_fk)
                .Index(t => t.id_linha_fk);
            
            CreateTable(
                "OO0009.OOParceiro",
                c => new
                    {
                        id_parceiro = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_local_inst_fk = c.Decimal(precision: 10, scale: 0),
                        id_equipamento_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_trabalho_fk = c.Decimal(precision: 10, scale: 0),
                        sg_funcao_parceiro = c.String(maxLength: 2),
                        cd_sap = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.id_parceiro)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ct_trabalho_fk)
                .ForeignKey("OO0009.OOEquipamento", t => t.id_equipamento_fk)
                .ForeignKey("OO0009.OOLocalInstalacao", t => t.id_local_inst_fk)
                .Index(t => t.id_local_inst_fk)
                .Index(t => t.id_equipamento_fk)
                .Index(t => t.id_ct_trabalho_fk);
            
            CreateTable(
                "OO0009.OOPlanoItem",
                c => new
                    {
                        id_plano_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        cd_item = c.String(nullable: false, maxLength: 12),
                        ds_item = c.String(maxLength: 40),
                        id_lc_instalacao_fk = c.Decimal(precision: 10, scale: 0),
                        cd_equipamento_fk = c.Decimal(precision: 10, scale: 0),
                        id_material_fk = c.Decimal(precision: 10, scale: 0),
                        cd_gp_lt_tarefa = c.String(maxLength: 12),
                        id_lt_tarefa_fk = c.Decimal(precision: 10, scale: 0),
                        id_centro_fk = c.Decimal(precision: 10, scale: 0),
                        ct_trabalho_fk = c.Decimal(precision: 10, scale: 0),
                        id_ct_planejamento_fk = c.Decimal(precision: 10, scale: 0),
                        id_gp_planejamento_fk = c.Decimal(precision: 10, scale: 0),
                        id_tp_ordem_fk = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.id_plano_fk, t.cd_item })
                .ForeignKey("OO0009.OOCentroLocalizacao", t => t.id_centro_fk)
                .ForeignKey("OO0009.OOCentroPlanejamento", t => t.id_ct_planejamento_fk)
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.ct_trabalho_fk)
                .ForeignKey("OO0009.OOEquipamento", t => t.cd_equipamento_fk)
                .ForeignKey("OO0009.OOGrupoPlanejamento", t => t.id_gp_planejamento_fk)
                .ForeignKey("OO0009.OOListaTarefa", t => t.id_lt_tarefa_fk)
                .ForeignKey("OO0009.OOLocalInstalacao", t => t.id_lc_instalacao_fk)
                .ForeignKey("OO0009.OOMaterial", t => t.id_material_fk)
                .ForeignKey("OO0009.OOPlano", t => t.id_plano_fk, cascadeDelete: true)
                .ForeignKey("OO0009.OOTipoOrdem", t => t.id_tp_ordem_fk)
                .Index(t => t.id_plano_fk)
                .Index(t => t.id_lc_instalacao_fk)
                .Index(t => t.cd_equipamento_fk)
                .Index(t => t.id_material_fk)
                .Index(t => t.id_lt_tarefa_fk)
                .Index(t => t.id_centro_fk)
                .Index(t => t.ct_trabalho_fk)
                .Index(t => t.id_ct_planejamento_fk)
                .Index(t => t.id_gp_planejamento_fk)
                .Index(t => t.id_tp_ordem_fk);
            
            CreateTable(
                "OO0009.OOPlano",
                c => new
                    {
                        id_plano = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 12),
                        ds_plano = c.String(maxLength: 40),
                        cd_plano_gp_ciclo = c.String(maxLength: 1),
                        id_estrategia_fk = c.Decimal(precision: 10, scale: 0),
                        nr_ciclo_unico_manut = c.String(maxLength: 22),
                        id_un_ciclo_manut_fk = c.Decimal(precision: 10, scale: 0),
                        cd_cg_plano = c.String(maxLength: 2),
                        id_pt_medicao_fk = c.Decimal(precision: 10, scale: 0),
                        nr_intervalo_solic = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id_un_intervalo_solic_fk = c.Decimal(precision: 10, scale: 0),
                        ds_selecao_plano = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.id_plano)
                .ForeignKey("OO0009.OOEstrategia", t => t.id_estrategia_fk)
                .ForeignKey("OO0009.OOPontoMedicao", t => t.id_pt_medicao_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_ciclo_manut_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_intervalo_solic_fk)
                .Index(t => t.id_estrategia_fk)
                .Index(t => t.id_un_ciclo_manut_fk)
                .Index(t => t.id_pt_medicao_fk)
                .Index(t => t.id_un_intervalo_solic_fk);
            
            CreateTable(
                "OO0009.OOTipoOrdem",
                c => new
                    {
                        id_tp_ordem = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 3),
                        ds_tp_ordem = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id_tp_ordem);
            
            CreateTable(
                "OO0009.OOPontoMedicaoDocMedicao",
                c => new
                    {
                        id_dc_medicao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 20),
                        id_pt_medicao_fk = c.Decimal(precision: 10, scale: 0),
                        dt_medicao = c.DateTime(nullable: false),
                        hr_medicao = c.DateTime(nullable: false),
                        nr_ps_contador = c.Single(nullable: false),
                        nr_valor_medicao = c.Single(nullable: false),
                        id_un_medida_fk = c.Decimal(precision: 10, scale: 0),
                        ds_dc_medicao = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.id_dc_medicao)
                .ForeignKey("OO0009.OOPontoMedicao", t => t.id_pt_medicao_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_medida_fk)
                .Index(t => t.id_pt_medicao_fk)
                .Index(t => t.id_un_medida_fk);
            
            CreateTable(
                "OO0009.OOPontoMedicaoVinculo",
                c => new
                    {
                        id_pt_medicao_vinc = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_pt_medicao_fk = c.Decimal(precision: 10, scale: 0),
                        id_pt_medicao_transf_valor = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_pt_medicao_vinc)
                .ForeignKey("OO0009.OOPontoMedicao", t => t.id_pt_medicao_fk)
                .ForeignKey("OO0009.OOPontoMedicao", t => t.id_pt_medicao_transf_valor, cascadeDelete: true)
                .Index(t => t.id_pt_medicao_fk)
                .Index(t => t.id_pt_medicao_transf_valor);
            
            CreateTable(
                "OO0009.OOPrioridadeSintoma",
                c => new
                    {
                        id_prioridade_sintoma = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_code_fk = c.Decimal(precision: 10, scale: 0),
                        cd_prioridade = c.String(maxLength: 1),
                        id_prioridade_fk = c.Decimal(precision: 10, scale: 0),
                        cd_entrega = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.id_prioridade_sintoma)
                .ForeignKey("OO0009.OOCode", t => t.id_code_fk)
                .ForeignKey("OO0009.OOPrioridade", t => t.id_prioridade_fk)
                .Index(t => t.id_code_fk)
                .Index(t => t.id_prioridade_fk);
            
            CreateTable(
                "OO0009.OOPrioridadeCentroTrabalho",
                c => new
                    {
                        id_prioridade_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_ct_resp = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_lc_instalacao = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.id_prioridade_fk, t.id_ct_resp })
                .ForeignKey("OO0009.OOCentroTrabalho", t => t.id_ct_resp, cascadeDelete: true)
                .ForeignKey("OO0009.OOLocalInstalacao", t => t.id_lc_instalacao)
                .ForeignKey("OO0009.OOPrioridade", t => t.id_prioridade_fk, cascadeDelete: true)
                .Index(t => t.id_prioridade_fk)
                .Index(t => t.id_ct_resp)
                .Index(t => t.id_lc_instalacao);
            
            CreateTable(
                "OO0009.OOSistemaAplicacao",
                c => new
                    {
                        id_aplicacao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_codigo_aplicacao = c.String(nullable: false, maxLength: 10),
                        id_empresa = c.Decimal(nullable: false, precision: 10, scale: 0),
                        dt_cadastro = c.DateTime(nullable: false),
                        ds_descricao = c.String(nullable: false, maxLength: 100),
                        ds_observacao = c.String(),
                        nm_bancohost = c.String(nullable: false, maxLength: 50),
                        nu_bancoporta = c.Decimal(nullable: false, precision: 10, scale: 0),
                        nm_banconome = c.String(nullable: false, maxLength: 50),
                        nm_bancousuario = c.String(nullable: false, maxLength: 50),
                        ds_bancosenha = c.String(nullable: false, maxLength: 100),
                        ds_bancoprotocolo = c.String(nullable: false, maxLength: 50),
                        ds_token = c.Guid(nullable: false),
                        isAtivo = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.id_aplicacao)
                .ForeignKey("OO0009.OOSistemaEmpresa", t => t.id_empresa, cascadeDelete: true)
                .Index(t => t.id_empresa);
            
            CreateTable(
                "OO0009.OOSistemaTipoLog",
                c => new
                    {
                        id_tipo_log = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_descricao = c.String(nullable: false, maxLength: 100),
                        dt_ocorrencia = c.DateTime(nullable: false),
                        isAtivo = c.Decimal(nullable: false, precision: 1, scale: 0),
                        id_aplicacao = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_tipo_log)
                .ForeignKey("OO0009.OOSistemaAplicacao", t => t.id_aplicacao, cascadeDelete: true)
                .Index(t => t.id_aplicacao);
            
            CreateTable(
                "OO0009.OOSistemaEmpresa",
                c => new
                    {
                        id_empresa = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        dt_cadastro = c.DateTime(nullable: false),
                        ds_descricao = c.String(nullable: false, maxLength: 100),
                        isAtivo = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.id_empresa);
            
            CreateTable(
                "OO0009.OOSistemaLogError",
                c => new
                    {
                        id_log_error = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        dt_ocorrencia = c.DateTime(nullable: false),
                        ds_ipaddress = c.String(nullable: false, maxLength: 20),
                        nm_machine = c.String(nullable: false, maxLength: 50),
                        nm_logon_user_identity_name = c.String(nullable: false, maxLength: 50),
                        id_logon_user_identity_token = c.String(nullable: false, maxLength: 50),
                        nm_controller = c.String(nullable: false, maxLength: 50),
                        nm_action = c.String(nullable: false, maxLength: 50),
                        ds_url_full = c.String(nullable: false, maxLength: 500),
                        ds_path_file = c.String(nullable: false, maxLength: 1000),
                        ds_type_error = c.String(nullable: false),
                        ds_error_link = c.String(maxLength: 500),
                        ds_error_id = c.String(nullable: false),
                        ds_error_message = c.String(nullable: false),
                        ds_error_source = c.String(nullable: false),
                        ds_stack_trace = c.String(nullable: false),
                        ds_target_site = c.String(nullable: false),
                        ds_inner_exception = c.String(),
                        id_aplicacao = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_log_error);
            
            CreateTable(
                "OO0009.OOSistemaLogLogin",
                c => new
                    {
                        id_log_login = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        dt_ocorrencia = c.DateTime(nullable: false),
                        ds_ipaddress = c.String(nullable: false),
                        nm_machine = c.String(nullable: false),
                        nm_logon_user_identity_name = c.String(nullable: false),
                        id_logon_user_identity_token = c.String(nullable: false),
                        nm_browser_name = c.String(nullable: false),
                        nm_browser_version = c.String(nullable: false),
                        is_browser_cookies = c.Decimal(nullable: false, precision: 1, scale: 0),
                        nm_platforma = c.String(nullable: false),
                        is_win16 = c.Decimal(nullable: false, precision: 1, scale: 0),
                        is_win32 = c.Decimal(nullable: false, precision: 1, scale: 0),
                        ds_url_full = c.String(nullable: false),
                        id_aplicacao = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_log_login);
            
            CreateTable(
                "OO0009.OOSistemaLogOperacoes",
                c => new
                    {
                        id_log_operacoes = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        dt_ocorrencia = c.DateTime(nullable: false),
                        id_tipo_log_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ds_ipaddress = c.String(nullable: false, maxLength: 20),
                        nm_machine = c.String(nullable: false, maxLength: 50),
                        nm_logon_user_identity_name = c.String(nullable: false, maxLength: 50),
                        id_logon_user_identity_token = c.String(nullable: false, maxLength: 50),
                        nm_controller = c.String(nullable: false, maxLength: 50),
                        nm_action = c.String(nullable: false, maxLength: 50),
                        ds_url_full = c.String(nullable: false, maxLength: 500),
                        ds_json_origem = c.String(nullable: false),
                        ds_json_para = c.String(nullable: false),
                        id_aplicacao = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_log_operacoes);
            
            CreateTable(
                "OO0009.OOSistemaLogOperacoesItem",
                c => new
                    {
                        id_log_operacoes_item = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_log_operacoes = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ds_propriedade = c.String(nullable: false, maxLength: 50),
                        nm_amigavel = c.String(nullable: false, maxLength: 50),
                        ds_valor_origem = c.String(nullable: false, maxLength: 200),
                        ds_valor_para = c.String(maxLength: 200),
                        nu_ordem = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_log_operacoes_item)
                .ForeignKey("OO0009.OOSistemaLogOperacoes", t => t.id_log_operacoes, cascadeDelete: true)
                .Index(t => t.id_log_operacoes);
            
            CreateTable(
                "OO0009.OOSistemaModulo",
                c => new
                    {
                        id_modulo = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_tabela_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ds_descricao = c.String(nullable: false, maxLength: 100),
                        dt_ocorrencia = c.DateTime(nullable: false),
                        id_aplicacao = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_modulo);
            
            CreateTable(
                "OO0009.OOSistemaPerfil",
                c => new
                    {
                        id_perfil = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        flg_ativo = c.Decimal(nullable: false, precision: 1, scale: 0),
                        ds_descricao = c.String(nullable: false, maxLength: 100),
                        HTMLStringMenu = c.String(nullable: false),
                        num_Usuarios = c.Decimal(nullable: false, precision: 10, scale: 0),
                        num_Usuarios_logados = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_aplicacao = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_perfil);
            
            CreateTable(
                "OO0009.OOSistemaPerfilItem",
                c => new
                    {
                        id_perfilItem = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_perfil_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        flg_Acessar = c.Decimal(nullable: false, precision: 1, scale: 0),
                        flg_Incluir = c.Decimal(nullable: false, precision: 1, scale: 0),
                        flg_Alterar = c.Decimal(nullable: false, precision: 1, scale: 0),
                        flg_Exportar = c.Decimal(nullable: false, precision: 1, scale: 0),
                        flg_Imprimir = c.Decimal(nullable: false, precision: 1, scale: 0),
                        SistemaPerfil_id_perfil = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_perfilItem)
                .ForeignKey("OO0009.OOSistemaPerfil", t => t.SistemaPerfil_id_perfil)
                .Index(t => t.SistemaPerfil_id_perfil);
            
            CreateTable(
                "OO0009.OOSistemaTabela",
                c => new
                    {
                        id_tabela = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        dt_ocorrencia = c.DateTime(nullable: false),
                        ds_descricao = c.String(nullable: false, maxLength: 100),
                        id_aplicacao = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_tabela);
            
            CreateTable(
                "OO0009.OOSistemaTabelaCampo",
                c => new
                    {
                        id_campo = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_tabela_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        dt_ocorrencia = c.DateTime(nullable: false),
                        ds_descricao = c.String(nullable: false, maxLength: 100),
                        id_tipo_dado_fk = c.Decimal(nullable: false, precision: 10, scale: 0),
                        nu_campo_tamanho = c.Decimal(nullable: false, precision: 10, scale: 0),
                        nu_campo_decimal = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ds_campo_mascara = c.String(maxLength: 20),
                        SistemaTabela_id_tabela = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_campo)
                .ForeignKey("OO0009.OOSistemaTabela", t => t.SistemaTabela_id_tabela)
                .Index(t => t.SistemaTabela_id_tabela);
            
            CreateTable(
                "OO0009.OOSistemaTipoDado",
                c => new
                    {
                        id_tipo_dado = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ds_descricao = c.String(nullable: false, maxLength: 100),
                        dt_ocorrencia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_tipo_dado);
            
            CreateTable(
                "OO0009.OOSistemaUsuario",
                c => new
                    {
                        id_usuario = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_empresa = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_aplicacao = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ds_descricao = c.String(nullable: false, maxLength: 100),
                        dt_ocorrencia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_usuario);
            
            CreateTable(
                "OO0009.OOSistemaUsuarioModulo",
                c => new
                    {
                        _idusuario = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        _idmodulo = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ds_descricao = c.String(nullable: false, maxLength: 100),
                        dt_ocorrencia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t._idusuario);
            
            CreateTable(
                "OO0009.OOToleranciaMP",
                c => new
                    {
                        id_tolerancia = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_estrategia_fk = c.Decimal(precision: 10, scale: 0),
                        id_pacote = c.Decimal(precision: 10, scale: 0),
                        nr_limite_superior = c.String(maxLength: 4),
                        nr_limite_inferior = c.String(maxLength: 4),
                        id_un_limite = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_tolerancia)
                .ForeignKey("OO0009.OOEstrategia", t => t.id_estrategia_fk)
                .ForeignKey("OO0009.OOUnidadeMedida", t => t.id_un_limite)
                .Index(t => t.id_estrategia_fk)
                .Index(t => t.id_un_limite);
            
            CreateTable(
                "OO0009.OOUtilizacaoListaTecnica",
                c => new
                    {
                        id_utilizacao = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        cd_sap = c.String(maxLength: 1),
                        ds_utilizacao = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.id_utilizacao);
            
            CreateTable(
                "OO0009.OOCatalogoPerfil",
                c => new
                    {
                        id_catalogo = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_perfil = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.id_catalogo, t.id_perfil })
                .ForeignKey("OO0009.OOCatalogo", t => t.id_catalogo, cascadeDelete: true)
                .ForeignKey("OO0009.OOPerfil", t => t.id_perfil, cascadeDelete: true)
                .Index(t => t.id_catalogo)
                .Index(t => t.id_perfil);
            
            CreateTable(
                "OO0009.OOGrupoCodeCatalogo",
                c => new
                    {
                        id_gp_code = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_catalogo = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.id_gp_code, t.id_catalogo })
                .ForeignKey("OO0009.OOGrupoCode", t => t.id_gp_code, cascadeDelete: true)
                .ForeignKey("OO0009.OOCatalogo", t => t.id_catalogo, cascadeDelete: true)
                .Index(t => t.id_gp_code)
                .Index(t => t.id_catalogo);
            
            CreateTable(
                "OO0009.OOEquipamentoPontoMedicao",
                c => new
                    {
                        id_equipamento = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_pt_medicao = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.id_equipamento, t.id_pt_medicao })
                .ForeignKey("OO0009.OOEquipamento", t => t.id_equipamento, cascadeDelete: true)
                .ForeignKey("OO0009.OOPontoMedicao", t => t.id_pt_medicao, cascadeDelete: true)
                .Index(t => t.id_equipamento)
                .Index(t => t.id_pt_medicao);
            
            CreateTable(
                "OO0009.OOOrdemStatusUsuario",
                c => new
                    {
                        id_ordem = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_st_usuario = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.id_ordem, t.id_st_usuario })
                .ForeignKey("OO0009.OOOrdem", t => t.id_ordem, cascadeDelete: true)
                .ForeignKey("OO0009.OOStatusUsuario", t => t.id_st_usuario, cascadeDelete: true)
                .Index(t => t.id_ordem)
                .Index(t => t.id_st_usuario);
            
            CreateTable(
                "OO0009.OONotasStatusUsuario",
                c => new
                    {
                        id_nota = c.Decimal(nullable: false, precision: 10, scale: 0),
                        id_st_usuario = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.id_nota, t.id_st_usuario })
                .ForeignKey("OO0009.OONota", t => t.id_nota, cascadeDelete: true)
                .ForeignKey("OO0009.OOStatusUsuario", t => t.id_st_usuario, cascadeDelete: true)
                .Index(t => t.id_nota)
                .Index(t => t.id_st_usuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("OO0009.OOToleranciaMP", "id_un_limite", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOToleranciaMP", "id_estrategia_fk", "OO0009.OOEstrategia");
            DropForeignKey("OO0009.OOSistemaTabelaCampo", "SistemaTabela_id_tabela", "OO0009.OOSistemaTabela");
            DropForeignKey("OO0009.OOSistemaPerfilItem", "SistemaPerfil_id_perfil", "OO0009.OOSistemaPerfil");
            DropForeignKey("OO0009.OOSistemaLogOperacoesItem", "id_log_operacoes", "OO0009.OOSistemaLogOperacoes");
            DropForeignKey("OO0009.OOSistemaAplicacao", "id_empresa", "OO0009.OOSistemaEmpresa");
            DropForeignKey("OO0009.OOSistemaTipoLog", "id_aplicacao", "OO0009.OOSistemaAplicacao");
            DropForeignKey("OO0009.OOPrioridadeCentroTrabalho", "id_prioridade_fk", "OO0009.OOPrioridade");
            DropForeignKey("OO0009.OOPrioridadeCentroTrabalho", "id_lc_instalacao", "OO0009.OOLocalInstalacao");
            DropForeignKey("OO0009.OOPrioridadeCentroTrabalho", "id_ct_resp", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOPrioridadeSintoma", "id_prioridade_fk", "OO0009.OOPrioridade");
            DropForeignKey("OO0009.OOPrioridadeSintoma", "id_code_fk", "OO0009.OOCode");
            DropForeignKey("OO0009.OOPontoMedicaoVinculo", "id_pt_medicao_transf_valor", "OO0009.OOPontoMedicao");
            DropForeignKey("OO0009.OOPontoMedicaoVinculo", "id_pt_medicao_fk", "OO0009.OOPontoMedicao");
            DropForeignKey("OO0009.OOPontoMedicaoDocMedicao", "id_un_medida_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOPontoMedicaoDocMedicao", "id_pt_medicao_fk", "OO0009.OOPontoMedicao");
            DropForeignKey("OO0009.OOPlanoItem", "id_tp_ordem_fk", "OO0009.OOTipoOrdem");
            DropForeignKey("OO0009.OOPlanoItem", "id_plano_fk", "OO0009.OOPlano");
            DropForeignKey("OO0009.OOPlano", "id_un_intervalo_solic_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOPlano", "id_un_ciclo_manut_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOPlano", "id_pt_medicao_fk", "OO0009.OOPontoMedicao");
            DropForeignKey("OO0009.OOPlano", "id_estrategia_fk", "OO0009.OOEstrategia");
            DropForeignKey("OO0009.OOPlanoItem", "id_material_fk", "OO0009.OOMaterial");
            DropForeignKey("OO0009.OOPlanoItem", "id_lc_instalacao_fk", "OO0009.OOLocalInstalacao");
            DropForeignKey("OO0009.OOPlanoItem", "id_lt_tarefa_fk", "OO0009.OOListaTarefa");
            DropForeignKey("OO0009.OOPlanoItem", "id_gp_planejamento_fk", "OO0009.OOGrupoPlanejamento");
            DropForeignKey("OO0009.OOPlanoItem", "cd_equipamento_fk", "OO0009.OOEquipamento");
            DropForeignKey("OO0009.OOPlanoItem", "ct_trabalho_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOPlanoItem", "id_ct_planejamento_fk", "OO0009.OOCentroPlanejamento");
            DropForeignKey("OO0009.OOPlanoItem", "id_centro_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOParceiro", "id_local_inst_fk", "OO0009.OOLocalInstalacao");
            DropForeignKey("OO0009.OOParceiro", "id_equipamento_fk", "OO0009.OOEquipamento");
            DropForeignKey("OO0009.OOParceiro", "id_ct_trabalho_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOPatioLinha", "id_patio_fk", "OO0009.OOPatio");
            DropForeignKey("OO0009.OOPatioLinha", "id_linha_fk", "OO0009.OOLinha");
            DropForeignKey("OO0009.OOOrdemProgramacaoEF", "id_programacao", "OO0009.OOProgramacaoEF");
            DropForeignKey("OO0009.OOOrdemProgramacaoEF", "id_ordem", "OO0009.OOOrdem");
            DropForeignKey("OO0009.OOOrdemProgramacaoEF", "id_nota_fk", "OO0009.OONota");
            DropForeignKey("OO0009.OOOperacaoProgramacaoEF", "id_programacao", "OO0009.OOProgramacaoEF");
            DropForeignKey("OO0009.OOProgramacaoEF", "id_empregado", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOProgramacaoEF", "id_centro_trabalho", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOProgramacaoEF", "id_centro", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOOperacaoProgramacaoEF", "id_ordem", "OO0009.OOOrdem");
            DropForeignKey("OO0009.OOOperacaoProgramacaoEF", "id_motivo", "OO0009.OOMotivoEntrega");
            DropForeignKey("OO0009.OOOperacaoProgramacaoEF", "id_gp_lt_tarefa", "OO0009.OOListaTarefa");
            DropForeignKey("OO0009.OOManobra", "id_linha_origem", "OO0009.OOLinha");
            DropForeignKey("OO0009.OOManobra", "id_linha_destino", "OO0009.OOLinha");
            DropForeignKey("OO0009.OOManobra", "id_entrega_trem_fk", "OO0009.OOEntregaTrem");
            DropForeignKey("OO0009.OOManobra", "id_rg_solicitante_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOManobra", "id_rg_cancelamento_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOManobra", "id_rg_autorizacao_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OONotaProgramacao", "id_programacao_fk", "OO0009.OOProgramacao");
            DropForeignKey("OO0009.OONotaProgramacao", "id_nota_fk", "OO0009.OONota");
            DropForeignKey("OO0009.OONotaProgramacao", "id_entrega_fk", "OO0009.OOEntregaTrem");
            DropForeignKey("OO0009.OONivelAlerta", "id_material_fk", "OO0009.OOMaterial");
            DropForeignKey("OO0009.OOMaterialOperacao", "id_unidade_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOMaterialOperacao", "id_operacao_fk", "OO0009.OOOperacaoOrdem");
            DropForeignKey("OO0009.OOMaterialOperacao", "id_deposito_fk", "OO0009.OODeposito");
            DropForeignKey("OO0009.OOMaterialOperacao", "id_ct_localizacao_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOMaterialOperacao", "id_categoria_item_fk", "OO0009.OOCategoriaItem");
            DropForeignKey("OO0009.OOMAP", "id_operacao_fk", "OO0009.OOOperacaoOrdem");
            DropForeignKey("OO0009.OOMaoDeObra", "id_unidade_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOMaoDeObra", "id_tarifa_fk", "OO0009.OOTarifa");
            DropForeignKey("OO0009.OOMaoDeObra", "id_operacao_fk", "OO0009.OOOperacaoOrdem");
            DropForeignKey("OO0009.OOMaoDeObra", "id_empregado_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOMaoDeObra", "id_chavecontrole_fk", "OO0009.OOChaveControle");
            DropForeignKey("OO0009.OOMaoDeObra", "id_centro_trabalho_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOListaTecnicaMaterial", "id_material_fk", "OO0009.OOMaterial");
            DropForeignKey("OO0009.OOListaTecnicaMaterial", "id_centro_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOListaTecnicaMaterialItem", "id_un_material_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOListaTecnicaMaterialItem", "id_material_fk", "OO0009.OOMaterial");
            DropForeignKey("OO0009.OOListaTecnicaMaterialItem", "id_documento_fk", "OO0009.OODocumento");
            DropForeignKey("OO0009.OOListaTecnicaMaterialItem", "id_centro_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOListaTecnicaMaterialItem", "id_cd_item_fk", "OO0009.OOCategoriaItem");
            DropForeignKey("OO0009.OOListaTarefaOperacaoPacote", "id_sub_operacao_fk", "OO0009.OOListaTarefaOperacao");
            DropForeignKey("OO0009.OOListaTarefaOperacaoPacote", "id_pacote_fk", "OO0009.OOEstrategiaPacote");
            DropForeignKey("OO0009.OOListaTarefaOperacaoPacote", "id_operacao_fk", "OO0009.OOListaTarefaOperacao");
            DropForeignKey("OO0009.OOListaTarefaOperacaoPacote", "id_lt_tarefa_fk", "OO0009.OOListaTarefa");
            DropForeignKey("OO0009.OOListaTarefaOperacaoPacote", "id_gp_lt_tarefa_fk", "OO0009.OOListaTarefa");
            DropForeignKey("OO0009.OOListaTarefaOperacaoPacote", "id_estrategia_fk", "OO0009.OOEstrategiaPacote");
            DropForeignKey("OO0009.OOListaTarefaOperacaoComp", "id_sub_operacao_fk", "OO0009.OOListaTarefaOperacao");
            DropForeignKey("OO0009.OOListaTarefaOperacaoComp", "id_operacao_fk", "OO0009.OOListaTarefaOperacao");
            DropForeignKey("OO0009.OOListaTarefaOperacao", "id_un_trabalho_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOListaTarefaOperacao", "id_un_duracao_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOListaTarefaOperacao", "id_tp_atividade_fk", "OO0009.OOTarifa");
            DropForeignKey("OO0009.OOListaTarefaOperacao", "id_lt_tarefa_fk", "OO0009.OOListaTarefa");
            DropForeignKey("OO0009.OOListaTarefa", "id_st_lista_tarefa_fk", "OO0009.OOStatusListaTarefa");
            DropForeignKey("OO0009.OOListaTarefa", "id_lc_instalacao_fk", "OO0009.OOLocalInstalacao");
            DropForeignKey("OO0009.OOListaTarefa", "id_gp_planejamento_fk", "OO0009.OOGrupoPlanejamento");
            DropForeignKey("OO0009.OOListaTarefa", "id_estrategia_fk", "OO0009.OOEstrategia");
            DropForeignKey("OO0009.OOListaTarefa", "cd_equipamento_fk", "OO0009.OOEquipamento");
            DropForeignKey("OO0009.OOListaTarefa", "id_ct_trabalho_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOListaTarefa", "id_ct_planejamento_fk", "OO0009.OOCentroPlanejamento");
            DropForeignKey("OO0009.OOListaTarefa", "id_centro_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOListaTarefaOperacao", "id_conjunto_fk", "OO0009.OOMaterial");
            DropForeignKey("OO0009.OOListaTarefaOperacao", "id_ct_trabalho_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOListaTarefaOperacao", "id_centro_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOListaTarefaOperacaoComp", "id_material_fk", "OO0009.OOMaterial");
            DropForeignKey("OO0009.OOListaTarefaOperacaoComp", "id_deposito_fk", "OO0009.OODeposito");
            DropForeignKey("OO0009.OOListaTarefaOperacaoComp", "id_cg_item_fk", "OO0009.OOCategoriaItem");
            DropForeignKey("OO0009.OOLinhaCentroTrabalho", "id_linha_fk", "OO0009.OOLinha");
            DropForeignKey("OO0009.OOLinhaCentroTrabalho", "id_ct_trabalho_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOIntervencaoOperacao", "id_operacao_fk", "OO0009.OOOperacaoOrdem");
            DropForeignKey("OO0009.OOIntervencaoOperacao", "mc_invervencao", "OO0009.OOMarco");
            DropForeignKey("OO0009.OOIntervencaoOperacao", "id_local_instalacao_fk", "OO0009.OOLocalInstalacao");
            DropForeignKey("OO0009.OOIntervencaoOperacao", "id_equipamento_instalado_fk", "OO0009.OOEquipamento");
            DropForeignKey("OO0009.OOIntervencaoOperacao", "id_equipamento_desinstalado_fk", "OO0009.OOEquipamento");
            DropForeignKey("OO0009.OOIntervencaoOperacao", "id_code_reparo_fk", "OO0009.OOCode");
            DropForeignKey("OO0009.OOIntervencaoOperacao", "id_code_parte_objeto_fk", "OO0009.OOCode");
            DropForeignKey("OO0009.OOIntervencaoOperacao", "id_code_defeito_fk", "OO0009.OOCode");
            DropForeignKey("OO0009.OOEstruturaCentroTrabalho", "id_ct_subordinado", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOEstruturaCentroTrabalho", "id_ct_superior", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOEstrategiaPacote", "id_un_ciclo_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOEstrategiaPacote", "id_estrategia", "OO0009.OOEstrategia");
            DropForeignKey("OO0009.OOEstrategia", "id_calendario_fk", "OO0009.OOCalendarioFabrica");
            DropForeignKey("OO0009.OOEquipamentoRastreavel", "id_nota_fk", "OO0009.OONota");
            DropForeignKey("OO0009.OOEquipamentoRastreavel", "id_local_inst_fk", "OO0009.OOLocalInstalacao");
            DropForeignKey("OO0009.OOEquipamentoRastreavel", "id_equip_removido_fk", "OO0009.OOEquipamento");
            DropForeignKey("OO0009.OOEquipamentoRastreavel", "id_equip_instalado_fk", "OO0009.OOEquipamento");
            DropForeignKey("OO0009.OOEquipamentoRastreavel", "id_empregado_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOEquipamentoRastreavel", "id_doc_medicao_fk", "OO0009.OODocumento");
            DropForeignKey("OO0009.OOClassificacao", "id_lc_instalacao_fk", "OO0009.OOLocalInstalacao");
            DropForeignKey("OO0009.OOClassificacao", "id_equipamento_fk", "OO0009.OOEquipamento");
            DropForeignKey("OO0009.OOClassificacao", "id_ct_trabalho_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOClassificacao", "id_centro_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOCentroTrabalhoTarifa", "id_tp_atividade_fk", "OO0009.OOTarifa");
            DropForeignKey("OO0009.OOTarifa", "id_un_atividade_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOCarro", "id_trem_fk", "OO0009.OOTrem");
            DropForeignKey("OO0009.OOTrem", "st_trem", "OO0009.OOStatusTrem");
            DropForeignKey("OO0009.OOTrem", "id_patio_fk", "OO0009.OOPatio");
            DropForeignKey("OO0009.OOTrem", "id_linha_origem_fk", "OO0009.OOLinha");
            DropForeignKey("OO0009.OOTrem", "id_linha_atual_fk", "OO0009.OOLinha");
            DropForeignKey("OO0009.OOTrem", "id_frota_fk", "OO0009.OOFrota");
            DropForeignKey("OO0009.OOTrem", "id_doc_medicao_fk", "OO0009.OODocumento");
            DropForeignKey("OO0009.OODocumento", "id_tp_documento_fk", "OO0009.OOTipoDocumento");
            DropForeignKey("OO0009.OODocumento", "id_nota_fk", "OO0009.OONota");
            DropForeignKey("OO0009.OONota", "id_un_medid_tempo_prev_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OONota", "id_tp_nota_fk", "OO0009.OOTipoNota");
            DropForeignKey("OO0009.OONotasStatusUsuario", "id_st_usuario", "OO0009.OOStatusUsuario");
            DropForeignKey("OO0009.OONotasStatusUsuario", "id_nota", "OO0009.OONota");
            DropForeignKey("OO0009.OONota", "id_st_sistema_fk", "OO0009.OOStatusSistema");
            DropForeignKey("OO0009.OONota", "id_st_pericia_fk", "OO0009.OOStatusPericia");
            DropForeignKey("OO0009.OONota", "id_st_copese_fk", "OO0009.OOStatusCopese");
            DropForeignKey("OO0009.OONota", "id_prioridade_fk", "OO0009.OOPrioridade");
            DropForeignKey("OO0009.OONota", "id_nota_referencia_fk", "OO0009.OONota");
            DropForeignKey("OO0009.OOMedidaNota", "id_st_usuario_fk", "OO0009.OOStatusUsuario");
            DropForeignKey("OO0009.OOOrdemStatusUsuario", "id_st_usuario", "OO0009.OOStatusUsuario");
            DropForeignKey("OO0009.OOOrdemStatusUsuario", "id_ordem", "OO0009.OOOrdem");
            DropForeignKey("OO0009.OOOrdem", "id_st_sistema_fk", "OO0009.OOStatusSistema");
            DropForeignKey("OO0009.OOOperacaoOrdem", "id_status_operacao_fk", "OO0009.OOStatusOperacao");
            DropForeignKey("OO0009.OOOperacaoOrdem", "id_ordem_fk", "OO0009.OOOrdem");
            DropForeignKey("OO0009.OOOperacaoOrdem", "id_nota_ea_fk", "OO0009.OONota");
            DropForeignKey("OO0009.OOOperacaoOrdem", "id_centro_trabalho_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOOrdem", "id_nota_fk", "OO0009.OONota");
            DropForeignKey("OO0009.OOMedidaNota", "id_st_medida_fk", "OO0009.OOStatusMedida");
            DropForeignKey("OO0009.OOMedidaNota", "id_nota_fk", "OO0009.OONota");
            DropForeignKey("OO0009.OOMedidaNota", "id_empregado_responsavel_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOMedidaNota", "id_empregado_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOMedidaNota", "id_code_tx_fk", "OO0009.OOCode");
            DropForeignKey("OO0009.OOMedidaNota", "id_cent_trab_responsavel_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OONota", "id_material_fk", "OO0009.OOMaterial");
            DropForeignKey("OO0009.OONota", "id_local_inst_princ_fk", "OO0009.OOLocalInstalacao");
            DropForeignKey("OO0009.OONota", "id_local_inst_fk", "OO0009.OOLocalInstalacao");
            DropForeignKey("OO0009.OONota", "id_linha_fk", "OO0009.OOLinha");
            DropForeignKey("OO0009.OONota", "id_ev_gerador_fk", "OO0009.OOEventoGerador");
            DropForeignKey("OO0009.OONota", "id_equipamento_fk", "OO0009.OOEquipamento");
            DropForeignKey("OO0009.OOEquipamento", "id_un_peso_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOEquipamentoPontoMedicao", "id_pt_medicao", "OO0009.OOPontoMedicao");
            DropForeignKey("OO0009.OOEquipamentoPontoMedicao", "id_equipamento", "OO0009.OOEquipamento");
            DropForeignKey("OO0009.OOPontoMedicao", "id_un_intervalo_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOPontoMedicao", "id_un_medida_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOPontoMedicao", "id_cg_pt_medicao_fk", "OO0009.OOCategoriaPontoMedicao");
            DropForeignKey("OO0009.OOEquipamento", "id_perfil_fk", "OO0009.OOPerfil");
            DropForeignKey("OO0009.OOEquipamento", "id_material_fk", "OO0009.OOMaterial");
            DropForeignKey("OO0009.OOEquipamento", "id_lc_instalacao_fk", "OO0009.OOLocalInstalacao");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_zona_fk", "OO0009.OOZona");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_un_peso_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_un_di_marcador_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_un_deslocamento2_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_un_deslocamento1_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_trem_fk", "OO0009.OOTrem");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_sistema_fk", "OO0009.OOSistema");
            DropForeignKey("OO0009.OOSistema", "id_frota_fk", "OO0009.OOFrota");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_posicao_fk", "OO0009.OOPosicao");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_perfil_fk", "OO0009.OOPerfil");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_md_rf_linear_fk", "OO0009.OOModeloLinear");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_mr_partida_fk", "OO0009.OOMarco");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_mr_final_fk", "OO0009.OOMarco");
            DropForeignKey("OO0009.OOMarco", "id_un_comprimento_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOMarco", "id_tp_marcador_fk", "OO0009.OOTipoMarcador");
            DropForeignKey("OO0009.OOMarco", "id_md_rf_linear_fk", "OO0009.OOModeloLinear");
            DropForeignKey("OO0009.OOModeloLinear", "id_un_di_marcador_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOMarco", "cd_lc_instalacao_fk", "OO0009.OOLocalInstalacao");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_ct_planejamento_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_lc_inst_superior_fk", "OO0009.OOLocalInstalacao");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_linha_fk", "OO0009.OOLinha");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_grcode_sistema_fk", "OO0009.OOGrupoCode");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_gp_planejamento_fk", "OO0009.OOGrupoPlanejamento");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_frota_fk", "OO0009.OOFrota");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_conjunto_fk", "OO0009.OOMaterial");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_complemento_fk", "OO0009.OOComplemento");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_cd_abc_fk", "OO0009.OOCodigoABC");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_ct_trabalho_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_ct_localizacao_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_ct_custo_fk", "OO0009.OOCentroCusto");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_centro_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOLocalInstalacao", "id_carro_fk", "OO0009.OOCarro");
            DropForeignKey("OO0009.OOEquipamento", "id_gp_planejamento_fk", "OO0009.OOGrupoPlanejamento");
            DropForeignKey("OO0009.OOEquipamento", "id_ct_localizacao_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOEquipamento", "id_conjunto_fk", "OO0009.OOMaterial");
            DropForeignKey("OO0009.OOEquipamento", "id_cd_abc_fk", "OO0009.OOCodigoABC");
            DropForeignKey("OO0009.OOEquipamento", "id_cg_equipamento_fk", "OO0009.OOCategoriaEquipamento");
            DropForeignKey("OO0009.OOEquipamento", "id_ct_trabalho_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOEquipamento", "id_ct_planejamento_fk", "OO0009.OOCentroPlanejamento");
            DropForeignKey("OO0009.OOEquipamento", "id_centro_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOEquipamento", "id_ct_custo_fk", "OO0009.OOCentroCusto");
            DropForeignKey("OO0009.OONota", "id_entrega_trem_fk", "OO0009.OOEntregaTrem");
            DropForeignKey("OO0009.OOEntregaTrem", "id_trem_fk", "OO0009.OOTrem");
            DropForeignKey("OO0009.OOEntregaTrem", "id_resp_liberacao", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOEntregaTrem", "id_resp_entrega", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOEntregaTrem", "id_resp_cancelamento", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOEntregaTrem", "id_patio_fk", "OO0009.OOPatio");
            DropForeignKey("OO0009.OOEntregaTrem", "id_motivo_entrega_prog_fk", "OO0009.OOMotivoEntrega");
            DropForeignKey("OO0009.OOEntregaTrem", "id_motivo_entrega_ocor_fk", "OO0009.OOMotivoEntrega");
            DropForeignKey("OO0009.OOEntregaTrem", "id_motivo_entrega_inspecao_fk", "OO0009.OOMotivoEntrega");
            DropForeignKey("OO0009.OOEntregaTrem", "id_lin_entrega", "OO0009.OOLinha");
            DropForeignKey("OO0009.OOEntregaTremProg", "id_entrega_fk", "OO0009.OOEntregaTrem");
            DropForeignKey("OO0009.OOEntregaTremProg", "id_programacao_fk", "OO0009.OOProgramacao");
            DropForeignKey("OO0009.OOProgramacao", "id_trem_fk", "OO0009.OOTrem");
            DropForeignKey("OO0009.OOProgramacao", "id_lin_planej_entrega_fk", "OO0009.OOLinha");
            DropForeignKey("OO0009.OOLinha", "id_centro_trabalho_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOProgramacao", "id_rg_programacao", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOProgramacao", "id_rg_cancelamento", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOProgramacao", "id_rg_autorizacao", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOProgramacao", "id_ct_trab", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOEntregaTremNota", "id_entrega_fk", "OO0009.OOEntregaTrem");
            DropForeignKey("OO0009.OOEntregaTremNota", "id_nota_fk", "OO0009.OONota");
            DropForeignKey("OO0009.OOEntregaTrem", "id_ct_trab", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OONota", "id_pl_repres_acionado4_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OONota", "id_pl_repres_acionado3_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OONota", "id_pl_repres_acionado2_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OONota", "id_pl_repres_acionado_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OONota", "id_pn_acionado_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OONota", "id_notificador_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OONota", "id_elemento_pep_fk", "OO0009.OOElementoPEP");
            DropForeignKey("OO0009.OONota", "id_diagnostico_fk", "OO0009.OODiagnostico");
            DropForeignKey("OO0009.OONota", "id_code_sintoma_fk", "OO0009.OOCode");
            DropForeignKey("OO0009.OOCode", "id_prioridade_fk", "OO0009.OOPrioridade");
            DropForeignKey("OO0009.OOCode", "id_gr_code_fk", "OO0009.OOGrupoCode");
            DropForeignKey("OO0009.OOGrupoCodeCatalogo", "id_catalogo", "OO0009.OOCatalogo");
            DropForeignKey("OO0009.OOGrupoCodeCatalogo", "id_gp_code", "OO0009.OOGrupoCode");
            DropForeignKey("OO0009.OOCatalogoPerfil", "id_perfil", "OO0009.OOPerfil");
            DropForeignKey("OO0009.OOCatalogoPerfil", "id_catalogo", "OO0009.OOCatalogo");
            DropForeignKey("OO0009.OONota", "id_ci_acionado_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OONota", "id_centro_trabalho_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOCapacidadePessoal", "id_empregado_fk", "OO0009.OOEmpregado");
            DropForeignKey("OO0009.OOEmpregado", "id_ct_custo_fk", "OO0009.OOCentroCusto");
            DropForeignKey("OO0009.OOCapacidadePessoal", "id_capacidade_fk", "OO0009.OOCapacidade");
            DropForeignKey("OO0009.OOCapacidade", "id_un_capacidade_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOCapacidade", "id_un_base_capacidade_fk", "OO0009.OOUnidadeMedida");
            DropForeignKey("OO0009.OOCapacidade", "id_tp_capacidade_fk", "OO0009.OOTipoCapacidade");
            DropForeignKey("OO0009.OOCapacidade", "id_gp_planejamento_fk", "OO0009.OOGrupoPlanejamento");
            DropForeignKey("OO0009.OOGrupoPlanejamento", "id_ct_localizacao_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOCapacidade", "id_ct_trabalho_fk", "OO0009.OOCentroTrabalho");
            DropForeignKey("OO0009.OOCentroTrabalho", "id_tp_ct_trabalho_fk", "OO0009.OOTipoCentroTrabalho");
            DropForeignKey("OO0009.OOCentroTrabalho", "id_localizacao_fk", "OO0009.OOLocalizacao");
            DropForeignKey("OO0009.OOLocalizacao", "id_ct_localizacao_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOCentroTrabalho", "id_centro_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOCentroTrabalho", "id_ct_custo_fk", "OO0009.OOCentroCusto");
            DropForeignKey("OO0009.OOCapacidade", "id_centro_fk", "OO0009.OOCentroLocalizacao");
            DropForeignKey("OO0009.OOCapacidade", "id_calendario_fk", "OO0009.OOCalendarioFabrica");
            DropIndex("OO0009.OONotasStatusUsuario", new[] { "id_st_usuario" });
            DropIndex("OO0009.OONotasStatusUsuario", new[] { "id_nota" });
            DropIndex("OO0009.OOOrdemStatusUsuario", new[] { "id_st_usuario" });
            DropIndex("OO0009.OOOrdemStatusUsuario", new[] { "id_ordem" });
            DropIndex("OO0009.OOEquipamentoPontoMedicao", new[] { "id_pt_medicao" });
            DropIndex("OO0009.OOEquipamentoPontoMedicao", new[] { "id_equipamento" });
            DropIndex("OO0009.OOGrupoCodeCatalogo", new[] { "id_catalogo" });
            DropIndex("OO0009.OOGrupoCodeCatalogo", new[] { "id_gp_code" });
            DropIndex("OO0009.OOCatalogoPerfil", new[] { "id_perfil" });
            DropIndex("OO0009.OOCatalogoPerfil", new[] { "id_catalogo" });
            DropIndex("OO0009.OOToleranciaMP", new[] { "id_un_limite" });
            DropIndex("OO0009.OOToleranciaMP", new[] { "id_estrategia_fk" });
            DropIndex("OO0009.OOSistemaTabelaCampo", new[] { "SistemaTabela_id_tabela" });
            DropIndex("OO0009.OOSistemaPerfilItem", new[] { "SistemaPerfil_id_perfil" });
            DropIndex("OO0009.OOSistemaLogOperacoesItem", new[] { "id_log_operacoes" });
            DropIndex("OO0009.OOSistemaTipoLog", new[] { "id_aplicacao" });
            DropIndex("OO0009.OOSistemaAplicacao", new[] { "id_empresa" });
            DropIndex("OO0009.OOPrioridadeCentroTrabalho", new[] { "id_lc_instalacao" });
            DropIndex("OO0009.OOPrioridadeCentroTrabalho", new[] { "id_ct_resp" });
            DropIndex("OO0009.OOPrioridadeCentroTrabalho", new[] { "id_prioridade_fk" });
            DropIndex("OO0009.OOPrioridadeSintoma", new[] { "id_prioridade_fk" });
            DropIndex("OO0009.OOPrioridadeSintoma", new[] { "id_code_fk" });
            DropIndex("OO0009.OOPontoMedicaoVinculo", new[] { "id_pt_medicao_transf_valor" });
            DropIndex("OO0009.OOPontoMedicaoVinculo", new[] { "id_pt_medicao_fk" });
            DropIndex("OO0009.OOPontoMedicaoDocMedicao", new[] { "id_un_medida_fk" });
            DropIndex("OO0009.OOPontoMedicaoDocMedicao", new[] { "id_pt_medicao_fk" });
            DropIndex("OO0009.OOPlano", new[] { "id_un_intervalo_solic_fk" });
            DropIndex("OO0009.OOPlano", new[] { "id_pt_medicao_fk" });
            DropIndex("OO0009.OOPlano", new[] { "id_un_ciclo_manut_fk" });
            DropIndex("OO0009.OOPlano", new[] { "id_estrategia_fk" });
            DropIndex("OO0009.OOPlanoItem", new[] { "id_tp_ordem_fk" });
            DropIndex("OO0009.OOPlanoItem", new[] { "id_gp_planejamento_fk" });
            DropIndex("OO0009.OOPlanoItem", new[] { "id_ct_planejamento_fk" });
            DropIndex("OO0009.OOPlanoItem", new[] { "ct_trabalho_fk" });
            DropIndex("OO0009.OOPlanoItem", new[] { "id_centro_fk" });
            DropIndex("OO0009.OOPlanoItem", new[] { "id_lt_tarefa_fk" });
            DropIndex("OO0009.OOPlanoItem", new[] { "id_material_fk" });
            DropIndex("OO0009.OOPlanoItem", new[] { "cd_equipamento_fk" });
            DropIndex("OO0009.OOPlanoItem", new[] { "id_lc_instalacao_fk" });
            DropIndex("OO0009.OOPlanoItem", new[] { "id_plano_fk" });
            DropIndex("OO0009.OOParceiro", new[] { "id_ct_trabalho_fk" });
            DropIndex("OO0009.OOParceiro", new[] { "id_equipamento_fk" });
            DropIndex("OO0009.OOParceiro", new[] { "id_local_inst_fk" });
            DropIndex("OO0009.OOPatioLinha", new[] { "id_linha_fk" });
            DropIndex("OO0009.OOPatioLinha", new[] { "id_patio_fk" });
            DropIndex("OO0009.OOOrdemProgramacaoEF", new[] { "id_nota_fk" });
            DropIndex("OO0009.OOOrdemProgramacaoEF", new[] { "id_ordem" });
            DropIndex("OO0009.OOOrdemProgramacaoEF", new[] { "id_programacao" });
            DropIndex("OO0009.OOProgramacaoEF", new[] { "id_empregado" });
            DropIndex("OO0009.OOProgramacaoEF", new[] { "id_centro_trabalho" });
            DropIndex("OO0009.OOProgramacaoEF", new[] { "id_centro" });
            DropIndex("OO0009.OOOperacaoProgramacaoEF", new[] { "id_motivo" });
            DropIndex("OO0009.OOOperacaoProgramacaoEF", new[] { "id_gp_lt_tarefa" });
            DropIndex("OO0009.OOOperacaoProgramacaoEF", new[] { "id_ordem" });
            DropIndex("OO0009.OOOperacaoProgramacaoEF", new[] { "id_programacao" });
            DropIndex("OO0009.OOManobra", new[] { "id_rg_cancelamento_fk" });
            DropIndex("OO0009.OOManobra", new[] { "id_rg_autorizacao_fk" });
            DropIndex("OO0009.OOManobra", new[] { "id_rg_solicitante_fk" });
            DropIndex("OO0009.OOManobra", new[] { "id_linha_destino" });
            DropIndex("OO0009.OOManobra", new[] { "id_linha_origem" });
            DropIndex("OO0009.OOManobra", new[] { "id_entrega_trem_fk" });
            DropIndex("OO0009.OONotaProgramacao", new[] { "id_entrega_fk" });
            DropIndex("OO0009.OONotaProgramacao", new[] { "id_programacao_fk" });
            DropIndex("OO0009.OONotaProgramacao", new[] { "id_nota_fk" });
            DropIndex("OO0009.OONivelAlerta", new[] { "id_material_fk" });
            DropIndex("OO0009.OOMaterialOperacao", new[] { "id_ct_localizacao_fk" });
            DropIndex("OO0009.OOMaterialOperacao", new[] { "id_deposito_fk" });
            DropIndex("OO0009.OOMaterialOperacao", new[] { "id_categoria_item_fk" });
            DropIndex("OO0009.OOMaterialOperacao", new[] { "id_unidade_fk" });
            DropIndex("OO0009.OOMaterialOperacao", new[] { "id_operacao_fk" });
            DropIndex("OO0009.OOMAP", new[] { "id_operacao_fk" });
            DropIndex("OO0009.OOMaoDeObra", new[] { "id_unidade_fk" });
            DropIndex("OO0009.OOMaoDeObra", new[] { "id_empregado_fk" });
            DropIndex("OO0009.OOMaoDeObra", new[] { "id_chavecontrole_fk" });
            DropIndex("OO0009.OOMaoDeObra", new[] { "id_tarifa_fk" });
            DropIndex("OO0009.OOMaoDeObra", new[] { "id_centro_trabalho_fk" });
            DropIndex("OO0009.OOMaoDeObra", new[] { "id_operacao_fk" });
            DropIndex("OO0009.OOListaTecnicaMaterial", new[] { "id_material_fk" });
            DropIndex("OO0009.OOListaTecnicaMaterial", new[] { "id_centro_fk" });
            DropIndex("OO0009.OOListaTecnicaMaterialItem", new[] { "id_documento_fk" });
            DropIndex("OO0009.OOListaTecnicaMaterialItem", new[] { "id_un_material_fk" });
            DropIndex("OO0009.OOListaTecnicaMaterialItem", new[] { "id_cd_item_fk" });
            DropIndex("OO0009.OOListaTecnicaMaterialItem", new[] { "id_material_fk" });
            DropIndex("OO0009.OOListaTecnicaMaterialItem", new[] { "id_centro_fk" });
            DropIndex("OO0009.OOListaTarefaOperacaoPacote", new[] { "id_pacote_fk" });
            DropIndex("OO0009.OOListaTarefaOperacaoPacote", new[] { "id_estrategia_fk" });
            DropIndex("OO0009.OOListaTarefaOperacaoPacote", new[] { "id_sub_operacao_fk" });
            DropIndex("OO0009.OOListaTarefaOperacaoPacote", new[] { "id_operacao_fk" });
            DropIndex("OO0009.OOListaTarefaOperacaoPacote", new[] { "id_lt_tarefa_fk" });
            DropIndex("OO0009.OOListaTarefaOperacaoPacote", new[] { "id_gp_lt_tarefa_fk" });
            DropIndex("OO0009.OOListaTarefa", new[] { "id_gp_planejamento_fk" });
            DropIndex("OO0009.OOListaTarefa", new[] { "id_ct_planejamento_fk" });
            DropIndex("OO0009.OOListaTarefa", new[] { "id_ct_trabalho_fk" });
            DropIndex("OO0009.OOListaTarefa", new[] { "id_centro_fk" });
            DropIndex("OO0009.OOListaTarefa", new[] { "id_estrategia_fk" });
            DropIndex("OO0009.OOListaTarefa", new[] { "cd_equipamento_fk" });
            DropIndex("OO0009.OOListaTarefa", new[] { "id_lc_instalacao_fk" });
            DropIndex("OO0009.OOListaTarefa", new[] { "id_st_lista_tarefa_fk" });
            DropIndex("OO0009.OOListaTarefaOperacao", new[] { "id_ct_trabalho_fk" });
            DropIndex("OO0009.OOListaTarefaOperacao", new[] { "id_centro_fk" });
            DropIndex("OO0009.OOListaTarefaOperacao", new[] { "id_tp_atividade_fk" });
            DropIndex("OO0009.OOListaTarefaOperacao", new[] { "id_conjunto_fk" });
            DropIndex("OO0009.OOListaTarefaOperacao", new[] { "id_un_trabalho_fk" });
            DropIndex("OO0009.OOListaTarefaOperacao", new[] { "id_un_duracao_fk" });
            DropIndex("OO0009.OOListaTarefaOperacao", new[] { "id_lt_tarefa_fk" });
            DropIndex("OO0009.OOListaTarefaOperacaoComp", new[] { "id_deposito_fk" });
            DropIndex("OO0009.OOListaTarefaOperacaoComp", new[] { "id_cg_item_fk" });
            DropIndex("OO0009.OOListaTarefaOperacaoComp", new[] { "id_material_fk" });
            DropIndex("OO0009.OOListaTarefaOperacaoComp", new[] { "id_sub_operacao_fk" });
            DropIndex("OO0009.OOListaTarefaOperacaoComp", new[] { "id_operacao_fk" });
            DropIndex("OO0009.OOLinhaCentroTrabalho", new[] { "id_ct_trabalho_fk" });
            DropIndex("OO0009.OOLinhaCentroTrabalho", new[] { "id_linha_fk" });
            DropIndex("OO0009.OOIntervencaoOperacao", new[] { "id_equipamento_instalado_fk" });
            DropIndex("OO0009.OOIntervencaoOperacao", new[] { "id_equipamento_desinstalado_fk" });
            DropIndex("OO0009.OOIntervencaoOperacao", new[] { "mc_invervencao" });
            DropIndex("OO0009.OOIntervencaoOperacao", new[] { "id_code_reparo_fk" });
            DropIndex("OO0009.OOIntervencaoOperacao", new[] { "id_code_defeito_fk" });
            DropIndex("OO0009.OOIntervencaoOperacao", new[] { "id_code_parte_objeto_fk" });
            DropIndex("OO0009.OOIntervencaoOperacao", new[] { "id_local_instalacao_fk" });
            DropIndex("OO0009.OOIntervencaoOperacao", new[] { "id_operacao_fk" });
            DropIndex("OO0009.OOEstruturaCentroTrabalho", new[] { "id_ct_subordinado" });
            DropIndex("OO0009.OOEstruturaCentroTrabalho", new[] { "id_ct_superior" });
            DropIndex("OO0009.OOEstrategia", new[] { "id_calendario_fk" });
            DropIndex("OO0009.OOEstrategiaPacote", new[] { "id_un_ciclo_fk" });
            DropIndex("OO0009.OOEstrategiaPacote", new[] { "id_estrategia" });
            DropIndex("OO0009.OOEquipamentoRastreavel", new[] { "id_empregado_fk" });
            DropIndex("OO0009.OOEquipamentoRastreavel", new[] { "id_doc_medicao_fk" });
            DropIndex("OO0009.OOEquipamentoRastreavel", new[] { "id_equip_instalado_fk" });
            DropIndex("OO0009.OOEquipamentoRastreavel", new[] { "id_equip_removido_fk" });
            DropIndex("OO0009.OOEquipamentoRastreavel", new[] { "id_local_inst_fk" });
            DropIndex("OO0009.OOEquipamentoRastreavel", new[] { "id_nota_fk" });
            DropIndex("OO0009.OOClassificacao", new[] { "id_equipamento_fk" });
            DropIndex("OO0009.OOClassificacao", new[] { "id_lc_instalacao_fk" });
            DropIndex("OO0009.OOClassificacao", new[] { "id_ct_trabalho_fk" });
            DropIndex("OO0009.OOClassificacao", new[] { "id_centro_fk" });
            DropIndex("OO0009.OOTarifa", new[] { "id_un_atividade_fk" });
            DropIndex("OO0009.OOCentroTrabalhoTarifa", new[] { "id_tp_atividade_fk" });
            DropIndex("OO0009.OOOperacaoOrdem", new[] { "id_status_operacao_fk" });
            DropIndex("OO0009.OOOperacaoOrdem", new[] { "id_centro_trabalho_fk" });
            DropIndex("OO0009.OOOperacaoOrdem", new[] { "id_nota_ea_fk" });
            DropIndex("OO0009.OOOperacaoOrdem", new[] { "id_ordem_fk" });
            DropIndex("OO0009.OOOrdem", new[] { "id_st_sistema_fk" });
            DropIndex("OO0009.OOOrdem", new[] { "id_nota_fk" });
            DropIndex("OO0009.OOMedidaNota", new[] { "id_cent_trab_responsavel_fk" });
            DropIndex("OO0009.OOMedidaNota", new[] { "id_empregado_responsavel_fk" });
            DropIndex("OO0009.OOMedidaNota", new[] { "id_st_usuario_fk" });
            DropIndex("OO0009.OOMedidaNota", new[] { "id_code_tx_fk" });
            DropIndex("OO0009.OOMedidaNota", new[] { "id_empregado_fk" });
            DropIndex("OO0009.OOMedidaNota", new[] { "id_st_medida_fk" });
            DropIndex("OO0009.OOMedidaNota", "ix_seq_medida_nota");
            DropIndex("OO0009.OOPontoMedicao", new[] { "id_un_intervalo_fk" });
            DropIndex("OO0009.OOPontoMedicao", new[] { "id_un_medida_fk" });
            DropIndex("OO0009.OOPontoMedicao", new[] { "id_cg_pt_medicao_fk" });
            DropIndex("OO0009.OOSistema", new[] { "id_frota_fk" });
            DropIndex("OO0009.OOModeloLinear", new[] { "id_un_di_marcador_fk" });
            DropIndex("OO0009.OOMarco", new[] { "cd_lc_instalacao_fk" });
            DropIndex("OO0009.OOMarco", new[] { "id_un_comprimento_fk" });
            DropIndex("OO0009.OOMarco", new[] { "id_tp_marcador_fk" });
            DropIndex("OO0009.OOMarco", new[] { "id_md_rf_linear_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_grcode_sistema_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_linha_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_zona_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_posicao_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_complemento_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_sistema_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_carro_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_trem_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_frota_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_perfil_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_cd_abc_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_ct_custo_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_gp_planejamento_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_ct_planejamento_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_ct_trabalho_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_centro_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_conjunto_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_un_deslocamento2_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_un_deslocamento1_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_un_di_marcador_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_mr_final_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_mr_partida_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_md_rf_linear_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_un_peso_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_lc_inst_superior_fk" });
            DropIndex("OO0009.OOLocalInstalacao", new[] { "id_ct_localizacao_fk" });
            DropIndex("OO0009.OOEquipamento", new[] { "id_perfil_fk" });
            DropIndex("OO0009.OOEquipamento", new[] { "id_cd_abc_fk" });
            DropIndex("OO0009.OOEquipamento", new[] { "id_ct_custo_fk" });
            DropIndex("OO0009.OOEquipamento", new[] { "id_gp_planejamento_fk" });
            DropIndex("OO0009.OOEquipamento", new[] { "id_ct_planejamento_fk" });
            DropIndex("OO0009.OOEquipamento", new[] { "id_ct_trabalho_fk" });
            DropIndex("OO0009.OOEquipamento", new[] { "id_centro_fk" });
            DropIndex("OO0009.OOEquipamento", new[] { "id_conjunto_fk" });
            DropIndex("OO0009.OOEquipamento", new[] { "id_material_fk" });
            DropIndex("OO0009.OOEquipamento", new[] { "id_un_peso_fk" });
            DropIndex("OO0009.OOEquipamento", new[] { "id_lc_instalacao_fk" });
            DropIndex("OO0009.OOEquipamento", new[] { "id_ct_localizacao_fk" });
            DropIndex("OO0009.OOEquipamento", new[] { "id_cg_equipamento_fk" });
            DropIndex("OO0009.OOLinha", new[] { "id_centro_trabalho_fk" });
            DropIndex("OO0009.OOProgramacao", new[] { "id_ct_trab" });
            DropIndex("OO0009.OOProgramacao", new[] { "id_rg_cancelamento" });
            DropIndex("OO0009.OOProgramacao", new[] { "id_rg_autorizacao" });
            DropIndex("OO0009.OOProgramacao", new[] { "id_rg_programacao" });
            DropIndex("OO0009.OOProgramacao", new[] { "id_lin_planej_entrega_fk" });
            DropIndex("OO0009.OOProgramacao", new[] { "id_trem_fk" });
            DropIndex("OO0009.OOEntregaTremProg", new[] { "id_programacao_fk" });
            DropIndex("OO0009.OOEntregaTremProg", new[] { "id_entrega_fk" });
            DropIndex("OO0009.OOEntregaTremNota", new[] { "id_nota_fk" });
            DropIndex("OO0009.OOEntregaTremNota", new[] { "id_entrega_fk" });
            DropIndex("OO0009.OOEntregaTrem", new[] { "id_resp_liberacao" });
            DropIndex("OO0009.OOEntregaTrem", new[] { "id_resp_cancelamento" });
            DropIndex("OO0009.OOEntregaTrem", new[] { "id_resp_entrega" });
            DropIndex("OO0009.OOEntregaTrem", new[] { "id_ct_trab" });
            DropIndex("OO0009.OOEntregaTrem", new[] { "id_lin_entrega" });
            DropIndex("OO0009.OOEntregaTrem", new[] { "id_patio_fk" });
            DropIndex("OO0009.OOEntregaTrem", new[] { "id_trem_fk" });
            DropIndex("OO0009.OOEntregaTrem", new[] { "id_motivo_entrega_inspecao_fk" });
            DropIndex("OO0009.OOEntregaTrem", new[] { "id_motivo_entrega_prog_fk" });
            DropIndex("OO0009.OOEntregaTrem", new[] { "id_motivo_entrega_ocor_fk" });
            DropIndex("OO0009.OOCode", new[] { "id_prioridade_fk" });
            DropIndex("OO0009.OOCode", new[] { "id_gr_code_fk" });
            DropIndex("OO0009.OONota", new[] { "id_entrega_trem_fk" });
            DropIndex("OO0009.OONota", new[] { "id_linha_fk" });
            DropIndex("OO0009.OONota", new[] { "id_diagnostico_fk" });
            DropIndex("OO0009.OONota", new[] { "id_notificador_fk" });
            DropIndex("OO0009.OONota", new[] { "id_pl_repres_acionado4_fk" });
            DropIndex("OO0009.OONota", new[] { "id_pl_repres_acionado3_fk" });
            DropIndex("OO0009.OONota", new[] { "id_pl_repres_acionado2_fk" });
            DropIndex("OO0009.OONota", new[] { "id_pl_repres_acionado_fk" });
            DropIndex("OO0009.OONota", new[] { "id_ci_acionado_fk" });
            DropIndex("OO0009.OONota", new[] { "id_pn_acionado_fk" });
            DropIndex("OO0009.OONota", new[] { "id_ev_gerador_fk" });
            DropIndex("OO0009.OONota", new[] { "id_st_copese_fk" });
            DropIndex("OO0009.OONota", new[] { "id_st_pericia_fk" });
            DropIndex("OO0009.OONota", new[] { "id_un_medid_tempo_prev_fk" });
            DropIndex("OO0009.OONota", new[] { "id_material_fk" });
            DropIndex("OO0009.OONota", new[] { "id_equipamento_fk" });
            DropIndex("OO0009.OONota", new[] { "id_elemento_pep_fk" });
            DropIndex("OO0009.OONota", new[] { "id_centro_trabalho_fk" });
            DropIndex("OO0009.OONota", new[] { "id_prioridade_fk" });
            DropIndex("OO0009.OONota", new[] { "id_code_sintoma_fk" });
            DropIndex("OO0009.OONota", new[] { "id_st_sistema_fk" });
            DropIndex("OO0009.OONota", new[] { "id_nota_referencia_fk" });
            DropIndex("OO0009.OONota", new[] { "id_local_inst_princ_fk" });
            DropIndex("OO0009.OONota", new[] { "id_local_inst_fk" });
            DropIndex("OO0009.OONota", new[] { "id_tp_nota_fk" });
            DropIndex("OO0009.OODocumento", new[] { "id_nota_fk" });
            DropIndex("OO0009.OODocumento", new[] { "id_tp_documento_fk" });
            DropIndex("OO0009.OOTrem", new[] { "st_trem" });
            DropIndex("OO0009.OOTrem", new[] { "id_linha_atual_fk" });
            DropIndex("OO0009.OOTrem", new[] { "id_patio_fk" });
            DropIndex("OO0009.OOTrem", new[] { "id_linha_origem_fk" });
            DropIndex("OO0009.OOTrem", new[] { "id_frota_fk" });
            DropIndex("OO0009.OOTrem", new[] { "id_doc_medicao_fk" });
            DropIndex("OO0009.OOCarro", new[] { "id_trem_fk" });
            DropIndex("OO0009.OOEmpregado", new[] { "id_ct_custo_fk" });
            DropIndex("OO0009.OOGrupoPlanejamento", new[] { "id_ct_localizacao_fk" });
            DropIndex("OO0009.OOLocalizacao", new[] { "id_ct_localizacao_fk" });
            DropIndex("OO0009.OOCentroTrabalho", new[] { "id_ct_custo_fk" });
            DropIndex("OO0009.OOCentroTrabalho", new[] { "id_localizacao_fk" });
            DropIndex("OO0009.OOCentroTrabalho", new[] { "id_tp_ct_trabalho_fk" });
            DropIndex("OO0009.OOCentroTrabalho", new[] { "id_centro_fk" });
            DropIndex("OO0009.OOCapacidade", new[] { "id_gp_planejamento_fk" });
            DropIndex("OO0009.OOCapacidade", new[] { "id_un_base_capacidade_fk" });
            DropIndex("OO0009.OOCapacidade", new[] { "id_un_capacidade_fk" });
            DropIndex("OO0009.OOCapacidade", new[] { "id_calendario_fk" });
            DropIndex("OO0009.OOCapacidade", new[] { "id_tp_capacidade_fk" });
            DropIndex("OO0009.OOCapacidade", new[] { "id_ct_trabalho_fk" });
            DropIndex("OO0009.OOCapacidade", new[] { "id_centro_fk" });
            DropIndex("OO0009.OOCapacidadePessoal", new[] { "id_empregado_fk" });
            DropIndex("OO0009.OOCapacidadePessoal", new[] { "id_capacidade_fk" });
            DropTable("OO0009.OONotasStatusUsuario");
            DropTable("OO0009.OOOrdemStatusUsuario");
            DropTable("OO0009.OOEquipamentoPontoMedicao");
            DropTable("OO0009.OOGrupoCodeCatalogo");
            DropTable("OO0009.OOCatalogoPerfil");
            DropTable("OO0009.OOUtilizacaoListaTecnica");
            DropTable("OO0009.OOToleranciaMP");
            DropTable("OO0009.OOSistemaUsuarioModulo");
            DropTable("OO0009.OOSistemaUsuario");
            DropTable("OO0009.OOSistemaTipoDado");
            DropTable("OO0009.OOSistemaTabelaCampo");
            DropTable("OO0009.OOSistemaTabela");
            DropTable("OO0009.OOSistemaPerfilItem");
            DropTable("OO0009.OOSistemaPerfil");
            DropTable("OO0009.OOSistemaModulo");
            DropTable("OO0009.OOSistemaLogOperacoesItem");
            DropTable("OO0009.OOSistemaLogOperacoes");
            DropTable("OO0009.OOSistemaLogLogin");
            DropTable("OO0009.OOSistemaLogError");
            DropTable("OO0009.OOSistemaEmpresa");
            DropTable("OO0009.OOSistemaTipoLog");
            DropTable("OO0009.OOSistemaAplicacao");
            DropTable("OO0009.OOPrioridadeCentroTrabalho");
            DropTable("OO0009.OOPrioridadeSintoma");
            DropTable("OO0009.OOPontoMedicaoVinculo");
            DropTable("OO0009.OOPontoMedicaoDocMedicao");
            DropTable("OO0009.OOTipoOrdem");
            DropTable("OO0009.OOPlano");
            DropTable("OO0009.OOPlanoItem");
            DropTable("OO0009.OOParceiro");
            DropTable("OO0009.OOPatioLinha");
            DropTable("OO0009.OOOrdemProgramacaoEF");
            DropTable("OO0009.OOProgramacaoEF");
            DropTable("OO0009.OOOperacaoProgramacaoEF");
            DropTable("OO0009.OOManobra");
            DropTable("OO0009.OONotaProgramacao");
            DropTable("OO0009.OONivelAlerta");
            DropTable("OO0009.OOMotivoNaoExecucao");
            DropTable("OO0009.OOMaterialOperacao");
            DropTable("OO0009.OOMAP");
            DropTable("OO0009.OOMaoDeObra");
            DropTable("OO0009.OOListaTecnicaMaterial");
            DropTable("OO0009.OOListaTecnicaMaterialItem");
            DropTable("OO0009.OOListaTarefaOperacaoPacote");
            DropTable("OO0009.OOStatusListaTarefa");
            DropTable("OO0009.OOListaTarefa");
            DropTable("OO0009.OOListaTarefaOperacao");
            DropTable("OO0009.OOListaTarefaOperacaoComp");
            DropTable("OO0009.OOLinhaCentroTrabalho");
            DropTable("OO0009.OOIntervencaoOperacao");
            DropTable("OO0009.OOGrupoAutorizacao");
            DropTable("OO0009.OOEstruturaCentroTrabalho");
            DropTable("OO0009.OOEstrategia");
            DropTable("OO0009.OOEstrategiaPacote");
            DropTable("OO0009.OOEquipamentoRastreavel");
            DropTable("OO0009.OODeposito");
            DropTable("OO0009.OOClassificacao");
            DropTable("OO0009.OOChaveControle");
            DropTable("OO0009.OOTarifa");
            DropTable("OO0009.OOCentroTrabalhoTarifa");
            DropTable("OO0009.OOCategoriaItem");
            DropTable("OO0009.OOStatusTrem");
            DropTable("OO0009.OOTipoDocumento");
            DropTable("OO0009.OOTipoNota");
            DropTable("OO0009.OOStatusPericia");
            DropTable("OO0009.OOStatusCopese");
            DropTable("OO0009.OOStatusSistema");
            DropTable("OO0009.OOStatusOperacao");
            DropTable("OO0009.OOOperacaoOrdem");
            DropTable("OO0009.OOOrdem");
            DropTable("OO0009.OOStatusUsuario");
            DropTable("OO0009.OOStatusMedida");
            DropTable("OO0009.OOMedidaNota");
            DropTable("OO0009.OOEventoGerador");
            DropTable("OO0009.OOCategoriaPontoMedicao");
            DropTable("OO0009.OOPontoMedicao");
            DropTable("OO0009.OOZona");
            DropTable("OO0009.OOSistema");
            DropTable("OO0009.OOPosicao");
            DropTable("OO0009.OOTipoMarcador");
            DropTable("OO0009.OOModeloLinear");
            DropTable("OO0009.OOMarco");
            DropTable("OO0009.OOFrota");
            DropTable("OO0009.OOComplemento");
            DropTable("OO0009.OOLocalInstalacao");
            DropTable("OO0009.OOMaterial");
            DropTable("OO0009.OOCodigoABC");
            DropTable("OO0009.OOCategoriaEquipamento");
            DropTable("OO0009.OOCentroPlanejamento");
            DropTable("OO0009.OOEquipamento");
            DropTable("OO0009.OOPatio");
            DropTable("OO0009.OOMotivoEntrega");
            DropTable("OO0009.OOLinha");
            DropTable("OO0009.OOProgramacao");
            DropTable("OO0009.OOEntregaTremProg");
            DropTable("OO0009.OOEntregaTremNota");
            DropTable("OO0009.OOEntregaTrem");
            DropTable("OO0009.OOElementoPEP");
            DropTable("OO0009.OODiagnostico");
            DropTable("OO0009.OOPrioridade");
            DropTable("OO0009.OOPerfil");
            DropTable("OO0009.OOCatalogo");
            DropTable("OO0009.OOGrupoCode");
            DropTable("OO0009.OOCode");
            DropTable("OO0009.OONota");
            DropTable("OO0009.OODocumento");
            DropTable("OO0009.OOTrem");
            DropTable("OO0009.OOCarro");
            DropTable("OO0009.OOEmpregado");
            DropTable("OO0009.OOUnidadeMedida");
            DropTable("OO0009.OOTipoCapacidade");
            DropTable("OO0009.OOGrupoPlanejamento");
            DropTable("OO0009.OOTipoCentroTrabalho");
            DropTable("OO0009.OOLocalizacao");
            DropTable("OO0009.OOCentroCusto");
            DropTable("OO0009.OOCentroTrabalho");
            DropTable("OO0009.OOCentroLocalizacao");
            DropTable("OO0009.OOCapacidade");
            DropTable("OO0009.OOCapacidadePessoal");
            DropTable("OO0009.OOCalendarioFabrica");
            DropTable("OO0009.OOAreaOperacional");
        }
    }
}
