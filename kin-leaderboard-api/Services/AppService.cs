using System.Linq;
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
    public class AppService : AbstractService<AppEntity, App, string>
    {

        public AppService(ILoggerFactory loggerFactory, ApplicationContext context, IMapper mapper) 
            : base(loggerFactory, context, mapper) {}

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

            return Mapper.Map<AppEntity, App>(dbEntity);
        }
        public async Task<App[]> GetAllApps()
        {
            var dbEntity = await Repo.GetContext
                .Apps
                .Include(a => a.Info)
                .Include(a => a.Wallet).ToArrayAsync().ConfigureAwait(false);

            return Mapper.Map<AppEntity[], App[]>(dbEntity);
        }

        public async Task<PaginatedList<UserWallet>> GetUserWallets(string id, int pageIndex = 1)
        {
            var dbEntityApp = await Repo.GetById(id).ConfigureAwait(false);

            if (dbEntityApp == null)
            {
                throw new NotFoundApiException($"{GetType().Name} id '{id}' not found");
            }

            return await PaginatedList<UserWallet>.CreateAsync(Repo
                .GetContext
                .UserWallets
                .AsNoTracking()
                .Where(w => w.AppId.Equals(id))
                .OrderByDescending(w => w.LastSeen), Mapper, pageIndex, 25);
        }

        public async Task<int> UpdateFriendlyName(string id, string value)
        {
            var dbEntityApp = await Repo.GetById(id).ConfigureAwait(false);

            if (dbEntityApp == null)
            {
                throw new NotFoundApiException($"{GetType().Name} id '{id}' not found");
            }


            dbEntityApp.FriendlyName = value;
            return await Repo.SaveChanges().ConfigureAwait(false);
        }

        public async Task<int> UpdateInfo(string id, AppInfo value)
        {
            var dbEntityApp = await Repo.GetById(id).ConfigureAwait(false);

            if (dbEntityApp == null)
            {
                throw new NotFoundApiException($"{GetType().Name} id '{id}' not found");
            }


            var dbEntityInfo = await Repo.GetContext
                .AppInfos
                .FindAsync(id).ConfigureAwait(false); ;

            var info = Mapper.Map(value, dbEntityInfo);

            if (dbEntityInfo == null)
            {
                info.AppId = id;
                await Repo.GetContext.AppInfos.AddAsync(info).ConfigureAwait(false);
            }
            else
            {
                Mapper.Map(value, dbEntityInfo);
            }

            return await Repo.GetContext.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<int> UpdateWallet(string id, AppWallet value)
        {
            var dbEntityApp = await Repo.GetById(id).ConfigureAwait(false);

            if (dbEntityApp == null)
            {
                throw new NotFoundApiException($"{GetType().Name} id '{id}' not found");
            }


            var dbEntityWallet = await Repo.GetContext
                .AppWallets
                .FindAsync(id, null).ConfigureAwait(false);

            var wallet = Mapper.Map(value, dbEntityWallet);

            if (dbEntityWallet == null)
            {
                wallet.AppId = id;
                await Repo.GetContext.AppWallets.AddAsync(wallet).ConfigureAwait(false);
            }
            else
            {
                Mapper.Map(value, dbEntityWallet);
            }

            return await Repo.GetContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
