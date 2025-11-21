using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.ReviewDomain;

/// <summary>
/// Represents a product feedback or review.
/// </summary>
public class Feedback : Entity<Guid>
{
    /// <summary>The rating given to the product (1-5).</summary>
    public int Rating { get; private set; }

    /// <summary>User comment about the product.</summary>
    public string Comment { get; private set; } = null!;

    /// <summary>The product being reviewed.</summary>
    public Guid ProductId { get; private set; }

    /// <summary>Navigation property to product.</summary>
    public Product? Product { get; private set; }

    // EF Core
    private Feedback() { }

    #region Constructor | Create

    /// <summary>
    /// Constructor | Create a feedback entry and mark as Created.
    /// </summary>
    /// <param name="rating">Rating value (1-5).</param>
    /// <param name="comment">User comment.</param>
    /// <param name="productId">The reviewed product.</param>
    /// <param name="createdBy">User/admin who created the feedback.</param>
    public Feedback(int rating, string comment, Guid productId, string? createdBy = "System")
    {
        if (rating is < 1 or > 5)
            throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be between 1 and 5.");

        ArgumentException.ThrowIfNullOrEmpty(comment);
        ArgumentOutOfRangeException.ThrowIfEqual(productId, Guid.Empty);

        Id = Guid.NewGuid();
        Rating = rating;
        Comment = comment;
        ProductId = productId;

        MarkCreated(createdBy);
    }

    #endregion

    #region Helper Methods : Update, Delete, Restore

    /// <summary>
    /// Update a feedback entry and mark as Modified.
    /// </summary>
    /// <param name="rating">New rating.</param>
    /// <param name="comment">New comment.</param>
    /// <param name="modifiedBy">User/admin who modified the entry.</param>
    public void Update(int rating, string comment, string? modifiedBy = "System")
    {
        if (rating is < 1 or > 5)
            throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be between 1 and 5.");

        ArgumentException.ThrowIfNullOrEmpty(comment);

        Rating = rating;
        Comment = comment;

        MarkModified(modifiedBy);
    }

    /// <summary>
    /// Soft delete feedback and mark as Deleted.
    /// </summary>
    /// <param name="deletedBy">User/admin who deleted the feedback.</param>
    public void Delete(string? deletedBy = "System")
    {
        MarkDeleted(deletedBy);
    }

    /// <summary>
    /// Restore a softly deleted feedback and mark as Restored.
    /// </summary>
    /// <param name="restoredBy">User/admin who restored the feedback.</param>
    public void Restore(string? restoredBy = "System")
    {
        MarkRestored(restoredBy);
    }

    #endregion
}
