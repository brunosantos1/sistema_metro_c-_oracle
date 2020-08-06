using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace PM.LogAndAlert.Models
{
    [Table("OOSistemaPerfil")]
    public class SistemaPerfil //: EntityTypeConfiguration<OOSistemaPerfil>
    {
        [Key]
        [Required]
        [Display(Name = "ID Registro")]
        public int id_perfil { get; set; }

        [Display(Name = "Registro Ativo?")]
        public bool flg_ativo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descrição")]
        public string ds_descricao { get; set; }
        public virtual List<SistemaPerfilItem> Item { get; set; }

        [Required]
        [StringLength(8000)]
        [Display(Name = "HTML Menu")]
        public string HTMLStringMenu { get; set; }

        [Display(Name = "Num. Usuários")]
        public int num_Usuarios { get; set; }

        [Display(Name = "Usuários Logados ")]
        public int num_Usuarios_logados{ get; set; }
    }

    [Table("OOSistemaPerfilItem")]
    public class SistemaPerfilItem //: EntityTypeConfiguration<OOSistemaPerfilItem>
    {
        [Key]
        [Required]
        [Display(Name = "ID Registro")]
        public int id_perfilItem { get; set; }
        [Display(Name = "ID Perfil")]
        public int id_perfil { get; set; }

        [Display(Name = "Acessar Módulo")]
        public bool flgAcessar { get; set; }
        [Display(Name = "Incluir?")]
        public bool flgIncluir { get; set; }
        [Display(Name = "Alterar?")]
        public bool flgAlterar { get; set; }
        [Display(Name = "Exportar?")]
        public bool flgExportar { get; set; }
        [Display(Name = "Imprimir?")]
        public bool flgImprimir { get; set; }
    }
}
