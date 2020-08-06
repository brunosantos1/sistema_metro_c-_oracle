using PM.Data.UnitOfWork;
using PM.Domain.Interfaces.Services;

namespace PM.Services
{
    public class MasterDataListServices : ServicesBase, IMasterDataListServices
    {
        private ILogServices _iLogBusiness;
        public MasterDataListServices(IUnitOfWork unitOfWork, ILogServices iLogServices) : base(unitOfWork)
        {
            _iLogBusiness = iLogServices;
        }

        //public Response ManageFleet(List<Frota> listFleet)
        //{
        //    Response response = new Response();
        //    response.Status = Domain.Entities.Enum.Type.Success;
        //    DateTime start = DateTime.Now;

        //    foreach (var item in listFleet)
        //    {
        //        try
        //        {
        //            //var fleetData = UnitOfWork.FleetRepository.AsQueryable().Where(m => m.SalesOff == item.SalesOff && m.Language == item.Language);
        //            //if (fleetData.Any())
        //            //{
        //            //    Fleet fleetUpdate = fleetData.First();
        //            //    fleetUpdate.Description = item.Description;
        //            //    UnitOfWork.FleetRepository.Update(fleetUpdate);
        //            //}
        //            //else
        //                UnitOfWork.FrotaRepository.Add(item);

        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    try
        //    {
        //        UnitOfWork.Commit();
        //        response.Status = Domain.Entities.Enum.Type.Success;
        //        response.Message = "Registros gravados com sucesso:" + (DateTime.Now - start).ToString();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response = _iLogBusiness.ManageErrorLog(e, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response.Message += ex.Message;
        //    }
        //    finally
        //    {
        //        _iLogBusiness.InsertLog(new Log()
        //        {
        //            dt_date = DateTime.Now,
        //            lg_entity = "Fleet",
        //            lg_message = response.Message,
        //            lg_method = "ManageFleet",
        //            sv_interface = "WSMasterDataList",
        //            lg_type = response.Status.ToString()
        //        });
        //    }
        //    return response;
        //}

        //public Response ManageTrain(List<Trem> listTrain)
        //{
        //    Response response = new Response();
        //    response.Status = Domain.Entities.Enum.Type.Success;
        //    DateTime start = DateTime.Now;

        //    foreach (var item in listTrain)
        //    {
        //        try
        //        {
        //            //var trainData = UnitOfWork.TrainRepository.AsQueryable().Where(m => m.SalesOff == item.SalesOff && m.Language == item.Language);
        //            //if (trainData.Any())
        //            //{
        //            //    Train trainUpdate = trainData.First();
        //            //    trainUpdate.Description = item.Description;
        //            //    UnitOfWork.TrainRepository.Update(trainUpdate);
        //            //}
        //            //else
        //                UnitOfWork.TremRepository.Add(item);

        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    try
        //    {
        //        UnitOfWork.Commit();
        //        response.Status = Domain.Entities.Enum.Type.Success;
        //        response.Message = "Registros gravados com sucesso:" + (DateTime.Now - start).ToString();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response = _iLogBusiness.ManageErrorLog(e, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response.Message += ex.Message;
        //    }
        //    finally
        //    {
        //        _iLogBusiness.InsertLog(new Log()
        //        {
        //            dt_date = DateTime.Now,
        //            lg_entity = "Train",
        //            lg_message = response.Message,
        //            lg_method = "ManageTrain",
        //            sv_interface = "WSMasterDataList",
        //            lg_type = response.Status.ToString()
        //        });
        //    }
        //    return response;
        //}

        //public Response ManageCar(List<Carro> listCar)
        //{
        //    Response response = new Response();
        //    response.Status = Domain.Entities.Enum.Type.Success;
        //    DateTime start = DateTime.Now;

        //    foreach (var item in listCar)
        //    {
        //        try
        //        {
        //            //var carData = UnitOfWork.CarRepository.AsQueryable().Where(m => m.SalesOff == item.SalesOff && m.Language == item.Language);
        //            //if (carData.Any())
        //            //{
        //            //    Car carUpdate = carData.First();
        //            //    carUpdate.Description = item.Description;
        //            //    UnitOfWork.CarRepository.Update(salesOfficeUpdate);
        //            //}
        //            //else
        //                UnitOfWork.CarroRepository.Add(item);

        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    try
        //    {
        //        UnitOfWork.Commit();
        //        response.Status = Domain.Entities.Enum.Type.Success;
        //        response.Message = "Registros gravados com sucesso:" + (DateTime.Now - start).ToString();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response = _iLogBusiness.ManageErrorLog(e, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response.Message += ex.Message;
        //    }
        //    finally
        //    {
        //        _iLogBusiness.InsertLog(new Log()
        //        {
        //            dt_date = DateTime.Now,
        //            lg_entity = "Car",
        //            lg_message = response.Message,
        //            lg_method = "ManageCar",
        //            sv_interface = "WSMasterDataList",
        //            lg_type = response.Status.ToString()
        //        });
        //    }
        //    return response;
        //}

