using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOEmpregado")]
    public class Empregado : EntityTypeConfiguration<Empregado>
    {
        public Empregado() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_empregado { get; set; }

        [StringLength(12)]
        public string rg_empregado { get; set; }

        [StringLength(30)]
        [Required]
        public string nm_funcionario { get; set; }

        [StringLength(50)]
        [Required]
        public string sb_funcionario { get; set; }

        [StringLength(70)]
        [Required]
        public string em_usuario { get; set; }

        [ForeignKey("CentroCusto")]
        [Required]
        public int? id_ct_custo_fk { get; set; }

        [Required]
        public bool st_ativo { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public CentroCusto CentroCusto { get; set; }
    }
}
