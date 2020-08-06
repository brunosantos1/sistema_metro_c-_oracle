using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOPatio")]
    public class Patio : EntityTypeConfiguration<Patio>
    {
        public Patio() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_patio { get; set; }

        [StringLength(12)]
        public string cd_sap { get; set; }

        [StringLength(30)]
        public string ds_patio { get; set; }

        [StringLength(60)]
        public string ds_rua { get; set; }

        [StringLength(10)]
        public string nr_endereco { get; set; }

        [StringLength(10)]
        public string nr_cep { get; set; }

        [StringLength(30)]
        public string nr_telefone { get; set; }

        [StringLength(10)]
        public string nr_ramal { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
