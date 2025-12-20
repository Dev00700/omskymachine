using MachineWeb.BAL;
using MachineWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineWeb.Controllers.adminpanel
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService aproductService)
        {
            this._productService = aproductService;
        }
        public async Task<IActionResult> Index()
        {
            CommonRequestDto<ProductSearchDto> requestDto = new CommonRequestDto<ProductSearchDto>
            {
                CompanyId = 1,
                UserId = 1,
                PageSize = 1,
                PageRecordCount = 10,
                Data = new ProductSearchDto
                {
                    ProductName = ""
                }
            };

            var res = await _productService.GetListService(requestDto);

            if (res.Data.Count() > 0)
            {
                res.Data.Where(x => !string.IsNullOrEmpty(x.ProductImage)).ToList().ForEach(x => x.ProductImage = "webimages/" + x.ProductImage);
                return View(res.Data);
            }
            return View(null);
        }


        
    }
}
