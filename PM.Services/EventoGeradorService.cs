using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class EventoGeradorService
    {
        private DatabaseContext context;

        public EventoGeradorService()
        {
            context = new DatabaseContext();
        }

        public EventoGerador GetByID(int id)
        {
            return context.EventoGeradorRepository.GetById(id);
        }

        public List<EventoGerador> GetAll()
        {
            return context.EventoGeradorRepository.GetAll();
        }

        public EventoGerador Delete(EventoGerador obj)
        {
            EventoGerador eventoGerador = new EventoGerador();
            eventoGerador.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                eventoGerador = context.EventoGeradorRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    eventoGerador.BaseModel.Retorno = MessageType.Success;
                    eventoGerador.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    eventoGerador.BaseModel.Erro = true;
                }
                else
                {
                    eventoGerador.BaseModel.Retorno = MessageType.Warning;
                    eventoGerador.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    eventoGerador.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    eventoGerador.BaseModel.Retorno = MessageType.Error;
                }

                eventoGerador.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                eventoGerador.BaseModel.MensagemException = e;
            }

            return eventoGerador;
        }

        public EventoGerador Add(EventoGerador param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.EventoGeradorRepository.Add(param);
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

        public EventoGerador Update(EventoGerador param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.EventoGeradorRepository.Add(param);
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
