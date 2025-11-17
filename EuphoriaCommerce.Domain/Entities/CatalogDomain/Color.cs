using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.CatalogDomain;

/// <summary>
/// Represents a product color.
/// <example>Red, Blue, Green</example>
/// </summary>
public class Color : Entity<Guid>
{
    /// <summary>The Color Name.</summary>
    public string Name { get; private set; } = null!;

    /// <summary>Hex code representation of the color.</summary>
    public string HexCode { get; private set; } = null!;

    /// <summary>Navigation property to ProductVariants using this color.</summary>
    public ICollection<ProductVariant> Variants { get; private set; } = new List<ProductVariant>();

    private Color() { }

    #region Constructor | Create
    /// <summary>Constructor | Create a Color and mark as Created.</summary>
    /// <param name="name">Color name.</param>
    /// <param name="hexCode">Hex code of the color.</param>
    /// <param name="createdBy">Admin who created the color.</param>
    public Color(string name, string hexCode, string? createdBy = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(hexCode);

        Id = Guid.NewGuid();
        Name = name;
        HexCode = hexCode;

        MarkCreated(createdBy);
    }
    #endregion

    #region Helper Methods : Update, Delete, Restore
    /// <summary>Update a Color and mark as Modified.</summary>
    /// <param name="name">Color name.</param>
    /// <param name="hexCode">Hex code of the color.</param>
    /// <param name="modifiedBy">Admin who modified the color.</param>
    public void Update(string name, string hexCode, string? modifiedBy = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(hexCode);

        Name = name;
        HexCode = hexCode;

        MarkModified(modifiedBy);
    }

    /// <summary>Softly delete a Color and mark as Deleted.</summary>
    /// <param name="deletedBy">Admin who deleted the color.</param>
    public void Delete(string? deletedBy = null)
    {
        MarkDeleted(deletedBy);
    }

    /// <summary>Restore a softly deleted Color and mark as Restored.</summary>
    /// <param name="restoredBy">Admin who restored the color.</param>
    public void Restore(string? restoredBy = null)
    {
        MarkRestored(restoredBy);
    }
    #endregion
}
