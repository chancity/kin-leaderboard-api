
namespace kin_leaderboard_api.Entities
{
    public class UserWallet : AppWallet
    {
        public string FriendlyName { get; set; }
        public long TxCount { get; set; }
        public long TxVolume { get; set; }
        public long FirstSeen { get; set; }
        public long LastSeen { get; set; }
    }
}
