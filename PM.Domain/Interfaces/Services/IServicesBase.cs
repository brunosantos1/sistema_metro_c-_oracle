using PM.Domain.Types;

namespace PM.Domain.Interfaces.Services
{
    public interface IServicesBase
    {
        void Log(string cwid, ActionType action, string description);
    }
}
