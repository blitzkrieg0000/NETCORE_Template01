using Application.Interfaces.Repository.GrantSupportCategory;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;
using C = Domain.Entities.Concrete;

namespace Application.Features.CQRS.Commands.GrantSupportCategory.CreateGrantSupportCategory;


public class CreateGrantSupportCategoryCommandHandler : IRequestHandler<CreateGrantSupportCategoryCommandRequest, CreateGrantSupportCategoryCommandResponse> {
    private readonly IGrantSupportCategoryQueryRepository _grantSupportCategoryQueryRepository;
    private readonly IGrantSupportCategoryCommandRepository _grantSupportCategoryCommandRepository;
    private readonly IMapper _mapper;

    public CreateGrantSupportCategoryCommandHandler(IGrantSupportCategoryQueryRepository grantSupportCategoryQueryRepository, IGrantSupportCategoryCommandRepository grantSupportCategoryCommandRepository, IMapper mapper) {
        _grantSupportCategoryQueryRepository = grantSupportCategoryQueryRepository;
        _grantSupportCategoryCommandRepository = grantSupportCategoryCommandRepository;
        _mapper = mapper;
    }

    public async Task<CreateGrantSupportCategoryCommandResponse> Handle(CreateGrantSupportCategoryCommandRequest request, CancellationToken cancellationToken) {
        var existData = await _grantSupportCategoryQueryRepository.GetByFilterAsync(x => x.Name == request.GrantSupportCategoryCreateDto.Name);
        if (existData != null) {
            return new(ResponseType.NotAllowed, request.GrantSupportCategoryCreateDto, "Bu kategori zaten mevcut.");
        }
        var data = _mapper.Map<C::GrantSupportCategory>(request.GrantSupportCategoryCreateDto);
        await _grantSupportCategoryCommandRepository.CreateAsync(data);
        await _grantSupportCategoryCommandRepository.SaveAsync();
        return new(ResponseType.Success, "Kategori başarıyla eklendi.");
    }

}
