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
    public class SistemaUsuarioModuloService
    {
        private DatabaseContext context;

        public SistemaUsuarioModuloService()
        {
            context = new DatabaseContext();
        }

        public SistemaUsuarioModulo GetByID(int id)
        {
            return context.SistemaUsuarioModuloRepository.GetById(id);
        }

        public List<SistemaUsuarioModulo> GetAll()
        {
            return context.SistemaUsuarioModuloRepository.GetAll();
        }

        public bool DeleteById(int id)
        {
            SistemaUsuarioModulo param = new SistemaUsuarioModulo();

            try
            {
                param = context.SistemaUsuarioModuloRepository.GetById(id);
                var retorno = context.SistemaUsuarioModuloRepository.Update(param);
                param.BaseModel.MensagemUsuario = "Registro excluído com sucesso";
                context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
                return true;
            }
            catch (Exception e)
            {
                BaseModel oBaseModel = new BaseModel();
                oBaseModel.Retorno = MessageType.Error;
                oBaseModel.MensagemUsuario = "Erro ao processar registro tente novamente mais tarde !!!";
                oBaseModel.MensagemException = e;
                param.BaseModel = oBaseModel;
                return false;
            }
        }

        public SistemaUsuarioModulo Add(SistemaUsuarioModulo param)
        {
            try
            {
                context.SistemaUsuarioModuloRepository.Add(param);
                param.BaseModel.MensagemUsuario = "Registro adicionado com sucesso";
                context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
            }
            catch (Exception e)
            {
                BaseModel oBaseModel = new BaseModel();
                oBaseModel.Retorno = MessageType.Error;
                oBaseModel.MensagemUsuario = "Erro ao processar registro tente novamente mais tarde !!!";
                oBaseModel.MensagemException = e;
                param.BaseModel = oBaseModel;
            }
            return param;
        }

        public bool Update(SistemaUsuarioModulo param)
        {
            try
            {
                context.SistemaUsuarioModuloRepository.Update(param);
                param.BaseModel.MensagemUsuario = "Registro alterado com sucesso";
                context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
                return true;
            }
            catch (Exception e)
            {
                BaseModel oBaseModel = new BaseModel();
                oBaseModel.Retorno = MessageType.Error;
                oBaseModel.MensagemUsuario = "Erro ao processar registro tente novamente mais tarde !!!";
                oBaseModel.MensagemException = e;
                param.BaseModel = oBaseModel;
                return false;
            }
        }
    }
}