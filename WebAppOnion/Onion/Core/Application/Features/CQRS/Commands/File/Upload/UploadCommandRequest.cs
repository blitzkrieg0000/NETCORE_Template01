using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CQRS.Commands.File.Upload;


public class UploadCommandRequest : IRequest<UploadCommandResponse> {
    public string Id { get; set; }
    public IFormFileCollection? Files { get; set; }
}
