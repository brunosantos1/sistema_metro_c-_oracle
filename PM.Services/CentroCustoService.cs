using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class CentroCustoService
    {
        private DatabaseContext context;

        public CentroCustoService()
        {
            context = new DatabaseContext();
        }

        public CentroCusto GetByID(int id)
        {
            return context.CentroCustoRepository.GetById(id);
        }

        public List<CentroCusto> GetAll()
        {
            return context.CentroCustoRepository.GetAll();
        }

        public CentroCusto Delete(CentroCusto obj)
        {
            CentroCusto centroCusto = new CentroCusto();
            centroCusto.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                centroCusto = context.CentroCustoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    centroCusto.BaseModel.Retorno = MessageType.Success;
                    centroCusto.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    centroCusto.BaseModel.Erro = true;
                }
                else
                {
                    centroCusto.BaseModel.Retorno = MessageType.Warning;
                    centroCusto.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    centroCusto.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    centroCusto.BaseModel.Retorno = MessageType.Error;
                }

                centroCusto.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                centroCusto.BaseModel.MensagemException = e;
            }

            return centroCusto;
        }

        public CentroCusto Add(CentroCusto param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CentroCustoRepository.Add(param);
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

        public CentroCusto Update(CentroCusto param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CentroCustoRepository.Add(param);
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
