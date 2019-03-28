using kin_leaderboard_api.Entities;
using kin_leaderboard_api.Enums;

namespace kin_leaderboard_api.Models
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
