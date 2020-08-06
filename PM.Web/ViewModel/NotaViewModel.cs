using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class NotaViewModel : BaseViewModel
    {
        public int TipoId { get; set; }

        [Display(Name = "Número da Nota:")]
        public string nr_nota_sap { get; set; }

        public string Descricao { get; set; }

        public TipoNotaViewModel TipoNota { get; set; }

        public StatusSistemaViewModel StatusSistema { get; set; }

        public StatusUsuarioViewModel StatusUsuario { get; set; }

        [Display(Name = "Data da Nota:")]
        public DateTime dt_hora_nota { get; set; }

        public DateTime DataEncerramentoRef { get; set; }

        [Display(Name = "Notificador:")]
        public string rg_notificador { get; set; }

        [Display(Name = "Ordem:")]
        public string Ordem { get; set; }

        [Display(Name = "Prioridade:")]
        public int nt_prioridade { get; set; }

        [Display(Name = "Etiqueta:")]
        public int eq_etiqueta { get; set; }

        [Display(Name = "Número ATE/PEP:")]
        public int NumeroPEP { get; set; }

        [Display(Name = "Dados Adicionais:")]
        public string DadosAdicionais { get; set; }

        public EquipamentoViewModel Equipamento { get; set; }

        public MaterialViewModel Material { get; set; }

        public CentroTrabalhoViewModel CentroTrabalho { get; set; }

        public PerfilCatalogoViewModel PerfilCatalogo { get; set; }

        public ElementoPEPViewModel ElementoPEP { get; set; }

        [Display(Name = "Equipe:")]
        public string Equipe { get; set; }

        [Display(Name = "Loc. Inst./Equip:")]
        public string LocInstEquip { get; set; }

        [Display(Name = "Descrição do Local de Instalação/Equipamento:")]
        public string DescrLocInstEquip { get; set; }

    }
}