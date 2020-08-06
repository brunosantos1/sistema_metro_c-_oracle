using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class StatusPericiaServices
    {
        public IList<StatusPericia> GetAll()
        {
            try
            {
                return StatusPericiasExtensions.GetAll(Links.appN.StatusPericias);
            }
            catch (System.Exception e)
            {
                return null;
            }
        }

        public StatusPericia GetById(int id)
        {
            return StatusPericiasExtensions.GetById(Links.appN.StatusPericias, id);
        }

        public StatusPericia Add(StatusPericia _param)
        {
            return StatusPericiasExtensions.Add(Links.appN.StatusPericias, _param);
        }

        public StatusPericia Update(StatusPericia _param)
        {
            return StatusPericiasExtensions.Update(Links.appN.StatusPericias, _param);
        }
    }
}