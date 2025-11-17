using EuphoriaCommerce.Domain.Bases;

namespace EuphoriaCommerce.Domain.Entities.ProductDomain;

/// <summary>
/// Represents a product image.
/// <example>Main image, Thumbnail image, Gallery image</example>
/// </summary>
public class ProductImage : Entity<Guid>
{
    /// <summary>URL of the image.</summary>
    public string ImageUrl { get; private set; } = null!;

    /// <summary>Indicates if this image is the main product image.</summary>
    public bool IsMain { get; private set; } = false;

    /// <summary>Foreign key to the Product.</summary>
    public Guid ProductId { get; private set; }

    /// <summary>Navigation property to the Product.</summary>
    public Product Product { get; private set; } = null!;

    private ProductImage() { }

    #region Constructor | Create
    /// <summary>Constructor | Create a ProductImage and mark as Created.</summary>
    /// <param name="imageUrl">Image URL.</param>
    /// <param name="isMain">Indicates if main image.</param>
    /// <param name="productId">Associated product Id.</param>
    /// <param name="createdBy">Admin who created the image.</param>
    public ProductImage(string imageUrl, bool isMain, Guid productId, string? createdBy = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(imageUrl);

        Id = Guid.NewGuid();
        ImageUrl = imageUrl;
        IsMain = isMain;
        ProductId = productId;

        MarkCreated(createdBy);
    }
    #endregion

    #region Helper Methods : Update, Delete, Restore
    /// <summary>Update a ProductImage and mark as Modified.</summary>
    /// <param name="imageUrl">Image URL.</param>
    /// <param name="isMain">Indicates if main image.</param>
    /// <param name="modifiedBy">Admin who modified the image.</param>
    public void Update(string imageUrl, bool isMain, string? modifiedBy = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(imageUrl);

        ImageUrl = imageUrl;
        IsMain = isMain;

        MarkModified(modifiedBy);
    }

    /// <summary>Softly delete a ProductImage and mark as Deleted.</summary>
    /// <param name="deletedBy">Admin who deleted the image.</param>
    public void Delete(string? deletedBy = null)
    {
        MarkDeleted(deletedBy);
    }

    /// <summary>Restore a softly deleted ProductImage and mark as Restored.</summary>
    /// <param name="restoredBy">Admin who restored the image.</param>
    public void Restore(string? restoredBy = null)
    {
        MarkRestored(restoredBy);
    }
    #endregion
}
