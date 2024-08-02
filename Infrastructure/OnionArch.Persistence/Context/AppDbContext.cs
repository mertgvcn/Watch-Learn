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

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<StudentLessonProgress> StudentLessonProgresses { get; set; }
    public DbSet<AuditLog> AuditLog { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Student>().HasMany(a => a.Courses).WithMany(a => a.Students).UsingEntity(a => a.ToTable("Enrollments"));

        modelBuilder.Entity<StudentLessonProgress>()
              .HasOne(s => s.Student)
              .WithMany(x => x.StudentLessonProgresses)
              .HasForeignKey(s => s.StudentId);
    }
    public override int SaveChanges()
    {
        throw new Exception("Savechanges is not allowed to be used. Use SaveChangesAsyncInstead");
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var ChangedObjects = ChangeTracker.Entries().Where(a => a.State == EntityState.Modified || a.State == EntityState.Added || a.State == EntityState.Deleted).ToList();
        foreach (var entity in ChangedObjects)
        {
            if (entity is IAuditable)
            {
                AuditLog.Add(new AuditLog()
                {
                    Object = entity.Entity.ToString()!,
                    Mutation = entity.State.ToString(),
                    OldObjectValue = JsonSerializer.Serialize(entity), //objeyi jsona çevir
                    Name = "Username is coming"
                });
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
