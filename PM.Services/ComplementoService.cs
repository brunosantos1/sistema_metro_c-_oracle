using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace PM.Services
{
    public class ComplementoService
    {
        private DatabaseContext context;

        public ComplementoService()
        {
            context = new DatabaseContext();
        }

        public Complemento GetByID(int id)
        {
            return context.ComplementoRepository.GetById(id);
        }

        public List<Complemento> GetAll()
        {
            return context.ComplementoRepository.GetAll();
        }

        public Complemento Delete(Complemento obj)
        {
            Complemento complemento = new Complemento();
            complemento.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                complemento = context.ComplementoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    complemento.BaseModel.Retorno = MessageType.Success;
                    complemento.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    complemento.BaseModel.Erro = true;
                }
                else
                {
                    complemento.BaseModel.Retorno = MessageType.Warning;
                    complemento.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    complemento.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    complemento.BaseModel.Retorno = MessageType.Error;
                }

                complemento.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                complemento.BaseModel.MensagemException = e;
            }

            return complemento;
        }

        public Complemento Add(Complemento param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ComplementoRepository.Add(param);
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

        public Complemento Update(Complemento param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ComplementoRepository.Add(param);
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

        public List<Complemento> GetBySistema(int idSistema)
        {
            return context.ComplementoRepository.AsQueryable().Where(x => x.id_grcode_sistema_fk == idSistema).ToList();
        }
    }
}
