using System.Threading.Tasks;
using AutoMapper;
using kin_leaderboard_api.Entities;
using kin_leaderboard_api.Exceptions;
using kin_leaderboard_api.Models;
using kin_leaderboard_api.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace kin_leaderboard_api.Services
{
    public class AppService : AbstractService<AppDto, App, string>
    {

        public AppService(ILoggerFactory loggerFactory, ApplicationContext context, IMapper mapper) 
            : base(loggerFactory.CreateLogger<AppService>(), context, mapper) {}

        public override async Task<App> Get(string id)
        {
            var dbEntity = await Repo.GetContext
                .Apps
                .Include(a => a.Info)
                .Include(a => a.Wallet)
                .SingleOrDefaultAsync(a => a.AppId.Equals(id));

            if (dbEntity == null)
            {
                throw new NotFoundApiException($"{GetType().Name} id '{id}' not found");
            }

            return Mapper.Map<AppDto, App>(dbEntity);
        }
    }
}
