using PM.WebServices;
using PM.WebServices.Models;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class ZonaServices
    {
        public IList<Zona> GetAll()
        {
            return ZonasExtensions.GetAll(Links.appN.Zonas);
        }

        //public ComplementoViewModel GetById(int id)
        //{
        //    ComplementoViewModel complementoVM = new ComplementoViewModel();

        //    try
        //    {
        //        complementoVM.Complemento = ComplementosExtensions.GetById(Links.appN.Complementos, id);
        //    }
        //    catch (System.Exception)
        //    {
        //        complementoVM.Complemento = new Complemento();
        //    }
        //    return complementoVM;
        //}

        //public async Task<UFViewModel> PostAsync(UFViewModel _param)
        //{
        //    return await UFsExtensions.PostAsync(Links.appN.UFs, _param);
        //}

        //public async Task<UFViewModel> GetAllAsync()
        //{
        //    UFViewModel uFVM = new UFViewModel();
        //    uFVM.UFs = await UFsExtensions.GetAllAsync(Links.appN.UFs);
        //    return uFVM;
        //}

        //public async Task<UFViewModel> GetByPaisAsync(long paisID)
        //{
        //    UFViewModel uFVM = new UFViewModel();
        //    uFVM.UFs = await UFsExtensions.GetByPaisAsync(Links.appN.UFs, paisID);
        //    return uFVM;
        //}

        //public async Task<UFViewModel> GetByIDAsync(long id)
        //{
        //    UFViewModel vm = new UFViewModel();
        //    vm.UF = await UFsExtensions.GetByIDAsync(Links.appN.UFs, id); 
        //    return vm;
        //}

        //public async Task<ServiceModels.UFViewModel> DeleteByIDAsync(long id)
        //{
        //    var retornoApi = await UFsExtensions.DeleteByIDAsync(Links.appN.UFs, id);
        //    return retornoApi;
        //}
    }
}
