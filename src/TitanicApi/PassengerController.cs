using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using TitanicApi.Core.Interfaces;

namespace TitanicApi
{
    public class PassengerController
    {
        private readonly ITitanicDataAccess _titanicDataAccess;

        public PassengerController(ITitanicDataAccess titanicDataAccess)
        {
            _titanicDataAccess = titanicDataAccess;
        }

        [FunctionName(nameof(GetPassenger))]
        public async Task<IActionResult> GetPassenger([HttpTrigger(AuthorizationLevel.Function, "get", Route = "passengers/{id:int}")] HttpRequest req, int id)
        {
            var passenger = await _titanicDataAccess.GetPassenger(id);

            return passenger == null ? new NotFoundResult() : new OkObjectResult(passenger);
        }

        [FunctionName(nameof(DeletePassenger))]
        public async Task<IActionResult> DeletePassenger([HttpTrigger(AuthorizationLevel.Function, "post", Route = "passengers/delete/{id:int}")] HttpRequest req, int id)
        {
            var success= await _titanicDataAccess.DeletePassenger(id);

            return success ? new OkResult() : new NotFoundResult();
        }
    }
}
