using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.GrantSupport.CreateGrantSupport
{
    public class CreateGrantSupportCommandResponse : Response
    {
        public CreateGrantSupportCommandResponse(ResponseType responseType) : base(responseType)
        {
        }

        public CreateGrantSupportCommandResponse(ResponseType responseType, string message) : base(responseType, message)
        {
        }
    }
}