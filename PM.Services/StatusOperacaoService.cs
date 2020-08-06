using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class StatusOperacaoService
    {
        private DatabaseContext context;

        public StatusOperacaoService()
        {
            context = new DatabaseContext();
        }

        public StatusOperacao GetByID(int id)
        {
            return context.StatusOperacaoRepository.GetById(id);
        }

        public List<StatusOperacao> GetAll()
        {
            return context.StatusOperacaoRepository.GetAll();
        }

        public StatusOperacao Delete(StatusOperacao obj)
        {
            StatusOperacao statusOperacao = new StatusOperacao();
            statusOperacao.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                statusOperacao = context.StatusOperacaoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    statusOperacao.BaseModel.Retorno = MessageType.Success;
                    statusOperacao.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    statusOperacao.BaseModel.Erro = true;
                }
                else
                {
                    statusOperacao.BaseModel.Retorno = MessageType.Warning;
                    statusOperacao.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    statusOperacao.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    statusOperacao.BaseModel.Retorno = MessageType.Error;
                }

                statusOperacao.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                statusOperacao.BaseModel.MensagemException = e;
            }

            return statusOperacao;
        }

        public StatusOperacao Add(StatusOperacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusOperacaoRepository.Add(param);
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

        public StatusOperacao Update(StatusOperacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusOperacaoRepository.Add(param);
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
