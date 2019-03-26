using System.Threading.Tasks;
using kin_leaderboard_api.Models;
using kin_leaderboard_api.Models.ApiResponse;
using kin_leaderboard_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace kin_leaderboard_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : AbstractController<AppService, App, string>
    {
        public AppController(AppService service) : base(service)
        {
           
        }

     
    }
}
