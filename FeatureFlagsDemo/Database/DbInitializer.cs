using FeatureFlagsDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeatureFlagsDemo.Database;

public static class DbInitializer
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>().HasData(
            new Invoice
            {
                Id = 1
            }
        );
        
        modelBuilder.Entity<InvoiceItem>().HasData(new InvoiceItem()
        {
            Id = 1,
            InvoiceId = 1,
            Name = "Item 1",
            Price = 10,
            Quantity = 1
        });
        
        modelBuilder.Entity<InvoiceItem>().HasData(new InvoiceItem()
        {
            Id = 2,
            InvoiceId = 1,
            Name = "Item 2",
            Price = 20,
            Quantity = 2
        });
        
        modelBuilder.Entity<InvoiceItem>().HasData(new InvoiceItem()
        {
            Id = 3,
            InvoiceId = 1,
            Name = "Item 3",
            Price = 30,
            Quantity = 3
        });
    }
}
