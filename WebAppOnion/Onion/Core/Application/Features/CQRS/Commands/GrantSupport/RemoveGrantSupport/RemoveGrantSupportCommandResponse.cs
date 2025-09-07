using Application.Dtos.GrantSupport;
using Common.ResponseObjects;


namespace Application.Features.CQRS.Commands.GrantSupport.RemoveGrantSupport
{
    public class RemoveGrantSupportCommandResponse : Response<GrantSupportDto>
    {
        public RemoveGrantSupportCommandResponse(ResponseType responseType) : base(responseType)
        {
        }

        public RemoveGrantSupportCommandResponse(ResponseType responseType, string message) : base(responseType, message)
        {
        }
    }
}
