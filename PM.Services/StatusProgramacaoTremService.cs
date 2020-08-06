using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class StatusProgramacaoTremService
    {
        private DatabaseContext context;

        public StatusProgramacaoTremService()
        {
            context = new DatabaseContext();
        }
        public StatusProgramacaoTremService(DatabaseContext dbcontext)
        {
            context = dbcontext;
        }
        
        public StatusProgramacaoTrem GetByID(int id)
        {
            return context.StatusProgramacaoTremRepository.GetById(id);
        }

        public List<StatusProgramacaoTrem> GetAll()
        {
            return context.StatusProgramacaoTremRepository.GetAll();
        }

        public StatusProgramacaoTrem Delete(StatusProgramacaoTrem obj)
        {
            StatusProgramacaoTrem StatusProgramacaoTrem = new StatusProgramacaoTrem();
            StatusProgramacaoTrem.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                StatusProgramacaoTrem = context.StatusProgramacaoTremRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    StatusProgramacaoTrem.BaseModel.Retorno = MessageType.Success;
                    StatusProgramacaoTrem.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    StatusProgramacaoTrem.BaseModel.Erro = true;
                }
                else
                {
                    StatusProgramacaoTrem.BaseModel.Retorno = MessageType.Warning;
                    StatusProgramacaoTrem.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    StatusProgramacaoTrem.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    StatusProgramacaoTrem.BaseModel.Retorno = MessageType.Error;
                }

                StatusProgramacaoTrem.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                StatusProgramacaoTrem.BaseModel.MensagemException = e;
            }

            return StatusProgramacaoTrem;
        }

        public StatusProgramacaoTrem Add(StatusProgramacaoTrem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusProgramacaoTremRepository.Add(param);
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

        public StatusProgramacaoTrem Update(StatusProgramacaoTrem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.StatusProgramacaoTremRepository.Update(param);
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

        public StatusProgramacaoTrem GetByCdSap(string cd)
        {
            List<StatusProgramacaoTrem> listst = context.StatusProgramacaoTremRepository.Find(x => x.cd_sap.ToUpper() == cd.ToUpper());
            if (listst.Count > 0)
            {
                return listst[0];
            }
            else
            {
                return null;
            }
        }
    }
}

