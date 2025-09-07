using Application.Dtos.ProductGrowingSuggestion;
using Application.Interfaces.Repository.ProductGrowingSuggestion;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;


namespace Application.Features.CQRS.Queries.ProductGrowingSuggestion.UpdateProductGrowingSuggestion
{
    public class UpdateProductGrowingSuggestionQueryHandler : IRequestHandler<UpdateProductGrowingSuggestionQueryRequest, UpdateProductGrowingSuggestionQueryResponse>
    {
        private readonly IProductGrowingSuggestionQueryRepository _productGrowingSuggestionQueryRepository;
       
        private readonly IMapper _mapper;

        public UpdateProductGrowingSuggestionQueryHandler(IProductGrowingSuggestionQueryRepository productGrowingSuggestionQueryRepository, IMapper mapper)
        {
            _productGrowingSuggestionQueryRepository = productGrowingSuggestionQueryRepository;
           
            _mapper = mapper;
        }

        public async Task<UpdateProductGrowingSuggestionQueryResponse> Handle(UpdateProductGrowingSuggestionQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _productGrowingSuggestionQueryRepository.GetByIdAsync(request.Id);
            var res = _mapper.Map<ProductGrowingSuggestionUpdateDto>(data);
            return new(ResponseType.Success, res);

        }
    }
}


