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

    public partial class MAP
    {
        /// <summary>
        /// Initializes a new instance of the MAP class.
        /// </summary>
        public MAP() { }

        /// <summary>
        /// Initializes a new instance of the MAP class.
        /// </summary>
        public MAP(int? idMap = default(int?), int? idOperacaoFk = default(int?), string dnMap = default(string), BaseModel baseModel = default(BaseModel), OperacaoOrdem operacaoOrdem = default(OperacaoOrdem))
        {
            IdMap = idMap;
            IdOperacaoFk = idOperacaoFk;
            DnMap = dnMap;
            BaseModel = baseModel;
            OperacaoOrdem = operacaoOrdem;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_map")]
        public int? IdMap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_operacao_fk")]
        public int? IdOperacaoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dn_map")]
        public string DnMap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "OperacaoOrdem")]
        public OperacaoOrdem OperacaoOrdem { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.DnMap != null)
            {
                if (this.DnMap.Length > 40)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DnMap", 40);
                }
                if (this.DnMap.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DnMap", 0);
                }
            }
            if (this.OperacaoOrdem != null)
            {
                this.OperacaoOrdem.Validate();
            }
        }
    }
}
