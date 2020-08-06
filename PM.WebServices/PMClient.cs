using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.WebServices
{
    public partial class PMClient : ServiceClient<PMClient>, IPMClient
    {
        public PMClient(Uri Base)
        {
            this.BaseUri = Base;
            this.Initialize();
        }
    }
}