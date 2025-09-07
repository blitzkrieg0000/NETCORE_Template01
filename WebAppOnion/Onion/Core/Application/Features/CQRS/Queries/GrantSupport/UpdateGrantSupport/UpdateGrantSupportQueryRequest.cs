using MediatR;

namespace Application.Features.CQRS.Queries.GrantSupport.UpdateGrantSupport;


public class UpdateGrantSupportQueryRequest : IRequest<UpdateGrantSupportQueryResponse> {
    public Guid Id { get; set; }
}

