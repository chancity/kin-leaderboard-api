using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace kin_leaderboard_api.Entities
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            DbContextOptionsBuilder<ApplicationContext> builder = new DbContextOptionsBuilder<ApplicationContext>();

            string connectionString = configuration["ConnectionStrings_ApplicationDatabase"];

            builder.UseMySql(connectionString);

            return new ApplicationContext(builder.Options);
        }
    }
}