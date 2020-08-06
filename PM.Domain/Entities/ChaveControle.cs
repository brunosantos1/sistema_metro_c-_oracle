using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOChaveControle")]
    public class ChaveControle : EntityTypeConfiguration<ChaveControle>
    {
        public ChaveControle() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_ch_controle { get; set; }

        [MaxLength(150)]
        public string ds_chave_controle { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
