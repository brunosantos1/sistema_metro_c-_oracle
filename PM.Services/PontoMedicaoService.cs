using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class PontoMedicaoService
    {
        private DatabaseContext context;

        public PontoMedicaoService()
        {
            context = new DatabaseContext();
        }

        public PontoMedicao GetByID(int id)
        {
            return context.PontoMedicaoRepository.GetById(id);
        }

        public List<PontoMedicao> GetAll()
        {
            return context.PontoMedicaoRepository.GetAll();
        }

        public PontoMedicao Delete(PontoMedicao obj)
        {
            PontoMedicao pontoMedicao = new PontoMedicao();
            pontoMedicao.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                pontoMedicao = context.PontoMedicaoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    pontoMedicao.BaseModel.Retorno = MessageType.Success;
                    pontoMedicao.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    pontoMedicao.BaseModel.Erro = true;
                }
                else
                {
                    pontoMedicao.BaseModel.Retorno = MessageType.Warning;
                    pontoMedicao.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    pontoMedicao.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    pontoMedicao.BaseModel.Retorno = MessageType.Error;
                }

                pontoMedicao.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                pontoMedicao.BaseModel.MensagemException = e;
            }

            return pontoMedicao;
        }

        public PontoMedicao Add(PontoMedicao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.PontoMedicaoRepository.Add(param);
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

        public PontoMedicao Update(PontoMedicao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.PontoMedicaoRepository.Add(param);
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
