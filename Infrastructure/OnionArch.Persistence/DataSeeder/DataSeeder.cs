using Bogus;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.DataSeeder;
public sealed class DataSeeder
{
    private readonly AppDbContext _context;

    public DataSeeder(AppDbContext context)
    {
        _context = context;
    }

    public async Task Seed()
    {
        _context.AddRange(CourseFaker.Generate(15));
        await _context.SaveChangesAsync(new());

    }

    public readonly static Faker<Course> CourseFaker = new Faker<Course>()
        .RuleFor(a => a.DateCreated, faker => faker.Date.Past())
        .RuleFor(a => a.Title, faker => faker.Lorem.Sentence(5))
        .RuleFor(a => a.Description, faker => faker.Lorem.Paragraph(1))
        .RuleFor(a => a.Teacher, faker => new()
        {
            DateCreated = faker.Date.Past(),
        })
        .RuleFor(a => a.Students, faker => new List<Student>()
        {
            new()
            {
                DateCreated = faker.Date.Past(),
            },
        }).UseSeed(1453);
}
