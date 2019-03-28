using System.ComponentModel.DataAnnotations.Schema;

namespace kin_leaderboard_api.Entities
{
    public class AppWalletEntity
    {
        public string Address { get; set; }

        [ForeignKey(nameof(AppId))]
        public string AppId { get; set; }

        public AppEntity AppEntity { get; set; }
        public long Balance { get; set; }
    }
}