using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOOrdem")]
    public class Ordem : EntityTypeConfiguration<Ordem>
    {
        public Ordem() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_ordem { get; set; }

        [ForeignKey("Nota")]
        public int? id_nota_fk { get; set; }

        public DateTime dt_hora_ordem { get; set; }

        [ForeignKey("StatusSistema")]
        public int? id_st_sistema_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public Nota Nota { get; set; }
        public StatusSistema StatusSistema { get; set; }
        public List<OperacaoOrdem> Operacoes { get; set; }
        public virtual ICollection<StatusUsuario> StatusUsuarios { get; set; }
    }
}