using EuphoriaCommerce.Domain.Bases;

namespace EuphoriaCommerce.Domain.Entities.CatalogDomain;

/// <summary> Represents a product brand. </summary>
public class Brand: Entity<Guid>
{
    public string Name { get; private set; } = null!;
    public string? LogoUrl { get; private set; }
    
    private Brand() { }

    public Brand(string name, string logoUrl)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Id = Guid.NewGuid();
        
        Name = name;
        LogoUrl = logoUrl;
    }
}