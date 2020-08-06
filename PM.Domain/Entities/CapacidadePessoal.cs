using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCapacidadePessoal")]
    public class CapacidadePessoal : EntityTypeConfiguration<CapacidadePessoal>
    {
        public CapacidadePessoal() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_capacidade_pessoal { get; set; }

        [ForeignKey("Capacidade")]
        public int? id_capacidade_fk { get; set; }

        [ForeignKey("Empregado")]
        public int? id_empregado_fk { get; set; }

        public DateTime dt_inicio { get; set; }

        public DateTime dt_fim { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public Capacidade Capacidade { get; set; }
        public Empregado Empregado { get; set; }
    }
}
