using System.Text.RegularExpressions;
using Application.Dtos.NewsAnnouncementCategory;
using FluentValidation;

namespace Application.Validators.NewsAnnouncementCategory;


public class NewsAnnouncementCategoryCreateDtoValidator : AbstractValidator<NewsAnnouncementCategoryCreateDto> {
    public sbyte MaxNameLength { get; set; } = 50;
    
    public NewsAnnouncementCategoryCreateDtoValidator() {
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
