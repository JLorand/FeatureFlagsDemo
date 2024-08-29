namespace FeatureFlagsDemo.DTOs;

public class InvoiceItemDTO
{
    public required string Name { get; init; }

    public int Quantity { get; init; }

    public decimal Price { get; init; }

    public decimal SubTotal { get; init; }
}