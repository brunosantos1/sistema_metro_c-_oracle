using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class GrupoCodeService
    {
        private DatabaseContext context;

        public GrupoCodeService()
        {
            context = new DatabaseContext();
        }

        public GrupoCode GetByID(int id)
        {
            return context.GrupoCodeRepository.GetById(id);
        }

        public List<GrupoCode> GetAll()
        {
            return context.GrupoCodeRepository.GetAll();
        }

        public GrupoCode Delete(GrupoCode obj)
        {
            GrupoCode GrupoCode = new GrupoCode();
            GrupoCode.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                GrupoCode = context.GrupoCodeRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    GrupoCode.BaseModel.Retorno = MessageType.Success;
                    GrupoCode.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    GrupoCode.BaseModel.Erro = true;
                }
                else
                {
                    GrupoCode.BaseModel.Retorno = MessageType.Warning;
                    GrupoCode.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    GrupoCode.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    GrupoCode.BaseModel.Retorno = MessageType.Error;
                }

                GrupoCode.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                GrupoCode.BaseModel.MensagemException = e;
            }

            return GrupoCode;
        }

        public GrupoCode Add(GrupoCode param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.GrupoCodeRepository.Add(param);
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

        public GrupoCode Update(GrupoCode param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.GrupoCodeRepository.Add(param);
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
