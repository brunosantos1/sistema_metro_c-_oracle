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
    public class OrdemService
    {
        private DatabaseContext context;

        public OrdemService()
        {
            context = new DatabaseContext();
        }

        public Ordem GetByID(int id)
        {
            return context.OrdemRepository.GetById(id);
        }

        public List<Ordem> GetAll()
        {
            return context.OrdemRepository.GetAll();
        }

        public bool DeleteById(int id)
        {
            Ordem ordem = new Ordem();

            try
            {
                ordem = context.OrdemRepository.GetById(id);
                var retorno = context.OrdemRepository.Update(ordem);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Ordem Add(Ordem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.OrdemRepository.Add(param);
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

        public Ordem Update(Ordem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.OrdemRepository.Add(param);
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