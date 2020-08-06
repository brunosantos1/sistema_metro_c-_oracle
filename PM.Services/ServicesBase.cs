using PM.Data.UnitOfWork;
using PM.Domain.Interfaces.Services;
using PM.Domain.Types;

namespace PM.Services
{
    public class ServicesBase : IServicesBase
    {
        private readonly IUnitOfWork _unitOfWork;

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public ServicesBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Log(string cwid, ActionType action, string description)
        {
            throw new System.NotImplementedException();
        }
    }
}
