using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OODocumento")]
    public class Documento : EntityTypeConfiguration<Documento>
    {
        public Documento() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_documento { get; set; }

        [ForeignKey("TipoDocumento")]
        public int? id_tp_documento_fk { get; set; }

        [StringLength(20)]
        public string ds_documento { get; set; }

        [ForeignKey("Nota")]
        public int? id_nota_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public TipoDocumento TipoDocumento { get; set; }
        public Nota Nota { get; set; }
    }
}