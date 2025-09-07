using Application.Dtos.GrantSupportCategory;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Mappings.AutoMapper;


public class GrantSupportCategoryProfile : Profile {
    public GrantSupportCategoryProfile() {
        CreateMap<GrantSupportCategory, GrantSupportCategoryDto>().ReverseMap();
        CreateMap<GrantSupportCategory, GrantSupportCategoryCreateDto>().ReverseMap();
    }
}

