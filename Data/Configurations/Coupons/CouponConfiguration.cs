using Data.Constants;
using Domain.Models.Coupons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations.Coupons;

public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(CommanTypeConst.MaxSize_128)
            .IsRequired();
        builder.Property(p => p.Description)
              .HasMaxLength(CommanTypeConst.MaxSize_128);
        builder.Property(p => p.Code)
            .HasMaxLength(CommanTypeConst.MaxSize_128)
            .IsRequired();
        builder.Property(p => p.Value);
        builder.Property(p => p.IsPercentage)
           .HasMaxLength(CommanTypeConst.MaxSize_128);
        builder.Property(p => p.TypeId)
            .HasMaxLength(CommanTypeConst.MaxSize_128);
        builder.Property(p => p.StartDate)
            .HasMaxLength(CommanTypeConst.MaxSize_128);
        builder.Property(p => p.EndDate);
    }
}
