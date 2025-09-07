using Application.Dtos.GrantSupport;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.GrantSupport
{
    public class GrantSupportCreateDtoValidator : AbstractValidator<GrantSupportCreateDto>
    {
        public GrantSupportCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılmamalıdır.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılmamalıdır.");
            RuleFor(x => x.GrantSupportCategoryId).NotEmpty().WithMessage("Bir kategori seçilmelidir.");
        }
    }
}
