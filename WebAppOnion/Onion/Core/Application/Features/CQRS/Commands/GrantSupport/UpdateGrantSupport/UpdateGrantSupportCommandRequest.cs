using Application.Dtos.GrantSupport;
using MediatR;

namespace Application.Features.CQRS.Commands.GrantSupport.UpdateGrantSupport;


public class UpdateGrantSupportCommandRequest : IRequest<UpdateGrantSupportCommandResponse> {
    public GrantSupportUpdateDto? GrantSupportUpdateDto { get; set; }

    public UpdateGrantSupportCommandRequest(GrantSupportUpdateDto? grantSupportUpdateDto) {
        GrantSupportUpdateDto = grantSupportUpdateDto;
    }
}

