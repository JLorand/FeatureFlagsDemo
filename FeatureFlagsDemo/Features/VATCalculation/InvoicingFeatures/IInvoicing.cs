using FeatureFlagsDemo.DTOs;

namespace FeatureFlagsDemo.Features.VATCalculation.InvoicingFeatures;

public interface IInvoicing
{
    public InvoicingType InvoicingType { get; }
    
    Task<List<InvoiceDTO>> CreateInvoice();
}