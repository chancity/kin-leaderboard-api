using kin_leaderboard_frontend.Shared.Enums;

namespace kin_leaderboard_frontend.Shared.Models
{
    public class AppPayment
    {
        public string AppId { get; set; }
        public PaymentType PaymentType { get; set; }
        public long EpochTime { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public long Amount { get; set; }
    }
}