using kin_kre_api.Models;

namespace kin_kre_api.Entities
{
    public class AppOperation
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
