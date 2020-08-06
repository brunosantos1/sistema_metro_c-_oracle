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
    [Table("EnvioAvisoAux")]
    public class EnvioAvisoAux
    {
        [Key]
        public Int64 EnvioAvisoAuxID { get; set; }       
        public Int64 EnvioAvisoID { get; set; }

        public Form1AdminViewModel form1AdminViewModel { get; set; }
        public ClienteXAssociada clienteXAssociada { get; set; }

        #region AvisoXUsuario

        [Display(Name = "AvisoXUsuarioID")]
        public Int64 AvisoXUsuarioID { get; set; }

        [ForeignKey("AvisoXUsuarioID")]
        [JsonIgnore]
        public virtual AvisoXUsuario AvisoXUsuario { get; set; }

        #endregion

        #region Campos

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(5000, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Mensagem")]
        public string Mensagem { get; set; }

        #endregion

        #region Empresa
        [Display(Name = "Empresa")]
        public Int64 EmpresaID { get; set; }
        // Navigation property
        [ForeignKey("EmpresaID")]
        [JsonIgnore]
        public virtual Empresa Empresa { get; set; }
        #endregion

        #region Registro       
        public Int64 UsuarioCriacaoId { get; set; }
        [Required]
        public DateTime DataCriacao { get; set; }
        public Int64? UsuarioAlteracaoId { get; set; }
        public DateTime? DataAlteracao { get; set; }
        #endregion
    }
}
