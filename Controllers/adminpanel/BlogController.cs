using MachineWeb.BAL;
using MachineWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineWeb.Controllers.adminpanel
{
    public class BlogController : Controller
    {
        private readonly BlogService _blogService;
        public BlogController(BlogService ablogService)
        {
            this._blogService = ablogService;    
        }
        public async Task<IActionResult> Index()
        {
            CommonRequestDto<BlogSearchDto> requestDto = new CommonRequestDto<BlogSearchDto>
            {
                CompanyId = 1,
                UserId = 1,
                PageSize= 1,
                PageRecordCount=10,
                Data = new BlogSearchDto
                {
                    Title = ""
                }
            };

            var res = await _blogService.GetListService(requestDto);

            if (res.Data.Count() > 0)
            {
                res.Data.Where(x=> !string.IsNullOrEmpty(x.Image)).ToList().ForEach(x => x.Image = "webimages/" + x.Image);
                return View(res.Data);
            }
            return View(null);
        }


    }
}
