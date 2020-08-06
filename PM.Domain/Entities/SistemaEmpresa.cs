using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace PM.Domain.Entities
{
    [Table("OOSistemaEmpresa")]
    public class SistemaEmpresa : EntityTypeConfiguration<SistemaEmpresa>
    {
        public SistemaEmpresa() { BaseModel = new BaseModel(); }

        [Key]
        [Required]
        [Display(Name = "ID Registro")]
        public int id_empresa { get; set; }

        [Required]
        [Display(Name = "Data Criação")]
        [DataType(DataType.DateTime)]
        public DateTime dt_cadastro { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descrição")]
        public string ds_descricao { get; set; }

        [Required]
        [Display(Name = "Registro Ativo")]
        public bool isAtivo { get; set; }

        public virtual List<SistemaAplicacao> id_aplicacao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}