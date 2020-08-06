using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class ZonaService
    {
        private DatabaseContext context;

        public ZonaService()
        {
            context = new DatabaseContext();
        }

        public Zona GetByID(int id)
        {
            return context.ZonaRepository.GetById(id);
        }

        public List<Zona> GetAll()
        {
            return context.ZonaRepository.GetAll();
        }

        public Zona Delete(Zona obj)
        {
            Zona zona = new Zona();
            zona.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                zona = context.ZonaRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    zona.BaseModel.Retorno = MessageType.Success;
                    zona.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    zona.BaseModel.Erro = true;
                }
                else
                {
                    zona.BaseModel.Retorno = MessageType.Warning;
                    zona.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    zona.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    zona.BaseModel.Retorno = MessageType.Error;
                }

                zona.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                zona.BaseModel.MensagemException = e;
            }

            return zona;
        }

        public Zona Add(Zona param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ZonaRepository.Add(param);
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

        public Zona Update(Zona param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ZonaRepository.Update(param);
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