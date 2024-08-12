using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArch.Domain.Entities;

namespace OnionArch.Persistence.Configurations;
public class CourseCommentConfiguration : IEntityTypeConfiguration<CourseComment>
{
    public void Configure(EntityTypeBuilder<CourseComment> builder)
    {
        builder.Property(x => x.EditedBy).HasMaxLength(64);
        builder.Property(x => x.Comment).HasMaxLength(255);
    }
}
