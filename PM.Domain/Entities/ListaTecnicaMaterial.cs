using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOListaTecnicaMaterial")]
    public class ListaTecnicaMaterial : EntityTypeConfiguration<ListaTecnicaMaterial>
    {
        public ListaTecnicaMaterial() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_lista_tecnica { get; set; }

        [ForeignKey("CentroLocalizacao")]
        public int? id_centro_fk { get; set; }

        [ForeignKey("Material")]
        public int? id_material_fk { get; set; }

        [StringLength(1)]
        public string cr_utilizacao { get; set; }

        public bool st_lt_tecnica { get; set; }

        public DateTime dt_valido_desde { get; set; }

        public DateTime dt_valido_ate { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public Material Material { get; set; }
        public CentroLocalizacao CentroLocalizacao { get; set; }
    }
}
