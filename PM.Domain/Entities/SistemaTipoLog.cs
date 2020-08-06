using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace PM.Domain.Entities
{
    [Table("OOSistemaTipoLog")]
    public class SistemaTipoLog : EntityTypeConfiguration<SistemaTipoLog>
    {
        public SistemaTipoLog() { BaseModel = new BaseModel(); }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Registro")]
        public int id_tipo_log { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descrição")]
        public string ds_descricao { get; set; }

        [Required]
        [Display(Name = "Data Criação")]
        [DataType(DataType.DateTime)]
        public DateTime dt_ocorrencia { get; set; }

        [Required]
        [Display(Name = "Registro Ativo")]
        public bool isAtivo { get; set; }
                
        [Required]
        [Display(Name = "ID Aplicação")]
        public int id_aplicacao { get; set; }


        #region Campos de retorno de erro em Add, Update, Delete
        [NotMapped]
        public BaseModel BaseModel { get; set; }
        #endregion
    }
}