using Application.Dtos.GrantSupport;
using FluentValidation;

namespace Application.Validators.GrantSupport;


public class GrantSupportUpdateDtoValidator : AbstractValidator<GrantSupportUpdateDto> {
    public sbyte MaxTitleLength { get; set; } = 100;
    public short MaxDescriptionLength { get; set; } = 2000;

    public GrantSupportUpdateDtoValidator() {
        RuleFor(x => x.Title)
        .NotEmpty().WithMessage("Başlık boş bırakılmamalıdır.")
        .Must(x => x.Length < MaxTitleLength).WithMessage($"Başlık {MaxTitleLength} karakterden az olmalıdır.");

        RuleFor(x => x.Description)
        .NotEmpty().WithMessage("Açıklama boş bırakılmamalıdır.")
        .Must(x => x?.Length < MaxDescriptionLength).WithMessage($"Açıklama {MaxDescriptionLength} karakterden az olmalıdır.");

        RuleFor(x => x.GrantSupportCategoryId)
        .NotEmpty().WithMessage("Bir kategori seçilmelidir.");
    }
}
