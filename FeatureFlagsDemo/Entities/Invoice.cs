using System.Text;

namespace FeatureFlagsDemo.Entities;

public class Invoice : BaseEntity
{
    public List<InvoiceItem> Items { get; init; } = new();

    public decimal Total => Items.Select(x => x.SubTotal).Sum();
}
