using DotnetApiBoilerplatev2._0.Core.Models.AccountDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace DotnetApiBoilerplatev2._0.Infrastructure.Configurations.AccountDetailsConfiguration
{
    public class RolesConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("RolesId")
                .HasColumnType(SqlDbType.Int.ToString())
                .ValueGeneratedOnAdd();
        }
    }
}
