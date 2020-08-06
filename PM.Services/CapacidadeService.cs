using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class CapacidadeService
    {
        private DatabaseContext context;

        public CapacidadeService()
        {
            context = new DatabaseContext();
        }

        public Capacidade GetByID(int id)
        {
            return context.CapacidadeRepository.GetById(id);
        }

        public List<Capacidade> GetAll()
        {
            return context.CapacidadeRepository.GetAll();
        }

        public Capacidade Delete(Capacidade obj)
        {
            Capacidade capacidade = new Capacidade();
            capacidade.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                capacidade = context.CapacidadeRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    capacidade.BaseModel.Retorno = MessageType.Success;
                    capacidade.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    capacidade.BaseModel.Erro = true;
                }
                else
                {
                    capacidade.BaseModel.Retorno = MessageType.Warning;
                    capacidade.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    capacidade.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    capacidade.BaseModel.Retorno = MessageType.Error;
                }

                capacidade.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                capacidade.BaseModel.MensagemException = e;
            }

            return capacidade;
        }

        public Capacidade Add(Capacidade param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CapacidadeRepository.Add(param);
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

        public Capacidade Update(Capacidade param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CapacidadeRepository.Add(param);
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
