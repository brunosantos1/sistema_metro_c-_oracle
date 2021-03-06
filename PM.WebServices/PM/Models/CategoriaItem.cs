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

    public partial class CategoriaItem
    {
        /// <summary>
        /// Initializes a new instance of the CategoriaItem class.
        /// </summary>
        public CategoriaItem() { }

        /// <summary>
        /// Initializes a new instance of the CategoriaItem class.
        /// </summary>
        public CategoriaItem(int? idCategoriaItem = default(int?), string dsCategoriaItem = default(string), BaseModel baseModel = default(BaseModel))
        {
            IdCategoriaItem = idCategoriaItem;
            DsCategoriaItem = dsCategoriaItem;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_categoria_item")]
        public int? IdCategoriaItem { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_categoria_item")]
        public string DsCategoriaItem { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.DsCategoriaItem != null)
            {
                if (this.DsCategoriaItem.Length > 50)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsCategoriaItem", 50);
                }
                if (this.DsCategoriaItem.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsCategoriaItem", 0);
                }
            }
        }
    }
}
