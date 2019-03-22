using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kin_leaderboard_api.Entities
{
    public class AppMetric
    {
        [Key]
        public long EpochTime { get; set; }
        [Key]
        public string AppId { get; set; }
        [ForeignKey(nameof(AppId))]
        public App App { get; set; }
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
        public long TotalUniqueCount { get; set; }
        public long TotalCount { get; set; }
        public long TotalVolume { get; set; }
    }
    public class MinuteMetrics : AppMetric
    { }
    public class DayMetrics : AppMetric
    { }
}