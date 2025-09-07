using Application.Dtos.NewsAnnouncement;
using Common.ResponseObjects;

namespace Application.Interfaces.Service.NewsAnnouncement;


public interface INewsAnnouncementService {

    Task<Response<NewsAnnouncementCreateDto>> CreateNewsAnnouncementAsync(NewsAnnouncementCreateDto? dto);

    Task<Response> UpdateNewsAnnouncementAsync(NewsAnnouncementUpdateDto? dto);

    Task<Response> RemoveNewsAnnouncement(Guid id);

}
