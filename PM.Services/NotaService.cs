using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using PM.Domain.Entities.Enum;
using System.Linq.Expressions;

namespace PM.Services
{
    public class NotaService
    {
        private DatabaseContext context;

        public NotaService()
        {
            context = new DatabaseContext();
        }

        public NotaService(DatabaseContext dbContext)
        {
            context = dbContext;
        }

        public Nota GetByID(int id)
        {
            return context.NotaRepository.GetById(id);
        }

        public Nota GetNotaStatusUsuarioById(int id)
        {
            Nota nota = context.NotaRepository.AsQueryable()
                           .Include(x => x.StatusUsuarios)
                           .Where(x => x.id_nota == id)
                           .FirstOrDefault();

            return nota;
        }

        public Nota GetNavigationPropertiesByID(int id)
        {
            Nota nota = context.NotaRepository.AsQueryable()
                .Include(x => x.TipoNota)
                .Include(x => x.LocalInstalacao)
                .Include(x => x.LocalInstPrinc)
                .Include(x => x.NotaReferencia)
                .Include(x => x.StatusSistema)
                .Include(x => x.CodeSintoma)
                .Include(x => x.Prioridade)
                .Include(x => x.Empregado)
                .Include(x => x.CentroTrabalho)
                .Include(x => x.ElementoPEP)
                .Include(x => x.Equipamento)
                .Include(x => x.Material)
                .Include(x => x.UnidadeMedidaTempoPrevisto)
                .Include(x => x.StatusPericia)
                .Include(x => x.EventoGerador)
                .Include(x => x.Diagnostico)
                .Include(x => x.StatusUsuarios)
                .Include(x => x.MedidasNota)
                .Include(x => x.Solicitante)
                .Where(x => x.id_nota == id)
                .FirstOrDefault();
            return nota;
        }

        public List<Nota> GetNotasVinculadas(int id)
        {
            List<Nota> notas = context.NotaRepository.Find(x => x.id_nota_vinculo_fk == id);
            return notas;
        }

        public List<Nota> GetNotasVinculadasEntregaTrem(int idEntregaTrem, int idTipoNota)
        {
            List<Nota> notas = context.NotaRepository.AsQueryable()
                                .Include(x => x.TipoNota)
                                .Include(x => x.LocalInstalacao)
                                .Include(x => x.MedidasNota)
                                .Include(x => x.CodeSintoma)
                                .Include(x => x.Prioridade)
                                .Include(x => x.CentroTrabalho)
                                .Include(x => x.Empregado)
                                .Include(x => x.MedidasNota)
                                .Include(x => x.EntregaTrem)
                                .Include(x => x.StatusSistema)
                                .Include(x => x.StatusUsuarios)
                                .ToList()
                                .Where(x => x.id_entrega_trem_fk.Equals(idEntregaTrem) &&
                                            x.id_tp_nota_fk.Equals(idTipoNota)
                                      ).ToList();
            return notas;
        }

        public List<Nota> GetNotasVinculadasNavigationProperties(int id)
        {
            List<Nota> notas = context.NotaRepository.AsQueryable()
                .Include(x => x.TipoNota)
                .Include(x => x.LocalInstalacao)
                .Include(x => x.LocalInstPrinc)
                .Include(x => x.NotaReferencia)
                .Include(x => x.StatusSistema)
                .Include(x => x.CodeSintoma)
                .Include(x => x.Prioridade)
                .Include(x => x.CentroTrabalho)
                .Include(x => x.ElementoPEP)
                .Include(x => x.Equipamento)
                .Include(x => x.Material)
                .Include(x => x.UnidadeMedidaTempoPrevisto)
                .Include(x => x.StatusPericia)
                .Include(x => x.EventoGerador)
                .Include(x => x.Diagnostico)
                .Where(x => x.id_nota_vinculo_fk == id)
                .ToList();

            return notas;
        }

        public List<Nota> GetNotaVinculadaTrem(int idTrem, string cd_sap)
        {
            List<Nota> notas = new List<Nota>();

            TipoNota oTipoNota = (new TipoNotaService()).GetByCodigoSap(cd_sap);
            try
            {
                notas = context.NotaRepository.AsQueryable()
                    .Include(x => x.TipoNota)
                    .Include(x => x.LocalInstalacao)
                    .Include(x => x.MedidasNota)
                    .Include(x => x.CodeSintoma)
                    .Include(x => x.Prioridade)
                    .Include(x => x.CentroTrabalho)
                    .Include(x => x.Empregado)
                    .Include(x => x.MedidasNota)
                    .Include(x => x.EntregaTrem)
                    .Include(x => x.StatusSistema)
                    .Include(x => x.StatusUsuarios)
                    .Where(x => x.LocalInstalacao.id_trem_fk == idTrem && x.id_tp_nota_fk == oTipoNota.id_tp_nota
                        && x.MedidasNota.Any(i => i.StatusUsuario.cd_sap == "ABER")
                        && (x.StatusUsuarios.Any(i => i.cd_sap != "RECB") || x.StatusUsuarios.Any(i => i.cd_sap != "CANC")  /*|| x.StatusUsuarios.Count.Equals(0)*/)
                       ).ToList();
                notas = notas.Where(c => c.id_entrega_trem_fk == null).OrderBy(c => c.id_nota).ToList();

            }
            catch (Exception ex)
            {
                ex = ex;
            }
            return notas;
        }

        public List<Nota> GetAll()
        {
            return context.NotaRepository.GetAll();
        }

        public Nota GetNotasCodigoSap(string nr_nota_sap)
        {
            Nota notas = context.NotaRepository.AsQueryable()
                .Include(x => x.TipoNota)
                .Include(x => x.LocalInstalacao)
                .Include(x => x.LocalInstPrinc)
                .Include(x => x.NotaReferencia)
                .Include(x => x.StatusSistema)
                .Include(x => x.CodeSintoma)
                .Include(x => x.Prioridade)
                .Include(x => x.CentroTrabalho)
                .Include(x => x.ElementoPEP)
                .Include(x => x.Equipamento)
                .Include(x => x.Material)
                .Include(x => x.UnidadeMedidaTempoPrevisto)
                .Include(x => x.StatusPericia)
                .Include(x => x.EventoGerador)
                .Include(x => x.Diagnostico)
                .Where(x => x.cd_nota_sap == nr_nota_sap)
                .First();

            return notas;
        }

        public Nota GetNotasCodigoSapPericia(string nr_nota_sap)
        {
            Nota notas = context.NotaRepository.AsQueryable()
                .Include(x => x.TipoNota)
                .Include(x => x.LocalInstalacao)
                .Include(x => x.Empregado)
                .Include(x => x.CentroTrabalho)
                .Where(x => x.cd_nota_sap == nr_nota_sap)
                .First();

            return notas;
        }
        public Nota GetNotasCodigoSapMR(string nr_nota_sap)
        {
            TipoNotaService tipoNotaService = new TipoNotaService();

            int idMC = tipoNotaService.GetByCodigoSap(TipoNotaSelecionarType.MC.ToString()).id_tp_nota;
            int idMI = tipoNotaService.GetByCodigoSap(TipoNotaSelecionarType.MI.ToString()).id_tp_nota;
            int idMP = tipoNotaService.GetByCodigoSap(TipoNotaSelecionarType.MP.ToString()).id_tp_nota;
            int idMS = tipoNotaService.GetByCodigoSap(TipoNotaSelecionarType.MS.ToString()).id_tp_nota;

            var parameterExpression = Expression.Parameter(typeof(Nota), "n");
            Nota notaInit = new Nota();

            var propertyTpNota = Expression.Property(parameterExpression, "id_tp_nota_fk");
            var propertyTpNotaConverted = Expression.Convert(propertyTpNota, notaInit.id_tp_nota_fk.GetType());

            var expressionTpNotaMc = Expression.Equal(propertyTpNotaConverted, Expression.Constant(idMC));
            var expressionTpNotaMi = Expression.Equal(propertyTpNotaConverted, Expression.Constant(idMI));
            var expressionTpNotaMp = Expression.Equal(propertyTpNotaConverted, Expression.Constant(idMP));
            var expressionTpNotaMs = Expression.Equal(propertyTpNotaConverted, Expression.Constant(idMS));

            Expression expression = Expression.Or(expressionTpNotaMc, expressionTpNotaMi);
            expression = Expression.Or(expression, expressionTpNotaMp);
            expression = Expression.Or(expression, expressionTpNotaMs);

            #region CdNotaSap            
            var constantCdNotaSap = Expression.Constant(nr_nota_sap);
            var propertyCdNotaSap = Expression.Property(parameterExpression, "cd_nota_sap");
            var expressionCdNotaSap = Expression.Equal(propertyCdNotaSap, constantCdNotaSap);
            expression = Expression.And(expression, expressionCdNotaSap);
            #endregion

            var lambda = Expression.Lambda<Func<Nota, bool>>(expression, parameterExpression);
            var compiledLambda = lambda.Compile();

            Nota notas = context.NotaRepository.AsQueryable()
                .Include(x => x.TipoNota)
                .Include(x => x.LocalInstalacao)
                .Include(x => x.LocalInstPrinc)
                .Include(x => x.NotaReferencia)
                .Include(x => x.StatusSistema)
                .Include(x => x.CodeSintoma)
                .Include(x => x.Prioridade)
                .Include(x => x.CentroTrabalho)
                .Include(x => x.ElementoPEP)
                .Include(x => x.Equipamento)
                .Include(x => x.Material)
                .Include(x => x.UnidadeMedidaTempoPrevisto)
                .Include(x => x.StatusPericia)
                .Include(x => x.EventoGerador)
                .Include(x => x.Diagnostico)
                .Where(x => (x.id_tp_nota_fk == idMC || x.id_tp_nota_fk == idMI || x.id_tp_nota_fk == idMP || x.id_tp_nota_fk == idMS) && (x.cd_nota_sap == nr_nota_sap)).First();

            return notas;
        }

        public Nota GetNotasCodigoSapEF(string nr_nota_sap)
        {
            TipoNotaService tipoNotaService = new TipoNotaService();

            Nota notas = context.NotaRepository.AsQueryable()
                .Include(x => x.TipoNota)
                .Include(x => x.LocalInstalacao)
                .Include(x => x.LocalInstPrinc)
                .Include(x => x.NotaReferencia)
                .Include(x => x.StatusSistema)
                .Include(x => x.CodeSintoma)
                .Include(x => x.Prioridade)
                .Include(x => x.CentroTrabalho)
                .Include(x => x.ElementoPEP)
                .Include(x => x.Equipamento)
                .Include(x => x.Material)
                .Include(x => x.UnidadeMedidaTempoPrevisto)
                .Include(x => x.StatusPericia)
                .Include(x => x.EventoGerador)
                .Include(x => x.Diagnostico)
                .Where(x => x.cd_nota_sap == nr_nota_sap).Where(
                x => x.id_tp_nota_fk == tipoNotaService.GetByCodigoSap(TipoNotaSelecionarType.EC.ToString()).id_tp_nota ||
                x.id_tp_nota_fk == tipoNotaService.GetByCodigoSap(TipoNotaSelecionarType.EI.ToString()).id_tp_nota ||
                x.id_tp_nota_fk == tipoNotaService.GetByCodigoSap(TipoNotaSelecionarType.ED.ToString()).id_tp_nota ||
                x.id_tp_nota_fk == tipoNotaService.GetByCodigoSap(TipoNotaSelecionarType.EP.ToString()).id_tp_nota
                ).First();

            return notas;
        }

        public List<Nota> GetAbertasPendentes(int idFrota, int idTrem, string tpNota)
        {
            List<Nota> notas = new List<Nota>();
            string cdStSistema = "MSPN";
            string cdStUsuarioAberta = "ABER";
            notas = context.NotaRepository.AsQueryable().Include(x => x.TipoNota).Include(x => x.LocalInstalacao).Include(x => x.CodeSintoma).Include(x => x.Prioridade).Include(x => x.CentroTrabalho).Include(x => x.Empregado).Include(x => x.StatusUsuarios).Include(x => x.CodeTpServico).Include(x => x.Solicitante)
                .Where(x => (x.TipoNota.cd_sap == tpNota) && (x.LocalInstalacao.id_frota_fk == idFrota && x.LocalInstalacao.id_trem_fk == idTrem) && x.StatusSistema.cd_sap == cdStSistema && x.StatusUsuarios.Any(i => i.cd_sap == cdStUsuarioAberta))
                .OrderByDescending(x => x.id_nota)
                .ToList();

            return notas;
        }

