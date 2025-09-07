using Application.Dtos.NewsAnnouncementCategory;
using Application.Interfaces.Repository.NewsAnnouncementCategory;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Queries.NewsAnnouncementCategory.ListNewsAnnouncementCategory;


public class ListNewsAnnouncementCategoryQueryHandler : IRequestHandler<ListNewsAnnouncementCategoryQueryRequest, ListNewsAnnouncementCategoryQueryResponse> {

    private readonly INewsAnnouncementCategoryQueryRepository _newsAnnouncementCategoryQueryRepository;
    private readonly IMapper _mapper;

    public ListNewsAnnouncementCategoryQueryHandler(INewsAnnouncementCategoryQueryRepository newsAnnouncementCategoryQueryRepository, IMapper mapper) {
        _newsAnnouncementCategoryQueryRepository = newsAnnouncementCategoryQueryRepository;
        _mapper = mapper;
    }


    public async Task<ListNewsAnnouncementCategoryQueryResponse> Handle(ListNewsAnnouncementCategoryQueryRequest request, CancellationToken cancellationToken) {
        var newsAnnouncementCategory = await _newsAnnouncementCategoryQueryRepository.GetAllByFilterAsync(request.Filter);
        var data = _mapper.Map<List<NewsAnnouncementCategoryDto>>(newsAnnouncementCategory);
        return new ListNewsAnnouncementCategoryQueryResponse(ResponseType.Success, data);
    }

}
