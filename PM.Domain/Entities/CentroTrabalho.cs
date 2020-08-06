using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCentroTrabalho")]
    public class CentroTrabalho : EntityTypeConfiguration<CentroTrabalho>
    {
        public CentroTrabalho() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_ct_trabalho { get; set; }

        [StringLength(8)]
        //[Index("IX_CentroTrabalho", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(8)]
        public string ct_trabalho { get; set; }

        [ForeignKey("CentroLocalizacao")]
        public int? id_centro_fk { get; set; }

        [ForeignKey("TpCentroTrabalho")]
        public int? id_tp_ct_trabalho_fk { get; set; }

        [StringLength(40)]
        public string ds_ct_trabalho { get; set; }

        [ForeignKey("Localizacao")]
        public int? id_localizacao_fk { get; set; }

        [StringLength(3)]
        public string cd_rs_ct_trabalho { get; set; }

        [StringLength(3)]
        public string cd_ch_utilizacao_lista { get; set; }

        [StringLength(4)]
        public string ch_controle { get; set; }

        public bool cr_ch_controle { get; set; }

        public DateTime dt_inicio { get; set; }

        public DateTime dt_fim { get; set; }
        
        [ForeignKey("CentroCusto")]
        public int? id_ct_custo_fk { get; set; }

        [StringLength(4)]
        public string ar_contabil { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public CentroLocalizacao CentroLocalizacao { get; set; }
        public TipoCentroTrabalho TpCentroTrabalho { get; set; }
        public CentroCusto CentroCusto { get; set; }
        public Localizacao Localizacao { get; set; }
    }
}
