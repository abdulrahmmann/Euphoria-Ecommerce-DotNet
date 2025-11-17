using EuphoriaCommerce.Domain.Bases;

namespace EuphoriaCommerce.Domain.Entities.ProductDomain;

/// <summary> Represent a Product Tag. </summary>
public class ProductTag: Entity<Guid>
{
    public string Name { get; private set; } = null!;
    
    public ICollection<Product> Products { get; private set; } = new List<Product>();

    private ProductTag() {}

    public ProductTag(string name)
    {
        Id = Guid.NewGuid();
        
        Name = name;
    }
}