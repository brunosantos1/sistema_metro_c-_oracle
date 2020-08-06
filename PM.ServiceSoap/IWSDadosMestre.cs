using PM.ServiceSoap.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace PM.ServiceSoap
{
    [ServiceContract]
    public interface IWSDadosMestre
    {
        [OperationContract(IsOneWay = true)]
        void GetDadosMestre(List<FrotaModel> sFleet, 
                                     List<TremModel> sTrain, 
                                     List<CarroModel> sCar, 
                                     List<SistemaModel> sSystem, 
                                     List<LinhaModel> sLine, 
                                     List<EquipamentoModel> sEquipment,
                                     List<LocalModel> sLocal,
                                     List<MateriaisModel> sMaterials,
                                     List<DiagnosticoModel> sDiagnosis,
                                     List<ZonaModel> sZone,
                                     List<SintomaModel> sSymptoms,
                                     List<PatioModel> sCourtyard);
    }
}
