using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;

namespace PM.Web.ViewModel
{   
    public class BaseViewModel
    {
        public string Versao { get; set; }

        public List<string> msgRetorno { get; set; }

    }
}


