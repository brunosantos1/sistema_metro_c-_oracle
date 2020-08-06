using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class CategoriaPontoMedicaoService
    {
        private DatabaseContext context;

        public CategoriaPontoMedicaoService()
        {
            context = new DatabaseContext();
        }

        public CategoriaPontoMedicao GetByID(int id)
        {
            return context.CategoriaPontoMedicaoRepository.GetById(id);
        }

        public List<CategoriaPontoMedicao> GetAll()
        {
            return context.CategoriaPontoMedicaoRepository.GetAll();
        }

        public CategoriaPontoMedicao Delete(CategoriaPontoMedicao obj)
        {
            CategoriaPontoMedicao categoriaPontoMedicao = new CategoriaPontoMedicao();
            categoriaPontoMedicao.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                categoriaPontoMedicao = context.CategoriaPontoMedicaoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    categoriaPontoMedicao.BaseModel.Retorno = MessageType.Success;
                    categoriaPontoMedicao.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    categoriaPontoMedicao.BaseModel.Erro = true;
                }
                else
                {
                    categoriaPontoMedicao.BaseModel.Retorno = MessageType.Warning;
                    categoriaPontoMedicao.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    categoriaPontoMedicao.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    categoriaPontoMedicao.BaseModel.Retorno = MessageType.Error;
                }

                categoriaPontoMedicao.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                categoriaPontoMedicao.BaseModel.MensagemException = e;
            }

            return categoriaPontoMedicao;
        }

        public CategoriaPontoMedicao Add(CategoriaPontoMedicao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CategoriaPontoMedicaoRepository.Add(param);
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

        public CategoriaPontoMedicao Update(CategoriaPontoMedicao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CategoriaPontoMedicaoRepository.Add(param);
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
