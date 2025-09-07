using Application.Interfaces.Repository.GrantSupports;
using Application.Models.GrantSupportViewModel;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Queries.GrantSupport.GetRangeGrantSupport;


public class GetRangeGrantSupportQueryHandler : IRequestHandler<GetRangeGrantSupportQueryRequest, GetRangeGrantSupportQueryResponse> {
    private readonly IGrantSupportQueryRepository _grantSupportQueryRepository;
    private readonly IMapper _mapper;
    public GetRangeGrantSupportQueryHandler(IGrantSupportQueryRepository grantSupportQueryRepository, IMapper mapper) {
        _grantSupportQueryRepository = grantSupportQueryRepository;
        _mapper = mapper;
    }


    public async Task<GetRangeGrantSupportQueryResponse> Handle(GetRangeGrantSupportQueryRequest request, CancellationToken cancellationToken) {
        var data = await _grantSupportQueryRepository.GetRangeWithRelationsAsync(request.Skip, request.Range, request.Filter);
        var response = _mapper.Map<List<GrantSupportViewModel>>(data);
        return new(ResponseType.Success, response);
    }
}

