using Application.Dtos.NewsAnnouncementCategory;
using MediatR;

namespace Application.Features.CQRS.Commands.NewsAnnouncementCategory.CreateNewsAnnouncementCategory;


public class CreateNewsAnnouncementCategoryCommandRequest : IRequest<CreateNewsAnnouncementCategoryCommandResponse>{
    public NewsAnnouncementCategoryCreateDto NewsAnnouncementCategoryCreateDto;

    public CreateNewsAnnouncementCategoryCommandRequest(NewsAnnouncementCategoryCreateDto newsAnnouncementCategoryCreateDto) {
        NewsAnnouncementCategoryCreateDto = newsAnnouncementCategoryCreateDto;
        NewsAnnouncementCategoryCreateDto.Active = true;
    }
}
