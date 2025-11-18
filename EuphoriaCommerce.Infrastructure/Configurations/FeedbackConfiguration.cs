using EuphoriaCommerce.Domain.Entities.ReviewDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuphoriaCommerce.Infrastructure.Configurations;

public class FeedbackConfiguration: BaseEntityConfiguration<Feedback>
{
    public override void Configure(EntityTypeBuilder<Feedback> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Feedbacks");
        
        builder.HasKey(temp => temp.Id).HasName("PK_FeedbackId");

        builder.HasIndex(temp => temp.Id);

        builder.Property(temp => temp.Rating).IsRequired();
        
        builder.Property(temp => temp.Comment).IsRequired().HasMaxLength(200);
        
        builder
            .HasOne(w => w.Product)
            .WithMany(f => f.Feedbacks)
            .HasForeignKey(w => w.ProductId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Feedback_Product_Id");
    }
}