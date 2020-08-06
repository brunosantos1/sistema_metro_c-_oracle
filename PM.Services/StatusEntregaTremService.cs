using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class StatusEntregaTremService
    {
        private DatabaseContext context;

        public StatusEntregaTremService()
        {
            context = new DatabaseContext();
        }
        public StatusEntregaTremService(DatabaseContext dbcontext)
        {
            context = dbcontext;
        }

        public StatusEntregaTrem GetByID(int id)
        {
            return context.StatusEntregaTremRepository.GetById(id);
        }

        public List<StatusEntregaTrem> GetAll()
        {
            return context.StatusEntregaTremRepository.GetAll();
        }

        public StatusEntregaTrem Delete(StatusEntregaTrem obj)
        {
            StatusEntregaTrem StatusEntregaTrem = new StatusEntregaTrem();
            StatusEntregaTrem.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                StatusEntregaTrem = context.StatusEntregaTremRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    StatusEntregaTrem.BaseModel.Retorno = MessageType.Success;
                    StatusEntregaTrem.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    StatusEntregaTrem.BaseModel.Erro = true;
                }
                else
                {
                    StatusEntregaTrem.BaseModel.Retorno = MessageType.Warning;
                    StatusEntregaTrem.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    StatusEntregaTrem.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    StatusEntregaTrem.BaseModel.Retorno = MessageType.Error;
                }

                StatusEntregaTrem.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                StatusEntregaTrem.BaseModel.MensagemException = e;
            }

            return StatusEntregaTrem;
        }

        public StatusEntregaTrem Add(StatusEntregaTrem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusEntregaTremRepository.Add(param);
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

        public StatusEntregaTrem Update(StatusEntregaTrem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusEntregaTremRepository.Update(param);
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
