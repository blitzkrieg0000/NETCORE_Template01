using Application.Dtos.NewsAnnouncement;
using Application.Interfaces.Repository.NewsAnnouncement;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Queries.NewsAnnoucement.UpdateNewsAnnouncement;


public class UpdateNewsAnnouncementCommandHandler : IRequestHandler<UpdateNewsAnnouncementQueryRequest, UpdateNewsAnnouncementQueryResponse> {
    private readonly INewsAnnouncementQueryRepository _newsAnnouncementQueryRepository;
    private readonly IMapper _mapper;

    public UpdateNewsAnnouncementCommandHandler(INewsAnnouncementQueryRepository newsAnnouncementQueryRepository, IMapper mapper) {
        _newsAnnouncementQueryRepository = newsAnnouncementQueryRepository;
        _mapper = mapper;
    }


    public async Task<UpdateNewsAnnouncementQueryResponse> Handle(UpdateNewsAnnouncementQueryRequest request, CancellationToken cancellationToken) {
        var data = await _newsAnnouncementQueryRepository.GetByIdWithRelationsAsync(request.Id);
        var res = _mapper.Map<NewsAnnouncementUpdateDto>(data);
        return new(ResponseType.Success, res);
    }
}
