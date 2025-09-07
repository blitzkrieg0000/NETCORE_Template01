using Application.Interfaces.Service.Storage;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.File.Upload;


public class UploadCommandHandler : IRequestHandler<UploadCommandRequest, UploadCommandResponse> {
    readonly IStorageService _storageService;

    public UploadCommandHandler(IStorageService storageService) {
        _storageService = storageService;
    }


    public async Task<UploadCommandResponse> Handle(UploadCommandRequest request, CancellationToken cancellationToken) {
        List<(string fileName, string savedPathName)> result = await _storageService.UploadAsync(request.Files);
        
        return new(ResponseType.Success);
        
    }
    

}
