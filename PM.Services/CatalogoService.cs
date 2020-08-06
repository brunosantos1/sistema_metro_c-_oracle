using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class CatalogoService
    {
        private DatabaseContext context;

        public CatalogoService()
        {
            context = new DatabaseContext();
        }

        public Catalogo GetByID(int id)
        {
            return context.CatalogoRepository.GetById(id);
        }

        public List<Catalogo> GetAll()
        {
            return context.CatalogoRepository.GetAll();
        }

        public Catalogo Delete(Catalogo obj)
        {
            Catalogo catalogo = new Catalogo();
            catalogo.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                catalogo = context.CatalogoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    catalogo.BaseModel.Retorno = MessageType.Success;
                    catalogo.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    catalogo.BaseModel.Erro = true;
                }
                else
                {
                    catalogo.BaseModel.Retorno = MessageType.Warning;
                    catalogo.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    catalogo.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    catalogo.BaseModel.Retorno = MessageType.Error;
                }

                catalogo.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                catalogo.BaseModel.MensagemException = e;
            }

            return catalogo;
        }

        public Catalogo Add(Catalogo param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CatalogoRepository.Add(param);
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

        public Catalogo Update(Catalogo param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CatalogoRepository.Update(param);
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