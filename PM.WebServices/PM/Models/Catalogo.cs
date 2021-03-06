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

    public partial class Catalogo
    {
        /// <summary>
        /// Initializes a new instance of the Catalogo class.
        /// </summary>
        public Catalogo() { }

        /// <summary>
        /// Initializes a new instance of the Catalogo class.
        /// </summary>
        public Catalogo(int? idCatalogo = default(int?), string cdSap = default(string), IList<GrupoCode> gruposCode = default(IList<GrupoCode>), IList<Perfil> perfis = default(IList<Perfil>), BaseModel baseModel = default(BaseModel))
        {
            IdCatalogo = idCatalogo;
            CdSap = cdSap;
            GruposCode = gruposCode;
            Perfis = perfis;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_catalogo")]
        public int? IdCatalogo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_sap")]
        public string CdSap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "GruposCode")]
        public IList<GrupoCode> GruposCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Perfis")]
        public IList<Perfil> Perfis { get; set; }

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
                if (this.CdSap.Length > 9)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdSap", 9);
                }
                if (this.CdSap.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdSap", 0);
                }
            }
            if (this.GruposCode != null)
            {
                foreach (var element in this.GruposCode)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (this.Perfis != null)
            {
                foreach (var element1 in this.Perfis)
                {
                    if (element1 != null)
                    {
                        element1.Validate();
                    }
                }
            }
        }
    }
}
