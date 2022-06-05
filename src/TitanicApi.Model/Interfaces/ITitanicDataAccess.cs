using TitanicApi.Model;

namespace TitanicApi.Core.Interfaces;

public interface ITitanicDataAccess
{
    Task<bool> DeletePassenger(int id);
    Task<Passenger?> GetPassenger(int id);
}
