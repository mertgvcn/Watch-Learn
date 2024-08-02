using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArch.Domain.Entities;

namespace OnionArch.Persistence.Configurations;
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(x => x.EditedBy).HasMaxLength(64);
        builder.Property(x => x.Title).HasMaxLength(64);
        builder.Property(x => x.Description).HasMaxLength(255);
    }
}
