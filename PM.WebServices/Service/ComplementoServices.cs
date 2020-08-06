﻿using PM.WebServices;
using PM.WebServices.Models;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class ComplementoServices
    {
        public IList<Complemento> GetAll()
        {
            return ComplementosExtensions.GetAll(Links.appN.Complementos);
        }
        public IList<Complemento> GetBySistema(int idSistema)
        {
            return ComplementosExtensions.GetBySistema(Links.appN.Complementos, idSistema);
        }
        public Complemento GetById(int id)
        {
            return ComplementosExtensions.GetById(Links.appN.Complementos, id);
        }
        //public ComplementoViewModel GetAll()
        //{
        //    ComplementoViewModel complementoVM = new ComplementoViewModel();

        //    try
        //    {
        //        complementoVM.Complementos = ComplementosExtensions.GetAll(Links.appN.Complementos);
        //    }
        //    catch (System.Exception)
        //    {
        //        complementoVM.Complementos = new List<Complemento>();
        //    }

        //    return complementoVM;
        //}

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