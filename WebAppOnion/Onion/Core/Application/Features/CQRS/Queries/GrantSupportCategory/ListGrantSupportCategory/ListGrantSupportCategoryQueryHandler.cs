using Application.Dtos.GrantSupportCategory;
using Application.Interfaces.Repository.GrantSupportCategory;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Queries.GrantSupportCategory.ListGrantSupportCategory;


public class ListGrantSupportCategoryQueryHandler : IRequestHandler<ListGrantSupportCategoryQueryRequest, ListGrantSupportCategoryQueryResponse> {
    private readonly IGrantSupportCategoryQueryRepository _grantSupportCategoryQueryRepository;
    private readonly IMapper _mapper;

    public ListGrantSupportCategoryQueryHandler(IGrantSupportCategoryQueryRepository grantSupportCategoryQueryRepository, IMapper mapper) {
        _grantSupportCategoryQueryRepository = grantSupportCategoryQueryRepository;
        _mapper = mapper;
    }

    public async Task<ListGrantSupportCategoryQueryResponse> Handle(ListGrantSupportCategoryQueryRequest request, CancellationToken cancellationToken) {
        var data = await _grantSupportCategoryQueryRepository.GetAllAsync();
        var mappedData = _mapper.Map<List<GrantSupportCategoryDto>>(data);
        return new(ResponseType.Success, mappedData);
    }
}
