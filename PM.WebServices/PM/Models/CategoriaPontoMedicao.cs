﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace PM.WebServices.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class CategoriaPontoMedicao
    {
        /// <summary>
        /// Initializes a new instance of the CategoriaPontoMedicao class.
        /// </summary>
        public CategoriaPontoMedicao() { }

        /// <summary>
        /// Initializes a new instance of the CategoriaPontoMedicao class.
        /// </summary>
        public CategoriaPontoMedicao(int? idCgPontoMedicao = default(int?), string cdSap = default(string), string dsCgPontoMedicao = default(string), BaseModel baseModel = default(BaseModel))
        {
            IdCgPontoMedicao = idCgPontoMedicao;
            CdSap = cdSap;
            DsCgPontoMedicao = dsCgPontoMedicao;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_cg_ponto_medicao")]
        public int? IdCgPontoMedicao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_sap")]
        public string CdSap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_cg_ponto_medicao")]
        public string DsCgPontoMedicao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.CdSap != null)
            {
                if (this.CdSap.Length > 5)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdSap", 5);
                }
                if (this.CdSap.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdSap", 0);
                }
            }
            if (this.DsCgPontoMedicao != null)
            {
                if (this.DsCgPontoMedicao.Length > 50)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsCgPontoMedicao", 50);
                }
                if (this.DsCgPontoMedicao.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsCgPontoMedicao", 0);
                }
            }
        }
    }
}
