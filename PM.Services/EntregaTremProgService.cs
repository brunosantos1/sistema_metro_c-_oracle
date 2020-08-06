using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using PM.Domain.Entities.Enum;
using System.Linq.Expressions;



namespace PM.Services
{
    public class EntregaTremProgService
    {
        private DatabaseContext context;

        public EntregaTremProgService()
        {
            context = new DatabaseContext();
        }

        public EntregaTremProgService(DatabaseContext dbContext)
        {
            context = dbContext;
        }

        public EntregaTremProg GetByID(int id)
        {
            return context.EntregaTremProgRepository.GetById(id);
        }
        public List<EntregaTremProg> GetAll()
        {
            return context.EntregaTremProgRepository.GetAll();
        }
        public bool DeleteById(int id)
        {
            EntregaTremProg EntregaTremProg = new EntregaTremProg();

            try
            {
                EntregaTremProg = context.EntregaTremProgRepository.GetById(id);
                var retorno = context.EntregaTremProgRepository.Update(EntregaTremProg);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public EntregaTremProg Add(EntregaTremProg param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.EntregaTremProgRepository.Add(param);
                context.SaveChanges();
                param.BaseModel.Erro = false;
                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
            }
            catch (Exception e)
            {
                param.BaseModel.Erro = true;
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
                Console.Write("Erro");
            }

            return param;
        }
        public EntregaTremProg Update(EntregaTremProg param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.EntregaTremProgRepository.Add(param);
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