        //public Response ManageSystem(List<Sistema> listSystem)
        //{
        //    Response response = new Response();
        //    response.Status = Domain.Entities.Enum.Type.Success;
        //    DateTime start = DateTime.Now;

        //    foreach (var item in listSystem)
        //    {
        //        try
        //        {
        //            //var systemData = UnitOfWork.SystemRepository.AsQueryable().Where(m => m.SalesOff == item.SalesOff && m.Language == item.Language);
        //            //if (systemData.Any())
        //            //{
        //            //    SystemList systemUpdate = systemData.First();
        //            //    systemUpdate.Description = item.Description;
        //            //    UnitOfWork.SystemRepository.Update(systemUpdate);
        //            //}
        //            //else
        //                UnitOfWork.SistemasRepository.Add(item);

        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    try
        //    {
        //        UnitOfWork.Commit();
        //        response.Status = Domain.Entities.Enum.Type.Success;
        //        response.Message = "Registros gravados com sucesso:" + (DateTime.Now - start).ToString();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response = _iLogBusiness.ManageErrorLog(e, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response.Message += ex.Message;
        //    }
        //    finally
        //    {
        //        _iLogBusiness.InsertLog(new Log()
        //        {
        //            dt_date = DateTime.Now,
        //            lg_entity = "System",
        //            lg_message = response.Message,
        //            lg_method = "ManageSystem",
        //            sv_interface = "WSMasterDataList",
        //            lg_type = response.Status.ToString()
        //        });
        //    }
        //    return response;
        //}

        //public Response ManageLine(List<Linha> listLine)
        //{
        //    Response response = new Response();
        //    response.Status = Domain.Entities.Enum.Type.Success;
        //    DateTime start = DateTime.Now;

        //    foreach (var item in listLine)
        //    {
        //        try
        //        {
        //            //var lineData = UnitOfWork.LineRepository.AsQueryable().Where(m => m.SalesOff == item.SalesOff && m.Language == item.Language);
        //            //if (lineData.Any())
        //            //{
        //            //    Line lineUpdate = lineData.First();
        //            //    lineUpdate.Description = item.Description;
        //            //    UnitOfWork.LineRepository.Update(lineUpdate);
        //            //}
        //            //else
        //                UnitOfWork.LinhaRepository.Add(item);

        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    try
        //    {
        //        UnitOfWork.Commit();
        //        response.Status = Domain.Entities.Enum.Type.Success;
        //        response.Message = "Registros gravados com sucesso:" + (DateTime.Now - start).ToString();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response = _iLogBusiness.ManageErrorLog(e, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response.Message += ex.Message;
        //    }
        //    finally
        //    {
        //        _iLogBusiness.InsertLog(new Log()
        //        {
        //            dt_date = DateTime.Now,
        //            lg_entity = "Line",
        //            lg_message = response.Message,
        //            lg_method = "ManageLine",
        //            sv_interface = "WSMasterDataList",
        //            lg_type = response.Status.ToString()
        //        });
        //    }
        //    return response;
        //}

        //public Response ManageEquipment(List<OOEquipamento> listEquipment)
        //{
        //    Response response = new Response();
        //    response.Status = Domain.Entities.Enum.Type.Success;
        //    DateTime start = DateTime.Now;

        //    foreach (var item in listEquipment)
        //    {
        //        try
        //        {
        //            //var equipmentData = UnitOfWork.EquipmentRepository.AsQueryable().Where(m => m.SalesOff == item.SalesOff && m.Language == item.Language);
        //            //if (equipmentData.Any())
        //            //{
        //            //    Equipment equipmentUpdate = equipmentData.First();
        //            //    equipmentUpdate.Description = item.Description;
        //            //    UnitOfWork.EquipmentRepository.Update(equipmentUpdate);
        //            //}
        //            //else
        //                UnitOfWork.EquipamentoRepository.Add(item);

        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    try
        //    {
        //        UnitOfWork.Commit();
        //        response.Status = Domain.Entities.Enum.Type.Success;
        //        response.Message = "Registros gravados com sucesso:" + (DateTime.Now - start).ToString();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response = _iLogBusiness.ManageErrorLog(e, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response.Message += ex.Message;
        //    }
        //    finally
        //    {
        //        _iLogBusiness.InsertLog(new OOLog()
        //        {
        //            dt_date = DateTime.Now,
        //            lg_entity = "Equipment",
        //            lg_message = response.Message,
        //            lg_method = "ManageEquipment",
        //            sv_interface = "WSMasterDataList",
        //            lg_type = response.Status.ToString()
        //        });
        //    }
        //    return response;
        //}

