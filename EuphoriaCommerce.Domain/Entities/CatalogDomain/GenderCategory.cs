using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.CatalogDomain;

/// <summary>
/// Represents a Gender of product.
/// <example>Men, Women, Kids.</example>
/// </summary>
public class GenderCategory: Entity<Guid>
{
    public string Name { get; private set; } = null!;
    
    public ICollection<Product> Products { get; private set; } = new List<Product>();

    private GenderCategory() {}
    
    public GenderCategory(string name, string? createdBy = "System")
    {
        Id = Guid.NewGuid();
        Name = name;
        MarkCreated(createdBy);
    }
}