﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace PM.WebServices.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class LocalInstalacao
    {
        /// <summary>
        /// Initializes a new instance of the LocalInstalacao class.
        /// </summary>
        public LocalInstalacao() { }

        /// <summary>
        /// Initializes a new instance of the LocalInstalacao class.
        /// </summary>
        public LocalInstalacao(int? idLcInstalacao = default(int?), string cdSap = default(string), string dsLcInstalacao = default(string), string cgLcInstalacao = default(string), string cdEstrutura = default(string), string cdTpLcInstalacao = default(string), int? idCtLocalizacaoFk = default(int?), string stSistema = default(string), string stUsuario = default(string), string dsRua = default(string), string nrEndereco = default(string), string cdPostal = default(string), string nrTelefone = default(string), string nrRamal = default(string), int? idLcInstSuperiorFk = default(int?), bool? crMgPermitida = default(bool?), bool? crMgIndividual = default(bool?), string cpOrdenacao = default(string), string sgPaisProdutor = default(string), string dsFabricante = default(string), string dsTpFabricante = default(string), string rfFabricante = default(string), string nrSerieFabricante = default(string), int? nrAnoConstrucao = default(int?), int? nrMesConstrucao = default(int?), DateTime? dtAquisicao = default(DateTime?), DateTime? dtEntradaServico = default(DateTime?), DateTime? dtInicioGarantia = default(DateTime?), DateTime? dtFimGarantia = default(DateTime?), string nrDimensao = default(string), double? peBruto = default(double?), int? idUnPesoFk = default(int?), int? idMdRfLinearFk = default(int?), string ptPartida = default(string), string ptFinal = default(string), double? nrComprimento = default(double?), string unMedida = default(string), int? idMrPartidaFk = default(int?), int? idMrFinalFk = default(int?), string nrDiMrPartida = default(string), string nrDiMrFinal = default(string), int? idUnDiMarcadorFk = default(int?), string tpDeslocamento1 = default(string), double? nrDeslocamento1 = default(double?), int? idUnDeslocamento1Fk = default(int?), string tpDeslocamento2 = default(string), double? nrDeslocamento2 = default(double?), int? idUnDeslocamento2Fk = default(int?), int? idConjuntoFk = default(int?), int? idCentroFk = default(int?), int? idCtTrabalhoFk = default(int?), int? idCtPlanejamentoFk = default(int?), int? idGpPlanejamentoFk = default(int?), int? idCtCustoFk = default(int?), string arContabil = default(string), int? idCdAbcFk = default(int?), int? idPerfilFk = default(int?), int? idFrotaFk = default(int?), int? idTremFk = default(int?), int? idCarroFk = default(int?), int? idSistemaFk = default(int?), int? idComplementoFk = default(int?), int? idPosicaoFk = default(int?), int? idZonaFk = default(int?), int? idLinhaFk = default(int?), int? idGrcodeSistemaFk = default(int?), string cdObj = default(string), BaseModel baseModel = default(BaseModel), CentroLocalizacao centro = default(CentroLocalizacao), CentroCusto centroCusto = default(CentroCusto), CentroLocalizacao centroLocalizacao = default(CentroLocalizacao), CodigoABC codigoAbc = default(CodigoABC), GrupoPlanejamento gpPlanejamento = default(GrupoPlanejamento), CentroLocalizacao localizacao = default(CentroLocalizacao), Marco marcoPartida = default(Marco), Marco marcoFinal = default(Marco), ModeloLinear modeloLinear = default(ModeloLinear), Perfil perfilCatalogo = default(Perfil), Material conjunto = default(Material), CentroTrabalho centroTrabalho = default(CentroTrabalho), UnidadeMedida unidadeMedidaPeso = default(UnidadeMedida), UnidadeMedida unidadeMedidaMarcador = default(UnidadeMedida), UnidadeMedida unidadeMedidaDes1 = default(UnidadeMedida), UnidadeMedida unidadeMedidaDes2 = default(UnidadeMedida), LocalInstalacao localInstalacaoSuperior = default(LocalInstalacao), Linha linha = default(Linha), Frota frota = default(Frota), Trem trem = default(Trem), Carro carro = default(Carro), Sistema sistema = default(Sistema), Complemento complemento = default(Complemento), Posicao posicao = default(Posicao), Zona zona = default(Zona), GrupoCode grCodeSistema = default(GrupoCode))
        {
            IdLcInstalacao = idLcInstalacao;
            CdSap = cdSap;
            DsLcInstalacao = dsLcInstalacao;
            CgLcInstalacao = cgLcInstalacao;
            CdEstrutura = cdEstrutura;
            CdTpLcInstalacao = cdTpLcInstalacao;
            IdCtLocalizacaoFk = idCtLocalizacaoFk;
            StSistema = stSistema;
            StUsuario = stUsuario;
            DsRua = dsRua;
            NrEndereco = nrEndereco;
            CdPostal = cdPostal;
            NrTelefone = nrTelefone;
            NrRamal = nrRamal;
            IdLcInstSuperiorFk = idLcInstSuperiorFk;
            CrMgPermitida = crMgPermitida;
            CrMgIndividual = crMgIndividual;
            CpOrdenacao = cpOrdenacao;
            SgPaisProdutor = sgPaisProdutor;
            DsFabricante = dsFabricante;
            DsTpFabricante = dsTpFabricante;
            RfFabricante = rfFabricante;
            NrSerieFabricante = nrSerieFabricante;
            NrAnoConstrucao = nrAnoConstrucao;
            NrMesConstrucao = nrMesConstrucao;
            DtAquisicao = dtAquisicao;
            DtEntradaServico = dtEntradaServico;
            DtInicioGarantia = dtInicioGarantia;
            DtFimGarantia = dtFimGarantia;
            NrDimensao = nrDimensao;
            PeBruto = peBruto;
            IdUnPesoFk = idUnPesoFk;
            IdMdRfLinearFk = idMdRfLinearFk;
            PtPartida = ptPartida;
            PtFinal = ptFinal;
            NrComprimento = nrComprimento;
            UnMedida = unMedida;
            IdMrPartidaFk = idMrPartidaFk;
            IdMrFinalFk = idMrFinalFk;
            NrDiMrPartida = nrDiMrPartida;
            NrDiMrFinal = nrDiMrFinal;
            IdUnDiMarcadorFk = idUnDiMarcadorFk;
            TpDeslocamento1 = tpDeslocamento1;
            NrDeslocamento1 = nrDeslocamento1;
            IdUnDeslocamento1Fk = idUnDeslocamento1Fk;
            TpDeslocamento2 = tpDeslocamento2;
            NrDeslocamento2 = nrDeslocamento2;
            IdUnDeslocamento2Fk = idUnDeslocamento2Fk;
            IdConjuntoFk = idConjuntoFk;
            IdCentroFk = idCentroFk;
            IdCtTrabalhoFk = idCtTrabalhoFk;
            IdCtPlanejamentoFk = idCtPlanejamentoFk;
            IdGpPlanejamentoFk = idGpPlanejamentoFk;
            IdCtCustoFk = idCtCustoFk;
            ArContabil = arContabil;
            IdCdAbcFk = idCdAbcFk;
            IdPerfilFk = idPerfilFk;
            IdFrotaFk = idFrotaFk;
            IdTremFk = idTremFk;
            IdCarroFk = idCarroFk;
            IdSistemaFk = idSistemaFk;
            IdComplementoFk = idComplementoFk;
            IdPosicaoFk = idPosicaoFk;
            IdZonaFk = idZonaFk;
            IdLinhaFk = idLinhaFk;
            IdGrcodeSistemaFk = idGrcodeSistemaFk;
            CdObj = cdObj;
            BaseModel = baseModel;
            Centro = centro;
            CentroCusto = centroCusto;
            CentroLocalizacao = centroLocalizacao;
            CodigoAbc = codigoAbc;
            GpPlanejamento = gpPlanejamento;
            Localizacao = localizacao;
            MarcoPartida = marcoPartida;
            MarcoFinal = marcoFinal;
            ModeloLinear = modeloLinear;
            PerfilCatalogo = perfilCatalogo;
            Conjunto = conjunto;
            CentroTrabalho = centroTrabalho;
            UnidadeMedidaPeso = unidadeMedidaPeso;
            UnidadeMedidaMarcador = unidadeMedidaMarcador;
            UnidadeMedidaDes1 = unidadeMedidaDes1;
            UnidadeMedidaDes2 = unidadeMedidaDes2;
            LocalInstalacaoSuperior = localInstalacaoSuperior;
            Linha = linha;
            Frota = frota;
            Trem = trem;
            Carro = carro;
            Sistema = sistema;
            Complemento = complemento;
            Posicao = posicao;
            Zona = zona;
            GrCodeSistema = grCodeSistema;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_lc_instalacao")]
        public int? IdLcInstalacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_sap")]
        public string CdSap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_lc_instalacao")]
        public string DsLcInstalacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cg_lc_instalacao")]
        public string CgLcInstalacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_estrutura")]
        public string CdEstrutura { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_tp_lc_instalacao")]
        public string CdTpLcInstalacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_ct_localizacao_fk")]
        public int? IdCtLocalizacaoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "st_sistema")]
        public string StSistema { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "st_usuario")]
        public string StUsuario { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_rua")]
        public string DsRua { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_endereco")]
        public string NrEndereco { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_postal")]
        public string CdPostal { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_telefone")]
        public string NrTelefone { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_ramal")]
        public string NrRamal { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_lc_inst_superior_fk")]
        public int? IdLcInstSuperiorFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cr_mg_permitida")]
        public bool? CrMgPermitida { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cr_mg_individual")]
        public bool? CrMgIndividual { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cp_ordenacao")]
        public string CpOrdenacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sg_pais_produtor")]
        public string SgPaisProdutor { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_fabricante")]
        public string DsFabricante { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_tp_fabricante")]
        public string DsTpFabricante { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rf_fabricante")]
        public string RfFabricante { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_serie_fabricante")]
        public string NrSerieFabricante { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_ano_construcao")]
        public int? NrAnoConstrucao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_mes_construcao")]
        public int? NrMesConstrucao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_aquisicao")]
        public DateTime? DtAquisicao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_entrada_servico")]
        public DateTime? DtEntradaServico { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_inicio_garantia")]
        public DateTime? DtInicioGarantia { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_fim_garantia")]
        public DateTime? DtFimGarantia { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_dimensao")]
        public string NrDimensao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pe_bruto")]
        public double? PeBruto { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_un_peso_fk")]
        public int? IdUnPesoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_md_rf_linear_fk")]
        public int? IdMdRfLinearFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pt_partida")]
        public string PtPartida { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pt_final")]
        public string PtFinal { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_comprimento")]
        public double? NrComprimento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "un_medida")]
        public string UnMedida { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_mr_partida_fk")]
        public int? IdMrPartidaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_mr_final_fk")]
        public int? IdMrFinalFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_di_mr_partida")]
        public string NrDiMrPartida { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_di_mr_final")]
        public string NrDiMrFinal { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_un_di_marcador_fk")]
        public int? IdUnDiMarcadorFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tp_deslocamento1")]
        public string TpDeslocamento1 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_deslocamento1")]
        public double? NrDeslocamento1 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_un_deslocamento1_fk")]
        public int? IdUnDeslocamento1Fk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tp_deslocamento2")]
        public string TpDeslocamento2 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_deslocamento2")]
        public double? NrDeslocamento2 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_un_deslocamento2_fk")]
        public int? IdUnDeslocamento2Fk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_conjunto_fk")]
        public int? IdConjuntoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_centro_fk")]
        public int? IdCentroFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_ct_trabalho_fk")]
        public int? IdCtTrabalhoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_ct_planejamento_fk")]
        public int? IdCtPlanejamentoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_gp_planejamento_fk")]
        public int? IdGpPlanejamentoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_ct_custo_fk")]
        public int? IdCtCustoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ar_contabil")]
        public string ArContabil { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_cd_abc_fk")]
        public int? IdCdAbcFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_perfil_fk")]
        public int? IdPerfilFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_frota_fk")]
        public int? IdFrotaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_trem_fk")]
        public int? IdTremFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_carro_fk")]
        public int? IdCarroFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_sistema_fk")]
        public int? IdSistemaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_complemento_fk")]
        public int? IdComplementoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_posicao_fk")]
        public int? IdPosicaoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_zona_fk")]
        public int? IdZonaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_linha_fk")]
        public int? IdLinhaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_grcode_sistema_fk")]
        public int? IdGrcodeSistemaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_obj")]
        public string CdObj { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Centro")]
        public CentroLocalizacao Centro { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroCusto")]
        public CentroCusto CentroCusto { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroLocalizacao")]
        public CentroLocalizacao CentroLocalizacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CodigoAbc")]
        public CodigoABC CodigoAbc { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "GpPlanejamento")]
        public GrupoPlanejamento GpPlanejamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Localizacao")]
        public CentroLocalizacao Localizacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MarcoPartida")]
        public Marco MarcoPartida { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MarcoFinal")]
        public Marco MarcoFinal { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ModeloLinear")]
        public ModeloLinear ModeloLinear { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PerfilCatalogo")]
        public Perfil PerfilCatalogo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Conjunto")]
        public Material Conjunto { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroTrabalho")]
        public CentroTrabalho CentroTrabalho { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UnidadeMedidaPeso")]
        public UnidadeMedida UnidadeMedidaPeso { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UnidadeMedidaMarcador")]
        public UnidadeMedida UnidadeMedidaMarcador { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UnidadeMedidaDes1")]
        public UnidadeMedida UnidadeMedidaDes1 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UnidadeMedidaDes2")]
        public UnidadeMedida UnidadeMedidaDes2 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "LocalInstalacaoSuperior")]
        public LocalInstalacao LocalInstalacaoSuperior { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Linha")]
        public Linha Linha { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Frota")]
        public Frota Frota { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Trem")]
        public Trem Trem { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Carro")]
        public Carro Carro { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Sistema")]
        public Sistema Sistema { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Complemento")]
        public Complemento Complemento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Posicao")]
        public Posicao Posicao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Zona")]
        public Zona Zona { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "GrCodeSistema")]
        public GrupoCode GrCodeSistema { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.CdSap != null)
            {
                if (this.CdSap.Length > 22)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdSap", 22);
                }
                if (this.CdSap.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdSap", 0);
                }
            }
            if (this.DsLcInstalacao != null)
            {
                if (this.DsLcInstalacao.Length > 40)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsLcInstalacao", 40);
                }
                if (this.DsLcInstalacao.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsLcInstalacao", 0);
                }
            }
            if (this.CgLcInstalacao != null)
            {
                if (this.CgLcInstalacao.Length > 1)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CgLcInstalacao", 1);
                }
                if (this.CgLcInstalacao.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CgLcInstalacao", 0);
                }
            }
            if (this.CdEstrutura != null)
            {
                if (this.CdEstrutura.Length > 5)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdEstrutura", 5);
                }
                if (this.CdEstrutura.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdEstrutura", 0);
                }
            }
            if (this.CdTpLcInstalacao != null)
            {
                if (this.CdTpLcInstalacao.Length > 10)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdTpLcInstalacao", 10);
                }
                if (this.CdTpLcInstalacao.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdTpLcInstalacao", 0);
                }
            }
            if (this.StSistema != null)
            {
                if (this.StSistema.Length > 40)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "StSistema", 40);
                }
                if (this.StSistema.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "StSistema", 0);
                }
            }
            if (this.StUsuario != null)
            {
                if (this.StUsuario.Length > 40)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "StUsuario", 40);
                }
                if (this.StUsuario.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "StUsuario", 0);
                }
            }
            if (this.DsRua != null)
            {
                if (this.DsRua.Length > 60)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsRua", 60);
                }
                if (this.DsRua.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsRua", 0);
                }
            }
            if (this.NrEndereco != null)
            {
                if (this.NrEndereco.Length > 10)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NrEndereco", 10);
                }
                if (this.NrEndereco.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NrEndereco", 0);
                }
            }
            if (this.CdPostal != null)
            {
                if (this.CdPostal.Length > 10)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdPostal", 10);
                }
                if (this.CdPostal.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdPostal", 0);
                }
            }
            if (this.NrTelefone != null)
            {
                if (this.NrTelefone.Length > 30)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NrTelefone", 30);
                }
                if (this.NrTelefone.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NrTelefone", 0);
                }
            }
            if (this.NrRamal != null)
            {
                if (this.NrRamal.Length > 10)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NrRamal", 10);
                }
                if (this.NrRamal.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NrRamal", 0);
                }
            }
            if (this.CpOrdenacao != null)
            {
                if (this.CpOrdenacao.Length > 30)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CpOrdenacao", 30);
                }
                if (this.CpOrdenacao.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CpOrdenacao", 0);
                }
            }
            if (this.SgPaisProdutor != null)
            {
                if (this.SgPaisProdutor.Length > 3)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "SgPaisProdutor", 3);
                }
                if (this.SgPaisProdutor.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "SgPaisProdutor", 0);
                }
            }
            if (this.DsFabricante != null)
            {
                if (this.DsFabricante.Length > 30)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsFabricante", 30);
                }
                if (this.DsFabricante.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsFabricante", 0);
                }
            }
            if (this.DsTpFabricante != null)
            {
                if (this.DsTpFabricante.Length > 20)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsTpFabricante", 20);
                }
                if (this.DsTpFabricante.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsTpFabricante", 0);
                }
            }
            if (this.RfFabricante != null)
            {
                if (this.RfFabricante.Length > 30)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "RfFabricante", 30);
                }
                if (this.RfFabricante.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "RfFabricante", 0);
                }
            }
            if (this.NrSerieFabricante != null)
            {
                if (this.NrSerieFabricante.Length > 30)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NrSerieFabricante", 30);
                }
                if (this.NrSerieFabricante.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NrSerieFabricante", 0);
                }
            }
            if (this.NrDimensao != null)
            {
                if (this.NrDimensao.Length > 18)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NrDimensao", 18);
                }
                if (this.NrDimensao.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NrDimensao", 0);
                }
            }
            if (this.PtPartida != null)
            {
                if (this.PtPartida.Length > 18)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "PtPartida", 18);
                }
                if (this.PtPartida.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "PtPartida", 0);
                }
            }
            if (this.PtFinal != null)
            {
                if (this.PtFinal.Length > 18)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "PtFinal", 18);
                }
                if (this.PtFinal.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "PtFinal", 0);
                }
            }
            if (this.UnMedida != null)
            {
                if (this.UnMedida.Length > 3)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "UnMedida", 3);
                }
                if (this.UnMedida.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "UnMedida", 0);
                }
            }
            if (this.NrDiMrPartida != null)
            {
                if (this.NrDiMrPartida.Length > 18)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NrDiMrPartida", 18);
                }
                if (this.NrDiMrPartida.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NrDiMrPartida", 0);
                }
            }
            if (this.NrDiMrFinal != null)
            {
                if (this.NrDiMrFinal.Length > 18)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NrDiMrFinal", 18);
                }
                if (this.NrDiMrFinal.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NrDiMrFinal", 0);
                }
            }
            if (this.TpDeslocamento1 != null)
            {
                if (this.TpDeslocamento1.Length > 2)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "TpDeslocamento1", 2);
                }
                if (this.TpDeslocamento1.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "TpDeslocamento1", 0);
                }
            }
            if (this.TpDeslocamento2 != null)
            {
                if (this.TpDeslocamento2.Length > 2)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "TpDeslocamento2", 2);
                }
                if (this.TpDeslocamento2.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "TpDeslocamento2", 0);
                }
            }
            if (this.ArContabil != null)
            {
                if (this.ArContabil.Length > 4)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "ArContabil", 4);
                }
                if (this.ArContabil.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "ArContabil", 0);
                }
            }
            if (this.CdObj != null)
            {
                if (this.CdObj.Length > 22)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdObj", 22);
                }
                if (this.CdObj.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdObj", 0);
                }
            }
            if (this.Centro != null)
            {
                this.Centro.Validate();
            }
            if (this.CentroCusto != null)
            {
                this.CentroCusto.Validate();
            }
            if (this.CentroLocalizacao != null)
            {
                this.CentroLocalizacao.Validate();
            }
            if (this.CodigoAbc != null)
            {
                this.CodigoAbc.Validate();
            }
            if (this.GpPlanejamento != null)
            {
                this.GpPlanejamento.Validate();
            }
            if (this.Localizacao != null)
            {
                this.Localizacao.Validate();
            }
            if (this.MarcoPartida != null)
            {
                this.MarcoPartida.Validate();
            }
            if (this.MarcoFinal != null)
            {
                this.MarcoFinal.Validate();
            }
            if (this.ModeloLinear != null)
            {
                this.ModeloLinear.Validate();
            }
            if (this.PerfilCatalogo != null)
            {
                this.PerfilCatalogo.Validate();
            }
            if (this.Conjunto != null)
            {
                this.Conjunto.Validate();
            }
            if (this.CentroTrabalho != null)
            {
                this.CentroTrabalho.Validate();
            }
            if (this.LocalInstalacaoSuperior != null)
            {
                this.LocalInstalacaoSuperior.Validate();
            }
            if (this.Linha != null)
            {
                this.Linha.Validate();
            }
            if (this.Trem != null)
            {
                this.Trem.Validate();
            }
            if (this.Carro != null)
            {
                this.Carro.Validate();
            }
            if (this.Complemento != null)
            {
                this.Complemento.Validate();
            }
            if (this.Posicao != null)
            {
                this.Posicao.Validate();
            }
            if (this.GrCodeSistema != null)
            {
                this.GrCodeSistema.Validate();
            }
        }
    }
}