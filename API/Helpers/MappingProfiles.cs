using API.Dtos;
using API.Dtos.Orders;
using API.Dtos.Users;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.StoreName, o => o.MapFrom(s => s.Store.StoreName))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<ProductUrlResolver>());

            CreateMap<Token, TokenDto>()
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.Product.ProductType.Name))
                .ForMember(d => d.StoreName, o => o.MapFrom(s => s.Store.StoreName))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.Name))
                .ForMember(d => d.RecipientName, o => o.MapFrom(s => s.Recipient.FullName))
                .ForMember(d => d.DonatorName, o => o.MapFrom(s => s.Donator.FullName))
                .ForMember(d => d.DonatorEmail, o => o.MapFrom(s => s.Donator.EmailAddress))
                .ForMember(d => d.ImageUrl, o=> o.MapFrom<TokenUrlResolver>()); ;    

            CreateMap<Store, StoreDto>()
                .ForMember(d => d.Country, o => o.MapFrom(s => s.Country.Name))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<StoreUrlResolver>());
                
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();           

            CreateMap<Core.Entities.Identity.UserAddress, UserAddressDto>().ReverseMap();
            CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();  

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.ItemOrdered.ImageUrl))
                .ForMember(d => d.ImageUrl, o=> o.MapFrom<OrderItemUrlResolver>());            
                 
        }
    }
}
