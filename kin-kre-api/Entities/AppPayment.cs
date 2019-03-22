using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kin_kre_api.Entities
{
    public class AppPayment
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public string AppId { get; set; }
        [ForeignKey(nameof(AppId))]
        public App App { get; set; }
        public long EpochTime { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
    }

    public class UniqueDayPayment : AppPayment { }
}
