using PM.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PM.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //IGenericRepository<AreaOperacional> AreaOperacionalRepository { get; }

        //IGenericRepository<CalendarioFabrica> CalendarioFabricaRepository { get; }
        //IGenericRepository<Capacidade> CapacidadeRepository { get; }
        //IGenericRepository<CapacidadePessoal> CapacidadePessoalRepository { get; }
        //IGenericRepository<Carro> CarroRepository { get; }
        //IGenericRepository<CategoriaDados> CategoriaDadosRepository { get; }
        //IGenericRepository<CategoriaEquipamento> CategoriaEquipamentoRepository { get; }
        //IGenericRepository<CategoriaPontoMedicao> CategoriaPontoMedicaoRepository { get; }
        //IGenericRepository<CentroCusto> CentroCustoRepository { get; }
        //IGenericRepository<CentroLocalizacao> CentroLocalizacaoRepository { get; }
        //IGenericRepository<CentroTrabalho> CentroTrabalhoRepository { get; }
        //IGenericRepository<CentroTrabalhoTarifa> CentroTrabalhoTarifaRepository { get; }
        //IGenericRepository<Classificacao> ClassificacaoRepository { get; }
        //IGenericRepository<ChaveAplicacao> ChaveAplicacaoRepository { get; }
        //IGenericRepository<ChaveControle> ChaveControleRepository { get; }
        //IGenericRepository<ChaveRoteiro> ChaveRoteiroRepository { get; }
        //IGenericRepository<Code> CodeRepository { get; }
        //IGenericRepository<CodigoABC> CodigoABCRepository { get; }

        //IGenericRepository<DistanciaMarcador> DistanciaMarcadorRepository { get; }

        //IGenericRepository<Equipamento> EquipamentoRepository { get; }
        //IGenericRepository<Estrategia> EstrategiaRepository { get; }
        //IGenericRepository<EstrategiaPacote> EstrategiaPacoteRepository { get; }
        //IGenericRepository<EquipamentoStatus> EquipamentoStatusRepository { get; }

        //IGenericRepository<GrupoCode> GrCodeRepository { get; }
        //IGenericRepository<GrupoCaracteristica> GrupoCaracteristicaRepository { get; }
        //IGenericRepository<GrupoAutorizacao> GrupoPlanAutorizacoesRepository { get; }

        //IGenericRepository<Linha> LinhaRepository { get; }
        //IGenericRepository<ListaTarefasMap> ListaTarefasMapRepository { get; }
        //IGenericRepository<ListaTarefa> ListaTarefasRepository { get; }
        //IGenericRepository<ListaTarefaOperacao> ListaTarefasOperacaoRepository { get; }
        //IGenericRepository<ListaTarefaOperacaoComponente> ListaTarefasOperacaoComponenteRepository { get; }
        //IGenericRepository<ListaTarefaOperacaoPacote> ListaTarefasOperacaoPacoteRepository { get; }
        //IGenericRepository<ListaTecnicaMaterial> ListaTecnicaMaterialRepository { get; }
        //IGenericRepository<ListaTecnicaMaterialItem> ListaTecnicaMaterialItemRepository { get; }
        //IGenericRepository<LocalInstalacao> LocalInstalacaoRepository { get; }
        //IGenericRepository<Log> LogRepository { get; }

        //IGenericRepository<Marco> MarcosRepository { get; }

        //IGenericRepository<ModeloLinear> ModeloLinearRepository { get; }

        //IGenericRepository<Nota> NotasRepository { get; }

        //IGenericRepository<TipoObjetoTecnico> ObjetoTecnicoRepository { get; }

        //IGenericRepository<Pacote> PacoteRepository { get; }
        //IGenericRepository<Parceiro> ParceiroRepository { get; }
        //IGenericRepository<Perfil> PerfilCatalogoRepository { get; }
        //IGenericRepository<Plano> PlanoRepository { get; }
        //IGenericRepository<PlanoItem> PlanoItemRepository { get; }
        //IGenericRepository<PontoMedicao> PontoMedicaoRepository { get; }
        //IGenericRepository<PontoMedicaoDocMedicao> PontoMedicaoDocMedicaoRepository { get; }
        //IGenericRepository<PontoMedicaoVinculo> PontoMedicaoVinculoRepository { get; }

        //IGenericRepository<ReferenciaLinear> ReferenciaLinearRepository { get; }

        //IGenericRepository<SistemaLogLogin> SistemaLogLoginRepository { get; }
        //IGenericRepository<Sistema> SistemaRepository { get; }

        //IGenericRepository<Tarifa> TarifaRepository { get; }
        //IGenericRepository<TipoCapacidade> TipoCapacidadeRepository { get; }
        //IGenericRepository<TipoCentroTrabalho> TipoCentroTrabalhoRepository { get; }
        //IGenericRepository<TipoOrdem> TipoOrdemRepository { get; }
        //IGenericRepository<TipoClasse> TipoClasseRepository { get; }
        //IGenericRepository<TipoMarcador> TipoMarcadorRepository { get; }
        //IGenericRepository<TipoNota> TipoNotaRepository { get; }
        //IGenericRepository<TipoVeiculo> TipoVeiculoRepository { get; }
        //IGenericRepository<Trem> TremRepository { get; }

        //IGenericRepository<UnidadeMedida> UnidadeMedidaRepository { get; }

        //IGenericRepository<Zona> ZonaRepository { get; }

        //IGenericRepository<MenuSistema> MenuSistemaRepository { get; }


        Task CommitAsync();
        void Commit(string user = "");
        void Rollback();
        void DisableAutoDetectChanges();
        void EnableAutoDetectChanges();
        void DisableValidateOnSave();
        void EnableValidateOnSave();
    }
}