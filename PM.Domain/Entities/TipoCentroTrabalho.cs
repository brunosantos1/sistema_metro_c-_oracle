using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOTipoCentroTrabalho")]
    public class TipoCentroTrabalho : EntityTypeConfiguration<TipoCentroTrabalho>
    {
        public TipoCentroTrabalho() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tp_centro_trabalho { get; set; }

        [StringLength(10)]
        //[Index("IX_TipoCentroTrabalho", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }
        
        [StringLength(150)]
        public string ds_tp_centro_trabalho { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
