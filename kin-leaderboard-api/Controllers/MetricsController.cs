using System.Threading.Tasks;
using kin_leaderboard_api.Exceptions;
using kin_leaderboard_api.Models;
using kin_leaderboard_api.Models.ApiResponse;
using kin_leaderboard_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace kin_leaderboard_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : AbstractController<AppMetricService, AppMetric, string>
    {
        public MetricsController(AppMetricService service) : base(service) { }

        [HttpGet("{app_id}/{startDay}/{endDay}")]
        public async Task<ActionResult<BaseResponseData<AppMetric[]>>> Get(string app_id, long startDay, long endDay)
        {
            return Ok(await Service.GetByDayRange(app_id, startDay, endDay).ConfigureAwait(false));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<BaseResponseData<AppMetric>>> Get(string id)
        {
            throw new NotFoundApiException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<BaseResponseData<ApiResult>>> Post(AppMetric value)
        {
            throw new NotFoundApiException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<BaseResponseData<AppMetric>>> Put(string id, AppMetric value)
        {
            throw new NotFoundApiException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<BaseResponseData<ApiResult>>> Delete(string id)
        {
            throw new NotFoundApiException();
        }
    }
}