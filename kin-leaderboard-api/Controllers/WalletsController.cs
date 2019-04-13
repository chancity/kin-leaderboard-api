using System.Threading.Tasks;
using kin_leaderboard_api.Exceptions;
using kin_leaderboard_api.Services;
using kin_leaderboard_frontend.Shared.Models;
using kin_leaderboard_frontend.Shared.Models.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace kin_leaderboard_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : AbstractController<UserWalletService, UserWallet, string>
    {
        public WalletsController(UserWalletService service) : base(service) { }


        [HttpGet("{app_id}/Payments")]
        public async Task<ActionResult<BaseResponseData<PaginatedResponse<AppPayment>>>> GetPayments(string app_id,
            string address, int pageIndex)
        {
            PaginatedList<AppPayment> paginatedList =
                await Service.GetPayments(app_id, address, pageIndex).ConfigureAwait(false);
            return Ok(ToResultReponse(new PaginatedResponse<AppPayment>(paginatedList)));
        }

        [HttpPut("{app_id}/FriendlyName")]
        //[Authorize]
        public async Task<ActionResult<BaseResponseData<ApiResult>>> UpdateFriendlyName(string app_id, string address,
            string value)
        {
            return Ok(ToResultReponse(await Service.UpdateFriendlyName(app_id, address, value).ConfigureAwait(false)));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<BaseResponseData<UserWallet>>> Get(string id)
        {
            throw new NotFoundApiException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<BaseResponseData<ApiResult>>> Post(UserWallet value)
        {
            throw new NotFoundApiException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<BaseResponseData<UserWallet>>> Put(string id, UserWallet value)
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