using DotnetApiBoilerplatev2._0.Core.Models.AccountDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace DotnetApiBoilerplatev2._0.Infrastructure.Configurations.AccountDetailsConfiguration
{
    public class GroupAccountsConfiguration : IEntityTypeConfiguration<GroupAccounts>
    {
        public void Configure(EntityTypeBuilder<GroupAccounts> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("GroupAccountsId")
                .HasColumnType(SqlDbType.Int.ToString())
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Accounts)
                .WithMany()
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Roles)
               .WithMany()
               .HasForeignKey(x => x.RoleId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
