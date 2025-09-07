using Application.Dtos.NewsAnnouncementCategory;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Mappings.AutoMapper;


public class NewsAnnouncementCategoryProfile : Profile {

    public NewsAnnouncementCategoryProfile() {

        CreateMap<NewsAnnouncementCategory, NewsAnnouncementCategoryDto>().ReverseMap();

        CreateMap<NewsAnnouncementCategory, NewsAnnouncementCategoryCreateDto>().ReverseMap();

    }


}
