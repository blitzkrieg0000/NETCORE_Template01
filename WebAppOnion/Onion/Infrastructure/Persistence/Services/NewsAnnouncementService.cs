using Application.Consts;
using Application.Dtos.NewsAnnouncement;
using Application.Interfaces.Repository.File.Common.ImageFile;
using Application.Interfaces.Repository.NewsAnnouncement;
using Application.Interfaces.Service.NewsAnnouncement;
using Application.Interfaces.Service.Storage;
using AutoMapper;
using Common.ResponseObjects;

namespace Persistence.Services;


public class NewsAnnouncementService : INewsAnnouncementService {
    private readonly INewsAnnouncementQueryRepository _newsAnnouncementQueryRepository;
    private readonly INewsAnnouncementCommandRepository _newsAnnouncementCommandRepository;
    private readonly IImageFileQueryRepository _imageFileQueryRepository;
    private readonly IImageFileCommandRepository _imageFileCommandRepository;
    private readonly IStorageService _storageService;
    private readonly IMapper _mapper;

    public NewsAnnouncementService(INewsAnnouncementQueryRepository newsAnnouncementQueryRepository, INewsAnnouncementCommandRepository newsAnnouncementCommandRepository, IImageFileQueryRepository imageFileQueryRepository, IImageFileCommandRepository imageFileCommandRepository, IStorageService storageService, IMapper mapper) {
        _newsAnnouncementQueryRepository = newsAnnouncementQueryRepository;
        _newsAnnouncementCommandRepository = newsAnnouncementCommandRepository;
        _imageFileQueryRepository = imageFileQueryRepository;
        _imageFileCommandRepository = imageFileCommandRepository;
        _storageService = storageService;
        _mapper = mapper;
    }


    public async Task<Response<NewsAnnouncementCreateDto>> CreateNewsAnnouncementAsync(NewsAnnouncementCreateDto? dto) {
        var newsAnnouncement = _mapper.Map<Domain.Entities.Concrete.NewsAnnouncement>(dto);

        // Manage File
        if (dto.Files != null && dto.Files.Count == 1) {
            if (!UploadContentDefaults.AllowedContentTypes.Contains(dto.Files[0].ContentType) || dto.Files[0].Length > 7000000) {
                return new(ResponseType.NotAllowed, UploadContentDefaults.AllowedContentMessage);
            }

            List<(string fileName, string savedPathName)> result = await _storageService.UploadAsync(dto.Files, "data/upload/news_announcement");
            var (firstFileName, firstFileSavedPathName) = result.FirstOrDefault();

            //Yüklenen dosyayı veri tabanına kaydet
            Guid id = await _imageFileCommandRepository.CreateAsync(new() {
                FileName = firstFileName,
                Path = firstFileSavedPathName,
                Active = true
            });

            newsAnnouncement.Image = id;
        }

        await _newsAnnouncementCommandRepository.CreateAsync(newsAnnouncement);
        await _newsAnnouncementCommandRepository.SaveAsync();

        return new(ResponseType.Success, "Bilgiler eklendi.");
    }


    public async Task<Response> UpdateNewsAnnouncementAsync(NewsAnnouncementUpdateDto? dto) {
        var newsAnnouncement = await _newsAnnouncementQueryRepository.GetByIdAsync(dto.Id);
        _mapper.Map(dto, newsAnnouncement); // Varsayılan objenin üzerine mapleme yapılır. Bu sayede değiştirilmeyen veriler sıfırlanmaz.

        // Manage File
        if (dto.Files != null && dto.Files.Count == 1) {

            if (!UploadContentDefaults.AllowedContentTypes.Contains(dto.Files[0].ContentType) || dto.Files[0].Length > 7000000) {
                return new(ResponseType.NotAllowed, UploadContentDefaults.AllowedContentMessage);
            }
            
            List<(string fileName, string savedPathName)> result = await _storageService.UploadAsync(dto.Files, "data/upload/news_announcement");
            var (firstFileName, firstFileSavedPathName) = result.FirstOrDefault();

            if (newsAnnouncement.Image != null) {
                var imageEntity = await _imageFileQueryRepository.GetByIdAsync((Guid)newsAnnouncement.Image, false);
                if (imageEntity != null) {
                    await _storageService.DeleteAsync(imageEntity.Path);
                    imageEntity.FileName = firstFileName;
                    imageEntity.Path = firstFileSavedPathName;
                    imageEntity.Length = dto.Files[0].Length;
                }
            } else {
                var id = await _imageFileCommandRepository.CreateAsync(new() {
                    FileName = firstFileName,
                    Path = firstFileSavedPathName,
                    Length = dto.Files[0].Length,
                    Active = true
                });
                newsAnnouncement.Image = id;
            }
        }

        _newsAnnouncementCommandRepository.UpdateOverwrite(newsAnnouncement);
        await _newsAnnouncementCommandRepository.SaveAsync();

        return new(ResponseType.Success, "Bilgiler güncellendi.");

    }


    public async Task<Response> RemoveNewsAnnouncement(Guid id) {
        try {
            var newsAnnouncement = await _newsAnnouncementQueryRepository.GetByIdAsync(id);
            _newsAnnouncementCommandRepository.Remove(newsAnnouncement);

            if (newsAnnouncement.Image != null) {
                var imageEntity = await _imageFileQueryRepository.GetByIdAsync((Guid)newsAnnouncement.Image);
                if (imageEntity != null) {
                    await _storageService.DeleteAsync(imageEntity.Path);
                    _imageFileCommandRepository.Remove(imageEntity);
                }
            }
            await _newsAnnouncementCommandRepository.SaveAsync();
            return new(ResponseType.Success, "Veri Kaldırıldı.");
        } catch {
            return new(ResponseType.NotAllowed, "Veri kullanılıyor.");
        }
    }

}
