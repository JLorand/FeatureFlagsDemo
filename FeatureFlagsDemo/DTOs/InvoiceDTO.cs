namespace FeatureFlagsDemo.DTOs;

public class InvoiceDTO
{
    public List<InvoiceItemDTO> Items { get; init; } = new();

    public decimal Total { get; init; }
}