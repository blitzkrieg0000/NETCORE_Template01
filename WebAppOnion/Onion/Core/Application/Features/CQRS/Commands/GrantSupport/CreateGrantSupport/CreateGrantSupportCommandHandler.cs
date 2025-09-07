
using Application.Consts;
using Application.Interfaces.Repository.File.Common.ImageFile;
using Application.Interfaces.Repository.GrantSupports;
using Application.Interfaces.Service.Storage;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;


namespace Application.Features.CQRS.Commands.GrantSupport.CreateGrantSupport {
    public class CreateGrantSupportCommandHandler : IRequestHandler<CreateGrantSupportCommandRequest, CreateGrantSupportCommandResponse> {
        private readonly IGrantSupportCommandRepository _repository;
        private readonly IStorageService _storageService;
        private readonly IImageFileQueryRepository _imageFileQueryRepository;
        private readonly IImageFileCommandRepository _imageFileCommandRepository;
        private readonly IMapper _mapper;

        public CreateGrantSupportCommandHandler(IGrantSupportCommandRepository repository, IStorageService storageService, IImageFileQueryRepository imageFileQueryRepository, IImageFileCommandRepository imageFileCommandRepository, IMapper mapper) {
            _repository = repository;
            _storageService = storageService;
            _imageFileQueryRepository = imageFileQueryRepository;
            _imageFileCommandRepository = imageFileCommandRepository;
            _mapper = mapper;
        }


        public async Task<CreateGrantSupportCommandResponse> Handle(CreateGrantSupportCommandRequest request, CancellationToken cancellationToken) {
            var dto = request._grantSupportCreateDto; //servise geçirilecek bu yüzden.

            var grantSupport = _mapper.Map<Domain.Entities.Concrete.GrantSupport>(dto);

            // Manage File
            if (dto.Files != null && dto.Files.Count == 1) {
                if (!UploadContentDefaults.AllowedContentTypes.Contains(dto.Files[0].ContentType) || dto.Files[0].Length > 7000000) {
                    return new(ResponseType.NotAllowed, UploadContentDefaults.AllowedContentMessage);
                }

                List<(string fileName, string savedPathName)> result = await _storageService.UploadAsync(dto.Files, "data/upload/grant_support");
                var (firstFileName, firstFileSavedPathName) = result.FirstOrDefault();

                //Yüklenen dosyayı veri tabanına kaydet
                Guid id = await _imageFileCommandRepository.CreateAsync(new() {
                    FileName = firstFileName,
                    Path = firstFileSavedPathName,
                    Active = true
                });

                grantSupport.Image = id;
            }

            await _repository.CreateAsync(grantSupport);
            await _repository.SaveAsync();

            return new(ResponseType.Success, "Bilgiler eklendi.");
        }
    }
}
