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
    public class MaoDeObraService
    {
        private DatabaseContext context;

        public MaoDeObraService()
        {
            context = new DatabaseContext();
        }

        public MaoDeObra GetByID(int id)
        {
            return context.MaoDeObraRepository.GetById(id);
        }

        public List<MaoDeObra> GetAll()
        {
            return context.MaoDeObraRepository.GetAll();
        }

        public List<MaoDeObra> GetByOperacaoOrdem(int id)
        {
            List<MaoDeObra> maosDeObra = context.MaoDeObraRepository.Find(x => x.id_operacao_fk == id);
            return maosDeObra;
        }

        public bool DeleteById(int id)
        {
            MaoDeObra maoDeObra = new MaoDeObra();

            try
            {
                maoDeObra = context.MaoDeObraRepository.GetById(id);
                var retorno = context.MaoDeObraRepository.Update(maoDeObra);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public MaoDeObra Add(MaoDeObra param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.MaoDeObraRepository.Add(param);
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

        public MaoDeObra Update(MaoDeObra param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.MaoDeObraRepository.Add(param);
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