using System.ComponentModel.DataAnnotations.Schema;
using kin_leaderboard_api.Enums;

namespace kin_leaderboard_api.Entities
{
    public class AppPaymentEntity
    {
        public int Id { get; set; }
        public string AppId { get; set; }

        [ForeignKey(nameof(AppId))]
        public AppEntity AppEntity { get; set; }

        public PaymentType PaymentType { get; set; }
        public long EpochTime { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public long Amount { get; set; }
    }
}