using Application.Dtos.GrantSupport;
using Application.Dtos.GrantSupportCategory;
using Application.Models.GrantSupportViewModel;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Mappings.AutoMapper;


public class GrantSupportProfile : Profile {
    public GrantSupportProfile() {
        CreateMap<GrantSupport, GrantSupportDto>().ReverseMap();
        CreateMap<GrantSupport, GrantSupportCreateDto>().ReverseMap();
        
        CreateMap<GrantSupportUpdateDto, GrantSupport>()
        .ForMember(x => x.Image, opt => opt.Ignore());

        CreateMap<GrantSupport, GrantSupportViewModel>()
        .ForMember(x => x.GrantSupportCategoryDto, opt =>
            opt.MapFrom(src => new GrantSupportCategoryDto() {
                Id = src.GrantSupportCategory.Id,
                Name = src.GrantSupportCategory.Name,
            })
        ).ForMember(x => x.Image, opt => opt.MapFrom(src => src.File.Path));

        CreateMap<GrantSupport, GrantSupportUpdateDto>()
        .ForMember(x => x.Image, opt => opt.MapFrom(src => src.File.Path));
    }

}

