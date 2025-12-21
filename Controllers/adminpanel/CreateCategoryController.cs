using MachineWeb.BAL;
using MachineWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static MachineWeb.Models.UserLogin;

namespace MachineWeb.Controllers.adminpanel
{
    public class CreateCategoryController : Controller
    {
        private readonly CategoryService _categoryService;
        private readonly FileUploadService _fileuploadservice;
        public CreateCategoryController(CategoryService acategoryService, FileUploadService afileuploadservice)
        {
            this._categoryService = acategoryService;
           this._fileuploadservice = afileuploadservice;
        }
        public async Task<IActionResult> Index(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return View(new CategoryResponseDto());
            }
            CommonRequestDto<CategoryRequestDto> requestDto = new CommonRequestDto<CategoryRequestDto>
            {
                CompanyId = 1,
                UserId = 1,
                Data = new CategoryRequestDto
                {
                    CategoryGuid = Id
                }
            };
            var res = await _categoryService.GetCategoryService(requestDto);
            if(res != null)
            {
                res.Data.CategoryImage = string.IsNullOrEmpty(res.Data.CategoryImage) ? "" : "webimages/" + res.Data.CategoryImage;
                return View(res.Data);
            }
            return View(null);
        }

        public async Task<JsonResult> SaveCategory([FromForm]  CategoryRequestDto categoryRequestDto)
        {
            var res = new CommonResponseDto<_categresdto>();
            string _imagename = string.Empty;
            if(categoryRequestDto.images!= null)
            {
                var imageNames = await _fileuploadservice.SaveImageInFolder(categoryRequestDto.images);
                _imagename = imageNames.FirstOrDefault() ?? "";
            }

            if (categoryRequestDto.CategoryGuid != null && categoryRequestDto.CategoryGuid != "null")
            {
                CommonRequestDto<CategoryRequestDto> requestDto = new CommonRequestDto<CategoryRequestDto>
                {
                    CompanyId = 1,
                    UserId = 1,
                    Data = new CategoryRequestDto
                    {
                        CategoryGuid = categoryRequestDto.CategoryGuid,
                        CategoryName = categoryRequestDto.CategoryName,
                        Image = _imagename,
                        IsActive = categoryRequestDto.IsActive
                    }
                };

                 res = await _categoryService.UpdateCategory(requestDto);
            }
            else
            {

                CommonRequestDto<CategoryRequestDto> requestDto = new CommonRequestDto<CategoryRequestDto>
                {
                    CompanyId = 1,
                    UserId = 1,
                    Data = new CategoryRequestDto
                    {
                        CategoryName = categoryRequestDto.CategoryName,
                        Image = _imagename,
                        IsActive = categoryRequestDto.IsActive
                    }
                };

                res = await _categoryService.SaveCategory(requestDto);
            }
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
