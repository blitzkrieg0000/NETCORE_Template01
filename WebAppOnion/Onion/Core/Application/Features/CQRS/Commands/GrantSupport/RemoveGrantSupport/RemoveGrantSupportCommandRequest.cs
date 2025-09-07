using MediatR;


namespace Application.Features.CQRS.Commands.GrantSupport.RemoveGrantSupport
{
    public class RemoveGrantSupportCommandRequest : IRequest<RemoveGrantSupportCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
