using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.ReviewDomain;

/// <summary> Represents a product feedback or review. </summary>
public class Feedback : Entity<Guid>
{
    public int Rating { get; private set; }
    public string Comment { get; private set; } = null!;
    
    public Guid ProductId { get; private set; }
    public Product? Product { get; private set; }

    private Feedback() { }

    private Feedback(int rating, string comment, Guid productId)
    {
        Id = Guid.NewGuid();
        
        Rating = rating;
        Comment = comment;
        ProductId = productId;
    }
}