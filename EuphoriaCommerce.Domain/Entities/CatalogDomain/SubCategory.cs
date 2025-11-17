using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.CatalogDomain;

/// <summary>
/// Represents a sub-category inside a main category.
/// <example>Tops, Printed T-shirts, Plain T-shirts, Kurti, Boxers</example>
/// </summary>
public class SubCategory : Entity<Guid>
{
    /// <summary>The sub-category name.</summary>
    public string Name { get; private set; } = null!;

    /// <summary>The sub-category description.</summary>
    public string Description { get; private set; } = null!;

    /// <summary>Foreign key to the main Category.</summary>
    public Guid CategoryId { get; private set; }

    /// <summary>Navigation property to the main Category.</summary>
    public Category Category { get; private set; } = null!;

    /// <summary>Navigation property to products under this sub-category.</summary>
    public ICollection<Product> Products { get; private set; } = new List<Product>();

    private SubCategory() { }

    #region Constructor | Create
    /// <summary>Constructor | Create a SubCategory and mark as Created.</summary>
    /// <param name="name">Sub-category name.</param>
    /// <param name="description">Sub-category description.</param>
    /// <param name="categoryId">Parent category Id.</param>
    /// <param name="createdBy">Admin who created the sub-category.</param>
    public SubCategory(string name, string description, Guid categoryId, string? createdBy = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);

        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        CategoryId = categoryId;

        MarkCreated(createdBy);
    }
    #endregion

    #region Helper Methods : Update, Delete, Restore
    /// <summary>Update a SubCategory and mark as Modified.</summary>
    /// <param name="name">Sub-category name.</param>
    /// <param name="description">Sub-category description.</param>
    /// <param name="categoryId">Parent category Id.</param>
    /// <param name="modifiedBy">Admin who modified the sub-category.</param>
    public void Update(string name, string description, Guid categoryId, string? modifiedBy = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);

        Name = name;
        Description = description;
        CategoryId = categoryId;

        MarkModified(modifiedBy);
    }

    /// <summary>Softly delete a SubCategory and mark as Deleted.</summary>
    /// <param name="deletedBy">Admin who deleted the sub-category.</param>
    public void Delete(string? deletedBy = null)
    {
        MarkDeleted(deletedBy);
    }

    /// <summary>Restore a softly deleted SubCategory and mark as Restored.</summary>
    /// <param name="restoredBy">Admin who restored the sub-category.</param>
    public void Restore(string? restoredBy = null)
    {
        MarkRestored(restoredBy);
    }
    #endregion
}
