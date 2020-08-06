using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOProgramacaoEF")]
    public class ProgramacaoEF : EntityTypeConfiguration<ProgramacaoEF>
    {
        public ProgramacaoEF() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id_programacao { get; set; }

        public int? nr_programacao { get; set; }

        public int? nr_ano { get; set; }

        public int? nr_semana { get; set; }

        [ForeignKey("CentroLocalizacao")]
        public int? id_centro { get; set; }
        [ForeignKey("CentroTrabalho")]
        public int? id_centro_trabalho { get; set; }
        [ForeignKey("Empregado")]
        public int? id_empregado { get; set; }

        public DateTime dt_realizacao { get; set; } 

        public int id_status { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public CentroLocalizacao CentroLocalizacao { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }

        public Empregado Empregado { get; set; }

    }
}