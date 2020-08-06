using PM.Domain.Entities;
using PM.Domain.Interfaces.Services;
using PM.ServiceSoap.Models;
using System;
using System.Collections.Generic;

namespace PM.ServiceSoap
{
    public class WSDadosMestre : Base.Base, IWSDadosMestre
    {
        private IMasterDataListServices _iMasterDataListServices;
        private ILogServices _iErrorServices;

        public WSDadosMestre(IMasterDataListServices iMasterDataListServices, ILogServices iErrorServices)
        {
            _iMasterDataListServices = iMasterDataListServices;
            _iErrorServices = iErrorServices;
        }
        public void GetDadosMestre(List<FrotaModel> sFleet,
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
                                     List<PatioModel> sCourtyard)
        {
            string message = string.Empty;
            try
            {
                //if (sFleet != null)
                //{
                //    message += _iMasterDataListServices.ManageFleet(Mapper.Map<List<Frota>>(sFleet)).Message;
                //}

                //if (sTrain != null)
                //{
                //    message += _iMasterDataListServices.ManageTrain(Mapper.Map<List<Trem>>(sTrain)).Message;
                //}

                //if (sCar != null)
                //{
                //    message += _iMasterDataListServices.ManageCar(Mapper.Map<List<Carro>>(sCar)).Message;
                //}

                //if (sSystem != null)
                //{
                //    message += _iMasterDataListServices.ManageSystem(Mapper.Map<List<Sistema>>(sSystem)).Message;
                //}

                //if (sLine != null)
                //{
                //    message += _iMasterDataListServices.ManageLine(Mapper.Map<List<Linha>>(sLine)).Message;
                //}
                                          
                //if (sMaterials != null)
                //{
                //    message += _iMasterDataListServices.ManageMaterials(Mapper.Map<List<Materiais>>(sMaterials)).Message;
                //}

                //if (sDiagnosis != null)
                //{
                //    message += _iMasterDataListServices.ManageDiagnosis(Mapper.Map<List<Diagnostico>>(sDiagnosis)).Message;
                //}

                //if (sZone != null)
                //{
                //    message += _iMasterDataListServices.ManageZone(Mapper.Map<List<Zona>>(sZone)).Message;
                //}

                //if (sSymptoms != null)
                //{
                //    message += _iMasterDataListServices.ManageSymptoms(Mapper.Map<List<Sintoma>>(sSymptoms)).Message;
                //}

                //if (sCourtyard != null)
                //{
                //    message += _iMasterDataListServices.ManageCourtyard(Mapper.Map<List<Patio>>(sCourtyard)).Message;
                //}

                if (!string.IsNullOrEmpty(message.Trim()))
                    throw new Exception(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
