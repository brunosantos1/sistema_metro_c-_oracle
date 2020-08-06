using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class CarroService
    {
        private DatabaseContext context;

        public CarroService()
        {
            context = new DatabaseContext();
        }

        public Carro GetByID(int id)
        {
            return context.CarroRepository.GetById(id);
        }

        public List<Carro> GetAll()
        {
            return context.CarroRepository.GetAll();
        }

        public List<Carro> GetByTrem(int id)
        {
            List<Carro> carros = context.CarroRepository.Find(x => x.id_trem_fk == id);
            return carros;
        }

        public Carro Delete(Carro obj)
        {
            Carro carro = new Carro();
            carro.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                carro = context.CarroRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    carro.BaseModel.Retorno = MessageType.Success;
                    carro.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    carro.BaseModel.Erro = true;
                }
                else
                {
                    carro.BaseModel.Retorno = MessageType.Warning;
                    carro.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    carro.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    carro.BaseModel.Retorno = MessageType.Error;
                }

                carro.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                carro.BaseModel.MensagemException = e;
            }

            return carro;
        }

        public Carro Add(Carro param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CarroRepository.Add(param);
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

        public Carro Update(Carro param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CarroRepository.Add(param);
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
