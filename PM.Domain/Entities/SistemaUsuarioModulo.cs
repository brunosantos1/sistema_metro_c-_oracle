using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace PM.Domain.Entities
{
    [Table("OOSistemaUsuarioModulo")]
    public class SistemaUsuarioModulo : EntityTypeConfiguration<SistemaUsuarioModulo>
    {
        public SistemaUsuarioModulo() { BaseModel = new BaseModel(); }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Registro")]
        public int _idusuario { get; set; }

        [Required]
        [Display(Name = "ID Modulo")]
        public int _idmodulo { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descrição")]
        public string ds_descricao { get; set; }

        [Required]
        [Display(Name = "Data Criação")]
        [DataType(DataType.DateTime)]
        public DateTime dt_ocorrencia { get; set; }

        #region Campos de retorno de erro em Add, Update, Delete
        [NotMapped]
        public BaseModel BaseModel { get; set; }
        #endregion
    }
}