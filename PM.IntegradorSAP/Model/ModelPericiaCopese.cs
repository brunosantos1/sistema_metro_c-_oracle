using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PM.IntegradorSAP.Model
{
    public class ModelPericiaCopese
    {
        [Required]
        public string TipoNota { get; set; }
        [Required]
        public string NotaReferencia { get; set; }
        public string LocInstalacao { get; set; }
        public string Code { get; set; }
        public string GrpCode { get; set; }
        public string Descricao { get; set; }
        public string Notificador { get; set; }
        public string Observacao { get; set; }
        public string StatusNota { get; set; }
        public string StatusUsuario { get; set; }
        public List<ModelPericiaCopeseCausa> Causa { get; set; }
        public List<ModelPericiaCopeseAtividade> Atividade { get; set; }
        public List<ModelPericiaCopeseMedida> Medida { get; set; }
    }

    public class ModelPericiaCopeseCausa
    {
        public string NumeroItem { get; set; }
        public string GrpCodCausa { get; set; }
        public string CodCausa { get; set; }
    }
    public class ModelPericiaCopeseAtividade
    {
        public string NumeroItem { get; set; }
        public string GrpCodAtividades { get; set; }
        public string CodAtividades { get; set; }
        public string NumeroBO { get; set; }
        public string DescricaoBO { get; set; }
    }

    public class ModelPericiaCopeseMedida
    {
        public string ItemMedia { get; set; }
        public string GrpCodMedidas { get; set; }
        public string CodMedidas { get; set; }
        public string FuncResposavel { get; set; }
        public string Responsavel { get; set; }
        public string StatusMedida { get; set; }
        public string DataMedida { get; set; }
        public string HoraMedida { get; set; }
        public string RGLogado { get; set; }
        public string DataProgramanda { get; set; }
        public string HoraProgramada { get; set; }
    }
}