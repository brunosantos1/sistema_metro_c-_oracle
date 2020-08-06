using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class StatusCopeseService
    {
        private DatabaseContext context;

        public StatusCopeseService()
        {
            context = new DatabaseContext();
        }

        public StatusCopese GetByID(int id)
        {
            return context.StatusCopeseRepository.GetById(id);
        }

        public List<StatusCopese> GetAll()
        {
            return context.StatusCopeseRepository.GetAll();
        }

        public StatusCopese Delete(StatusCopese obj)
        {
            StatusCopese statusCopese = new StatusCopese();
            statusCopese.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                statusCopese = context.StatusCopeseRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    statusCopese.BaseModel.Retorno = MessageType.Success;
                    statusCopese.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    statusCopese.BaseModel.Erro = true;
                }
                else
                {
                    statusCopese.BaseModel.Retorno = MessageType.Warning;
                    statusCopese.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    statusCopese.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    statusCopese.BaseModel.Retorno = MessageType.Error;
                }

                statusCopese.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                statusCopese.BaseModel.MensagemException = e;
            }

            return statusCopese;
        }

        public StatusCopese Add(StatusCopese param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusCopeseRepository.Add(param);
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

        public StatusCopese Update(StatusCopese param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusCopeseRepository.Add(param);
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
