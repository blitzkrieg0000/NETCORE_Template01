using Application.Dtos.NewsAnnouncement;
using Application.Features.CQRS.Queries.NewsAnnoucement.GetRangeNewsAnnouncement;
using Application.Interfaces.Repository.NewsAnnouncement;
using Application.Models.NewsAnnouncement;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Queries.NewsAnnouncement.GetRangeNewsAnnouncement;


public class GetRangeNewsAnnouncementQueryHandler : IRequestHandler<GetRangeNewsAnnouncementQueryRequest, GetRangeNewsAnnouncementQueryResponse> {
    public readonly INewsAnnouncementQueryRepository _newsAnnouncementQueryRepository;
    public readonly IMapper _mapper;

    public GetRangeNewsAnnouncementQueryHandler(INewsAnnouncementQueryRepository newsAnnouncementQueryRepository, IMapper mapper) {
        _newsAnnouncementQueryRepository = newsAnnouncementQueryRepository;
        _mapper = mapper;
    }


    public async Task<GetRangeNewsAnnouncementQueryResponse> Handle(GetRangeNewsAnnouncementQueryRequest request, CancellationToken cancellationToken) {
        var data = await _newsAnnouncementQueryRepository.GetRangeWithRelationsAsync(request.Skip, request.Range, request.Filter);
        var mapped = _mapper.Map<List<NewsAnnouncementViewModel>>(data);
        return new (ResponseType.Success, mapped);
    }
}
