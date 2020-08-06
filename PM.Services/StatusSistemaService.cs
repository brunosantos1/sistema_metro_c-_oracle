using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class StatusSistemaService
    {
        private DatabaseContext context;

        public StatusSistemaService()
        {
            context = new DatabaseContext();
        }

        public StatusSistemaService(DatabaseContext dbContext)
        {
            context = dbContext;
        }

        public StatusSistema GetByID(int id)
        {
            return context.StatusSistemaRepository.GetById(id);
        }

        public List<StatusSistema> GetAll()
        {
            return context.StatusSistemaRepository.GetAll();
        }

        public StatusSistema Delete(StatusSistema obj)
        {
            StatusSistema statusSistema = new StatusSistema();
            statusSistema.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                statusSistema = context.StatusSistemaRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    statusSistema.BaseModel.Retorno = MessageType.Success;
                    statusSistema.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    statusSistema.BaseModel.Erro = true;
                }
                else
                {
                    statusSistema.BaseModel.Retorno = MessageType.Warning;
                    statusSistema.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    statusSistema.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    statusSistema.BaseModel.Retorno = MessageType.Error;
                }

                statusSistema.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                statusSistema.BaseModel.MensagemException = e;
            }

            return statusSistema;
        }

        public StatusSistema Add(StatusSistema param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusSistemaRepository.Add(param);
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

        public StatusSistema GetByCdSap(string cd)
        {
            List<StatusSistema> listst = context.StatusSistemaRepository.Find(x => x.cd_sap == cd);
            if (listst.Count > 0)
            {
                return listst[0];
            }
            else
            {
                return null;
            }
        }

        public StatusSistema Update(StatusSistema param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusSistemaRepository.Add(param);
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
