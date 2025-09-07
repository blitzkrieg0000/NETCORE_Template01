using Application.Models.NewsAnnouncement;
using FluentValidation;

namespace Application.Validators.NewsAnnouncement;


public class NewsAnnouncementCreateViewModelValidator : AbstractValidator<NewsAnnouncementCreateViewModel> {
    public sbyte MaxTitleLength { get; set; } = 100;
    public short MaxDescriptionLength { get; set; } = 2000;

    public NewsAnnouncementCreateViewModelValidator() {
        RuleFor(x => x.NewsAnnouncementCreateDto.Title)
        .NotNull().WithMessage("Başlık boş bırakılmamalıdır.")
        .NotEmpty().WithMessage("Başlık boş bırakılmamalıdır.")
        .MinimumLength(0).WithMessage("Başlık boş bırakılmamalıdır.")
        .MaximumLength(MaxTitleLength).WithMessage($"Başlık {MaxTitleLength} karakterden az olmalıdır.");


        RuleFor(x => x.NewsAnnouncementCreateDto.Description)
        .NotNull().WithMessage("Açıklama boş bırakılmamalıdır.")
        .NotEmpty().WithMessage("Açıklama boş bırakılmamalıdır.")
        .MinimumLength(0).WithMessage("Başlık boş bırakılmamalıdır.")
        .MaximumLength(MaxDescriptionLength).WithMessage($"Açıklama {MaxDescriptionLength} karakterden az olmalıdır.");


        RuleFor(x => x.NewsAnnouncementCreateDto.NewsAnnouncementCategoryId)
        .NotEmpty().WithMessage("Bir kategori seçilmelidir.");
    }
}
