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

    public partial class Documento
    {
        /// <summary>
        /// Initializes a new instance of the Documento class.
        /// </summary>
        public Documento() { }

        /// <summary>
        /// Initializes a new instance of the Documento class.
        /// </summary>
        public Documento(int? idDocumento = default(int?), int? idTpDocumentoFk = default(int?), string dsDocumento = default(string), int? idNotaFk = default(int?), BaseModel baseModel = default(BaseModel), TipoDocumento tipoDocumento = default(TipoDocumento), Nota nota = default(Nota))
        {
            IdDocumento = idDocumento;
            IdTpDocumentoFk = idTpDocumentoFk;
            DsDocumento = dsDocumento;
            IdNotaFk = idNotaFk;
            BaseModel = baseModel;
            TipoDocumento = tipoDocumento;
            Nota = nota;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_documento")]
        public int? IdDocumento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_tp_documento_fk")]
        public int? IdTpDocumentoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_documento")]
        public string DsDocumento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_nota_fk")]
        public int? IdNotaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TipoDocumento")]
        public TipoDocumento TipoDocumento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Nota")]
        public Nota Nota { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.DsDocumento != null)
            {
                if (this.DsDocumento.Length > 20)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsDocumento", 20);
                }
                if (this.DsDocumento.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsDocumento", 0);
                }
            }
            if (this.TipoDocumento != null)
            {
                this.TipoDocumento.Validate();
            }
            if (this.Nota != null)
            {
                this.Nota.Validate();
            }
        }
    }
}
