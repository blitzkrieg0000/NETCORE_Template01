using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.File.Upload;


public class UploadCommandResponse : Response {
    public UploadCommandResponse(ResponseType responseType) : base(responseType) {
        
    }
}
