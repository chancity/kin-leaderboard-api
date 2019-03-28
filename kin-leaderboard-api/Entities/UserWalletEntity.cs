using System.ComponentModel.DataAnnotations.Schema;

namespace kin_leaderboard_api.Entities
{
    public class UserWalletEntity
    {
        public string Address { get; set; }
        public string AppId { get; set; }

        [ForeignKey(nameof(AppId))]
        public AppEntity AppEntity { get; set; }

        public string FriendlyName { get; set; }
        public long TxCount { get; set; }
        public long TxVolume { get; set; }
        public long FirstSeen { get; set; }
        public long LastSeen { get; set; }
    }
}