using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PM.Services
{
    public class LocalInstalacaoService
    {
        private DatabaseContext context;

        public LocalInstalacaoService()
        {
            context = new DatabaseContext();
        }

        public LocalInstalacao GetByID(int id)
        {
            return context.LocalInstalacaoRepository.GetById(id);
        }

        public List<LocalInstalacao> GetAll()
        {
            return context.LocalInstalacaoRepository.GetAll();
        }

        public List<LocalInstalacao> ConsultarLCParametros(LocalInstalacao localInstalacao)
        {
            if (localInstalacao.id_sistema_fk > 0 || localInstalacao.id_complemento_fk > 0 || localInstalacao.id_frota_fk > 0 || localInstalacao.id_trem_fk > 0 || localInstalacao.id_carro_fk > 0 || localInstalacao.id_linha_fk > 0 || localInstalacao.id_zona_fk > 0)
            {
                var parameterExpression = Expression.Parameter(typeof(LocalInstalacao), "e");
                #region IdLocalInstalacao
                localInstalacao.id_lc_instalacao = 0;
                var constantIdLocalInstalacao = Expression.Constant(localInstalacao.id_lc_instalacao);
                var propertyIdLocalInstalacao = Expression.Property(parameterExpression, "id_lc_instalacao");
                var expressionIdLocalInstalacao = Expression.GreaterThan(propertyIdLocalInstalacao, constantIdLocalInstalacao);
                Expression expression = Expression.And(expressionIdLocalInstalacao, expressionIdLocalInstalacao);
                #endregion

                #region IdSistemaFk
                if (localInstalacao.id_sistema_fk > 0)
                {
                    var constantIdSistemaFk = Expression.Constant(localInstalacao.id_sistema_fk);
                    var propertyIdSistemaFk = Expression.Property(parameterExpression, "id_sistema_fk");
                    var propertyIdSistemaFkConverted = Expression.Convert(propertyIdSistemaFk, localInstalacao.id_sistema_fk.GetType());
                    var expressionIdSistemaFk = Expression.Equal(propertyIdSistemaFkConverted, constantIdSistemaFk);
                    expression = Expression.And(expression, expressionIdSistemaFk);
                }
                #endregion

                #region IdComplementoFk
                if (localInstalacao.id_complemento_fk > 0)
                {
                    var constantIdComplementoFk = Expression.Constant(localInstalacao.id_complemento_fk);
                    var propertyIdComplementoFk = Expression.Property(parameterExpression, "id_complemento_fk");
                    var propertyIdComplementoFkConverted = Expression.Convert(propertyIdComplementoFk, localInstalacao.id_complemento_fk.GetType());
                    var expressionIdComplementoFk = Expression.Equal(propertyIdComplementoFkConverted, constantIdComplementoFk);
                    expression = Expression.And(expression, expressionIdComplementoFk);
                }
                #endregion

                #region IdFrotaFk
                if (localInstalacao.id_frota_fk > 0)
                {
                    var constantIdFrotaFk = Expression.Constant(localInstalacao.id_frota_fk);
                    var propertyIdFrotaFk = Expression.Property(parameterExpression, "id_frota_fk");
                    var propertyIdFrotaFkConverted = Expression.Convert(propertyIdFrotaFk, localInstalacao.id_frota_fk.GetType());
                    var expressionIdFrotaFk = Expression.Equal(propertyIdFrotaFkConverted, constantIdFrotaFk);
                    expression = Expression.And(expression, expressionIdFrotaFk);
                }
                #endregion

                #region IdTremFk
                if (localInstalacao.id_trem_fk > 0)
                {
                    var constantIdTremFk = Expression.Constant(localInstalacao.id_trem_fk);
                    var propertyIdTremFk = Expression.Property(parameterExpression, "id_trem_fk");
                    var propertyIdTremFkConverted = Expression.Convert(propertyIdTremFk, localInstalacao.id_trem_fk.GetType());
                    var expressionIdTremFk = Expression.Equal(propertyIdTremFkConverted, constantIdTremFk);
                    expression = Expression.And(expression, expressionIdTremFk);
                }
                #endregion

                #region IdCarroFk
                if (localInstalacao.id_carro_fk > 0)
                {
                    var constantIdCarroFk = Expression.Constant(localInstalacao.id_carro_fk);
                    var propertyIdCarroFk = Expression.Property(parameterExpression, "id_carro_fk");
                    var propertyIdCarroFkConverted = Expression.Convert(propertyIdCarroFk, localInstalacao.id_carro_fk.GetType());
                    var expressionIdCarroFk = Expression.Equal(propertyIdCarroFkConverted, constantIdCarroFk);
                    expression = Expression.And(expression, expressionIdCarroFk);
                }
                #endregion

                #region IdLinhaFk
                if (localInstalacao.id_linha_fk > 0)
                {
                    var constantIdLinhaFk = Expression.Constant(localInstalacao.id_linha_fk);
                    var propertyIdLinhaFk = Expression.Property(parameterExpression, "id_linha_fk");
                    var propertyIdLinhaFkConverted = Expression.Convert(propertyIdLinhaFk, localInstalacao.id_linha_fk.GetType());
                    var expressionIdLinhaFk = Expression.Equal(propertyIdLinhaFkConverted, constantIdLinhaFk);
                    expression = Expression.And(expression, expressionIdLinhaFk);
                }
                #endregion

                #region IdZonaFk
                if (localInstalacao.id_zona_fk > 0)
                {
                    var constantIdZonaFk = Expression.Constant(localInstalacao.id_zona_fk);
                    var propertyIdZonaFk = Expression.Property(parameterExpression, "id_zona_fk");
                    var propertyIdZonaFkConverted = Expression.Convert(propertyIdZonaFk, localInstalacao.id_zona_fk.GetType());
                    var expressionIdZonaFk = Expression.Equal(propertyIdZonaFkConverted, constantIdZonaFk);
                    expression = Expression.And(expression, expressionIdZonaFk);
                }
                #endregion


                var lambda = Expression.Lambda<Func<LocalInstalacao, bool>>(expression, parameterExpression);
                var compiledLambda = lambda.Compile();

                var lcRetorno = context.LocalInstalacaoRepository.AsQueryable().Where(lambda)
                    .ToList();
                return lcRetorno;
            }
            else return new List<LocalInstalacao>();
        }

        public List<LocalInstalacao> Search(int idFrota, int idTrem, int idCarro)
        {
            //Mudança de regra de negócio, sistema precisa ser nulo
            List<LocalInstalacao> locais = context.LocalInstalacaoRepository.Find(x => (x.id_frota_fk == idFrota && x.id_trem_fk == idTrem && x.id_carro_fk == idCarro && x.id_sistema_fk == null));
            return locais;
        }

        public List<LocalInstalacao> SearchMS(int idFrota, int idTrem, int idCarro, int idSistema, int? idComplemento, int? idPosicao)
        {
            //Mudança de regra de negócio, sistema precisa ser nulo
            List<LocalInstalacao> locais = context.LocalInstalacaoRepository.Find(x => (x.id_frota_fk == idFrota && x.id_trem_fk == idTrem && x.id_carro_fk == idCarro && x.id_sistema_fk == idSistema && x.id_complemento_fk == idComplemento && x.id_posicao_fk == idPosicao));
            return locais;
        }

        public List<LocalInstalacao> Search1(int idFrota, int idTrem, int idCarro, int idLinha)
        {
            //Mudança de regra de negócio, sistema precisa ser nulo
            List<LocalInstalacao> locais = context.LocalInstalacaoRepository.Find(x => (x.id_frota_fk == idFrota && x.id_trem_fk == idTrem && x.id_carro_fk == idCarro && x.id_linha_fk == idLinha && x.id_sistema_fk == null));
            return locais;
        }

        public List<LocalInstalacao> Search3(int idFrota, int idTrem, int idCarro, int idLinha, int idSistema, int idComplemento, int idPosicao)
        {
            //Mudança de regra de negócio, sistema precisa ser nulo
            List<LocalInstalacao> locais = context.LocalInstalacaoRepository.Find(x => (x.id_frota_fk == idFrota && x.id_trem_fk == idTrem && x.id_carro_fk == idCarro && x.id_linha_fk == idLinha && x.id_sistema_fk == idSistema && x.id_complemento_fk == idComplemento && x.id_posicao_fk == idPosicao));
            return locais;
        }

        public List<LocalInstalacao> Search4(int idFrota, int idTrem, int idCarro, int idSistema, int idComplemento, int idPosicao)
        {
            //Mudança de regra de negócio, sistema precisa ser nulo
            List<LocalInstalacao> locais = context.LocalInstalacaoRepository.Find(x => (x.id_frota_fk == idFrota && x.id_trem_fk == idTrem && x.id_carro_fk == idCarro && x.id_sistema_fk == idSistema && x.id_complemento_fk == idComplemento && x.id_posicao_fk == idPosicao));
            return locais;
        }

        public LocalInstalacao Delete(LocalInstalacao obj)
        {
            LocalInstalacao localInstalacao = new LocalInstalacao();
            localInstalacao.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                localInstalacao = context.LocalInstalacaoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    localInstalacao.BaseModel.Retorno = MessageType.Success;
                    localInstalacao.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    localInstalacao.BaseModel.Erro = true;
                }
                else
                {
                    localInstalacao.BaseModel.Retorno = MessageType.Warning;
                    localInstalacao.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    localInstalacao.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    localInstalacao.BaseModel.Retorno = MessageType.Error;
                }

                localInstalacao.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                localInstalacao.BaseModel.MensagemException = e;
            }

            return localInstalacao;
        }

        public LocalInstalacao Add(LocalInstalacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.LocalInstalacaoRepository.Add(param);
                param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.Erro = true;
            }
            catch (Exception e)
            {
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
            }

            return param;
        }

        public LocalInstalacao Update(LocalInstalacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.LocalInstalacaoRepository.Add(param);
                param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.Erro = true;
            }
            catch (Exception e)
            {
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
            }

            return param;
        }
    }
}
