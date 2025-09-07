using Application.Dtos.GrantSupportCategory;
using MediatR;

namespace Application.Features.CQRS.Commands.GrantSupportCategory.CreateGrantSupportCategory;


public class CreateGrantSupportCategoryCommandRequest : IRequest<CreateGrantSupportCategoryCommandResponse> {
    public GrantSupportCategoryCreateDto GrantSupportCategoryCreateDto { get; set; }

    public CreateGrantSupportCategoryCommandRequest(GrantSupportCategoryCreateDto grantSupportCategoryCreateDto) {
        GrantSupportCategoryCreateDto = grantSupportCategoryCreateDto;
    }
}
