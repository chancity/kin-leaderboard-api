
using System.ComponentModel.DataAnnotations.Schema;
using kin_leaderboard_api.Entities;

namespace kin_leaderboard_api.Models
{
    public class UserWallet
    {
        public string Address { get; set; }
        public string AppId { get; set; }
        public string FriendlyName { get; set; }
        public long TxCount { get; set; }
        public long TxVolume { get; set; }
        public long FirstSeen { get; set; }
        public long LastSeen { get; set; }
    }
}
