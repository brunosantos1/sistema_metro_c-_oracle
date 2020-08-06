using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class StatusMedidaService
    {
        private DatabaseContext context;

        public StatusMedidaService()
        {
            context = new DatabaseContext();
        }

        public StatusMedidaService(DatabaseContext dbContext)
        {
            context = dbContext;
        }

        public StatusMedida GetByID(int id)
        {
            return context.StatusMedidaRepository.GetById(id);
        }

        public StatusMedida GetByCdSap(string cdSap)
        {
            List<StatusMedida> listMedida = context.StatusMedidaRepository.Find(x => x.cd_sap == cdSap);
            if (listMedida.Count > 0)
            {
                return listMedida[0];
            }
            else
            {
                return null;
            }
        }

        public List<StatusMedida> GetAll()
        {
            return context.StatusMedidaRepository.GetAll();
        }

        public StatusMedida Delete(StatusMedida obj)
        {
            StatusMedida statusMedida = new StatusMedida();
            statusMedida.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                statusMedida = context.StatusMedidaRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    statusMedida.BaseModel.Retorno = MessageType.Success;
                    statusMedida.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    statusMedida.BaseModel.Erro = true;
                }
                else
                {
                    statusMedida.BaseModel.Retorno = MessageType.Warning;
                    statusMedida.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    statusMedida.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    statusMedida.BaseModel.Retorno = MessageType.Error;
                }

                statusMedida.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                statusMedida.BaseModel.MensagemException = e;
            }

            return statusMedida;
        }

        public StatusMedida Add(StatusMedida param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusMedidaRepository.Add(param);
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

        public StatusMedida Update(StatusMedida param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusMedidaRepository.Add(param);
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
