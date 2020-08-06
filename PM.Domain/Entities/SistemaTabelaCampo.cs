using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace PM.Domain.Entities
{
    [Table("OOSistemaTabelaCampo")]
    public class SistemaTabelaCampo : EntityTypeConfiguration<SistemaTabelaCampo>
    {
        public SistemaTabelaCampo() { BaseModel = new BaseModel(); }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Registro")]
        public int id_campo { get; set; }

        [Required]
        [Display(Name = "Tabela")]
        public int id_tabela_fk { get; set; }

        [Required]
        [Display(Name = "Data Criação")]
        [DataType(DataType.DateTime)]
        public DateTime dt_ocorrencia { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descrição")]
        public string ds_descricao { get; set; }

        [Required]
        [Display(Name = "Tipo Campo")]
        public int id_tipo_dado_fk { get; set; }

        [Required]
        [Display(Name = "Tamanho")]
        public int nu_campo_tamanho { get; set; }

        [Required]
        [Display(Name = "Casa Decimal")]
        public int nu_campo_decimal { get; set; }

        [Display(Name = "Mascara")]
        [StringLength(20)]
        public string ds_campo_mascara { get; set; }


        //public int _idrelacionatab { get; set; }
        //public int _idrelacionacmp { get; set; }

        #region Campos de retorno de erro em Add, Update, Delete
        [NotMapped]
        public BaseModel BaseModel { get; set; }
        #endregion
    }
}