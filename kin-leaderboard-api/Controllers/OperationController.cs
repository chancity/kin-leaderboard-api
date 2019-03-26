using kin_leaderboard_api.Entities;
using kin_leaderboard_api.Models;
using kin_leaderboard_api.Services;
using kin_leaderboard_api.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kin_leaderboard_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OperationController : AbstractController<AbstractService<AppOperationDto, Operation, long>, Operation, long>
    {
        private readonly AbstractService<AppOperationDto, Operation, long> _service;

        public OperationController(AbstractService<AppOperationDto, Operation, long> service) : base(service)
        {
            _service = service;
        }
    }
}
