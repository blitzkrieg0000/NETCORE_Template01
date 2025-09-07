
using Application.Dtos.ProductGrowingSuggestionCategory;
using AutoMapper;
using Domain.Entities.Concrete;


namespace Application.Mappings.AutoMapper
{
    public class ProductGrowingSuggestionCategoryProfile: Profile {

        public ProductGrowingSuggestionCategoryProfile()
        {
            CreateMap<ProductGrowingSuggestionCategory, ProductGrowingSuggestionCategoryDto>().ReverseMap();
        }
    }
}
