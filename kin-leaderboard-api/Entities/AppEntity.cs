namespace kin_leaderboard_api.Entities
{
    public class AppEntity
    {
        public string AppId { get; set; }
        public string FriendlyName { get; set; }
        public long FirstSeen { get; set; }
        public long LastSeen { get; set; }
        public virtual AppInfoEntity Info { get; set; }
        public virtual AppWalletEntity Wallet { get; set; }

        public AppEntity()
        {
            Info = new AppInfoEntity();
        }
    }
}