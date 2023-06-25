using AutoMapper;
using Shop.Services.Dtos.BrandDtos;
using Shop.Services.Dtos.ProductDtos;
using Shop.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Shop.Services.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile(IHttpContextAccessor accessor)
        {
            var uriBuilder = new UriBuilder(accessor.HttpContext.Request.Scheme, accessor.HttpContext.Request.Host.Host, accessor.HttpContext.Request.Host.Port ?? -1);
            if (uriBuilder.Uri.IsDefaultPort)
            {
                uriBuilder.Port = -1;
            }
            string baseUrl = uriBuilder.Uri.AbsoluteUri;

            CreateMap<Product, ProductGetDto>()
                .ForMember(dest => dest.ImageUrl, m => m.MapFrom(s => baseUrl + $"uploads/products/{s.ImageName}"));
            CreateMap<ProductPostDto, Product>();
            CreateMap<Product, ProductGetAllItemDto>()
                .ForMember(dest => dest.HasDiscount, m => m.MapFrom(s => s.DiscountPercent > 0))
                .ForMember(dest => dest.ImageUrl, m => m.MapFrom(s =>s.ImageName==null?null: baseUrl + $"uploads/products/{s.ImageName}"));


            CreateMap<BrandPostDto, Brand>();
            CreateMap<Brand, BrandGetAllItemDto>();
            CreateMap<Brand, BrandInProductGetDto>();
            CreateMap<Brand,BrandGetDto>();
        }
    }
}
