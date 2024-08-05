using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArch.Domain.Entities;

namespace OnionArch.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.EditedBy).HasMaxLength(64);
        builder.Property(x => x.FirstName).HasMaxLength(64);
        builder.Property(x => x.LastName).HasMaxLength(64);
        builder.Property(x => x.Email).HasMaxLength(64);
        builder.Property(x => x.PhoneNumber).HasMaxLength(16);
        builder.Property(x => x.Password).HasMaxLength(256);
    }
}
