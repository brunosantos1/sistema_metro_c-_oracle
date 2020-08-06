using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class StatusUsuarioService
    {
        private DatabaseContext context;

        public StatusUsuarioService()
        {
            context = new DatabaseContext();
        }

        public StatusUsuarioService(DatabaseContext dbContext)
        {
            context = dbContext;
        }

        public StatusUsuario GetByID(int id)
        {
            return context.StatusUsuarioRepository.GetById(id);
        }

        public StatusUsuario GetByCdSap(string cd)
        {
            List<StatusUsuario> listst = context.StatusUsuarioRepository.Find(x => x.cd_sap == cd);
            if (listst.Count > 0)
            {
                return listst[0];
            }
            else
            {
                return null;
            }
        }

        public List<StatusUsuario> GetAll()
        {
            return context.StatusUsuarioRepository.GetAll();
        }

        public StatusUsuario Delete(StatusUsuario obj)
        {
            StatusUsuario statusUsuario = new StatusUsuario();
            statusUsuario.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                statusUsuario = context.StatusUsuarioRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    statusUsuario.BaseModel.Retorno = MessageType.Success;
                    statusUsuario.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    statusUsuario.BaseModel.Erro = true;
                }
                else
                {
                    statusUsuario.BaseModel.Retorno = MessageType.Warning;
                    statusUsuario.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    statusUsuario.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    statusUsuario.BaseModel.Retorno = MessageType.Error;
                }

                statusUsuario.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                statusUsuario.BaseModel.MensagemException = e;
            }

            return statusUsuario;
        }

        public StatusUsuario Add(StatusUsuario param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusUsuarioRepository.Add(param);
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

        public StatusUsuario Update(StatusUsuario param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusUsuarioRepository.Update(param);
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
