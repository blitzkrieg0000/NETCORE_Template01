using Application.Dtos.NewsAnnouncementCategory;
using Application.Interfaces.Repository.NewsAnnouncementCategory;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace UI.ViewComponents.RelationalDropDowns;


public class NewsAnnouncementCategoryDropdown : ViewComponent {
    private readonly INewsAnnouncementCategoryQueryRepository _newsAnnouncementCategoryQueryRepository;
    private readonly IMapper _mapper;

    public NewsAnnouncementCategoryDropdown(INewsAnnouncementCategoryQueryRepository newsAnnouncementCategoryQueryRepository, IMapper mapper) {
        _newsAnnouncementCategoryQueryRepository = newsAnnouncementCategoryQueryRepository;
        _mapper = mapper;
    }


    public async Task<IViewComponentResult> InvokeAsync(Guid? id) {
        var categories = await _newsAnnouncementCategoryQueryRepository.GetAllAsync();
        var data = _mapper.Map<List<NewsAnnouncementCategoryDto>>(categories);
        var selectList = new SelectList(data, "Id", "Name", id);
        return View("default", selectList);
    }

}
