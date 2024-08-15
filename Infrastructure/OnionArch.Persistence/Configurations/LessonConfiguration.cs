using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArch.Domain.Entities;

namespace OnionArch.Persistence.Configurations;
public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
	public void Configure(EntityTypeBuilder<Lesson> builder)
	{
		builder.Property(x => x.EditedBy).HasMaxLength(64);
		builder.Property(x => x.Title).HasMaxLength(64);
		builder.Property(x => x.Description).HasMaxLength(512);
		builder.Property(x => x.VideoUrl).HasMaxLength(255);
	}
}
