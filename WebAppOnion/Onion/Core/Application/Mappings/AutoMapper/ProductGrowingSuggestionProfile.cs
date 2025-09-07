using Application.Dtos.GrantSupport;
using Application.Dtos.ProductGrowingSuggestion;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Mappings.AutoMapper;


public class ProductGrowingSuggestionProfile : Profile {

    public ProductGrowingSuggestionProfile() {
        CreateMap<ProductGrowingSuggestion, ProductGrowingSuggestionDto>().ReverseMap();
        CreateMap<ProductGrowingSuggestion, ProductGrowingSuggestionCreateDto>().ReverseMap();
        CreateMap<ProductGrowingSuggestion, ProductGrowingSuggestionUpdateDto>().ReverseMap();
    }

}
