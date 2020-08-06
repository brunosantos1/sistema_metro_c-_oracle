using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class MaterialViewModel : BaseViewModel
    {
        public int PrioridadeId { get; set; }

        [Display(Name = "Cód. Material:")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição do Material:")]
        public string Descricao { get; set; }

        [Display(Name = "Giro:")]
        public int Giro { get; set; }

        [Display(Name = "Nível de Alerta")]
        public int NivelAlerta { get; set; }

        [Display(Name = "Nível Crítico")]
        public int NivelCritico { get; set; }

        [Display(Name = "Qtde. Indisponível:")]
        public int QuantidadeIndisponivel { get; set; }

        [Display(Name = "Quantidade em Oficina")]
        public int QuantidadeOficina { get; set; }

        [Display(Name = "Quantidade Paralisada")]
        public int QuantidadeParalisada { get; set; }

        [Display(Name = "Quantidade em Terceiros")]
        public int QuantidadeTerceiros { get; set; }

        [Display(Name = "Quantidade Disponível na Logística")]
        public int QuantidadeDisponivelLogistica { get; set; }

        [Display(Name = "Quantidade Usuário / Transporte")]
        public int QuantidadeUsuarioTransporte { get; set; }

        [Display(Name = "Quantidade a Programar")]
        public int QuantidadeProgramar { get; set; }

        [Display(Name = "Quantidade Máxima Liberável:")]
        public int QuantidadeMaximaLiberavel { get; set; }

        public CentroTrabalhoViewModel CentroTrabalho { get; set; }

        [Display(Name = "Lista de Tarefas")]
        public int TarefaId { get; set; }

        public string Componente { get; set; }

        public string Operacao { get; set; }

        public int Quantidade { get; set; }

        public string Unidade { get; set; }

        public bool Reserva { get; set; }

        public string LocalEntrega { get; set; }

        public string ReservaReq { get; set; }

        public string CategItem { get; set; }

        public bool Incluir { get; set; }

        public bool Excluir { get; set; }
    }

}