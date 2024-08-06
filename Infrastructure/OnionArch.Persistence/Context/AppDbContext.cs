using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Common;
using OnionArch.Domain.Entities;
using System.Reflection;
using System.Text.Json;

namespace OnionArch.Persistence.Context;
public class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<StudentLessonProgress> StudentLessonProgresses { get; set; }
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
    public DbSet<AuditLog> AuditLog { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Student>().HasMany(a => a.Courses).WithMany(a => a.Students).UsingEntity(a => a.ToTable("Enrollments"));
    }

    public override int SaveChanges()
    {
        throw new InvalidOperationException("Use SaveChangesAsync");
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        var ChangedObjects = ChangeTracker.Entries().Where(a => a.State == EntityState.Modified || a.State == EntityState.Added || a.State == EntityState.Deleted).ToList();
        foreach (var entity in ChangedObjects)
        {
            if (entity is IAuditable)
            {
                Add(new AuditLog()
                {
                    DateCreated = DateTime.UtcNow,
                    Mutation = entity.State.ToString(),
                    Name = "Add User Name",
                    Object = entity.ToString(),
                    OldObjectValue = JsonSerializer.Serialize(entity)
                });
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
