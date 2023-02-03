using DotnetApiBoilerplatev2._0.Core.Models.AccountDetails;
using DotnetApiBoilerplatev2._0.Infrastructure.Configurations.AccountDetailsConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DotnetApiBoilerplatev2._0.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public virtual DbSet<Accounts> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountsConfiguration());
            builder.ApplyConfiguration(new RolesConfiguration());
            builder.ApplyConfiguration(new GroupAccountsConfiguration());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("Secrets/secrets.json", optional: false, reloadOnChange: true)
                    .Build();
                var connectionString = configuration.GetConnectionString("DevConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}