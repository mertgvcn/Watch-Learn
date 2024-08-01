using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArch.Domain.Entities;

namespace OnionArch.Persistence.Configurations;
public class StudentLessonProgressConfiguration : IEntityTypeConfiguration<StudentLessonProgress>
{
    public void Configure(EntityTypeBuilder<StudentLessonProgress> builder)
    {
        builder.Property(x => x.EditedBy)
            .HasMaxLength(64);
    }
}
