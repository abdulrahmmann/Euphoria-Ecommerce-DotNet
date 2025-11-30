using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.CatalogDomain;

/// <summary>
/// Represents a product brand.
/// <example>Zara, </example> <example>HM, </example> <example>Adidas</example>
/// </summary>
public class Brand: Entity<Guid>
{
    /// <summary>The Brand Name.</summary>
    public string Name { get; private set; } = null!;
    
    /// <summary>The Brand Logo.</summary>
    public string LogoUrl { get; private set; } = null!;

    public List<Product> Products = new List<Product>();
    
    private Brand() { }

    #region Constructor | Create
    /// <summary>Constructor | Create a Brand and mark as Created.</summary>
    /// <param name="name">Brand Name.</param>
    /// <param name="logoUrl">Brand Logo.</param>
    /// <param name="createdBy">Admin Who create the brand.</param>
    public Brand(string name, string logoUrl, string? createdBy = "System")
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(logoUrl);
        
        Id = Guid.NewGuid();
        Name = name;
        LogoUrl = logoUrl;
        
        MarkCreated(createdBy);
    }
    #endregion

    #region Helper Methods : Update, Delete, Restore
    /// <summary> Update a Brand and mark as Modified. </summary>
    /// <param name="name"> Brand Name. </param>
    /// <param name="logoUrl"> Brand Logo. </param>
    /// <param name="modifiedBy">Admin Who modify the brand.</param>
    public void Update(string? name, string? logoUrl, string? modifiedBy = "System")
    {
        Name = name ?? Name;
        LogoUrl = logoUrl ?? LogoUrl; 

        MarkModified(modifiedBy);
    }
    
    /// <summary> Softly Delete a Brand and mark as Deleted.</summary>/ 
    /// <param name="deletedBy">Admin Who delete the brand.</param>
    public void Delete(string? deletedBy = "System")
    {
        MarkDeleted(deletedBy); 
    }
    /// <summary> Restore Softly Deleted Brand and mark as Restored.</summary>/ 
    /// <param name="restoredBy">the admin who restore the brand.</param>
    public void Restore(string? restoredBy = "System")
    {
        MarkRestored(restoredBy);
    }
    #endregion
}