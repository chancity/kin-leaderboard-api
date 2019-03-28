using System.ComponentModel.DataAnnotations.Schema;

namespace kin_leaderboard_api.Entities {
    public class AppMetricEntity
    {
        public long EpochTime { get; set; }
        public string AppId { get; set; }
        [ForeignKey(nameof(AppId))]
        public AppEntity AppEntity { get; set; }

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
    }
}