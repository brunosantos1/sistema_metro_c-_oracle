using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using PM.Domain.Entities.Enum;

namespace PM.Services
{
    public class MaterialOperacaoService
    {
        private DatabaseContext context;

        public MaterialOperacaoService()
        {
            context = new DatabaseContext();
        }

        public MaterialOperacao GetByID(int id)
        {
            return context.MaterialOperacaoRepository.GetById(id);
        }

        public List<MaterialOperacao> GetAll()
        {
            return context.MaterialOperacaoRepository.GetAll();
        }

        public List<MaterialOperacao> GetByOperacaoOrdem(int id)
        {
            List<MaterialOperacao> materiaisOperacao = context.MaterialOperacaoRepository.Find(x => x.id_operacao_fk == id);
            return materiaisOperacao;
        }

        public bool DeleteById(int id)
        {
            MaterialOperacao materialOperacao = new MaterialOperacao();

            try
            {
                materialOperacao = context.MaterialOperacaoRepository.GetById(id);
                var retorno = context.MaterialOperacaoRepository.Update(materialOperacao);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public MaterialOperacao Add(MaterialOperacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.MaterialOperacaoRepository.Add(param);
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

        public MaterialOperacao Update(MaterialOperacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.MaterialOperacaoRepository.Add(param);
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