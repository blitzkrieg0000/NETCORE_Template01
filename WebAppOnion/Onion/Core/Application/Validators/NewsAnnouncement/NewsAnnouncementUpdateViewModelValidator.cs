
using Application.Models.NewsAnnouncement;
using FluentValidation;

namespace Application.Validators.NewsAnnouncement;

public class NewsAnnouncementUpdateViewModelValidator : AbstractValidator<NewsAnnouncementUpdateViewModel> {
    public sbyte MaxTitleLength { get; set; } = 100;
    public short MaxDescriptionLength { get; set; } = 2000;


    public NewsAnnouncementUpdateViewModelValidator() {
        RuleFor(x => x.NewsAnnouncementUpdateDto.Title)
        .NotNull().WithMessage("Başlık boş bırakılmamalıdır.")
        .NotEmpty().WithMessage("Başlık boş bırakılmamalıdır.")
        .MinimumLength(0).WithMessage("Başlık boş bırakılmamalıdır.")
        .MaximumLength(MaxTitleLength).WithMessage($"Başlık {MaxTitleLength} karakterden az olmalıdır.");

        RuleFor(x => x.NewsAnnouncementUpdateDto.Description)
        .NotNull().WithMessage("Açıklama boş bırakılmamalıdır.")
        .NotEmpty().WithMessage("Açıklama boş bırakılmamalıdır.")
        .MinimumLength(0).WithMessage("Başlık boş bırakılmamalıdır.")
        .MaximumLength(MaxDescriptionLength).WithMessage($"Açıklama {MaxDescriptionLength} karakterden az olmalıdır.");

        RuleFor(x => x.NewsAnnouncementUpdateDto.NewsAnnouncementCategoryId)
        .NotEmpty().WithMessage("Bir kategori seçilmelidir.");
    }


}
