using Azure.Data.Tables;
using TitanicApi.Core.AppSettings;
using TitanicApi.Core.Interfaces;
using TitanicApi.Model;

namespace TitanicApi.Infrastructure;

public class TitanicDataAccess : ITitanicDataAccess
{
    private readonly TableClient _tableClient;

    private const string DefaultPartition = "partition-passengers";

    public TitanicDataAccess(AzureTableStorageSettings tableStorageSettings)
    {
        _tableClient = new TableClient(new Uri(tableStorageSettings.Uri), tableStorageSettings.TableNames["Passengers"],
            new TableSharedKeyCredential(tableStorageSettings.Name, tableStorageSettings.Key));
    }
    public async Task<Passenger?> GetPassenger(int id)
    {
        var passengerEntity = await _tableClient.QueryAsync<PassengerEntity>(p => p.RowKey == id.ToString()).FirstOrDefaultAsync();

        return passengerEntity == null ? null : new Passenger(passengerEntity);
    }

    public async Task<bool> DeletePassenger(int id)
    {
        var response = await _tableClient.DeleteEntityAsync(DefaultPartition, id.ToString());
        return !response.IsError;
    }
}
