using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOStatusUsuario")]
    public class StatusUsuario : EntityTypeConfiguration<StatusUsuario>
    {
        public StatusUsuario() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_st_usuario { get; set; }

        [StringLength(4)]
        public string cd_sap { get; set; }

        [StringLength(150)]
        public string ds_st_usuario { get; set; }

        public bool st_acumulativo { get; set; }

        public virtual ICollection<Nota> Notas { get; set; }

        public virtual ICollection<Ordem> Ordens { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}