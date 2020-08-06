using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOEstruturaCentroTrabalho")]
    public class EstruturaCentroTrabalho : EntityTypeConfiguration<EstruturaCentroTrabalho>
    {
        public EstruturaCentroTrabalho() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_est_ct_trabalho { get; set; }

        [ForeignKey("CtTrab1")]
        public int? id_ct_superior { get; set; }

        [ForeignKey("CtTrab2")]
        public int? id_ct_subordinado { get; set; }

        public bool ic_imediato { get; set; }


        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public CentroTrabalho CtTrab1 { get; set; }
        public CentroTrabalho CtTrab2 { get; set; }
        
    }
}
