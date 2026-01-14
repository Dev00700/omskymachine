using MachineWeb.BAL;
using MachineWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static MachineWeb.Models.UserLogin;

namespace MachineWeb.Controllers.adminpanel
{
    public class CreateBlogController : Controller
    {
        private readonly BlogService _blogService;
        private readonly FileUploadService _fileuploadservice;
        public CreateBlogController(BlogService ablogService, FileUploadService afileuploadservice)
        {
            this._blogService = ablogService;
           this._fileuploadservice = afileuploadservice;
        }
        public async Task<IActionResult> Index(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return View(new BlogResponseDto());
            }
            CommonRequestDto<BlogRequestDto> requestDto = new CommonRequestDto<BlogRequestDto>
            {
                CompanyId = 1,
                UserId = 1,
                Data = new BlogRequestDto
                {
                    BlogGuid = Id
                }
            };
            var res = await _blogService.GetBlogService(requestDto);
            if(res != null)
            {
                res.Data.Image = string.IsNullOrEmpty(res.Data.Image) ? "" : "webimages/" + res.Data.Image;
                return View(res.Data);
            }
            return View(null);
        }

        public async Task<JsonResult> SaveBlog([FromForm]  BlogRequestDto blogRequestDto)
        {
            var res = new CommonResponseDto<_Blogresdto>();
            string _imagename = string.Empty;
            if(blogRequestDto.images!= null)
            {
                var imageNames = await _fileuploadservice.SaveImageInFolder(blogRequestDto.images);
                _imagename = imageNames.FirstOrDefault() ?? "";
            }

            if (blogRequestDto.BlogGuid != null && blogRequestDto.BlogGuid != "null")
            {
                CommonRequestDto<BlogRequestDto> requestDto = new CommonRequestDto<BlogRequestDto>
                {
                    CompanyId = 1,
                    UserId = 1,
                    Data = new BlogRequestDto
                    {
                        BlogGuid = blogRequestDto.BlogGuid,
                        Title = blogRequestDto.Title,
                        Description = blogRequestDto.Description,
                        Link = blogRequestDto.Link,
                        Image = _imagename,
                        IsActive = blogRequestDto.IsActive
                    }
                };

                 res = await _blogService.UpdateBlog(requestDto);
            }
            else
            {

                CommonRequestDto<BlogRequestDto> requestDto = new CommonRequestDto<BlogRequestDto>
                {
                    CompanyId = 1,
                    UserId = 1,
                    Data = new BlogRequestDto
                    {
                        Title = blogRequestDto.Title,
                        Description = blogRequestDto.Description,
                        Link = blogRequestDto.Link,
                        Image = _imagename,
                        IsActive = blogRequestDto.IsActive
                    }
                };

                res = await _blogService.SaveBlog(requestDto);
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
