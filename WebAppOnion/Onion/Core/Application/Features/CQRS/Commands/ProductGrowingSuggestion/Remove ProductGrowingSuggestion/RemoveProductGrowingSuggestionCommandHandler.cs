using Application.Interfaces.Repository.ProductGrowingSuggestion;
using Application.Interfaces.Service.Storage;
using Common.ResponseObjects;
using MediatR;


namespace Application.Features.CQRS.Commands.ProductGrowingSuggestion.Remove_ProductGrowingSuggestion
{
    public class Remove_ProductGrowingSuggestionCommandHandler : IRequestHandler<RemoveProductGrowingSuggestionCommandRequest, RemoveProductGrowingSuggestionCommandResponse>
    {
        private readonly IProductGrowingSuggestionQueryRepository _productGrowingSuggestionQueryRepository;
        private readonly IProductGrowingSuggestionCommandRepository _productGrowingSuggestionCommandRepository;
        private readonly IStorageService? _storageService;
    

         public Remove_ProductGrowingSuggestionCommandHandler(IProductGrowingSuggestionQueryRepository productGrowingSuggestionQueryRepository, IProductGrowingSuggestionCommandRepository productGrowingSuggestionCommandRepository, IStorageService storageService)
        {
            _productGrowingSuggestionQueryRepository = productGrowingSuggestionQueryRepository;
            _productGrowingSuggestionCommandRepository = productGrowingSuggestionCommandRepository;
            _storageService = storageService;
        }

        public async Task<RemoveProductGrowingSuggestionCommandResponse> Handle(RemoveProductGrowingSuggestionCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var productGrowingSuggestion = await _productGrowingSuggestionQueryRepository.GetByIdAsync(request.Id);
                _productGrowingSuggestionCommandRepository.Remove(productGrowingSuggestion);
                if (productGrowingSuggestion.Image != null)
                {
                    await _storageService.DeleteAsync(productGrowingSuggestion.Image);
                }
                await _productGrowingSuggestionCommandRepository.SaveAsync();
                return new(ResponseType.Success, "Veri Kaldırıldı.");
            }
            catch
            {
                return new(ResponseType.NotAllowed, "Veri kullanılıyor.");
            }
        }
    }

}
