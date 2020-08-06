using PM.Domain.Entities;
using PM.Domain.Interfaces.Entities;
using System;
using System.Data.Entity;

namespace PM.Data.UnitOfWork
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        #region Declaração dos Repositórios

        private readonly GenericRepository<AreaOperacional> _areaOperacionalRepository;
        private readonly GenericRepository<CalendarioFabrica> _calendarioFabrica;
        private readonly GenericRepository<Capacidade> _capacidadeRepository;
        private readonly GenericRepository<CapacidadePessoal> _capacidadePessoalRepository;
        private readonly GenericRepository<Carro> _carroRepository;
        private readonly GenericRepository<Catalogo> _catalogoRepository;
        private readonly GenericRepository<CategoriaEquipamento> _categoriaEquipamentoRepository;
        private readonly GenericRepository<CategoriaItem> _categoriaItemRepository;
        private readonly GenericRepository<CategoriaPontoMedicao> _categoriaPontoMedicaoRepository;
        private readonly GenericRepository<CentroCusto> _centroCustoRepository;
        private readonly GenericRepository<CentroLocalizacao> _centroLocalizacaoRepository;
        private readonly GenericRepository<CentroPlanejamento> _centroPlanejamentoRepository;
        private readonly GenericRepository<CentroTrabalho> _centroTrabalhoRepository;
        private readonly GenericRepository<CentroTrabalhoTarifa> _centroTrabalhoTarifaRepository;
        private readonly GenericRepository<ChaveControle> _chaveControleRepository;
        private readonly GenericRepository<Classificacao> _classificacaoRepository;
        private readonly GenericRepository<Code> _codeRepository;
        private readonly GenericRepository<CodigoABC> _codigoABCRepository;
        private readonly GenericRepository<Complemento> _complementoRepository;
        private readonly GenericRepository<Deposito> _depositoRepository;
        private readonly GenericRepository<Diagnostico> _diagnosticoRepository;
        private readonly GenericRepository<Documento> _documentoRepository;
        private readonly GenericRepository<ElementoPEP> _elementoPEPRepository;
        private readonly GenericRepository<EntregaTrem> _entregaTremRepository;
        private readonly GenericRepository<Empregado> _empregadoRepository;
        private readonly GenericRepository<Equipamento> _equipamentoRepository;
        private readonly GenericRepository<EquipamentoRastreavel> _equipamentoRastreavelRepository;
        private readonly GenericRepository<Estrategia> _estrategiaRepository;
        private readonly GenericRepository<EstrategiaPacote> _estrategiaPacoteRepository;
        private readonly GenericRepository<EstruturaCentroTrabalho> _estruturaCentroTrabalhoRepository;
        private readonly GenericRepository<EventoGerador> _eventoGeradorRepository;
        private readonly GenericRepository<Frota> _frotaRepository;
        private readonly GenericRepository<GrupoAutorizacao> _grupoAutorizacaoRepository;
        private readonly GenericRepository<GrupoCode> _grupoCodeRepository;
        private readonly GenericRepository<GrupoPlanejamento> _grupoPlanejamentoRepository;
        private readonly GenericRepository<IntervencaoOperacao> _intervencaoOperacaoRepository;
        private readonly GenericRepository<Linha> _linhaRepository;
        private readonly GenericRepository<LinhaCentroTrabalho> _linhaCentroTrabalhoRepository;
        private readonly GenericRepository<ListaTarefa> _listatarefaRepository;
        private readonly GenericRepository<ListaTarefaOperacao> _listaTarefaOperacaoRepository;
        private readonly GenericRepository<ListaTarefaOperacaoComponente> _listaTarefaOperacaoComponenteRepository;
        private readonly GenericRepository<ListaTarefaOperacaoPacote> _listaTarefaOperacaoPacoteRepository;
        private readonly GenericRepository<ListaTecnicaMaterial> _listaTecnicaMaterialRepository;
        private readonly GenericRepository<ListaTecnicaMaterialItem> _listaTecnicaMaterialItemRepository;
        private readonly GenericRepository<LocalInstalacao> _localInstalacaoRepository;
        private readonly GenericRepository<Localizacao> _localizacaoRepository;
        private readonly GenericRepository<MAP> _mapRepository;
        private readonly GenericRepository<MaoDeObra> _maoDeObraRepository;
        private readonly GenericRepository<Marco> _marcoRepository;
        private readonly GenericRepository<Material> _materialRepository;
        private readonly GenericRepository<MaterialOperacao> _materialOperacaoRepository;
        private readonly GenericRepository<MedidaNota> _medidaNotaRepository;
        private readonly GenericRepository<ModeloLinear> _modeloLinearRepository;
        private readonly GenericRepository<MotivoEntrega> _motivoEntregaRepository;
        private readonly GenericRepository<MotivoNaoExecucao> _motivoNaoExecucaoRepository;
        private readonly GenericRepository<NivelAlerta> _nivelAlertaRepository;
        private readonly GenericRepository<Nota> _notaRepository;
        private readonly GenericRepository<NotaProgramacao> _notaProgramacaoRepository;
        private readonly GenericRepository<Manobra> _manobraRepository;
        private readonly GenericRepository<OperacaoOrdem> _operacaoOrdemRepository;
        private readonly GenericRepository<OperacaoProgramacaoEF> _operacaoProgramacaoEFRepository;
        private readonly GenericRepository<Ordem> _ordemRepository;
        private readonly GenericRepository<OrdemProgramacaoEF> _ordemProgramacaoEFRepository;
        private readonly GenericRepository<Patio> _patioRepository;
        private readonly GenericRepository<PatioLinha> _patioLinhaRepository;
        private readonly GenericRepository<Parceiro> _parceiroRepository;
        private readonly GenericRepository<Perfil> _perfilRepository;
        private readonly GenericRepository<Plano> _planoRepository;
        private readonly GenericRepository<PlanoItem> _planoItemRepository;
        private readonly GenericRepository<PontoMedicao> _pontoMedicaoRepository;
        private readonly GenericRepository<PontoMedicaoDocMedicao> _pontoMedicaoDocMedicaoRepository;
        private readonly GenericRepository<PontoMedicaoVinculo> _pontoMedicaoVinculoRepository;
        private readonly GenericRepository<Posicao> _posicaoRepository;
        private readonly GenericRepository<Prioridade> _prioridadeRepository;
        private readonly GenericRepository<PrioridadeSintoma> _prioridadeSintomaRepository;
        private readonly GenericRepository<PrioridadeCentroTrabalho> _prioridadeCentroTrabalhoRepository;
        private readonly GenericRepository<Programacao> _programacaoRepository;
        private readonly GenericRepository<ProgramacaoEF> _programacaoEFRepository;
        private readonly GenericRepository<Sistema> _sistemaRepository;
        private readonly GenericRepository<SistemaAplicacao> _sistemaAplicacaoRepository;
        private readonly GenericRepository<SistemaEmpresa> _sistemaEmpresaRepository;
        private readonly GenericRepository<SistemaLogError> _sistemaLogErrorRepository;
        private readonly GenericRepository<SistemaLogLogin> _sistemaLogLoginRepository;
        private readonly GenericRepository<SistemaLogOperacoes> _sistemaLogOperacoesRepository;
        private readonly GenericRepository<SistemaLogOperacoesItem> _sistemaLogOperacoesItemRepository;
        private readonly GenericRepository<SistemaModulo> _sistemaModuloRepository;
        private readonly GenericRepository<SistemaPerfil> _sistemaPerfilRepository;
        private readonly GenericRepository<SistemaPerfilItem> _sistemaPerfilItemRepository;
        private readonly GenericRepository<SistemaTabela> _sistemaTabelaRepository;
        private readonly GenericRepository<SistemaTabelaCampo> _sistemaTabelaCampoRepository;
        private readonly GenericRepository<SistemaTipoDado> _sistemaTipoDadoRepository;
        private readonly GenericRepository<SistemaTipoLog> _sistemaTipoLogRepository;
        private readonly GenericRepository<SistemaUsuario> _sistemaUsuarioRepository;
        private readonly GenericRepository<SistemaUsuarioModulo> _sistemaUsuarioModuloRepository;
        private readonly GenericRepository<StatusCopese> _statusCopeseRepository;
        private readonly GenericRepository<StatusListaTarefa> _statusListaTarefaRepository;
        private readonly GenericRepository<StatusMedida> _statusMedidaRepository;
        private readonly GenericRepository<StatusOperacao> _statusOperacaoRepository;
        private readonly GenericRepository<StatusPericia> _statusPericiaRepository;
        private readonly GenericRepository<StatusSistema> _statusSistemaRepository;
        private readonly GenericRepository<StatusTrem> _statusTremRepository;
        private readonly GenericRepository<StatusEntregaTrem> _statusEntregaTremRepository;
        private readonly GenericRepository<StatusProgramacaoTrem> _statusProgramacaoTremRepository;
        private readonly GenericRepository<StatusUsuario> _statusUsuarioRepository;
        private readonly GenericRepository<Tarifa> _tarifaRepository;
        private readonly GenericRepository<TipoCapacidade> _tipoCapacidadeRepository;
        private readonly GenericRepository<TipoCentroTrabalho> _tipoCentroTrabalhoRepository;
        private readonly GenericRepository<TipoMarcador> _tipoMarcadorRepository;
        private readonly GenericRepository<TipoNota> _tipoNotaRepository;
        private readonly GenericRepository<TipoOrdem> _tipoOrdemRepository;
        private readonly GenericRepository<ToleranciaMP> _toleranciaMPRepository;
        private readonly GenericRepository<Trem> _tremRepository;
        private readonly GenericRepository<UnidadeMedida> _unidadeMedidaRepository;
        private readonly GenericRepository<UtilizacaoListaTecnica> _utilizacaoListaTecnicaRepository;
        private readonly GenericRepository<Zona> _zonaRepository;

        #endregion

        public DatabaseContext() : base("ConnectionDev")
        {
            this.Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer<DatabaseContext>(null);

            #region Instanciando Conexão nos Repositórios

            _areaOperacionalRepository = new GenericRepository<AreaOperacional>(this);
            _calendarioFabrica = new GenericRepository<CalendarioFabrica>(this);
            _capacidadePessoalRepository = new GenericRepository<CapacidadePessoal>(this);
            _carroRepository = new GenericRepository<Carro>(this);
            _capacidadeRepository = new GenericRepository<Capacidade>(this);
            _catalogoRepository = new GenericRepository<Catalogo>(this);
            _categoriaEquipamentoRepository = new GenericRepository<CategoriaEquipamento>(this);
            _categoriaItemRepository = new GenericRepository<CategoriaItem>(this);
            _categoriaPontoMedicaoRepository = new GenericRepository<CategoriaPontoMedicao>(this);
            _centroCustoRepository = new GenericRepository<CentroCusto>(this);
            _centroLocalizacaoRepository = new GenericRepository<CentroLocalizacao>(this);
            _centroPlanejamentoRepository = new GenericRepository<CentroPlanejamento>(this);
            _centroTrabalhoRepository = new GenericRepository<CentroTrabalho>(this);
            _centroTrabalhoTarifaRepository = new GenericRepository<CentroTrabalhoTarifa>(this);
            _chaveControleRepository = new GenericRepository<ChaveControle>(this);
            _classificacaoRepository = new GenericRepository<Classificacao>(this);
            _codeRepository = new GenericRepository<Code>(this);
            _codigoABCRepository = new GenericRepository<CodigoABC>(this);
            _complementoRepository = new GenericRepository<Complemento>(this);
            _depositoRepository = new GenericRepository<Deposito>(this);
            _diagnosticoRepository = new GenericRepository<Diagnostico>(this);
            _documentoRepository = new GenericRepository<Documento>(this);
            _elementoPEPRepository = new GenericRepository<ElementoPEP>(this);
            _entregaTremRepository = new GenericRepository<EntregaTrem>(this);
            _empregadoRepository = new GenericRepository<Empregado>(this);
            _equipamentoRepository = new GenericRepository<Equipamento>(this);
            _equipamentoRastreavelRepository = new GenericRepository<EquipamentoRastreavel>(this);
            _estrategiaPacoteRepository = new GenericRepository<EstrategiaPacote>(this);
            _estruturaCentroTrabalhoRepository = new GenericRepository<EstruturaCentroTrabalho>(this);
            _estrategiaRepository = new GenericRepository<Estrategia>(this);
            _eventoGeradorRepository = new GenericRepository<EventoGerador>(this);
            _frotaRepository = new GenericRepository<Frota>(this);
            _grupoAutorizacaoRepository = new GenericRepository<GrupoAutorizacao>(this);
            _grupoCodeRepository = new GenericRepository<GrupoCode>(this);
            _grupoPlanejamentoRepository = new GenericRepository<GrupoPlanejamento>(this);
            _intervencaoOperacaoRepository = new GenericRepository<IntervencaoOperacao>(this);
            _linhaRepository = new GenericRepository<Linha>(this);
            _linhaCentroTrabalhoRepository = new GenericRepository<LinhaCentroTrabalho>(this);
            _listaTarefaOperacaoComponenteRepository = new GenericRepository<ListaTarefaOperacaoComponente>(this);
            _listaTarefaOperacaoPacoteRepository = new GenericRepository<ListaTarefaOperacaoPacote>(this);
            _listaTarefaOperacaoRepository = new GenericRepository<ListaTarefaOperacao>(this);
            _listaTecnicaMaterialItemRepository = new GenericRepository<ListaTecnicaMaterialItem>(this);
            _listaTecnicaMaterialRepository = new GenericRepository<ListaTecnicaMaterial>(this);
            _listatarefaRepository = new GenericRepository<ListaTarefa>(this);
            _localInstalacaoRepository = new GenericRepository<LocalInstalacao>(this);
            _localizacaoRepository = new GenericRepository<Localizacao>(this);
            _maoDeObraRepository = new GenericRepository<MaoDeObra>(this);
            _mapRepository = new GenericRepository<MAP>(this);
            _marcoRepository = new GenericRepository<Marco>(this);
            _materialOperacaoRepository = new GenericRepository<MaterialOperacao>(this);
            _materialRepository = new GenericRepository<Material>(this);
            _medidaNotaRepository = new GenericRepository<MedidaNota>(this);
            _modeloLinearRepository = new GenericRepository<ModeloLinear>(this);
            _motivoEntregaRepository = new GenericRepository<MotivoEntrega>(this);
            _motivoNaoExecucaoRepository = new GenericRepository<MotivoNaoExecucao>(this);
            _nivelAlertaRepository = new GenericRepository<NivelAlerta>(this);
            _notaRepository = new GenericRepository<Nota>(this);
            _notaProgramacaoRepository = new GenericRepository<NotaProgramacao>(this);
            _manobraRepository = new GenericRepository<Manobra>(this);
            _operacaoOrdemRepository = new GenericRepository<OperacaoOrdem>(this);
            _operacaoProgramacaoEFRepository = new GenericRepository<OperacaoProgramacaoEF>(this);
            _ordemRepository = new GenericRepository<Ordem>(this);
            _ordemProgramacaoEFRepository = new GenericRepository<OrdemProgramacaoEF>(this);
            _patioRepository = new GenericRepository<Patio>(this);
            _patioLinhaRepository = new GenericRepository<PatioLinha>(this);
            _parceiroRepository = new GenericRepository<Parceiro>(this);
            _perfilRepository = new GenericRepository<Perfil>(this);
            _planoItemRepository = new GenericRepository<PlanoItem>(this);
            _planoRepository = new GenericRepository<Plano>(this);
            _pontoMedicaoDocMedicaoRepository = new GenericRepository<PontoMedicaoDocMedicao>(this);
            _pontoMedicaoRepository = new GenericRepository<PontoMedicao>(this);
            _pontoMedicaoVinculoRepository = new GenericRepository<PontoMedicaoVinculo>(this);
            _posicaoRepository = new GenericRepository<Posicao>(this);
            _prioridadeRepository = new GenericRepository<Prioridade>(this);
            _prioridadeSintomaRepository = new GenericRepository<PrioridadeSintoma>(this);
            _prioridadeCentroTrabalhoRepository = new GenericRepository<PrioridadeCentroTrabalho>(this);
            _programacaoRepository = new GenericRepository<Programacao>(this);
            _programacaoEFRepository = new GenericRepository<ProgramacaoEF>(this);
            _sistemaAplicacaoRepository = new GenericRepository<SistemaAplicacao>(this);
            _sistemaEmpresaRepository = new GenericRepository<SistemaEmpresa>(this);
            _sistemaLogErrorRepository = new GenericRepository<SistemaLogError>(this);
            _sistemaLogLoginRepository = new GenericRepository<SistemaLogLogin>(this);
            _sistemaLogOperacoesRepository = new GenericRepository<SistemaLogOperacoes>(this);
            _sistemaLogOperacoesItemRepository = new GenericRepository<SistemaLogOperacoesItem>(this);
            _sistemaModuloRepository = new GenericRepository<SistemaModulo>(this);
            _sistemaPerfilRepository = new GenericRepository<SistemaPerfil>(this);
            _sistemaPerfilItemRepository = new GenericRepository<SistemaPerfilItem>(this);
            _sistemaTabelaRepository = new GenericRepository<SistemaTabela>(this);
            _sistemaTabelaCampoRepository = new GenericRepository<SistemaTabelaCampo>(this);
            _sistemaTipoDadoRepository = new GenericRepository<SistemaTipoDado>(this);
            _sistemaTipoLogRepository = new GenericRepository<SistemaTipoLog>(this);
            _sistemaUsuarioRepository = new GenericRepository<SistemaUsuario>(this);
            _sistemaUsuarioModuloRepository = new GenericRepository<SistemaUsuarioModulo>(this);
            _sistemaRepository = new GenericRepository<Sistema>(this);
            _statusCopeseRepository = new GenericRepository<StatusCopese>(this);
            _statusListaTarefaRepository = new GenericRepository<StatusListaTarefa>(this);
            _statusMedidaRepository = new GenericRepository<StatusMedida>(this);
            _statusOperacaoRepository = new GenericRepository<StatusOperacao>(this);
            _statusPericiaRepository = new GenericRepository<StatusPericia>(this);
            _statusSistemaRepository = new GenericRepository<StatusSistema>(this);
            _statusTremRepository = new GenericRepository<StatusTrem>(this);
            _statusEntregaTremRepository = new GenericRepository<StatusEntregaTrem>(this);
            _statusProgramacaoTremRepository = new GenericRepository<StatusProgramacaoTrem>(this);
            _statusUsuarioRepository = new GenericRepository<StatusUsuario>(this);
            _tarifaRepository = new GenericRepository<Tarifa>(this);
            _tipoCapacidadeRepository = new GenericRepository<TipoCapacidade>(this);
            _tipoCentroTrabalhoRepository = new GenericRepository<TipoCentroTrabalho>(this);
            _tipoMarcadorRepository = new GenericRepository<TipoMarcador>(this);
            _tipoNotaRepository = new GenericRepository<TipoNota>(this);
            _tipoOrdemRepository = new GenericRepository<TipoOrdem>(this);
            _toleranciaMPRepository = new GenericRepository<ToleranciaMP>(this);
            _tremRepository = new GenericRepository<Trem>(this);
            _unidadeMedidaRepository = new GenericRepository<UnidadeMedida>(this);
            _utilizacaoListaTecnicaRepository = new GenericRepository<UtilizacaoListaTecnica>(this);
            _zonaRepository = new GenericRepository<Zona>(this);

            #endregion
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations

            #region Tabelas a serem criadas

                .Add(new AreaOperacional())
                .Add(new CalendarioFabrica())
                .Add(new CapacidadePessoal())
                .Add(new Carro())
                .Add(new Capacidade())
                .Add(new Catalogo())
                .Add(new CategoriaEquipamento())
                .Add(new CategoriaItem())
                .Add(new CategoriaPontoMedicao())
                .Add(new CentroCusto())
                .Add(new CentroLocalizacao())
                .Add(new CentroPlanejamento())
                .Add(new CentroTrabalho())
                .Add(new CentroTrabalhoTarifa())
                .Add(new ChaveControle())
                .Add(new Classificacao())
                .Add(new Code())
                .Add(new CodigoABC())
                .Add(new Complemento())
                .Add(new Deposito())
                .Add(new Diagnostico())
                .Add(new Documento())
                .Add(new ElementoPEP())
                .Add(new Empregado())
                .Add(new Equipamento())
                .Add(new EquipamentoRastreavel())
                .Add(new EstrategiaPacote())
                .Add(new EstruturaCentroTrabalho())
                .Add(new Estrategia())
                .Add(new EventoGerador())
                .Add(new Frota())
                .Add(new GrupoAutorizacao())
                .Add(new GrupoCode())
                .Add(new GrupoPlanejamento())
                .Add(new IntervencaoOperacao())
                .Add(new Linha())
                .Add(new LinhaCentroTrabalho())
                .Add(new ListaTarefaOperacaoComponente())
                .Add(new ListaTarefaOperacaoPacote())
                .Add(new ListaTarefaOperacao())
                .Add(new ListaTecnicaMaterialItem())
                .Add(new ListaTecnicaMaterial())
                .Add(new ListaTarefa())
                .Add(new LocalInstalacao())
                .Add(new Localizacao())
                .Add(new MaoDeObra())
                .Add(new MAP())
                .Add(new Marco())
                .Add(new MaterialOperacao())
                .Add(new Material())
                .Add(new MedidaNota())
                .Add(new ModeloLinear())
                .Add(new MotivoEntrega())
                .Add(new EntregaTrem())
                .Add(new MotivoNaoExecucao())
                .Add(new NivelAlerta())
                .Add(new Nota())
                .Add(new NotaProgramacao())
                .Add(new Manobra())
                .Add(new OperacaoOrdem())
                .Add(new OperacaoProgramacaoEF())
                .Add(new Ordem())
                .Add(new OrdemProgramacaoEF())
                .Add(new Patio())
                .Add(new PatioLinha())
                .Add(new Parceiro())
                .Add(new Perfil())
                .Add(new PlanoItem())
                .Add(new Plano())
                .Add(new PontoMedicaoDocMedicao())
                .Add(new PontoMedicao())
                .Add(new PontoMedicaoVinculo())
                .Add(new Posicao())
                .Add(new Prioridade())
                .Add(new PrioridadeSintoma())
                .Add(new PrioridadeCentroTrabalho())
                .Add(new Programacao())
                .Add(new ProgramacaoEF())
                .Add(new SistemaAplicacao())
                .Add(new SistemaEmpresa())
                .Add(new SistemaLogError())
                .Add(new SistemaLogLogin())
                .Add(new SistemaLogOperacoes())
                .Add(new SistemaLogOperacoesItem())
                .Add(new SistemaModulo())
                .Add(new SistemaPerfil())
                .Add(new SistemaPerfilItem())
                .Add(new SistemaTabela())
                .Add(new SistemaTabelaCampo())
                .Add(new SistemaTipoDado())
                .Add(new SistemaTipoLog())
                .Add(new SistemaUsuario())
                .Add(new SistemaUsuarioModulo())
                .Add(new Sistema())
                .Add(new StatusCopese())
                .Add(new StatusListaTarefa())
                .Add(new StatusMedida())
                .Add(new StatusOperacao())
                .Add(new StatusPericia())
                .Add(new StatusSistema())
                .Add(new StatusTrem())
                .Add(new StatusEntregaTrem())
                .Add(new StatusProgramacaoTrem())
                .Add(new StatusUsuario())
                .Add(new Tarifa())
                .Add(new TipoCapacidade())
                .Add(new TipoCentroTrabalho())
                .Add(new TipoMarcador())
                .Add(new TipoNota())
                .Add(new TipoOrdem())
                .Add(new ToleranciaMP())
                .Add(new Trem())
                .Add(new UnidadeMedida())
                .Add(new UtilizacaoListaTecnica())
                .Add(new Zona())
            ;

            #endregion

            #region Tabelas de relacionamento

            modelBuilder.Entity<Nota>()
                .HasMany(c => c.StatusUsuarios).WithMany(i => i.Notas)
                .Map(t => t.MapLeftKey("id_nota")
                    .MapRightKey("id_st_usuario")
                    .ToTable("OONotasStatusUsuario"));

            modelBuilder.Entity<Ordem>()
                .HasMany(c => c.StatusUsuarios).WithMany(i => i.Ordens)
                .Map(t => t.MapLeftKey("id_ordem")
                    .MapRightKey("id_st_usuario")
                    .ToTable("OOOrdemStatusUsuario"));

            modelBuilder.Entity<Equipamento>()
                .HasMany(c => c.PontosMedicao).WithMany(i => i.Equipamentos)
                .Map(t => t.MapLeftKey("id_equipamento")
                    .MapRightKey("id_pt_medicao")
                    .ToTable("OOEquipamentoPontoMedicao"));

            modelBuilder.Entity<GrupoCode>()
                .HasMany(c => c.Catalogos).WithMany(i => i.GruposCode)
                .Map(t => t.MapLeftKey("id_gp_code")
                    .MapRightKey("id_catalogo")
                    .ToTable("OOGrupoCodeCatalogo"));

            modelBuilder.Entity<Catalogo>()
                .HasMany(c => c.Perfis).WithMany(i => i.Catalogos)
                .Map(t => t.MapLeftKey("id_catalogo")
                    .MapRightKey("id_perfil")
                    .ToTable("OOCatalogoPerfil"));

            #endregion

            
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("OO0009T".ToUpper());
        }

        #region Retorno dos Repositórios

        public IGenericRepository<AreaOperacional> AreaOperacionalRepository { get { return _areaOperacionalRepository; } }
        public IGenericRepository<CalendarioFabrica> CalendarioFabricaRepository { get { return _calendarioFabrica; } }
        public IGenericRepository<Capacidade> CapacidadeRepository { get { return _capacidadeRepository; } }
        public IGenericRepository<CapacidadePessoal> CapacidadePessoalRepository { get { return _capacidadePessoalRepository; } }
        public IGenericRepository<Carro> CarroRepository { get { return _carroRepository; } }
        public IGenericRepository<Catalogo> CatalogoRepository { get { return _catalogoRepository; } }
        public IGenericRepository<CategoriaEquipamento> CategoriaEquipamentoRepository { get { return _categoriaEquipamentoRepository; } }
        public IGenericRepository<CategoriaItem> CategoriaItemRepository { get { return _categoriaItemRepository; } }
        public IGenericRepository<CategoriaPontoMedicao> CategoriaPontoMedicaoRepository { get { return _categoriaPontoMedicaoRepository; } }
        public IGenericRepository<CentroCusto> CentroCustoRepository { get { return _centroCustoRepository; } }
        public IGenericRepository<CentroLocalizacao> CentroLocalizacaoRepository { get { return _centroLocalizacaoRepository; } }
        public IGenericRepository<CentroPlanejamento> CentroPlanejamentoRepository { get { return _centroPlanejamentoRepository; } }
        public IGenericRepository<CentroTrabalho> CentroTrabalhoRepository { get { return _centroTrabalhoRepository; } }
        public IGenericRepository<CentroTrabalhoTarifa> CentroTrabalhoTarifaRepository { get { return _centroTrabalhoTarifaRepository; } }
        public IGenericRepository<ChaveControle> ChaveControleRepository { get { return _chaveControleRepository; } }
        public IGenericRepository<Classificacao> ClassificacaoRepository { get { return _classificacaoRepository; } }
        public IGenericRepository<Code> CodeRepository { get { return _codeRepository; } }
        public IGenericRepository<CodigoABC> CodigoABCRepository { get { return _codigoABCRepository; } }
        public IGenericRepository<Complemento> ComplementoRepository { get { return _complementoRepository; } }
        public IGenericRepository<Deposito> DepositoRepository { get { return _depositoRepository; } }
        public IGenericRepository<Diagnostico> DiagnosticoRepository { get { return _diagnosticoRepository; } }
        public IGenericRepository<Documento> DocumentoRepository { get { return _documentoRepository; } }
        public IGenericRepository<ElementoPEP> ElementoPEPRepository { get { return _elementoPEPRepository; } }
        public IGenericRepository<EntregaTrem> EntregaTremRepository { get { return _entregaTremRepository; } }
        public IGenericRepository<Empregado> EmpregadoRepository { get { return _empregadoRepository; } }
        public IGenericRepository<Equipamento> EquipamentoRepository { get { return _equipamentoRepository; } }
        public IGenericRepository<EquipamentoRastreavel> EquipamentoRastreavelRepository { get { return _equipamentoRastreavelRepository; } }
        public IGenericRepository<Estrategia> EstrategiaRepository { get { return _estrategiaRepository; } }
        public IGenericRepository<EstrategiaPacote> EstrategiaPacoteRepository { get { return _estrategiaPacoteRepository; } }
        public IGenericRepository<EstruturaCentroTrabalho> EstruturaCentroTrabalhoRepository { get { return _estruturaCentroTrabalhoRepository; } }
        public IGenericRepository<EventoGerador> EventoGeradorRepository { get { return _eventoGeradorRepository; } }
        public IGenericRepository<Frota> FrotaRepository { get { return _frotaRepository; } }
        public IGenericRepository<GrupoAutorizacao> GrupoAutorizacaoRepository { get { return _grupoAutorizacaoRepository; } }
        public IGenericRepository<GrupoCode> GrupoCodeRepository { get { return _grupoCodeRepository; } }
        public IGenericRepository<GrupoPlanejamento> GrupoPlanejamentoRepository { get { return _grupoPlanejamentoRepository; } }
        public IGenericRepository<IntervencaoOperacao> IntervencaoOperacaoRepository { get { return _intervencaoOperacaoRepository; } }
        public IGenericRepository<Linha> LinhaRepository { get { return _linhaRepository; } }
        public IGenericRepository<LinhaCentroTrabalho> LinhaCentroTrabalhoRepository { get { return _linhaCentroTrabalhoRepository; } }
        public IGenericRepository<ListaTarefa> ListaTarefaRepository { get { return _listatarefaRepository; } }
        public IGenericRepository<ListaTarefaOperacao> ListaTarefaOperacaoRepository { get { return _listaTarefaOperacaoRepository; } }
        public IGenericRepository<ListaTarefaOperacaoComponente> ListaTarefaOperacaoComponenteRepository { get { return _listaTarefaOperacaoComponenteRepository; } }
        public IGenericRepository<ListaTarefaOperacaoPacote> ListaTarefaOperacaoPacoteRepository { get { return _listaTarefaOperacaoPacoteRepository; } }
        public IGenericRepository<ListaTecnicaMaterial> ListaTecnicaMaterialRepository { get { return _listaTecnicaMaterialRepository; } }
        public IGenericRepository<ListaTecnicaMaterialItem> ListaTecnicaMaterialItemRepository { get { return _listaTecnicaMaterialItemRepository; } }
        public IGenericRepository<LocalInstalacao> LocalInstalacaoRepository { get { return _localInstalacaoRepository; } }
        public IGenericRepository<Localizacao> LocalizacaoRepository { get { return _localizacaoRepository; } }
        public IGenericRepository<MAP> MapRepository { get { return _mapRepository; } }
        public IGenericRepository<MaoDeObra> MaoDeObraRepository { get { return _maoDeObraRepository; } }
        public IGenericRepository<Marco> MarcoRepository { get { return _marcoRepository; } }
        public IGenericRepository<Material> MaterialRepository { get { return _materialRepository; } }
        public IGenericRepository<MaterialOperacao> MaterialOperacaoRepository { get { return _materialOperacaoRepository; } }
        public IGenericRepository<MedidaNota> MedidaNotaRepository { get { return _medidaNotaRepository; } }
        public IGenericRepository<ModeloLinear> ModeloLinearRepository { get { return _modeloLinearRepository; } }
        public IGenericRepository<MotivoEntrega> MotivoEntregaRepository { get { return _motivoEntregaRepository; } }
        public IGenericRepository<MotivoNaoExecucao> MotivoNaoExecucaoRepository { get { return _motivoNaoExecucaoRepository; } }
        public IGenericRepository<NivelAlerta> NivelAlertaRepository { get { return _nivelAlertaRepository; } }
        public IGenericRepository<Nota> NotaRepository { get { return _notaRepository; } }
        public IGenericRepository<NotaProgramacao> NotaProgramacaoRepository { get { return _notaProgramacaoRepository; } }
        public IGenericRepository<Manobra> ManobraRepository { get { return _manobraRepository; } }
        public IGenericRepository<OperacaoOrdem> OperacaoOrdemRepository { get { return _operacaoOrdemRepository; } }
        public IGenericRepository<OperacaoProgramacaoEF> OperacaoProgramacaoEFRepository { get { return _operacaoProgramacaoEFRepository; } }
        public IGenericRepository<Ordem> OrdemRepository { get { return _ordemRepository; } }
        public IGenericRepository<OrdemProgramacaoEF> OrdemProgramacaoEFRepository { get { return _ordemProgramacaoEFRepository; } }
        public IGenericRepository<Patio> PatioRepository { get { return _patioRepository; } }
        public IGenericRepository<PatioLinha> PatioLinhaRepository { get { return _patioLinhaRepository; } }
        public IGenericRepository<Parceiro> ParceiroRepository { get { return _parceiroRepository; } }
        public IGenericRepository<Perfil> PerfilRepository { get { return _perfilRepository; } }
        public IGenericRepository<Plano> PlanoRepository { get { return _planoRepository; } }
        public IGenericRepository<PontoMedicao> PontoMedicaoRepository { get { return _pontoMedicaoRepository; } }
        public IGenericRepository<PontoMedicaoDocMedicao> PontoMedicaoDocMedicaoRepository { get { return _pontoMedicaoDocMedicaoRepository; } }
        public IGenericRepository<PontoMedicaoVinculo> PontoMedicaoVinculoRepository { get { return _pontoMedicaoVinculoRepository; } }
        public IGenericRepository<Posicao> PosicaoRepository { get { return _posicaoRepository; } }
        public IGenericRepository<Prioridade> PrioridadeRepository { get { return _prioridadeRepository; } }
        public IGenericRepository<PrioridadeSintoma> PrioridadeSintomaRepository { get { return _prioridadeSintomaRepository; } }
        public IGenericRepository<PrioridadeCentroTrabalho> PrioridadeCentroTrabalhoRepository { get { return _prioridadeCentroTrabalhoRepository; } }
        public IGenericRepository<Programacao> ProgramacaoRepository { get { return _programacaoRepository; } }
        public IGenericRepository<ProgramacaoEF> ProgramacaoEquipamentoFixoRepository { get { return _programacaoEFRepository; } }
        public IGenericRepository<SistemaAplicacao> SistemaAplicacaoRepository { get { return _sistemaAplicacaoRepository; } }
        public IGenericRepository<SistemaEmpresa> SistemaEmpresaRepository { get { return _sistemaEmpresaRepository; } }
        public IGenericRepository<SistemaLogError> SistemaLogErrorRepository { get { return _sistemaLogErrorRepository; } }
        public IGenericRepository<SistemaLogLogin> SistemaLogLoginRepository { get { return _sistemaLogLoginRepository; } }
        public IGenericRepository<SistemaLogOperacoes> SistemaLogOperacoesRepository { get { return _sistemaLogOperacoesRepository; } }
        public IGenericRepository<SistemaLogOperacoesItem> SistemaLogOperacoesItemRepository { get { return _sistemaLogOperacoesItemRepository; } }
        public IGenericRepository<SistemaModulo> SistemaModuloRepository { get { return _sistemaModuloRepository; } }
        public IGenericRepository<SistemaPerfil> SistemaPerfilRepository { get { return _sistemaPerfilRepository; } }
        public IGenericRepository<SistemaPerfilItem> SistemaPerfilItemRepository { get { return _sistemaPerfilItemRepository; } }
        public IGenericRepository<Sistema> SistemaRepository { get { return _sistemaRepository; } }
        public IGenericRepository<SistemaTabela> SistemaTabelaRepository { get { return _sistemaTabelaRepository; } }
        public IGenericRepository<SistemaTabelaCampo> SistemaTabelaCampoRepository { get { return _sistemaTabelaCampoRepository; } }
        public IGenericRepository<SistemaTipoDado> SistemaTipoDadoRepository { get { return _sistemaTipoDadoRepository; } }
        public IGenericRepository<SistemaTipoLog> SistemaTipoLogRepository { get { return _sistemaTipoLogRepository; } }
        public IGenericRepository<SistemaUsuario> SistemaUsuarioRepository { get { return _sistemaUsuarioRepository; } }
        public IGenericRepository<SistemaUsuarioModulo> SistemaUsuarioModuloRepository { get { return _sistemaUsuarioModuloRepository; } }
        public IGenericRepository<StatusCopese> StatusCopeseRepository { get { return _statusCopeseRepository; } }
        public IGenericRepository<StatusListaTarefa> StatusListaTarefaRepository { get { return _statusListaTarefaRepository; } }
        public IGenericRepository<StatusMedida> StatusMedidaRepository { get { return _statusMedidaRepository; } }
        public IGenericRepository<StatusOperacao> StatusOperacaoRepository { get { return _statusOperacaoRepository; } }
        public IGenericRepository<StatusPericia> StatusPericiaRepository { get { return _statusPericiaRepository; } }
        public IGenericRepository<StatusSistema> StatusSistemaRepository { get { return _statusSistemaRepository; } }
        public IGenericRepository<StatusTrem> StatusTremRepository { get { return _statusTremRepository; } }
        public IGenericRepository<StatusEntregaTrem> StatusEntregaTremRepository { get { return _statusEntregaTremRepository; } }
        public IGenericRepository<StatusProgramacaoTrem> StatusProgramacaoTremRepository { get { return _statusProgramacaoTremRepository; } }
        public IGenericRepository<StatusUsuario> StatusUsuarioRepository { get { return _statusUsuarioRepository; } }
        public IGenericRepository<Tarifa> TarifaRepository { get { return _tarifaRepository; } }
        public IGenericRepository<TipoCapacidade> TipoCapacidadeRepository { get { return _tipoCapacidadeRepository; } }
        public IGenericRepository<TipoCentroTrabalho> TipoCentroTrabalhoRepository { get { return _tipoCentroTrabalhoRepository; } }
        public IGenericRepository<TipoMarcador> TipoMarcadorRepository { get { return _tipoMarcadorRepository; } }
        public IGenericRepository<TipoNota> TipoNotaRepository { get { return _tipoNotaRepository; } }
        public IGenericRepository<TipoOrdem> TipoOrdemRepository { get { return _tipoOrdemRepository; } }
        public IGenericRepository<ToleranciaMP> ToleranciaMPRepository { get { return _toleranciaMPRepository; } }
        public IGenericRepository<Trem> TremRepository { get { return _tremRepository; } }
        public IGenericRepository<UnidadeMedida> UnidadeMedidaRepository { get { return _unidadeMedidaRepository; } }
        public IGenericRepository<UtilizacaoListaTecnica> UtilizacaoListaTecnicaRepository { get { return _utilizacaoListaTecnicaRepository; } }
        public IGenericRepository<Zona> ZonaRepository { get { return _zonaRepository; } }

        #endregion

        public void Commit(string user = "")
        {
            var entries = this.ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                var obj = entry.Entity as IAuditable;
                if (obj != null && !string.IsNullOrEmpty(user))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            obj.CreatedAt = DateTime.Now;
                            obj.CreatedBy = user;
                            break;
                        case EntityState.Modified:
                            obj.UpdatedAt = DateTime.Now;
                            obj.UpdatedBy = user;
                            break;
                    }
                }
            }

            this.SaveChanges();
        }

        public void Rollback()
        {
            var entries = this.ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Detached)
                {
                    entry.State = EntityState.Detached;
                }
                else
                {
                    entry.Reload();
                }
            }
        }

        public void DisableAutoDetectChanges()
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public void EnableAutoDetectChanges()
        {
            this.Configuration.AutoDetectChangesEnabled = true;
        }

        public void DisableValidateOnSave()
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public void EnableValidateOnSave()
        {
            this.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}