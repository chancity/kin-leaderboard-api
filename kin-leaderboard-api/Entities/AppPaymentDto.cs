using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kin_leaderboard_api.Entities
{
    public class AppPaymentDto
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        [ForeignKey(nameof(AppId))]
        public AppDto AppDto { get; set; }
        public long EpochTime { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
    }
}
