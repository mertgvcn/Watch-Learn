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
        _context.AddRange(studentFaker.Generate(4));

        await _context.SaveChangesAsync();
    }

    public readonly static Faker<Student> studentFaker = new Faker<Student>()
        .RuleFor(item => item.DateCreated, faker => faker.Date.Past())
        .RuleFor(item => item.EditedBy, faker => faker.Person.FullName)
        .RuleFor(item => item.FirstName, faker => faker.Person.FirstName)
        .RuleFor(item => item.LastName, faker => faker.Person.LastName)
        .RuleFor(item => item.Email, faker => faker.Internet.Email())
        .RuleFor(item => item.PhoneNumber, faker => faker.Person.Phone)
        .RuleFor(item => item.Password, faker => "123")
        .RuleFor(item => item.Courses, faker => new List<Course>
        {
            new()
            {
                DateCreated = faker.Date.Past(),
                EditedBy = faker.Person.FullName,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(3)
            },
            new()
            {
                DateCreated = faker.Date.Past(),
                EditedBy = faker.Person.FullName,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(3)
            },
            new()
            {
                DateCreated = faker.Date.Past(),
                EditedBy = faker.Person.FullName,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(3)
            }
        }).UseSeed(20);
}
