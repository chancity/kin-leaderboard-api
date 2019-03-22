using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kin_kre_api.Entities
{
    public class App
    {
        [Key]
        public string AppId { get; set; }
        public string FriendlyName { get; set; }
        public long FirstSeen { get; set; }
        public long LastSeen { get; set; }

        public ICollection<AppWallet> Wallets { get; set; }
        public ICollection<DayMetrics> DayMetrics { get; set; }
        public ICollection<MinuteMetrics> MinuteMetrics { get; set; }
        public ICollection<UniqueDayPayment> UniqueDayPayments { get; set; }
        public ICollection<AppPayment> Payments { get; set; }
        public ICollection<UserWallet> UserWallets { get; set; }

        public App()
        {
            Wallets = new List<AppWallet>();
            DayMetrics = new List<DayMetrics>();
            MinuteMetrics = new List<MinuteMetrics>();
            UniqueDayPayments = new List<UniqueDayPayment>();
            Payments = new List<AppPayment>();
            UserWallets = new List<UserWallet>();
        }
    }
}
