using MachineWeb.BAL;
using MachineWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineWeb.Controllers
{
    public class MainCategoryViewComponent : ViewComponent
    {
        private readonly HomeService _homeService;

        public MainCategoryViewComponent(HomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var request = new CommonRequestDto<HomeRequestDto>
            {
                CompanyId = 1,
                UserId = 1,
                PageSize = 1,
                PageRecordCount = 100,
                Data = new HomeRequestDto
                {
                    ProcId = 2
                }
            };

            var categories = await _homeService.GetCategoryHomeData(request);
            return View(categories.Data);
        }
    }

}
