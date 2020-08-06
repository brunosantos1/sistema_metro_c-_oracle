using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCentroLocalizacao")]
    public class CentroLocalizacao : EntityTypeConfiguration<CentroLocalizacao>
    {
        public CentroLocalizacao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_ct_localizacao { get; set; }

        [StringLength(4)]
        //[Index("IX_CentroLocalizacao", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }
        
        [StringLength(50)]
        public string ds_ct_localizacao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
