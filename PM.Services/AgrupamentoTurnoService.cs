using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class AgrupamentoTurnoService
    {
        private DatabaseContext context;

        public AgrupamentoTurnoService()
        {
            context = new DatabaseContext();
        }

        public AgrupamentoTurno GetByID(int id)
        {
            return context.AgrupamentoTurnoRepository.GetById(id);
        }

        public List<AgrupamentoTurno> GetAll()
        {
            return context.AgrupamentoTurnoRepository.GetAll();
        }

        public AgrupamentoTurno Delete(AgrupamentoTurno obj)
        {
            AgrupamentoTurno AgrupamentoTurno = new AgrupamentoTurno();
            AgrupamentoTurno.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                AgrupamentoTurno = context.AgrupamentoTurnoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    AgrupamentoTurno.BaseModel.Retorno = MessageType.Success;
                    AgrupamentoTurno.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    AgrupamentoTurno.BaseModel.Erro = true;
                }
                else
                {
                    AgrupamentoTurno.BaseModel.Retorno = MessageType.Warning;
                    AgrupamentoTurno.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    AgrupamentoTurno.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    AgrupamentoTurno.BaseModel.Retorno = MessageType.Error;
                }

                AgrupamentoTurno.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                AgrupamentoTurno.BaseModel.MensagemException = e;
            }

            return AgrupamentoTurno;
        }

        public AgrupamentoTurno Add(AgrupamentoTurno param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.AgrupamentoTurnoRepository.Add(param);
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

        public AgrupamentoTurno Update(AgrupamentoTurno param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.AgrupamentoTurnoRepository.Add(param);
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
