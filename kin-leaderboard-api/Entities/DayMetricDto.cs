using System.ComponentModel.DataAnnotations.Schema;

namespace kin_leaderboard_api.Entities {
    public class DayMetricDto
    {
        public long EpochTime { get; set; }
        public string AppId { get; set; }
        [ForeignKey(nameof(AppId))]
        public AppDto AppDto { get; set; }
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
    }
}