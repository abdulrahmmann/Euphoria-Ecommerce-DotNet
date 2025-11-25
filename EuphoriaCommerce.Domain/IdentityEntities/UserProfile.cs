using System.ComponentModel.DataAnnotations;

namespace EuphoriaCommerce.Domain.IdentityEntities;

public class UserProfile
{
     /// <summary> The user's first name. </summary>
     [StringLength(30, ErrorMessage = "FirstName cannot exceed 30 characters.")]
    public string FirstName { get; private set; } = null!;

    /// <summary> The user's middle or second name (optional). </summary>
    [StringLength(30, ErrorMessage = "SecondName cannot exceed 30 characters.")]
    public string? SecondName { get; private set; } = null!;

    /// <summary> The user's last name or family name. </summary>
    [StringLength(60, ErrorMessage = "LastName cannot exceed 60 characters.")]
    public string LastName { get; private set; } = null!;

    /// <summary> The user's full name, automatically combined from first, second, and last names. </summary>
    [StringLength(120, ErrorMessage = "FullName cannot exceed 120 characters.")]
    public string FullName { get; private set; } = null!;

    /// <summary> URL of the user's profile image or avatar (optional). </summary>
    public string? ProfileImageUrl { get; private set; }

    /// <summary> A short biography or personal description written by the user. </summary>
    [StringLength(1000, ErrorMessage = "Bio cannot exceed 1000 characters.")]
    public string Bio { get; private set; } = null!;
    
    /// <summary> The user's gender. Allowed values: "Male" or "Female"; we are not supporting gays people. </summary>
    public string Gender { get; private set; } = null!;

    /// <summary> The user's address information as a value object. </summary>
    // public Address Address { get; private set; } = null!;
    [StringLength(30, ErrorMessage = "Country cannot exceed 30 characters.")]
    public string Country { get; private set; } = null!;
    [StringLength(30, ErrorMessage = "City cannot exceed 30 characters.")]
    public string City { get; private set; } = null!;
    [StringLength(120, ErrorMessage = "Street cannot exceed 120 characters.")]
    public string Street { get; private set; } = null!;
    [StringLength(30, ErrorMessage = "ZipCode cannot exceed 30 characters.")]
    public string ZipCode { get; private set; } = null!;

    /// <summary> The foreign key referencing the associated application user. </summary>
    public string UserId { get; private set; }

    /// <summary> Navigation property for the related <see cref="ApplicationUser"/>. </summary>
    public ApplicationUser ApplicationUser { get; private set; } = null!;

    private UserProfile() { }

    public UserProfile(string? firstName, string? secondName, string? lastName, string? profileImageUrl, 
        string? bio, string? gender, string? country, string? city, string? street, string? zipCode, string userId)
    {
        ArgumentException.ThrowIfNullOrEmpty(firstName);
        ArgumentException.ThrowIfNullOrEmpty(secondName);
        ArgumentException.ThrowIfNullOrEmpty(lastName);
        ArgumentException.ThrowIfNullOrEmpty(profileImageUrl);
        ArgumentException.ThrowIfNullOrEmpty(bio);
        ArgumentException.ThrowIfNullOrEmpty(gender);
        ArgumentException.ThrowIfNullOrEmpty(country);
        ArgumentException.ThrowIfNullOrEmpty(city);
        ArgumentException.ThrowIfNullOrEmpty(street);
        ArgumentException.ThrowIfNullOrEmpty(zipCode);
        
        FirstName = firstName;
        SecondName = secondName;
        LastName = lastName;
        ProfileImageUrl = profileImageUrl;
        Bio = bio;
        Gender = gender;
        Country =  country;
        City = city;
        Street = street;
        ZipCode = zipCode;
        UserId = userId;

        UpdateFullName();
    }
    
    private void UpdateFullName()
    {
        FullName = $"{FirstName} {SecondName} {LastName}".Replace("  ", " ").Trim();
    }
    
    public void UpdateUserProfile(string? firstName, string? secondName, string? lastName, string? profileImageUrl, 
        string? bio, string? country, string? city, string? street, string? zipCode)
    {
        FirstName = firstName ?? FirstName;
        SecondName = secondName ?? SecondName;
        LastName = lastName ?? LastName;
        ProfileImageUrl = profileImageUrl ?? ProfileImageUrl;
        Bio = bio ?? Bio;
        Country = country ?? Country;
        City = city ?? City;
        Street = street ?? Street;
        ZipCode = zipCode ?? ZipCode;
    }
}