        public List<Nota> ConsultarNotaParametros(Nota nota)
        {
            var parameterExpression = Expression.Parameter(typeof(Nota), "n");
            #region IdNotaInit
            Nota nota_init = new Nota();
            nota_init.id_nota = 0;
            var constantIdNota = Expression.Constant(nota_init.id_nota);
            var propertyIdNota = Expression.Property(parameterExpression, "id_nota");
            var propertyIdNotaConverted = Expression.Convert(propertyIdNota, nota_init.id_nota.GetType());
            var expressionIdNota = Expression.GreaterThan(propertyIdNotaConverted, constantIdNota);
            Expression expression = Expression.And(expressionIdNota, expressionIdNota);
            #endregion

            #region IdNotaReferenciaFk
            if (nota.id_nota_referencia_fk > 0)
            {
                var constantIdNotaReferenciaFk = Expression.Constant(nota.id_nota_referencia_fk);
                var propertyIdNotaReferenciaFk = Expression.Property(parameterExpression, "id_nota_referencia_fk");
                var propertyIdNotaReferenciaFkConverted = Expression.Convert(propertyIdNotaReferenciaFk, nota.id_nota_referencia_fk.GetType());
                var expressionIdNotaReferenciaFk = Expression.Equal(propertyIdNotaReferenciaFkConverted, constantIdNotaReferenciaFk);
                expression = Expression.And(expression, expressionIdNotaReferenciaFk);
            }
            #endregion

            #region IdTpNotaFk
            if (nota.id_tp_nota_fk > 0)
            {
                var constantIdTpNotaFk = Expression.Constant(nota.id_tp_nota_fk);
                var propertyIdTpNotaFk = Expression.Property(parameterExpression, "id_tp_nota_fk");
                var expressionIdTpNotaFk = Expression.Equal(propertyIdTpNotaFk, constantIdTpNotaFk);
                expression = Expression.And(expression, expressionIdTpNotaFk);
                //Expression expression2 = expressionIdTpNotaFk;
            }
            #endregion

            #region CdNotaSap
            if (!String.IsNullOrEmpty(nota.cd_nota_sap))
            {
                var constantCdNotaSap = Expression.Constant(nota.cd_nota_sap);
                var propertyCdNotaSap = Expression.Property(parameterExpression, "cd_nota_sap");
                var expressionCdNotaSap = Expression.Equal(propertyCdNotaSap, constantCdNotaSap);
                expression = Expression.And(expression, expressionCdNotaSap);
            }
            #endregion

            #region DsDescricao
            if (!String.IsNullOrEmpty(nota.ds_descricao))
            {
                var constantDsDescricao = Expression.Constant(nota.ds_descricao);
                var propertyDsDescricao = Expression.Property(parameterExpression, "ds_descricao");
                var expressionDsDescricao = Expression.Equal(propertyDsDescricao, constantDsDescricao);
                expression = Expression.And(expression, expressionDsDescricao);
            }
            #endregion

            #region StUsuario
            //if(nota.StUsuario > 0) {
            //var constantStUsuario = Expression.Constant(nota.StUsuario);
            //var propertyStUsuario = Expression.Property(parameterExpression, "StUsuario");
            //var expressionStUsuario = Expression.Equal(propertyStUsuario, constantStUsuario);
            //expression = Expression.And(expression, expressionStUsuario);
            //}
            #endregion

            #region IdPrioridadeFk
            if (nota.id_prioridade_fk > 0)
            {
                var constantIdPrioridadeFk = Expression.Constant(nota.id_prioridade_fk);
                var propertyIdPrioridadeFk = Expression.Property(parameterExpression, "id_prioridade_fk");
                var propertyIdPrioridadeFkConverted = Expression.Convert(propertyIdPrioridadeFk, nota.id_prioridade_fk.GetType());
                var expressionIdPrioridadeFk = Expression.Equal(propertyIdPrioridadeFkConverted, constantIdPrioridadeFk);
                expression = Expression.And(expression, expressionIdPrioridadeFk);
            }
            #endregion

            #region EqEtiqueta
            //if (!String.IsNullOrEmpty(nota.eq_etiqueta))
            //{
            //    var constantEqEtiqueta = Expression.Constant(nota.eq_etiqueta);
            //    var propertyEqEtiqueta = Expression.Property(parameterExpression, "eq_etiqueta");
            //    var expressionEqEtiqueta = Expression.Equal(propertyEqEtiqueta, constantEqEtiqueta);
            //    expression = Expression.And(expression, expressionEqEtiqueta);
            //}
            #endregion

            #region IdCodeSintomaFk
            if (nota.id_code_sintoma_fk > 0)
            {
                var constantIdCodeSintomaFk = Expression.Constant(nota.id_code_sintoma_fk);
                var propertyIdCodeSintomaFk = Expression.Property(parameterExpression, "id_code_sintoma_fk");
                var expressionIdCodeSintomaFk = Expression.Equal(propertyIdCodeSintomaFk, constantIdCodeSintomaFk);
                expression = Expression.And(expression, expressionIdCodeSintomaFk);
            }
            #endregion

            #region IdEquipamentoFk
            if (nota.id_equipamento_fk > 0)
            {
                var constantIdEquipamentoFk = Expression.Constant(nota.id_equipamento_fk);
                var propertyIdEquipamentoFk = Expression.Property(parameterExpression, "id_equipamento_fk");
                var expressionIdEquipamentoFk = Expression.Equal(propertyIdEquipamentoFk, constantIdEquipamentoFk);
                expression = Expression.And(expression, expressionIdEquipamentoFk);
            }
            #endregion

            #region IdMaterialFk
            if (nota.id_material_fk > 0)
            {
                var constantIdMaterialFk = Expression.Constant(nota.id_material_fk);
                var propertyIdMaterialFk = Expression.Property(parameterExpression, "id_material_fk");
                var expressionIdMaterialFk = Expression.Equal(propertyIdMaterialFk, constantIdMaterialFk);
                expression = Expression.And(expression, expressionIdMaterialFk);
            }
            #endregion

            #region IdCentroTrabalhoFk
            if (nota.id_centro_trabalho_fk > 0)
            {
                var constantIdCentroTrabalhoFk = Expression.Constant(nota.id_centro_trabalho_fk);
                var propertyIdCentroTrabalhoFk = Expression.Property(parameterExpression, "id_centro_trabalho_fk");
                var expressionIdCentroTrabalhoFk = Expression.Equal(propertyIdCentroTrabalhoFk, constantIdCentroTrabalhoFk);
                expression = Expression.And(expression, expressionIdCentroTrabalhoFk);
            }
            #endregion

            var lambda = Expression.Lambda<Func<Nota, bool>>(expression, parameterExpression);
            var compiledLambda = lambda.Compile();

            var notaRetorno = context.NotaRepository.AsQueryable().Where(lambda)
                .Include(x => x.TipoNota)
                .Include(x => x.Equipamento)
                .Include(x => x.Material)
                .Include(x => x.CentroTrabalho)
                .ToList();
            return notaRetorno;

            //return
            //    context.NotaRepository.GetAll().Where(x => x.id_tp_nota_fk == nota.id_tp_nota_fk)
            //    //.Include(x => x.TipoNota)
            //    //.Include(x => x.Equipamento)
            //    //.Include(x => x.Material)
            //    //.Include(x => x.CentroTrabalho)
            //    .ToList();
        }

        public List<Nota> ConsultarNotaCopeseEFMRParametros(Nota nota, DateTime dtIni, DateTime dtFim)
        {
            if (nota.id_code_sintoma_fk > 0 || nota.id_nota > 0 || nota.id_nota_referencia_fk > 0
                || !String.IsNullOrEmpty(nota.cd_nota_sap) || dtIni > DateTime.Now.AddYears(-100) || dtFim > DateTime.Now.AddYears(-100)
                || nota.id_st_copese_fk != null || nota.id_equipamento_fk > 0 || nota.id_local_inst_fk > 0)
            {
                var parameterExpression = Expression.Parameter(typeof(Nota), "n");

                #region IdNota            
                Nota notaInit = new Nota();
                notaInit.id_nota = 0;
                var constantIdNota = Expression.Constant(notaInit.id_nota);
                var propertyIdNota = Expression.Property(parameterExpression, "id_nota");
                var propertyIdNotaConverted = Expression.Convert(propertyIdNota, notaInit.id_nota.GetType());
                var expressionIdNota = Expression.GreaterThan(propertyIdNotaConverted, constantIdNota);
                Expression expression = Expression.And(expressionIdNota, expressionIdNota);
                #endregion

                #region IdTpNotaFk
                if (nota.id_tp_nota_fk > 0)
                {
                    var constantIdTpNotaFk = Expression.Constant(nota.id_tp_nota_fk);
                    var propertyIdTpNotaFk = Expression.Property(parameterExpression, "id_tp_nota_fk");
                    var expressionIdTpNotaFk = Expression.Equal(propertyIdTpNotaFk, constantIdTpNotaFk);
                    expression = Expression.And(expression, expressionIdTpNotaFk);
                }
                #endregion

                #region IdCodeSintomaFk
                if (nota.id_code_sintoma_fk > 0)
                {
                    var constantIdCodeSintomaFk = Expression.Constant(nota.id_code_sintoma_fk);
                    var propertyIdCodeSintomaFk = Expression.Property(parameterExpression, "id_code_sintoma_fk");
                    var propertyIdCodeSintomaConverted = Expression.Convert(propertyIdCodeSintomaFk, nota.id_code_sintoma_fk.GetType());
                    var expressionIdCodeSintomaFk = Expression.Equal(propertyIdCodeSintomaConverted, constantIdCodeSintomaFk);
                    expression = Expression.And(expression, expressionIdCodeSintomaFk);
                }
                #endregion

                #region IdNotaParam
                if (nota.id_nota > 0)
                {
                    nota.id_nota = 0;
                    var constantIdNotaParam = Expression.Constant(nota.id_nota);
                    var propertyIdNotaParam = Expression.Property(parameterExpression, "id_nota");
                    var propertyIdNotaParamConverted = Expression.Convert(propertyIdNotaParam, nota.id_nota.GetType());
                    var expressionIdNotaParam = Expression.Equal(propertyIdNotaParamConverted, constantIdNotaParam);
                    expression = Expression.And(expressionIdNota, expressionIdNotaParam);
                }
                #endregion

                #region IdNotaReferenciaFk
                if (nota.id_nota_referencia_fk > 0)
                {
                    var constantIdNotaReferenciaFk = Expression.Constant(nota.id_nota_referencia_fk);
                    var propertyIdNotaReferenciaFk = Expression.Property(parameterExpression, "id_nota_referencia_fk");
                    var propertyIdNotaReferenciaFkConverted = Expression.Convert(propertyIdNotaReferenciaFk, nota.id_nota_referencia_fk.GetType());
                    var expressionIdNotaReferenciaFk = Expression.Equal(propertyIdNotaReferenciaFkConverted, constantIdNotaReferenciaFk);
                    expression = Expression.And(expression, expressionIdNotaReferenciaFk);
                }
                #endregion


                #region CdNotaSap            
                if (!String.IsNullOrEmpty(nota.cd_nota_sap))
                {
                    var constantCdNotaSap = Expression.Constant(nota.cd_nota_sap);
                    var propertyCdNotaSap = Expression.Property(parameterExpression, "cd_nota_sap");
                    var expressionCdNotaSap = Expression.Equal(propertyCdNotaSap, constantCdNotaSap);
                    expression = Expression.And(expression, expressionCdNotaSap);
                }
                #endregion

                #region DtInicio
                if (dtIni > DateTime.Now.AddYears(-100))
                {
                    dtIni = Convert.ToDateTime(dtIni.AddDays(1).ToShortDateString() + " 00:00:00.000");

                    var constantDtInicio = Expression.Constant(dtIni);
                    var propertyDtInicio = Expression.Property(parameterExpression, "dt_hora_nota");
                    var propertyDtInicioConverted = Expression.Convert(propertyDtInicio, dtIni.GetType());
                    var expressionDtInicio = Expression.GreaterThanOrEqual(propertyDtInicioConverted, constantDtInicio);
                    expression = Expression.And(expression, expressionDtInicio);
                }
                #endregion

                #region DtFim
                if (dtFim > DateTime.Now.AddYears(-100))
                {
                    dtFim = Convert.ToDateTime(dtFim.AddDays(1).ToShortDateString() + " 23:59:59.999");
                    var constantDtFim = Expression.Constant(dtFim);
                    var propertyDtFim = Expression.Property(parameterExpression, "dt_hora_nota");
                    var propertyDtFimConverted = Expression.Convert(propertyDtFim, dtFim.GetType());
                    var expressionDtFim = Expression.LessThanOrEqual(propertyDtFimConverted, constantDtFim);
                    expression = Expression.And(expression, expressionDtFim);
                }
                #endregion

                #region StPericia
                if (nota.id_st_pericia_fk > 0)
                {
                    var constantStPericia = Expression.Constant(nota.id_st_pericia_fk);
                    var propertyStPericia = Expression.Property(parameterExpression, "id_st_pericia_fk");
                    var propertyStPericiaConverted = Expression.Convert(propertyStPericia, nota.id_st_pericia_fk.GetType());
                    var expressionStPericia = Expression.Equal(propertyStPericiaConverted, constantStPericia);
                    expression = Expression.And(expression, expressionStPericia);
                }
                #endregion

                #region IdStCopeseFk
                if (nota.id_st_copese_fk > 0)
                {
                    var constantIdStCopeseFk = Expression.Constant(nota.id_st_copese_fk);
                    var propertyIdStCopeseFk = Expression.Property(parameterExpression, "id_st_copese_fk");
                    var propertyIdStCopeseFkConverted = Expression.Convert(propertyIdStCopeseFk, nota.id_st_copese_fk.GetType());
                    var expressionIdStCopeseFk = Expression.Equal(propertyIdStCopeseFkConverted, constantIdStCopeseFk);
                    expression = Expression.And(expression, expressionIdStCopeseFk);
                }
                #endregion

                #region IdEquipamentoFk
                if (nota.id_equipamento_fk > 0)
                {
                    var constantIdEquipamentoFk = Expression.Constant(nota.id_equipamento_fk);
                    var propertyIdEquipamentoFk = Expression.Property(parameterExpression, "id_equipamento_fk");
                    var propertyIdEquipamentoFkConverted = Expression.Convert(propertyIdEquipamentoFk, nota.id_equipamento_fk.GetType());
                    var expressionIdEquipamentoFk = Expression.Equal(propertyIdEquipamentoFkConverted, constantIdEquipamentoFk);
                    expression = Expression.And(expression, expressionIdEquipamentoFk);
                }
                #endregion

                #region IdLocalInstFk
                if (nota.id_local_inst_fk > 0)
                {
                    var constantIdLocalInstFk = Expression.Constant(nota.id_local_inst_fk);
                    var propertyIdLocalInstFk = Expression.Property(parameterExpression, "id_local_inst_fk");
                    var propertyIdLocalInstFkConverted = Expression.Convert(propertyIdLocalInstFk, nota.id_local_inst_fk.GetType());
                    var expressionIdLocalInstFk = Expression.Equal(propertyIdLocalInstFkConverted, constantIdLocalInstFk);
                    expression = Expression.And(expression, expressionIdLocalInstFk);
                }
                #endregion

                var lambda = Expression.Lambda<Func<Nota, bool>>(expression, parameterExpression);
                var compiledLambda = lambda.Compile();

                var notaRetorno = context.NotaRepository.AsQueryable().Where(lambda)
                    .Include(x => x.TipoNota)
                    .Include(x => x.Equipamento)
                    .Include(x => x.Material)
                    .Include(x => x.CentroTrabalho)
                    .ToList();

                return notaRetorno;
            }

            else return new List<Nota>();
        }


