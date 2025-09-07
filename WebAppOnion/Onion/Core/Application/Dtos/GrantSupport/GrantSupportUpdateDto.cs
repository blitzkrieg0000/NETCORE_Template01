using Microsoft.AspNetCore.Http;

namespace Application.Dtos.GrantSupport;


public class GrantSupportUpdateDto : UpdateDto {
    public Guid? GrantSupportCategoryId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public IFormFileCollection? Files { get; set; }
}