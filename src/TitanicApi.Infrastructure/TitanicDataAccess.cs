using TitanicApi.Core.Interfaces;
using TitanicApi.Model;

namespace TitanicApi.Infrastructure;

public class TitanicDataAccess : ITitanicDataAccess
{
    public Task<Passenger> GetPassenger(int id)
    {
        return Task.FromResult(new Passenger { Id = id });
    }

    public Task<bool> DeletePassenger(int id)
    {
        return Task.FromResult(true);
    }
}
