using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.WebServices.Service
{
    public class ProgramacaoServices
    {
        public IList<Programacao> GetAll()
        {
            return ProgramacaoOperationsExtensions.GetAll(Links.appN.ProgramacaoOperations);
        }

        public Programacao GetById(int id)
        {
            return ProgramacaoOperationsExtensions.GetById(Links.appN.ProgramacaoOperations, id);
        }

        public Programacao GetNavigationPropertiesByID(int id)
        {
            return ProgramacaoOperationsExtensions.GetNavigationPropertiesByID(Links.appN.ProgramacaoOperations, id);
        }

        public Programacao Add(Programacao _param)
        {
            try
            {
                return ProgramacaoOperationsExtensions.Add(Links.appN.ProgramacaoOperations, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "Erro ao processar registro. Tente novamente mais tarde";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Programacao LiberarProgramacao(Programacao _param)
        {
            try
            {
                return ProgramacaoOperationsExtensions.LiberarProgramacao(Links.appN.ProgramacaoOperations, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "Erro ao processar registro. Tente novamente mais tarde";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Programacao CancelaProgramacao(Programacao _param)
        {
            try
            {
                return ProgramacaoOperationsExtensions.CancelaProgramacao(Links.appN.ProgramacaoOperations, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "Erro ao processar registro. Tente novamente mais tarde";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Programacao MudarLocalProgramacao(Programacao _param)
        {
            try
            {
                return ProgramacaoOperationsExtensions.MudarLocalProgramacao(Links.appN.ProgramacaoOperations, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "Erro ao processar registro. Tente novamente mais tarde";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public Programacao Update(Programacao _param)
        {
            try
            {
                return ProgramacaoOperationsExtensions.Update(Links.appN.ProgramacaoOperations, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "Erro ao processar registro. Tente novamente mais tarde";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public IList<Programacao> GetByProgramacao(int idLinha, int idPatio, int idTrem, int idMotivo, DateTime dtInicio, DateTime dtFinal)
        {
            return ProgramacaoOperationsExtensions.GetByProgramacao(Links.appN.ProgramacaoOperations, idLinha, idPatio, idTrem, idMotivo, dtInicio, dtFinal);

        }
        public string AutoComplete(string campo, string term)
        {
            term = string.IsNullOrEmpty(term) ? "" : term;

            List<Programacao> resultado = new List<Programacao>(ProgramacaoOperationsExtensions.AutoComplete(Links.appN.ProgramacaoOperations, campo, term));

            StringBuilder texto = new StringBuilder();

            if (resultado.Count > 0)
            {
                texto.Append("<div class='list-group' style='overflow: auto; height: 100px; margin-right: -15px; position: absolute; z-index: 4; margin-left: -15px; width: 485px;'>");

                resultado.ForEach(x =>
                {
                    if (campo == "ds_descricao_nota")
                    {
                        texto.Append(string.Format(@"<a onClick=""select('{0}');"" href=""#"" class='list-group-item'>{0}</a>", x.DsObservacao));
                    }
                });

                texto.Append("</div>");

                return texto.ToString();
            }
            return string.Empty;
        }


    }
}