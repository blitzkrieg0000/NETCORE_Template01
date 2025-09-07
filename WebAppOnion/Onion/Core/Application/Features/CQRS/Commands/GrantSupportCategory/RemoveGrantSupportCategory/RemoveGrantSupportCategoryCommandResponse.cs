using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.GrantSupportCategory.RemoveGrantSupportCategory;


public class RemoveGrantSupportCategoryCommandResponse : Response {
    public RemoveGrantSupportCategoryCommandResponse(ResponseType responseType) : base(responseType) {
    }

    public RemoveGrantSupportCategoryCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }
}
