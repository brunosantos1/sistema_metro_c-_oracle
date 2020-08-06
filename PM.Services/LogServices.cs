using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.RS;
using PM.Domain.Interfaces.Services;
using System;
using System.Data.Entity.Validation;

namespace PM.Services
{
    public class LogServices : ServicesBase, ILogServices
    {
        public LogServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public Response ManageErrorLog(DbEntityValidationException dbEntityValidationException, Response response)
        {
            foreach (var eve in dbEntityValidationException.EntityValidationErrors)
            {
                response.Message += string.Format(" Entity of type \"{0}\" in state \"{1}\" has the following validation errors: ", eve.Entry.Entity.GetType().Name, eve.Entry.State) + "\n";

                foreach (var ve in eve.ValidationErrors)
                {
                    response.Message += string.Format(" - Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage) + "\n";
                }
            }

            return response;
        }

        public void InsertLog(Log log)
        {
            try
            {
                //UnitOfWork.LogRepository.Add(log);
                UnitOfWork.Commit();
            }
            catch (Exception)
            {

            }
        }
    }
}
