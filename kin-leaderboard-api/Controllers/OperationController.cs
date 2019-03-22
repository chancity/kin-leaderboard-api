using System.Threading.Tasks;
using kin_leaderboard_api.Models;
using kin_leaderboard_api.Models.ApiResponse;
using kin_leaderboard_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kin_leaderboard_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OperationController : AbstractController<OperationsService, Operation, long>
    {
        private readonly OperationsService _service;

        public OperationController(OperationsService service) : base(service)
        {
            _service = service;
        }
    }
}
