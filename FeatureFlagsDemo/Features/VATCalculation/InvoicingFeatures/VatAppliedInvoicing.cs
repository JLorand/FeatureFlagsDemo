using AutoMapper;
using FeatureFlagsDemo.Database;
using FeatureFlagsDemo.DTOs;
using FeatureFlagsDemo.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FeatureFlagsDemo.Features.VATCalculation.InvoicingFeatures;

public class VatAppliedInvoicing(AppDbContext dbContext, IMapper mapper, IOptionsSnapshot<VATOptions> vatOptions) : IInvoicing
{
    private readonly VATOptions _vat = vatOptions.Value;
    
    public InvoicingType InvoicingType => InvoicingType.VAT;
    
    public async Task<List<InvoiceDTO>> CreateInvoice()
    {
        var invoices = await dbContext.Invoices.Include(i => i.Items).ToListAsync();
        return invoices.Select(i => new InvoiceDTO
        {
            Items = mapper.Map<List<InvoiceItemDTO>>(i.Items),
            Total = i.Total * (1 + _vat.VATPercentage / 100)
        }).ToList();
    }
}