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

    public partial class Equipamento
    {
        /// <summary>
        /// Initializes a new instance of the Equipamento class.
        /// </summary>
        public Equipamento() { }

        /// <summary>
        /// Initializes a new instance of the Equipamento class.
        /// </summary>
        public Equipamento(int? idEquipamento = default(int?), string cdSap = default(string), string cdEquipamento = default(string), int? idCgEquipamentoFk = default(int?), string dsEquipamento = default(string), string tpEquipamento = default(string), string stSistema = default(string), string stEquipamento = default(string), int? idCtLocalizacaoFk = default(int?), string cpOrdenacao = default(string), int? idLcInstalacaoFk = default(int?), int? idEqSuperiorFk = default(int?), bool? crMgIndividual = default(bool?), string sgPaisProdutor = default(string), string dsFabricante = default(string), string rfFabricante = default(string), string nrSerieFabricante = default(string), int? nrAnoConstrucao = default(int?), int? nrMesConstrucao = default(int?), DateTime? dtAquisicao = default(DateTime?), DateTime? dtIniFunc = default(DateTime?), DateTime? dtInicioGarantia = default(DateTime?), DateTime? dtFimGarantia = default(DateTime?), bool? cdHerdarGarantia = default(bool?), string nrIdentifTecnica = default(string), string nrDimensao = default(string), double? peBruto = default(double?), int? idUnPesoFk = default(int?), int? idMaterialFk = default(int?), int? idConjuntoFk = default(int?), string tpVeiculo = default(string), string nrIdentifVeiculo = default(string), string dsPlacaVeiculo = default(string), string nrSerieMotor = default(string), string cdTpCombustivelPrimario = default(string), string cdTpCombustivelSecundario = default(string), string cdTpOleo = default(string), int? idCentroFk = default(int?), int? idCtTrabalhoFk = default(int?), int? idCtPlanejamentoFk = default(int?), int? idGpPlanejamentoFk = default(int?), int? idCtCustoFk = default(int?), string arContabil = default(string), string nrImobilizado = default(string), string nrSubImobilizado = default(string), string nrPatrimonio = default(string), int? idCdAbcFk = default(int?), int? idPerfilFk = default(int?), BaseModel baseModel = default(BaseModel), Perfil perfilCatalogo = default(Perfil), CentroLocalizacao ctLocalizacao = default(CentroLocalizacao), CentroLocalizacao centroLocalizacao = default(CentroLocalizacao), CentroTrabalho centroTrabalho = default(CentroTrabalho), GrupoPlanejamento gpPlanejamento = default(GrupoPlanejamento), CentroCusto centroCusto = default(CentroCusto), CodigoABC codigoABC = default(CodigoABC), CategoriaEquipamento cgEquipamento = default(CategoriaEquipamento), Material material = default(Material), Material conjunto = default(Material), LocalInstalacao localInstalacao = default(LocalInstalacao), UnidadeMedida unidadeMedida = default(UnidadeMedida), CentroPlanejamento centroPlanejamento = default(CentroPlanejamento), IList<PontoMedicao> pontosMedicao = default(IList<PontoMedicao>))
        {
            IdEquipamento = idEquipamento;
            CdSap = cdSap;
            CdEquipamento = cdEquipamento;
            IdCgEquipamentoFk = idCgEquipamentoFk;
            DsEquipamento = dsEquipamento;
            TpEquipamento = tpEquipamento;
            StSistema = stSistema;
            StEquipamento = stEquipamento;
            IdCtLocalizacaoFk = idCtLocalizacaoFk;
            CpOrdenacao = cpOrdenacao;
            IdLcInstalacaoFk = idLcInstalacaoFk;
            IdEqSuperiorFk = idEqSuperiorFk;
            CrMgIndividual = crMgIndividual;
            SgPaisProdutor = sgPaisProdutor;
            DsFabricante = dsFabricante;
            RfFabricante = rfFabricante;
            NrSerieFabricante = nrSerieFabricante;
            NrAnoConstrucao = nrAnoConstrucao;
            NrMesConstrucao = nrMesConstrucao;
            DtAquisicao = dtAquisicao;
            DtIniFunc = dtIniFunc;
            DtInicioGarantia = dtInicioGarantia;
            DtFimGarantia = dtFimGarantia;
            CdHerdarGarantia = cdHerdarGarantia;
            NrIdentifTecnica = nrIdentifTecnica;
            NrDimensao = nrDimensao;
            PeBruto = peBruto;
            IdUnPesoFk = idUnPesoFk;
            IdMaterialFk = idMaterialFk;
            IdConjuntoFk = idConjuntoFk;
            TpVeiculo = tpVeiculo;
            NrIdentifVeiculo = nrIdentifVeiculo;
            DsPlacaVeiculo = dsPlacaVeiculo;
            NrSerieMotor = nrSerieMotor;
            CdTpCombustivelPrimario = cdTpCombustivelPrimario;
            CdTpCombustivelSecundario = cdTpCombustivelSecundario;
            CdTpOleo = cdTpOleo;
            IdCentroFk = idCentroFk;
            IdCtTrabalhoFk = idCtTrabalhoFk;
            IdCtPlanejamentoFk = idCtPlanejamentoFk;
            IdGpPlanejamentoFk = idGpPlanejamentoFk;
            IdCtCustoFk = idCtCustoFk;
            ArContabil = arContabil;
            NrImobilizado = nrImobilizado;
            NrSubImobilizado = nrSubImobilizado;
            NrPatrimonio = nrPatrimonio;
            IdCdAbcFk = idCdAbcFk;
            IdPerfilFk = idPerfilFk;
            BaseModel = baseModel;
            PerfilCatalogo = perfilCatalogo;
            CtLocalizacao = ctLocalizacao;
            CentroLocalizacao = centroLocalizacao;
            CentroTrabalho = centroTrabalho;
            GpPlanejamento = gpPlanejamento;
            CentroCusto = centroCusto;
            CodigoABC = codigoABC;
            CgEquipamento = cgEquipamento;
            Material = material;
            Conjunto = conjunto;
            LocalInstalacao = localInstalacao;
            UnidadeMedida = unidadeMedida;
            CentroPlanejamento = centroPlanejamento;
            PontosMedicao = pontosMedicao;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_equipamento")]
        public int? IdEquipamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_sap")]
        public string CdSap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_equipamento")]
        public string CdEquipamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_cg_equipamento_fk")]
        public int? IdCgEquipamentoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_equipamento")]
        public string DsEquipamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tp_equipamento")]
        public string TpEquipamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "st_sistema")]
        public string StSistema { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "st_equipamento")]
        public string StEquipamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_ct_localizacao_fk")]
        public int? IdCtLocalizacaoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cp_ordenacao")]
        public string CpOrdenacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_lc_instalacao_fk")]
        public int? IdLcInstalacaoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_eq_superior_fk")]
        public int? IdEqSuperiorFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cr_mg_individual")]
        public bool? CrMgIndividual { get; set; }

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
        [JsonProperty(PropertyName = "dt_ini_func")]
        public DateTime? DtIniFunc { get; set; }

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
        [JsonProperty(PropertyName = "cd_herdar_garantia")]
        public bool? CdHerdarGarantia { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_identif_tecnica")]
        public string NrIdentifTecnica { get; set; }

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
        [JsonProperty(PropertyName = "id_material_fk")]
        public int? IdMaterialFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_conjunto_fk")]
        public int? IdConjuntoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tp_veiculo")]
        public string TpVeiculo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_identif_veiculo")]
        public string NrIdentifVeiculo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_placa_veiculo")]
        public string DsPlacaVeiculo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_serie_motor")]
        public string NrSerieMotor { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_tp_combustivel_primario")]
        public string CdTpCombustivelPrimario { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_tp_combustivel_secundario")]
        public string CdTpCombustivelSecundario { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_tp_oleo")]
        public string CdTpOleo { get; set; }

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
        [JsonProperty(PropertyName = "nr_imobilizado")]
        public string NrImobilizado { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_sub_imobilizado")]
        public string NrSubImobilizado { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_patrimonio")]
        public string NrPatrimonio { get; set; }

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
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PerfilCatalogo")]
        public Perfil PerfilCatalogo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CtLocalizacao")]
        public CentroLocalizacao CtLocalizacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroLocalizacao")]
        public CentroLocalizacao CentroLocalizacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroTrabalho")]
        public CentroTrabalho CentroTrabalho { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "GpPlanejamento")]
        public GrupoPlanejamento GpPlanejamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroCusto")]
        public CentroCusto CentroCusto { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CodigoABC")]
        public CodigoABC CodigoABC { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CgEquipamento")]
        public CategoriaEquipamento CgEquipamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Material")]
        public Material Material { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Conjunto")]
        public Material Conjunto { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "LocalInstalacao")]
        public LocalInstalacao LocalInstalacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UnidadeMedida")]
        public UnidadeMedida UnidadeMedida { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroPlanejamento")]
        public CentroPlanejamento CentroPlanejamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PontosMedicao")]
        public IList<PontoMedicao> PontosMedicao { get; set; }

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
            if (this.CdEquipamento != null)
            {
                if (this.CdEquipamento.Length > 18)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdEquipamento", 18);
                }
                if (this.CdEquipamento.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdEquipamento", 0);
                }
            }
            if (this.DsEquipamento != null)
            {
                if (this.DsEquipamento.Length > 40)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsEquipamento", 40);
                }
                if (this.DsEquipamento.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsEquipamento", 0);
                }
            }
            if (this.TpEquipamento != null)
            {
                if (this.TpEquipamento.Length > 10)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "TpEquipamento", 10);
                }
                if (this.TpEquipamento.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "TpEquipamento", 0);
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
            if (this.StEquipamento != null)
            {
                if (this.StEquipamento.Length > 40)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "StEquipamento", 40);
                }
                if (this.StEquipamento.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "StEquipamento", 0);
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
            if (this.NrIdentifTecnica != null)
            {
                if (this.NrIdentifTecnica.Length > 25)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NrIdentifTecnica", 25);
                }
                if (this.NrIdentifTecnica.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NrIdentifTecnica", 0);
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
            if (this.TpVeiculo != null)
            {
                if (this.TpVeiculo.Length > 10)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "TpVeiculo", 10);
                }
                if (this.TpVeiculo.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "TpVeiculo", 0);
                }
            }
            if (this.NrIdentifVeiculo != null)
            {
                if (this.NrIdentifVeiculo.Length > 18)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NrIdentifVeiculo", 18);
                }
                if (this.NrIdentifVeiculo.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NrIdentifVeiculo", 0);
                }
            }
            if (this.DsPlacaVeiculo != null)
            {
                if (this.DsPlacaVeiculo.Length > 15)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsPlacaVeiculo", 15);
                }
                if (this.DsPlacaVeiculo.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsPlacaVeiculo", 0);
                }
            }
            if (this.NrSerieMotor != null)
            {
                if (this.NrSerieMotor.Length > 30)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NrSerieMotor", 30);
                }
                if (this.NrSerieMotor.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NrSerieMotor", 0);
                }
            }
            if (this.CdTpCombustivelPrimario != null)
            {
                if (this.CdTpCombustivelPrimario.Length > 12)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdTpCombustivelPrimario", 12);
                }
                if (this.CdTpCombustivelPrimario.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdTpCombustivelPrimario", 0);
                }
            }
            if (this.CdTpCombustivelSecundario != null)
            {
                if (this.CdTpCombustivelSecundario.Length > 12)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdTpCombustivelSecundario", 12);
                }
                if (this.CdTpCombustivelSecundario.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdTpCombustivelSecundario", 0);
                }
            }
            if (this.CdTpOleo != null)
            {
                if (this.CdTpOleo.Length > 12)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdTpOleo", 12);
                }
                if (this.CdTpOleo.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdTpOleo", 0);
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
            if (this.NrImobilizado != null)
            {
                if (this.NrImobilizado.Length > 12)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NrImobilizado", 12);
                }
                if (this.NrImobilizado.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NrImobilizado", 0);
                }
            }
            if (this.NrSubImobilizado != null)
            {
                if (this.NrSubImobilizado.Length > 4)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NrSubImobilizado", 4);
                }
                if (this.NrSubImobilizado.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NrSubImobilizado", 0);
                }
            }
            if (this.NrPatrimonio != null)
            {
                if (this.NrPatrimonio.Length > 25)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NrPatrimonio", 25);
                }
                if (this.NrPatrimonio.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NrPatrimonio", 0);
                }
            }
            if (this.PerfilCatalogo != null)
            {
                this.PerfilCatalogo.Validate();
            }
            if (this.CtLocalizacao != null)
            {
                this.CtLocalizacao.Validate();
            }
            if (this.CentroLocalizacao != null)
            {
                this.CentroLocalizacao.Validate();
            }
            if (this.CentroTrabalho != null)
            {
                this.CentroTrabalho.Validate();
            }
            if (this.GpPlanejamento != null)
            {
                this.GpPlanejamento.Validate();
            }
            if (this.CentroCusto != null)
            {
                this.CentroCusto.Validate();
            }
            if (this.CodigoABC != null)
            {
                this.CodigoABC.Validate();
            }
            if (this.CgEquipamento != null)
            {
                this.CgEquipamento.Validate();
            }
            if (this.Material != null)
            {
                this.Material.Validate();
            }
            if (this.Conjunto != null)
            {
                this.Conjunto.Validate();
            }
            if (this.LocalInstalacao != null)
            {
                this.LocalInstalacao.Validate();
            }
            if (this.CentroPlanejamento != null)
            {
                this.CentroPlanejamento.Validate();
            }
            if (this.PontosMedicao != null)
            {
                foreach (var element in this.PontosMedicao)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}