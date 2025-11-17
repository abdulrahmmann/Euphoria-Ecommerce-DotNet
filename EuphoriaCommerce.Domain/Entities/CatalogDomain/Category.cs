using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.CatalogDomain;

/// <summary> Represents a product category. </summary>
public class Category : Entity<Guid>
{
    public string Name { get; private set; } = null!; // Men, Women, Kids
    public string Description { get; private set; } = null!;
    
    public ICollection<Product> Products { get; private set; } = new List<Product>();
    
    public ICollection<SubCategory> SubCategories { get; private set; } = new List<SubCategory>();
    
    private Category() {}
    
    private Category(string name, string? description)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);
        
        Id = Guid.NewGuid();
        
        Name = name;
        Description = description;
    }
}