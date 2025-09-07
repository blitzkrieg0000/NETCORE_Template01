using Application.Interfaces.Repository.NewsAnnouncement;
using Application.Models.NewsAnnouncement;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;
using X.PagedList;

namespace Application.Features.CQRS.Queries.NewsAnnouncement.ListNewsAnnouncement;


public class ListNewsAnnouncementQueryHandler : IRequestHandler<ListNewsAnnouncementQueryRequest, ListNewsAnnouncementQueryResponse> {
    private readonly INewsAnnouncementQueryRepository _newsAnnouncementQueryRepository;
    private readonly IMapper _mapper;

    public ListNewsAnnouncementQueryHandler(INewsAnnouncementQueryRepository newsAnnouncementQueryRepository, IMapper mapper) {
        _newsAnnouncementQueryRepository = newsAnnouncementQueryRepository;
        _mapper = mapper;
    }


    public async Task<ListNewsAnnouncementQueryResponse> Handle(ListNewsAnnouncementQueryRequest request, CancellationToken cancellationToken) {
        var newsAnnouncementsPagedList = await _newsAnnouncementQueryRepository.GetRangePagedListWithRelationsAsync(request.PaginatorModel.Page, request.PaginatorModel.Range, request.Filter);
        var pagedViewModel = _mapper.Map<IPagedList<NewsAnnouncementViewModel>>(newsAnnouncementsPagedList);
        return new(ResponseType.Success, pagedViewModel);
    }

}
