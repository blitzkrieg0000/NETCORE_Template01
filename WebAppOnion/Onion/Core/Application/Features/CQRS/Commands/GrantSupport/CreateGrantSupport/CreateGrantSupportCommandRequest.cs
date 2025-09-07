using Application.Dtos.GrantSupport;
using MediatR;


namespace Application.Features.CQRS.Commands.GrantSupport.CreateGrantSupport
{
    public class CreateGrantSupportCommandRequest :IRequest<CreateGrantSupportCommandResponse>
    {
        public GrantSupportCreateDto? _grantSupportCreateDto;

        public CreateGrantSupportCommandRequest(GrantSupportCreateDto? grantSupportCreateDto)
        {
            _grantSupportCreateDto = grantSupportCreateDto;
        }
    }

    
}
