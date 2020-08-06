using PM.Domain.Entities;
using PM.Domain.Entities.RS;
using System.Data.Entity.Validation;

namespace PM.Domain.Interfaces.Services
{
    public interface ILogServices
    {
        Response ManageErrorLog(DbEntityValidationException dbEntityValidationException, Response response);
        void InsertLog(Log log);
    }
}
