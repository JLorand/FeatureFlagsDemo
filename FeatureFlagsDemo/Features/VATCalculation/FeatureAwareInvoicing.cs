using FeatureFlagsDemo.DTOs;
using FeatureFlagsDemo.Features.VATCalculation.InvoicingFeatures;

namespace FeatureFlagsDemo.Features.VATCalculation;

public class FeatureAwareInvoicing(IVATCalculationFeature vatCalculationFeature, IEnumerable<IInvoicing> invoicing)
{
    public async Task<List<InvoiceDTO>> CreateInvoice()
    {
        var invoicingService = await GetInvoicing();
        return await invoicingService.CreateInvoice();
    }

    private async Task<IInvoicing> GetInvoicing()
    {
        return await vatCalculationFeature.IsEnabled() 
            ? GetInvoicing(InvoicingType.VAT) 
            : GetInvoicing(InvoicingType.Basic);
    }

    private IInvoicing GetInvoicing(InvoicingType invoicingType)
    {
        return invoicing.FirstOrDefault(x => x.InvoicingType == invoicingType)!;
    }
}