using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class ElementoPEPService
    {
        private DatabaseContext context;

        public ElementoPEPService()
        {
            context = new DatabaseContext();
        }

        public ElementoPEP GetByID(int id)
        {
            return context.ElementoPEPRepository.GetById(id);
        }

        public List<ElementoPEP> GetAll()
        {
            return context.ElementoPEPRepository.GetAll();
        }

        public ElementoPEP Delete(ElementoPEP obj)
        {
            ElementoPEP elementoPEP = new ElementoPEP();
            elementoPEP.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                elementoPEP = context.ElementoPEPRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    elementoPEP.BaseModel.Retorno = MessageType.Success;
                    elementoPEP.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    elementoPEP.BaseModel.Erro = true;
                }
                else
                {
                    elementoPEP.BaseModel.Retorno = MessageType.Warning;
                    elementoPEP.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    elementoPEP.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    elementoPEP.BaseModel.Retorno = MessageType.Error;
                }

                elementoPEP.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                elementoPEP.BaseModel.MensagemException = e;
            }

            return elementoPEP;
        }

        public ElementoPEP Add(ElementoPEP param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ElementoPEPRepository.Add(param);
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

        public ElementoPEP Update(ElementoPEP param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ElementoPEPRepository.Add(param);
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
