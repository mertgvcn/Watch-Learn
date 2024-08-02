using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArch.Domain.Entities;

namespace OnionArch.Persistence.Configurations;
public class LessonConfiguration : BaseEntityConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.EditedBy)
            .IsRequired(false)
            .HasMaxLength(64);

        builder.Property(x => x.Title)
            .IsRequired(true)
            .HasMaxLength(64);

        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasMaxLength(255);

    }


}
