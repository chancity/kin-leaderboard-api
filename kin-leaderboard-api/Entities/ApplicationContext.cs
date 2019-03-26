using kin_leaderboard_api.Models;
using Microsoft.EntityFrameworkCore;

namespace kin_leaderboard_api.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<AppDto>(entity =>
            {
                entity.ToTable("app");
                entity.HasKey(e => e.AppId);

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasColumnName("app_id")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.FriendlyName)
                    .HasColumnName("friendly_name")
                    .HasColumnType("varchar(127)")
                    .HasDefaultValue();

                entity.Property(e => e.FirstSeen)
                    .IsRequired()
                    .HasColumnName("first_seen")
                    .HasColumnType("bigint");

                entity.Property(e => e.LastSeen)
                    .IsRequired()
                    .HasColumnName("last_seen")
                    .HasColumnType("bigint");
                entity.OwnsOne(e => e.Info);
                entity.OwnsOne(e => e.Wallet);
            });
            builder.Entity<AppInfoDto>(entity =>
            {
                entity.ToTable("app_info");
                entity.HasKey(e => e.AppId);

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasColumnName("app_id")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.AppStore)
                    .HasColumnName("app_store")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GooglePlay)
                    .HasColumnName("google_play")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasColumnType("varchar(255)");

            });

            builder.Entity<MinuteMetricDto>(entity =>
            {
                entity.ToTable("minute_metric");
                entity.HasKey(e => new {e.EpochTime, e.AppId});

                entity.Property(e => e.EpochTime)
                    .HasColumnName("epoch_time")
                    .IsRequired()
                    .HasColumnType("bigint");
            });

            builder.Entity<DayMetricDto>(entity =>
            {
                entity.ToTable("day_metric");
                entity.HasKey(e => new { e.EpochTime, e.AppId });

                entity.Property(e => e.EpochTime)
                    .HasColumnName("epoch_time")
                    .IsRequired()
                    .HasColumnType("bigint");
            });

            builder.Entity<AppWalletDto>(entity =>
            {
                entity.ToTable("app_wallet");
                entity.HasKey(e => new { e.AppId, e.Address});

                entity.Property(e => e.AppId)
                    .HasColumnName("app_id")
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsRequired()
                    .HasColumnType("varchar(56)");
            });

            builder.Entity<UserWalletDto>(entity =>
            {
                entity.ToTable("user_wallet");
                entity.HasKey(e => new { e.Address });

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsRequired()
                    .HasColumnType("varchar(56)");

                entity.Property(e => e.FriendlyName)
                    .HasColumnName("friendly_name")
                    .IsRequired()
                    .HasColumnType("varchar(127)");


            });

            builder.Entity<PagingTokenDto>(entity =>
            {
                entity.ToTable("paging_token");
                entity.HasKey(e => new { e.Cursor });

                entity.Property(e => e.Cursor)
                    .IsRequired()
                    .HasColumnName("cursor")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");
            });
            builder.Entity<UniquePaymentDto>(entity =>
            {
                entity.ToTable("unique_payment");
                entity.HasKey(e => new { e.AppId, e.EpochTime, e.Sender, e.Recipient });

                entity.Property(e => e.AppId)
                    .HasColumnName("app_id")
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Sender)
                    .HasColumnName("sender")
                    .IsRequired()
                    .HasColumnType("varchar(56)");

                entity.Property(e => e.Recipient)
                    .HasColumnName("recipient")
                    .IsRequired()
                    .HasColumnType("varchar(56)");

                entity.Property(e => e.EpochTime)
                    .HasColumnName("epoch_time")
                    .IsRequired()
                    .HasColumnType("bigint");
            });
            builder.Entity<AppPaymentDto>(entity =>
            {
                entity.ToTable("app_payment");
                entity.HasKey(e => new { e.Id });

                entity.Property(e => e.AppId)
                    .HasColumnName("app_id")
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Sender)
                    .HasColumnName("sender")
                    .IsRequired()
                    .HasColumnType("varchar(56)");

                entity.Property(e => e.Recipient)
                    .HasColumnName("recipient")
                    .IsRequired()
                    .HasColumnType("varchar(56)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .IsRequired()
                    .HasColumnType("bigint");

                entity.Property(e => e.EpochTime)
                    .HasColumnName("epoch_time")
                    .IsRequired()
                    .HasColumnType("bigint");
            });
            builder.Entity<AppOperationDto>(entity =>
            {
                entity.ToTable("app_operation");
                entity.HasKey(e => new { e.PagingToken });

                entity.Property(e => e.PagingToken)
                    .HasColumnName("paging_token")
                    .IsRequired()
                    .HasColumnType("bigint")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cursor)
                    .HasColumnName("cursor")
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.EpochTime)
                    .HasColumnName("epoch_time")
                    .IsRequired()
                    .HasColumnType("bigint");

                entity.Property(e => e.OperationType)
                    .HasColumnName("operation_type")
                    .IsRequired()
                    .HasColumnType("smallint");

                entity.Property(e => e.AppId)
                    .HasColumnName("app_id")
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Sender)
                    .HasColumnName("sender")
                    .IsRequired()
                    .HasColumnType("varchar(56)");

                entity.Property(e => e.Recipient)
                    .HasColumnName("recipient")
                    .IsRequired()
                    .HasColumnType("varchar(56)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .IsRequired()
                    .HasColumnType("bigint");
            });

            base.OnModelCreating(builder);
        }
         public DbSet<AppDto> Apps { get; set; }
         public DbSet<MinuteMetricDto> MinuteMetrics { get; set; }
         public DbSet<DayMetricDto> DayMetrics { get; set; }
         public DbSet<AppOperationDto> Operations { get; set; }
         public DbSet<PagingTokenDto> PagingTokens { get; set; }
         public DbSet<AppPaymentDto> Payments { get; set; }
         public DbSet<UniquePaymentDto> UniqueDayPayments { get; set; }
         public DbSet<AppWalletDto> AppWallets { get; set; }
         public DbSet<UserWalletDto> UserWallets { get; set; }
    }
}
