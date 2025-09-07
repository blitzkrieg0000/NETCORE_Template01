using MediatR;

namespace Application.Features.CQRS.Commands.NewsAnnouncementCategory.RemoveNewsAnnouncementCategory;


public class RemoveNewsAnnouncementCategoryCommandRequest : IRequest<RemoveNewsAnnouncementCategoryCommandResponse> {
    public Guid Id { get; set; }
}
