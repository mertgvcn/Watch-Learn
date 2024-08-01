namespace OnionArch.Domain.Entities;
public class Product
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required decimal Discount { get; set; }
    public required long BrandId { get; set; }
    public Brand Brand { get; set; }
    public ICollection<Category> Categories { get; set; }
}
