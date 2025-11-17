using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.CatalogDomain;

/// <summary> Represents a product size. </summary>
public class Size: Entity<Guid>
{
    public string Name { get; private set; } = null!;
    public string SizeType { get; private set; } = null!;
    
    public ICollection<ProductVariant> Variants { get; private set; } = new List<ProductVariant>();
    
    private Size() { }

    private Size(string name, string sizeType)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(sizeType);
        
        Id = Guid.NewGuid();
        
        Name = name;
        SizeType = sizeType;
    }
}