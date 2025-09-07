using Application.Dtos.NewsAnnouncement;
using FluentValidation;

namespace Application.Validators.NewsAnnouncement;


public class NewsAnnouncementUpdateDtoValidator : AbstractValidator<NewsAnnouncementUpdateDto> {
    public sbyte MaxTitleLength { get; set; } = 100;
    public short MaxDescriptionLength { get; set; } = 2000;

    public NewsAnnouncementUpdateDtoValidator() {
        RuleFor(x => x.Title)
        .NotEmpty().WithMessage("Başlık boş bırakılmamalıdır.")
        .Must(x => x.Length < MaxTitleLength).WithMessage($"Başlık {MaxTitleLength} karakterden az olmalıdır.");

        RuleFor(x => x.Description)
        .NotEmpty().WithMessage("Açıklama boş bırakılmamalıdır.")
        .Must(x => x?.Length < MaxDescriptionLength).WithMessage($"Açıklama {MaxDescriptionLength} karakterden az olmalıdır.");

        RuleFor(x => x.NewsAnnouncementCategoryId)
        .NotEmpty().WithMessage("Bir kategori seçilmelidir.");
    }
}
