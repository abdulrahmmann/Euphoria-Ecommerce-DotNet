using EuphoriaCommerce.Domain.Bases;

namespace EuphoriaCommerce.Domain.Entities.ProductDomain;

/// <summary>
/// Represents a product badge.
/// <example>New, Hot, Limited</example>
/// </summary>
public class ProductBadge : Entity<Guid>
{
    /// <summary>The badge text.</summary>
    public string Name { get; private set; } = null!;

    /// <summary>The badge color (HEX or tailwind color).</summary>
    public string Color { get; private set; } = null!;

    /// <summary>The product this badge belongs to.</summary>
    public Guid ProductId { get; private set; }

    /// <summary>Navigation to the product.</summary>
    public Product Product { get; private set; } = null!;

    private ProductBadge() { }

    #region Constructor | Create

    /// <summary>Create a Product Badge and mark it as Created.</summary>
    /// <param name="name">Badge name (e.g., Hot, Limited, New).</param>
    /// <param name="color">Badge color.</param>
    /// <param name="productId">The product that owns this badge.</param>
    /// <param name="createdBy">Admin who created this badge.</param>
    public ProductBadge(string name, string color, Guid productId, string? createdBy = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(color);

        Id = Guid.NewGuid();
        Name = name;
        Color = color;
        ProductId = productId;

        MarkCreated(createdBy);
    }

    #endregion

    #region Helper Methods : Update, Delete, Restore
    /// <summary>Update this badge and mark it as Modified.</summary>
    /// <param name="name">Badge name.</param>
    /// <param name="color">Badge color.</param>
    /// <param name="modifiedBy">Admin who made the modification.</param>
    public void Update(string name, string color, string? modifiedBy = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(color);

        Name = name;
        Color = color;

        MarkModified(modifiedBy);
    }

    /// <summary>Soft delete this badge and mark it as Deleted.</summary>
    /// <param name="deletedBy">Admin who deleted the badge.</param>
    public void Delete(string? deletedBy = null)
    {
        MarkDeleted(deletedBy);
    }

    /// <summary>Restore a softly deleted badge and mark it as Restored.</summary>
    /// <param name="restoredBy">Admin who restored the badge.</param>
    public void Restore(string? restoredBy = null)
    {
        MarkRestored(restoredBy);
    }
    #endregion
}
