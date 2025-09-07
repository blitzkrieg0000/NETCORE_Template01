using Application.Dtos.GrantSupport;
using Application.Dtos.GrantSupportCategory;

namespace Application.Models.GrantSupportViewModel;


public class GrantSupportViewModel : GrantSupportDto {
    public GrantSupportCategoryDto GrantSupportCategoryDto { get; set; }
}
