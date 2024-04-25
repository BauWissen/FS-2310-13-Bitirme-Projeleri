using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesUp.Entity;
using SalesUp.Entity.Identity;
using SalesUp.Shared.ComplexTypes;

namespace SalesUp.Data.Concrete.Configs;

public class SubscriptionConfig : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Duration).IsRequired();
        builder.Property(x => x.DurationUnit).IsRequired();
        builder.Property(x => x.Price).IsRequired().HasColumnType("real");
        builder.Property(x => x.SubscriptionType).IsRequired();

        builder.HasData(
            new Subscription
            {
                Id = 1,
                Name = "6 Aylık Abonelik",
                SubscriptionType = SubscriptionType.Monthly,
                Price = 1000,
                Duration = 6,
                DurationUnit = "Ay",
                Description = "Her ay düzenli olarak ödenecek olan abonelik sistemidir.",
            },
            new Subscription
            {
                Id = 2,
                Name = "12 Aylık Abonelik",
                SubscriptionType = SubscriptionType.Year,
                Price = 800,
                Duration = 12,
                DurationUnit = "Ay",
                Description = "Her ay düzenli olarak ödenecek olan abonelik sistemidir."
            },
        new Subscription
            {
                Id = 3,
                Name = "24 Aylık Abonelik",
                SubscriptionType = SubscriptionType.TwoYears,
                Price = 500,
                Duration = 24,
                DurationUnit = "Ay",
                Description = "Her ay düzenli olarak ödenecek olan abonelik sistemidir."
            }
            
        );
    }
};