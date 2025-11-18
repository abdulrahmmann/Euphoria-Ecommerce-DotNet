using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;
using EuphoriaCommerce.Domain.IdentityEntities;

namespace EuphoriaCommerce.Domain.Entities.WishlistDomain;

/// <summary>
/// Represents a user's wishlist item.
/// </summary>
public class Wishlist : Entity<Guid>
{
    /// <summary>User ID Foreign key this wishlist belongs to.</summary>
    public string UserId { get; private set; }
    
    /// <summary>Navigation to User.</summary>
    public ApplicationUser? ApplicationUser { get; private set; }

    /// <summary>Product ID Foreign key this wishlist belongs to.</summary>
    public Guid ProductId { get; private set; }

    /// <summary>Navigation to Product.</summary>
    public Product? Product { get; private set; }

    // EF Core only
    private Wishlist() { }

    #region Constructor | Create

    /// <summary>
    /// Constructor | Create wishlist item and mark as Created.
    /// </summary>
    /// <param name="userId">User who added the product.</param>
    /// <param name="productId">Product added to wishlist.</param>
    /// <param name="createdBy">Admin Who Create Wishlist.</param>
    public Wishlist(string userId, Guid productId, string? createdBy = null)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(userId, string.Empty);
        ArgumentOutOfRangeException.ThrowIfEqual(productId, Guid.Empty);

        Id = Guid.NewGuid();
        UserId = userId;
        ProductId = productId;

        MarkCreated(createdBy);
    }

    #endregion

    #region Helper Methods : Delete, Restore

    /// <summary>
    /// Softly delete wishlist item and mark as Deleted.
    /// </summary>
    /// <param name="deletedBy">Admin/user who deleted the record.</param>
    public void Delete(string? deletedBy = null)
    {
        MarkDeleted(deletedBy);
    }

    /// <summary>
    /// Restore a softly deleted wishlist item and mark as Restored.
    /// </summary>
    /// <param name="restoredBy">Admin/user who restored the record.</param>
    public void Restore(string? restoredBy = null)
    {
        MarkRestored(restoredBy);
    }

    #endregion
}
