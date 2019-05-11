namespace kin_leaderboard_frontend.Shared.Models
{
    public class Appp
    {
        public string AppId { get; set; }
        public string FriendlyName { get; set; }
        public long FirstSeen { get; set; }
        public long LastSeen { get; set; }

        public AppInfo Info { get; set; }
        public AppWallet Wallet { get; set; }
    }
}