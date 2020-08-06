using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOUtilizacaoListaTecnica")]
    public class UtilizacaoListaTecnica : EntityTypeConfiguration<UtilizacaoListaTecnica>
    {
        public UtilizacaoListaTecnica() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_utilizacao { get; set; }

        [MaxLength(1)]
        //[Index("IX_UtilizacaoListaTecnica", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [MaxLength(20)]
        public string ds_utilizacao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
