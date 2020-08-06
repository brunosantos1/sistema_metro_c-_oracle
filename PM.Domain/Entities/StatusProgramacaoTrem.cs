
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOStatusProgramacaoTrem")]
    public class StatusProgramacaoTrem : EntityTypeConfiguration<StatusProgramacaoTrem>
    {
        public StatusProgramacaoTrem() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_st_programacao_trem { get; set; }

        [StringLength(50)]
        public string ds_st_programacao_trem { get; set; }

        [StringLength(04)]
        public string cd_sap { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}