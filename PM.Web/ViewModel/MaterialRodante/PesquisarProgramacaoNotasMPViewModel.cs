using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.WebServices.Models;

namespace PM.Web.ViewModel
{
    public class PesquisarProgramacaoNotasMPViewModel : BaseViewModel
    {
        public PesquisarProgramacaoNotasMPViewModel()
        {
        }

        public int id                                           { get; set; }
        public int idLinha                                      { get; set; }
        public int idPatio                                      { get; set; }
        public int idTrem                                       { get; set; }
        public int idTipo_manutencao                            { get; set; }
        public int idCentroTrabalho                             { get; set; }
        public string data_inicial                              { get; set; }
        public string data_final                                { get; set; }
        public int idStatus                                     { get; set; }
        public string Solicitante                               { get; set; }


        public List<SelectListItem> SelecionarLinha             { get; set; }
        public List<SelectListItem> SelecionarTrem              { get; set; }
        public List<SelectListItem> SelecionarPatio             { get; set; }
        public List<SelectListItem> SelecionarTipoManutencao    { get; set; }
        public List<SelectListItem> SelecionarCentroTrabalho    { get; set; }
        public List<SelectListItem> SelecionarStatus            { get; set; }
    }
}