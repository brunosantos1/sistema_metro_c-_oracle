using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class MaterialService
    {
        private DatabaseContext context;

        public MaterialService()
        {
            context = new DatabaseContext();
        }

        public Material GetByID(int id)
        {
            return context.MaterialRepository.GetById(id);
        }

        public List<Material> GetAll()
        {
            return context.MaterialRepository.GetAll();
        }

        public Material Delete(Material obj)
        {
            Material material = new Material();
            material.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                material = context.MaterialRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    material.BaseModel.Retorno = MessageType.Success;
                    material.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    material.BaseModel.Erro = true;
                }
                else
                {
                    material.BaseModel.Retorno = MessageType.Warning;
                    material.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    material.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    material.BaseModel.Retorno = MessageType.Error;
                }

                material.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                material.BaseModel.MensagemException = e;
            }

            return material;
        }

        public Material Add(Material param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.MaterialRepository.Add(param);
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

        public Material Update(Material param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.MaterialRepository.Update(param);
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
