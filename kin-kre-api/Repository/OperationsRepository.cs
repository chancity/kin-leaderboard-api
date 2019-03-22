using kin_kre_api.Entities;
using kin_kre_api.Repository.Abstract;

namespace kin_kre_api.Repository
{
    public class OperationsRepository : BaseRepository<AppOperation>
    {
        public OperationsRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
