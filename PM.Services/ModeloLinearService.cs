using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class ModeloLinearService
    {
        private DatabaseContext context;

        public ModeloLinearService()
        {
            context = new DatabaseContext();
        }

        public ModeloLinear GetByID(int id)
        {
            return context.ModeloLinearRepository.GetById(id);
        }

        public List<ModeloLinear> GetAll()
        {
            return context.ModeloLinearRepository.GetAll();
        }

        public ModeloLinear Delete(ModeloLinear obj)
        {
            ModeloLinear modeloLinear = new ModeloLinear();
            modeloLinear.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                modeloLinear = context.ModeloLinearRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    modeloLinear.BaseModel.Retorno = MessageType.Success;
                    modeloLinear.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    modeloLinear.BaseModel.Erro = true;
                }
                else
                {
                    modeloLinear.BaseModel.Retorno = MessageType.Warning;
                    modeloLinear.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    modeloLinear.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    modeloLinear.BaseModel.Retorno = MessageType.Error;
                }

                modeloLinear.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                modeloLinear.BaseModel.MensagemException = e;
            }

            return modeloLinear;
        }

        public ModeloLinear Add(ModeloLinear param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ModeloLinearRepository.Add(param);
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

        public ModeloLinear Update(ModeloLinear param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ModeloLinearRepository.Add(param);
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
