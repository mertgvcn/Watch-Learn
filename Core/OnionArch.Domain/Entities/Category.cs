using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities;
public class Category : EntityBase
{
    public Category()
    {

    }
    public Category(string name, int priority, long? parentCategoryId)
    {
        Name = name;
        Priority = priority;
        ParentCategoryId = parentCategoryId;
    }

    public required string Name { get; set; }
    public required int Priority { get; set; }
    public long? ParentCategoryId { get; set; }
    public Category ParentCategory { get; set; }
    public ICollection<Category> ChildrenCategories { get; set; }
    public ICollection<Detail> Details { get; set; }
    public ICollection<Product> Products { get; set; }
}
