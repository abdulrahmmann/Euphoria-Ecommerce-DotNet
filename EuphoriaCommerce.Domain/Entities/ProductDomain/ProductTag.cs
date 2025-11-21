using EuphoriaCommerce.Domain.Bases;

namespace EuphoriaCommerce.Domain.Entities.ProductDomain;

/// <summary>
/// Represents a product tag.
/// <example>New Arrival, Best Seller, Trending</example>
/// </summary>
public class ProductTag : Entity<Guid>
{
    /// <summary>The tag name.</summary>
    public string Name { get; private set; } = null!;

    /// <summary>Navigation property to products with this tag.</summary>
    public ICollection<Product> Products { get; private set; } = new List<Product>();

    private ProductTag() { }

    #region Constructor | Create
    /// <summary>Constructor | Create a ProductTag and mark as Created.</summary>
    /// <param name="name">Tag name.</param>
    /// <param name="createdBy">Admin who created the tag.</param>
    public ProductTag(string name, string? createdBy = "System")
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        Id = Guid.NewGuid();
        Name = name;

        MarkCreated(createdBy);
    }
    #endregion

    #region Helper Methods : Update, Delete, Restore
    /// <summary>Update a ProductTag and mark as Modified.</summary>
    /// <param name="name">Tag name.</param>
    /// <param name="modifiedBy">Admin who modified the tag.</param>
    public void Update(string name, string? modifiedBy = "System")
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        Name = name;

        MarkModified(modifiedBy);
    }

    /// <summary>Softly delete a ProductTag and mark as Deleted.</summary>
    /// <param name="deletedBy">Admin who deleted the tag.</param>
    public void Delete(string? deletedBy = "System")
    {
        MarkDeleted(deletedBy);
    }

    /// <summary>Restore a softly deleted ProductTag and mark as Restored.</summary>
    /// <param name="restoredBy">Admin who restored the tag.</param>
    public void Restore(string? restoredBy = "System")
    {
        MarkRestored(restoredBy);
    }
    #endregion
}