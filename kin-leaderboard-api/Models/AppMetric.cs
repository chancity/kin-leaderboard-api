using System.ComponentModel.DataAnnotations.Schema;
using kin_leaderboard_api.Entities;

namespace kin_leaderboard_api.Models
{
    public class AppMetric
    {
        public long EpochTime { get; set; }
        public string AppId { get; set; }
        public long NewWalletCount { get; set; }
        public long SpenderUniqueCount { get; set; }
        public long SpenderCount { get; set; }
        public long SpenderVolume { get; set; }
        public long EarnerUniqueCount { get; set; }
        public long EarnerCount { get; set; }
        public long EarnerVolume { get; set; }
        public long P2PUniqueCount { get; set; }
        public long P2PCount { get; set; }
        public long P2PVolume { get; set; }

        private long _totalUniqueCount;
        public long TotalUniqueCount
        {
            get { return SpenderUniqueCount + EarnerUniqueCount + P2PUniqueCount; }
            set => _totalUniqueCount = value;
        }
        private long _totalCount;
        public long TotalCount
        {
            get { return SpenderCount + EarnerCount + P2PCount; }
            set => _totalCount = value;
        }
        private long _totalVolume;
        public long TotalVolume
        {
            get { return SpenderVolume + EarnerVolume + P2PVolume; }
            set => _totalVolume = value;
        }
    }
}