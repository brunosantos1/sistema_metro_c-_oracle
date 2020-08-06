using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;

namespace PM.WebServices.Service
{
    public class StatusProgramacaoTremServices
    {
        public List<StatusProgramacaoTrem> GetAll()
        {
            try
            {
                return StatusProgramacaoTremOperationsExtensions.GetAll(Links.appN.StatusProgramacaoTremOperations).ToList();
            }
            catch (System.Exception)
            {
                return new List<StatusProgramacaoTrem>();
            }
        }

        public StatusProgramacaoTrem GetById(int id)
        {
            try
            {
                return StatusProgramacaoTremOperationsExtensions.GetById(Links.appN.StatusProgramacaoTremOperations, id);
            }
            catch (System.Exception)
            {
                return (new StatusProgramacaoTrem());
            }
        }

        public StatusProgramacaoTrem GetByCdSap(string sap)
        {
            try
            {
                return StatusProgramacaoTremOperationsExtensions.GetByCdSap(Links.appN.StatusProgramacaoTremOperations, sap);
            }
            catch (System.Exception)
            {
                return new StatusProgramacaoTrem();
            }
        }
    }
}
