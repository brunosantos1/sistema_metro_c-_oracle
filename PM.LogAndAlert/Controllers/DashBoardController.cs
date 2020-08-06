using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.LogAndAlert.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public string gr_NotasAbertasPendentes(string data1, string data2)
        {
            // coleções de agrupamento
            List<DashBoardComplexData> lstComplexData = new List<DashBoardComplexData>();
            DashBoardComplexData oComplexData;
            List<DashBoardComplexData.Dados> lsod = new List<DashBoardComplexData.Dados>();
            DashBoardComplexData.Dados oDados = new DashBoardComplexData.Dados();
            List<DashBoardComplexData.ValoresGrafico> lstValoresGrafico = new List<DashBoardComplexData.ValoresGrafico>();
            DashBoardComplexData.ValoresGrafico oValoresGrafico = new DashBoardComplexData.ValoresGrafico();
            
            oDados = new DashBoardComplexData.Dados(); lstValoresGrafico = new List<DashBoardComplexData.ValoresGrafico>();
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 10))); oValoresGrafico.V = 974; lstValoresGrafico.Add(oValoresGrafico);
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 11))); oValoresGrafico.V = 32; lstValoresGrafico.Add(oValoresGrafico);
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 12))); oValoresGrafico.V = 842; lstValoresGrafico.Add(oValoresGrafico);
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 13))); oValoresGrafico.V = 552; lstValoresGrafico.Add(oValoresGrafico);
            oDados.X            = lstValoresGrafico; oComplexData = new DashBoardComplexData(); oComplexData.label = "Material Rodante"; oComplexData.totalizador = 2400; oComplexData.color = "#3498DB"; oComplexData.data = lstValoresGrafico; lstComplexData.Add(oComplexData);

            oDados = new DashBoardComplexData.Dados(); lstValoresGrafico = new List<DashBoardComplexData.ValoresGrafico>();
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 10))); oValoresGrafico.V = 754; lstValoresGrafico.Add(oValoresGrafico);
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 11))); oValoresGrafico.V = 248; lstValoresGrafico.Add(oValoresGrafico);
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 12))); oValoresGrafico.V = 878; lstValoresGrafico.Add(oValoresGrafico);
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 13))); oValoresGrafico.V = 647; lstValoresGrafico.Add(oValoresGrafico);
            oDados.X = lstValoresGrafico; oComplexData = new DashBoardComplexData(); oComplexData.label = "Equipamento Fixo"; oComplexData.totalizador = 100 ; oComplexData.color = "#1ABB9C"; oComplexData.data = lstValoresGrafico; lstComplexData.Add(oComplexData);

            oDados = new DashBoardComplexData.Dados(); lstValoresGrafico = new List<DashBoardComplexData.ValoresGrafico>();
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 10))); oValoresGrafico.V = 854; lstValoresGrafico.Add(oValoresGrafico);
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 11))); oValoresGrafico.V = 332; lstValoresGrafico.Add(oValoresGrafico);
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 12))); oValoresGrafico.V = 567; lstValoresGrafico.Add(oValoresGrafico);
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 13))); oValoresGrafico.V = 952; lstValoresGrafico.Add(oValoresGrafico);
            oDados.X = lstValoresGrafico; oComplexData = new DashBoardComplexData(); oComplexData.label = "Manobras"; oComplexData.totalizador = 500 ; oComplexData.color = "#E74C3C"; oComplexData.data = lstValoresGrafico; lstComplexData.Add(oComplexData);

            oDados = new DashBoardComplexData.Dados(); lstValoresGrafico = new List<DashBoardComplexData.ValoresGrafico>();
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 10))); oValoresGrafico.V = 964; lstValoresGrafico.Add(oValoresGrafico);
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 11))); oValoresGrafico.V = 732; lstValoresGrafico.Add(oValoresGrafico);
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 12))); oValoresGrafico.V = 487; lstValoresGrafico.Add(oValoresGrafico);
            oValoresGrafico = new DashBoardComplexData.ValoresGrafico(); oValoresGrafico.T = GetJavascriptTimeStamp((new DateTime(2019, 09, 13))); oValoresGrafico.V = 52; lstValoresGrafico.Add(oValoresGrafico);
            oDados.X = lstValoresGrafico; oComplexData = new DashBoardComplexData(); oComplexData.label = "Oficinas"; oComplexData.totalizador = 1000; oComplexData.color = "#9B59B6"; oComplexData.data = lstValoresGrafico; lstComplexData.Add(oComplexData);

            var json = JsonConvert.SerializeObject(lstComplexData, Formatting.Indented);
            return json.ToString();
        }

        public string gr_SaldoUltimoSemestre()
        {
            return "".ToString();
        }
        public string gr_SaldoUltimoMes()
        {
            return "".ToString();
        }
        private Int64 GetJavascriptTimeStamp(DateTime dt)
        {
            var nineteenseventy = new DateTime(1970, 1, 1);
            var timeElapsed = (dt.ToUniversalTime() - nineteenseventy);
            return (Int64)(timeElapsed.TotalMilliseconds + 0.5);
        }
    }

    public class DashBoardComplexData
    {
        public string label { get; set; }        
        public List<ValoresGrafico> data { get; set; }
        public string color { get; set; }
        public double totalizador { get; set; }
        public struct Dados
        {
            public List<ValoresGrafico> X;
        }

        public struct ValoresGrafico
        {
            [JsonProperty(PropertyName = "0")]
            public Int64 T;
            [JsonProperty(PropertyName = "1")]
            public double V;
        }
    }
}