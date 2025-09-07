using Application.Interfaces.Repository.ProductGrowingSuggestion;
using Application.Interfaces.Service.Storage;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.ProductGrowingSuggestion.Update_ProductGrowingSuggestion
{
    public class UpdateProductGrowingSuggestionCommandHandler :IRequestHandler<UpdateProductGrowingSuggestionCommandRequest ,UpdateProductGrowingSuggestionCommandResponse>

    {
        private readonly IProductGrowingSuggestionCommandRepository _productGrowingSuggestionCommandRepository;
        private readonly IProductGrowingSuggestionQueryRepository _productGrowingSuggestionQueryRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;
      

        public UpdateProductGrowingSuggestionCommandHandler(IProductGrowingSuggestionCommandRepository productGrowingSuggestionCommandRepository, IProductGrowingSuggestionQueryRepository productGrowingSuggestionQueryRepository, IStorageService storageService, IMapper mapper)
        {
            _productGrowingSuggestionCommandRepository = productGrowingSuggestionCommandRepository;
            _productGrowingSuggestionQueryRepository = productGrowingSuggestionQueryRepository;
            _storageService = storageService;
            _mapper = mapper;
        }

        public async Task<UpdateProductGrowingSuggestionCommandResponse> Handle(UpdateProductGrowingSuggestionCommandRequest request, CancellationToken cancellationToken)
        {
            var productGrowingSuggestion = await _productGrowingSuggestionQueryRepository.GetByIdAsync(request.ProductGrowingSuggestionUpdateDto.Id);
            _mapper.Map(request.ProductGrowingSuggestionUpdateDto, productGrowingSuggestion);

            if (request.ProductGrowingSuggestionUpdateDto.Files != null && request.ProductGrowingSuggestionUpdateDto.Files.Count > 0)
            {
                await _storageService.DeleteAsync(productGrowingSuggestion.Image);
                List<(string fileName, string savedPathName)> result = await _storageService.UploadAsync(request.ProductGrowingSuggestionUpdateDto.Files, "data/upload/Product_Growing_Suggestion");
                var (firstFileName, firstFileSavedPathName) = result.FirstOrDefault();
                productGrowingSuggestion.Image = firstFileSavedPathName;
            }

            _productGrowingSuggestionCommandRepository.UpdateOverwrite(productGrowingSuggestion);
            await _productGrowingSuggestionCommandRepository.SaveAsync();

            return new(ResponseType.Success, "Bilgiler güncellendi.");
        }
    }


}
