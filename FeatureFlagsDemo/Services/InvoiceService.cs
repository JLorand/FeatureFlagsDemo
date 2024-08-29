using AutoMapper;
using FeatureFlagsDemo.Database;
using FeatureFlagsDemo.DTOs;
using FeatureFlagsDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeatureFlagsDemo.Services;

public class InvoiceService(AppDbContext dbContext, IMapper mapper) : IInvoiceService
{
    public async Task<List<InvoiceDTO>> GetInvoices()
    {
        var invoices = await dbContext.Invoices.Include(i => i.Items).ToListAsync();
        return mapper.Map<List<Invoice>, List<InvoiceDTO>>(invoices);
    }
}