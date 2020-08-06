using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PM.ServiceSoap
{
    [ServiceContract]
    public interface IWSOficina
    {
        [OperationContract]
        void DoWork();
    }
}
