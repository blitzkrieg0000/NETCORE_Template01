using Application.Interfaces.Repository.NewsAnnouncementCategory;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.NewsAnnouncementCategory.RemoveNewsAnnouncementCategory;


public class RemoveNewsAnnouncementCategoryCommandHandler : IRequestHandler<RemoveNewsAnnouncementCategoryCommandRequest, RemoveNewsAnnouncementCategoryCommandResponse> {
    private readonly INewsAnnouncementCategoryCommandRepository _newsAnnouncementCategoryCommandRepository;
    private readonly INewsAnnouncementCategoryQueryRepository _newsAnnouncementCategoryQueryRepository;

    public RemoveNewsAnnouncementCategoryCommandHandler(INewsAnnouncementCategoryCommandRepository newsAnnouncementCategoryCommandRepository, INewsAnnouncementCategoryQueryRepository newsAnnouncementCategoryQueryRepository) {
        _newsAnnouncementCategoryCommandRepository = newsAnnouncementCategoryCommandRepository;
        _newsAnnouncementCategoryQueryRepository = newsAnnouncementCategoryQueryRepository;
    }

    public async Task<RemoveNewsAnnouncementCategoryCommandResponse> Handle(RemoveNewsAnnouncementCategoryCommandRequest request, CancellationToken cancellationToken) {
        try {
            var entity = await _newsAnnouncementCategoryQueryRepository.GetByIdAsync(request.Id);
            _newsAnnouncementCategoryCommandRepository.Remove(entity);
            await _newsAnnouncementCategoryCommandRepository.SaveAsync();
            return new(ResponseType.Success, "Kategori Kaldırıldı.");
        } catch {
            return new(ResponseType.NotAllowed, "Kategori kullanımdayken silinemez.");
        }
    }
}