        //public Response ManageLocal(List<OOLocal> listLocal)
        //{
        //    Response response = new Response();
        //    response.Status = Domain.Entities.Enum.Type.Success;
        //    DateTime start = DateTime.Now;

        //    foreach (var item in listLocal)
        //    {
        //        try
        //        {
        //            //var localData = UnitOfWork.LocalRepository.AsQueryable().Where(m => m.SalesOff == item.SalesOff && m.Language == item.Language);
        //            //if (localData.Any())
        //            //{
        //            //    Local localUpdate = localData.First();
        //            //    localUpdate.Description = item.Description;
        //            //    UnitOfWork.LocalRepository.Update(localUpdate);
        //            //}
        //            //else
        //                UnitOfWork.LocalRepository.Add(item);

        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    try
        //    {
        //        UnitOfWork.Commit();
        //        response.Status = Domain.Entities.Enum.Type.Success;
        //        response.Message = "Registros gravados com sucesso:" + (DateTime.Now - start).ToString();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response = _iLogBusiness.ManageErrorLog(e, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response.Message += ex.Message;
        //    }
        //    finally
        //    {
        //        _iLogBusiness.InsertLog(new OOLog()
        //        {
        //            dt_date = DateTime.Now,
        //            lg_entity = "Local",
        //            lg_message = response.Message,
        //            lg_method = "ManageLocal",
        //            sv_interface = "WSMasterDataList",
        //            lg_type = response.Status.ToString()
        //        });
        //    }
        //    return response;
        //}

        //public Response ManageMaterials(List<Materiais> listMaterials)
        //{
        //    Response response = new Response();
        //    response.Status = Domain.Entities.Enum.Type.Success;
        //    DateTime start = DateTime.Now;

        //    foreach (var item in listMaterials)
        //    {
        //        try
        //        {
        //            //var materialsData = UnitOfWork.MaterialsRepository.AsQueryable().Where(m => m.SalesOff == item.SalesOff && m.Language == item.Language);
        //            //if (materialsData.Any())
        //            //{
        //            //    Materials materialsUpdate = materialsData.First();
        //            //    materialsUpdate.Description = item.Description;
        //            //    UnitOfWork.MaterialsRepository.Update(materialsUpdate);
        //            //}
        //            //else
        //                UnitOfWork.MateriaisRepository.Add(item);

        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    try
        //    {
        //        UnitOfWork.Commit();
        //        response.Status = Domain.Entities.Enum.Type.Success;
        //        response.Message = "Registros gravados com sucesso:" + (DateTime.Now - start).ToString();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response = _iLogBusiness.ManageErrorLog(e, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response.Message += ex.Message;
        //    }
        //    finally
        //    {
        //        _iLogBusiness.InsertLog(new Log()
        //        {
        //            dt_date = DateTime.Now,
        //            lg_entity = "Materials",
        //            lg_message = response.Message,
        //            lg_method = "ManageMaterials",
        //            sv_interface = "WSMasterDataList",
        //            lg_type = response.Status.ToString()
        //        });
        //    }
        //    return response;
        //}

        //public Response ManageDiagnosis(List<Diagnostico> listDiagnosis)
        //{
        //    Response response = new Response();
        //    response.Status = Domain.Entities.Enum.Type.Success;
        //    DateTime start = DateTime.Now;

        //    foreach (var item in listDiagnosis)
        //    {
        //        try
        //        {
        //            //var diagnosisData = UnitOfWork.DiagnosisRepository.AsQueryable().Where(m => m.SalesOff == item.SalesOff && m.Language == item.Language);
        //            //if (diagnosisData.Any())
        //            //{
        //            //    Diagnosis diagnosisUpdate = diagnosisData.First();
        //            //    diagnosisUpdate.Description = item.Description;
        //            //    UnitOfWork.DiagnosisRepository.Update(diagnosisUpdate);
        //            //}
        //            //else
        //                UnitOfWork.DiagnosticoRepository.Add(item);

        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    try
        //    {
        //        UnitOfWork.Commit();
        //        response.Status = Domain.Entities.Enum.Type.Success;
        //        response.Message = "Registros gravados com sucesso:" + (DateTime.Now - start).ToString();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response = _iLogBusiness.ManageErrorLog(e, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response.Message += ex.Message;
        //    }
        //    finally
        //    {
        //        _iLogBusiness.InsertLog(new Log()
        //        {
        //            dt_date = DateTime.Now,
        //            lg_entity = "Diagnosis",
        //            lg_message = response.Message,
        //            lg_method = "ManageDiagnosis",
        //            sv_interface = "WSMasterDataList",
        //            lg_type = response.Status.ToString()
        //        });
        //    }
        //    return response;
        //}
                
