using MachineWeb.BAL;
using MachineWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MachineWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService homeService;

        public HomeController(HomeService ahomeService)
        {
            this.homeService = ahomeService;
        }

        public async Task<IActionResult> Index()
        {
            var homeresponse = new HomeDto();
            CommonRequestDto<HomeRequestDto> _productrequestDto = new CommonRequestDto<HomeRequestDto>
            {
                CompanyId = 1,
                UserId = 1,
                PageSize = 1,
                PageRecordCount = 10,
                Data = new HomeRequestDto
                {
                    ProcId = 1
                }
            };

            var res = await homeService.GetHomeData(_productrequestDto);

            if (res.Data.Count() > 0)
            {
                res.Data.Where(x => !string.IsNullOrEmpty(x.ProductImage)).ToList().ForEach(x => x.ProductImage = "webimages/" + x.ProductImage);
                homeresponse.productDataResponses = res.Data;
                return View(homeresponse);
            }
            return View(new HomeDto());
        }

        public IActionResult Privacy()
        {
            return View();
        }

         
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }


    }
}
