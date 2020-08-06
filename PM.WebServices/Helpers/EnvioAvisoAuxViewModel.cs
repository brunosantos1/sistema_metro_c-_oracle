using FN.DeePlanning.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NDeePlanning.Models
{
   
    public class EnvioAvisoAuxViewModel
    {
        public EnvioAvisoAuxViewModel()
        {
            ListaEnvioAvisoAux = new List<EnvioAvisoAux>();
        }
        public List<EnvioAvisoAux> ListaEnvioAvisoAux { get; set; }

        public bool Adicionar(EnvioAviso envioAviso, Form1AdminViewModel form1AdminViewModel)
        {
            EnvioAvisoAux envioAvisoAux = new EnvioAvisoAux
            {
                AvisoXUsuario = envioAviso.AvisoXUsuario,
                AvisoXUsuarioID = envioAviso.AvisoXUsuarioID,
                DataAlteracao = envioAviso.DataAlteracao,
                DataCriacao = envioAviso.DataCriacao,
                Empresa = envioAviso.Empresa,
                EmpresaID = envioAviso.EmpresaID,
                EnvioAvisoID = envioAviso.EnvioAvisoID,
                Mensagem = envioAviso.Mensagem,
                UsuarioAlteracaoId = envioAviso.UsuarioAlteracaoId,
                UsuarioCriacaoId = envioAviso.UsuarioCriacaoId,
                form1AdminViewModel = form1AdminViewModel                
            };
            ListaEnvioAvisoAux.Add(envioAvisoAux);
            return true;
        }

        public bool Adicionar(EnvioAviso envioAviso, ClienteXAssociada clienteXAssociada)
        {
            EnvioAvisoAux envioAvisoAux = new EnvioAvisoAux
            {
                AvisoXUsuario = envioAviso.AvisoXUsuario,
                AvisoXUsuarioID = envioAviso.AvisoXUsuarioID,
                DataAlteracao = envioAviso.DataAlteracao,
                DataCriacao = envioAviso.DataCriacao,
                Empresa = envioAviso.Empresa,
                EmpresaID = envioAviso.EmpresaID,
                EnvioAvisoID = envioAviso.EnvioAvisoID,
                Mensagem = envioAviso.Mensagem,
                UsuarioAlteracaoId = envioAviso.UsuarioAlteracaoId,
                UsuarioCriacaoId = envioAviso.UsuarioCriacaoId,
                clienteXAssociada = clienteXAssociada
            };
            ListaEnvioAvisoAux.Add(envioAvisoAux);
            return true;
        }
    }
}
