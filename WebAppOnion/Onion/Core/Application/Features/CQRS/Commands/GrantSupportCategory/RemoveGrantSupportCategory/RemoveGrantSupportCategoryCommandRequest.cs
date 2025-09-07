using MediatR;

namespace Application.Features.CQRS.Commands.GrantSupportCategory.RemoveGrantSupportCategory;


public class RemoveGrantSupportCategoryCommandRequest : IRequest<RemoveGrantSupportCategoryCommandResponse> {
    public Guid Id { get; set; }
}
