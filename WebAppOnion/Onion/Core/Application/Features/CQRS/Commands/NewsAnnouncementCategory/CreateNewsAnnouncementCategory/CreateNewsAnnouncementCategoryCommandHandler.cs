using Application.Interfaces.Repository.NewsAnnouncementCategory;
using AutoMapper;
using Common.ResponseObjects;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Commands.NewsAnnouncementCategory.CreateNewsAnnouncementCategory;

public class CreateNewsAnnouncementCategoryCommandHandler : IRequestHandler<CreateNewsAnnouncementCategoryCommandRequest, CreateNewsAnnouncementCategoryCommandResponse> {
    private readonly INewsAnnouncementCategoryQueryRepository _newsAnnouncementCategoryQueryRepository;
    private readonly INewsAnnouncementCategoryCommandRepository _newsAnnouncementCategoryCommandRepository;
    private readonly IMapper _mapper;

    public CreateNewsAnnouncementCategoryCommandHandler(INewsAnnouncementCategoryQueryRepository newsAnnouncementCategoryQueryRepository, INewsAnnouncementCategoryCommandRepository newsAnnouncementCategoryCommandRepository, IMapper mapper) {
        _newsAnnouncementCategoryQueryRepository = newsAnnouncementCategoryQueryRepository;
        _newsAnnouncementCategoryCommandRepository = newsAnnouncementCategoryCommandRepository;
        _mapper = mapper;
    }

    public async Task<CreateNewsAnnouncementCategoryCommandResponse> Handle(CreateNewsAnnouncementCategoryCommandRequest request, CancellationToken cancellationToken) {
        var existData = await _newsAnnouncementCategoryQueryRepository.GetByFilterAsync(x => x.Name == request.NewsAnnouncementCategoryCreateDto.Name);
        if (existData != null) {
            return new(ResponseType.NotAllowed, request.NewsAnnouncementCategoryCreateDto, "Bu kategori zaten mevcut.");
        }
        var data = _mapper.Map<Domain.Entities.Concrete.NewsAnnouncementCategory>(request.NewsAnnouncementCategoryCreateDto);
        await _newsAnnouncementCategoryCommandRepository.CreateAsync(data);
        await _newsAnnouncementCategoryCommandRepository.SaveAsync();
        return new(ResponseType.Success, "Kategori başarıyla eklendi.");
    }

}
