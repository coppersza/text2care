using API.Dtos;
using AutoMapper;
using Core.Entities;

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
                .ForMember(d => d.Recipient, o => o.MapFrom(s => s.Recipient.FullName))
                .ForMember(d => d.Donator, o => o.MapFrom(s => s.Donator.FullName))
                .ForMember(d => d.DonatorEmail, o => o.MapFrom(s => s.Donator.EmailAddress))
                .ForMember(d => d.ImageUrl, o=> o.MapFrom<TokenUrlResolver>()); ;                

        }
    }
}
