using System.Reflection;
using FeatureFlagsDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeatureFlagsDemo.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Invoice> Invoices { get; set; }

    public DbSet<InvoiceItem> InvoiceItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        DbInitializer.SeedData(modelBuilder);
    }
}
