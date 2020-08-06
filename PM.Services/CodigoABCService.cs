using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class CodigoABCService
    {
        private DatabaseContext context;

        public CodigoABCService()
        {
            context = new DatabaseContext();
        }

        public CodigoABC GetByID(int id)
        {
            return context.CodigoABCRepository.GetById(id);
        }

        public List<CodigoABC> GetAll()
        {
            return context.CodigoABCRepository.GetAll();
        }

        public CodigoABC Delete(CodigoABC obj)
        {
            CodigoABC codigoABC = new CodigoABC();
            codigoABC.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                codigoABC = context.CodigoABCRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    codigoABC.BaseModel.Retorno = MessageType.Success;
                    codigoABC.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    codigoABC.BaseModel.Erro = true;
                }
                else
                {
                    codigoABC.BaseModel.Retorno = MessageType.Warning;
                    codigoABC.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    codigoABC.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    codigoABC.BaseModel.Retorno = MessageType.Error;
                }

                codigoABC.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                codigoABC.BaseModel.MensagemException = e;
            }

            return codigoABC;
        }

        public CodigoABC Add(CodigoABC param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CodigoABCRepository.Add(param);
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

        public CodigoABC Update(CodigoABC param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CodigoABCRepository.Add(param);
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
