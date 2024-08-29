namespace FeatureFlagsDemo.Entities;

public class InvoiceItem : BaseEntity
{
    public required string Name { get; init; }

    public int Quantity { get; init; }

    public decimal Price { get; init; }
    
    public decimal SubTotal => Quantity * Price;
    
    
    public long InvoiceId { get; init; }
    
    public Invoice Invoice { get; init; } = null!;
}
