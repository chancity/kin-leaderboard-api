using kin_leaderboard_api.Entities;
using kin_leaderboard_api.Repository.Abstract;

namespace kin_leaderboard_api.Repository
{
    public class OperationsRepository : BaseRepository<AppOperation>
    {
        public OperationsRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
