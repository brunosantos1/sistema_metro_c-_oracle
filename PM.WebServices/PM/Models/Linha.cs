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

    public partial class Linha
    {
        /// <summary>
        /// Initializes a new instance of the Linha class.
        /// </summary>
        public Linha() { }

        /// <summary>
        /// Initializes a new instance of the Linha class.
        /// </summary>
        public Linha(int? idLinha = default(int?), string nmLinha = default(string), int? idCentroTrabalhoFk = default(int?), BaseModel baseModel = default(BaseModel), CentroTrabalho centroTrabalho = default(CentroTrabalho))
        {
            IdLinha = idLinha;
            NmLinha = nmLinha;
            IdCentroTrabalhoFk = idCentroTrabalhoFk;
            BaseModel = baseModel;
            CentroTrabalho = centroTrabalho;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_linha")]
        public int? IdLinha { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nm_linha")]
        public string NmLinha { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_centro_trabalho_fk")]
        public int? IdCentroTrabalhoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroTrabalho")]
        public CentroTrabalho CentroTrabalho { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.CentroTrabalho != null)
            {
                this.CentroTrabalho.Validate();
            }
        }
    }
}
