using Application.Interfaces.Repository.GrantSupportCategory;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.GrantSupportCategory.RemoveGrantSupportCategory;


public class RemoveGrantSupportCategoryCommandHandler : IRequestHandler<RemoveGrantSupportCategoryCommandRequest, RemoveGrantSupportCategoryCommandResponse> {
    private readonly IGrantSupportCategoryQueryRepository _grantSupportCategoryQueryRepository;
    private readonly IGrantSupportCategoryCommandRepository _grantSupportCategoryCommandRepository;

    public RemoveGrantSupportCategoryCommandHandler(IGrantSupportCategoryQueryRepository grantSupportCategoryQueryRepository, IGrantSupportCategoryCommandRepository grantSupportCategoryCommandRepository) {
        _grantSupportCategoryQueryRepository = grantSupportCategoryQueryRepository;
        _grantSupportCategoryCommandRepository = grantSupportCategoryCommandRepository;
    }

    public async Task<RemoveGrantSupportCategoryCommandResponse> Handle(RemoveGrantSupportCategoryCommandRequest request, CancellationToken cancellationToken) {

        try {
            var entity = await _grantSupportCategoryQueryRepository.GetByIdAsync(request.Id);
            _grantSupportCategoryCommandRepository.Remove(entity);
            await _grantSupportCategoryCommandRepository.SaveAsync();
            return new(ResponseType.Success, "Kategori Kaldırıldı.");
        } catch {
            return new(ResponseType.NotAllowed, "Kategori kullanımdayken silinemez.");
        }

    }
}
