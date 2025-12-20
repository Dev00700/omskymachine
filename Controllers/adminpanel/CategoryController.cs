using MachineWeb.BAL;
using MachineWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineWeb.Controllers.adminpanel
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService acategoryService)
        {
            this._categoryService = acategoryService;    
        }
        public async Task<IActionResult> Index()
        {
            CommonRequestDto<CategorySearchDto> requestDto = new CommonRequestDto<CategorySearchDto>
            {
                CompanyId = 1,
                UserId = 1,
                PageSize= 1,
                PageRecordCount=10,
                Data = new CategorySearchDto
                {
                    CategoryName = ""
                }
            };

            var res = await _categoryService.GetListService(requestDto);

            if (res.Data.Count() > 0)
            {
                res.Data.Where(x=> !string.IsNullOrEmpty(x.CategoryImage)).ToList().ForEach(x => x.CategoryImage = "webimages/" + x.CategoryImage);
                return View(res.Data);
            }
            return View(null);
        }


        public async Task<JsonResult> SaveCategory(CategoryRequestDto categoryRequestDto)
        {
            CommonRequestDto<CategoryRequestDto> requestDto = new CommonRequestDto<CategoryRequestDto>
            {
                CompanyId = 1,
                UserId = 1,
                Data = categoryRequestDto
            };

            var res = await _categoryService.SaveCategory(requestDto);
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
