using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArch.Domain.Entities;

namespace OnionArch.Persistence.Configurations;
public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
{
    public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
    {
        builder.Property(x => x.EditedBy).HasMaxLength(64);
        builder.Property(x => x.Token).HasMaxLength(255);
    }
}
