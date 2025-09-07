using Application.Interfaces.Repository.File.Common.ImageFile;
using Application.Interfaces.Repository.GrantSupports;
using Application.Interfaces.Service.Storage;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.GrantSupport.RemoveGrantSupport;


public class RemoveGrantSupportCommandHandler : IRequestHandler<RemoveGrantSupportCommandRequest, RemoveGrantSupportCommandResponse> {
    private readonly IGrantSupportCommandRepository _grantSupportCommandRepository;
    private readonly IGrantSupportQueryRepository _grantSupportQueryRepository;
    private readonly IImageFileQueryRepository _imageFileQueryRepository;
    private readonly IImageFileCommandRepository _imageFileCommandRepository;
    private readonly IStorageService _storageService;

    public RemoveGrantSupportCommandHandler(IGrantSupportCommandRepository grantSupportCommandRepository, IGrantSupportQueryRepository grantSupportQueryRepository, IImageFileQueryRepository imageFileQueryRepository, IImageFileCommandRepository imageFileCommandRepository, IStorageService storageService) {
        _grantSupportCommandRepository = grantSupportCommandRepository;
        _grantSupportQueryRepository = grantSupportQueryRepository;
        _imageFileQueryRepository = imageFileQueryRepository;
        _imageFileCommandRepository = imageFileCommandRepository;
        _storageService = storageService;
    }


    public async Task<RemoveGrantSupportCommandResponse> Handle(RemoveGrantSupportCommandRequest request, CancellationToken cancellationToken) {
        try {
            var newsAnnouncement = await _grantSupportQueryRepository.GetByIdAsync(request.Id);
            _grantSupportCommandRepository.Remove(newsAnnouncement);

            if (newsAnnouncement.Image != null) {
                var imageEntity = await _imageFileQueryRepository.GetByIdAsync((Guid)newsAnnouncement.Image);
                if (imageEntity != null) {
                    await _storageService.DeleteAsync(imageEntity.Path);
                    _imageFileCommandRepository.Remove(imageEntity);
                }
            }
            await _grantSupportCommandRepository.SaveAsync();
            return new(ResponseType.Success, "Veri Kaldırıldı.");
        } catch {
            return new(ResponseType.NotAllowed, "Veri kullanılıyor.");
        }
    }
}

