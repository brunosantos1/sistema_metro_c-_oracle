using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOMaterial")]
    public class Material : EntityTypeConfiguration<Material>
    {
        public Material() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_material { get; set; }

        [StringLength(50)]
        public string ds_material { get; set; }

        [StringLength(4)]
        public string tp_material { get; set; }

        [StringLength(3)]
        public string cd_unidade_medida { get; set; }

        [StringLength(30)]
        public string ds_unidade_medida { get; set; }

        [StringLength(4)]
        public string cd_classe_avaliacao { get; set; }
                
        public DateTime dt_criacao { get; set; }

        [StringLength(60)]
        public string cd_material_antigo { get; set; }

        [StringLength(10)]
        public string rg_empregado { get; set; }

        public DateTime dt_ultima_alteracao { get; set; }

        [StringLength(30)]
        public string ds_tipo_material { get; set; }

        [StringLength(2000)]
        public string ds_detalhada { get; set; }

        [StringLength(12)]
        public string cd_sap { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
