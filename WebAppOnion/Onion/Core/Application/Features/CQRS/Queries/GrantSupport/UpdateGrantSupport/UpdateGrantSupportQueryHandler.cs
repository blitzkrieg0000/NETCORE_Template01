using Application.Dtos.GrantSupport;
using Application.Interfaces.Repository.GrantSupports;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Queries.GrantSupport.UpdateGrantSupport;


public class UpdateGrantSupportQueryHandler : IRequestHandler<UpdateGrantSupportQueryRequest, UpdateGrantSupportQueryResponse> {
    private readonly IGrantSupportQueryRepository _grantSupportQueryRepository;
    private readonly IMapper _mapper;

    public UpdateGrantSupportQueryHandler(IGrantSupportQueryRepository grantSupportQueryRepository, IMapper mapper) {
        _grantSupportQueryRepository = grantSupportQueryRepository;
        _mapper = mapper;
    }

    public async Task<UpdateGrantSupportQueryResponse> Handle(UpdateGrantSupportQueryRequest request, CancellationToken cancellationToken) {
        var data = await _grantSupportQueryRepository.GetByIdWithRelationsAsync(request.Id);
        var response = _mapper.Map<GrantSupportUpdateDto>(data);
        return new(ResponseType.Success, response);
    }
}

