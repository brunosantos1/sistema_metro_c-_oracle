using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOUnidadeMedida")]
    public class UnidadeMedida : EntityTypeConfiguration<UnidadeMedida>
    {
        public UnidadeMedida() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_unidade_medida { get; set; }

        [MaxLength(3)]
        public string ds_unidade_medida { get; set; }

        [MaxLength(40)]
        public string tx_relativo_dimensao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
