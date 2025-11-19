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
            profile.Property(x => x.FirstName).IsRequired(false).HasMaxLength(30);
            profile.Property(x => x.SecondName).IsRequired(false).HasMaxLength(30);
            profile.Property(x => x.LastName).IsRequired(false).HasMaxLength(60);
            profile.Property(x => x.FullName).IsRequired(false).HasMaxLength(120);
            profile.Property(x => x.Bio).IsRequired(false).HasMaxLength(1000);
            profile.Property(x => x.Country).IsRequired(false).HasMaxLength(30);
            profile.Property(x => x.City).IsRequired(false).HasMaxLength(30);
            profile.Property(x => x.Street).IsRequired(false).HasMaxLength(30);
            profile.Property(x => x.ZipCode).IsRequired(false).HasMaxLength(30);
            profile.Property(x => x.ProfileImageUrl).IsRequired(false);
        });
    }
}