using Microsoft.EntityFrameworkCore;

namespace kin_leaderboard_api.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

         public DbSet<App> Apps { get; set; }
         public DbSet<MinuteMetrics> MinuteMetrics { get; set; }
         public DbSet<DayMetrics> DayMetrics { get; set; }
         public DbSet<AppOperation> Operations { get; set; }
         public DbSet<PagingToken> PagingTokens { get; set; }
         public DbSet<AppPayment> Payments { get; set; }
         public DbSet<UniqueDayPayment> UniqueDayPayments { get; set; }
         public DbSet<AppWallet> Wallets { get; set; }


    }
}
