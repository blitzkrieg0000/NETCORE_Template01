
using Application.Interfaces.Repository.ProductGrowingSuggestionCategory;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.ProductGrowingSuggestionCategory.CreateProductGrowingSuggestionCategory
{
    public class CreateProductGrowingSuggestionCategoryCommandHandler : IRequestHandler<CreateProductGrowingSuggestionCategoryCommandRequest, CreateProductGrowingSuggestionCategoryCommandResponse>
    {
        private readonly IProductGrowingSuggestionCategoryQueryRepository _productGrowingSuggestionCategoryQueryRepository;
        private readonly IProductGrowingSuggestionCategoryCommandRepository _productGrowingSuggestionCategoryCommandRepository;
        private readonly IMapper _mapper;


        public CreateProductGrowingSuggestionCategoryCommandHandler(IProductGrowingSuggestionCategoryQueryRepository productGrowingSuggestionCategoryQueryRepository, IProductGrowingSuggestionCategoryCommandRepository productGrowingSuggestionCategoryCommandRepository, IMapper mapper)
        {
            _productGrowingSuggestionCategoryQueryRepository = productGrowingSuggestionCategoryQueryRepository;
            _productGrowingSuggestionCategoryCommandRepository = productGrowingSuggestionCategoryCommandRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductGrowingSuggestionCategoryCommandResponse> Handle(CreateProductGrowingSuggestionCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var existData = await _productGrowingSuggestionCategoryQueryRepository.GetByFilterAsync(x => x.Name == request.ProductGrowingSuggestionCategoryCreateDto.Name);
            if (existData != null)
            {
                return new(ResponseType.NotAllowed, request.ProductGrowingSuggestionCategoryCreateDto, "Bu kategori zaten mevcut.");
            }
            var data = _mapper.Map<Domain.Entities.Concrete.ProductGrowingSuggestionCategory>(request.ProductGrowingSuggestionCategoryCreateDto);
            await _productGrowingSuggestionCategoryCommandRepository.CreateAsync(data);
            await _productGrowingSuggestionCategoryCommandRepository.SaveAsync();
            return new(ResponseType.Success, "Kategori başarıyla eklendi.");
        }
    }

}
