using PM.WebServices;
using PM.WebServices.Models;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class StatusCopeseServices
    {
        public IList<StatusCopese> GetAll()
        {
            return StatusCopesesExtensions.GetAll(Links.appN.StatusCopeses);
        }
    }
}
