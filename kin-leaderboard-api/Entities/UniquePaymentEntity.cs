namespace kin_leaderboard_api.Entities
{
    public class UniquePaymentEntity
    {
        public string AppId { get; set; }

        public long EpochTime { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
    }
}