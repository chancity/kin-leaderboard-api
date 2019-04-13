using System.Threading.Tasks;
using kin_leaderboard_api.Exceptions;
using kin_leaderboard_api.Services;
using kin_leaderboard_frontend.Shared.Models;
using kin_leaderboard_frontend.Shared.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kin_leaderboard_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppsController : AbstractController<AppService, App, string>
    {
        public AppsController(AppService service) : base(service) { }

        [HttpGet]
        public async Task<ActionResult<BaseResponseData<App[]>>> GetAllApps()
        {
            return Ok(ToResultReponse(await Service.GetAllApps().ConfigureAwait(false)));
        }

        [HttpGet("{id}/UserWallets")]
        public async Task<ActionResult<BaseResponseData<PaginatedResponse<UserWallet>>>> GetUserWallets(string id,
            int pageIndex)
        {
            PaginatedList<UserWallet> paginatedList = await Service.GetUserWallets(id, pageIndex).ConfigureAwait(false);
            return Ok(ToResultReponse(new PaginatedResponse<UserWallet>(paginatedList)));
        }

        [HttpPut("{id}/FriendlyName")]
        [Authorize]
        public async Task<ActionResult<BaseResponseData<ApiResult>>> UpdateFriendlyName(string id, string value)
        {
            return Ok(ToResultReponse(await Service.UpdateFriendlyName(id, value).ConfigureAwait(false)));
        }

        [HttpPut("{id}/Info")]
        [Authorize]
        public async Task<ActionResult<BaseResponseData<ApiResult>>> UpdateInfo(string id, [FromBody] AppInfo value)
        {
            return Ok(ToResultReponse(await Service.UpdateInfo(id, value).ConfigureAwait(false)));
        }

        [HttpPut("{id}/Wallet")]
        [Authorize]
        public async Task<ActionResult<BaseResponseData<ApiResult>>> UpdateWallet(string id, string address)
        {
            return Ok(ToResultReponse(await Service.UpdateWallet(id, new AppWallet {Address = address, Balance = 0})
                .ConfigureAwait(false)));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<BaseResponseData<ApiResult>>> Post(App value)
        {
            throw new NotFoundApiException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<BaseResponseData<App>>> Put(string id, App value)
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