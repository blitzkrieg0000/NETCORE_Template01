using Application.Consts;
using Application.Interfaces.Repository.File.Common.ImageFile;
using Application.Interfaces.Repository.GrantSupports;
using Application.Interfaces.Service.Storage;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.GrantSupport.UpdateGrantSupport;


public class UpdateGrantSupportCommandHandler : IRequestHandler<UpdateGrantSupportCommandRequest, UpdateGrantSupportCommandResponse> {
    private readonly IGrantSupportCommandRepository _grantSupportCommandRepository;
    private readonly IGrantSupportQueryRepository _grantSupportQueryRepository;
    private readonly IImageFileQueryRepository _imageFileQueryRepository;
    private readonly IImageFileCommandRepository _imageFileCommandRepository;
    private readonly IStorageService _storageService;
    private readonly IMapper _mapper;

    public UpdateGrantSupportCommandHandler(IGrantSupportCommandRepository grantSupportCommandRepository, IGrantSupportQueryRepository grantSupportQueryRepository, IImageFileQueryRepository imageFileQueryRepository, IImageFileCommandRepository imageFileCommandRepository, IStorageService storageService, IMapper mapper) {
        _grantSupportCommandRepository = grantSupportCommandRepository;
        _grantSupportQueryRepository = grantSupportQueryRepository;
        _imageFileQueryRepository = imageFileQueryRepository;
        _imageFileCommandRepository = imageFileCommandRepository;
        _storageService = storageService;
        _mapper = mapper;
    }


    public async Task<UpdateGrantSupportCommandResponse> Handle(UpdateGrantSupportCommandRequest request, CancellationToken cancellationToken) {
        var dto = request.GrantSupportUpdateDto;
        var grantSupport = await _grantSupportQueryRepository.GetByIdAsync(dto.Id);
        _mapper.Map(dto, grantSupport); // Varsayılan objenin üzerine mapleme yapılır. Bu sayede değiştirilmeyen veriler sıfırlanmaz.

        // Manage File
        if (dto.Files != null && dto.Files.Count == 1) {

            if (!UploadContentDefaults.AllowedContentTypes.Contains(dto.Files[0].ContentType) || dto.Files[0].Length > 7000000) {
                return new(ResponseType.NotAllowed, UploadContentDefaults.AllowedContentMessage);
            }

            List<(string fileName, string savedPathName)> result = await _storageService.UploadAsync(dto.Files, "data/upload/grant_support");
            var (firstFileName, firstFileSavedPathName) = result.FirstOrDefault();

            if (grantSupport.Image != null) {
                var imageEntity = await _imageFileQueryRepository.GetByIdAsync((Guid)grantSupport.Image, false);
                if (imageEntity != null) {
                    await _storageService.DeleteAsync(imageEntity.Path);
                    imageEntity.FileName = firstFileName;
                    imageEntity.Path = firstFileSavedPathName;
                    imageEntity.Length = dto.Files[0].Length;
                }
            } else {
                var id = await _imageFileCommandRepository.CreateAsync(new() {
                    FileName = firstFileName,
                    Path = firstFileSavedPathName,
                    Length = dto.Files[0].Length,
                    Active = true
                });
                grantSupport.Image = id;
            }
        }

        _grantSupportCommandRepository.UpdateOverwrite(grantSupport);
        await _grantSupportCommandRepository.SaveAsync();

        return new(ResponseType.Success, "Bilgiler güncellendi.");
    }
}

