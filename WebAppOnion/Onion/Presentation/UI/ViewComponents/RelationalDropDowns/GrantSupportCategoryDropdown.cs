using Application.Dtos.GrantSupportCategory;
using Application.Interfaces.Repository.GrantSupportCategory;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace UI.ViewComponents.RelationalDropDowns
{
    public class GrantSupportCategoryDropdown : ViewComponent
    {
        private readonly IGrantSupportCategoryQueryRepository _grantSupportCategoryQueryRepository;
        private readonly IMapper _mapper;

        public GrantSupportCategoryDropdown(IGrantSupportCategoryQueryRepository grantSupportCategoryQueryRepository, IMapper mapper)
        {
            _grantSupportCategoryQueryRepository = grantSupportCategoryQueryRepository;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? id)
        {
            var categories = await _grantSupportCategoryQueryRepository.GetAllAsync();
            var data = _mapper.Map<List<GrantSupportCategoryDto>>(categories);
            var selectList = new SelectList(data, "Id", "Name", id);
            return View("default", selectList);
        }
    }
}
