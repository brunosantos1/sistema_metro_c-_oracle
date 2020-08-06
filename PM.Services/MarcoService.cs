using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class MarcoService
    {
        private DatabaseContext context;

        public MarcoService()
        {
            context = new DatabaseContext();
        }

        public Marco GetByID(int id)
        {
            return context.MarcoRepository.GetById(id);
        }

        public List<Marco> GetAll()
        {
            return context.MarcoRepository.GetAll();
        }

        public Marco Delete(Marco obj)
        {
            Marco Marco = new Marco();
            Marco.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                Marco = context.MarcoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    Marco.BaseModel.Retorno = MessageType.Success;
                    Marco.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    Marco.BaseModel.Erro = true;
                }
                else
                {
                    Marco.BaseModel.Retorno = MessageType.Warning;
                    Marco.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    Marco.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    Marco.BaseModel.Retorno = MessageType.Error;
                }

                Marco.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                Marco.BaseModel.MensagemException = e;
            }

            return Marco;
        }

        public Marco Add(Marco param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.MarcoRepository.Add(param);
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

        public Marco Update(Marco param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.MarcoRepository.Add(param);
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
