using System.Configuration;
using System.Web.Hosting;
using System.Web.Http;

namespace PM.ServiceApi
{
    public class GlobalConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //ConfigurationFileMap fileMap = new ConfigurationFileMap(HostingEnvironment.MapPath("ServiceApi.config"));
            //Configuration configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
        }
    }
}