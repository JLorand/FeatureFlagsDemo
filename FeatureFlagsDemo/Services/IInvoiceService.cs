using FeatureFlagsDemo.DTOs;
using FeatureFlagsDemo.Entities;

namespace FeatureFlagsDemo.Services;

public interface IInvoiceService
{
    Task<List<InvoiceDTO>> GetInvoices();
}
