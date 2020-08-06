using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class UnidadeMedidaService
    {
        private DatabaseContext context;

        public UnidadeMedidaService()
        {
            context = new DatabaseContext();
        }

        public UnidadeMedida GetByID(int id)
        {
            return context.UnidadeMedidaRepository.GetById(id);
        }

        public List<UnidadeMedida> GetAll()
        {
            return context.UnidadeMedidaRepository.GetAll();
        }

        public UnidadeMedida Delete(UnidadeMedida obj)
        {
            UnidadeMedida unidadeMedida = new UnidadeMedida();
            unidadeMedida.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                unidadeMedida = context.UnidadeMedidaRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    unidadeMedida.BaseModel.Retorno = MessageType.Success;
                    unidadeMedida.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    unidadeMedida.BaseModel.Erro = true;
                }
                else
                {
                    unidadeMedida.BaseModel.Retorno = MessageType.Warning;
                    unidadeMedida.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    unidadeMedida.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    unidadeMedida.BaseModel.Retorno = MessageType.Error;
                }

                unidadeMedida.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                unidadeMedida.BaseModel.MensagemException = e;
            }

            return unidadeMedida;
        }

        public UnidadeMedida Add(UnidadeMedida param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.UnidadeMedidaRepository.Add(param);
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

        public UnidadeMedida Update(UnidadeMedida param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.UnidadeMedidaRepository.Add(param);
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
