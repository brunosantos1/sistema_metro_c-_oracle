using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCentroCusto")]
    public class CentroCusto : EntityTypeConfiguration<CentroCusto>
    {
        public CentroCusto() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_centro_custo { get; set; }

        [StringLength(10)]
        //[Index("IX_CentroCusto", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(30)]
        public string ds_centro_custo { get; set; }

        [StringLength(255)]
        public string ds_completa_centro_custo { get; set; }

        [StringLength(12)]
        public string nm_usuario_alteracao { get; set; }

        public DateTime dt_alteracao_registro { get; set; }

        public decimal nr_fator { get; set; }

        [StringLength(15)]
        public string sg_centro_custo { get; set; }

        public bool st_ativo { get; set; }
        
        [StringLength(15)]
        public string ar_centro_custo { get; set; }

        public DateTime dt_carga { get; set; }

        [StringLength(5)]
        public string ct_custo_anterior { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
