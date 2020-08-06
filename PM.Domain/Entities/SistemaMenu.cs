using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOSistemaMenu")]
    public class SistemaMenu : EntityTypeConfiguration<SistemaMenu>
    {
        public SistemaMenu() { BaseModel = new BaseModel(); }

        [Key]
        [Required]
        [Display(Name = "ID Registro")]
        public int id_menu { get; set; }

        [Required]
        [Display(Name = "Menu Pai")]
        public int id_pai { get; set; }

        [Display(Name = "Registro Ativo?")]
        public bool flg_ativo { get; set; }

        [Display(Name = "Tem Menu Filho?")]
        public bool flg_temfilho { get; set; }

        [Display(Name = "Cabeçalho de Menu?")]
        public bool flg_header { get; set; }

        [Required]
        [Display(Name = "Ordem de Exibição")]
        public int ordem_exibicao { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descrição do Menu")]
        public string ds_legenda { get; set; }

        [StringLength(500)]
        [Display(Name = "Nome classe CSS")]
        public string nm_estilo { get; set; }

        [StringLength(50)]
        [Display(Name = "Descrição Tooltip")]
        public string ds_tooltip { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "URL do menu")]
        public string ds_URL { get; set; }

        [Required]
        [StringLength(07)]
        [Display(Name = "URL Target")]
        public string nm_target { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
