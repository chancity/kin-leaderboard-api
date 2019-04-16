namespace kin_leaderboard_frontend.Shared.Models
{
    public class AppMetric
    {
        private long _totalCount;

        private long _totalUniqueCount;
        private long _totalVolume;
        public long EpochTime { get; set; }
        public string AppId { get; set; }
        public long OperationCount { get; set; }
        public long NewWalletCount { get; set; }
        public long SpendUniqueCount { get; set; }
        public long SpendCount { get; set; }
        public long SpendVolume { get; set; }
        public long EarnUniqueCount { get; set; }
        public long EarnCount { get; set; }
        public long EarnVolume { get; set; }
        public long P2PUniqueCount { get; set; }
        public long P2PCount { get; set; }
        public long P2PVolume { get; set; }
        
        public long TotalUniqueCount
        {
            get => SpendUniqueCount + EarnUniqueCount + P2PUniqueCount;
            set => _totalUniqueCount = value;
        }

        public long TotalCount
        {
            get => SpendCount + EarnCount + P2PCount;
            set => _totalCount = value;
        }

        public long TotalVolume
        {
            get => SpendVolume + EarnVolume + P2PVolume;
            set => _totalVolume = value;
        }
    }
}