using EuphoriaCommerce.Domain.Entities.WishlistDomain;
using Microsoft.AspNetCore.Identity;

namespace EuphoriaCommerce.Domain.IdentityEntities;

/// <summary>
/// Represents an application user with authentication and account management details.
/// </summary>
public class ApplicationUser: IdentityUser
{
    /// <summary>
    /// Represent the user account status : active or disabled
    /// If <see langword="false"/>, the user cannot log in.
    /// </summary>
    public bool IsActive { get; private set; } = true;
    
    /// <summary>
    /// Represent the role assigned to the user.
    /// Possible values include:
    /// <list type="bullet">
    /// <item>Admin</item>
    /// <item>User</item>
    /// </list>
    /// </summary>
    public string Role { get; private set; } = string.Empty;
    
    /// <summary> The user's gender. Allowed values: "Male" or "Female"; we are not supporting gays people. </summary>
    public string Gender { get; private set; } = null!;

    /// <summary> Navigation property that references the user's extended profile information. </summary>
    public UserProfile UserProfile { get; private set; } = null!;

    public List<Wishlist> Wishlists = new List<Wishlist>();
    
    #region Refresh Token fields
    /// <summary>
    /// Represent the refresh token assigned to the user.
    /// </summary>
    public string? RefreshToken { get; set; } 
    
    /// <summary>
    /// Represent the expiration date and time of the refresh token.
    /// </summary>
    public DateTime? RefreshTokenExpiration { get; set; }
    #endregion
}