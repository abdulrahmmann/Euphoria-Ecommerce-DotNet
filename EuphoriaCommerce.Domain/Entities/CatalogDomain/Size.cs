using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.CatalogDomain;

/// <summary>
/// Represents a product size.
/// </summary>
public class Size: Entity<Guid>
{
    /// <summary>
    /// The size name.
    /// <example>Small, </example> <example>38</example>
    /// </summary>
    public string Name { get; private set; } = null!;
    
    /// <summary>
    /// The classification type of the size.
    /// <example>Clothing, </example> <example>Shoes</example>
    /// </summary>
    public string SizeType { get; private set; } = null!;
    
    public ICollection<ProductVariant> Variants { get; private set; } = new List<ProductVariant>();
    
    private Size() { }

    #region Constructor | Create
    /// <summary>Constructor | Create a Size and mark as Created.</summary>
    /// <param name="name">The Size Name.</param>
    /// <param name="sizeType">The Size Type.</param>
    /// <param name="createdBy">Admin Who create the Size.</param>
    private Size(string name, string sizeType, string? createdBy = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(sizeType);
        
        Id = Guid.NewGuid();
        
        Name = name;
        SizeType = sizeType;
        
        MarkCreated(createdBy);
    }
    #endregion

    #region Helper Methods : Update, Delete, Restore
    /// <summary>Update a Size and mark as Modified.</summary>
    /// <param name="name">The Size Name.</param>
    /// <param name="sizeType">The Size Type.</param>
    /// <param name="modifiedBy">Admin Who modify the Size.</param>
    public void Update(string name, string sizeType, string? modifiedBy = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(sizeType);

        Name = name;
        SizeType = sizeType;

        MarkModified(modifiedBy);
    }
    
    /// <summary> Softly Delete a Size and mark as Deleted.</summary>/ 
    /// <param name="deletedBy">Admin Who delete the size.</param>
    public void Delete(string? deletedBy = null)
    {
        MarkDeleted(deletedBy); 
    }
    /// <summary> Restore Softly Deleted Size and mark as Restored.</summary>/ 
    /// <param name="restoredBy">the admin who restore the size.</param>
    public void Restore(string? restoredBy = null)
    {
        MarkRestored(restoredBy);
    }
    #endregion
    
}