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
    public class EquipamentoService
    {
        private DatabaseContext context;

        public EquipamentoService()
        {
            context = new DatabaseContext();
        }
        public List<Equipamento> ConsultarEFParametros(Equipamento equipamento)
        {
            //if (equipamento.id_linha_fk > 0 || equipamento.id_zona_fk > 0)
            //{
                var parameterExpression = Expression.Parameter(typeof(Equipamento), "e");
                #region IdEquipamento
                equipamento.id_equipamento = 0;
                var constantIdEquipamento = Expression.Constant(equipamento.id_equipamento);
                var propertyIdEquipamento = Expression.Property(parameterExpression, "id_equipamento");
                var expressionIdEquipamento = Expression.GreaterThan(propertyIdEquipamento, constantIdEquipamento);
                Expression expression = Expression.And(expressionIdEquipamento, expressionIdEquipamento);
                #endregion

                #region IdLinhaFk
                //if (equipamento.id_linha_fk > 0)
                //{
                //    var constantIdLinhaFk = Expression.Constant(equipamento.id_linha_fk);
                //    var propertyIdLinhaFk = Expression.Property(parameterExpression, "id_linha_fk");
                //    var propertyIdLinhaFkConverted = Expression.Convert(propertyIdLinhaFk, equipamento.id_linha_fk.GetType());
                //    var expressionIdLinhaFk = Expression.Equal(propertyIdLinhaFkConverted, constantIdLinhaFk);
                //    expression = Expression.And(expression, expressionIdLinhaFk);
                //}
                #endregion

                #region IdZonaFk
                //if (equipamento.id_zona_fk > 0)
                //{
                //    var constantIdZonaFk = Expression.Constant(equipamento.id_zona_fk);
                //    var propertyIdZonaFk = Expression.Property(parameterExpression, "id_zona_fk");
                //    var propertyIdZonaFkConverted = Expression.Convert(propertyIdZonaFk, equipamento.id_zona_fk.GetType());
                //    var expressionIdZonaFk = Expression.Equal(propertyIdZonaFkConverted, constantIdZonaFk);
                //    expression = Expression.And(expression, expressionIdZonaFk);
                //}
                #endregion

                var lambda = Expression.Lambda<Func<Equipamento, bool>>(expression, parameterExpression);
                var compiledLambda = lambda.Compile();

                var eqRetorno = context.EquipamentoRepository.AsQueryable().Where(lambda)
                    .ToList();
                return eqRetorno;
            //}
            //else return new List<Equipamento>();
        }

        public Equipamento GetByID(int id)
        {
            return context.EquipamentoRepository.GetById(id);
        }

        public List<Equipamento> GetAll()
        {
            return context.EquipamentoRepository.GetAll();
        }

        public Equipamento Delete(Equipamento obj)
        {
            Equipamento equipamento = new Equipamento();
            equipamento.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                equipamento = context.EquipamentoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    equipamento.BaseModel.Retorno = MessageType.Success;
                    equipamento.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    equipamento.BaseModel.Erro = true;
                }
                else
                {
                    equipamento.BaseModel.Retorno = MessageType.Warning;
                    equipamento.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    equipamento.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    equipamento.BaseModel.Retorno = MessageType.Error;
                }

                equipamento.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                equipamento.BaseModel.MensagemException = e;
            }

            return equipamento;
        }

        public Equipamento Add(Equipamento param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.EquipamentoRepository.Add(param);
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

        public Equipamento Update(Equipamento param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.EquipamentoRepository.Add(param);
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
