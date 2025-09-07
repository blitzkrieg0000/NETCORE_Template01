using System.Text.RegularExpressions;
using Application.Dtos.GrantSupportCategory;
using FluentValidation;

namespace Application.Validators.GrantSupportCategory;


public class GrantSupportCategoryCreateDtoValidator : AbstractValidator<GrantSupportCategoryCreateDto> {
    public sbyte MaxNameLength { get; set; } = 50;

    public GrantSupportCategoryCreateDtoValidator() {
        RuleFor(x => x.Name)
        .NotNull().WithMessage("Başlık boş bırakılmamalıdır.")
        .NotEmpty().WithMessage("Başlık boş bırakılmamalıdır.")
        .MinimumLength(0).WithMessage("Başlık boş bırakılmamalıdır.")
        .MaximumLength(MaxNameLength).WithMessage($"Başlık {MaxNameLength} karakterden az olmalıdır.")
        .Must(x =>
            x != null &&
            Regex.IsMatch(x, @"^[a-zA-Z0-9ğüşıöçĞÜŞİÖÇ]+$")
        ).WithMessage("Sadece alfa-numerik karakterler kullanılmalıdır.");
    }
}
