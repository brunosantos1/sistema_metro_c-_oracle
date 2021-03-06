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

    public partial class CalendarioFabrica
    {
        /// <summary>
        /// Initializes a new instance of the CalendarioFabrica class.
        /// </summary>
        public CalendarioFabrica() { }

        /// <summary>
        /// Initializes a new instance of the CalendarioFabrica class.
        /// </summary>
        public CalendarioFabrica(int? idCalendarioFabrica = default(int?), DateTime? dtValidoDesdeAno = default(DateTime?), DateTime? dtValidoAteAno = default(DateTime?), bool? tbSegunda = default(bool?), bool? tbTerca = default(bool?), bool? tbQuarta = default(bool?), bool? tbQuinta = default(bool?), bool? tbSexta = default(bool?), bool? tbSabado = default(bool?), bool? tbDomingo = default(bool?), bool? tbFeriado = default(bool?), DateTime? dtAtivoDesdeAno = default(DateTime?), DateTime? dtAtivoAteAno = default(DateTime?), BaseModel baseModel = default(BaseModel))
        {
            IdCalendarioFabrica = idCalendarioFabrica;
            DtValidoDesdeAno = dtValidoDesdeAno;
            DtValidoAteAno = dtValidoAteAno;
            TbSegunda = tbSegunda;
            TbTerca = tbTerca;
            TbQuarta = tbQuarta;
            TbQuinta = tbQuinta;
            TbSexta = tbSexta;
            TbSabado = tbSabado;
            TbDomingo = tbDomingo;
            TbFeriado = tbFeriado;
            DtAtivoDesdeAno = dtAtivoDesdeAno;
            DtAtivoAteAno = dtAtivoAteAno;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_calendario_fabrica")]
        public int? IdCalendarioFabrica { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_valido_desde_ano")]
        public DateTime? DtValidoDesdeAno { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_valido_ate_ano")]
        public DateTime? DtValidoAteAno { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tb_segunda")]
        public bool? TbSegunda { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tb_terca")]
        public bool? TbTerca { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tb_quarta")]
        public bool? TbQuarta { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tb_quinta")]
        public bool? TbQuinta { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tb_sexta")]
        public bool? TbSexta { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tb_sabado")]
        public bool? TbSabado { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tb_domingo")]
        public bool? TbDomingo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tb_feriado")]
        public bool? TbFeriado { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_ativo_desde_ano")]
        public DateTime? DtAtivoDesdeAno { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_ativo_ate_ano")]
        public DateTime? DtAtivoAteAno { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

    }
}
