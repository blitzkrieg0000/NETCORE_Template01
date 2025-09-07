using Application.Interfaces.Repository.GrantSupports;
using Application.Models.GrantSupportViewModel;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;
using X.PagedList;

namespace Application.Features.CQRS.Queries.GrantSupport.ListGrantSupport;


public class ListGrantSupportQueryHandler : IRequestHandler<ListGrantSupportQueryRequest, ListGrantSupportQueryResponse> {
    private readonly IGrantSupportQueryRepository _grantSupportQueryRepository;
    private readonly IMapper mapper;

    public ListGrantSupportQueryHandler(IMapper mapper, IGrantSupportQueryRepository grantSupportQueryRepository) {
        this.mapper = mapper;
        _grantSupportQueryRepository = grantSupportQueryRepository;
    }


    public async Task<ListGrantSupportQueryResponse> Handle(ListGrantSupportQueryRequest request, CancellationToken cancellationToken) {
        var grantsupport = await _grantSupportQueryRepository.GetRangePagedListWithRelationsAsync(request.PaginatorModel.Page, request.PaginatorModel.Range, request.Filter);
        var data = mapper.Map<IPagedList<GrantSupportViewModel>>(grantsupport);
        return new ListGrantSupportQueryResponse(ResponseType.Success, data);
    }
}

