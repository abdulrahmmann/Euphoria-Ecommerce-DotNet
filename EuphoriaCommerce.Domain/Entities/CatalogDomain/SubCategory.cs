using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.CatalogDomain;

/// <summary> Represents a sub-category inside a main category. </summary>
public class SubCategory : Entity<Guid>
{
    public string Name { get; private set; } = null!; // Tops, Printed T-shirts, Plain T-shirts, Kurti, Boxers ...
    public string Description { get; private set; } = null!;
    
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; } = null!; 
    
    public ICollection<Product> Products { get; private set; } = new List<Product>();
    
    private SubCategory() { }
    
    private SubCategory(string name, string description, Guid categoryId)
    {
        Id = Guid.NewGuid();
        
        Name = name;
        Description = description;
        CategoryId = categoryId;
    }
}