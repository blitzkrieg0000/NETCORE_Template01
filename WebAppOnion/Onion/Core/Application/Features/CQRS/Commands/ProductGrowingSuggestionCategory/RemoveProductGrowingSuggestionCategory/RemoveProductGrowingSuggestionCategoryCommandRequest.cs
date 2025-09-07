using Application.Features.CQRS.Commands.NewsAnnouncementCategory.RemoveNewsAnnouncementCategory;
using MediatR;

namespace Application.Features.CQRS.Commands.ProductGrowingSuggestionCategory.RemoveProductGrowingSuggestionCategory
{
    public class RemoveProductGrowingSuggestionCategoryCommandRequest : IRequest<RemoveProductGrowingSuggestionCategoryCommandResponse>
    {
        public Guid Id { get; set; }
    }
    
}