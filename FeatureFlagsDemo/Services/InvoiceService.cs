using AutoMapper;
using FeatureFlagsDemo.Database;
using FeatureFlagsDemo.DTOs;
using FeatureFlagsDemo.Entities;
using FeatureFlagsDemo.Features;
using FeatureFlagsDemo.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
// Getting rid of the MS.FeatureManagement third-party library local dependency
using Microsoft.FeatureManagement;

namespace FeatureFlagsDemo.Services;

public class InvoiceService(
    AppDbContext dbContext,
    IMapper mapper,
    IVATCalculationFeature vatCalculationFeature,
    IOptions<VATOptions> vatOptions)
    : IInvoiceService
{
    private readonly VATOptions _vat = vatOptions.Value;

    public async Task<List<InvoiceDTO>> GetInvoices()
    {
        var invoices = await dbContext.Invoices.Include(i => i.Items).ToListAsync();

        if (await vatCalculationFeature.IsEnabled())
        {
            return invoices.Select(i => new InvoiceDTO
            {
                Items = mapper.Map<List<InvoiceItemDTO>>(i.Items),
                Total = i.Total * (1 + _vat.VATPercentage / 100)
            }).ToList();
        }
        
        return mapper.Map<List<Invoice>, List<InvoiceDTO>>(invoices);
    }
}