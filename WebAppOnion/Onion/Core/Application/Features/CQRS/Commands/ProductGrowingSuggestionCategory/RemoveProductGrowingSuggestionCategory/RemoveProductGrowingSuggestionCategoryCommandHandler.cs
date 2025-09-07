using Application.Features.CQRS.Commands.NewsAnnouncementCategory.RemoveNewsAnnouncementCategory;
using Application.Interfaces.Repository.NewsAnnouncementCategory;
using Application.Interfaces.Repository.ProductGrowingSuggestionCategory;
using Common.ResponseObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.ProductGrowingSuggestionCategory.RemoveProductGrowingSuggestionCategory
{
    public class RemoveProductGrowingSuggestionCategoryCommandHandler :IRequestHandler<RemoveProductGrowingSuggestionCategoryCommandRequest, RemoveProductGrowingSuggestionCategoryCommandResponse>

    {
        private readonly IProductGrowingSuggestionCategoryCommandRepository _productGrowingSuggestionCategoryCommandRepository;
        private readonly IProductGrowingSuggestionCategoryQueryRepository _productGrowingSuggestionCategoryQueryRepository;

        public RemoveProductGrowingSuggestionCategoryCommandHandler(IProductGrowingSuggestionCategoryCommandRepository productGrowingSuggestionCategoryCommandRepository, IProductGrowingSuggestionCategoryQueryRepository productGrowingSuggestionCategoryQueryRepository)
        {
            _productGrowingSuggestionCategoryCommandRepository = productGrowingSuggestionCategoryCommandRepository;
            _productGrowingSuggestionCategoryQueryRepository = productGrowingSuggestionCategoryQueryRepository;
        }

        public async Task<RemoveProductGrowingSuggestionCategoryCommandResponse> Handle(RemoveProductGrowingSuggestionCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _productGrowingSuggestionCategoryQueryRepository.GetByIdAsync(request.Id);
                _productGrowingSuggestionCategoryCommandRepository.Remove(entity);
                await _productGrowingSuggestionCategoryCommandRepository.SaveAsync();
                return new(ResponseType.Success, "Kategori Kaldırıldı.");
            }
            catch
            {
                return new(ResponseType.NotAllowed, "Kategori kullanımdayken silinemez.");
            }
        }
    }
}
