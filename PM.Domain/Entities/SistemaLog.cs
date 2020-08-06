using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    public class SistemaLog
    {
        public SistemaLog() { BaseModel = new BaseModel(); }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}