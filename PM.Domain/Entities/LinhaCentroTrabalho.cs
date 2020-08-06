using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOLinhaCentroTrabalho")]
    public class LinhaCentroTrabalho : EntityTypeConfiguration<LinhaCentroTrabalho>
    {
        public LinhaCentroTrabalho() { BaseModel = new BaseModel(); }

        [Key, Column(Order = 0)]
        [ForeignKey("Linha")]
        public int? id_linha_fk { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("CentroTrabalho")]
        public int? id_ct_trabalho_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public Linha Linha { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
    }
}
