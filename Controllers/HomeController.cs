using MachineWeb.BAL;
using MachineWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MachineWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService homeService;
        private readonly EnquiryService enquiryService;

        public HomeController(HomeService ahomeService, EnquiryService aenquiryService)
        {
            this.homeService = ahomeService;
            this.enquiryService = aenquiryService;
        }

        public async Task<IActionResult> Index()
        {
            var homeresponse = new HomeDto();
            CommonRequestDto<HomeRequestDto> _productrequestDto = new CommonRequestDto<HomeRequestDto>
            {
                CompanyId = 1,
                UserId = 1,
                PageSize = 1,
                PageRecordCount = 100,
                Data = new HomeRequestDto
                {
                    ProcId = 1
                }
            };

            var res = await homeService.GetHomeData(_productrequestDto);

            CommonRequestDto<HomeRequestDto> _categoryrequestDto = new CommonRequestDto<HomeRequestDto>
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

            var categoryres = await homeService.GetCategoryHomeData(_categoryrequestDto);

            if (res.Data.Count() > 0)
            {
                res.Data.Where(x => !string.IsNullOrEmpty(x.ProductImage)).ToList().ForEach(x => x.ProductImage = "webimages/" + x.ProductImage);
                categoryres.Data.Where(x => !string.IsNullOrEmpty(x.CategoryImage)).ToList().ForEach(x => x.CategoryImage = "webimages/" + x.CategoryImage);
                homeresponse.productDataResponses = res.Data;
                homeresponse.categoryDataResponses = categoryres.Data;
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


        public async Task<JsonResult> SendEnquiry([FromForm] EnquiryRequestDto enquiryRequestDto)
        {
            var res = new CommonResponseDto<_enquiryresdto>();

            CommonRequestDto<EnquiryRequestDto> requestDto = new CommonRequestDto<EnquiryRequestDto>
            {
                CompanyId = 1,
                UserId = 1,
                Data = new EnquiryRequestDto
                {
                    Name= enquiryRequestDto.Name,
                    Email= enquiryRequestDto.Email,
                    Subject = enquiryRequestDto.Subject,
                    Message= enquiryRequestDto.Message
                }
            };

            res = await enquiryService.SendEnquiry(requestDto);
            if (res != null)
            {
                if (res.Flag == 1)
                {
                    return Json(new { success = true, message = res.Message });
                }
                else
                {
                    return Json(new { success = false, message = res.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid data" });
            }

            return Json(new { success = false, message = "Something went wrong" });
        }

    }
}
