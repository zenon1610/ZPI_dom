using AutoMapper;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;
using System.Linq;

namespace WebStore.Services.Configuration.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            // Mapowanie Product -> ProductVm
            CreateMap<Product, ProductVm>()
                .ForMember(dest => dest.Quantity,
                    opt => opt.MapFrom(src => src.ProductStocks.Sum(ps => ps.Quantity)));

            // Mapowanie AddOrUpdateProductVm -> Product
            CreateMap<AddOrUpdateProductVm, Product>()
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Supplier, opt => opt.Ignore())
                .ForMember(dest => dest.ProductStocks, opt => opt.Ignore())
                .ForMember(dest => dest.OrderProducts, opt => opt.Ignore());

            // Dodaj tutaj inne mapowania w razie potrzeby

            // CreateMap<Order, OrderVm>().ReverseMap();
            // CreateMap<Invoice, InvoiceVm>().ReverseMap();
            // CreateMap<StationaryStore, StoreVm>().ReverseMap();
            // CreateMap<Address, AddressVm>().ReverseMap();

            CreateMap<Order, OrderVm>().ReverseMap()
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                .ForMember(dest => dest.OrderProducts, opt => opt.Ignore());

            CreateMap<Invoice, InvoiceVm>().ReverseMap()
                .ForMember(dest => dest.Order, opt => opt.Ignore());

            CreateMap<StationaryStore, StoreVm>().ReverseMap()
                .ForMember(dest => dest.Addresses, opt => opt.Ignore())
                .ForMember(dest => dest.Employees, opt => opt.Ignore());

            CreateMap<Address, AddressVm>().ReverseMap()
                .ForMember(dest => dest.Customer, opt => opt.Ignore());
        }
    }
}
