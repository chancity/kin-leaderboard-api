using System.Threading.Tasks;
using kin_leaderboard_api.Entities;
using kin_leaderboard_api.Exceptions;
using kin_leaderboard_api.Services.Abstract;
using kin_leaderboard_frontend.Shared.Models;
using kin_leaderboard_frontend.Shared.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kin_leaderboard_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class
        OperationController : AbstractController<AbstractService<AppOperationEntity, Operation, long>, Operation, long>
    {
        private readonly AbstractService<AppOperationEntity, Operation, long> _service;

        public OperationController(AbstractService<AppOperationEntity, Operation, long> service) : base(service)
        {
            _service = service;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<BaseResponseData<Operation>>> Put(long id, Operation value)
        {
            throw new NotFoundApiException();
        }
    }
}