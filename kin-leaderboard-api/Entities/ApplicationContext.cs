using Microsoft.EntityFrameworkCore;

namespace kin_leaderboard_api.Entities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<AppEntity> Apps { get; set; }
        public DbSet<AppMetricEntity> AppMetrics { get; set; }
        public DbSet<AppOperationEntity> Operations { get; set; }
        public DbSet<PagingTokenEntity> PagingTokens { get; set; }
        public DbSet<AppPaymentEntity> Payments { get; set; }
        public DbSet<UniquePaymentEntity> UniqueDayPayments { get; set; }
        public DbSet<AppWalletEntity> AppWallets { get; set; }
        public DbSet<AppInfoEntity> AppInfos { get; set; }
        public DbSet<UserWalletEntity> UserWallets { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppEntity>(entity =>
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
                    .HasDefaultValue(null);

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

            builder.Entity<AppInfoEntity>(entity =>
            {
                entity.ToTable("app_info");
                entity.HasKey(e => e.AppId);

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasColumnName("app_id")
                    .HasDefaultValue(null)
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.AppStore)
                    .HasColumnName("app_store")
                    .HasDefaultValue(null)
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasDefaultValue(null)
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GooglePlay)
                    .HasColumnName("google_play")
                    .HasDefaultValue(null)
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasDefaultValue(null)
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasDefaultValue(null)
                    .HasColumnType("varchar(255)");
            });

            builder.Entity<AppMetricEntity>(entity =>
            {
                entity.ToTable("app_metric");
                entity.HasKey(e => new {e.EpochTime, e.AppId});

                entity.Property(e => e.AppId)
                    .HasColumnName("app_id")
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.EpochTime)
                    .HasColumnName("epoch_time")
                    .IsRequired()
                    .HasColumnType("bigint");

                entity.Property(e => e.OperationCount)
                    .HasColumnName("operation_count")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");

                entity.Property(e => e.NewWalletCount)
                    .HasColumnName("new_wallet_count")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");

                entity.Property(e => e.EarnCount)
                    .HasColumnName("earn_count")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");

                entity.Property(e => e.EarnUniqueCount)
                    .HasColumnName("earn_unique_count")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");

                entity.Property(e => e.EarnVolume)
                    .HasColumnName("earn_volume")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");

                entity.Property(e => e.SpendCount)
                    .HasColumnName("spend_count")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");

                entity.Property(e => e.SpendUniqueCount)
                    .HasColumnName("spend_unique_count")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");

                entity.Property(e => e.SpendVolume)
                    .HasColumnName("spend_volume")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");

                entity.Property(e => e.P2PCount)
                    .HasColumnName("p2p_count")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");

                entity.Property(e => e.P2PUniqueCount)
                    .HasColumnName("p2p_unique_count")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");

                entity.Property(e => e.P2PVolume)
                    .HasColumnName("p2p_volume")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");
            });

            builder.Entity<AppWalletEntity>(entity =>
            {
                entity.ToTable("app_wallet");
                entity.HasKey(e => new {e.AppId, e.Address});

                entity.Property(e => e.AppId)
                    .HasColumnName("app_id")
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsRequired()
                    .HasColumnType("varchar(56)");


                entity.Property(e => e.Balance)
                    .HasColumnName("balance")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");
            });

            builder.Entity<UserWalletEntity>(entity =>
            {
                entity.ToTable("user_wallet");
                entity.HasKey(e => new {e.AppId, e.Address});
                entity.HasIndex(e => new {e.AppId});

                entity.Property(e => e.AppId)
                    .HasColumnName("app_id")
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsRequired()
                    .HasColumnType("varchar(56)");

                entity.Property(e => e.FriendlyName)
                    .HasColumnName("friendly_name")
                    .HasDefaultValue(null)
                    .HasColumnType("varchar(127)");

                entity.Property(e => e.TxCount)
                    .HasColumnName("tx_count")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");

                entity.Property(e => e.TxVolume)
                    .HasColumnName("tx_volume")
                    .HasDefaultValue(0)
                    .HasColumnType("bigint");

                entity.Property(e => e.FirstSeen)
                    .IsRequired()
                    .HasColumnName("first_seen")
                    .HasColumnType("bigint");

                entity.Property(e => e.LastSeen)
                    .IsRequired()
                    .HasColumnName("last_seen")
                    .HasColumnType("bigint");
            });

            builder.Entity<UniquePaymentEntity>(entity =>
            {
                entity.ToTable("unique_payment");
                entity.HasKey(e => new {e.AppId, e.EpochTime, e.Sender, e.Recipient});

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

            builder.Entity<AppPaymentEntity>(entity =>
            {
                entity.ToTable("app_payment");
                entity.HasKey(e => new {e.Id});
                entity.HasIndex(e => new {e.AppId, e.Sender, e.Recipient});

                entity.Property(e => e.Id)
                    .HasColumnName("id");

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

                entity.Property(e => e.PaymentType)
                    .HasColumnName("payment_type")
                    .IsRequired()
                    .HasColumnType("smallint");
            });

            builder.Entity<AppOperationEntity>(entity =>
            {
                entity.ToTable("app_operation");
                entity.HasKey(e => new {e.PagingToken});

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

            builder.Entity<PagingTokenEntity>(entity =>
            {
                entity.ToTable("paging_token");
                entity.HasKey(e => new {e.Cursor});

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
            base.OnModelCreating(builder);
        }
    }
}