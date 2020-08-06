using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class StatusPericiaService
    {
        private DatabaseContext context;

        public StatusPericiaService()
        {
            context = new DatabaseContext();
        }

        public StatusPericia GetByID(int id)
        {
            return context.StatusPericiaRepository.GetById(id);
        }

        public List<StatusPericia> GetAll()
        {
            return context.StatusPericiaRepository.GetAll();
        }

        public StatusPericia Delete(StatusPericia obj)
        {
            StatusPericia statusPericia = new StatusPericia();
            statusPericia.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                statusPericia = context.StatusPericiaRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    statusPericia.BaseModel.Retorno = MessageType.Success;
                    statusPericia.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    statusPericia.BaseModel.Erro = true;
                }
                else
                {
                    statusPericia.BaseModel.Retorno = MessageType.Warning;
                    statusPericia.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    statusPericia.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    statusPericia.BaseModel.Retorno = MessageType.Error;
                }

                statusPericia.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                statusPericia.BaseModel.MensagemException = e;
            }

            return statusPericia;
        }

        public StatusPericia Add(StatusPericia param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusPericiaRepository.Add(param);
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

        public StatusPericia Update(StatusPericia param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusPericiaRepository.Add(param);
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
