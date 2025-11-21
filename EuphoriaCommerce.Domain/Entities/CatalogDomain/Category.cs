using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.CatalogDomain;

/// <summary>
/// Represents a product category.
/// <example>Shoes, Tops, Dresses, Pants, Shirts, Plain, Hoodies, Kurti, Accessories, Boxers.</example>
/// </summary>
public class Category : Entity<Guid>
{
    /// <summary>The category name.</summary>
    public string Name { get; private set; } = null!;

    /// <summary>The category description.</summary>
    public string Description { get; private set; } = null!;

    /// <summary>Navigation property to products in this category.</summary>
    public ICollection<Product> Products { get; private set; } = new List<Product>();

    /// <summary>Navigation property to subcategories under this category.</summary>

    private Category() { }

    #region Constructor | Create
    /// <summary>Constructor | Create a Category and mark as Created.</summary>
    /// <param name="name">Category name.</param>
    /// <param name="description">Category description.</param>
    /// <param name="createdBy">Admin who created the category.</param>
    public Category(string name, string description, string? createdBy = "System")
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);

        Id = Guid.NewGuid();
        Name = name;
        Description = description;

        MarkCreated(createdBy);
    }
    #endregion

    #region Helper Methods : Update, Delete, Restore
    /// <summary>Update a Category and mark as Modified.</summary>
    /// <param name="name">Category name.</param>
    /// <param name="description">Category description.</param>
    /// <param name="modifiedBy">Admin who modified the category.</param>
    public void Update(string name, string description, string? modifiedBy = "System")
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);

        Name = name;
        Description = description;

        MarkModified(modifiedBy);
    }

    /// <summary>Softly delete a Category and mark as Deleted.</summary>
    /// <param name="deletedBy">Admin who deleted the category.</param>
    public void Delete(string? deletedBy = "System")
    {
        MarkDeleted(deletedBy);
    }

    /// <summary>Restore a softly deleted Category and mark as Restored.</summary>
    /// <param name="restoredBy">Admin who restored the category.</param>
    public void Restore(string? restoredBy = "System")
    {
        MarkRestored(restoredBy);
    }
    #endregion
}