        public List<Nota> ConsultarNotaPericiaMRParametros(Nota nota, string _dtIni, string _dtFim)
        {
            DateTime dtIni;
            DateTime dtFim;

            DateTime.TryParse(_dtIni, out dtIni);
            DateTime.TryParse(_dtFim, out dtFim);

            if (nota.id_tp_nota_fk > 0 ||
                nota.id_local_inst_fk > 0 ||
                nota.id_ev_gerador_fk > 0 ||
                !string.IsNullOrEmpty(nota.cd_bo_metro) ||
                !string.IsNullOrEmpty(nota.cd_bo_ssp) ||
                !string.IsNullOrEmpty(nota.cd_nota_sap) ||
                dtIni > DateTime.Now.AddYears(-100) ||
                dtFim > DateTime.Now.AddYears(-100) ||
                nota.id_nota_referencia_fk > 0 ||
                nota.id_st_pericia_fk > 0 ||
                nota.id_nota > 0)
            {
                var parameterExpression = Expression.Parameter(typeof(Nota), "n");

                #region IdNota            
                Nota notaInit = new Nota();
                notaInit.id_nota = 0;
                var constantIdNota = Expression.Constant(notaInit.id_nota);
                var propertyIdNota = Expression.Property(parameterExpression, "id_nota");
                var propertyIdNotaConverted = Expression.Convert(propertyIdNota, notaInit.id_nota.GetType());
                var expressionIdNota = Expression.GreaterThan(propertyIdNotaConverted, constantIdNota);
                Expression expression = Expression.And(expressionIdNota, expressionIdNota);
                #endregion

                #region IdTpNotaFk
                if (nota.id_tp_nota_fk > 0)
                {
                    var constantIdTpNotaFk = Expression.Constant(nota.id_tp_nota_fk);
                    var propertyIdTpNotaFk = Expression.Property(parameterExpression, "id_tp_nota_fk");
                    var expressionIdTpNotaFk = Expression.Equal(propertyIdTpNotaFk, constantIdTpNotaFk);
                    expression = Expression.And(expression, expressionIdTpNotaFk);
                }
                #endregion

                #region IdNotaParam
                if (nota.id_nota > 0)
                {
                    nota.id_nota = 0;
                    var constantIdNotaParam = Expression.Constant(nota.id_nota);
                    var propertyIdNotaParam = Expression.Property(parameterExpression, "id_nota");
                    var propertyIdNotaParamConverted = Expression.Convert(propertyIdNotaParam, nota.id_nota.GetType());
                    var expressionIdNotaParam = Expression.Equal(propertyIdNotaParamConverted, constantIdNotaParam);
                    expression = Expression.And(expressionIdNota, expressionIdNotaParam);
                }
                #endregion

                #region IdNotaReferenciaFk
                if (nota.id_nota_referencia_fk > 0)
                {
                    var constantIdNotaReferenciaFk = Expression.Constant(nota.id_nota_referencia_fk);
                    var propertyIdNotaReferenciaFk = Expression.Property(parameterExpression, "id_nota_referencia_fk");
                    var propertyIdNotaReferenciaFkConverted = Expression.Convert(propertyIdNotaReferenciaFk, nota.id_nota_referencia_fk.GetType());
                    var expressionIdNotaReferenciaFk = Expression.Equal(propertyIdNotaReferenciaFkConverted, constantIdNotaReferenciaFk);
                    expression = Expression.And(expression, expressionIdNotaReferenciaFk);
                }
                #endregion

                #region CdNotaSap            
                if (!String.IsNullOrEmpty(nota.cd_nota_sap))
                {
                    var constantCdNotaSap = Expression.Constant(nota.cd_nota_sap);
                    var propertyCdNotaSap = Expression.Property(parameterExpression, "cd_nota_sap");
                    var expressionCdNotaSap = Expression.Equal(propertyCdNotaSap, constantCdNotaSap);
                    expression = Expression.And(expression, expressionCdNotaSap);
                }
                #endregion

                #region DtInicio
                if (dtIni > DateTime.Now.AddYears(-100))
                {
                    dtIni = DateTime.Parse(dtIni.ToShortDateString() + " 00:00:00.000");
                    var constantDtInicio = Expression.Constant(dtIni);
                    var propertyDtInicio = Expression.Property(parameterExpression, "dt_hora_nota");
                    var propertyDtInicioConverted = Expression.Convert(propertyDtInicio, dtIni.GetType());
                    var expressionDtInicio = Expression.GreaterThanOrEqual(propertyDtInicioConverted, constantDtInicio);
                    expression = Expression.And(expression, expressionDtInicio);
                }
                #endregion

                #region DtFim
                if (dtFim > DateTime.Now.AddYears(-100))
                {
                    dtFim = DateTime.Parse(dtFim.ToShortDateString() + " 23:59:59.999");
                    var constantDtFim = Expression.Constant(dtFim);
                    var propertyDtFim = Expression.Property(parameterExpression, "dt_hora_nota");
                    var propertyDtFimConverted = Expression.Convert(propertyDtFim, dtFim.GetType());
                    var expressionDtFim = Expression.LessThanOrEqual(propertyDtFimConverted, constantDtFim);
                    expression = Expression.And(expression, expressionDtFim);
                }
                #endregion

                #region StPericia
                if (nota.id_st_pericia_fk > 0)
                {
                    var constantStPericia = Expression.Constant(nota.id_st_pericia_fk);
                    var propertyStPericia = Expression.Property(parameterExpression, "id_st_pericia_fk");
                    var propertyStPericiaConverted = Expression.Convert(propertyStPericia, nota.id_st_pericia_fk.GetType());
                    var expressionStPericia = Expression.Equal(propertyStPericiaConverted, constantStPericia);
                    expression = Expression.And(expression, expressionStPericia);
                }
                #endregion

                #region IdLocalInstFk
                if (nota.id_local_inst_fk > 0)
                {
                    var constantIdLocalInstFk = Expression.Constant(nota.id_local_inst_fk);
                    var propertyIdLocalInstFk = Expression.Property(parameterExpression, "id_local_inst_fk");
                    var propertyIdLocalInstFkConverted = Expression.Convert(propertyIdLocalInstFk, nota.id_local_inst_fk.GetType());
                    var expressionIdLocalInstFk = Expression.Equal(propertyIdLocalInstFkConverted, constantIdLocalInstFk);
                    expression = Expression.And(expression, expressionIdLocalInstFk);
                }
                #endregion

                #region IdEvGeradorFk
                if (nota.id_ev_gerador_fk > 0)
                {
                    var constantIdEvGeradorFk = Expression.Constant(nota.id_ev_gerador_fk);
                    var propertyIdEvGeradorFk = Expression.Property(parameterExpression, "id_ev_gerador_fk");
                    var propertyIdEvGeradorFkConverted = Expression.Convert(propertyIdEvGeradorFk, nota.id_ev_gerador_fk.GetType());
                    var expressionIdEvGeradorFk = Expression.Equal(propertyIdEvGeradorFkConverted, constantIdEvGeradorFk);
                    expression = Expression.And(expression, expressionIdEvGeradorFk);
                }
                #endregion

                #region CdBoMetro
                if (!string.IsNullOrEmpty(nota.cd_bo_metro))
                {
                    var constantCdBoMetro = Expression.Constant(nota.cd_bo_metro);
                    var propertyCdBoMetro = Expression.Property(parameterExpression, "cd_bo_metro");
                    var propertyCdBoMetroConverted = Expression.Convert(propertyCdBoMetro, nota.cd_bo_metro.GetType());
                    var expressionCdBoMetro = Expression.Equal(propertyCdBoMetro, constantCdBoMetro);
                    expression = Expression.And(expression, expressionCdBoMetro);
                }
                #endregion

                #region CdBoSsp
                if (!string.IsNullOrEmpty(nota.cd_bo_ssp))
                {
                    var constantCdBoSsp = Expression.Constant(nota.cd_bo_ssp);
                    var propertyCdBoSsp = Expression.Property(parameterExpression, "cd_bo_ssp");
                    var propertyCdBoSspConverted = Expression.Convert(propertyCdBoSsp, nota.cd_bo_ssp.GetType());
                    var expressionCdBoSsp = Expression.Equal(propertyCdBoSsp, constantCdBoSsp);
                    expression = Expression.And(expression, expressionCdBoSsp);
                }
                #endregion

                var lambda = Expression.Lambda<Func<Nota, bool>>(expression, parameterExpression);
                var compiledLambda = lambda.Compile();

                var notaRetorno = context.NotaRepository.AsQueryable().Where(lambda)
                    .Include(x => x.TipoNota)
                    .Include(x => x.LocalInstalacao)
                    .Include(x => x.EventoGerador)
                    .Include(x => x.StatusPericia)
                    .Include(x => x.CentroTrabalho)
                    .ToList();

                return notaRetorno;
            }
            else return new List<Nota>();
        }

        /*public List<Nota> GetAllByLinhaZonaSistema(int linha, int zona, int sistema)
        {
            List<Nota> resultado = context.NotaRepository.GetAll();

            if (linha > 0)
                return resultado.Where(x => x.LocalInstalacao.id_linha_fk == linha).ToList();
            else if (zona > 0)
                return resultado.Where(x => x.LocalInstalacao.id_zona_fk == zona).ToList();
            else if (sistema > 0)
                return resultado.Where(x => x.LocalInstalacao.id_sistema_fk == sistema).ToList();
            else
                return resultado;
        }*/

        public Nota AddCopese(Nota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                param.dt_hora_nota = DateTime.Now;
                context.NotaRepository.Add(param);
                context.SaveChanges();

                StatusMedidaService statusMedidaService;
                CodeService codeService = new CodeService();
                MedidaNota medidaNota;
                StatusMedida stMed;
                Code cod;

                #region Atualiza Status do Usuario para a Nota de Referencia
                if (param.id_nota_referencia_fk != null)
                {

                    NotaService notaService = new NotaService(this.context);
                    Nota notaReferencia = notaService.GetNotaStatusUsuarioById(param.id_nota_referencia_fk.Value);

                    StatusUsuarioService statusUsuarioService = new StatusUsuarioService(this.context);
                    StatusUsuario stAber = new StatusUsuario();
                    stAber = statusUsuarioService.GetByCdSap("CPSE");

                    if (notaReferencia.StatusUsuarios.Count(x => x.id_st_usuario == stAber.id_st_usuario) <= 0)
                        notaReferencia.StatusUsuarios.Add(stAber);

                    context.NotaRepository.Update(notaReferencia);

                }
                #endregion

                #region PNAcionado
                statusMedidaService = new StatusMedidaService(this.context);

                medidaNota = new MedidaNota();
                medidaNota.id_nota_fk = param.id_nota;
                medidaNota.sq_medida_nota = 1;

                medidaNota.dt_hora_medida_nota = DateTime.Now;
                medidaNota.id_empregado_responsavel_fk = param.id_pn_acionado_fk.Value;
                medidaNota.fn_responsavel = "ZR";

                stMed = statusMedidaService.GetByCdSap("LIBE");
                medidaNota.id_st_medida_fk = stMed.id_st_medida;

                cod = codeService.GetByCdSap("PLA");
                medidaNota.id_code_tx_fk = cod.id_code;

                context.MedidaNotaRepository.Add(medidaNota);
                context.SaveChanges();
                #endregion

                #region CIAcionado
                statusMedidaService = new StatusMedidaService(this.context);

                medidaNota = new MedidaNota();
                medidaNota.id_nota_fk = param.id_nota;
                medidaNota.sq_medida_nota = 2;

                medidaNota.dt_hora_medida_nota = DateTime.Now;
                medidaNota.id_cent_trab_responsavel_fk = param.id_centro_trabalho_fk;
                medidaNota.fn_responsavel = "ZA";

                stMed = statusMedidaService.GetByCdSap("LIBE");
                medidaNota.id_st_medida_fk = stMed.id_st_medida;

                cod = codeService.GetByCdSap("CIM");
                medidaNota.id_code_tx_fk = cod.id_code;

                context.MedidaNotaRepository.Add(medidaNota);
                context.SaveChanges();
                #endregion

                #region RepreAcionado1
                statusMedidaService = new StatusMedidaService(this.context);

                medidaNota = new MedidaNota();
                medidaNota.id_nota_fk = param.id_nota;
                medidaNota.sq_medida_nota = 3;

                medidaNota.dt_hora_medida_nota = DateTime.Now;
                medidaNota.id_empregado_responsavel_fk = param.id_pl_repres_acionado_fk.Value;
                medidaNota.fn_responsavel = "ZR";

                stMed = statusMedidaService.GetByCdSap("LIBE");
                medidaNota.id_st_medida_fk = stMed.id_st_medida;

                cod = codeService.GetByCdSap("PLR");
                medidaNota.id_code_tx_fk = cod.id_code;

                context.MedidaNotaRepository.Add(medidaNota);
                context.SaveChanges();
                #endregion

                #region RepreAcionado2
                statusMedidaService = new StatusMedidaService(this.context);

                medidaNota = new MedidaNota();
                medidaNota.id_nota_fk = param.id_nota;
                medidaNota.sq_medida_nota = 4;

                medidaNota.dt_hora_medida_nota = DateTime.Now;
                medidaNota.id_empregado_responsavel_fk = param.id_pl_repres_acionado2_fk.Value;
                medidaNota.fn_responsavel = "ZR";

                stMed = statusMedidaService.GetByCdSap("LIBE");
                medidaNota.id_st_medida_fk = stMed.id_st_medida;

                cod = codeService.GetByCdSap("PLR");
                medidaNota.id_code_tx_fk = cod.id_code;

                context.MedidaNotaRepository.Add(medidaNota);
                context.SaveChanges();
                #endregion

                #region RepreAcionado3
                statusMedidaService = new StatusMedidaService(this.context);

                medidaNota = new MedidaNota();
                medidaNota.id_nota_fk = param.id_nota;
                medidaNota.sq_medida_nota = 5;

                medidaNota.dt_hora_medida_nota = DateTime.Now;
                medidaNota.id_empregado_responsavel_fk = param.id_pl_repres_acionado3_fk.Value;
                medidaNota.fn_responsavel = "ZR";

                stMed = statusMedidaService.GetByCdSap("LIBE");
                medidaNota.id_st_medida_fk = stMed.id_st_medida;

                cod = codeService.GetByCdSap("PLR");
                medidaNota.id_code_tx_fk = cod.id_code;

                context.MedidaNotaRepository.Add(medidaNota);
                context.SaveChanges();
                #endregion

                #region RepreAcionado4
                statusMedidaService = new StatusMedidaService(this.context);

                medidaNota = new MedidaNota();
                medidaNota.id_nota_fk = param.id_nota;
                medidaNota.sq_medida_nota = 6;

                medidaNota.dt_hora_medida_nota = DateTime.Now;
                medidaNota.id_empregado_responsavel_fk = param.id_pl_repres_acionado4_fk.Value;
                medidaNota.fn_responsavel = "ZR";

                stMed = statusMedidaService.GetByCdSap("LIBE");
                medidaNota.id_st_medida_fk = stMed.id_st_medida;

                cod = codeService.GetByCdSap("PLR");
                medidaNota.id_code_tx_fk = cod.id_code;

                context.MedidaNotaRepository.Add(medidaNota);
                context.SaveChanges();
                #endregion

                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.MensagemUsuario = Mensagens.MSG04.Replace("[#1]", param.id_nota.ToString());
            }
            catch (Exception e)
            {
                param.BaseModel.Erro = true;
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
                Console.Write("Erro");
            }

            return param;
        }

        public Nota UpdateCopese(Nota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.NotaRepository.Update(param);
                context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.MensagemUsuario = Mensagens.MSG08;
            }
            catch (Exception e)
            {
                param.BaseModel.Erro = true;
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
                Console.Write("Erro");
            }

