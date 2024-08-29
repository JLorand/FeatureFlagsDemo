using FeatureFlagsDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeatureFlagsDemo.Database.EntityTypeConfigurations;

public class InvoiceItemEntityTypeConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder
            .Property(x => x.Name)
            .HasMaxLength(125);
    }
}
