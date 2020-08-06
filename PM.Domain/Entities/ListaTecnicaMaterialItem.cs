using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOListaTecnicaMaterialItem")]
    public class ListaTecnicaMaterialItem : EntityTypeConfiguration<ListaTecnicaMaterialItem>
    {
        public ListaTecnicaMaterialItem() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_lista_tecnica_item { get; set; }

        [ForeignKey("CentroLocalizacao")]
        public int? id_centro_fk { get; set; }

        [ForeignKey("Material")]
        public int? id_material_fk { get; set; }

        [StringLength(4)]
        public string nr_item { get; set; }
               
        [ForeignKey("CategoriaItem")]
        public int? id_cd_item_fk { get; set; }

        [StringLength(40)]
        public string ds_material_Linha1 { get; set; }

        [StringLength(40)]
        public string ds_material_Linha2 { get; set; }

        public decimal nr_quantidade { get; set; }

        [ForeignKey("UnidadeMedida")]
        public int? id_un_material_fk { get; set; }

        [ForeignKey("Documento")]
        public int? id_documento_fk { get; set; }

        [StringLength(3)]
        public string ds_parte_documento { get; set; }

        [StringLength(3)]
        public string vs_documento { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public Material Material { get; set; }
        public CentroLocalizacao CentroLocalizacao { get; set; }
        public Documento Documento { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public CategoriaItem CategoriaItem { get; set; }
    }
}
