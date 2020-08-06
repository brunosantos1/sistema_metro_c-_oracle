using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OONivelAlerta")]
    public class NivelAlerta : EntityTypeConfiguration<NivelAlerta>
    {
        public NivelAlerta() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_nivel_alerta { get; set; }

        [ForeignKey("Material")]
        public int? id_material_fk { get; set; }    

        public int qt_alerta { get; set; }

        public int qt_critica { get; set; }

        public bool st_ativo { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public Material Material { get; set; }
    }
}