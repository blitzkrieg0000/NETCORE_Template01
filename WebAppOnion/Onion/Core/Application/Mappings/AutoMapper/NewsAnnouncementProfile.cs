using Application.Dtos.NewsAnnouncement;
using Application.Dtos.NewsAnnouncementCategory;
using Application.Models.NewsAnnouncement;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Mappings.AutoMapper;


public class NewsAnnouncementProfile : Profile {

    public NewsAnnouncementProfile() {
        CreateMap<NewsAnnouncementDto, NewsAnnouncement>();
        
        CreateMap<NewsAnnouncement, NewsAnnouncementDto>()
        .ForMember(x=>x.Image, opt=>opt.MapFrom(src=> src.File.Path));

        CreateMap<NewsAnnouncement, NewsAnnouncementViewModel>()
        .ForMember(x => x.NewsAnnouncementCategoryDto, opt =>
            opt.MapFrom(src => new NewsAnnouncementCategoryDto() {
                Id = src.NewsAnnouncementCategory.Id,
                Name = src.NewsAnnouncementCategory.Name,
            })
        ).ForMember(x=>x.Image, opt=>opt.MapFrom(src=> src.File.Path));


        CreateMap<NewsAnnouncement, NewsAnnouncementUpdateDto>()
        .ForMember(x=>x.Image, opt=>opt.MapFrom(src=> src.File.Path));

        CreateMap<NewsAnnouncementUpdateDto, NewsAnnouncement>()
        .ForMember(x => x.Image, opt => opt.Ignore());

        CreateMap<NewsAnnouncement, NewsAnnouncementCreateDto>();

        CreateMap<NewsAnnouncementCreateDto, NewsAnnouncement>()
        .ForMember(x => x.IsPersistent, opt => opt.Ignore());
    }
}