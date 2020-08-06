using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class CalendarioFabricaService
    {
        private DatabaseContext context;

        public CalendarioFabricaService()
        {
            context = new DatabaseContext();
        }

        public CalendarioFabrica GetByID(int id)
        {
            return context.CalendarioFabricaRepository.GetById(id);
        }

        public List<CalendarioFabrica> GetAll()
        {
            return context.CalendarioFabricaRepository.GetAll();
        }

        public CalendarioFabrica Delete(CalendarioFabrica obj)
        {
            CalendarioFabrica calendarioFabrica = new CalendarioFabrica();
            calendarioFabrica.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                calendarioFabrica = context.CalendarioFabricaRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    calendarioFabrica.BaseModel.Retorno = MessageType.Success;
                    calendarioFabrica.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    calendarioFabrica.BaseModel.Erro = true;
                }
                else
                {
                    calendarioFabrica.BaseModel.Retorno = MessageType.Warning;
                    calendarioFabrica.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    calendarioFabrica.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    calendarioFabrica.BaseModel.Retorno = MessageType.Error;
                }

                calendarioFabrica.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                calendarioFabrica.BaseModel.MensagemException = e;
            }

            return calendarioFabrica;
        }

        public CalendarioFabrica Add(CalendarioFabrica param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CalendarioFabricaRepository.Add(param);
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

        public CalendarioFabrica Update(CalendarioFabrica param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CalendarioFabricaRepository.Add(param);
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
