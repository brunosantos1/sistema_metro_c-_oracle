using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOMaoDeObra")]
    public class MaoDeObra : EntityTypeConfiguration<MaoDeObra>
    {
        public MaoDeObra() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_maodeobra { get; set; }

        [ForeignKey("OperacaoOrdem")]
        public int? id_operacao_fk { get; set; }

        [ForeignKey("CentroTrabalho")]
        public int? id_centro_trabalho_fk { get; set; }

        [ForeignKey("Tarifa")]
        public int? id_tarifa_fk { get; set; }

        [ForeignKey("ChaveControle")]
        public int? id_chavecontrole_fk { get; set; }

        public DateTime dt_hora_maodeobra { get; set; }

        public DateTime dt_execucao { get; set; }

        [ForeignKey("Empregado")]
        public int? id_empregado_fk { get; set; }

        public float tm_preparo { get; set; }

        public float tm_deslocamento { get; set; }

        public float tm_acesso { get; set; }

        public float tm_execucao { get; set; }

        public float dr_duracao { get; set; }

        [ForeignKey("UnidadeMedida")]
        public int? id_unidade_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public Tarifa Tarifa { get; set; }
        public OperacaoOrdem OperacaoOrdem { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
        public ChaveControle ChaveControle { get; set; }
        public Empregado Empregado { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}