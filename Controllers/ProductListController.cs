using MachineWeb.BAL;
using MachineWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineWeb.Controllers
{
    public class ProductListController : Controller
    {
        private readonly HomeService homeService;
        public ProductListController(HomeService ahomeService)
        {
         this.homeService= ahomeService;
        }
        public async Task<IActionResult> Index(string CategoryGuid)
        {
            CommonRequestDto<ProductDetailRequestDto> requestDto = new CommonRequestDto<ProductDetailRequestDto>
            {
                CompanyId = 1,
                UserId = 1,
                PageSize = 1,
                PageRecordCount = 100,
                Data = new ProductDetailRequestDto
                {
                    ProcId = 3,
                    CategoryGuid = Guid.Parse(CategoryGuid)
                }
            };

            var res = await homeService.GetCategoryWiseProductData(requestDto);
            if (res != null)
            {
                if (res.Data != null)
                {

                    res.Data.ForEach(x => x.ProductImage = "webimages/" + x.ProductImage);
                }
                return View(res.Data);
            }
            return View(new List<CategoryWiseProductDataResponse>());
        }
    }
}
