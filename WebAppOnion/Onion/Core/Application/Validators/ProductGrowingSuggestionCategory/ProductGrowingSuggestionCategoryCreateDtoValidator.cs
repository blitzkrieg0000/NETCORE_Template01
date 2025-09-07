using Application.Dtos.ProductGrowingSuggestionCategory;
using FluentValidation;
using System.Text.RegularExpressions;


namespace Application.Validators.ProductGrowingSuggestionCategory
{
    public class ProductGrowingSuggestionCategoryCreateDtoValidator : AbstractValidator<ProductGrowingSuggestionCategoryCreateDto>
    {
        public sbyte MaxNameLength { get; set; } = 50;

        public ProductGrowingSuggestionCategoryCreateDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotNull().WithMessage("Başlık boş bırakılmamalıdır.")
            .NotEmpty().WithMessage("Başlık boş bırakılmamalıdır.")
            .MinimumLength(0).WithMessage("Başlık boş bırakılmamalıdır.")
            .MaximumLength(MaxNameLength).WithMessage($"Başlık {MaxNameLength} karakterden az olmalıdır.")
            .Must(x =>
                x != null &&
                !(Regex.IsMatch(x, @"[^\u0020-\u007E]") || Regex.IsMatch(x, @"[^a-zA-Z\d\s:]"))
            ).WithMessage("Sadece alfa-numerik karakterler kullanılmalıdır.");
        }

    }

}
