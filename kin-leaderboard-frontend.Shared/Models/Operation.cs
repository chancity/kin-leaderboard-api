using kin_leaderboard_frontend.Shared.Enums;

namespace kin_leaderboard_frontend.Shared.Models
{
    public class Operation
    {
        public long PagingToken { get; set; }
        public string Cursor { get; set; }
        public long EpochTime { get; set; }
        public OperationType OperationType { get; set; }
        public string AppId { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public long Amount { get; set; }
    }
}