using DotnetApiBoilerplatev2._0.Core.Models.AccountDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace DotnetApiBoilerplatev2._0.Infrastructure.Configurations.AccountDetailsConfiguration
{
    public class AccountsConfiguration : IEntityTypeConfiguration<Accounts>
    {
        public void Configure(EntityTypeBuilder<Accounts> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("AccountId")
                .HasColumnType(SqlDbType.Int.ToString())
                .ValueGeneratedOnAdd();
        }
    }
}
