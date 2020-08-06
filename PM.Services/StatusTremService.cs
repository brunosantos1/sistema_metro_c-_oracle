using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class StatusTremService
    {
        private DatabaseContext context;

        public StatusTremService()
        {
            context = new DatabaseContext();
        }
        public StatusTremService(DatabaseContext dbcontext)
        {
            context = dbcontext;
        }

        public StatusTrem GetByID(int id)
        {
            return context.StatusTremRepository.GetById(id);
        }

        public List<StatusTrem> GetAll()
        {
            return context.StatusTremRepository.GetAll();
        }

        public StatusTrem Delete(StatusTrem obj)
        {
            StatusTrem StatusTrem = new StatusTrem();
            StatusTrem.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                StatusTrem = context.StatusTremRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    StatusTrem.BaseModel.Retorno = MessageType.Success;
                    StatusTrem.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    StatusTrem.BaseModel.Erro = true;
                }
                else
                {
                    StatusTrem.BaseModel.Retorno = MessageType.Warning;
                    StatusTrem.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    StatusTrem.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    StatusTrem.BaseModel.Retorno = MessageType.Error;
                }

                StatusTrem.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                StatusTrem.BaseModel.MensagemException = e;
            }

            return StatusTrem;
        }

        public StatusTrem Add(StatusTrem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusTremRepository.Add(param);
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

        public StatusTrem Update(StatusTrem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusTremRepository.Update(param);
                param.BaseModel.MensagemUsuario = Mensagens.Registro_Atualizado;
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
