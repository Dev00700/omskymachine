using MachineWeb.BAL;
using MachineWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineWeb.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly ProductService _productService;
        public ProductDetailController(ProductService aproductService)
        {
            this._productService = aproductService;
        }
        public async Task<IActionResult> Index(string ProductGuid)
        {
            CommonRequestDto<ProductRequestDto> requestDto = new CommonRequestDto<ProductRequestDto>
            {
                CompanyId = 1,
                UserId = 1,
                PageSize = 1,
                PageRecordCount = 10,
                Data = new ProductRequestDto
                {
                    ProductGuid = ProductGuid
                }
            };

            var res = await _productService.GetProductService(requestDto);
            if (res != null)
            {
                if (res.Data.ProductImagesJson != null)
                {
                    res.Data.productImageDtos = System.Text.Json.JsonSerializer.Deserialize<List<ProductImageDto>>(res.Data.ProductImagesJson);

                    res.Data.productImageDtos.ForEach(x => x.Image = "webimages/" + x.Image);
                }
                return View(res.Data);
            }
            return View(new ProductResponseDto());
        }
    }
}
