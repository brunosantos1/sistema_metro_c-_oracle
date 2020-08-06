using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace PM.Domain.Entities
{
    [Table("OOSistemaAplicacao")]
    public class SistemaAplicacao : EntityTypeConfiguration<SistemaAplicacao>
    {
        public SistemaAplicacao() { BaseModel = new BaseModel(); }

        [Key]
        [Required]
        [Display(Name = "ID Aplicação")]
        public int id_aplicacao { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Código Aplicação")]
        public string ds_codigo_aplicacao { get; set; }

        [Required]
        [Display(Name = "ID Empresa")]
        public int id_empresa { get; set; }

        [Display(Name = "ID Tipo Log")]
        public virtual List<SistemaTipoLog> id_tipo_log { get; set; }

        [Required]
        [Display(Name = "Data Criação")]
        public DateTime dt_cadastro { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nome da aplicação")]
        public string ds_descricao { get; set; }

        [StringLength(8000)]
        [Display(Name = "Observações")]
        public string ds_observacao { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Servidor")]
        public string nm_bancohost { get; set; }

        [Required]
        [Display(Name = "Porta")]
        public int nu_bancoporta { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Banco de Dados")]
        public string nm_banconome { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Usuario banco")]
        public string nm_bancousuario { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha banco")]
        public string ds_bancosenha { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Protocolo")]
        public string ds_bancoprotocolo { get; set; }

        [Display(Name = "Token Aplicacao")]
        public Guid ds_token { get; set; }

        [Required]
        [Display(Name = "Registro Ativo")]
        public bool isAtivo { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
