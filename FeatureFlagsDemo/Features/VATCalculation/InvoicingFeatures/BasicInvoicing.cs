using AutoMapper;
using FeatureFlagsDemo.Database;
using FeatureFlagsDemo.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FeatureFlagsDemo.Features.VATCalculation.InvoicingFeatures;

public class BasicInvoicing(AppDbContext dbContext, IMapper mapper) : IInvoicing
{
    public InvoicingType InvoicingType => InvoicingType.Basic;
    
    public async Task<List<InvoiceDTO>> CreateInvoice()
    {
        var invoices = await dbContext.Invoices.Include(i => i.Items).ToListAsync();
        return mapper.Map<List<InvoiceDTO>>(invoices);
    }
}