using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOLogs")]
    public class Log : EntityTypeConfiguration<Log>
    {
        public Log() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_log { get; set; }

        [StringLength(40)]
        public string sv_interface { get; set; }

        [StringLength(40)]
        public string lg_type { get; set; }

        [StringLength(40)]
        public string lg_entity { get; set; }

        [StringLength(40)]
        public string lg_method { get; set; }

        public string lg_message { get; set; }

        public DateTime dt_date { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
