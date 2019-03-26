using System.Threading.Tasks;

namespace kin_leaderboard_api.Services.Abstract {
    public interface IAppService<TModel, TId>
    {
        Task<TModel> Get(TId id);
        Task<int> Post(TModel value);
        Task Put(TId id, TModel value);
        Task<int> Delete(TId id);
    }
}