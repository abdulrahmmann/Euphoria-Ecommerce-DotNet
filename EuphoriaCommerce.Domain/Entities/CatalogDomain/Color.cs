using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.CatalogDomain;

/// <summary> Represents a product color.  </summary>
public class Color : Entity<Guid>
{
    public string Name { get; private set; } = null!;
    public string HexCode { get; private set; } = null!;
    
    public ICollection<ProductVariant> Variants { get; private set; } = new List<ProductVariant>();
    
    private Color() { }

    private Color(string name, string hexCode)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(hexCode);

        Id = Guid.NewGuid();
        
        Name = name;
        HexCode = hexCode;
    }
}