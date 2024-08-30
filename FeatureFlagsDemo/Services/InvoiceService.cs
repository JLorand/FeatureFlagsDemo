using FeatureFlagsDemo.DTOs;
using FeatureFlagsDemo.Features.VATCalculation;

namespace FeatureFlagsDemo.Services;

public class InvoiceService(FeatureAwareInvoicing featureAwareInvoicing) : IInvoiceService
{
    public async Task<List<InvoiceDTO>> GetInvoices()
    {
        return await featureAwareInvoicing.CreateInvoice();
    }
}