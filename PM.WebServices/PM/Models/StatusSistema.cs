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

    public partial class StatusSistema
    {
        /// <summary>
        /// Initializes a new instance of the StatusSistema class.
        /// </summary>
        public StatusSistema() { }

        /// <summary>
        /// Initializes a new instance of the StatusSistema class.
        /// </summary>
        public StatusSistema(int? idStSistema = default(int?), string dsStSistema = default(string), string cdSap = default(string), BaseModel baseModel = default(BaseModel))
        {
            IdStSistema = idStSistema;
            DsStSistema = dsStSistema;
            CdSap = cdSap;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_st_sistema")]
        public int? IdStSistema { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_st_sistema")]
        public string DsStSistema { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_sap")]
        public string CdSap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.DsStSistema != null)
            {
                if (this.DsStSistema.Length > 150)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsStSistema", 150);
                }
                if (this.DsStSistema.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsStSistema", 0);
                }
            }
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
        }
    }
}
