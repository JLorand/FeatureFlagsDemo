using AutoMapper;
using FeatureFlagsDemo.DTOs;
using FeatureFlagsDemo.Entities;

namespace FeatureFlagsDemo.Mappers;

public class InvoiceMapper : Profile
{
    public InvoiceMapper()
    {
        CreateMap<Invoice, InvoiceDTO>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
            ;

        CreateMap<InvoiceItem, InvoiceItemDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.SubTotal))
            ;
    }
}