            return param;
        }

        public Nota DescaracterizarCopese(Nota param)
        {
            try
            {
                param.BaseModel.Erro = false;

                #region Adiciona Status de Medida da Nota de Copese
                StatusMedidaService statusMedidaService = new StatusMedidaService(this.context);

                MedidaNota medidaNota = new MedidaNota();
                medidaNota.id_nota_fk = param.id_nota;
                medidaNota.sq_medida_nota = 1;
                medidaNota.dt_hora_medida_nota = DateTime.Now;
                medidaNota.id_empregado_fk = null;              //empregado logado (falta implementar)
                medidaNota.id_empregado_responsavel_fk = null; // Para este caso é null

                StatusMedida stMed = statusMedidaService.GetByCdSap("ENCE");
                medidaNota.id_st_medida_fk = stMed.id_st_medida;

                StatusUsuario stUsuario = new StatusUsuarioService().GetByCdSap("CPSD");
                medidaNota.StatusUsuario = stUsuario;

                Code cod = new CodeService().GetByCdSap("FINL");
                medidaNota.id_code_tx_fk = cod.id_code;

                context.MedidaNotaRepository.Add(medidaNota);
                #endregion

                #region Atualiza todos as Medidas da Nota Copese com o Status Encerrada

                if (param.id_nota != null)
                {
                    Nota nota = new NotaService().GetNotaStatusUsuarioById(param.id_nota);

                    nota.StatusSistema = new StatusSistemaService().GetByCdSap("MSEC");
                    nota.StatusCopese = new StatusCopeseService().GetAll().Where(s => s.ds_st_copese == "Fechada").First();
                    nota.StatusUsuarios.Add(stUsuario);

                    foreach (var item in nota.MedidasNota)
                    {
                        item.StatusMedida = stMed;
                    }

                    context.NotaRepository.Update(nota);
                }
                #endregion

                context.SaveChanges();

                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.MensagemUsuario = Mensagens.MSG04.Replace("[#1]", param.id_nota.ToString());
            }
            catch (Exception e)
            {
                param.BaseModel.Erro = true;
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
                Console.Write("Erro");
            }

            return param;
        }

        public Nota EncerrarCopese(Nota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                #region Adiciona Status de Medida da Nota de Copese
                StatusMedidaService statusMedidaService = new StatusMedidaService(this.context);

                MedidaNota medidaNota = new MedidaNota();
                medidaNota.id_nota_fk = param.id_nota;
                medidaNota.sq_medida_nota = 1;
                medidaNota.dt_hora_medida_nota = DateTime.Now;
                medidaNota.id_empregado_fk = null;              //empregado logado (falta implementar)
                medidaNota.id_empregado_responsavel_fk = null; // Para este caso é null

                StatusMedida stMed = statusMedidaService.GetByCdSap("ENCE");
                medidaNota.id_st_medida_fk = stMed.id_st_medida;

                StatusUsuario stUsuario = new StatusUsuarioService().GetByCdSap("FINL");
                medidaNota.StatusUsuario = stUsuario;

                Code cod = new CodeService().GetByCdSap("FINL");
                medidaNota.id_code_tx_fk = cod.id_code;

                context.MedidaNotaRepository.Add(medidaNota);
                #endregion

                #region Atualiza todos as Medidas da Nota Copese com o Status Encerrada

                if (param.id_nota != null)
                {
                    Nota nota = new NotaService().GetNotaStatusUsuarioById(param.id_nota);

                    nota.StatusSistema = new StatusSistemaService().GetByCdSap("MSEN");
                    nota.StatusCopese = new StatusCopeseService().GetAll().Where(s => s.ds_st_copese == "Fechada").First();
                    nota.StatusUsuarios.Add(stUsuario);

                    foreach (var item in nota.MedidasNota)
                    {
                        item.StatusMedida = stMed;
                    }

                    context.NotaRepository.Update(nota);
                }

                #endregion

                context.SaveChanges();

                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.MensagemUsuario = Mensagens.MSG46.Replace("[#1]", param.id_nota.ToString());
            }
            catch (Exception e)
            {
                param.BaseModel.Erro = true;
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
                Console.Write("Erro");
            }

            return param;
        }

        public bool DeleteById(int id)
        {
            Nota nota = new Nota();

            try
            {
                nota = context.NotaRepository.GetById(id);
                var retorno = context.NotaRepository.Update(nota);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Nota Add(Nota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.NotaRepository.Add(param);
                context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
            }
            catch (Exception e)
            {
                param.BaseModel.Erro = true;
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
                Console.Write("Erro");
            }

            return param;
        }

        #region Pericia
        public Nota AddPericia(Nota param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    //temporario gera codigo sap temporario
                    string cdNotaSAP = DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.ToShortTimeString().Replace(":", "");
                    param.cd_nota_sap = cdNotaSAP;

                    param.BaseModel.Erro = false;
                    context.NotaRepository.Add(param);
                    context.SaveChanges();

                    #region Atualiza Status de Medida da Nota de Pericia
                    StatusMedidaService statusMedidaService;
                    CodeService codeService = new CodeService();
                    MedidaNota medidaNota;
                    StatusMedida stMed;
                    Code cod;

                    //Status da Nota
                    statusMedidaService = new StatusMedidaService(this.context);
                    int sequenciaMedidaNota = 1;

                    medidaNota = new MedidaNota();
                    medidaNota.id_nota_fk = param.id_nota;
                    medidaNota.sq_medida_nota = sequenciaMedidaNota;
                    medidaNota.dt_hora_medida_nota = DateTime.Now;
                    medidaNota.id_empregado_fk = null;              //empregado logado (falta implementar)
                    medidaNota.id_empregado_responsavel_fk = null; // Para este caso é null

                    if (param.id_centro_trabalho_fk > 0)
                        medidaNota.id_cent_trab_responsavel_fk = param.id_centro_trabalho_fk;

                    medidaNota.fn_responsavel = "ZA";
                    stMed = statusMedidaService.GetByCdSap("ABER");

                    medidaNota.id_st_medida_fk = stMed.id_st_medida;
                    cod = codeService.GetByCdSap("ABER");
                    medidaNota.id_code_tx_fk = cod.id_code;
                    context.MedidaNotaRepository.Add(medidaNota);

                    //BO Metrô
                    if (!String.IsNullOrEmpty(param.cd_bo_metro))
                    {
                        sequenciaMedidaNota = sequenciaMedidaNota + 1;
                        medidaNota = new MedidaNota();
                        medidaNota.id_nota_fk = param.id_nota;
                        medidaNota.sq_medida_nota = sequenciaMedidaNota;
                        medidaNota.dt_hora_medida_nota = DateTime.Now;
                        medidaNota.id_empregado_fk = null;              //empregado logado (falta implementar)
                        medidaNota.id_empregado_responsavel_fk = null; // Para este caso é null
                        medidaNota.ds_motivo = param.ds_bo_metro;

                        if (param.id_centro_trabalho_fk > 0)
                            medidaNota.id_cent_trab_responsavel_fk = param.id_centro_trabalho_fk;

                        medidaNota.fn_responsavel = "ZA";
                        stMed = statusMedidaService.GetByCdSap("ENCE");

                        medidaNota.id_st_medida_fk = stMed.id_st_medida;
                        cod = codeService.GetByCdSap("BOME");
                        medidaNota.id_code_tx_fk = cod.id_code;
                        context.MedidaNotaRepository.Add(medidaNota);
                    }

                    //BO SSP
                    if (!String.IsNullOrEmpty(param.cd_bo_ssp))
                    {
                        sequenciaMedidaNota = sequenciaMedidaNota + 1;
                        medidaNota = new MedidaNota();
                        medidaNota.id_nota_fk = param.id_nota;
                        medidaNota.sq_medida_nota = sequenciaMedidaNota;
                        medidaNota.dt_hora_medida_nota = DateTime.Now;
                        medidaNota.id_empregado_fk = null;              //empregado logado (falta implementar)
                        medidaNota.id_empregado_responsavel_fk = null; // Para este caso é null
                        medidaNota.ds_motivo = param.ds_bo_ssp;

                        if (param.id_centro_trabalho_fk > 0)
                            medidaNota.id_cent_trab_responsavel_fk = param.id_centro_trabalho_fk;

                        medidaNota.fn_responsavel = "ZA";
                        stMed = statusMedidaService.GetByCdSap("ENCE");

                        medidaNota.id_st_medida_fk = stMed.id_st_medida;
                        cod = codeService.GetByCdSap("BOSP");
                        medidaNota.id_code_tx_fk = cod.id_code;

                        context.MedidaNotaRepository.Add(medidaNota);
                    }
                    #endregion

                    if (param.id_nota_referencia_fk != null)
                    {
                        #region Atualiza Status do Usuario para a Nota de Referencia
                        NotaService notaService = new NotaService(this.context);
                        Nota notaReferencia = notaService.GetNotaStatusUsuarioById(param.id_nota_referencia_fk.Value);

                        StatusUsuarioService statusUsuarioService = new StatusUsuarioService(this.context);
                        StatusUsuario stAber = new StatusUsuario();
                        stAber = statusUsuarioService.GetByCdSap("PERI");

                        if (notaReferencia.StatusUsuarios.Count(x => x.id_st_usuario == stAber.id_st_usuario) <= 0)
                            notaReferencia.StatusUsuarios.Add(stAber);

                        context.NotaRepository.Update(notaReferencia);
                        #endregion
                    }

                    context.SaveChanges();

                    #region WSDL Enviar Nota para o SAP
                    //////ModelPericiaCopese modelPericiaCopese = new ModelPericiaCopese();
                    //////PericiaCopese oPericiaCopese = new PericiaCopese();

                    //////#region Atividade
                    //////ModelPericiaCopeseAtividade modelPericiaCopeseAtividade = new ModelPericiaCopeseAtividade();
                    //////modelPericiaCopese.Atividade = new List<ModelPericiaCopeseAtividade>();
                    //////modelPericiaCopese.Atividade.Add(modelPericiaCopeseAtividade);
                    //////#endregion

                    //////#region Causa
                    //////ModelPericiaCopeseCausa modelPericiaCopeseCausa = new ModelPericiaCopeseCausa();
                    //////modelPericiaCopese.Causa = new List<ModelPericiaCopeseCausa>();
                    //////modelPericiaCopese.Causa.Add(modelPericiaCopeseCausa);
                    //////#endregion

                    //////#region Medida da Nota
                    //////ModelPericiaCopeseMedida modelPericiaCopeseMedida = new ModelPericiaCopeseMedida();
                    //////modelPericiaCopese.Medida = new List<ModelPericiaCopeseMedida>();
                    //////modelPericiaCopese.Medida.Add(modelPericiaCopeseMedida);
                    //////#endregion

                    //////#region PericiaCopese
                    //////modelPericiaCopese.Code = param.CodeSintoma.cd_sap;
                    //////modelPericiaCopese.Descricao = param.ds_descricao;
                    //////modelPericiaCopese.GrpCode = param.CodeSintoma.GrupoCode.cd_sap;
                    //////modelPericiaCopese.LocInstalacao = param.LocalInstalacao.cd_sap;
                    //////modelPericiaCopese.NotaReferencia = param.NotaReferencia.cd_nota_sap;
                    //////modelPericiaCopese.Notificador = param.Empregado.rg_empregado;
                    //////modelPericiaCopese.Observacao = param.ds_observacao;
                    ////////fsc***modelPericiaCopese.StatusNota = "";
                    //////modelPericiaCopese.StatusUsuario = "";
                    //////modelPericiaCopese.TipoNota = param.TipoNota.cd_sap;
                    //////#endregion 

                    ////////List<Resposta> respostaPericiaCopese = oPericiaCopese.CriacaoNota("DESENVOLVIMENTO", modelPericiaCopese);
                    ////////var verificar = respostaPericiaCopese.FirstOrDefault(x => x._status == true)._codMensagem;

                    ////////if (verificar == null)
                    ////////    throw new Exception("Codigo do sap nao retornado");

                    #endregion

                    dbContextTransaction.Commit();

                    param.BaseModel.Retorno = MessageType.Success;
                    param.BaseModel.MensagemUsuario = Mensagens.MSG04.Replace("[#1]", param.id_nota.ToString());
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    param.BaseModel.Erro = true;
                    param.BaseModel.Retorno = MessageType.Error;
                    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException = e;
                    Console.Write("Erro");
                }
            }
            return param;
        }

        public Nota UpdatePericia(Nota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.NotaRepository.Update(param);
                //context.SaveChanges();

                #region Atualiza Status de Medida da Nota de Pericia
                StatusMedidaService statusMedidaService;
                CodeService codeService = new CodeService();
                MedidaNota medidaNota;
                StatusMedida stMed;
                Code cod;

                statusMedidaService = new StatusMedidaService(this.context);

                var verificaNota = context.NotaRepository.GetById(param.id_nota);
                int sequenciaMedidaNota;

                try
                {
                    sequenciaMedidaNota = context.MedidaNotaRepository.AsQueryable().LastOrDefault(x => x.id_nota_fk == param.id_nota).sq_medida_nota;
                }
                catch (Exception) { sequenciaMedidaNota = 0; }

                //BO Metrô
                if (param.cd_bo_metro != verificaNota.cd_bo_metro)
                {
                    sequenciaMedidaNota = sequenciaMedidaNota + 1;
                    medidaNota = new MedidaNota();
                    medidaNota.id_nota_fk = param.id_nota;
                    medidaNota.sq_medida_nota = sequenciaMedidaNota;
                    medidaNota.dt_hora_medida_nota = DateTime.Now;
                    medidaNota.id_empregado_fk = null;              //empregado logado (falta implementar)
                    medidaNota.id_empregado_responsavel_fk = null; // Para este caso é null
                    medidaNota.ds_motivo = param.ds_bo_metro;

                    if (param.id_centro_trabalho_fk > 0)
                        medidaNota.id_cent_trab_responsavel_fk = param.id_centro_trabalho_fk;

                    medidaNota.fn_responsavel = "ZA";
                    stMed = statusMedidaService.GetByCdSap("ENCE");

                    medidaNota.id_st_medida_fk = stMed.id_st_medida;
                    cod = codeService.GetByCdSap("BOME");
                    medidaNota.id_code_tx_fk = cod.id_code;
                    context.MedidaNotaRepository.Add(medidaNota);
                }

                //BO SSP
                if (param.cd_bo_ssp != verificaNota.cd_bo_ssp)
                {
                    sequenciaMedidaNota = sequenciaMedidaNota + 1;
                    medidaNota = new MedidaNota();
                    medidaNota.id_nota_fk = param.id_nota;
                    medidaNota.sq_medida_nota = sequenciaMedidaNota;
                    medidaNota.dt_hora_medida_nota = DateTime.Now;
                    medidaNota.id_empregado_fk = null;              //empregado logado (falta implementar)
                    medidaNota.id_empregado_responsavel_fk = null; // Para este caso é null
                    medidaNota.ds_motivo = param.ds_bo_ssp;

                    if (param.id_centro_trabalho_fk > 0)
                        medidaNota.id_cent_trab_responsavel_fk = param.id_centro_trabalho_fk;

                    medidaNota.fn_responsavel = "ZA";
                    stMed = statusMedidaService.GetByCdSap("ENCE");

                    medidaNota.id_st_medida_fk = stMed.id_st_medida;
                    cod = codeService.GetByCdSap("BOSP");
                    medidaNota.id_code_tx_fk = cod.id_code;

                    context.MedidaNotaRepository.Add(medidaNota);
                }
                #endregion

                context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.MensagemUsuario = Mensagens.MSG08;
            }
            catch (Exception e)
            {
                param.BaseModel.Erro = true;
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
                Console.Write("Erro");
            }

            return param;
        }

        public Nota LiberarPericia(Nota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                //context.NotaRepository.Add(param);
                //context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.MensagemUsuario = Mensagens.MSG500;
            }
            catch (Exception e)
            {
                param.BaseModel.Erro = true;
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
                Console.Write("Erro");
            }

            return param;
        }

        public Nota EncerrarPericia(Nota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                //context.NotaRepository.Add(param);
                //context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.MensagemUsuario = Mensagens.MSG46;
            }
            catch (Exception e)
            {
                param.BaseModel.Erro = true;
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
                Console.Write("Erro");
            }

            return param;
        }
        #endregion
        #region NotaMI
        public Nota CriarMI(Nota nota)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    TipoNotaService tipoNotaService = new TipoNotaService(this.context);
                    StatusSistema statusSistema = new StatusSistema();
                    StatusSistemaService statusSistemaService = new StatusSistemaService(this.context);
                    StatusUsuarioService statusUsuarioService = new StatusUsuarioService(this.context);
                    TipoNota tipoNota = tipoNotaService.GetByCodigoSap(TipoNotaSelecionarType.MI.ToString());

                    List<StatusUsuario> statusUsuario = new List<StatusUsuario>();
                    statusUsuario.Add(statusUsuarioService.GetByCdSap("ABER"));

                    if (nota.st_if_oper_maior_cinco_min ?? false)
                    {
                        statusUsuario.Add(statusUsuarioService.GetByCdSap("MKB5"));
                    }

                    if (nota.st_in_notavel ?? false)
                    {
                        statusUsuario.Add(statusUsuarioService.GetByCdSap("INCN"));
                    }

                    if (nota.st_fumaca ?? false)
                    {
                        statusUsuario.Add(statusUsuarioService.GetByCdSap("FUMA"));
                    }

                    if (nota.st_reboque ?? false)
                    {
                        statusUsuario.Add(statusUsuarioService.GetByCdSap("REBQ"));
                    }

                    nota.StatusUsuarios = statusUsuario;
                    nota.id_tp_nota_fk = tipoNota.id_tp_nota;
                    nota.id_st_sistema_fk = statusSistemaService.GetByCdSap("MSPN")?.id_st_sistema;

                    context.NotaRepository.Add(nota);
                    context.SaveChanges();

                    MedidaNota medidaNota = new MedidaNota();
                    medidaNota.id_nota_fk = nota.id_nota;
                    medidaNota.id_st_usuario_fk = statusUsuarioService.GetByCdSap("ABER")?.id_st_usuario;
                    medidaNota.sq_medida_nota = 1;
                    medidaNota.dt_hora_medida_nota = DateTime.Now;
                    medidaNota.id_empregado_fk = null; //empregado logado (falta implementar)
                    medidaNota.id_empregado_responsavel_fk = null; // Para este caso é null
                    medidaNota.id_cent_trab_responsavel_fk = nota.id_centro_trabalho_fk;
                    medidaNota.fn_responsavel = "ZA";
                    medidaNota.id_st_medida_fk = new StatusMedidaService().GetByCdSap("LIBE")?.id_st_medida;
                    medidaNota.id_code_tx_fk = new CodeService().GetByCdSap("ABER")?.id_code;

                    MedidaNotaService medidaNtServices = new MedidaNotaService(this.context);
                    medidaNtServices.Add(medidaNota);

                    dbContextTransaction.Commit();

                    nota.BaseModel.Erro = false;
                    nota.BaseModel.Retorno = MessageType.Success;
                    nota.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();

                    nota.BaseModel.Erro = true;
                    nota.BaseModel.Retorno = MessageType.Error;
                    nota.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    nota.BaseModel.MensagemException = e;
                    Console.Write("Erro");
                }

            }

            return nota;
        }

        public Nota EditarMI(Nota nota)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    Nota dbNota = this.GetNotaStatusUsuarioById(nota.id_nota);
                    dbNota.id_tp_nota_fk = nota.id_tp_nota_fk;
                    dbNota.id_local_inst_fk = nota.id_local_inst_fk;
                    dbNota.id_local_inst_princ_fk = nota.id_local_inst_princ_fk;
                    dbNota.id_code_sintoma_fk = nota.id_code_sintoma_fk;
                    dbNota.ds_descricao = nota.ds_descricao;
                    dbNota.id_prioridade_fk = nota.id_prioridade_fk;
                    dbNota.id_notificador_fk = nota.id_notificador_fk;
                    dbNota.sg_local = nota.sg_local;
                    dbNota.id_linha_fk = nota.id_linha_fk;
                    dbNota.id_centro_trabalho_fk = nota.id_centro_trabalho_fk;
                    dbNota.ds_observacao = nota.ds_observacao;
                    dbNota.st_in_notavel = nota.st_in_notavel;
                    dbNota.st_fumaca = nota.st_fumaca;
                    dbNota.st_reboque = nota.st_reboque;
                    dbNota.dt_hora_nota = nota.dt_hora_nota;

                    void CheckStatus(bool status, string st_usuario_cd_sap, DatabaseContext context)
                    {
                        StatusUsuarioService statusService = new StatusUsuarioService(context);
                        StatusUsuario statusUsuario = new StatusUsuario();

                        if (status)
                        {
                            statusUsuario = statusService.GetByCdSap(st_usuario_cd_sap);

                            if (!dbNota.StatusUsuarios.Contains(statusUsuario))
                            {
                                dbNota.StatusUsuarios.Add(statusUsuario);
                            }
                        }
                        else
                        {
                            statusUsuario = statusService.GetByCdSap(st_usuario_cd_sap);

                            if (dbNota.StatusUsuarios.Contains(statusUsuario))
                            {
                                dbNota.StatusUsuarios.Remove(statusUsuario);
                            }
                        }
                    }

                    CheckStatus(dbNota.st_if_oper_maior_cinco_min ?? false, "MKB5", this.context);
                    CheckStatus(dbNota.st_in_notavel ?? false, "INCN", this.context);
                    CheckStatus(dbNota.st_fumaca ?? false, "FUMA", this.context);
                    CheckStatus(dbNota.st_reboque ?? false, "REBQ", this.context);

                    context.NotaRepository.Update(dbNota);
                    context.SaveChanges();
                    dbContextTransaction.Commit();

                    nota.BaseModel.Erro = false;
                    nota.BaseModel.Retorno = MessageType.Success;
                    nota.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();

                    nota.BaseModel.Erro = true;
                    nota.BaseModel.Retorno = MessageType.Error;
                    nota.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    nota.BaseModel.MensagemException = e;
                    Console.Write("Erro");
                }
            }

            return nota;
        }

        public Nota CancelarMI(int id, string motivo)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    Nota dbNota = this.GetNotaStatusUsuarioById(id);

                    MedidaNota ultimaMedida = context.MedidaNotaRepository.AsQueryable()
                        .Where(x => x.id_nota_fk == id)
                        .OrderByDescending(x => x.sq_medida_nota)?
                        .First();

                    StatusUsuario statusUsuario = context.StatusUsuarioRepository.AsQueryable()
                        .Where(x => x.id_st_usuario == ultimaMedida.id_st_usuario_fk).First();

                    if (dbNota.StatusUsuarios.Contains(statusUsuario))
                    {
                        dbNota.StatusUsuarios.Remove(statusUsuario);
                    }

                    StatusUsuario stCanc = context.StatusUsuarioRepository.AsQueryable().Where(x => x.cd_sap == "CANC").First();
                    StatusMedida stEnce = context.StatusMedidaRepository.AsQueryable().Where(x => x.cd_sap == "ENCE").First();
                    StatusSistema stMsen = context.StatusSistemaRepository.AsQueryable().Where(x => x.cd_sap == "MSEN").First();

                    dbNota.StatusUsuarios.Add(stCanc);
                    dbNota.id_st_sistema_fk = stMsen?.id_st_sistema;
                    context.NotaRepository.Update(dbNota);

                    ultimaMedida.id_st_medida_fk = stEnce?.id_st_medida;
                    context.MedidaNotaRepository.Update(ultimaMedida);

                    MedidaNota novaMedida = new MedidaNota();
                    novaMedida.id_nota_fk = id;
                    novaMedida.id_code_tx_fk = context.CodeRepository.AsQueryable().Where(x => x.cd_sap == "CANC").First()?.id_code;
                    novaMedida.dt_hora_medida_nota = DateTime.Now;
                    novaMedida.id_st_usuario_fk = stCanc.id_st_usuario;
                    novaMedida.id_st_medida_fk = stEnce.id_st_medida;
                    novaMedida.sq_medida_nota = ultimaMedida.sq_medida_nota + 1;
                    novaMedida.ds_motivo = motivo;

                    context.MedidaNotaRepository.Add(novaMedida);
                    context.SaveChanges();

                    dbContextTransaction.Commit();

                    dbNota.BaseModel.Erro = false;
                    dbNota.BaseModel.Retorno = MessageType.Success;
                    dbNota.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;

                    return dbNota;
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();

                    Nota erroNota = new Nota();
                    erroNota.BaseModel.Erro = true;
                    erroNota.BaseModel.Retorno = MessageType.Error;
                    erroNota.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    erroNota.BaseModel.MensagemException = e;
                    Console.Write("Erro");
                    return erroNota;
                }
            }

        }

        public List<Nota> PesquisarNotaMI(int? idFrota, int? idTrem = null, int? idCarro = null, string cdSap = null, DateTime? dataInicial = null, DateTime? dataFinal = null, int? idNotificador = null, int? rg_notificador = null, int? idStatus = null)
        {
            if (idFrota > 0 || idTrem > 0 || cdSap != null || idStatus > 0 || idCarro > 0 || dataInicial != null || dataFinal != null || idNotificador > 0 || rg_notificador != null)
            {
                var parameterExpression = Expression.Parameter(typeof(Nota), "n");
                Expression expression = null;

                TipoNotaService tpnotaServices = new TipoNotaService(this.context);
                TipoNota tipoNota = tpnotaServices.GetByCodigoSap(TipoNotaSelecionarType.MI.ToString());

                var constantTpNota = Expression.Constant(tipoNota.id_tp_nota);
                var propertyTpNota = Expression.Property(parameterExpression, "id_tp_nota_fk");
                var expressionTpNota = Expression.Equal(propertyTpNota, constantTpNota);

                expression = expressionTpNota;

                Expression localInstProp = Expression.Property(parameterExpression, typeof(Nota).GetProperty("LocalInstalacao"));

                if (idFrota != null && idFrota > 0)
                {
                    var constantIdFrota = Expression.Constant(idFrota.GetValueOrDefault());
                    Expression propertyIdFrota = Expression.Property(localInstProp, typeof(LocalInstalacao).GetProperty("id_frota_fk"));
                    Expression propertyIdFrotaConverted = Expression.Convert(propertyIdFrota, typeof(int));
                    var expressionIdFrota = Expression.Equal(propertyIdFrotaConverted, constantIdFrota);

                    if (expression == null)
                    {
                        expression = expressionIdFrota;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdFrota);
                    }
                }

                if (idTrem != null && idTrem > 0)
                {
                    var constantIdTrem = Expression.Constant(idTrem.GetValueOrDefault());
                    Expression propertyIdTrem = Expression.Property(localInstProp, typeof(LocalInstalacao).GetProperty("id_trem_fk"));
                    Expression propertyIdTremConverted = Expression.Convert(propertyIdTrem, typeof(int));
                    var expressionIdTrem = Expression.Equal(propertyIdTremConverted, constantIdTrem);

                    if (expression == null)
                    {
                        expression = expressionIdTrem;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdTrem);
                    }
                }

                if (idCarro != null && idCarro > 0)
                {
                    var constantIdCarro = Expression.Constant(idCarro.GetValueOrDefault());
                    Expression propertyIdCarro = Expression.Property(localInstProp, typeof(LocalInstalacao).GetProperty("id_carro_fk"));
                    Expression propertyIdCarroConverted = Expression.Convert(propertyIdCarro, typeof(int));
                    var expressionIdCarro = Expression.Equal(propertyIdCarroConverted, constantIdCarro);

                    if (expression == null)
                    {
                        expression = expressionIdCarro;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdCarro);
                    }
                }

                if (cdSap != null)
                {
                    var constantCdSap = Expression.Constant(cdSap);
                    var propertyCdSap = Expression.Property(parameterExpression, "cd_nota_sap");
                    var expressionCdSap = Expression.Equal(propertyCdSap, constantCdSap);
                    if (expression == null)
                    {
                        expression = expressionCdSap;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionCdSap);
                    }
                }

                if (dataInicial > DateTime.Now.AddYears(-100))
                {
                    var constantDtInicio = Expression.Constant(dataInicial);
                    var propertyDtInicio = Expression.Property(parameterExpression, "dt_hora_nota");
                    var propertyDtInicioConverted = Expression.Convert(propertyDtInicio, dataInicial.GetType());
                    var expressionDtInicio = Expression.GreaterThanOrEqual(propertyDtInicioConverted, constantDtInicio);

                    if (expression == null)
                    {
                        expression = expressionDtInicio;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionDtInicio);
                    }
                }

                if (dataFinal > DateTime.Now.AddYears(-100))
                {
                    var constantDtFim = Expression.Constant(dataFinal);
                    var propertyDtFim = Expression.Property(parameterExpression, "dt_hora_nota");
                    var propertyDtFimConverted = Expression.Convert(propertyDtFim, dataFinal.GetType());
                    var expressionDtFim = Expression.LessThanOrEqual(propertyDtFimConverted, constantDtFim);
                    if (expression == null)
                    {
                        expression = expressionDtFim;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionDtFim);
                    }
                }

                if (idNotificador != null && idNotificador > 0)
                {
                    var constantIdNotificador = Expression.Constant(idNotificador);
                    var propertyIdNotificador = Expression.Property(parameterExpression, "id_notificador_fk");
                    var propertyIdNotificadorConverted = Expression.Convert(propertyIdNotificador, idNotificador.GetType());
                    var expressionIdNotificador = Expression.Equal(propertyIdNotificadorConverted, constantIdNotificador);
                    if (expression == null)
                    {
                        expression = expressionIdNotificador;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdNotificador);
                    }
                }

                if (idStatus != null && idStatus > 0)
                {
                    var properties = Expression.PropertyOrField(parameterExpression, "StatusUsuarios");
                    var stProperty = Expression.Parameter(typeof(StatusUsuario), "statusUsuario");

                    var condition = Expression.Equal(
                        Expression.PropertyOrField(stProperty, "id_st_usuario"),
                        Expression.Constant(idStatus)
                    );

                    var predicate = Expression.Lambda<Func<StatusUsuario, bool>>(condition, stProperty);

                    var anyCall = Expression.Call(
                        typeof(Enumerable), "Any", new[] { typeof(StatusUsuario) },
                        properties, predicate
                    );

                    var bookPredicate = Expression.Lambda<Func<Nota, bool>>(anyCall, parameterExpression);
                    var bookPredicate2 = bookPredicate.Compile();

                    if (expression == null)
                    {
                        expression = anyCall;
                    }
                    else
                    {
                        expression = Expression.And(expression, anyCall);
                    }
                }

                var lambda = Expression.Lambda<Func<Nota, bool>>(expression, parameterExpression);
                var compiledLambda = lambda.Compile();

                var notaRetorno = context.NotaRepository.AsQueryable()
                    .Include(x => x.TipoNota)
                    .Include(x => x.LocalInstalacao)
                    .Include(x => x.CodeSintoma)
                    .Include(x => x.Prioridade)
                    .Include(x => x.StatusUsuarios)
                    .Include(x => x.Empregado)
                    .Where(lambda).OrderByDescending(x => x.id_nota).ToList();

                return notaRetorno;
            }
            else
            {
                return new List<Nota>();
            }
        }
        #endregion

        public Nota Update(Nota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.NotaRepository.Update(param);
                context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.MensagemUsuario = Mensagens.Registro_Atualizado;
            }
            catch (Exception e)
            {
                param.BaseModel.Erro = true;
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
                Console.Write("Erro");
            }

            return param;
        }


        public Nota CarregarUltima(string tpNpta)
        {
            Nota nota = context.NotaRepository.AsQueryable()
                .Include(x => x.TipoNota)
                .Include(x => x.LocalInstalacao)
                .Include(x => x.LocalInstPrinc)
                .Include(x => x.NotaReferencia)
                .Include(x => x.StatusSistema)
                .Include(x => x.CodeSintoma)
                .Include(x => x.Prioridade)
                .Include(x => x.CentroTrabalho)
                .Include(x => x.ElementoPEP)
                .Include(x => x.Material)
                .Include(x => x.UnidadeMedidaTempoPrevisto)
                .Include(x => x.StatusPericia)
                .Include(x => x.EventoGerador)
                .Include(x => x.Diagnostico)
                .Include(x => x.Empregado)
                .Where(x => x.TipoNota.cd_sap == tpNpta)
                .OrderByDescending(x => x.id_nota)
                .First();

            return nota;
        }

        public int CountByFrotaTremCarro(int idFrota, int idTrem, int idCarro)
        {
            int notas = 0;
            notas = context.NotaRepository.AsQueryable().Where(x => x.LocalInstalacao.id_frota_fk == idFrota && x.LocalInstalacao.id_trem_fk == idTrem && x.LocalInstalacao.id_carro_fk == idCarro).ToList().Count();
            return notas;
        }

        #region NotaProgramacao
        public List<Nota> PesquisarNotaProgramacao(int? idFrota, int? idTrem = null, int? idCarro = null, int? idSistema = null, int? idSintoma = null, string cdSap = null, DateTime? dataInicial = null, DateTime? dataFinal = null, int? idPrioridade = null, int? idNotificador = null, int? rg_notificador = null, int? idStatus = null, int? idNotStatus = null, string cd_sap = "MC")
        {
            DateTime teste = DateTime.Now;

            //TimeZoneInfo tzInfo = TimeZoneInfo.Local;
            //var offset = tzInfo.GetUtcOffset(dataInicial.GetValueOrDefault());
            //var newDt = dataInicial.GetValueOrDefault() + offset;

            string teste1 = teste.ToString();

            if (idFrota > 0 || idTrem > 0 || cdSap != null || idStatus > 0 || idNotStatus > 0 || idCarro > 0 || idSistema > 0 || idSintoma > 0 || dataInicial != null || dataFinal != null || idPrioridade > 0 || idNotificador > 0 || rg_notificador != null)
            {
                var parameterExpression = Expression.Parameter(typeof(Nota), "n");
                Expression expression = null;

                TipoNotaService tpnotaServices = new TipoNotaService(this.context);
                //TipoNota tipoNota = tpnotaServices.GetByCodigoSap("MC");
                TipoNota tipoNota = tpnotaServices.GetByCodigoSap(cd_sap.ToUpper());
                var constantTpNota = Expression.Constant(tipoNota.id_tp_nota);
                var propertyTpNota = Expression.Property(parameterExpression, "id_tp_nota_fk");
                var expressionTpNota = Expression.Equal(propertyTpNota, constantTpNota);
                expression = expressionTpNota;
                Expression localInstProp = Expression.Property(parameterExpression, typeof(Nota).GetProperty("LocalInstalacao"));

                if (idFrota != null && idFrota > 0)
                {
                    var constantIdFrota = Expression.Constant(idFrota.GetValueOrDefault());
                    Expression propertyIdFrota = Expression.Property(localInstProp, typeof(LocalInstalacao).GetProperty("id_frota_fk"));
                    Expression propertyIdFrotaConverted = Expression.Convert(propertyIdFrota, typeof(int));
                    var expressionIdFrota = Expression.Equal(propertyIdFrotaConverted, constantIdFrota);

                    //expression = expressionIdFrota;

                    if (expression == null)
                    {
                        expression = expressionIdFrota;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdFrota);
                    }

                }
                if (idTrem != null && idTrem > 0)
                {
                    var constantIdTrem = Expression.Constant(idTrem.GetValueOrDefault());
                    Expression propertyIdTrem = Expression.Property(localInstProp, typeof(LocalInstalacao).GetProperty("id_trem_fk"));
                    Expression propertyIdTremConverted = Expression.Convert(propertyIdTrem, typeof(int));
                    var expressionIdTrem = Expression.Equal(propertyIdTremConverted, constantIdTrem);
                    if (expression == null)
                    {
                        expression = expressionIdTrem;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdTrem);
                    }
                }
                if (idCarro != null && idCarro > 0)
                {
                    var constantIdCarro = Expression.Constant(idCarro.GetValueOrDefault());
                    Expression propertyIdCarro = Expression.Property(localInstProp, typeof(LocalInstalacao).GetProperty("id_carro_fk"));
                    Expression propertyIdCarroConverted = Expression.Convert(propertyIdCarro, typeof(int));
                    var expressionIdCarro = Expression.Equal(propertyIdCarroConverted, constantIdCarro);
                    if (expression == null)
                    {
                        expression = expressionIdCarro;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdCarro);
                    }
                }
                if (idSistema != null && idSistema > 0)
                {
                    var constantIdSistema = Expression.Constant(idSistema.GetValueOrDefault());
                    Expression propertyIdSistema = Expression.Property(localInstProp, typeof(LocalInstalacao).GetProperty("id_sistema_fk"));
                    Expression propertyIdSistemaConverted = Expression.Convert(propertyIdSistema, typeof(int));
                    var expressionIdSistema = Expression.Equal(propertyIdSistemaConverted, constantIdSistema);
                    if (expression == null)
                    {
                        expression = expressionIdSistema;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdSistema);
                    }
                }
                if (idSintoma != null && idSintoma > 0)
                {
                    var constantIdSintoma = Expression.Constant(idSintoma.GetValueOrDefault());
                    Expression propertyIdSintoma = Expression.Property(localInstProp, typeof(LocalInstalacao).GetProperty("id_sintoma_fk"));
                    Expression propertyIdSintomaConverted = Expression.Convert(propertyIdSintoma, typeof(int));
                    var expressionIdSintoma = Expression.Equal(propertyIdSintomaConverted, constantIdSintoma);
                    if (expression == null)
                    {
                        expression = expressionIdSintoma;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdSintoma);
                    }
                }
                if (cdSap != null)
                {
                    var constantCdSap = Expression.Constant(cdSap);
                    var propertyCdSap = Expression.Property(parameterExpression, "cd_nota_sap");
                    var expressionCdSap = Expression.Equal(propertyCdSap, constantCdSap);
                    if (expression == null)
                    {
                        expression = expressionCdSap;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionCdSap);
                    }
                }
                #region DtInicio
                if (dataInicial > DateTime.Now.AddYears(-100))
                {
                    var constantDtInicio = Expression.Constant(dataInicial);
                    var propertyDtInicio = Expression.Property(parameterExpression, "dt_hora_nota");
                    var propertyDtInicioConverted = Expression.Convert(propertyDtInicio, dataInicial.GetType());
                    var expressionDtInicio = Expression.GreaterThanOrEqual(propertyDtInicioConverted, constantDtInicio);
                    if (expression == null)
                    {
                        expression = expressionDtInicio;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionDtInicio);
                    }
                }
                #endregion

                #region DtFim
                if (dataFinal > DateTime.Now.AddYears(-100))
                {
                    var constantDtFim = Expression.Constant(dataFinal);
                    var propertyDtFim = Expression.Property(parameterExpression, "dt_hora_nota");
                    var propertyDtFimConverted = Expression.Convert(propertyDtFim, dataFinal.GetType());
                    var expressionDtFim = Expression.LessThanOrEqual(propertyDtFimConverted, constantDtFim);
                    if (expression == null)
                    {
                        expression = expressionDtFim;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionDtFim);
                    }
                }
                #endregion
                if (idPrioridade != null && idPrioridade > 0)
                {
                    var constantIdPrioridade = Expression.Constant(idPrioridade);
                    var propertyIdPrioridade = Expression.Property(parameterExpression, "id_prioridade_fk");
                    var propertyIdPrioridadeConverted = Expression.Convert(propertyIdPrioridade, idPrioridade.GetType());
                    var expressionIdPrioridade = Expression.Equal(propertyIdPrioridadeConverted, constantIdPrioridade);
                    if (expression == null)
                    {
                        expression = expressionIdPrioridade;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdPrioridade);
                    }
                }
                if (idNotificador != null && idNotificador > 0)
                {
                    var constantIdNotificador = Expression.Constant(idNotificador);
                    var propertyIdNotificador = Expression.Property(parameterExpression, "id_notificador_fk");
                    var propertyIdNotificadorConverted = Expression.Convert(propertyIdNotificador, idNotificador.GetType());
                    var expressionIdNotificador = Expression.Equal(propertyIdNotificadorConverted, constantIdNotificador);
                    if (expression == null)
                    {
                        expression = expressionIdNotificador;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdNotificador);
                    }
                }
                //Expression<Func<Nota, bool>> bookPredicate = book => book.properties.Any(bookProperty => bookProperty.type.key == "tipo1" && bookProperty.value == "1");
                if (idStatus != null && idStatus > 0)
                {
                    var properties = Expression.PropertyOrField(parameterExpression, "StatusUsuarios");
                    var stProperty = Expression.Parameter(typeof(StatusUsuario), "statusUsuario");
                    

                    // bookProperty.value == "1"
                    var condition = Expression.Equal(
                        Expression.PropertyOrField(stProperty, "id_st_usuario"),
                        Expression.Constant(idStatus)
                    );
                    
                    //var condition = Expression.AndAlso(conditionA, conditionB);
                    
                    var predicate = Expression.Lambda<Func<StatusUsuario, bool>>(condition, stProperty);
                    
                    var anyCall = Expression.Call(
                        typeof(Enumerable), "Any", new[] { typeof(StatusUsuario) },
                        properties, predicate
                    );
                    // book => book.properties.Any(...)
                    var bookPredicate = Expression.Lambda<Func<Nota, bool>>(anyCall, parameterExpression);
                    var bookPredicate2 = bookPredicate.Compile();
                    if (expression == null)
                    {
                        expression = anyCall;
                    }
                    else
                    {
                        expression = Expression.And(expression, anyCall);
                    }
                }


                if (idNotStatus != null && idNotStatus > 0)
                {
                    var properties = Expression.PropertyOrField(parameterExpression, "StatusUsuarios");
                    var stProperty = Expression.Parameter(typeof(StatusUsuario), "statusUsuario");
                    

                    // bookProperty.value == "1"
                    var condition = Expression.NotEqual(
                        Expression.PropertyOrField(stProperty, "id_st_usuario"),
                        Expression.Constant(idNotStatus)
                    );
                    
                    //var condition = Expression.AndAlso(conditionA, conditionB);
                    
                    var predicate = Expression.Lambda<Func<StatusUsuario, bool>>(condition, stProperty);
                    
                    var anyCall = Expression.Call(
                        typeof(Enumerable), "Any", new[] { typeof(StatusUsuario) },
                        properties, predicate
                    );
                    // book => book.properties.Any(...)
                    var bookPredicate = Expression.Lambda<Func<Nota, bool>>(anyCall, parameterExpression);
                    var bookPredicate2 = bookPredicate.Compile();
                    if (expression == null)
                    {
                        expression = anyCall;
                    }
                    else
                    {
                        expression = Expression.And(expression, anyCall);
                    }
                }

                var lambda = Expression.Lambda<Func<Nota, bool>>(expression, parameterExpression);
                var compiledLambda = lambda.Compile();

                var notaRetorno = context.NotaRepository.AsQueryable().Include(x => x.TipoNota).Include(x => x.LocalInstalacao).Include(x => x.CodeSintoma).Include(x => x.Prioridade).Include(x => x.StatusUsuarios).Include(x => x.CentroTrabalho).Include(x => x.Empregado).Where(lambda).OrderByDescending(x => x.id_nota)
                    .ToList();
                return notaRetorno;
            }
            else
            {
                return new List<Nota>();
            }
        }
        #endregion

        #region NotaMC
        public List<Nota> PesquisarNotaMC(int? idFrota, int? idTrem = null, int? idCarro = null, int? idSistema = null, int? idSintoma = null, string cdSap = null, DateTime? dataInicial = null, DateTime? dataFinal = null, int? idPrioridade = null, int? idNotificador = null, int? rg_notificador = null, int? idStatus = null)
        {
            DateTime teste = DateTime.Now;

            //TimeZoneInfo tzInfo = TimeZoneInfo.Local;
            //var offset = tzInfo.GetUtcOffset(dataInicial.GetValueOrDefault());
            //var newDt = dataInicial.GetValueOrDefault() + offset;

            string teste1 = teste.ToString();

            if (idFrota > 0 || idTrem > 0 || cdSap != null || idStatus > 0 || idCarro > 0 || idSistema > 0 || idSintoma > 0 || dataInicial != null || dataFinal != null || idPrioridade > 0 || idNotificador > 0 || rg_notificador != null)
            {
                var parameterExpression = Expression.Parameter(typeof(Nota), "n");
                Expression expression = null;

                TipoNotaService tpnotaServices = new TipoNotaService(this.context);
                TipoNota tipoNota = tpnotaServices.GetByCodigoSap("MC");
                //TipoNota tipoNota = tpnotaServices.GetByCodigoSap(cd_sap.ToUpper());


                //param.id_tp_nota_fk = tipoNota.id_tp_nota;

                var constantTpNota = Expression.Constant(tipoNota.id_tp_nota);
                var propertyTpNota = Expression.Property(parameterExpression, "id_tp_nota_fk");
                var expressionTpNota = Expression.Equal(propertyTpNota, constantTpNota);
                //if (expression == null)
                //{

                expression = expressionTpNota;

                //}
                //else
                //{
                //expression = Expression.And(expression, expressionCdSap);
                //}

                Expression localInstProp = Expression.Property(parameterExpression, typeof(Nota).GetProperty("LocalInstalacao"));

                if (idFrota != null && idFrota > 0)
                {
                    var constantIdFrota = Expression.Constant(idFrota.GetValueOrDefault());
                    Expression propertyIdFrota = Expression.Property(localInstProp, typeof(LocalInstalacao).GetProperty("id_frota_fk"));
                    Expression propertyIdFrotaConverted = Expression.Convert(propertyIdFrota, typeof(int));
                    var expressionIdFrota = Expression.Equal(propertyIdFrotaConverted, constantIdFrota);

                    //expression = expressionIdFrota;

                    if (expression == null)
                    {
                        expression = expressionIdFrota;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdFrota);
                    }

                }
                if (idTrem != null && idTrem > 0)
                {
                    var constantIdTrem = Expression.Constant(idTrem.GetValueOrDefault());
                    Expression propertyIdTrem = Expression.Property(localInstProp, typeof(LocalInstalacao).GetProperty("id_trem_fk"));
                    Expression propertyIdTremConverted = Expression.Convert(propertyIdTrem, typeof(int));
                    var expressionIdTrem = Expression.Equal(propertyIdTremConverted, constantIdTrem);
                    if (expression == null)
                    {
                        expression = expressionIdTrem;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdTrem);
                    }
                }
                if (idCarro != null && idCarro > 0)
                {
                    var constantIdCarro = Expression.Constant(idCarro.GetValueOrDefault());
                    Expression propertyIdCarro = Expression.Property(localInstProp, typeof(LocalInstalacao).GetProperty("id_carro_fk"));
                    Expression propertyIdCarroConverted = Expression.Convert(propertyIdCarro, typeof(int));
                    var expressionIdCarro = Expression.Equal(propertyIdCarroConverted, constantIdCarro);
                    if (expression == null)
                    {
                        expression = expressionIdCarro;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdCarro);
                    }
                }
                if (idSistema != null && idSistema > 0)
                {
                    var constantIdSistema = Expression.Constant(idSistema.GetValueOrDefault());
                    Expression propertyIdSistema = Expression.Property(localInstProp, typeof(LocalInstalacao).GetProperty("id_sistema_fk"));
                    Expression propertyIdSistemaConverted = Expression.Convert(propertyIdSistema, typeof(int));
                    var expressionIdSistema = Expression.Equal(propertyIdSistemaConverted, constantIdSistema);
                    if (expression == null)
                    {
                        expression = expressionIdSistema;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdSistema);
                    }
                }
                if (idSintoma != null && idSintoma > 0)
                {
                    var constantIdSintoma = Expression.Constant(idSintoma.GetValueOrDefault());
                    Expression propertyIdSintoma = Expression.Property(localInstProp, typeof(LocalInstalacao).GetProperty("id_sintoma_fk"));
                    Expression propertyIdSintomaConverted = Expression.Convert(propertyIdSintoma, typeof(int));
                    var expressionIdSintoma = Expression.Equal(propertyIdSintomaConverted, constantIdSintoma);
                    if (expression == null)
                    {
                        expression = expressionIdSintoma;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdSintoma);
                    }
                }
                if (cdSap != null)
                {
                    var constantCdSap = Expression.Constant(cdSap);
                    var propertyCdSap = Expression.Property(parameterExpression, "cd_nota_sap");
                    var expressionCdSap = Expression.Equal(propertyCdSap, constantCdSap);
                    if (expression == null)
                    {
                        expression = expressionCdSap;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionCdSap);
                    }
                }
                #region DtInicio
                if (dataInicial > DateTime.Now.AddYears(-100))
                {
                    var constantDtInicio = Expression.Constant(dataInicial);
                    var propertyDtInicio = Expression.Property(parameterExpression, "dt_hora_nota");
                    var propertyDtInicioConverted = Expression.Convert(propertyDtInicio, dataInicial.GetType());
                    var expressionDtInicio = Expression.GreaterThanOrEqual(propertyDtInicioConverted, constantDtInicio);
                    if (expression == null)
                    {
                        expression = expressionDtInicio;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionDtInicio);
                    }
                }
                #endregion

                #region DtFim
                if (dataFinal > DateTime.Now.AddYears(-100))
                {
                    var constantDtFim = Expression.Constant(dataFinal);
                    var propertyDtFim = Expression.Property(parameterExpression, "dt_hora_nota");
                    var propertyDtFimConverted = Expression.Convert(propertyDtFim, dataFinal.GetType());
                    var expressionDtFim = Expression.LessThanOrEqual(propertyDtFimConverted, constantDtFim);
                    if (expression == null)
                    {
                        expression = expressionDtFim;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionDtFim);
                    }
                }
                #endregion
                if (idPrioridade != null && idPrioridade > 0)
                {
                    var constantIdPrioridade = Expression.Constant(idPrioridade);
                    var propertyIdPrioridade = Expression.Property(parameterExpression, "id_prioridade_fk");
                    var propertyIdPrioridadeConverted = Expression.Convert(propertyIdPrioridade, idPrioridade.GetType());
                    var expressionIdPrioridade = Expression.Equal(propertyIdPrioridadeConverted, constantIdPrioridade);
                    if (expression == null)
                    {
                        expression = expressionIdPrioridade;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdPrioridade);
                    }
                }
                if (idNotificador != null && idNotificador > 0)
                {
                    var constantIdNotificador = Expression.Constant(idNotificador);
                    var propertyIdNotificador = Expression.Property(parameterExpression, "id_notificador_fk");
                    var propertyIdNotificadorConverted = Expression.Convert(propertyIdNotificador, idNotificador.GetType());
                    var expressionIdNotificador = Expression.Equal(propertyIdNotificadorConverted, constantIdNotificador);
                    if (expression == null)
                    {
                        expression = expressionIdNotificador;
                    }
                    else
                    {
                        expression = Expression.And(expression, expressionIdNotificador);
                    }
                }


                //Expression<Func<Nota, bool>> bookPredicate = book => book.properties.Any(bookProperty => bookProperty.type.key == "tipo1" && bookProperty.value == "1");
                if (idStatus != null && idStatus > 0)
                {
                    var properties = Expression.PropertyOrField(parameterExpression, "StatusUsuarios");
                    var stProperty = Expression.Parameter(typeof(StatusUsuario), "statusUsuario");
                    

                    // bookProperty.value == "1"
                    var condition = Expression.Equal(
                        Expression.PropertyOrField(stProperty, "id_st_usuario"),
                        Expression.Constant(idStatus)
                    );
                    
                    //var condition = Expression.AndAlso(conditionA, conditionB);
                    
                    var predicate = Expression.Lambda<Func<StatusUsuario, bool>>(condition, stProperty);
                    
                    var anyCall = Expression.Call(
                        typeof(Enumerable), "Any", new[] { typeof(StatusUsuario) },
                        properties, predicate
                    );
                    // book => book.properties.Any(...)
                    var bookPredicate = Expression.Lambda<Func<Nota, bool>>(anyCall, parameterExpression);
                    var bookPredicate2 = bookPredicate.Compile();
                    if (expression == null)
                    {
                        expression = anyCall;
                    }
                    else
                    {
                        expression = Expression.And(expression, anyCall);
                    }
                }


                var lambda = Expression.Lambda<Func<Nota, bool>>(expression, parameterExpression);
                var compiledLambda = lambda.Compile();

                var notaRetorno = context.NotaRepository.AsQueryable().Include(x => x.TipoNota).Include(x => x.LocalInstalacao).Include(x => x.CodeSintoma).Include(x => x.Prioridade).Include(x => x.StatusUsuarios).Include(x => x.CentroTrabalho).Include(x => x.Empregado).Where(lambda).OrderByDescending(x => x.id_nota)
                    .ToList();
                return notaRetorno;
            }
            else
            {
                return new List<Nota>();
            }
        }

        public Nota CriarMC(Nota param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {


                    TipoNotaService tpnotaServices = new TipoNotaService(this.context);
                    TipoNota tipoNota = tpnotaServices.GetByCodigoSap("MC");
                    param.id_tp_nota_fk = tipoNota.id_tp_nota;

                    StatusSistema stSistema = new StatusSistema();
                    StatusSistemaService stSistemaService = new StatusSistemaService(this.context);
                    stSistema = stSistemaService.GetByCdSap("MSPN");
                    param.id_st_sistema_fk = stSistema.id_st_sistema;



                    StatusUsuarioService statusService = new StatusUsuarioService(this.context);
                    param.StatusUsuarios = new List<StatusUsuario>();

                    StatusUsuario stAber = new StatusUsuario();
                    stAber = statusService.GetByCdSap("ABER");
                    param.StatusUsuarios.Add(stAber);
                    //context.StatusUsuarioRepository.Attach(stAber);

                    if (param.st_if_oper_maior_cinco_min == true)
                    {
                        StatusUsuario stUsu1 = new StatusUsuario();
                        stUsu1 = statusService.GetByCdSap("MKB5");
                        param.StatusUsuarios.Add(stUsu1);
                    }
                    if (param.st_in_notavel == true)
                    {
                        StatusUsuario stUsu2 = new StatusUsuario();
                        stUsu2 = statusService.GetByCdSap("INCN");
                        param.StatusUsuarios.Add(stUsu2);
                    }
                    if (param.st_fumaca == true)
                    {
                        StatusUsuario stUsu3 = new StatusUsuario();
                        stUsu3 = statusService.GetByCdSap("FUMA");
                        param.StatusUsuarios.Add(stUsu3);
                    }
                    if (param.st_reboque == true)
                    {
                        StatusUsuario stUsu4 = new StatusUsuario();
                        stUsu4 = statusService.GetByCdSap("REBQ");
                        param.StatusUsuarios.Add(stUsu4);
                    }


                    context.NotaRepository.Add(param);
                    context.SaveChanges();


                    MedidaNota medidaNota = new MedidaNota();
                    medidaNota.id_nota_fk = param.id_nota;
                    medidaNota.id_st_usuario_fk = stAber.id_st_usuario;
                    medidaNota.sq_medida_nota = 1;
                    medidaNota.dt_hora_medida_nota = DateTime.Now;
                    medidaNota.id_empregado_fk = null; //empregado logado (falta implementar)
                    medidaNota.id_empregado_responsavel_fk = null; // Para este caso é null
                    medidaNota.id_cent_trab_responsavel_fk = param.id_centro_trabalho_fk;
                    medidaNota.fn_responsavel = "ZA";


                    StatusMedida stMed = new StatusMedidaService().GetByCdSap("LIBE");

                    medidaNota.id_st_medida_fk = stMed.id_st_medida;
                    Code cod = new CodeService().GetByCdSap("ABER");
                    medidaNota.id_code_tx_fk = cod.id_code;

                    MedidaNotaService medidaNtServices = new MedidaNotaService(this.context);
                    medidaNtServices.Add(medidaNota);

                    //context.SaveChanges();

                    dbContextTransaction.Commit();

                    param.BaseModel.Erro = false;
                    param.BaseModel.Retorno = MessageType.Success;
                    param.BaseModel.MensagemUsuario = Mensagens.MSG04.Replace("[#1]", param.cd_nota_sap.ToString());
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();

                    param.BaseModel.Erro = true;
                    param.BaseModel.Retorno = MessageType.Error;
                    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException = e;
                    Console.Write("Erro");
                }

            }



            return param;
        }

        public Nota CancelarMC(int id, string motivo)
        {


            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    Nota dbNota = this.GetNotaStatusUsuarioById(id);

                    MedidaNota ultMed = context.MedidaNotaRepository.AsQueryable().Where(x => x.id_nota_fk == id).OrderByDescending(x => x.id_medida_nota).First();
                    int idUltSt = ultMed.id_st_usuario_fk.GetValueOrDefault();


                    StatusUsuario stUsu = context.StatusUsuarioRepository.AsQueryable().Where(x => x.id_st_usuario == idUltSt).First();

                    if (dbNota.StatusUsuarios.Count(x => x.cd_sap == stUsu.cd_sap) > 0)
                    {
                        dbNota.StatusUsuarios.Remove(stUsu);
                    }

                    StatusUsuario stCanc = context.StatusUsuarioRepository.AsQueryable().Where(x => x.cd_sap == "CANC").First();
                    dbNota.StatusUsuarios.Add(stCanc);
                    StatusSistema stSis = context.StatusSistemaRepository.AsQueryable().Where(x => x.cd_sap == "MSEN").First();
                    dbNota.id_st_sistema_fk = stSis.id_st_sistema;

                    context.NotaRepository.Update(dbNota);

                    StatusMedida stMedida = context.StatusMedidaRepository.AsQueryable().Where(x => x.cd_sap == "ENCE").First();
                    ultMed.id_st_medida_fk = stMedida.id_st_medida;

                    context.MedidaNotaRepository.Update(ultMed);

                    MedidaNota novMed = new MedidaNota();
                    novMed.id_nota_fk = id;
                    Code code = context.CodeRepository.AsQueryable().Where(x => x.cd_sap == "CANC").First();
                    novMed.id_code_tx_fk = code.id_code;
                    novMed.dt_hora_medida_nota = DateTime.Now;
                    novMed.id_st_usuario_fk = stCanc.id_st_usuario;
                    novMed.id_st_medida_fk = stMedida.id_st_medida;
                    novMed.ds_motivo = motivo;
                    novMed.sq_medida_nota = ultMed.sq_medida_nota + 1;

                    context.MedidaNotaRepository.Add(novMed);
                    context.SaveChanges();

                    dbContextTransaction.Commit();

                    dbNota.BaseModel.Erro = false;
                    dbNota.BaseModel.Retorno = MessageType.Success;
                    dbNota.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;

                    return dbNota;
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();

                    Nota erroNota = new Nota();
                    erroNota.BaseModel.Erro = true;
                    erroNota.BaseModel.Retorno = MessageType.Error;
                    erroNota.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    erroNota.BaseModel.MensagemException = e;
                    Console.Write("Erro");
                    return erroNota;
                }
            }


        }

        public Nota EditarMC(Nota param)
        {


            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {

                try
                {
                    StatusUsuarioService statusService = new StatusUsuarioService(this.context);
                    param.StatusUsuarios = new List<StatusUsuario>();




                    Nota dbNota = this.GetNotaStatusUsuarioById(param.id_nota);
                    dbNota.id_local_inst_fk = param.id_local_inst_fk;
                    dbNota.id_code_sintoma_fk = param.id_code_sintoma_fk;
                    dbNota.ds_descricao = param.ds_descricao;
                    dbNota.id_prioridade_fk = param.id_prioridade_fk;
                    //dbNota.rg_notificador = param.rg_notificador;
                    dbNota.id_notificador_fk = param.id_notificador_fk;
                    dbNota.sg_local = param.sg_local;
                    dbNota.id_centro_trabalho_fk = param.id_centro_trabalho_fk;
                    dbNota.ds_observacao = param.ds_observacao;
                    dbNota.st_if_oper_maior_cinco_min = param.st_if_oper_maior_cinco_min;
                    dbNota.st_in_notavel = param.st_in_notavel;
                    dbNota.st_fumaca = param.st_fumaca;
                    dbNota.st_reboque = param.st_reboque;


                    if (dbNota.st_if_oper_maior_cinco_min == true)
                    {
                        StatusUsuario stUsu1 = new StatusUsuario();
                        stUsu1 = statusService.GetByCdSap("MKB5");

                        if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu1.id_st_usuario) <= 0)
                            dbNota.StatusUsuarios.Add(stUsu1);
                    }
                    else
                    {
                        StatusUsuario stUsu1 = new StatusUsuario();
                        stUsu1 = statusService.GetByCdSap("MKB5");

                        if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu1.id_st_usuario) > 0)
                            dbNota.StatusUsuarios.Remove(stUsu1);
                    }


                    if (dbNota.st_in_notavel == true)
                    {
                        StatusUsuario stUsu2 = new StatusUsuario();
                        stUsu2 = statusService.GetByCdSap("INCN");

                        if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu2.id_st_usuario) <= 0)
                            dbNota.StatusUsuarios.Add(stUsu2);
                    }
                    else
                    {
                        StatusUsuario stUsu2 = new StatusUsuario();
                        stUsu2 = statusService.GetByCdSap("INCN");

                        if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu2.id_st_usuario) > 0)
                            dbNota.StatusUsuarios.Remove(stUsu2);
                    }


                    if (dbNota.st_fumaca == true)
                    {
                        StatusUsuario stUsu3 = new StatusUsuario();
                        stUsu3 = statusService.GetByCdSap("FUMA");

                        if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu3.id_st_usuario) <= 0)
                            dbNota.StatusUsuarios.Add(stUsu3);
                    }
                    else
                    {
                        StatusUsuario stUsu3 = new StatusUsuario();
                        stUsu3 = statusService.GetByCdSap("FUMA");

                        if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu3.id_st_usuario) > 0)
                            dbNota.StatusUsuarios.Remove(stUsu3);
                    }


                    if (dbNota.st_reboque == true)
                    {
                        StatusUsuario stUsu4 = new StatusUsuario();
                        stUsu4 = statusService.GetByCdSap("REBQ");

                        if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu4.id_st_usuario) <= 0)
                            dbNota.StatusUsuarios.Add(stUsu4);
                    }
                    else
                    {
                        StatusUsuario stUsu4 = new StatusUsuario();
                        stUsu4 = statusService.GetByCdSap("REBQ");

                        if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu4.id_st_usuario) > 0)
                            dbNota.StatusUsuarios.Remove(stUsu4);
                    }


                    context.NotaRepository.Update(dbNota);

                    context.SaveChanges();
                    dbContextTransaction.Commit();

                    param.BaseModel.Erro = false;
                    param.BaseModel.Retorno = MessageType.Success;
                    param.BaseModel.MensagemUsuario = Mensagens.MSG08;
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();

                    param.BaseModel.Erro = true;
                    param.BaseModel.Retorno = MessageType.Error;
                    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException = e;
                    Console.Write("Erro");
                }
            }




            return param;
        }
        #endregion

        #region NotaMD
        public Nota CriarMD(Nota param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    TipoNotaService tpnotaServices = new TipoNotaService(this.context);
                    TipoNota tipoNota = tpnotaServices.GetByCodigoSap("MD");
                    param.id_tp_nota_fk = tipoNota.id_tp_nota;

                    //temporario gera codigo sap temporario
                    string cdNotaSAP = DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.ToShortTimeString().Replace(":", "");
                    param.cd_nota_sap = cdNotaSAP;

                    StatusSistema stSistema = new StatusSistema();
                    StatusSistemaService stSistemaService = new StatusSistemaService(this.context);
                    stSistema = stSistemaService.GetByCdSap("MSPN");
                    param.id_st_sistema_fk = stSistema.id_st_sistema;

                    StatusUsuarioService statusService = new StatusUsuarioService(this.context);
                    param.StatusUsuarios = new List<StatusUsuario>();

                    StatusUsuario stAber = new StatusUsuario();
                    stAber = statusService.GetByCdSap("ABER");
                    param.StatusUsuarios.Add(stAber);
                    context.NotaRepository.Add(param);
                    context.SaveChanges();

                    StatusMedidaService statusMedidaService = new StatusMedidaService(this.context);
                    StatusMedida stMed = statusMedidaService.GetByCdSap("ABER");

                    CodeService codeService = new CodeService();
                    Code cod = codeService.GetByCdSap("ABER");

                    MedidaNota medidaNota = new MedidaNota();
                    medidaNota.id_nota_fk = param.id_nota;
                    medidaNota.sq_medida_nota = 1;
                    medidaNota.dt_hora_medida_nota = DateTime.Now;
                    medidaNota.id_empregado_fk = null;              //empregado logado (falta implementar)
                    medidaNota.id_empregado_responsavel_fk = null; // Para este caso é null
                    medidaNota.id_st_usuario_fk = stAber.id_st_usuario;

                    if (param.id_centro_trabalho_fk > 0)
                        medidaNota.id_cent_trab_responsavel_fk = param.id_centro_trabalho_fk;

                    medidaNota.fn_responsavel = "ZA";
                    medidaNota.id_st_medida_fk = stMed.id_st_medida;
                    medidaNota.id_code_tx_fk = cod.id_code;
                    context.MedidaNotaRepository.Add(medidaNota);
                    //context.NotaRepository.Add(param);
                    context.SaveChanges();

                    dbContextTransaction.Commit();

                    param.BaseModel.Erro = false;
                    param.BaseModel.Retorno = MessageType.Success;
                    param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    param.BaseModel.Erro = true;
                    param.BaseModel.Retorno = MessageType.Error;
                    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException = e;
                    Console.Write("Erro");
                }

            }
            return param;
        }

        public Nota CancelarMD(int id, string motivo)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    Nota dbNota = this.GetNotaStatusUsuarioById(id);

                    MedidaNota ultMed = context.MedidaNotaRepository.AsQueryable().Where(x => x.id_nota_fk == id).OrderByDescending(x => x.id_medida_nota).First();
                    int idUltSt = ultMed.id_st_usuario_fk.GetValueOrDefault();

                    StatusUsuario stUsu = context.StatusUsuarioRepository.AsQueryable().Where(x => x.id_st_usuario == idUltSt).First();

                    if (dbNota.StatusUsuarios.Count(x => x.cd_sap == stUsu.cd_sap) > 0)
                    {
                        dbNota.StatusUsuarios.Remove(stUsu);
                    }

                    StatusUsuario stCanc = context.StatusUsuarioRepository.AsQueryable().Where(x => x.cd_sap == "CANC").First();
                    dbNota.StatusUsuarios.Add(stCanc);
                    StatusSistema stSis = context.StatusSistemaRepository.AsQueryable().Where(x => x.cd_sap == "MSEN").First();
                    dbNota.id_st_sistema_fk = stSis.id_st_sistema;

                    context.NotaRepository.Update(dbNota);

                    StatusMedida stMedida = context.StatusMedidaRepository.AsQueryable().Where(x => x.cd_sap == "ENCE").First();
                    ultMed.id_st_medida_fk = stMedida.id_st_medida;

                    context.MedidaNotaRepository.Update(ultMed);

                    MedidaNota novMed = new MedidaNota();
                    novMed.id_nota_fk = id;
                    Code code = context.CodeRepository.AsQueryable().Where(x => x.cd_sap == "CANC").First();
                    novMed.id_code_tx_fk = code.id_code;
                    novMed.dt_hora_medida_nota = DateTime.Now;
                    novMed.id_st_usuario_fk = stCanc.id_st_usuario;
                    novMed.id_st_medida_fk = stMedida.id_st_medida;
                    novMed.ds_motivo = motivo;

                    context.MedidaNotaRepository.Add(novMed);
                    context.SaveChanges();

                    dbContextTransaction.Commit();

                    dbNota.BaseModel.Erro = false;
                    dbNota.BaseModel.Retorno = MessageType.Success;
                    dbNota.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;

                    return dbNota;
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();

                    Nota erroNota = new Nota();
                    erroNota.BaseModel.Erro = true;
                    erroNota.BaseModel.Retorno = MessageType.Error;
                    erroNota.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    erroNota.BaseModel.MensagemException = e;
                    Console.Write("Erro");
                    return erroNota;
                }
            }


        }

        public Nota EditarMD(Nota param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    StatusUsuarioService statusService = new StatusUsuarioService(this.context);
                    param.StatusUsuarios = new List<StatusUsuario>();

                    Nota dbNota = this.GetNotaStatusUsuarioById(param.id_nota);
                    dbNota.id_local_inst_fk = param.id_local_inst_fk;
                    //dbNota.id_code_sintoma_fk = param.id_code_sintoma_fk;
                    dbNota.ds_descricao = param.ds_descricao;
                    //dbNota.id_prioridade_fk = param.id_prioridade_fk;
                    //dbNota.rg_notificador = param.rg_notificador;
                    dbNota.id_notificador_fk = param.id_notificador_fk;
                    //dbNota.sg_local = param.sg_local;
                    dbNota.id_centro_trabalho_fk = param.id_centro_trabalho_fk;
                    dbNota.ds_observacao = param.ds_observacao;
                    //dbNota.st_if_oper_maior_cinco_min = param.st_if_oper_maior_cinco_min;
                    //dbNota.st_in_notavel = param.st_in_notavel;
                    //dbNota.st_fumaca = param.st_fumaca;
                    //dbNota.st_reboque = param.st_reboque;

                    StatusUsuario stUsu = new StatusUsuario();
                    stUsu = statusService.GetByCdSap("ABER");
                    dbNota.StatusUsuarios.Add(stUsu);



                    //if (dbNota.st_if_oper_maior_cinco_min == true)
                    //{
                    //    StatusUsuario stUsu1 = new StatusUsuario();
                    //    stUsu1 = statusService.GetByCdSap("MKB5");

                    //    if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu1.id_st_usuario) <= 0)
                    //        dbNota.StatusUsuarios.Add(stUsu1);
                    //}
                    //else
                    //{
                    //    StatusUsuario stUsu1 = new StatusUsuario();
                    //    stUsu1 = statusService.GetByCdSap("MKB5");

                    //    if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu1.id_st_usuario) > 0)
                    //        dbNota.StatusUsuarios.Remove(stUsu1);
                    //}


                    //if (dbNota.st_in_notavel == true)
                    //{
                    //    StatusUsuario stUsu2 = new StatusUsuario();
                    //    stUsu2 = statusService.GetByCdSap("INCN");

                    //    if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu2.id_st_usuario) <= 0)
                    //        dbNota.StatusUsuarios.Add(stUsu2);
                    //}
                    //else
                    //{
                    //    StatusUsuario stUsu2 = new StatusUsuario();
                    //    stUsu2 = statusService.GetByCdSap("INCN");

                    //    if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu2.id_st_usuario) > 0)
                    //        dbNota.StatusUsuarios.Remove(stUsu2);
                    //}


                    //if (dbNota.st_fumaca == true)
                    //{
                    //    StatusUsuario stUsu3 = new StatusUsuario();
                    //    stUsu3 = statusService.GetByCdSap("FUMA");

                    //    if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu3.id_st_usuario) <= 0)
                    //        dbNota.StatusUsuarios.Add(stUsu3);
                    //}
                    //else
                    //{
                    //    StatusUsuario stUsu3 = new StatusUsuario();
                    //    stUsu3 = statusService.GetByCdSap("FUMA");

                    //    if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu3.id_st_usuario) > 0)
                    //        dbNota.StatusUsuarios.Remove(stUsu3);
                    //}


                    //if (dbNota.st_reboque == true)
                    //{
                    //    StatusUsuario stUsu4 = new StatusUsuario();
                    //    stUsu4 = statusService.GetByCdSap("REBQ");

                    //    if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu4.id_st_usuario) <= 0)
                    //        dbNota.StatusUsuarios.Add(stUsu4);
                    //}
                    //else
                    //{
                    //    StatusUsuario stUsu4 = new StatusUsuario();
                    //    stUsu4 = statusService.GetByCdSap("REBQ");

                    //    if (dbNota.StatusUsuarios.Count(x => x.id_st_usuario == stUsu4.id_st_usuario) > 0)
                    //        dbNota.StatusUsuarios.Remove(stUsu4);
                    //}


                    context.NotaRepository.Update(dbNota);

                    context.SaveChanges();
                    dbContextTransaction.Commit();

                    param.BaseModel.Erro = false;
                    param.BaseModel.Retorno = MessageType.Success;
                    param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();

                    param.BaseModel.Erro = true;
                    param.BaseModel.Retorno = MessageType.Error;
                    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException = e;
                    Console.Write("Erro");
                }
            }
            return param;
        }
        #endregion

        #region NotaMS
        public Nota CriarMS(Nota param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    TipoNotaService tpnotaServices = new TipoNotaService(this.context);
                    TipoNota tipoNota = tpnotaServices.GetByCodigoSap("MS");
                    param.id_tp_nota_fk = tipoNota.id_tp_nota;

                    StatusSistema stSistema = new StatusSistema();
                    StatusSistemaService stSistemaService = new StatusSistemaService(this.context);
                    stSistema = stSistemaService.GetByCdSap("MSPN");
                    param.id_st_sistema_fk = stSistema.id_st_sistema;

                    StatusUsuarioService statusService = new StatusUsuarioService(this.context);
                    param.StatusUsuarios = new List<StatusUsuario>();

                    StatusUsuario stAber = new StatusUsuario();
                    stAber = statusService.GetByCdSap("ABER");
                    param.StatusUsuarios.Add(stAber);

                    context.NotaRepository.Add(param);
                    context.SaveChanges();

                    MedidaNota medidaNota = new MedidaNota();
                    medidaNota.id_nota_fk = param.id_nota;
                    medidaNota.id_st_usuario_fk = stAber.id_st_usuario;
                    medidaNota.sq_medida_nota = 1;
                    medidaNota.dt_hora_medida_nota = DateTime.Now;
                    medidaNota.id_empregado_fk = null; //empregado logado (falta implementar)
                    medidaNota.id_empregado_responsavel_fk = null; // Para este caso é null
                    medidaNota.id_cent_trab_responsavel_fk = param.id_centro_trabalho_fk;
                    medidaNota.fn_responsavel = "ZA";

                    StatusMedida stMed = new StatusMedidaService().GetByCdSap("LIBE");

                    medidaNota.id_st_medida_fk = stMed.id_st_medida;
                    Code cod = new CodeService().GetByCdSap("ABER");
                    medidaNota.id_code_tx_fk = cod.id_code;

                    MedidaNotaService medidaNtServices = new MedidaNotaService(this.context);
                    medidaNtServices.Add(medidaNota);

                    dbContextTransaction.Commit();

                    param.BaseModel.Erro = false;
                    param.BaseModel.Retorno = MessageType.Success;
                    param.BaseModel.MensagemUsuario = Mensagens.MSG04.Replace("[#1]", param.cd_nota_sap.ToString());
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();

                    param.BaseModel.Erro = true;
                    param.BaseModel.Retorno = MessageType.Error;
                    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException = e;
                    Console.Write("Erro");
                }
            }

            return param;
        }

        public Nota EditarMS(Nota param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    StatusUsuarioService statusService = new StatusUsuarioService(this.context);
                    param.StatusUsuarios = new List<StatusUsuario>();
                    Nota dbNota = this.GetNotaStatusUsuarioById(param.id_nota);
                    dbNota.id_local_inst_fk = param.id_local_inst_fk;
                    dbNota.id_code_tp_servico_fk = param.id_code_tp_servico_fk;
                    dbNota.ds_descricao = param.ds_descricao;
                    dbNota.id_solicitante_fk = param.id_solicitante_fk;
                    dbNota.id_linha_fk = param.id_linha_fk;
                    dbNota.id_centro_trabalho_fk = param.id_centro_trabalho_fk;
                    dbNota.dt_hora_programada = param.dt_hora_programada;
                    dbNota.ds_observacao = param.ds_observacao;

                    context.NotaRepository.Update(dbNota);

                    context.SaveChanges();
                    dbContextTransaction.Commit();

                    param.BaseModel.Erro = false;
                    param.BaseModel.Retorno = MessageType.Success;
                    param.BaseModel.MensagemUsuario = Mensagens.MSG08;
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();

                    param.BaseModel.Erro = true;
                    param.BaseModel.Retorno = MessageType.Error;
                    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException = e;
                    Console.Write("Erro");
                }
            }

            return param;
        }
        #endregion

    }
}