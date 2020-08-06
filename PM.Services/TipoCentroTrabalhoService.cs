using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class TipoCentroTrabalhoService
    {
        private DatabaseContext context;

        public TipoCentroTrabalhoService()
        {
            context = new DatabaseContext();
        }

        public TipoCentroTrabalho GetByID(int id)
        {
            return context.TipoCentroTrabalhoRepository.GetById(id);
        }

        public List<TipoCentroTrabalho> GetAll()
        {
            return context.TipoCentroTrabalhoRepository.GetAll();
        }

        public TipoCentroTrabalho Delete(TipoCentroTrabalho obj)
        {
            TipoCentroTrabalho tipoCentroTrabalho = new TipoCentroTrabalho();
            tipoCentroTrabalho.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                tipoCentroTrabalho = context.TipoCentroTrabalhoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    tipoCentroTrabalho.BaseModel.Retorno = MessageType.Success;
                    tipoCentroTrabalho.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    tipoCentroTrabalho.BaseModel.Erro = true;
                }
                else
                {
                    tipoCentroTrabalho.BaseModel.Retorno = MessageType.Warning;
                    tipoCentroTrabalho.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    tipoCentroTrabalho.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    tipoCentroTrabalho.BaseModel.Retorno = MessageType.Error;
                }

                tipoCentroTrabalho.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                tipoCentroTrabalho.BaseModel.MensagemException = e;
            }

            return tipoCentroTrabalho;
        }

        public TipoCentroTrabalho Add(TipoCentroTrabalho param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.TipoCentroTrabalhoRepository.Add(param);
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

        public TipoCentroTrabalho Update(TipoCentroTrabalho param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.TipoCentroTrabalhoRepository.Add(param);
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
