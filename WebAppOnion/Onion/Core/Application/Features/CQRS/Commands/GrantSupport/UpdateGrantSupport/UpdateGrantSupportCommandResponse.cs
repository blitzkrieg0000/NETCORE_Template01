using Common.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.GrantSupport.UpdateGrantSupport
{
    public class UpdateGrantSupportCommandResponse : Response
    {
        public UpdateGrantSupportCommandResponse(ResponseType responseType) : base(responseType)
        {
        }

        public UpdateGrantSupportCommandResponse(ResponseType responseType, string message) : base(responseType, message)
        {
        }
    }
}
