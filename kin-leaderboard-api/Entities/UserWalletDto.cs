
using System.ComponentModel.DataAnnotations.Schema;

namespace kin_leaderboard_api.Entities
{
    public class UserWalletDto
    {
        public string Address { get; set; }
        public string AppId { get; set; }
        [ForeignKey(nameof(AppId))]
        public AppDto AppDto { get; set; }
        public long Balance { get; set; }
        public string FriendlyName { get; set; }
        public long TxCount { get; set; }
        public long TxVolume { get; set; }
        public long FirstSeen { get; set; }
        public long LastSeen { get; set; }
    }
}
