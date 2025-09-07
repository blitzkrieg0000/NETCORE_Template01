using Application.Interfaces.Repository.ProductGrowingSuggestion;
using Application.Interfaces.Service.Storage;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;


namespace Application.Features.CQRS.Commands.ProductGrowingSuggestion.CreateProductGrowingSuggestion {
    public class CreateProductGrowingSuggestionCommandHandler : IRequestHandler<CreateProductGrowingSuggestionCommandRequest, CreateProductGrowingSuggestionCommandResponse> {
        private readonly IProductGrowingSuggestionCommandRepository _productGrowingSuggestionCommandRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;
        public string[] AllowedContentTypes { get; set; } = { "image/png", "image/jpeg", "image/bmp", "image/svg+xml", "image/jpg" };
        public CreateProductGrowingSuggestionCommandHandler(IProductGrowingSuggestionCommandRepository productGrowingSuggestionCommandRepository, IStorageService storageService, IMapper mapper) {
            _productGrowingSuggestionCommandRepository = productGrowingSuggestionCommandRepository;
            _storageService = storageService;
            _mapper = mapper;
        }


        public async Task<CreateProductGrowingSuggestionCommandResponse> Handle(CreateProductGrowingSuggestionCommandRequest request, CancellationToken cancellationToken) {
            var productGrowingSuggestion = _mapper.Map<Domain.Entities.Concrete.ProductGrowingSuggestion>(request.ProductGrowingSuggestionCreateDto);

            if (request.ProductGrowingSuggestionCreateDto.Files != null && request.ProductGrowingSuggestionCreateDto.Files.Count == 1) {
                if (!AllowedContentTypes.Contains(request.ProductGrowingSuggestionCreateDto.Files[0].ContentType) || request.ProductGrowingSuggestionCreateDto.Files[0].Length > 7000000) {
                    return new(ResponseType.NotAllowed, "Eklenen dosya 7MB dan küçük JPG, JPEG, PNG, SVG formatında olmalıdır.");
                }

                List<(string fileName, string savedPathName)> result = await _storageService.UploadAsync(request.ProductGrowingSuggestionCreateDto.Files, "data/upload/product_growing_suggestion");
                var (firstFileName, firstFileSavedPathName) = result.FirstOrDefault();
                productGrowingSuggestion.Image = firstFileSavedPathName;
            }

            await _productGrowingSuggestionCommandRepository.CreateAsync(productGrowingSuggestion);
            await _productGrowingSuggestionCommandRepository.SaveAsync();

            return new(ResponseType.Success, "Öneri Eklendi");
        }

    }

}