        //public Response ManageZone(List<Zona> listZone)
        //{
        //    Response response = new Response();
        //    response.Status = Domain.Entities.Enum.Type.Success;
        //    DateTime start = DateTime.Now;

        //    foreach (var item in listZone)
        //    {
        //        try
        //        {
        //            //var zoneData = UnitOfWork.ZoneRepository.AsQueryable().Where(m => m.SalesOff == item.SalesOff && m.Language == item.Language);
        //            //if (zoneData.Any())
        //            //{
        //            //    Zone zoneUpdate = zoneData.First();
        //            //    zoneUpdate.Description = item.Description;
        //            //    UnitOfWork.ZoneRepository.Update(zoneUpdate);
        //            //}
        //            //else
        //                UnitOfWork.ZonaRepository.Add(item);

        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    try
        //    {
        //        UnitOfWork.Commit();
        //        response.Status = Domain.Entities.Enum.Type.Success;
        //        response.Message = "Registros gravados com sucesso:" + (DateTime.Now - start).ToString();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response = _iLogBusiness.ManageErrorLog(e, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response.Message += ex.Message;
        //    }
        //    finally
        //    {
        //        _iLogBusiness.InsertLog(new Log()
        //        {
        //            dt_date = DateTime.Now,
        //            lg_entity = "Zone",
        //            lg_message = response.Message,
        //            lg_method = "ManageZone",
        //            sv_interface = "WSMasterDataList",
        //            lg_type = response.Status.ToString()
        //        });
        //    }
        //    return response;
        //}

        //public Response ManageSymptoms(List<Sintoma> listSymptoms)
        //{
        //    Response response = new Response();
        //    response.Status = Domain.Entities.Enum.Type.Success;
        //    DateTime start = DateTime.Now;

        //    foreach (var item in listSymptoms)
        //    {
        //        try
        //        {
        //            //var symptomsData = UnitOfWork.SymptomsRepository.AsQueryable().Where(m => m.SalesOff == item.SalesOff && m.Language == item.Language);
        //            //if (symptomsData.Any())
        //            //{
        //            //    Symptoms symptomsUpdate = symptomsData.First();
        //            //    symptomsUpdate.Description = item.Description;
        //            //    UnitOfWork.SymptomsRepository.Update(symptomsUpdate);
        //            //}
        //            //else
        //                UnitOfWork.SintomasRepository.Add(item);

        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    try
        //    {
        //        UnitOfWork.Commit();
        //        response.Status = Domain.Entities.Enum.Type.Success;
        //        response.Message = "Registros gravados com sucesso:" + (DateTime.Now - start).ToString();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response = _iLogBusiness.ManageErrorLog(e, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response.Message += ex.Message;
        //    }
        //    finally
        //    {
        //        _iLogBusiness.InsertLog(new Log()
        //        {
        //            dt_date = DateTime.Now,
        //            lg_entity = "Symptoms",
        //            lg_message = response.Message,
        //            lg_method = "ManageSymptoms",
        //            sv_interface = "WSMasterDataList",
        //            lg_type = response.Status.ToString()
        //        });
        //    }
        //    return response;
        //}

        //public Response ManageCourtyard(List<Patio> listCourtyard)
        //{
        //    Response response = new Response();
        //    response.Status = Domain.Entities.Enum.Type.Success;
        //    DateTime start = DateTime.Now;

        //    foreach (var item in listCourtyard)
        //    {
        //        try
        //        {
        //            //var courtyardData = UnitOfWork.CourtyardRepository.AsQueryable().Where(m => m.SalesOff == item.SalesOff && m.Language == item.Language);
        //            //if (courtyardData.Any())
        //            //{
        //            //    Courtyard courtyardUpdate = courtyardData.First();
        //            //    courtyardUpdate.Description = item.Description;
        //            //    UnitOfWork.CourtyardRepository.Update(courtyardUpdate);
        //            //}
        //            //else
        //                UnitOfWork.PatioRepository.Add(item);

        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    try
        //    {
        //        UnitOfWork.Commit();
        //        response.Status = Domain.Entities.Enum.Type.Success;
        //        response.Message = "Registros gravados com sucesso:" + (DateTime.Now - start).ToString();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response = _iLogBusiness.ManageErrorLog(e, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        UnitOfWork.Rollback();
        //        response.Status = Domain.Entities.Enum.Type.Error;
        //        response.Message += ex.Message;
        //    }
        //    finally
        //    {
        //        _iLogBusiness.InsertLog(new Log()
        //        {
        //            dt_date = DateTime.Now,
        //            lg_entity = "Courtyard",
        //            lg_message = response.Message,
        //            lg_method = "ManageCourtyard",
        //            sv_interface = "WSMasterDataList",
        //            lg_type = response.Status.ToString()
        //        });
        //    }
        //    return response;
        //}
    }
}
