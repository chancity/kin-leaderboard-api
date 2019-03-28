using System.Threading.Tasks;
using kin_leaderboard_api.Entities;
using kin_leaderboard_api.Repository.Abstract;

namespace kin_leaderboard_api.Repository
{
    public class BaseRepository<TDto, TId> : AbstractRepository<TDto> where TDto : class
    {
        public ApplicationContext GetContext => Context;
        public BaseRepository(ApplicationContext context) : base(context) { }

        public Task<TDto> GetById(TId id)
        {
            return Context.Set<TDto>().FindAsync(id);
        }
    }
}