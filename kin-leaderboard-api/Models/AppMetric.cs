using System.ComponentModel.DataAnnotations.Schema;
using kin_leaderboard_api.Entities;

namespace kin_leaderboard_api.Models
{
    public class AppMetric
    {
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

        private long _totalUniqueCount;
        public long TotalUniqueCount
        {
            get { return SpendUniqueCount + EarnUniqueCount + P2PUniqueCount; }
            set => _totalUniqueCount = value;
        }
        private long _totalCount;
        public long TotalCount
        {
            get { return SpendCount + EarnCount + P2PCount; }
            set => _totalCount = value;
        }
        private long _totalVolume;
        public long TotalVolume
        {
            get { return SpendVolume + EarnVolume + P2PVolume; }
            set => _totalVolume = value;
        }
    }
}