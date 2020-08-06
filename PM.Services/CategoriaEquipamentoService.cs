using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class CategoriaEquipamentoService
    {
        private DatabaseContext context;

        public CategoriaEquipamentoService()
        {
            context = new DatabaseContext();
        }

        public CategoriaEquipamento GetByID(int id)
        {
            return context.CategoriaEquipamentoRepository.GetById(id);
        }

        public List<CategoriaEquipamento> GetAll()
        {
            return context.CategoriaEquipamentoRepository.GetAll();
        }

        public CategoriaEquipamento Delete(CategoriaEquipamento obj)
        {
            CategoriaEquipamento categoriaEquipamento = new CategoriaEquipamento();
            categoriaEquipamento.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                categoriaEquipamento = context.CategoriaEquipamentoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    categoriaEquipamento.BaseModel.Retorno = MessageType.Success;
                    categoriaEquipamento.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    categoriaEquipamento.BaseModel.Erro = true;
                }
                else
                {
                    categoriaEquipamento.BaseModel.Retorno = MessageType.Warning;
                    categoriaEquipamento.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    categoriaEquipamento.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    categoriaEquipamento.BaseModel.Retorno = MessageType.Error;
                }

                categoriaEquipamento.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                categoriaEquipamento.BaseModel.MensagemException = e;
            }

            return categoriaEquipamento;
        }

        public CategoriaEquipamento Add(CategoriaEquipamento param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CategoriaEquipamentoRepository.Add(param);
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

        public CategoriaEquipamento Update(CategoriaEquipamento param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CategoriaEquipamentoRepository.Add(param);
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
