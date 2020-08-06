using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace PM.Services
{
    public class CodeService
    {
        private DatabaseContext context;

        public CodeService()
        {
            context = new DatabaseContext();
        }

        public Code GetByID(int id)
        {
            try
            {
                return context.CodeRepository.GetById(id);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public Code GetByCdSap(string cdSap)
        {
            try
            {
                List<Code> listCode = context.CodeRepository.Find(x => x.cd_sap == cdSap);
                if (listCode.Count > 0)
                {
                    return listCode[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public List<Code> GetAll()
        {
            return context.CodeRepository.GetAll();
        }

        public Code Delete(Code obj)
        {
            Code code = new Code();
            code.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                code = context.CodeRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    code.BaseModel.Retorno = MessageType.Success;
                    code.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    code.BaseModel.Erro = true;
                }
                else
                {
                    code.BaseModel.Retorno = MessageType.Warning;
                    code.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    code.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    code.BaseModel.Retorno = MessageType.Error;
                }

                code.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                code.BaseModel.MensagemException = e;
            }

            return code;
        }

        public Code Add(Code param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CodeRepository.Add(param);
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

        public Code Update(Code param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CodeRepository.Add(param);
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

        public List<Code> GetTipoServico()
        {
            try
            {
                return context.CodeRepository.AsQueryable().Where(x => x.GrupoCode.cd_sap == "SERVICO").ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
