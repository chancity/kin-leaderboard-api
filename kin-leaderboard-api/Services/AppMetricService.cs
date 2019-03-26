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
    public class AppMetricService : AbstractService<DayMetricDto, AppMetric, string>
    {

        public AppMetricService(ILoggerFactory loggerFactory, ApplicationContext context, IMapper mapper) 
            : base(loggerFactory, context, mapper) {}


        public async Task<AppMetric[]> GetByDayRange(string id, long startDay, long endDay)
        {
            var dbEntity = await Repo.GetContext
                .DayMetrics.Where(d => d.AppId.Equals(id) && d.EpochTime >= startDay && d.EpochTime <= endDay).OrderBy(dto => dto.EpochTime).Take(30).ToArrayAsync();

               

            if (dbEntity == null)
            {
                throw new NotFoundApiException($"{GetType().Name} id '{id}' not found");
            }

            return Mapper.Map<DayMetricDto[], AppMetric[]>(dbEntity);
        }
    }
}
