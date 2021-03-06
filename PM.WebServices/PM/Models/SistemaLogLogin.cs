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

    public partial class SistemaLogLogin
    {
        /// <summary>
        /// Initializes a new instance of the SistemaLogLogin class.
        /// </summary>
        public SistemaLogLogin() { }

        /// <summary>
        /// Initializes a new instance of the SistemaLogLogin class.
        /// </summary>
        public SistemaLogLogin(DateTime dtOcorrencia, string dsIpaddress, string nmMachine, string nmLogonUserIdentityName, string idLogonUserIdentityToken, string nmBrowserName, string nmBrowserVersion, bool isBrowserCookies, string nmPlatforma, bool isWin16, bool isWin32, string dsUrlFull, int idAplicacao, int? idLogLogin = default(int?), BaseModel baseModel = default(BaseModel))
        {
            IdLogLogin = idLogLogin;
            DtOcorrencia = dtOcorrencia;
            DsIpaddress = dsIpaddress;
            NmMachine = nmMachine;
            NmLogonUserIdentityName = nmLogonUserIdentityName;
            IdLogonUserIdentityToken = idLogonUserIdentityToken;
            NmBrowserName = nmBrowserName;
            NmBrowserVersion = nmBrowserVersion;
            IsBrowserCookies = isBrowserCookies;
            NmPlatforma = nmPlatforma;
            IsWin16 = isWin16;
            IsWin32 = isWin32;
            DsUrlFull = dsUrlFull;
            IdAplicacao = idAplicacao;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_log_login")]
        public int? IdLogLogin { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_ocorrencia")]
        public DateTime DtOcorrencia { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_ipaddress")]
        public string DsIpaddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nm_machine")]
        public string NmMachine { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nm_logon_user_identity_name")]
        public string NmLogonUserIdentityName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_logon_user_identity_token")]
        public string IdLogonUserIdentityToken { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nm_browser_name")]
        public string NmBrowserName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nm_browser_version")]
        public string NmBrowserVersion { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "is_browser_cookies")]
        public bool IsBrowserCookies { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nm_platforma")]
        public string NmPlatforma { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "is_win16")]
        public bool IsWin16 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "is_win32")]
        public bool IsWin32 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_url_full")]
        public string DsUrlFull { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_aplicacao")]
        public int IdAplicacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (DsIpaddress == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DsIpaddress");
            }
            if (NmMachine == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "NmMachine");
            }
            if (NmLogonUserIdentityName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "NmLogonUserIdentityName");
            }
            if (IdLogonUserIdentityToken == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "IdLogonUserIdentityToken");
            }
            if (NmBrowserName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "NmBrowserName");
            }
            if (NmBrowserVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "NmBrowserVersion");
            }
            if (NmPlatforma == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "NmPlatforma");
            }
            if (DsUrlFull == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DsUrlFull");
            }
        }
    }
}
