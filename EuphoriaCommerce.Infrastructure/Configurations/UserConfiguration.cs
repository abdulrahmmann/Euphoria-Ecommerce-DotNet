using EuphoriaCommerce.Domain.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuphoriaCommerce.Infrastructure.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(temp => temp.Id).HasName("PK_UserId");

        builder.Property(temp => temp.IsActive).IsRequired().HasDefaultValue(true);
        
        builder.OwnsOne(temp => temp.UserProfile, profile =>
        {
            profile.Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            profile.Property(x => x.SecondName).IsRequired().HasMaxLength(30);
            profile.Property(x => x.LastName).IsRequired().HasMaxLength(60);
            profile.Property(x => x.FullName).IsRequired().HasMaxLength(120);
            profile.Property(x => x.Bio).IsRequired().HasMaxLength(1000);
            profile.Property(x => x.Country).IsRequired().HasMaxLength(30);
            profile.Property(x => x.City).IsRequired().HasMaxLength(30);
            profile.Property(x => x.Street).IsRequired().HasMaxLength(30);
            profile.Property(x => x.ZipCode).IsRequired().HasMaxLength(30);
            profile.Property(x => x.ProfileImageUrl).IsRequired();
        });
    }
}