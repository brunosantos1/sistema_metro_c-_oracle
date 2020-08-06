using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOLocalizacao")]
    public class Localizacao : EntityTypeConfiguration<Localizacao>
    {
        public Localizacao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_localizacao { get; set; }

        [ForeignKey("CentroLocalizacao")]
        public int? id_ct_localizacao_fk { get; set; }

        [StringLength(4)]
        //[Index("IX_Localizacao", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(30)]
        public string ds_localizacao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public CentroLocalizacao CentroLocalizacao { get; set; }
    }
}