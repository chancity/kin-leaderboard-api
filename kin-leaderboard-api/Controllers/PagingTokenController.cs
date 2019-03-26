using System.Threading.Tasks;
using kin_leaderboard_api.Entities;
using kin_leaderboard_api.Exceptions;
using kin_leaderboard_api.Models;
using kin_leaderboard_api.Models.ApiResponse;
using kin_leaderboard_api.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace kin_leaderboard_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagingTokenController : AbstractController<AbstractService<PagingTokenDto, PagingToken, string>, PagingToken, string>
    {
        public PagingTokenController(AbstractService<PagingTokenDto, PagingToken, string> service) : base(service)
        {}

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<BaseResponseData<ApiResult>>> Post(PagingToken value)
        {
            throw new NotFoundApiException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<BaseResponseData<PagingToken>>> Put(string id, PagingToken value)
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
