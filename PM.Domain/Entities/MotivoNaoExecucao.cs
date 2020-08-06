using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOMotivoNaoExecucao")]
    public class MotivoNaoExecucao : EntityTypeConfiguration<MotivoNaoExecucao>
    {
        public MotivoNaoExecucao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id_motivo { get; set; }

        [StringLength(22)]
        //[Index("IX_LocalInstalacao", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [MaxLength(50)]
        public string ds_motivo { get; set; }

        public bool id_ativo { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        
    }
}
