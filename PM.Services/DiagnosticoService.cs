using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class DiagnosticoService
    {
        private DatabaseContext context;

        public DiagnosticoService()
        {
            context = new DatabaseContext();
        }

        public Diagnostico GetByID(int id)
        {
            return context.DiagnosticoRepository.GetById(id);
        }

        public List<Diagnostico> GetAll()
        {
            return context.DiagnosticoRepository.GetAll();
        }

        public Diagnostico Delete(Diagnostico obj)
        {
            Diagnostico diagnostico = new Diagnostico();
            diagnostico.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                diagnostico = context.DiagnosticoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    diagnostico.BaseModel.Retorno = MessageType.Success;
                    diagnostico.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    diagnostico.BaseModel.Erro = true;
                }
                else
                {
                    diagnostico.BaseModel.Retorno = MessageType.Warning;
                    diagnostico.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    diagnostico.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    diagnostico.BaseModel.Retorno = MessageType.Error;
                }

                diagnostico.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                diagnostico.BaseModel.MensagemException = e;
            }

            return diagnostico;
        }

        public Diagnostico Add(Diagnostico param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.DiagnosticoRepository.Add(param);
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

        public Diagnostico Update(Diagnostico param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.DiagnosticoRepository.Add(param);
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
