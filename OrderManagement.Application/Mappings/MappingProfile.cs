using AutoMapper;
using OrderManagement.Application.DTOs;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();
            CreateMap<Customer, UpdateCustomerDto>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CustomerName,
                           opt => opt.MapFrom(src => src.Customer.FullName)); ;

            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductName,
                           opt => opt.MapFrom(src => src.Product.Name)); ;
        }
    }
}
